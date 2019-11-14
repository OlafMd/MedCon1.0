using BOp.Providers;
using CL1_CMN;
using CL1_CMN_CTR;
using CL1_CMN_PRO;
using CL1_HEC;
using CL1_HEC_ACT;
using CL1_HEC_CAS;
using CL1_HEC_PRC;
using CL1_ORD_PRC;
using CL1_USR;
using CSV2Core.SessionSecurity;
using CSV2Core_MySQL.Dictionaries.MultiTable;
using CSV2Core_MySQL.Support;
using DLCore_TokenVerification;
using LogUtils;
using MMDocConnectDBMethods.Case.Atomic.Manipulation;
using MMDocConnectDBMethods.Case.Atomic.Retrieval;
using MMDocConnectDBMethods.Doctor.Atomic.Retrieval;
using MMDocConnectDBMethods.MainData.Atomic.Retrieval;
using MMDocConnectDBMethods.MainData.Complex.Retrieval;
using MMDocConnectDBMethods.Order.Atomic.Retrieval;
using MMDocConnectDBMethods.Order.Complex.Manipulation;
using MMDocConnectDBMethods.Order.Complex.Model;
using MMDocConnectDBMethods.Patient.Atomic.Retrieval;
using MMDocConnectDBMethods.Pharmacy.Atomic.Manipulation;
using MMDocConnectDBMethods.Pharmacy.Atomic.Retrieval;
using MMDocConnectDBMethods.Pharmacy.Model;
using MMDocConnectDocApp;
using MMDocConnectDocAppInterfaces;
using MMDocConnectDocAppModels;
using MMDocConnectElasticSearchMethods;
using MMDocConnectElasticSearchMethods.Case.Manipulation;
using MMDocConnectElasticSearchMethods.Case.Retrieval;
using MMDocConnectElasticSearchMethods.Models;
using MMDocConnectElasticSearchMethods.Order.Retrieval;
using MMDocConnectElasticSearchMethods.Patient.Manipulation;
using MMDocConnectUtils;
using Newtonsoft.Json;
using SharedServiceUtils;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;

namespace MMDocConnectDocAppServices
{
    public class OrdersDataService : BaseVerification, IOrdersDataService
    {
        #region Retrieval

        public IEnumerable<object> GetOrderStats(ElasticParameterObject sort_parameter, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var request = HttpContext.Current.Request;
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(request);

            transaction = new TransactionalInformation();
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            try
            {
                var dbConnection = DBSQLSupport.CreateConnection(connectionString);
                DbTransaction dbTransaction = null;
                try
                {
                    dbConnection.Open();
                    dbTransaction = dbConnection.BeginTransaction();

                    var result = new List<object>();
                    var default_shipping_date_offset = GetDefaultShippingDateOffset(data.PracticeID, dbConnection, dbTransaction, securityTicket);
                    dbTransaction.Commit();

                    sort_parameter.page_size = int.MaxValue;
                    sort_parameter.start_row_index = 0;
                    sort_parameter.default_shipping_date_offset = default_shipping_date_offset;

                    var order_ids_eligibile_for_settlement = sort_parameter.filter_by.orders == true ? GetOrderIdsEligibleForSettlement(data.PracticeID, dbConnection, dbTransaction, securityTicket) : null;

                    var orders = Get_Orders.GetAllPracticeOrders(data.PracticeID.ToString(), sort_parameter, order_ids_eligibile_for_settlement, securityTicket.TenantID.ToString()).ToList();
                    var total_order_count = orders.Count;
                    var grouped_by_drug = orders.GroupBy(t => t.drug).ToDictionary(t => t.Key, t => t.ToList());

                    return grouped_by_drug.Select(drug =>
                    {
                        var number_of_orders = drug.Value.Count;
                        var percentage = number_of_orders * 100.0 / total_order_count;
                        return new
                        {
                            drug_name = drug.Key,
                            order_count = number_of_orders,
                            percentage = Math.Round(percentage, 2)
                        };
                    }).ToList();
                }
                finally
                {
                    if (dbConnection.State == System.Data.ConnectionState.Open)
                    {
                        dbConnection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, ex), data.PracticeName);

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }

            return Enumerable.Empty<object>();
        }

