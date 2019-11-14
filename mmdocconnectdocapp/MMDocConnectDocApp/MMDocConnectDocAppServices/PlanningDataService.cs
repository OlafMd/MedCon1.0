using CL1_CMN_CTR;
using CL1_HEC;
using CL1_HEC_CAS;
using CL1_HEC_CRT;
using CSV2Core.SessionSecurity;
using CSV2Core_MySQL.Support;
using DLCore_TokenVerification;
using LogUtils;
using MMDocConnectDBMethods.Case.Atomic.Manipulation;
using MMDocConnectDBMethods.Case.Atomic.Retrieval;
using MMDocConnectDBMethods.Case.Complex.Retrieval;
using MMDocConnectDBMethods.Doctor.Atomic.Manipulation;
using MMDocConnectDBMethods.Doctor.Atomic.Retrieval;
using MMDocConnectDBMethods.Doctor.Model;
using MMDocConnectDBMethods.MainData.Atomic.Retrieval;
using MMDocConnectDBMethods.MainData.Complex.Retrieval;
using MMDocConnectDBMethods.Order.Atomic.Retrieval;
using MMDocConnectDBMethods.Patient.Atomic.Retrieval;
using MMDocConnectDBMethods.Patient.Complex.Retrieval;
using MMDocConnectDocApp;
using MMDocConnectDocAppInterfaces;
using MMDocConnectDocAppModels;
using MMDocConnectElasticSearchMethods.Case.Entity;
using MMDocConnectElasticSearchMethods.Case.Retrieval;
using MMDocConnectElasticSearchMethods.Doctor.Retrieval;
using MMDocConnectElasticSearchMethods.Models;
using MMDocConnectElasticSearchMethods.Patient.Manipulation;
using MMDocConnectUtils;
using SharedServiceUtils;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Web;

namespace MMDocConnectDocAppServices
{
    public class PlanningDataService : BaseVerification, IPlanningDataService
    {
        private object lockObj = new object();

        #region RETRIEVAL
        public bool MissingIvomCaseExists(Guid patient_id, bool is_left_eye, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var request = HttpContext.Current.Request;
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(request);
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;
            transaction = new TransactionalInformation();

            var dbConnection = DBSQLSupport.CreateConnection(connectionString);
            DbTransaction dbTransaction = null;

            try
            {
                dbConnection.Open();
                dbTransaction = dbConnection.BeginTransaction();

                var missing_ivom_exists = cls_Get_CaseID_for_PatientID_Localization_and_CasePropertyGpmID.Invoke(dbConnection, dbTransaction, new P_CAS_GCIDfPIDLaCPGpmID_1256()
                {
                    PatientID = patient_id,
                    Localization = is_left_eye ? "L" : "R",
                    CasePropertyGpmID = ECaseProperty.MissingIvom.Value()
                }, securityTicket).Result != null;

                return missing_ivom_exists;
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
            finally
            {
                dbConnection.Close();
            }

            return false;

        }

        public bool CaseHasOctPending(Guid case_id, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var request = HttpContext.Current.Request;
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(request);
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            transaction = new TransactionalInformation();

            var dbConnection = DBSQLSupport.CreateConnection(connectionString);
            DbTransaction dbTransaction = null;

            try
            {
                dbConnection.Open();
                dbTransaction = dbConnection.BeginTransaction();

                var pending_oct = cls_Get_PendingOct_FsStatus_for_CaseID.Invoke(dbConnection, dbTransaction, new P_CAS_GPOctFsSfCID_1705() { CaseID = case_id }, securityTicket).Result;
                return pending_oct != null;
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
            finally
            {
                dbConnection.Close();
            }

            return false;

        }

        public bool IsOrderSubmitted(Guid case_id, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var request = HttpContext.Current.Request;
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(request);
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            transaction = new TransactionalInformation();

            var dbConnection = DBSQLSupport.CreateConnection(connectionString);
            DbTransaction dbTransaction = null;

            try
            {
                dbConnection.Open();
                dbTransaction = dbConnection.BeginTransaction();

                var current_order_status = cls_Get_Case_Order_Status_for_CaseID.Invoke(dbConnection, dbTransaction, new P_CAS_GCOSfCID_1622() { CaseID = case_id }, securityTicket).Result;
                var is_order_submitted = current_order_status != null && (current_order_status.order_status == 1 || current_order_status.order_status == 2 || current_order_status.order_status == 3 || current_order_status.order_status == 4);
                return is_order_submitted;
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
            finally
            {
                dbConnection.Close();
            }

            return false;
        }

        public bool WillOrderBeCancelled(Case parameter, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var request = HttpContext.Current.Request;
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(request);
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            transaction = new TransactionalInformation();

            var dbConnection = DBSQLSupport.CreateConnection(connectionString);
            DbTransaction dbTransaction = null;

            try
            {
                dbConnection.Open();
                dbTransaction = dbConnection.BeginTransaction();

                var current_order_status = cls_Get_Case_Order_Status_for_CaseID.Invoke(dbConnection, dbTransaction, new P_CAS_GCOSfCID_1622() { CaseID = parameter.case_id }, securityTicket).Result;
                if (current_order_status != null && (current_order_status.order_status == 1 || current_order_status.order_status == 2 || current_order_status.order_status == 3))
                {
                    var drug_order_settings = cls_Get_Drug_Order_Settings.Invoke(dbConnection, dbTransaction, new P_CAS_GDOS_1108() { CaseID = parameter.case_id }, securityTicket).Result;
                    if (drug_order_settings != null)
                    {
                        var is_order_different = !parameter.is_orders_drug ||
                               drug_order_settings.drug_id != parameter.drug_id ||
                               drug_order_settings.is_label_only != parameter.is_label_only ||
                               drug_order_settings.is_patient_fee_waived != parameter.is_patient_fee_waived ||
                               drug_order_settings.is_send_invoice_to_practice != parameter.is_send_invoice_to_practice ||
                               drug_order_settings.treatment_date.Date != DateTime.ParseExact(parameter.treatment_date, "dd.MM.yyyy", new CultureInfo("de", true)).Date;

                        return is_order_different;
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
            finally
            {
                dbConnection.Close();
            }

            return false;
        }

        public bool GetIsPatientFeeWaived(Guid patient_id, string treatment_date, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var request = HttpContext.Current.Request;
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(request);
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            transaction = new TransactionalInformation();

            var dbConnection = DBSQLSupport.CreateConnection(connectionString);
            DbTransaction dbTransaction = null;

            try
            {
                dbConnection.Open();
                dbTransaction = dbConnection.BeginTransaction();

                if (!String.IsNullOrEmpty(treatment_date))
                {
                    var date = DateTime.MinValue;
                    DateTime.TryParseExact(treatment_date, "dd.MM.yyyy", new CultureInfo("de"), DateTimeStyles.None, out date);

                    var fee_waivers = cls_Get_Patient_Properties_for_PatientID_and_PropertyGpmID.Invoke(dbConnection, dbTransaction, new P_PA_GPPfPIDaPGpmID_1620()
                    {
                        PatientID = patient_id,
                        PropertyGpmID = EPatientProperty.FeeWaived.Value()
                    }, securityTicket).Result.Select(t => DateTime.Parse(t.string_value)).ToList();
                    dbTransaction.Commit();

                    var fee_waiver_date = fee_waivers.SingleOrDefault(t => t.Year == date.Year);

                    if (fee_waiver_date != null && fee_waiver_date != DateTime.MinValue)
                    {
                        return fee_waiver_date.Date <= date.Date && new DateTime(fee_waiver_date.Year, 12, 31) >= date.Date;
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
            finally
            {
                dbConnection.Close();
            }

            return false;
        }

        public bool GetIsPatientHipOnAnOctContract(Guid patient_id, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var request = HttpContext.Current.Request;
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(request);
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            transaction = new TransactionalInformation();

            var connection = DBSQLSupport.CreateConnection(connectionString);
            DbTransaction dbTransaction = null;

            try
            {
                connection.Open();
                dbTransaction = connection.BeginTransaction();

                var hips = cls_Get_is_Patient_HIP_on_an_Oct_Contract.Invoke(connection, dbTransaction, new P_PA_GiPHipoaOctC_1811() { PatientID = patient_id }, securityTicket).Result;

                dbTransaction.Commit();

                return hips.Any();
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
            finally
            {
                connection.Close();
            }

            return false;
        }

        public PracticeDefaultSettings GetPracticeDefaultSettings(string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var request = HttpContext.Current.Request;
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(request);
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            transaction = new TransactionalInformation();

            var connection = DBSQLSupport.CreateConnection(connectionString);
            DbTransaction dbTransaction = null;

            try
            {
                connection.Open();
                dbTransaction = connection.BeginTransaction();

                var defaultShippingDateOffset = cls_Get_Practice_PropertyValue_for_PropertyName_and_PracticeID.Invoke(connection, dbTransaction, new P_DO_GPPVfPNaPID_0916() { PracticeID = data.PracticeID, PropertyName = "Default Shipping Date Offset" }, securityTicket).Result;
                var ordersDrugs = cls_Get_Practice_PropertyValue_for_PropertyName_and_PracticeID.Invoke(connection, dbTransaction, new P_DO_GPPVfPNaPID_0916() { PracticeID = data.PracticeID, PropertyName = "Order Drugs" }, securityTicket).Result;
                var labelOnly = cls_Get_Practice_PropertyValue_for_PropertyName_and_PracticeID.Invoke(connection, dbTransaction, new P_DO_GPPVfPNaPID_0916() { PracticeID = data.PracticeID, PropertyName = "Only Label Required" }, securityTicket).Result;
                var isQuickOrderActive = cls_Get_Practice_PropertyValue_for_PropertyName_and_PracticeID.Invoke(connection, dbTransaction, new P_DO_GPPVfPNaPID_0916() { PracticeID = data.PracticeID, PropertyName = "Quick order" }, securityTicket).Result;
                var deliveryDateFrom = cls_Get_Practice_PropertyValue_for_PropertyName_and_PracticeID.Invoke(connection, dbTransaction, new P_DO_GPPVfPNaPID_0916() { PracticeID = data.PracticeID, PropertyName = "Delivery date from" }, securityTicket).Result;
                var deliveryDateTo = cls_Get_Practice_PropertyValue_for_PropertyName_and_PracticeID.Invoke(connection, dbTransaction, new P_DO_GPPVfPNaPID_0916() { PracticeID = data.PracticeID, PropertyName = "Delivery date to" }, securityTicket).Result;

                dbTransaction.Commit();

                return new PracticeDefaultSettings()
                {
                    drugs_delivery_date_offset = defaultShippingDateOffset == null ? 0 : defaultShippingDateOffset.NumericValue,
                    practice_orders_drugs = ordersDrugs == null ? false : ordersDrugs.BooleanValue,
                    label_only = labelOnly == null ? false : labelOnly.BooleanValue,
                    quick_order = isQuickOrderActive == null ? false : isQuickOrderActive.BooleanValue,
                    delivery_date_from = deliveryDateFrom == null ? "08:00" : deliveryDateFrom.TextValue,
                    delivery_date_to = deliveryDateTo == null ? "18:00" : deliveryDateTo.TextValue
                };
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
            finally
            {
                connection.Close();
            }

            return null;
        }

        public MultiSubmitObject[] InitiateCaseMultiSubmit(Guid[] case_ids, Guid[] deselected_ids, bool all_selected, FilterObject filter, string sort_by, bool isAsc, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var request = HttpContext.Current.Request;
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(request);

            transaction = new TransactionalInformation();
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            MultiSubmitObject[] response = new MultiSubmitObject[] { };
            try
            {
                if (all_selected || deselected_ids.Length != 0)
                {
                    ElasticParameterObject filter_by = new ElasticParameterObject();
                    filter_by.date_from = filter.date_from;
                    filter_by.date_to = filter.date_to;
                    filter_by.filter_by.filter_status = filter.filter_by.filter_status;
                    filter_by.filter_by.filter_type = filter.filter_by.filter_type;
                    filter_by.search_params = filter.search_params;
                    filter_by.filter_by.orders = filter.filter_by.orders;
                    filter_by.filter_by.filter_current = filter.filter_by.filter_current;
                    filter_by.filter_by.localization = filter_by.filter_by.localization;

                    response = Get_Cases.GetCasesFilteredIDs(filter_by, data.PracticeID.ToString(), Array.ConvertAll(deselected_ids, x => x.ToString()), false, "", "", sort_by, isAsc, securityTicket).GroupBy(cas => cas.treatment_doctor_id).Select(cas => new MultiSubmitObject() { id = Guid.Parse(cas.First().treatment_doctor_id), count = cas.Count() }).ToArray();
                }
                else
                {
                    response = Get_Cases.GetCasesforIDArray(data.PracticeID, Array.ConvertAll(case_ids, x => x.ToString()), false, "", "", sort_by, isAsc, securityTicket)
                        .Where(t => !String.IsNullOrEmpty(t.treatment_doctor_id)).GroupBy(cas => cas.treatment_doctor_id).Select(cas => new MultiSubmitObject()
                    {
                        id = Guid.Parse(cas.First().treatment_doctor_id),
                        count = cas.Count()
                    }).ToArray();
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

            return response;
        }

        public List<AutocompleteModel> GetPatientsForAutocomplete(string search_criteria, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var request = HttpContext.Current.Request;
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(request);
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            transaction = new TransactionalInformation();

            List<AutocompleteModel> patients = new List<AutocompleteModel>();

            try
            {
                using (var dbConnection = DBSQLSupport.CreateConnection(connectionString))
                {
                    dbConnection.Open();
                    var dbTransaction = dbConnection.BeginTransaction();
                    var patients_from_elastic = Retrieve_Patients.Get_Patients_for_Autocomplete(search_criteria, data.PracticeID, connectionString, securityTicket);
                    if (patients_from_elastic.Any())
                    {
                        var patient_ids = patients_from_elastic.Select(t => Guid.Parse(t.id)).ToArray();
                        var hips_participating_on_oct_ctr = cls_Get_is_Patient_HIP_on_an_Oct_Contract_for_PatientIDs.Invoke(dbConnection, dbTransaction, new P_PA_GiPHipoaOctCfPIDs_1225() { PatientIDs = patient_ids }, securityTicket).Result;

                        foreach (var patient in patients_from_elastic)
                        {
                            var patient_id = Guid.Parse(patient.id);
                            patients.Add(new AutocompleteModel()
                            {
                                display_name = patient.name_with_birthdate,
                                id = patient_id,
                                hipParticipatesOnOctContract = hips_participating_on_oct_ctr.Any(t => t.Patient_RefID == patient_id)
                            });
                        }
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

            return patients;

        }

        public ACAutocompleteModel GetACDoctorsAndPracticesForAutocomplete(string connectionString, string search_criteria, string sessionTicket, out TransactionalInformation transaction)
        {
            var request = HttpContext.Current.Request;
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(request);
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            transaction = new TransactionalInformation();
            var autocomplete_model = new ACAutocompleteModel();
            var last_used_doctors = new List<AutocompleteModel>();
            var doctors = new List<AutocompleteModel>();
            var practices = new List<AutocompleteModel>();

            try
            {
                var last_used_practices_doctors = Get_Practices_and_Doctors.Get_Last_Used_Doctors_Practices(Guid.Empty, securityTicket);
                foreach (var doctor_practice in last_used_practices_doctors)
                {
                    last_used_doctors.Add(new AutocompleteModel()
                    {
                        display_name = doctor_practice.display_name.Replace("()", "(-)"),
                        id = Guid.Parse(doctor_practice.id),
                        type = "LABEL_LAST_USED"
                    });
                }

                if (!string.IsNullOrEmpty(search_criteria))
                {
                    var doctors_practices_from_elastic = Get_Practices_and_Doctors.Get_AC_Doctors_and_Practices(new Practice_Parameter()
                    {
                        role = "ac",
                        search_criteria = search_criteria,
                        sortfield = "name_untouched",
                        ascending = true,
                        practice_id = data.PracticeID
                    }, securityTicket);

                    var grouped = doctors_practices_from_elastic.GroupBy(t => t.type).ToDictionary(t => t.Key, t => t.ToList());
                    var doctors_type = "LABEL_DOCTORS";
                    var practices_type = "LABEL_PRACTICES";
                    if (grouped.ContainsKey(doctors_type))
                    {
                        doctors = grouped[doctors_type].Select(doctor_practice => new AutocompleteModel()
                        {
                            display_name = doctor_practice.autocomplete_name + " (" + doctor_practice.bsnr_lanr + ")",
                            id = Guid.Parse(doctor_practice.id),
                            type = doctor_practice.type,
                            secondary_display_name = doctor_practice.practice_name_for_doctor
                        }).ToList();
                    }

                    if (grouped.ContainsKey(practices_type))
                    {
                        practices = grouped[practices_type].Select(doctor_practice => new AutocompleteModel()
                        {
                            display_name = doctor_practice.autocomplete_name + " (" + doctor_practice.bsnr_lanr + ")",
                            id = Guid.Parse(doctor_practice.id),
                            type = doctor_practice.type,
                            secondary_display_name = doctor_practice.practice_name_for_doctor
                        }).ToList();
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

            autocomplete_model.last_used = last_used_doctors;
            autocomplete_model.doctors = doctors;
            autocomplete_model.practices = practices;

            return autocomplete_model;
        }

        public ACAutocompleteModel GetOctDoctorsForAutocomplete(string connectionString, string search_criteria, Guid patient_id, string date, string sessionTicket, out TransactionalInformation transaction)
        {
            var request = HttpContext.Current.Request;
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(request);
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            transaction = new TransactionalInformation();
            ACAutocompleteModel autocomplete_model = new ACAutocompleteModel();
            var last_used_doctors = new List<AutocompleteModel>();
            var doctors = new List<AutocompleteModel>();
            var elastic_type = "user_oct_";

            try
            {
                var dbConnection = DBSQLSupport.CreateConnection(connectionString);
                DbTransaction dbTransaction = null;

                try
                {
                    dbConnection.Open();
                    dbTransaction = dbConnection.BeginTransaction();

                    #region patient's contract
                    var contract_id = Guid.Empty;
                    var oct_gpos_ids = cls_Get_GposIDs_for_GposType.Invoke(connectionString, new P_MD_GGpoIDsfGposT_1145() { GposType = EGposType.Oct.Value() }, securityTicket).Result;
                    if (oct_gpos_ids.Any() && patient_id != Guid.Empty && !String.IsNullOrEmpty(date))
                    {
                        var culture = new System.Globalization.CultureInfo("de", true);
                        var oct_date = DateTime.Parse(date, culture, System.Globalization.DateTimeStyles.None);

                        var patient_consents = cls_Get_Patient_Consents_before_Date_and_GposIDs.Invoke(connectionString, new P_PA_GPCbDaGposIDs_1154()
                        {
                            Date = oct_date.Date,
                            GposIDs = oct_gpos_ids.Select(t => t.GposID).ToArray(),
                            PatientID = patient_id
                        }, securityTicket).Result;

                        var all_contract_parameters = ORM_CMN_CTR_Contract_Parameter.Query.Search(connectionString, new ORM_CMN_CTR_Contract_Parameter.Query()
                        {
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false
                        }).GroupBy(t => t.Contract_RefID).ToDictionary(t => t.Key, t => t);

                        if (patient_consents.Any())
                        {
                            var last_potential_consent = patient_consents.First(t => t.consent_valid_from.Date <= oct_date.Date);
                            contract_id = last_potential_consent.contract_id;
                        }
                    }
                    #endregion

                    var allPotetntialDoctors = cls_Get_DoctorIDs_with_Oct_Contract.Invoke(dbConnection, dbTransaction, securityTicket).Result;

                    var allContractIDs = new Guid[] { contract_id };
                    if (contract_id == Guid.Empty)
                    {
                        allContractIDs = allPotetntialDoctors.Select(x => x.ContractID).Distinct().ToArray();
                    }

                    var allContractParameters = ORM_CMN_CTR_Contract_Parameter.Query.Search(dbConnection, dbTransaction, new ORM_CMN_CTR_Contract_Parameter.Query() { Tenant_RefID = securityTicket.TenantID, IsDeleted = false })
                          .Where(x => allContractIDs.Contains(x.Contract_RefID));

                    var allContractsWithCertificate = allContractParameters.Where(x => x.ParameterName == EContractParameter.DoctorNeedCertification.Value()).Select(x => x.Contract_RefID);
                    var allContractsWithoutCertificate = allContractIDs.Where(x => !allContractsWithCertificate.Contains(x));

                    #region create new list of potetntial doctors
                    var newListOfPotentialDoctors = new List<DO_GDIDswOC_1531>();
                    if (allContractsWithoutCertificate.Any())
                    {
                        newListOfPotentialDoctors.AddRange(allPotetntialDoctors.Where(x => allContractsWithoutCertificate.Contains(x.ContractID)).ToList());
                    }
                    if (allContractsWithCertificate.Any())
                    {
                        foreach (var doc in allPotetntialDoctors)
                        {
                            if (newListOfPotentialDoctors.Any(x => x.DoctorID == doc.DoctorID))
                            {
                                continue;
                            }

                            var is_certificated_for_oct = cls_Get_Is_Doctor_Certificated_for_OCT.Invoke(dbConnection, dbTransaction, new P_DO_GIDCfOCT_1729 { DoctorID = doc.DoctorID }, securityTicket).Result;
                            if (is_certificated_for_oct != null ? is_certificated_for_oct.IsDoctorCertificated : false)
                            {
                                newListOfPotentialDoctors.Add(doc);
                            }
                        }
                    }
                    #endregion

                    var last_used_practices_doctors = Get_Practices_and_Doctors.Get_Last_Used_Doctors_from_Potential_Doctors(Guid.Empty, newListOfPotentialDoctors.Select(x => x.DoctorID.ToString()), securityTicket, elastic_type);
                    var doctor_ids = last_used_practices_doctors.Select(t => Guid.Parse(t.id)).ToArray();
                    if (doctor_ids.Any(t => t != Guid.Empty))
                    {
                        var practice_names = cls_Get_Practice_Names_for_DoctorIDs.Invoke(connectionString, new P_DO_GPNfDIDs_1747() { DoctorIDs = doctor_ids }, securityTicket).Result;

                        foreach (var doctor_practice in last_used_practices_doctors)
                        {
                            var practice_name = practice_names.First(t => t.doctor_id == Guid.Parse(doctor_practice.id));
                            last_used_doctors.Add(new AutocompleteModel()
                            {
                                display_name = doctor_practice.display_name.Replace("()", "(-)"),
                                id = Guid.Parse(doctor_practice.id),
                                type = "LABEL_LAST_USED",
                                name = doctor_practice.display_name,
                                secondary_display_name = practice_name.practice_name
                            });
                        }
                    }

                    if (!string.IsNullOrEmpty(search_criteria))
                    {
                        var doctors_practices_from_elastic = Get_Practices_and_Doctors.Get_Doctors_for_SearchCriteria_and_Potential_Doctors(search_criteria, newListOfPotentialDoctors.Select(x => x.DoctorID.ToString()), securityTicket);

                        foreach (var doctor_practice in doctors_practices_from_elastic)
                        {
                            doctors.Add(new AutocompleteModel()
                            {
                                display_name = doctor_practice.autocomplete_name + " (" + doctor_practice.bsnr_lanr + ")",
                                id = Guid.Parse(doctor_practice.id),
                                type = doctor_practice.type,
                                secondary_display_name = doctor_practice.practice_name_for_doctor,
                                name = doctor_practice.autocomplete_name
                            });
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

            autocomplete_model.last_used = last_used_doctors;
            autocomplete_model.doctors = doctors;
            return autocomplete_model;
        }

        public List<AutocompleteModel> GetAllDrugsForDropdown(string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var request = HttpContext.Current.Request;
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(request);
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            transaction = new TransactionalInformation();
            var drugs = new List<AutocompleteModel>();

            try
            {
                // var drugs_from_db = cls_Get_Drug_Details_on_Tenant.Invoke(connectionString, securityTicket).Result;
                var drugs_from_db = cls_Get_All_Drugs_for_PracticeID.Invoke(connectionString, new P_CAS_GADfPID_1620() { PracticeID = data.PracticeID }, securityTicket).Result;
                drugs = drugs_from_db.Select(drug =>
                {
                    return new AutocompleteModel()
                    {
                        display_name = drug.drug_name,
                        id = drug.drug_id
                    };
                }).ToList();
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

            return drugs;
        }

        public IEnumerable<AutocompleteModel> GetAllDiagnosesForDropdown(Guid patient_id, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var request = HttpContext.Current.Request;
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(request);

            transaction = new TransactionalInformation();
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;


            try
            {
                var diagnoses_from_db = cls_Get_Diagnoses_for_PatientID.Invoke(connectionString, new P_PA_GDfPID_1726() { PatientID = patient_id }, securityTicket).Result;

                return diagnoses_from_db.Select(diagnose => new AutocompleteModel()
                {
                    display_name = diagnose.diagnose_name + " (" + diagnose.catalog_display_name + ": " + diagnose.diagnose_icd_10 + ")",
                    id = diagnose.diagnose_id
                });
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

            return new List<AutocompleteModel>();
        }

        public List<Case_Model> GetAllCases(ElasticParameterObject sort_parameter, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var request = HttpContext.Current.Request;
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(request);

            var ordersDataService = new OrdersDataService();
            transaction = new TransactionalInformation();
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            List<Case_Model> cases = new List<Case_Model>();

            try
            {
                var dbConnection = DBSQLSupport.CreateConnection(connectionString);
                DbTransaction dbTransaction = null;

                try
                {
                    dbConnection.Open();
                    dbTransaction = dbConnection.BeginTransaction();

                    var default_shipping_date_offset = ordersDataService.GetDefaultShippingDateOffset(data.PracticeID, dbConnection, dbTransaction, securityTicket);
                    cases = Get_Cases.GetAllCases(data.PracticeID, sort_parameter, securityTicket);

                    var order_ids_with_case_id = cases.Any() ? cls_Get_OrderIDs_for_CaseIDs.Invoke(dbConnection, dbTransaction, new P_OR_GOIDsfCIDs_1351
                    {
                        CaseIDs = cases.Select(x => Guid.Parse(x.id)).Distinct().ToArray()
                    }, securityTicket).Result.GroupBy(x => x.CaseID).ToDictionary(x => x.Key, x => x.First().OrderID) : null;

                    foreach (var cas in cases)
                    {
                        var patient_id = Guid.Parse(cas.patient_id);

                        #region Order
                        cas.status_drug_order = cas.status_drug_order == null ? "" : cas.status_drug_order;

                        if (cas.status_treatment == "OP1" && cas.treatment_date < DateTime.Now.Date)
                        {
                            cas.status_treatment = "OP3";
                        }

                        if (cas.status_drug_order == "MO0")
                        {
                            if (cas.treatment_date.AddDays(-default_shipping_date_offset).Date <= DateTime.Now.Date)
                            {
                                cas.status_drug_order = "MO8";
                            }
                        }

                        cas.is_submit_order_button_visible = false;
                        if (cas.diagnose == "" && cas.localization == "-" && cas.is_orders_drug)
                        {
                            if (cas.status_drug_order == "MO0" || cas.status_drug_order == "MO8")
                            {
                                cas.is_submit_order_button_visible = true;
                            }

                            if (order_ids_with_case_id.ContainsKey(Guid.Parse(cas.id)))
                                cas.order_id = order_ids_with_case_id[Guid.Parse(cas.id)].ToString();
                        }
                        #endregion

                        #region Group name
                        switch (sort_parameter.sort_by)
                        {
                            case "treatment_date": cas.group_name = cas.treatment_date_month_year.ToUpper(); break;
                            case "patient_name": cas.group_name = cas.patient_name.Substring(0, 1).ToUpper(); break;
                            case "diagnose": cas.group_name = string.IsNullOrEmpty(cas.diagnose) ? "-" : cas.diagnose; break;
                            case "localization": cas.group_name = cas.localization; break;
                            case "treatment_doctor_name": cas.group_name = cas.treatment_doctor_name; break;
                            case "aftercare_name": cas.group_name = cas.aftercare_name; break;
                            case "status_drug_order": cas.group_name = cas.status_drug_order.Equals("") ? "LABEL_NO_DRUGS_ORDERED" : cas.status_drug_order; break;

                            default: cas.group_name = cas.treatment_date_month_year; break;
                        }
                        #endregion

                        cas.treatment_date_day_month = cas.treatment_date.ToString("dd.MM.yyyy");
                        cas.is_submit_button_visible = cas.treatment_date <= DateTime.Now;
                        cas.is_edit_button_visible = cas.status_treatment != "OP4";
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

            return cases;
        }

        public Case GetCaseDetailsforCaseID(Guid case_id, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = HttpContext.Current != null ? Util.GetIPInfo(HttpContext.Current.Request) : new IPInfo() { address = "none", agent = "none" };

            transaction = new TransactionalInformation();
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            Case case_details = new Case();

            try
            {
                var dbConnection = DBSQLSupport.CreateConnection(connectionString);
                DbTransaction dbTransaction = null;
                try
                {
                    dbConnection.Open();
                    dbTransaction = dbConnection.BeginTransaction();

                    var case_from_db = cls_Get_Case_Details_for_CaseID.Invoke(connectionString, new P_CAS_GCDfCID_1435() { CaseID = case_id }, securityTicket).Result;

                    if (case_from_db != null)
                    {
                        case_details.aftercare_doctor_practice_id = case_from_db.is_aftercare_doctor ? case_from_db.ac_doctor_id : case_from_db.ac_practice_id;
                        case_details.case_id = case_from_db.case_id;
                        case_details.diagnose_id = case_from_db.diagnose_id;
                        case_details.drug_id = case_from_db.drug_id;
                        case_details.is_confirmed = case_from_db.is_confirmed;
                        case_details.is_label_only = case_from_db.is_label_only;
                        case_details.is_left_eye = case_from_db.localization != null ? case_from_db.localization.Equals("L") : false;
                        case_details.is_orders_drug = case_from_db.order_id != Guid.Empty && case_from_db.order_status_code != 6 && case_from_db.order_status_code != 9;
                        case_details.is_patient_fee_waived = case_from_db.is_patient_fee_waived;
                        case_details.is_send_invoice_to_practice = case_from_db.is_send_invoice_to_practice;
                        case_details.patient_id = case_from_db.patient_id;
                        case_details.treatment_date = case_from_db.treatment_date.ToString("dd.MM.yyyy");
                        case_details.treatment_doctor_id = case_from_db.op_doctor_id;
                        case_details.patient_display_name = case_from_db.patient_display_name;
                        case_details.is_treatment_form_open = case_from_db.diagnose_id != Guid.Empty;
                        case_details.aftercare_display_name = case_from_db.is_aftercare_doctor ? case_from_db.aftercare_doctor_display_name : case_from_db.aftercare_practice_display_name;
                        case_details.can_cancel_order = case_from_db.order_status_code != 3;
                        case_details.aftercare_performed_date = case_from_db.aftercare_performed_date.ToString("dd.MM.yyyy");
                        case_details.order_comment = case_from_db.order_comment;
                        case_details.oct_doctor_id = case_from_db.oct_doctor_id;
                        case_details.oct_doctor_display_name = case_from_db.oct_doctor_display_name;
                        case_details.order_status = case_from_db.order_status;
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

            return case_details;
        }
        public Case GetPreviousCaseDataforPatientID(Guid patient_id, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var request = HttpContext.Current.Request;
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(request);

            transaction = new TransactionalInformation();
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            var connection = DBSQLSupport.CreateConnection(connectionString);
            Case case_data = new Case();

            try
            {
                connection.Open();
                var dbTransaction = connection.BeginTransaction();

                var _case = cls_Get_Previous_Case_Data_for_PatientID.Invoke(connection, dbTransaction, new P_CAS_GPCDfPID_1144() { PatientID = patient_id }, securityTicket).Result;

                if (_case == null)
                {
                    var doctor_id = cls_Get_DoctorID_for_AccountID.Invoke(connection, dbTransaction, securityTicket).Result;
                    if (doctor_id != null)
                    {
                        case_data.treatment_doctor_id = doctor_id.DoctorID;
                    }
                    else
                    {
                        var doctors_in_practice = cls_Get_DoctorIDs_for_PracticeID.Invoke(connection, dbTransaction, new P_DO_GDIDsfPID_1635() { PracticeID = data.PracticeID }, securityTicket).Result;
                        if (doctors_in_practice.Any())
                        {
                            try
                            {
                                var doctor = doctors_in_practice.SingleOrDefault();
                                if (doctor != null)
                                {
                                    case_data.treatment_doctor_id = doctor.DoctorID;
                                }
                            }
                            catch (Exception ex)
                            {
                                case_data.treatment_doctor_id = Guid.Empty;
                            }
                        }
                    }
                }
                else
                {
                    case_data.diagnose_id = _case.diagnose_id;
                    case_data.is_left_eye = _case.localization != null ? _case.localization.Equals("L") : true;
                    if (_case.treatment_doctor_id != Guid.Empty)
                    {
                        case_data.treatment_doctor_id = _case.treatment_doctor_id;
                    }
                    else
                    {
                        var doctor_id = cls_Get_DoctorID_for_AccountID.Invoke(connectionString, securityTicket).Result;
                        if (doctor_id != null)
                        {
                            case_data.treatment_doctor_id = doctor_id.DoctorID;
                        }
                        else
                        {
                            var doctors_in_practice = cls_Get_DoctorIDs_for_PracticeID.Invoke(connection, dbTransaction, new P_DO_GDIDsfPID_1635() { PracticeID = data.PracticeID }, securityTicket).Result;
                            if (doctors_in_practice.Any())
                            {
                                try
                                {
                                    var doctor = doctors_in_practice.SingleOrDefault();
                                    if (doctor != null)
                                    {
                                        case_data.treatment_doctor_id = doctor.DoctorID;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    case_data.treatment_doctor_id = Guid.Empty;
                                }
                            }
                        }
                    }
                    case_data.is_confirmed = _case.is_diagnosis_confirmed;
                    case_data.aftercare_doctor_practice_id = _case.is_aftercare_doctor ? _case.aftercare_doctor_id : _case.aftercare_practice_id;
                    case_data.aftercare_display_name = _case.is_aftercare_doctor ? _case.aftercare_doctor_display_name : _case.aftercare_practice_display_name;

                    var oct_planned_action_data = cls_Get_Case_PlannedActionData_for_CaseID_and_ActionTypeGpmID.Invoke(connection, dbTransaction, new P_CAS_GCPADfCIDaATGpmID_1235()
                    {
                        CaseID = _case.case_id,
                        ActionTypeGpmID = EActionType.PlannedOct.Value()
                    }, securityTicket).Result;

                    if (oct_planned_action_data != null)
                    {
                        var oct_doctor = cls_Get_Case_DoctorData_for_DoctorBptID.Invoke(connection, dbTransaction, new P_CAS_GCDDfDBptID_1242() { DoctorBptID = oct_planned_action_data.to_be_performed_by_bpt_id }, securityTicket).Result;
                        if (oct_doctor != null)
                        {
                            case_data.oct_doctor_id = oct_doctor.id;
                            case_data.oct_doctor_display_name = GenericUtils.GetDoctorName(oct_doctor);
                        }
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
            finally
            {
                connection.Close();
            }

            return case_data;
        }

        public Guid GetDiagnosisIDForNameAndPatient(Guid patient_id, string name, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var request = HttpContext.Current.Request;
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(request);

            transaction = new TransactionalInformation();
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            try
            {
                var diagnoses_from_db = cls_Get_Diagnoses_for_PatientID.Invoke(connectionString, new P_PA_GDfPID_1726() { PatientID = patient_id }, securityTicket).Result;
                var filtered_daignosis = diagnoses_from_db.SingleOrDefault(x => (x.diagnose_name + " (" + x.catalog_display_name + ": " + x.diagnose_icd_10 + ")").Contains(name));

                return filtered_daignosis.diagnose_id;
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

            return Guid.Empty;
        }

        public Guid GetDrugIDForName(string drugName, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var request = HttpContext.Current.Request;
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(request);
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            transaction = new TransactionalInformation();

            try
            {
                var drugs_from_db = cls_Get_All_Drugs_for_PracticeID.Invoke(connectionString, new P_CAS_GADfPID_1620() { PracticeID = data.PracticeID }, securityTicket).Result;
                var filtered_drug = drugs_from_db.SingleOrDefault(x => x.drug_name.Contains(drugName));

                return filtered_drug.drug_id;
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
            return Guid.Empty;
        }

        public long GetCasesCount(ElasticParameterObject parameter, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var request = HttpContext.Current.Request;
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(request);

            transaction = new TransactionalInformation();
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            long response = 0;

            try
            {
                response = Get_Cases.GetCasesCount(parameter, data.PracticeID.ToString(), "", "-", securityTicket);
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

            return response;
        }
        public ContractModel[] GetContractList(Guid patient_id, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var request = HttpContext.Current.Request;
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(request);

            transaction = new TransactionalInformation();
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            try
            {
                var patient_hip = cls_Get_Patient_Insurance_Data_for_PatientIDs.Invoke(connectionString, new P_PA_GPIDfPIDs_1002() { PatientIDs = new Guid[] { patient_id } }, securityTicket).Result.FirstOrDefault();
                if (patient_hip != null)
                {
                    return cls_Get_Contracts_Where_Hip_Participating_for_HipID.Invoke(connectionString, new P_PA_GCwHipPfHipID_0954() { HipIkNumber = patient_hip.HipIkNumber }, securityTicket).Result.Select(ctr =>
                    {
                        return new ContractModel()
                        {
                            id = ctr.ContractID.ToString(),
                            name = ctr.ContractName,
                            participation_consent_valid_days = ctr.ParticipationConsentValidForMonths,
                            ValidFrom = ctr.ValidFrom,
                            ValidTo = ctr.ValidThrough
                        };
                    }).ToArray();
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

            return new ContractModel[] { };
        }

        public bool CanShowOrderMessage(string connectionString, string sessionTicket, out TransactionalInformation transaction, DbConnection dbConnection = null, DbTransaction dbTransaction = null)
        {
            var handle_connection = dbConnection == null;
            var handle_transaction = dbTransaction == null;

            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = HttpContext.Current != null ? Util.GetIPInfo(HttpContext.Current.Request) : new IPInfo() { agent = "none", address = "none" };

            transaction = new TransactionalInformation();
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            try
            {
                if (handle_connection)
                {
                    dbConnection = DBSQLSupport.CreateConnection(connectionString);
                }

                try
                {
                    if (handle_connection)
                    {
                        dbConnection.Open();
                    }

                    if (handle_transaction)
                    {
                        dbTransaction = dbConnection.BeginTransaction();
                    }

                    //////////
                    var isDoctor = data.AccountInformation.role == Properties.Settings.Default.OPDocAccountDocApp || data.AccountInformation.role == Properties.Settings.Default.ACDocAccountDocApp;
                    var canShow = true;
                    if (isDoctor)
                    {
                        var doctor = ORM_HEC_Doctor.Query.Search(dbConnection, dbTransaction, new ORM_HEC_Doctor.Query
                        {
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false,
                            HEC_DoctorID = data.DoctorID
                        }).SingleOrDefault();

                        if (doctor != null)
                        {
                            var showSubmittedOrderGPM = ORM_HEC_Doctor_UniversalProperty.Query.Search(dbConnection, dbTransaction, new ORM_HEC_Doctor_UniversalProperty.Query
                            {
                                Tenant_RefID = securityTicket.TenantID,
                                IsDeleted = false,
                                GlobalPropertyMatchingID = EDoctorParameters.ShowSubmittedOrderMessage.Value()
                            }).SingleOrDefault();

                            if (showSubmittedOrderGPM != null)
                            {
                                var showSubmittedOrderValue = ORM_HEC_Doctor_UniversalPropertyValue.Query.Search(dbConnection, dbTransaction, new ORM_HEC_Doctor_UniversalPropertyValue.Query
                                {
                                    Tenant_RefID = securityTicket.TenantID,
                                    IsDeleted = false,
                                    UniversalProperty_RefID = showSubmittedOrderGPM.HEC_Doctor_UniversalPropertyID,
                                    HEC_Doctor_RefID = doctor.HEC_DoctorID
                                }).SingleOrDefault();

                                canShow = showSubmittedOrderValue == null ? true : showSubmittedOrderValue.Value_Boolean;
                            }
                        }
                    }
                    else
                    {
                        var practice = ORM_HEC_MedicalPractis.Query.Search(dbConnection, dbTransaction, new ORM_HEC_MedicalPractis.Query
                        {
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false,
                            HEC_MedicalPractiseID = data.PracticeID
                        }).SingleOrDefault();

                        if (practice != null)
                        {
                            var showSumittedOrderGPM = ORM_HEC_MedicalPractice_UniversalProperty.Query.Search(dbConnection, dbTransaction, new ORM_HEC_MedicalPractice_UniversalProperty.Query
                            {
                                Tenant_RefID = securityTicket.TenantID,
                                IsDeleted = false,
                                GlobalPropertyMatchingID = EPracticeParameters.ShowSubmittedOrderMessage.Value()
                            }).SingleOrDefault();
                            if (showSumittedOrderGPM != null)
                            {


                                var showSumittedOrderValue = ORM_HEC_MedicalPractice_2_UniversalProperty.Query.Search(dbConnection, dbTransaction, new ORM_HEC_MedicalPractice_2_UniversalProperty.Query
                                {
                                    Tenant_RefID = securityTicket.TenantID,
                                    IsDeleted = false,
                                    HEC_MedicalPractice_UniversalProperty_RefID = showSumittedOrderGPM.HEC_MedicalPractice_UniversalPropertyID,
                                    HEC_MedicalPractice_RefID = practice.HEC_MedicalPractiseID
                                }).SingleOrDefault();
                                canShow = showSumittedOrderValue == null ? true : showSumittedOrderValue.Value_Boolean;
                            }
                        }
                    }

                    return canShow;

                    //////////

                    if (handle_transaction)
                    {
                        dbTransaction.Commit();
                    }
                }
                finally
                {
                    if (handle_connection)
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
            return true;
        }
        #endregion

        #region MANIPULATION
        public Guid CreateCase(Case new_case, string connectionString, string sessionTicket, out TransactionalInformation transaction, DbConnection dbConnection = null, DbTransaction dbTransaction = null)
        {
            var handle_connection = dbConnection == null;
            var handle_transaction = dbTransaction == null;

            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = HttpContext.Current != null ? Util.GetIPInfo(HttpContext.Current.Request) : new IPInfo() { agent = "none", address = "none" };

            transaction = new TransactionalInformation();
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            Guid new_case_id = Guid.Empty;

            try
            {
                if (handle_connection)
                {
                    dbConnection = DBSQLSupport.CreateConnection(connectionString);
                }

                try
                {
                    if (handle_connection)
                    {
                        dbConnection.Open();
                    }

                    if (handle_transaction)
                    {
                        dbTransaction = dbConnection.BeginTransaction();
                    }

                    var culture = new System.Globalization.CultureInfo("de", true);
                    var treatment_date = DateTime.Parse(new_case.treatment_date, culture, System.Globalization.DateTimeStyles.None);

                    var parameter = new P_CAS_SC_1711();
                    parameter.aftercare_doctor_practice_id = new_case.aftercare_doctor_practice_id;
                    parameter.practice_id = data.PracticeID;
                    parameter.delivery_date = DateTime.ParseExact(new_case.treatment_date, "dd.MM.yyyy", culture);
                    parameter.min_delivery_date = DateTime.Parse(new_case.min_delivery_date, culture, System.Globalization.DateTimeStyles.AssumeLocal);
                    parameter.alternative_delivery_date_from = parameter.alternative_delivery_date_to = DateTime.Parse(new_case.treatment_date, culture, System.Globalization.DateTimeStyles.AssumeLocal);
                    parameter.case_id = new_case.case_id;
                    parameter.diagnose_id = new_case.diagnose_id;
                    parameter.drug_id = new_case.drug_id;
                    parameter.is_confirmed = new_case.is_confirmed;
                    parameter.is_label_only = new_case.is_label_only;
                    parameter.is_left_eye = new_case.is_left_eye;
                    parameter.is_quick_order = new_case.is_quick_order;
                    parameter.submit_created_case = new_case.submit_created_case;
                    parameter.is_documentation_only = new_case.is_documentation_only;
                    if (parameter.case_id == Guid.Empty)
                    {
                        parameter.is_orders_drug = treatment_date < DateTime.Now.Date ? false : new_case.is_orders_drug;
                    }
                    else
                    {
                        parameter.is_orders_drug = new_case.is_orders_drug;
                    }

                    parameter.is_patient_fee_waived = new_case.is_patient_fee_waived;
                    parameter.is_send_invoice_to_practice = new_case.is_send_invoice_to_practice;
                    parameter.patient_id = new_case.patient_id;
                    parameter.treatment_date = treatment_date;
                    parameter.treatment_doctor_id = new_case.treatment_doctor_id;
                    parameter.planned_action_id = new_case.planned_action_id;
                    parameter.order_comment = new_case.order_comment;
                    parameter.withdraw_oct = new_case.withdraw_oct;
                    parameter.submited_by_doctor_id = new_case.submited_by_doctor_id;

                    var submit_oct_until_date = DateTime.MinValue;
                    if (DateTime.TryParseExact(new_case.submit_oct_until_date, "dd.MM.yyyy", culture, DateTimeStyles.AssumeLocal, out submit_oct_until_date))
                    {
                        parameter.submit_oct_until_date = submit_oct_until_date;
                    }

                    if (new_case.oct_doctor_id.HasValue)
                    {
                        parameter.oct_doctor_id = new_case.oct_doctor_id.Value;
                    }

                    if (new_case.aftercare_performed_date != null)
                    {
                        parameter.aftercare_performed_date = DateTime.Parse(new_case.aftercare_performed_date, culture, System.Globalization.DateTimeStyles.AssumeLocal);
                    }

                    Case previous_state = null;

                    if (new_case.case_id != Guid.Empty)
                    {
                        Thread detailsThread = new Thread(() => GetCasePreviousDetails(out previous_state, new_case.case_id, connectionString, sessionTicket));
                        detailsThread.Start();
                    }

                    new_case_id = cls_Save_Case.Invoke(dbConnection, dbTransaction, parameter, securityTicket).Result;

                    var elasticRefresher = new ElasticRefresher(new Guid[] { new_case.patient_id }, dbConnection, dbTransaction, securityTicket);
                    elasticRefresher.RebuildElastic();

                    Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, new_case, previous_state), data.PracticeName);

                    if (handle_transaction)
                    {
                        dbTransaction.Commit();
                    }
                }
                finally
                {
                    if (handle_connection)
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

            return new_case_id;
        }

        public String SubmitCase(Guid case_id, Guid authorizing_doctor_id, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            lock (lockObj)
            {
                var request = HttpContext.Current.Request;
                var method = MethodInfo.GetCurrentMethod();
                var ipInfo = Util.GetIPInfo(request);

                transaction = new TransactionalInformation();
                var securityTicket = VerifySessionToken(sessionTicket);
                var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;
                var report_url = "";

                try
                {
                    using (var dbConnection = DBSQLSupport.CreateConnection(connectionString))
                    {
                        dbConnection.Open();
                        var dbTransaction = dbConnection.BeginTransaction();

                        var parameter = new P_CAS_SC_1425()
                        {
                            case_ids = new Guid[] { case_id },
                            is_treatment = true,
                            practice_id = data.PracticeID,
                            authorizing_doctor_id = authorizing_doctor_id
                        };

                        //TODO REBUILD OCT ELASTIC
                        var submitted_case_data = cls_Submit_Case.Invoke(dbConnection, dbTransaction, parameter, securityTicket).Result;

                        if (submitted_case_data != null)
                        {
                            if (!String.IsNullOrEmpty(submitted_case_data.pdf_report_url))
                            {
                                report_url = submitted_case_data.pdf_report_url;
                            }

                            var elasticRefresher = new ElasticRefresher(submitted_case_data.patient_ids, dbConnection, dbTransaction, securityTicket, true);
                            elasticRefresher
                                .UpdateIvoms()
                                .UpdateAftercare()
                                .UpdateOct()
                                .RebuildElastic();
                        }

                        Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, parameter), data.PracticeName);

                        dbTransaction.Commit();
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

                return report_url;
            }
        }

        public Guid CancelCase(Guid case_id, bool cancel_treatment, bool cancel_drug_order, string connectionString, string sessionTicket, out TransactionalInformation transaction)
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

                    var parameter = new P_CAS_CC_1641() { case_id = case_id, cancel_drug_order = cancel_drug_order, cancel_treatment = cancel_treatment };
                    var patient_id = cls_Cancel_Case.Invoke(dbConnection, dbTransaction, parameter, securityTicket).Result;

                    var elasticRefresher = new ElasticRefresher(new Guid[] { patient_id }, dbConnection, dbTransaction, securityTicket, true);
                    elasticRefresher
                        .UpdateIvoms()
                        .UpdateOct()
                        .UpdateOrders()
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

            return case_id;
        }

        public object MultiEditCase(Guid authorizing_doctor_id, Guid[] case_ids, Guid[] case_ids_to_submit, Guid[] deselected_ids, bool all_selected, Guid treatment_doctor_id, Guid aftercare_doctor_id, bool should_submit, FilterObject filter, string connectionString, string sessionTicket, out TransactionalInformation transaction, DbConnection dbConnection = null, DbTransaction dbTransaction = null)
        {
            var handle_connection = dbConnection == null;
            var handle_transaction = dbTransaction == null;

            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = HttpContext.Current != null ? Util.GetIPInfo(HttpContext.Current.Request) : new IPInfo() { agent = "none", address = "none" };

            transaction = new TransactionalInformation();
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            List<Guid> response = new List<Guid>();
            var reportUrl = "";

            try
            {
                if (handle_connection)
                {
                    dbConnection = DBSQLSupport.CreateConnection(connectionString);
                }

                try
                {
                    if (handle_connection)
                    {
                        dbConnection.Open();
                    }

                    if (handle_transaction)
                    {
                        dbTransaction = dbConnection.BeginTransaction();
                    }

                    lock (lockObj)
                    {
                        ElasticParameterObject filter_by = new ElasticParameterObject();
                        filter_by.date_from = filter.date_from;
                        filter_by.date_to = filter.date_to;
                        filter_by.filter_by.filter_status = filter.filter_by.filter_status;
                        filter_by.filter_by.filter_type = filter.filter_by.filter_type;
                        filter_by.search_params = filter.search_params;
                        filter_by.filter_by.orders = filter.filter_by.orders;
                        filter_by.filter_by.filter_current = filter.filter_by.filter_current;
                        filter_by.filter_by.localization = filter.filter_by.localization;

                        var patient_ids = new List<Guid>();
                        var case_id_list = new List<Guid>();

                        if (all_selected || deselected_ids.Length != 0)
                        {
                            var cases = Get_Cases.GetCasesFilteredIDs(filter_by, data.PracticeID.ToString(), Array.ConvertAll(deselected_ids, x => x.ToString()), should_submit, authorizing_doctor_id.ToString(), treatment_doctor_id.ToString(),
                                "treatment_date", false, securityTicket).ToList();

                            for (var i = 0; i < cases.Count; i++)
                            {
                                var _case = cases[i];
                                case_id_list.Add(Guid.Parse(_case.id));
                                patient_ids.Add(Guid.Parse(_case.patient_id));
                            }

                            case_ids = case_id_list.ToArray();
                        }

                        CAS_SC_1425 submitted_case_data = null;
                        if (case_ids.Length != 0)
                        {
                            if (!should_submit)
                            {
                                response = cls_Save_Case_Multi_Edit.Invoke(dbConnection, dbTransaction, new P_CAS_SCME_1741()
                                {
                                    is_treatment = true,
                                    case_ids = case_ids,
                                    treatment_doctor_id = treatment_doctor_id,
                                    aftercare_doctor_id = aftercare_doctor_id,
                                    practice_id = data.PracticeID
                                }, securityTicket).Result.ToList();

                                foreach (var cas in response)
                                {
                                    patient_ids.Add(ORM_HEC_CAS_Case.Query.Search(dbConnection, dbTransaction, new ORM_HEC_CAS_Case.Query { Tenant_RefID = securityTicket.TenantID, IsDeleted = false, HEC_CAS_CaseID = cas }).Single().Patient_RefID);
                                }
                            }
                            else
                            {
                                if (case_ids_to_submit.Length != 0)
                                {
                                    submitted_case_data = cls_Submit_Case.Invoke(dbConnection, dbTransaction, new P_CAS_SC_1425()
                                    {
                                        case_ids = case_ids_to_submit,
                                        is_treatment = true,
                                        practice_id = data.PracticeID,
                                        authorizing_doctor_id = authorizing_doctor_id
                                    }, securityTicket).Result;

                                    patient_ids = submitted_case_data.patient_ids.ToList();
                                    if (!String.IsNullOrEmpty(submitted_case_data.pdf_report_url))
                                    {
                                        reportUrl = submitted_case_data.pdf_report_url;
                                    }
                                }
                            }
                        }

                        var elasticRefresher = new ElasticRefresher(patient_ids, dbConnection, dbTransaction, securityTicket, true);
                        elasticRefresher
                            .UpdateOct()
                            .UpdateIvoms();

                        if (should_submit)
                        {
                            elasticRefresher.UpdateAftercare();
                        }

                        elasticRefresher.RebuildElastic();

                        Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, new TreatmentMultiEditSubmitModel()
                        {
                            CaseIDs = case_ids,
                            IsSubmit = should_submit,
                            AftercareDoctorID = aftercare_doctor_id,
                            AuthorizingDoctorID = authorizing_doctor_id,
                            CaseIDsToSubmit = case_ids_to_submit,
                            PracticeID = data.PracticeID,
                            TreatmentDoctorID = treatment_doctor_id
                        }), data.PracticeName);
                    }

                    if (handle_transaction)
                    {
                        dbTransaction.Commit();
                    }
                }
                finally
                {
                    if (handle_connection)
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

            if (reportUrl != "")
                return reportUrl;

            return response.ToArray();
        }

        public Guid CreateTemporaryAftercareDoctor(string name, string street, string house_number, string zip, string city, string phone, string fax, string email, string comment, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var request = HttpContext.Current.Request;
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(request);

            transaction = new TransactionalInformation();
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            Guid response = Guid.Empty;
            try
            {
                var parameter = new P_DO_SAHD_1815()
                {
                    name = name,
                    city = city,
                    comment = comment,
                    email = email,
                    fax = fax,
                    house_number = house_number,
                    phone = phone,
                    practice_id = data.PracticeID,
                    street = street,
                    zip = zip
                };

                response = cls_Save_AdHoc_Doctor.Invoke(connectionString, parameter, securityTicket).Result;
                Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, parameter), data.PracticeName);

            }
            catch (Exception ex)
            {
                Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, ex), data.PracticeName);

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                if (ex.InnerException != null)
                {
                    transaction.ReturnMessage.Add(ex.StackTrace);
                    transaction.ReturnMessage.Add(ex.Message);
                }

                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }

            return response;
        }

        public void SaveOrderMessageVisability(string connectionString, string sessionTicket, out TransactionalInformation transaction, DbConnection dbConnection = null, DbTransaction dbTransaction = null)
        {
            var handle_connection = dbConnection == null;
            var handle_transaction = dbTransaction == null;

            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = HttpContext.Current != null ? Util.GetIPInfo(HttpContext.Current.Request) : new IPInfo() { agent = "none", address = "none" };

            transaction = new TransactionalInformation();
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            try
            {
                if (handle_connection)
                {
                    dbConnection = DBSQLSupport.CreateConnection(connectionString);
                }

                try
                {
                    if (handle_connection)
                    {
                        dbConnection.Open();
                    }

                    if (handle_transaction)
                    {
                        dbTransaction = dbConnection.BeginTransaction();
                    }

                    //////////
                    var isDoctor = data.AccountInformation.role == Properties.Settings.Default.OPDocAccountDocApp || data.AccountInformation.role == Properties.Settings.Default.ACDocAccountDocApp;

                    if (isDoctor)
                    {
                        var doctor = ORM_HEC_Doctor.Query.Search(dbConnection, dbTransaction, new ORM_HEC_Doctor.Query
                        {
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false,
                            HEC_DoctorID = data.DoctorID
                        }).SingleOrDefault();

                        if (doctor != null)
                        {
                            var submittedOrderMessageGPM = ORM_HEC_Doctor_UniversalProperty.Query.Search(dbConnection, dbTransaction, new ORM_HEC_Doctor_UniversalProperty.Query
                            {
                                Tenant_RefID = securityTicket.TenantID,
                                IsDeleted = false,
                                GlobalPropertyMatchingID = EDoctorParameters.ShowSubmittedOrderMessage.Value()
                            }).SingleOrDefault();
                            if (submittedOrderMessageGPM == null)
                            {
                                submittedOrderMessageGPM = new ORM_HEC_Doctor_UniversalProperty()
                                {
                                    Tenant_RefID = securityTicket.TenantID,
                                    GlobalPropertyMatchingID = EDoctorParameters.ShowSubmittedOrderMessage.Value(),
                                    IsValue_Boolean = true,
                                    PropertyName = String.Empty
                                };
                                submittedOrderMessageGPM.Save(dbConnection, dbTransaction);
                            }

                            var submittedOrderMessageValue = ORM_HEC_Doctor_UniversalPropertyValue.Query.Search(dbConnection, dbTransaction, new ORM_HEC_Doctor_UniversalPropertyValue.Query
                            {
                                Tenant_RefID = securityTicket.TenantID,
                                IsDeleted = false,
                                UniversalProperty_RefID = submittedOrderMessageGPM.HEC_Doctor_UniversalPropertyID,
                                HEC_Doctor_RefID = doctor.HEC_DoctorID
                            }).SingleOrDefault();
                            if (submittedOrderMessageValue == null)
                            {
                                submittedOrderMessageValue = new ORM_HEC_Doctor_UniversalPropertyValue
                                {
                                    Tenant_RefID = securityTicket.TenantID,
                                    UniversalProperty_RefID = submittedOrderMessageGPM.HEC_Doctor_UniversalPropertyID,
                                    HEC_Doctor_RefID = doctor.HEC_DoctorID
                                };
                            }
                            submittedOrderMessageValue.Value_Boolean = false;
                            submittedOrderMessageValue.Save(dbConnection, dbTransaction);

                        }
                    }
                    else
                    {
                        var practice = ORM_HEC_MedicalPractis.Query.Search(dbConnection, dbTransaction, new ORM_HEC_MedicalPractis.Query
                           {
                               Tenant_RefID = securityTicket.TenantID,
                               IsDeleted = false,
                               HEC_MedicalPractiseID = data.PracticeID
                           }).SingleOrDefault();

                        if (practice != null)
                        {
                            var submittedOrderMessageGPM = ORM_HEC_MedicalPractice_UniversalProperty.Query.Search(dbConnection, dbTransaction, new ORM_HEC_MedicalPractice_UniversalProperty.Query
                            {
                                Tenant_RefID = securityTicket.TenantID,
                                IsDeleted = false,
                                GlobalPropertyMatchingID = EPracticeParameters.ShowSubmittedOrderMessage.Value()
                            }).SingleOrDefault();
                            if (submittedOrderMessageGPM == null)
                            {
                                submittedOrderMessageGPM = new ORM_HEC_MedicalPractice_UniversalProperty()
                                {
                                    Tenant_RefID = securityTicket.TenantID,
                                    GlobalPropertyMatchingID = EPracticeParameters.ShowSubmittedOrderMessage.Value(),
                                    IsValue_Boolean = true,
                                    PropertyName = String.Empty
                                };
                                submittedOrderMessageGPM.Save(dbConnection, dbTransaction);
                            }

                            var submittedOrderMessageValue = ORM_HEC_MedicalPractice_2_UniversalProperty.Query.Search(dbConnection, dbTransaction, new ORM_HEC_MedicalPractice_2_UniversalProperty.Query
                            {
                                Tenant_RefID = securityTicket.TenantID,
                                IsDeleted = false,
                                HEC_MedicalPractice_UniversalProperty_RefID = submittedOrderMessageGPM.HEC_MedicalPractice_UniversalPropertyID,
                                HEC_MedicalPractice_RefID = practice.HEC_MedicalPractiseID
                            }).SingleOrDefault();
                            if (submittedOrderMessageValue == null)
                            {
                                submittedOrderMessageValue = new ORM_HEC_MedicalPractice_2_UniversalProperty
                                {
                                    Tenant_RefID = securityTicket.TenantID,
                                    HEC_MedicalPractice_UniversalProperty_RefID = submittedOrderMessageGPM.HEC_MedicalPractice_UniversalPropertyID,
                                    HEC_MedicalPractice_RefID = practice.HEC_MedicalPractiseID
                                };
                            }
                            submittedOrderMessageValue.Value_Boolean = false;
                            submittedOrderMessageValue.Save(dbConnection, dbTransaction);
                        }
                    }

                    //////////

                    if (handle_transaction)
                    {
                        dbTransaction.Commit();
                    }

                    Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket), data.PracticeName);
                }
                finally
                {
                    if (handle_connection)
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

        #endregion

        #region VALIDATION
        /// <summary>
        /// This method verifies whether the patient is eligible for treatment
        /// </summary>
        /// <param name="drug_id"></param>
        /// <param name="patient_id"></param>
        /// <param name="treatment_date"></param>
        /// <param name="connectionString"></param>
        /// <param name="sessionTicket"></param>
        /// <param name="transaction"></param>
        /// <returns>TreatmentEligibility object which specifies whether the patient is eligible for treatment and if not, the reason why</returns>
        public TreatmentEligibility VerifyTreatmentEligibility(Guid drug_id, Guid patient_id, string treatment_date, bool is_resubmit, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var request = HttpContext.Current.Request;
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(request);

            transaction = new TransactionalInformation();
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            var treatment_eligibility = new TreatmentEligibility();

            IFormatProvider culture = new CultureInfo("de", true);

            try
            {
                var dbConnection = DBSQLSupport.CreateConnection(connectionString);
                DbTransaction dbTransaction = null;
                try
                {
                    dbConnection.Open();
                    dbTransaction = dbConnection.BeginTransaction();

                    if (drug_id == Guid.Empty)
                    {
                        treatment_eligibility.eligible = false;
                    }
                    else
                    {
                        var treatment_date_datetime = DateTime.Now;

                        try
                        {
                            treatment_date_datetime = DateTime.Parse(treatment_date, culture, DateTimeStyles.AssumeLocal);
                        }
                        catch (Exception ex)
                        {
                            treatment_eligibility.eligible = false;
                            treatment_eligibility.reason = "date";
                            return treatment_eligibility;
                        }

                        var patientHealthInsurance = ORM_HEC_Patient_HealthInsurance.Query.Search(dbConnection, dbTransaction, new ORM_HEC_Patient_HealthInsurance.Query()
                        {
                            Patient_RefID = patient_id,
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false
                        }).SingleOrDefault();

                        if (patientHealthInsurance == null || patientHealthInsurance.HealthInsurance_Number == "privat")
                        {
                            treatment_eligibility.reason = "hip";
                            return treatment_eligibility;
                        }

                        var patientService = new PatientDataService();
                        var isInsuranceNumberValid = patientService.CheckIfKVNRIsValid(patientHealthInsurance.HealthInsurance_Number, connectionString, sessionTicket, out transaction);
                        if (!isInsuranceNumberValid)
                        {
                            treatment_eligibility.reason = "insurance_number";
                            return treatment_eligibility;
                        }

                        var hip_contracts = cls_Get_Patients_HIP_Contracts.Invoke(dbConnection, dbTransaction, new P_PA_GPHIPC_1731() { PatientID = patient_id }, securityTicket).Result;
                        if (hip_contracts.Length != 0)
                        {
                            var eligible_contracts = new List<ConsentVerificationModel>();

                            #region Cache

                            var doctorParticipationsCache = ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingDoctor.Query.Search(dbConnection, dbTransaction, new ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingDoctor.Query()
                            {
                                Tenant_RefID = securityTicket.TenantID,
                                IsDeleted = false
                            }).GroupBy(t => t.InsuranceToBrokerContract_RefID).Select(t => new { key = t.Key, value = t }).ToDictionary(t => t.key, t => t.value);

                            #endregion

                            foreach (var contract in hip_contracts)
                            {
                                if (data != null)
                                {
                                    var doctor_ids = cls_Get_DoctorIDs_for_PracticeID.Invoke(dbConnection, dbTransaction, new P_DO_GDIDsfPID_1635() { PracticeID = data.PracticeID }, securityTicket).Result;
                                    if (doctor_ids.Length == 0)
                                    {
                                        treatment_eligibility.eligible = false;
                                        treatment_eligibility.reason = "doctors";
                                        return treatment_eligibility;
                                    }
                                    else
                                    {
                                        var insurance_broker = ORM_HEC_CRT_InsuranceToBrokerContract.Query.Search(dbConnection, dbTransaction, new ORM_HEC_CRT_InsuranceToBrokerContract.Query()
                                        {
                                            Ext_CMN_CTR_Contract_RefID = contract.contract_id,
                                            Tenant_RefID = securityTicket.TenantID,
                                            IsDeleted = false
                                        }).SingleOrDefault();

                                        if (insurance_broker != null)
                                        {
                                            foreach (var doctor in doctor_ids)
                                            {
                                                if (!eligible_contracts.Any(t => t.ContractID == contract.contract_id) && doctorParticipationsCache.ContainsKey(insurance_broker.HEC_CRT_InsuranceToBrokerContractID))
                                                {
                                                    var doctor_consents = doctorParticipationsCache[insurance_broker.HEC_CRT_InsuranceToBrokerContractID].Where(t => t.Doctor_RefID == doctor.DoctorID);

                                                    var eligible = doctor_consents.Select(consent =>
                                                    {
                                                        var left_side = consent.ValidThrough == DateTime.MinValue ? true : consent.ValidThrough >= treatment_date_datetime;
                                                        var right_side = consent.ValidFrom <= treatment_date_datetime;
                                                        return left_side && right_side;
                                                    }).Any(el => el);

                                                    if (eligible)
                                                    {
                                                        eligible_contracts.Add(new ConsentVerificationModel()
                                                        {
                                                            ContractID = contract.contract_id,
                                                            InsuranceToBrokerContractID = insurance_broker.HEC_CRT_InsuranceToBrokerContractID
                                                        });
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                            treatment_eligibility.eligible = eligible_contracts.Count != 0;

                            if (treatment_eligibility.eligible)
                            {
                                var patient_participation_consents = ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingPatient.Query.Search(dbConnection, dbTransaction, new ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingPatient.Query()
                                {
                                    Patient_RefID = patient_id,
                                    IsDeleted = false
                                });

                                if (!patient_participation_consents.Any())
                                {
                                    treatment_eligibility.eligible = false;
                                    treatment_eligibility.reason = "LABEL_PATIENT_HAS_NO_CONSENT";
                                    return treatment_eligibility;
                                }

                                #region CHECK PATIENT PARTICIPATION
                                var all_contract_parameters = ORM_CMN_CTR_Contract_Parameter.Query.Search(dbConnection, dbTransaction, new ORM_CMN_CTR_Contract_Parameter.Query() { Tenant_RefID = securityTicket.TenantID, IsDeleted = false })
                                    .GroupBy(t => t.Contract_RefID).ToDictionary(t => t.Key, t => t.ToList());

                                var all_participation = ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingPatient.Query.Search(dbConnection, dbTransaction, new ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingPatient.Query()
                                {
                                    Patient_RefID = patient_id,
                                    Tenant_RefID = securityTicket.TenantID
                                });

                                var all_patient_participations = all_participation.GroupBy(t => t.InsuranceToBrokerContract_RefID).ToDictionary(t => t.Key, t => t.ToList());

                                var any_patient_consent_valid = all_patient_participations.Any(patient_participation => patient_participation.Value.Any(t =>
                                {
                                    var valid_from_condition = false;
                                    var valid_through_condition = false;

                                    var contract = eligible_contracts.Single(x => x.InsuranceToBrokerContractID == t.InsuranceToBrokerContract_RefID);
                                    var consent_valid_for_months_parameter = all_contract_parameters[contract.ContractID].SingleOrDefault(x => x.ParameterName == "Duration of participation consent – Month");
                                    var days_between_surgery_and_aftercare_parameter = all_contract_parameters[contract.ContractID].SingleOrDefault(x => x.ParameterName == "Number of days between surgery and aftercare - Days");
                                    var days_between_surgery_and_aftercare = days_between_surgery_and_aftercare_parameter != null ? days_between_surgery_and_aftercare_parameter.IfNumericValue_Value : 0;
                                    var is_consent_auto_renewed_by_op = all_contract_parameters[contract.ContractID].Any(x => x.ParameterName == "OP renews patient consent");
                                    var consent_valid_for_months = consent_valid_for_months_parameter != null ? Convert.ToInt32(consent_valid_for_months_parameter.IfNumericValue_Value) : 12;

                                    if (!is_consent_auto_renewed_by_op)
                                    {
                                        var validFrom = t.ValidFrom;
                                        var validTo = t.ValidFrom.AddMonths(consent_valid_for_months);
                                        var contractShouldStart = treatment_date_datetime.Date.Subtract(validTo.Date.AddDays(-days_between_surgery_and_aftercare)).Days;

                                        if (validFrom <= treatment_date_datetime.Date && treatment_date_datetime.Date <= validTo)
                                        {
                                            if ((validFrom <= treatment_date_datetime.Date && validTo.AddDays(-days_between_surgery_and_aftercare).Date >= treatment_date_datetime.Date) ||
                                                (all_participation.Any(x => x.ValidFrom >= validFrom.AddDays(contractShouldStart) && x.ValidFrom <= validTo)) ||
                                                (all_participation.Any(x => x.ValidFrom == validTo)))
                                            {
                                                return true;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (t.ValidFrom.Date <= treatment_date_datetime.Date && t.ValidFrom.AddMonths(consent_valid_for_months).AddDays(-days_between_surgery_and_aftercare).Date > treatment_date_datetime.Date)
                                        {
                                            return true;
                                        }

                                        var op_dates = cls_Get_PerformedOpDates_for_PatientID.Invoke(dbConnection, dbTransaction, new P_CAS_GPOpDfPID_0959() { PatientID = patient_id }, securityTicket).Result;

                                        var last_op_date = op_dates.FirstOrDefault();
                                        if (last_op_date != null)
                                        {
                                            var last_consent_valid_until = last_op_date.treatment_date.Date.AddMonths(consent_valid_for_months);
                                            if (last_consent_valid_until > treatment_date_datetime.Date)
                                            {
                                                return true;
                                            }
                                        }
                                    }

                                    return valid_from_condition && valid_through_condition;
                                }));
                                #endregion

                                if (!any_patient_consent_valid)
                                {
                                    treatment_eligibility.eligible = false;
                                    treatment_eligibility.reason = "LABEL_PATIENT_HAS_NO_CONSENT_ON_SELECTED_DATE";
                                    return treatment_eligibility;
                                }

                                var assignment = cls_Check_Drug_GPOS.Invoke(dbConnection, dbTransaction, new P_CAS_CDGPOS_1424() { DrugID = drug_id, PatientID = patient_id, IsResubmit = is_resubmit }, securityTicket).Result;

                                treatment_eligibility.eligible = assignment != null && assignment.AssignmentID != Guid.Empty;
                                if (!treatment_eligibility.eligible)
                                {
                                    treatment_eligibility.reason = "drug";
                                    return treatment_eligibility;
                                }

                            }
                            else
                            {
                                treatment_eligibility.reason = "doctors";
                                return treatment_eligibility;
                            }

                        }
                        else
                        {
                            treatment_eligibility.reason = "hip";
                            return treatment_eligibility;
                        }
                    }
                }
                catch
                { }
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

            return treatment_eligibility;
        }

        public bool CheckIfAlreadyExistTreatment(Guid case_id, Guid patient_id, string treatment_date, bool is_left_eye, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var request = HttpContext.Current.Request;
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(request);
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;
            transaction = new TransactionalInformation();

            var dbConnection = DBSQLSupport.CreateConnection(connectionString);
            DbTransaction dbTransaction = null;

            try
            {
                dbConnection.Open();
                dbTransaction = dbConnection.BeginTransaction();
                var culture = new System.Globalization.CultureInfo("de", true);
                var treatmentDate = DateTime.Parse(treatment_date, culture, System.Globalization.DateTimeStyles.AssumeLocal);

                var excludeFSStatuses = new List<int>() { 8, 11, 17 };

                var result = cls_Get_Treatment_for_PatientID_and_Localization_and_Treatment_Date_and_PracticeID.Invoke(dbConnection, dbTransaction, new P_CAS_GTfPIDaLaTDaPID_1707
                {
                    LocalizationCode = is_left_eye ? "L" : "R",
                    PatientID = patient_id,
                    PracticeID = data.PracticeID,
                    TreatmentDate = treatmentDate.Date,
                }, securityTicket).Result;


                var exist = result.Any(x => x.CaseID != case_id && ((x.TransmitionStatusKey == null) || (x.TransmitionStatusKey != null && x.TransmitionStatusKey == "treatment" && !excludeFSStatuses.Any(status => status == x.TransmitionCode))));

                return exist;
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
            finally
            {
                dbConnection.Close();
            }

            return false;
        }

        public MulitiSubmitValidation CheckIfAlreadyExistAnyTreatment(Guid[] case_ids, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var returnObject = new MulitiSubmitValidation();

            var request = HttpContext.Current.Request;
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(request);
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;


            transaction = new TransactionalInformation();

            var dbConnection = DBSQLSupport.CreateConnection(connectionString);
            DbTransaction dbTransaction = null;

            try
            {
                dbConnection.Open();
                dbTransaction = dbConnection.BeginTransaction();
                var culture = new System.Globalization.CultureInfo("de", true);
                if (case_ids == null || !case_ids.Any())
                {
                    return new MulitiSubmitValidation();
                }

                var excludeFSStatuses = new List<int>() { 8, 11, 17 };
                var treatmentInformation = cls_Get_Case_Treatment_Data_for_CaseIDs.Invoke(dbConnection, dbTransaction, new P_CAS_GCTDfCIDs_1624
                {
                    CaseIDs = case_ids
                }, securityTicket).Result;

                var numberOfInvalidCases = 0;
                var validTreatments = new List<CAS_GCTDfCIDs_1624>();

                var allSubmittedTreatments = cls_Get_Treatment_for_PatientIDs_and_PracticeIDs.Invoke(dbConnection, dbTransaction, new P_CAS_GTfPIDsaPIDs_1208
                {
                    PatientIDs = treatmentInformation.Select(x => x.patient_id).Distinct().ToArray(),
                    PracticeID = data.PracticeID
                }, securityTicket).Result;

                foreach (var treatment in treatmentInformation)
                {
                    var result = allSubmittedTreatments.Where(x => x.PlannedFor_Date.Date == treatment.treatment_date.Date && x.LocalizationCode == treatment.localization && x.Patient_RefID == treatment.patient_id && x.PlannedActionID != treatment.planned_action_id);

                    var existSubmittedTreatment = result.Any(x => x.TransmitionStatusKey != null && x.TransmitionStatusKey == "treatment" && !excludeFSStatuses.Any(status => status == x.TransmitionCode));
                    if (existSubmittedTreatment)
                    {
                        numberOfInvalidCases++;
                    }
                    else
                    {
                        var alreadyExistInValidList = validTreatments.Any(a => a.localization == treatment.localization && a.treatment_date == treatment.treatment_date && a.patient_id == treatment.patient_id && a.case_id != treatment.case_id);
                        if (!alreadyExistInValidList)
                        {
                            validTreatments.Add(treatment);
                        }
                    }
                }
                return new MulitiSubmitValidation()
                {
                    number_of_all_cases = case_ids.Count(),
                    valid_case_ids = treatmentInformation.Any() ? validTreatments.Select(x => x.case_id).ToList() : case_ids.ToList(),
                    number_of_invalid_cases = numberOfInvalidCases
                };
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
            finally
            {
                dbConnection.Close();
            }

            return new MulitiSubmitValidation();
        }

        public OCTValidation CheckIfOCTCanBeSubmitted(Guid case_id, Guid doctor_id, Guid patient_id, String treatment_date, Guid diagnosis_id, Guid medication_id, bool is_left_eye, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var returnObject = new OCTValidation { can_submit = true };

            var request = HttpContext.Current.Request;
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(request);
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            transaction = new TransactionalInformation();

            var dbConnection = DBSQLSupport.CreateConnection(connectionString);
            DbTransaction dbTransaction = null;

            try
            {
                dbConnection.Open();
                dbTransaction = dbConnection.BeginTransaction();

                var culture = new System.Globalization.CultureInfo("de", true);
                var treatmentDate = DateTime.Parse(treatment_date, culture, System.Globalization.DateTimeStyles.AssumeLocal);

                var oct_exist_for_case = cls_Get_OctID_for_CaseID.Invoke(dbConnection, dbTransaction, new P_CAS_GOIDfCID_1552 { CaseID = case_id }, securityTicket).Result.Any();
                returnObject.oct_exist_for_case = oct_exist_for_case;

                if (oct_exist_for_case)
                {
                    var oct_gpos_ids = cls_Get_GposIDs_for_GposType.Invoke(dbConnection, dbTransaction, new P_MD_GGpoIDsfGposT_1145()
                    {
                        GposType = EGposType.Oct.Value()
                    }, securityTicket).Result.Select(t => t.GposID).ToArray();

                    var patient_consents = cls_Get_Patient_Consents_before_Date_and_GposIDs.Invoke(dbConnection, dbTransaction, new P_PA_GPCbDaGposIDs_1154()
                    {
                        Date = treatmentDate,
                        GposIDs = oct_gpos_ids,
                        PatientID = patient_id
                    }, securityTicket).Result;

                    if (!patient_consents.Any())
                    {
                        returnObject.oct_exist_for_case = false;
                        returnObject.can_submit = false;
                        return returnObject;
                    }

                    var patient_consent = patient_consents.First();

                    var contract_parameters = ORM_CMN_CTR_Contract_Parameter.Query.Search(dbConnection, dbTransaction, new ORM_CMN_CTR_Contract_Parameter.Query()
                    {
                        Contract_RefID = patient_consent.contract_id,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    });


                    #region Max OCT's per treatment year

                    var useSettlementYear = contract_parameters.SingleOrDefault(t => t.ParameterName == EContractParameter.UseSettlementYear.Value()) != null;
                    var max_number_of_preexaminations = contract_parameters.SingleOrDefault(t => t.ParameterName == EContractParameter.MaxNumberOfOcts.Value());

                    var performedOCTsForYear = 0;
                    var treatment_year_length_ctr_parameter = contract_parameters.SingleOrDefault(t => t.ParameterName == EContractParameter.PreexaminationsDays.Value());
                    var treatment_year_length = treatment_year_length_ctr_parameter != null ? treatment_year_length_ctr_parameter.IfNumericValue_Value : 365;
                    var oct_planned_action_type_id = cls_Get_ActionTypeID.Invoke(dbConnection, dbTransaction, new P_CAS_GATID_1514() { action_type_gpmid = EActionType.PlannedOct.Value() }, securityTicket).Result;

                    if (max_number_of_preexaminations != null && useSettlementYear)
                    {
                        var localization = is_left_eye ? "L" : "R";

                        var treatment_year_start_date = cls_Get_TreatmentYear.Invoke(dbConnection, dbTransaction, new P_CAS_GTY_1125()
                        {
                            Date = treatmentDate.Date,
                            LocalizationCode = localization,
                            PatientID = patient_id
                        }, securityTicket).Result;
                        var treatment_year_end_date = treatment_year_start_date.Date.AddDays(treatment_year_length - 1);

                        performedOCTsForYear = cls_Get_TreatmentYearOctCount.Invoke(dbConnection, dbTransaction, new P_CAS_GTYOctC_1939()
                        {
                            LocalizationCode = "L",
                            OctPlannedActionTypeID = oct_planned_action_type_id,
                            PatientID = patient_id,
                            TreatmentYearStartDate = treatment_year_start_date,
                            TreatmentYearEndDate = treatment_year_end_date
                        }, securityTicket).Result.fs_status_count;

                        performedOCTsForYear += cls_Get_TreatmentYearOctCount.Invoke(dbConnection, dbTransaction, new P_CAS_GTYOctC_1939()
                        {
                            LocalizationCode = "R",
                            OctPlannedActionTypeID = oct_planned_action_type_id,
                            PatientID = patient_id,
                            TreatmentYearStartDate = treatment_year_start_date,
                            TreatmentYearEndDate = treatment_year_end_date
                        }, securityTicket).Result.fs_status_count;

                        var is_limit_exceeded = performedOCTsForYear >= max_number_of_preexaminations.IfNumericValue_Value;
                        if (is_limit_exceeded)
                        {
                            returnObject.can_submit = false;
                            returnObject.message = treatment_year_start_date.AddDays(treatment_year_length).ToString("dd.MM.yyyy");
                        }
                    }
                    #endregion Max OCT's per treatment year
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
            finally
            {
                dbConnection.Close();
            }

            return returnObject;


        }

        public bool CanSaveCaseAfterChangeLocalization(Guid case_id, Guid patient_id, bool is_left_eye, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var request = HttpContext.Current.Request;
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(request);
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            transaction = new TransactionalInformation();

            var dbConnection = DBSQLSupport.CreateConnection(connectionString);
            DbTransaction dbTransaction = null;

            try
            {
                dbConnection.Open();
                dbTransaction = dbConnection.BeginTransaction();

                var case_details = cls_Get_Case_Details_for_CaseID.Invoke(dbConnection, dbTransaction, new P_CAS_GCDfCID_1435() { CaseID = case_id }, securityTicket).Result;

                var new_localization = is_left_eye ? "L" : "R";
                if (new_localization != case_details.localization)
                {
                    var latest_oct_bill_position = cls_Get_Existing_OCT_BillPosition_for_PatientID_and_LocalizationCode.Invoke(dbConnection, dbTransaction, new P_CAS_GEBPfPIDaLC_1803()
                    {
                        LocalizationCode = case_details.localization,
                        PatientID = case_details.patient_id
                    }, securityTicket).Result;

                    var latest_new_localization_op = cls_Get_OpDates_for_PatientID_and_LocalizationCode_in_TreatmentYear.Invoke(dbConnection, dbTransaction, new P_CAS_GOpDfPIDaLCiTY_1110()
                    {
                        LocalizationCode = new_localization,
                        PatientID = case_details.patient_id,
                        TreatmentYearEndDate = DateTime.Now
                    }, securityTicket).Result.FirstOrDefault();

                    if (latest_oct_bill_position != null && latest_oct_bill_position.CaseID == case_details.case_id)
                    {
                        if (latest_new_localization_op == null)
                        {
                            var case_has_pending_oct = cls_Get_CaseIDs_with_Pending_Octs_for_PatientID_and_LocalizationCode.Invoke(dbConnection, dbTransaction, new P_CAS_GCIDswPOctsfPIDaLC_1103()
                            {
                                LocalizationCode = case_details.localization,
                                PatientID = case_details.patient_id
                            }, securityTicket).Result.Any(t => t.case_id == case_details.case_id);

                            if (case_has_pending_oct)
                            {
                                return false;
                            }
                        }
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
            finally
            {
                dbConnection.Close();
            }

            return true;
        }
        #endregion

        #region UTIL
        private static void GetCasePreviousDetails(out Case previous_state, Guid id, string connectionString, string sessionTicket)
        {
            var transaction = new TransactionalInformation();
            var pd = new PlanningDataService();

            previous_state = pd.GetCaseDetailsforCaseID(id, connectionString, sessionTicket, out transaction);
        }
        #endregion
    }
}