        private IEnumerable<string> GetOrderIdsEligibleForSettlement(Guid practiceId, DbConnection dbConnection, DbTransaction dbTransaction, SessionSecurityTicket securityTicket)
        {
            var consents = cls_Get_Patient_Consents_with_Period_for_Practice.Invoke(dbConnection, dbTransaction, new P_PA_GPCwPfP_1538
            {
                PracticeID = practiceId
            }, securityTicket).Result.GroupBy(t => t.HEC_Patient_RefID).ToDictionary(t => t.Key, t => t.GroupBy(x => x.Ext_CMN_CTR_Contract_RefID).ToDictionary(x => x.Key, x => x.ToList()));

            if (consents.Any())
            {
                var allContractParameters = ORM_CMN_CTR_Contract_Parameter.Query.Search(dbConnection, dbTransaction, new ORM_CMN_CTR_Contract_Parameter.Query() { Tenant_RefID = securityTicket.TenantID, IsDeleted = false })
                    .GroupBy(t => t.Contract_RefID).ToDictionary(t => t.Key, t => t.ToList());
                var patientIds = consents.Keys.ToArray();
                var potentialOrders = cls_Get_Potential_Orders_Eligible_for_Settlement.Invoke(dbConnection, dbTransaction, new P_OR_GPOEfS_1518() { PatientIDs = patientIds }, securityTicket).Result;
                var performedOps = cls_Get_PerformedOpDates_for_PatientIDs.Invoke(dbConnection, dbTransaction, new P_CAS_GPOpDfPIDs_1509() { PatientIDs = patientIds }, securityTicket).Result
                    .GroupBy(t => t.PatientID).ToDictionary(t => t.Key, t => t.ToList());

                var result = potentialOrders.Where(t =>
                {
                    if (consents.ContainsKey(t.patient_id))
                    {
                        var potentialConsents = consents[t.patient_id].Where(c => c.Value.First().ValidFrom.Date <= t.treatment_date.Date).ToList();
                        foreach (var consent in potentialConsents.Where(pc => pc.Value.Any(v => v.HealthcareProduct_RefID == t.drug_id)))
                        {
                            var consentInfo = consent.Value.First();
                            var contractParameters = allContractParameters[consent.Key];
                            var is_consent_auto_renewed_by_op = contractParameters.Any(p => p.ParameterName == "OP renews patient consent");
                            var consent_valid_for_months_parameter = contractParameters.SingleOrDefault(p => p.ParameterName == "Duration of participation consent – Month");
                            var consent_valid_for_months = consent_valid_for_months_parameter != null && consent_valid_for_months_parameter.IfNumericValue_Value < 2000000 ? (int)consent_valid_for_months_parameter.IfNumericValue_Value : 12;

                            var consent_covers_order = false;
                            consent_covers_order = consentInfo.ValidFrom.AddMonths(consent_valid_for_months).Date > t.treatment_date.Date;
                            if (consent_covers_order)
                            {
                                return consent_covers_order;
                            }
                            else if (is_consent_auto_renewed_by_op && performedOps.ContainsKey(t.patient_id))
                            {
                                var latestOpDateBeforeOrder = performedOps[t.patient_id].FirstOrDefault(x => x.TreatmentDate.Date <= t.treatment_date.Date);
                                if (latestOpDateBeforeOrder != null)
                                {
                                    var opIsCloseEnoughToOrderToExtendConsent = latestOpDateBeforeOrder.TreatmentDate.AddMonths(consent_valid_for_months).Date >= t.treatment_date.Date;
                                    if (opIsCloseEnoughToOrderToExtendConsent)
                                    {
                                        return opIsCloseEnoughToOrderToExtendConsent;
                                    }
                                }
                            }
                        }
                    }

                    return false;
                }).Select(t => t.order_id).Select(t => t.ToString()).ToList();

                return result;
            }

            return null;
        }

        public IEnumerable<DateTime> GetTreatmentDates(IEnumerable<Guid> order_ids, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var request = HttpContext.Current.Request;
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(request);

            transaction = new TransactionalInformation();
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            try
            {
                using (var dbConnection = DBSQLSupport.CreateConnection(connectionString))
                {
                    dbConnection.Open();
                    var dbTransaction = dbConnection.BeginTransaction();
                    return cls_Get_TreatmentDates_for_OrderIDs.Invoke(dbConnection, dbTransaction, new P_OR_GTDfOIDs_1400() { OrderIDs = order_ids.ToArray() }, securityTicket).Result.Select(t => t.treatment_date).ToList();
                }
            }
            catch (Exception ex)
            {
                Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, ex), data.PracticeName);

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }

            return Enumerable.Empty<DateTime>();
        }

        public long GetOrderCount(string search_params, string hip_name, DateTime orders_from_date, DateTime orders_to_date, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var request = HttpContext.Current.Request;
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(request);

            transaction = new TransactionalInformation();
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;
            long result = 0;

            try
            {
                result = Get_Orders.GetOrderCount(search_params, hip_name, data.PracticeID, securityTicket.TenantID.ToString(), orders_from_date, orders_to_date);
            }
            catch (Exception ex)
            {
                Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, ex), data.PracticeName);

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }

            return result;
        }

        public IEnumerable<Guid> GetOrderIDsToSubmit(string search_criteria, bool all_selected, IEnumerable<Guid> selected_ids, IEnumerable<Guid> deselected_ids, string hip_name, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var request = HttpContext.Current.Request;
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(request);

            transaction = new TransactionalInformation();
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            try
            {
                var result = selected_ids;
                if (all_selected || (deselected_ids != null && deselected_ids.Any()))
                {
                    if (deselected_ids == null)
                    {
                        deselected_ids = new List<Guid>();
                    }

                    var orders = Get_Orders.GetPracticeOrders(0, int.MaxValue, data.PracticeID.ToString(), securityTicket.TenantID.ToString(), search_criteria, hip_name, DateTime.MinValue, DateTime.MaxValue, Array.ConvertAll(deselected_ids.ToArray(), x => x.ToString())).ToList();
                    result = orders.Select(t => Guid.Parse(t.id));
                }

                return result;
            }
            catch (Exception ex)
            {
                Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, ex), data.PracticeName);

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }

            return Enumerable.Empty<Guid>();
        }

        public Order GetOrderDetails(Guid order_id, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var request = HttpContext.Current.Request;
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(request);

            transaction = new TransactionalInformation();
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            try
            {
                var dbConnection = DBSQLSupport.CreateConnection(connectionString);
                DbTransaction dbTransaction = null;
                try
                {
                    dbConnection.Open();
                    dbTransaction = dbConnection.BeginTransaction();

                    var order_data = cls_Get_Case_Order_Data_for_OrderHeaderID.Invoke(dbConnection, dbTransaction, new P_CAS_GCODfOHID_1413() { OrderHeaderID = order_id }, securityTicket).Result;
                    if (order_data != null)
                    {
                        var order = new Order();
                        order.comment = order_data.order_comment;
                        order.drug_id = order_data.drug_id;
                        order.fee_waived = order_data.patient_fee_waived;
                        order.id = order_id;
                        order.label_only = order_data.label_only;
                        order.patient_name = String.Format("{0} {1} ({2})", order_data.patient_first_name, order_data.patient_last_name, order_data.patient_birthdate.ToString("dd.MM.yyyy"));
                        order.treatment_date = order_data.treatment_date.ToString("dd.MM.yyyy");
                        order.case_id = order_data.case_id;
                        order.is_only_order = !order_data.treatment_exist;

                        var invoice_property = cls_Get_CasePropertyValue_for_CaseID_and_CasePropertyGpmID.Invoke(dbConnection, dbTransaction, new P_CAS_GCPVfCIDaCGpmID_1346()
                        {
                            CaseID = order_data.case_id,
                            PropertyGpmID = ECaseProperty.SendInvoiceToPractice.Value()
                        }, securityTicket).Result;

                        if (invoice_property != null)
                        {
                            order.send_invoice_to_practice = invoice_property.Value_Boolean;
                        }

                        return order;
                    }

                    dbTransaction.Commit();
                }
                finally
                {
                    if (dbConnection.State == System.Data.ConnectionState.Open)
                    {
                        dbConnection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, ex), data.PracticeName);

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }

            return null;
        }

        public object GetPracticeOrders(ElasticParameterObject sort_parameter, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var request = HttpContext.Current.Request;
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(request);

            transaction = new TransactionalInformation();
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            try
            {
                var dbConnection = DBSQLSupport.CreateConnection(connectionString);
                DbTransaction dbTransaction = null;
                try
                {
                    dbConnection.Open();
                    dbTransaction = dbConnection.BeginTransaction();

                    var default_shipping_date_offset = GetDefaultShippingDateOffset(data.PracticeID, dbConnection, dbTransaction, securityTicket);
                    
                    var orders = Get_Orders.GetPracticeOrders(sort_parameter.start_row_index, int.MaxValue, data.PracticeID.ToString(), securityTicket.TenantID.ToString(), sort_parameter.search_params,
                        !String.IsNullOrEmpty(sort_parameter.hip_name) ? sort_parameter.hip_name.ToLower() : null, sort_parameter.orders_from_date, sort_parameter.orders_to_date).ToList();

                    #region statistic
                    var total_order_count = orders.Count;
                    var grouped_by_drug = orders.GroupBy(t => t.drug).ToDictionary(t => t.Key, t => t.ToList());


                    var order_stats = grouped_by_drug.Select(drug =>
                    {
                        var number_of_orders = drug.Value.Count;
                        var percentage = number_of_orders * 100.0 / total_order_count;
                        return new Order_Stats()
                        {
                            drug_name = drug.Key,
                            order_count = number_of_orders,
                            percentage = Math.Round(percentage, 2)
                        };
                    }).OrderBy(t => t.drug_name).ToList();


                    #endregion
                    if (orders.Any())
                    {
                        var order_ids = orders.Select(t => Guid.Parse(t.id)).ToArray();
                        var all_order_information = cls_Get_OrderInfo_for_OrderIDs.Invoke(dbConnection, dbTransaction, new P_OR_GOIfOIDs_1453() { HeaderIDs = order_ids }, securityTicket).Result.GroupBy(x => x.order_id).ToDictionary(t => t.Key, t => t.Single());
                        var all_statuses_for_orders = cls_Get_Order_Status_History_for_OrderIDs.Invoke(dbConnection, dbTransaction, new P_OR_GOSHfOIDs_1528
                        {
                            OrderIDs = order_ids
                        }, securityTicket).Result.GroupBy(x => x.OrderID).ToDictionary(t => t.Key, t => t.ToList());

                        var result = orders.Select(order =>
                        {
                            order.group_name = order.treatment_date.ToString("d. MMMM yyyy", new CultureInfo("de")).ToUpper();
                            if (order.treatment_date.AddDays(-default_shipping_date_offset).Date <= DateTime.Now.Date)
                            {
                                order.status_drug_order = "MO8";
                            }

                            var extended = new Order_Model_Extended();
                            extended.PopulateBase(order);

                            var order_id = Guid.Parse(order.id);
                            if (all_order_information.ContainsKey(order_id))
                            {
                                var order_information = all_order_information[order_id];
                                extended.patient_fee_waived = order_information.patient_fee_waived;
                                extended.label_only = order_information.label_only;
                                extended.invoice_to_practice = order_information.bill_to_bpt != Guid.Empty;
                                extended.position_comment = order_information.position_comment;
                            }

                            if (all_statuses_for_orders.ContainsKey(order_id))
                            {
                                var statuses_for_order = all_statuses_for_orders[order_id];
                                extended.create_date_string = statuses_for_order.Any(x => x.StatusCode == 0) ? statuses_for_order.First(x => x.StatusCode == 0).StatusChangedOn.ToString("dd.MM.yyyy") : "-";
                            }

                            return extended;
                        }).ToList();

                        dbTransaction.Commit();

                        return new
                        {
                            orders = result,
                            order_stats = order_stats
                        };
                    }
                }
                finally
                {
                    if (dbConnection.State == System.Data.ConnectionState.Open)
                    {
                        dbConnection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, ex), data.PracticeName);

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }

            return new { orders = Enumerable.Empty<Order_Model_Extended>(), order_stats = new object[] { } };
        }

        public Return_Order_Model GetAllPracticeOrders(ElasticParameterObject sort_parameter, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var request = HttpContext.Current.Request;
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(request);

            transaction = new TransactionalInformation();
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            try
            {
                var dbConnection = DBSQLSupport.CreateConnection(connectionString);
                DbTransaction dbTransaction = null;
                try
                {
                    dbConnection.Open();
                    dbTransaction = dbConnection.BeginTransaction();
                    var repacked_orders = new List<Order_Model_Extended>();
                    var order_stats = new List<Order_Stats>();

                    var default_shipping_date_offset = GetDefaultShippingDateOffset(data.PracticeID, dbConnection, dbTransaction, securityTicket);
                    sort_parameter.default_shipping_date_offset = default_shipping_date_offset;

                    if (!String.IsNullOrEmpty(sort_parameter.search_params))
                    {
                        sort_parameter.search_params = sort_parameter.search_params.ToLower();
                    }

                    #region statistic
                    var page_size = sort_parameter.page_size;
                    var start_row_index = sort_parameter.start_row_index;

                    sort_parameter.page_size = Int32.MaxValue;
                    sort_parameter.start_row_index = 0;
                    var order_ids_eligibile_for_settlement = sort_parameter.filter_by.orders == true ? GetOrderIdsEligibleForSettlement(data.PracticeID, dbConnection, dbTransaction, securityTicket) : null;
                    var orders_for_stats = Get_Orders.GetAllPracticeOrders(data.PracticeID.ToString(), sort_parameter, order_ids_eligibile_for_settlement, securityTicket.TenantID.ToString()).ToList();

                    var total_order_count = orders_for_stats.Count;
                    var grouped_by_drug = orders_for_stats.GroupBy(t => t.drug).ToDictionary(t => t.Key, t => t.ToList());


                    order_stats = grouped_by_drug.Select(drug =>
                    {
                        var number_of_orders = drug.Value.Count;
                        var percentage = number_of_orders * 100.0 / total_order_count;
                        return new Order_Stats()
                        {
                            drug_name = drug.Key,
                            order_count = number_of_orders,
                            percentage = Math.Round(percentage, 2)
                        };
                    }).OrderBy(t => t.drug_name).ToList();
                    #endregion

                    sort_parameter.page_size = page_size;
                    sort_parameter.start_row_index = start_row_index;
                    var orders = Get_Orders.GetAllPracticeOrders(data.PracticeID.ToString(), sort_parameter, order_ids_eligibile_for_settlement, securityTicket.TenantID.ToString()).ToList();
                    if (orders.Any())
                    {
                        #region repack data
                        var order_ids = orders.Select(t => Guid.Parse(t.id)).ToArray();
                        var case_ids = orders.Select(t => Guid.Parse(t.case_id)).ToArray();

                        var all_order_information = cls_Get_OrderInfo_for_OrderIDs.Invoke(dbConnection, dbTransaction, new P_OR_GOIfOIDs_1453() { HeaderIDs = order_ids }, securityTicket).Result.GroupBy(x => x.order_id).ToDictionary(t => t.Key, t => t.First());
                        var all_treatment_informations = cls_Get_Case_Treatments_on_Tenant.Invoke(dbConnection, dbTransaction, new P_CAS_GCToT_1418
                        {
                            CaseIDs = case_ids
                        }, securityTicket).Result.GroupBy(x => x.CaseID).ToDictionary(x => x.Key, x => x.First());
                        var all_statuses_for_orders = cls_Get_Order_Status_History_for_OrderIDs.Invoke(dbConnection, dbTransaction, new P_OR_GOSHfOIDs_1528
                        {
                            OrderIDs = order_ids
                        }, securityTicket).Result.GroupBy(x => x.OrderID).ToDictionary(t => t.Key, t => t.ToList());

                        repacked_orders = orders.Select(order =>
                        {
                            var order_id = Guid.Parse(order.id);
                            var case_id = Guid.Parse(order.case_id);

                            if (order.status_drug_order == "MO0")
                            {
                                if (order.treatment_date.AddDays(-default_shipping_date_offset).Date <= DateTime.Now.Date)
                                {
                                    order.status_drug_order = "MO8";
                                }
                            }

                            switch (sort_parameter.sort_by)
                            {
                                case "treatment_date": order.group_name = order.treatment_date.ToString("MMMM yyyy", new CultureInfo("de")).ToUpper(); break;
                                case "patient_name": order.group_name = order.patient_name; break;
                                case "drug": order.group_name = order.drug; break;
                                case "pharmacy_name": order.group_name = order.pharmacy_name; break;
                                case "diagnose": order.group_name = order.diagnose; break;
                                case "localization": order.group_name = order.localization; break;
                                case "treatment_doctor_name": order.group_name = order.treatment_doctor_name; break;
                                case "status_drug_order": order.group_name = order.status_drug_order; break;
                            }


                            var extended = new Order_Model_Extended();
                            extended.PopulateBase(order);
                            extended.delivery_date_string = extended.delivery_time_from.ToString("dd.MM.yyyy");

                            if (all_order_information.ContainsKey(order_id))
                            {
                                var order_information = all_order_information[order_id];
                                extended.patient_fee_waived = order_information.patient_fee_waived;
                                extended.label_only = order_information.label_only;
                                extended.invoice_to_practice = order_information.bill_to_bpt != Guid.Empty;
                                extended.header_comment = order_information.header_comment;
                                extended.position_comment = order_information.position_comment;
                            }
                            if (all_treatment_informations.ContainsKey(case_id))
                            {
                                var treatment = all_treatment_informations[case_id];
                                extended.is_treatment_submitted = treatment.IsPerformed;
                            }
                            if (all_statuses_for_orders.ContainsKey(order_id))
                            {
                                var statuses_for_order = all_statuses_for_orders[order_id].OrderBy(x => x.StatusChangedOn);
                                extended.submission_date_string = statuses_for_order.Any(x => x.StatusCode == 1) ? statuses_for_order.First(x => x.StatusCode == 1).StatusChangedOn.ToString("dd.MM.yyyy") : "-";
                            }

                            return extended;
                        }).ToList();
                        #endregion

                        dbTransaction.Commit();

                    }

                    var returnObject = new Return_Order_Model()
                    {
                        orders = repacked_orders,
                        order_stats = order_stats
                    };

                    return returnObject;

                }
                finally
                {
                    if (dbConnection.State == System.Data.ConnectionState.Open)
                    {
                        dbConnection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, ex), data.PracticeName);

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }

            return new Return_Order_Model();
        }

        public double GetDefaultShippingDateOffset(Guid practice_id, DbConnection dbConnection, DbTransaction dbTransaction, SessionSecurityTicket securityTicket)
        {
            var default_shipping_date_offset = 0d;
            var default_shipping_date_offset_property = cls_Get_Practice_PropertyValue_for_PropertyName_and_PracticeID.Invoke(dbConnection, dbTransaction, new P_DO_GPPVfPNaPID_0916()
            {
                PracticeID = practice_id,
                PropertyName = "Default Shipping Date Offset"
            }, securityTicket).Result;

            if (default_shipping_date_offset_property != null)
            {
                default_shipping_date_offset = default_shipping_date_offset_property.NumericValue;
            }

            return default_shipping_date_offset;
        }

        public string GetOrderComment(Guid id, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            transaction = new TransactionalInformation();
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            try
            {
                var dbConnection = DBSQLSupport.CreateConnection(connectionString);
                DbTransaction dbTransaction = null;
                try
                {
                    dbConnection.Open();
                    dbTransaction = dbConnection.BeginTransaction();

                    var order = ORM_ORD_PRC_ProcurementOrder_Position.Query.Search(dbConnection, dbTransaction, new ORM_ORD_PRC_ProcurementOrder_Position.Query()
                    {
                        ProcurementOrder_Header_RefID = id,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).SingleOrDefault();

                    dbTransaction.Commit();

                    if (order != null)
                    {
                        return order.Position_Comment;
                    }
                }
                finally
                {
                    if (dbConnection.State == System.Data.ConnectionState.Open)
                    {
                        dbConnection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, ex), data.PracticeName);

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }

            return null;
        }

        public Guid GetOrderIDForCaseID(Guid case_id, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var request = HttpContext.Current.Request;
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(request);

            transaction = new TransactionalInformation();
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;
            Guid orderID = Guid.Empty;

            try
            {
                var dbConnection = DBSQLSupport.CreateConnection(connectionString);
                DbTransaction dbTransaction = null;
                try
                {
                    dbConnection.Open();
                    dbTransaction = dbConnection.BeginTransaction();

                    orderID = cls_Get_OrderID_for_CaseID.Invoke(connectionString, new P_OR_GOIDfCID_0921
                    {
                        CaseID = case_id
                    }, securityTicket).Result.OrderID;

                    dbTransaction.Commit();
                }
                finally
                {
                    if (dbConnection.State == System.Data.ConnectionState.Open)
                    {
                        dbConnection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, ex), data.PracticeName);

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }

            return orderID;
        }

        public String GetOrderReportURL(Guid order_id, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var request = HttpContext.Current.Request;
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(request);

            transaction = new TransactionalInformation();
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            try
            {
                var dbConnection = DBSQLSupport.CreateConnection(connectionString);
                DbTransaction dbTransaction = null;
                try
                {
                    dbConnection.Open();
                    dbTransaction = dbConnection.BeginTransaction();

                    var _providerFactory = ProviderFactory.Instance;
                    var documentProvider = _providerFactory.CreateDocumentServiceProvider();

                    var document = cls_Get_Order_PDF_Report_for_OrderID.Invoke(dbConnection, dbTransaction, new P_OR_GOPDFRfOID_1228 { OrderID = order_id.ToString() }, securityTicket).Result;
                    if (document != null)
                    {
                        Guid documentID;
                        Guid.TryParse(document.DocumentID, out documentID);
                        if (documentID != Guid.Empty)
                        {
                            var reportURL = documentProvider.GenerateDownloadLink(documentID, securityTicket.SessionTicket, true, true);
                            return reportURL;
                        }
                    }

                    dbTransaction.Commit();
                }
                finally
                {
                    if (dbConnection.State == System.Data.ConnectionState.Open)
                    {
                        dbConnection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, ex), data.PracticeName);

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }

            return "";
        }
        #endregion Retrieval

        #region Manipulation

        public String SubmitOrderToMM(OrderSubmitParameter parameter, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var request = HttpContext.Current.Request;
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(request);
            var reportURL = String.Empty;

            transaction = new TransactionalInformation();
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            try
            {
                using (var dbConnection = DBSQLSupport.CreateConnection(connectionString))
                {
                    dbConnection.Open();
                    var dbTransaction = dbConnection.BeginTransaction();
                    reportURL = cls_Submit_Order_to_MM.Invoke(dbConnection, dbTransaction, new P_OR_SOtMM_1311
                    {
                        Order = parameter
                    }, securityTicket).Result;
                    var patientIds = cls_Get_CaseID_and_PatientID_for_OrderIDs.Invoke(dbConnection, dbTransaction, new P_OR_GCIDaPIDfOIDs_1434() { OrderIDs = parameter.order_ids.ToArray() }, securityTicket).Result.Select(t => t.patient_id).ToList();

                    var elasticRefresher = new ElasticRefresher(patientIds, dbConnection, dbTransaction, securityTicket, true);
                    elasticRefresher
                        .UpdateOrders()
                        .UpdateIvoms()
                        .RebuildElastic();

                    dbTransaction.Commit();
                    
                    Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, parameter), data.PracticeName);
                }
            }
            catch (Exception ex)
            {
                Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, ex), data.PracticeName);

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }
            return reportURL;
        }

        public void CancelDrugOrder(Guid order_id, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var request = HttpContext.Current.Request;
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(request);

            transaction = new TransactionalInformation();
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            try
            {
                var dbConnection = DBSQLSupport.CreateConnection(connectionString);
                DbTransaction dbTransaction = null;
                try
                {
                    dbConnection.Open();
                    dbTransaction = dbConnection.BeginTransaction();
                    var caseDetails = cls_Get_CaseID_and_PatientID_for_OrderID.Invoke(dbConnection, dbTransaction, new P_OR_GCIDaPIDfOID_1412() { OrderID = order_id }, securityTicket).Result;
                    var all_languages = ORM_CMN_Language.Query.Search(dbConnection, dbTransaction, new ORM_CMN_Language.Query()
                    {
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).ToArray();

                    var treatment_planned_action_id = cls_Get_Treatment_Planned_Action_for_CaseID.Invoke(dbConnection, dbTransaction, new P_CAS_GTPAfCID_0946() { CaseID = caseDetails.case_id }, securityTicket).Result;
                    var drug_order_ids = cls_Get_DrugOrderIDs_for_PlannedActionID.Invoke(dbConnection, dbTransaction, new P_CAS_GDOIDsfPAID_1243() { PlannedActionID = treatment_planned_action_id.planned_action_id }, securityTicket).Result;

                    var trigger_acc = ORM_USR_Account.Query.Search(dbConnection, dbTransaction, new ORM_USR_Account.Query() { USR_AccountID = securityTicket.AccountID }).Single();

                    var header = ORM_ORD_PRC_ProcurementOrder_Header.Query.Search(dbConnection, dbTransaction, new ORM_ORD_PRC_ProcurementOrder_Header.Query()
                    {
                        ORD_PRC_ProcurementOrder_HeaderID = order_id,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).Single();

                    var ord_procurement_order_position = ORM_ORD_PRC_ProcurementOrder_Position.Query.Search(dbConnection, dbTransaction, new ORM_ORD_PRC_ProcurementOrder_Position.Query()
                    {
                        ProcurementOrder_Header_RefID = header.ORD_PRC_ProcurementOrder_HeaderID,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).Single();

                    cls_Cancel_Drug_Order.Invoke(dbConnection, dbTransaction, new P_CAS_CDO_1250()
                    {
                        all_languagesL = all_languages,
                        created_by_bpt = trigger_acc.BusinessParticipant_RefID,
                        ord_drug_order_header = header,
                        procurement_order_position_id = ord_procurement_order_position.ORD_PRC_ProcurementOrder_PositionID,
                        case_id = caseDetails.case_id
                    }, securityTicket);

                    var elasticRefresher = new ElasticRefresher(new Guid[] { caseDetails.patient_id }, dbConnection, dbTransaction, securityTicket, true);
                    elasticRefresher
                        .UpdateOrders()
                        .UpdateIvoms()
                        .RebuildElastic();

                    dbTransaction.Commit();

                    Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, order_id), data.PracticeName);
                }
                finally
                {
                    if (dbConnection.State == System.Data.ConnectionState.Open)
                    {
                        dbConnection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, ex), data.PracticeName);

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }
        }

        public void SaveOrderDetails(Order order, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var request = HttpContext.Current.Request;
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(request);

            transaction = new TransactionalInformation();
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            try
            {
                var dbConnection = DBSQLSupport.CreateConnection(connectionString);
                DbTransaction dbTransaction = null;
                try
                {
                    dbConnection.Open();
                    dbTransaction = dbConnection.BeginTransaction();

                    var culture = new CultureInfo("de", true);
                    var order_date = DateTime.ParseExact(order.treatment_date, "dd.MM.yyyy", culture);

                    var order_position = ORM_ORD_PRC_ProcurementOrder_Position.Query.Search(dbConnection, dbTransaction, new ORM_ORD_PRC_ProcurementOrder_Position.Query()
                    {
                        ProcurementOrder_Header_RefID = order.id,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).SingleOrDefault();

                    if (order_position == null)
                    {
                        throw new ArgumentException(String.Format("Order position not found for header id {0}", order.id));
                    }

                    var practice_bpt = cls_Get_Practice_BptID_for_PracticeID.Invoke(dbConnection, dbTransaction, new P_DO_GPBptIDfPID_1446() { PracticeID = data.PracticeID }, securityTicket).Result;

                    order_position.Position_Comment = order.comment;
                    order_position.IsProFormaOrderPosition = order.label_only;
                    order_position.BillTo_BusinessParticipant_RefID = order.send_invoice_to_practice ? practice_bpt.practice_bpt_id : Guid.Empty;
                    order_position.Modification_Timestamp = DateTime.Now;

                    order_position.Save(dbConnection, dbTransaction);

                    var hec_order_position = ORM_HEC_PRC_ProcurementOrder_Position.Query.Search(dbConnection, dbTransaction, new ORM_HEC_PRC_ProcurementOrder_Position.Query()
                    {
                        Ext_ORD_PRC_ProcurementOrder_Position_RefID = order_position.ORD_PRC_ProcurementOrder_PositionID,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).SingleOrDefault();

                    if (hec_order_position == null)
                    {
                        throw new ArgumentException(String.Format("HEC Order position not found for order position id {0}", order_position.ORD_PRC_ProcurementOrder_PositionID));
                    }

                    hec_order_position.IsOrderForPatient_PatientFeeWaived = order.fee_waived;
                    hec_order_position.IfProFormaOrderPosition_PrintLabelOnly = order.label_only;
                    hec_order_position.Modification_Timestamp = DateTime.Now;

                    hec_order_position.Save(dbConnection, dbTransaction);

                    var treatment_required_product = ORM_HEC_ACT_PlannedAction_PotentialProcedure_RequiredProduct.Query.Search(dbConnection, dbTransaction, new ORM_HEC_ACT_PlannedAction_PotentialProcedure_RequiredProduct.Query()
                    {
                        BoundTo_HealthcareProcurementOrderPosition_RefID = hec_order_position.HEC_PRC_ProcurementOrder_PositionID,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).SingleOrDefault();

                    if (treatment_required_product == null)
                    {
                        throw new ArgumentException(String.Format("Potential procedure required product not found for HEC order position id {0}", hec_order_position.HEC_PRC_ProcurementOrder_PositionID));
                    }

                    treatment_required_product.HealthcareProduct_RefID = order.drug_id;
                    treatment_required_product.Modification_Timestamp = DateTime.Now;

                    treatment_required_product.Save(dbConnection, dbTransaction);

                    #region Planned Action Potential Procedure
                    var planned_action_potential_procedure = ORM_HEC_ACT_PlannedAction_PotentialProcedure.Query.Search(dbConnection, dbTransaction, new ORM_HEC_ACT_PlannedAction_PotentialProcedure.Query
                    {
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false,
                        HEC_ACT_PlannedAction_PotentialProcedureID = treatment_required_product.PlannedAction_PotentialProcedure_RefID
                    }).SingleOrDefault();

                    if (planned_action_potential_procedure == null)
                    {
                        throw new ArgumentException(String.Format(" Planned action potential procedure not found for HEC treatment required product id {0}", treatment_required_product.PlannedAction_PotentialProcedure_RefID));
                    }
                    #endregion

                    #region Planed Action
                    var planed_action = ORM_HEC_ACT_PlannedAction.Query.Search(dbConnection, dbTransaction, new ORM_HEC_ACT_PlannedAction.Query
                    {
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false,
                        HEC_ACT_PlannedActionID = planned_action_potential_procedure.PlannedAction_RefID
                    }).SingleOrDefault();
                    if (planed_action == null)
                    {
                        throw new ArgumentException(String.Format("Planed action not found for HEC planned action potential procedure id {0}", planned_action_potential_procedure.PlannedAction_RefID));
                    }
                    planed_action.PlannedFor_Date = order_date;
                    planed_action.Save(dbConnection, dbTransaction);
                    #endregion


                    var case_invoice_property = cls_Get_CasePropertyValue_for_CaseID_and_CasePropertyGpmID.Invoke(dbConnection, dbTransaction, new P_CAS_GCPVfCIDaCGpmID_1346()
                    {
                        CaseID = order.case_id,
                        PropertyGpmID = ECaseProperty.SendInvoiceToPractice.Value()
                    }, securityTicket).Result;

                    var invoice_property_value = new ORM_HEC_CAS_Case_UniversalPropertyValue();
                    if (case_invoice_property == null)
                    {
                        var invoice_property = ORM_HEC_CAS_Case_UniversalProperty.Query.Search(dbConnection, dbTransaction, new ORM_HEC_CAS_Case_UniversalProperty.Query()
                        {
                            GlobalPropertyMatchingID = ECaseProperty.SendInvoiceToPractice.Value(),
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false
                        }).SingleOrDefault();

                        if (invoice_property == null)
                        {
                            invoice_property = new ORM_HEC_CAS_Case_UniversalProperty();
                            invoice_property.GlobalPropertyMatchingID = ECaseProperty.SendInvoiceToPractice.Value();
                            invoice_property.IsValue_Boolean = true;
                            invoice_property.Modification_Timestamp = DateTime.Now;
                            invoice_property.PropertyName = "Send Invoice to Practice";
                            invoice_property.Tenant_RefID = securityTicket.TenantID;

                            invoice_property.Save(dbConnection, dbTransaction);
                        }

                        invoice_property_value = new ORM_HEC_CAS_Case_UniversalPropertyValue();
                        invoice_property_value.HEC_CAS_Case_RefID = order.case_id;
                        invoice_property_value.HEC_CAS_Case_UniversalProperty_RefID = invoice_property.HEC_CAS_Case_UniversalPropertyID;
                        invoice_property_value.Tenant_RefID = securityTicket.TenantID;
                    }
                    else
                    {
                        invoice_property_value.Load(dbConnection, dbTransaction, case_invoice_property.ID);
                    }

                    invoice_property_value.Value_Boolean = order.send_invoice_to_practice;
                    invoice_property_value.Modification_Timestamp = DateTime.Now;

                    invoice_property_value.Save(dbConnection, dbTransaction);

                    var elasticRefresher = new ElasticRefresher(new Guid[] { planed_action.Patient_RefID }, dbConnection, dbTransaction, securityTicket, true);
                    elasticRefresher
                        .UpdateOrders()
                        .UpdateIvoms()
                        .RebuildElastic();

                    dbTransaction.Commit();

                    Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, order), data.PracticeName);
                }
                finally
                {
                    if (dbConnection.State == System.Data.ConnectionState.Open)
                    {
                        dbConnection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, ex), data.PracticeName);

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }
        }

        public void SubmitAllShoppingCartOrders(int number_of_orders, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var request = HttpContext.Current.Request;
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(request);

            transaction = new TransactionalInformation();
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            try
            {
                var dbConnection = DBSQLSupport.CreateConnection(connectionString);
                DbTransaction dbTransaction = null;
                try
                {
                    dbConnection.Open();
                    dbTransaction = dbConnection.BeginTransaction();

                    var orders = Get_Orders.GetPracticeOrders(0, int.MaxValue, data.PracticeID.ToString(), securityTicket.TenantID.ToString(), null, null, DateTime.MinValue, DateTime.MaxValue).ToList();
                    if (orders.Count() >= number_of_orders)
                    {
                        if (orders.Any())
                        {

                            var doctorId = cls_Get_DoctorID_for_AccountID.Invoke(dbConnection, dbTransaction, securityTicket).Result.DoctorID;

                            var order_ids = orders.Select(t => Guid.Parse(t.id)).Take(200).ToArray();
                            var random_phramacy = ORM_HEC_Pharmacy.Query.Search(dbConnection, dbTransaction, new ORM_HEC_Pharmacy.Query { Tenant_RefID = securityTicket.TenantID, IsDeleted = false }).First();

                            var failed = 0;
                            foreach (var id in order_ids)
                            {
                                try
                                {
                                    SubmitOrderToMM(new OrderSubmitParameter()
                                    {
                                        city = "Novi Sad",
                                        comment = null,
                                        delivery_date = DateTime.Now.ToString("dd.MM.yyyy"),
                                        delivery_date_from = "08:00",
                                        delivery_date_to = "18:00",
                                        doctor_id = doctorId,
                                        number = "21",
                                        order_ids = new Guid[] { id },
                                        receiver = "Praxis",
                                        street = "street 23",
                                        zip = "21000",
                                        default_pharmacy = random_phramacy.HEC_PharmacyID,
                                    }, connectionString, sessionTicket, out transaction);
                                }
                                catch { failed++; }
                            }

                            dbTransaction.Commit();
                        }
                    }
                }
                finally
                {
                    if (dbConnection.State == System.Data.ConnectionState.Open)
                    {
                        dbConnection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, ex), data.PracticeName);

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }
        }

        #endregion Manipulation
    }
}