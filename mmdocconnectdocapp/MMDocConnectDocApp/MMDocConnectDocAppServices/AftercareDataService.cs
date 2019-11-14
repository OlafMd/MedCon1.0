using CL1_HEC;
using CSV2Core.SessionSecurity;
using CSV2Core_MySQL.Support;
using DLCore_TokenVerification;
using LogUtils;
using MMDocConnectDBMethods.Case.Atomic.Manipulation;
using MMDocConnectDBMethods.Case.Atomic.Retrieval;
using MMDocConnectDBMethods.Case.Complex.Retrieval;
using MMDocConnectDBMethods.Doctor.Atomic.Retrieval;
using MMDocConnectDBMethods.MainData.Atomic.Retrieval;
using MMDocConnectDBMethods.MainData.Complex.Retrieval;
using MMDocConnectDBMethods.Patient.Atomic.Manipulation;
using MMDocConnectDBMethods.Patient.Atomic.Retrieval;
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
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MMDocConnectDocAppServices
{
    public class AftercareDataService : BaseVerification, IAftercareDataService
    {
        IFormatProvider culture = new System.Globalization.CultureInfo("de", true);

        #region RETRIEVAL
        public IEnumerable<Aftercare_Model> GetAllAftercares(ElasticParameterObject sort_parameter, string connectionString, string sessionTicket, out TransactionalInformation transaction)
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

                    var hipData = cls_Get_Hip_Contract_Parameters_on_Tenant.Invoke(dbConnection, dbTransaction, securityTicket).Result.GroupBy(hip => hip.HipIK).ToDictionary(t => t.Key, t => t.ToList());
                    var rangeParameters = GetRangeParameters(dbConnection, dbTransaction, securityTicket, hipData);

                    var doctors = ORM_HEC_Doctor.Query.Search(dbConnection, dbTransaction, new ORM_HEC_Doctor.Query()
                    {
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).ToDictionary(t => t.HEC_DoctorID, t => t.Account_RefID);

                    var aftercares = Get_Aftercares.GetAllAftercaresforPracticeID(data.PracticeID.ToString(), data.AccountInformation.role.Contains("practice"), sort_parameter, securityTicket, rangeParameters).Select(ac =>
                    {
                        var max_days_for_submission_parameter = hipData[ac.hip_ik_number].FirstOrDefault(t => t.ParameterName == "Number of days between surgery and aftercare - Days");
                        var max_days_for_submission = max_days_for_submission_parameter != null ? max_days_for_submission_parameter.ParameterValue : 3650;
                        var max_date_for_submission = ac.treatment_date.AddDays(max_days_for_submission);
                        if (max_date_for_submission.Date >= DateTime.Now.Date)
                        {
                            max_date_for_submission = DateTime.Now;
                        }
                        else if (ac.status == "AC1")
                        {
                            ac.status = "AC3";
                        }

                        ac.max_date_for_submission = max_date_for_submission.ToString("MM.dd.yyyy");

                        ac.is_submit_visible = false;
                        var doctor_id = Guid.Parse(ac.aftercare_doctor_practice_id);
                        var is_doctor = doctors.ContainsKey(doctor_id);
                        if (is_doctor)
                        {
                            var doctor_account_id = doctors[doctor_id];
                            var is_temp = doctor_account_id == Guid.Empty;
                            ac.is_submit_visible = ac.status != "AC4" && is_doctor && !is_temp;
                        }

                        return ac;
                    }).ToList(); ;

                    return aftercares;
                }
                finally
                {
                    dbConnection.Close();
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

            return Enumerable.Empty<Aftercare_Model>();
        }
        public long GetAftercaresCount(ElasticParameterObject parameter, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            transaction = new TransactionalInformation();
            long response = 0;
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

                    var rangeParameters = GetRangeParameters(dbConnection, dbTransaction, securityTicket);

                    response = Get_Aftercares.GetAftercaresCount(parameter, data.AccountInformation.role.Contains("practice"), data.PracticeID.ToString(), "", rangeParameters, securityTicket);
                    dbTransaction.Commit();
                }
                finally
                {
                    dbConnection.Close();
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
        public ACAutocompleteModel GetACDoctorsAndPracticesForAutocomplete(string search_criteria, string sessionTicket, string connectionString, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            transaction = new TransactionalInformation();
            ACAutocompleteModel autocomplete_model = new ACAutocompleteModel();
            var last_used_doctors = new List<AutocompleteModel>();
            var doctors = new List<AutocompleteModel>();
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            try
            {
                var last_used_practices_doctors = Get_Practices_and_Doctors.Get_Last_Used_Doctors_Practices(data.PracticeID, securityTicket);
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
                    doctors = doctors_practices_from_elastic.Select(doc =>
                    {
                        var bsnr_lanr = doc.bsnr_lanr == "" ? "-" : doc.bsnr_lanr;
                        return new AutocompleteModel()
                        {
                            display_name = doc.autocomplete_name + " (" + bsnr_lanr + ")",
                            id = Guid.Parse(doc.id),
                            type = doc.type,
                            secondary_display_name = doc.practice_name_for_doctor
                        };
                    }).ToList();
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

        public Guid GetACIDForCaseID(Guid case_id, string sessionTicket, string connectionString, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            transaction = new TransactionalInformation();
            var securityTicket = VerifySessionToken(sessionTicket);

            try
            {
                var oct_planned_action_type_id = cls_Get_ActionTypeID.Invoke(connectionString, new P_CAS_GATID_1514()
                {
                    action_type_gpmid = EActionType.PlannedAftercare.Value()
                }, securityTicket).Result;

                var aftercare = cls_Get_RelevanActionIDs_for_CaseID_and_ActionTypeID.Invoke(connectionString, new P_CAS_GRAIDsfCIDaATID_1547()
                {
                    CaseID = case_id,
                    ActionTypeID = oct_planned_action_type_id
                }, securityTicket).Result;

                return aftercare.SingleOrDefault().action_id;

            }
            catch (Exception ex)
            {
                var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;
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
        #endregion

        #region MANIPULATION
        public String SubmitAftercare(Guid authorizing_doctor_id, Guid case_id, string date_of_performed_action, string connectionString, string sessionTicket, out TransactionalInformation transaction, DbConnection dbConnection = null, DbTransaction dbTransaction = null)
        {
            var handle_connection = dbConnection == null;
            var handle_transaction = dbTransaction == null;

            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            transaction = new TransactionalInformation();
            var report_url = "";
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

                    CAS_SC_1425 submitted_case_data = null;

                    var parameter = new P_CAS_SC_1425()
                    {
                        case_ids = new Guid[] { case_id },
                        is_treatment = false,
                        practice_id = data.PracticeID,
                        date_of_performed_action = DateTime.Parse(date_of_performed_action, culture, System.Globalization.DateTimeStyles.AssumeLocal),
                        authorizing_doctor_id = authorizing_doctor_id
                    };

                    submitted_case_data = cls_Submit_Case.Invoke(dbConnection, dbTransaction, parameter, securityTicket).Result;

                    if (submitted_case_data != null)
                    {
                        if (!String.IsNullOrEmpty(submitted_case_data.pdf_report_url))
                        {
                            report_url = submitted_case_data.pdf_report_url;
                        }

                        var elasticRefresher = new ElasticRefresher(submitted_case_data.patient_ids, dbConnection, dbTransaction, securityTicket, true);
                        elasticRefresher
                            .UpdateAftercare()
                            .UpdateIvoms()
                            .RebuildElastic();
                    }

                    Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, parameter), data.PracticeName);

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

            return report_url;
        }

        public object MultiEditSubmitAftercare(Guid authorizing_doctor_id, Guid[] case_ids, Guid[] case_ids_to_submit, Guid[] deselected_ids, bool all_selected, string aftercare_performed_date, Guid aftercare_doctor_id, bool should_submit, FilterObject filter, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            transaction = new TransactionalInformation();
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;
            var response = new List<Guid>();
            var reportUrl = "";
            var patient_ids = new List<Guid>();

            try
            {
                var dbConnection = DBSQLSupport.CreateConnection(connectionString);
                DbTransaction dbTransaction = null;

                try
                {
                    dbConnection.Open();
                    dbTransaction = dbConnection.BeginTransaction();

                    var rangeParameters = GetRangeParameters(dbConnection, dbTransaction, securityTicket);

                    ElasticParameterObject filter_by = new ElasticParameterObject();
                    filter_by.date_from = filter.date_from;
                    filter_by.date_to = filter.date_to;
                    filter_by.filter_by.filter_status = filter.filter_by.filter_status;
                    filter_by.filter_by.filter_type = filter.filter_by.filter_type;
                    filter_by.search_params = filter.search_params;

                    var case_id_list = new List<Guid>();
                    if (all_selected || deselected_ids.Length != 0)
                    {
                        if (String.IsNullOrEmpty(aftercare_performed_date))
                        {
                            var aftercares = Get_Aftercares.GetAftercaresFilteredIDs(filter_by, data.PracticeID.ToString(), Array.ConvertAll(deselected_ids, x => x.ToString()), authorizing_doctor_id == aftercare_doctor_id ? false : should_submit, data.AccountInformation.role.Contains("practice"), authorizing_doctor_id.ToString(), "treatment_date", false, rangeParameters, securityTicket);
                            for (var i = 0; i < aftercares.Length; i++)
                            {
                                var aftercare = aftercares[i];
                                case_id_list.Add(Guid.Parse(aftercare.case_id));
                                patient_ids.Add(Guid.Parse(aftercare.patient_id));
                            }
                        }
                        else
                        {
                            var aftercare_date = DateTime.ParseExact(aftercare_performed_date, "dd.MM.yyyy", new System.Globalization.CultureInfo("de", true));
                            var aftercares = Get_Aftercares.GetAftercaresFilteredIDs(filter_by,
                              data.PracticeID.ToString(),
                              Array.ConvertAll(deselected_ids, x => x.ToString()),
                              authorizing_doctor_id == aftercare_doctor_id ? false : should_submit, data.AccountInformation.role.Contains("practice"), authorizing_doctor_id.ToString(),
                              "treatment_date", false, rangeParameters,
                              securityTicket).Where(ac => ac.treatment_date <= aftercare_date).ToArray();

                            for (var i = 0; i < aftercares.Length; i++)
                            {
                                var aftercare = aftercares[i];
                                case_id_list.Add(Guid.Parse(aftercare.case_id));
                                patient_ids.Add(Guid.Parse(aftercare.patient_id));
                            }
                        }
                    }
                    else
                    {
                        var aftercares = Get_Aftercares.GetAftercaresForIDArray(data.PracticeID, data.AccountInformation.role.Contains("practice"), Array.ConvertAll(case_ids, x => x.ToString()), should_submit, "", "treatment_date", false, securityTicket).ToArray();
                        for (var i = 0; i < aftercares.Length; i++)
                        {
                            var aftercare = aftercares[i];
                            case_id_list.Add(Guid.Parse(aftercare.case_id));
                            patient_ids.Add(Guid.Parse(aftercare.patient_id));
                        }
                    }

                    case_ids = case_id_list.ToArray();

                    CAS_SC_1425 submitted_case_data = null;

                    if (case_ids.Any())
                    {
                        if (!should_submit)
                        {
                            response = cls_Save_Case_Multi_Edit.Invoke(dbConnection, dbTransaction, new P_CAS_SCME_1741()
                            {
                                is_treatment = false,
                                case_ids = case_ids,
                                aftercare_doctor_id = aftercare_doctor_id,
                                practice_id = data.PracticeID,
                                aftercare_performed_date = aftercare_performed_date
                            }, securityTicket).Result.ToList();
                        }
                        else
                        {
                            if (case_ids_to_submit.Any())
                            {
                                submitted_case_data = cls_Submit_Case.Invoke(dbConnection, dbTransaction, new P_CAS_SC_1425()
                                {
                                    case_ids = case_ids_to_submit,
                                    is_treatment = false,
                                    practice_id = data.PracticeID,
                                    date_of_performed_action = DateTime.Parse(aftercare_performed_date, culture, System.Globalization.DateTimeStyles.AssumeLocal),
                                    authorizing_doctor_id = authorizing_doctor_id
                                }, securityTicket).Result;
                            }
                        }

                        if (submitted_case_data != null && !String.IsNullOrEmpty(submitted_case_data.pdf_report_url))
                        {
                            reportUrl = submitted_case_data.pdf_report_url;
                        }

                        var elasticRefresher = new ElasticRefresher(patient_ids, dbConnection, dbTransaction, securityTicket, true);
                        elasticRefresher.UpdateAftercare();
                        if (should_submit)
                        {
                            elasticRefresher.UpdateIvoms();
                        }

                        elasticRefresher.RebuildElastic();


                        Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, new AftercareMultiEditSubmitModel()
                        {
                            AftercareDoctorID = aftercare_doctor_id,
                            AftercarePerformedDate = aftercare_performed_date,
                            AuthorizedByID = authorizing_doctor_id,
                            CaseIDs = case_ids,
                            CaseIDsToSubmit = case_ids_to_submit,
                            IsSubmit = should_submit
                        }), data.PracticeName);

                        dbTransaction.Commit();

                        if (reportUrl != "")
                        {
                            return reportUrl;
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

            return response.ToArray();
        }

        private List<AftercareHipParameter> GetRangeParameters(DbConnection dbConnection, DbTransaction dbTransaction, SessionSecurityTicket securityTicket, Dictionary<string, List<MD_GHCPoT_1617>> hipData = null)
        {
            if (hipData == null)
            {
                hipData = cls_Get_Hip_Contract_Parameters_on_Tenant.Invoke(dbConnection, dbTransaction, securityTicket).Result.GroupBy(hip => hip.HipIK).ToDictionary(t => t.Key, t => t.ToList());
            }

            var rangeParameters = hipData.Select(t =>
            {
                var result = new AftercareHipParameter();
                if (t.Value.Any(x => x.ParameterValue != double.MaxValue && x.ParameterValue < 20000000 && x.ParameterValue != 0))
                {
                    try
                    {
                        var daysBetweenSurgeryAndAftercare = Convert.ToInt32(t.Value.First(x => x.ParameterName == "Number of days between surgery and aftercare - Days").ParameterValue);
                        var daysToSubmitAftercare = Convert.ToInt32(t.Value.First(x => x.ParameterName == "Number of days between treatment and settlement claim - Days").ParameterValue);
                        result.MinimumTreatmentDate = DateTime.Now.AddDays(-(daysToSubmitAftercare + daysBetweenSurgeryAndAftercare)).ToString("yyyy-MM-dd");
                        result.OverdueDate = DateTime.Now.AddDays(-daysBetweenSurgeryAndAftercare).ToString("yyyy-MM-dd");
                    }
                    catch { }
                }

                result.HipIk = t.Key;

                return result;
            }).ToList();

            return rangeParameters;
        }

        public MultiSubmitObject[] InitiateAftercareMultiSubmit(Guid[] case_ids, Guid[] deselected_ids, bool all_selected, FilterObject filter, string sort_by, bool isAsc, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            transaction = new TransactionalInformation();
            MultiSubmitObject[] response = new MultiSubmitObject[] { };
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

                    var rangeParameters = GetRangeParameters(dbConnection, dbTransaction, securityTicket);

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
                        filter_by.filter_by.localization = filter.filter_by.localization;

                        response = Get_Aftercares.GetAftercaresFilteredIDs(filter_by, data.PracticeID.ToString(), Array.ConvertAll(deselected_ids, x => x.ToString()), false, data.AccountInformation.role.Contains("practice"), "", sort_by, isAsc, rangeParameters, securityTicket).GroupBy(cas => cas.aftercare_doctor_practice_id).Select(cas => new MultiSubmitObject() { id = Guid.Parse(cas.First().aftercare_doctor_practice_id), count = cas.Count() }).ToArray();
                    }
                    else
                    {
                        response = Get_Aftercares.GetAftercaresForIDArray(data.PracticeID, data.AccountInformation.role.Contains("practice"), Array.ConvertAll(case_ids, x => x.ToString()), false, "", sort_by, isAsc, securityTicket).GroupBy(cas => cas.aftercare_doctor_practice_id).Select(cas => new MultiSubmitObject() { id = Guid.Parse(cas.First().aftercare_doctor_practice_id), count = cas.Count() }).ToArray();
                    }

                    response = response.Where(r => cls_Get_Doctor_Details_for_DoctorID.Invoke(connectionString, new P_DO_GDDfDID_0823() { DoctorID = r.id }, securityTicket).Result.Length != 0).ToArray();
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

            return response;
        }
        #endregion

        #region VALIDATION
        public Guid[] ValidateAftercareDateForMultiEdit(Guid[] case_ids, Guid[] deselected_ids, string aftercare_performed_date, bool all_selected, bool should_submit, FilterObject filter, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            transaction = new TransactionalInformation();
            List<Guid> response = new List<Guid>();
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

                    var rangeParameters = GetRangeParameters(dbConnection, dbTransaction, securityTicket);

                    ElasticParameterObject filter_by = new ElasticParameterObject();
                    filter_by.date_from = filter.date_from;
                    filter_by.date_to = filter.date_to;
                    filter_by.filter_by.filter_status = filter.filter_by.filter_status;
                    filter_by.filter_by.filter_type = filter.filter_by.filter_type;
                    filter_by.filter_by.filter_current = filter.filter_by.filter_current;
                    filter_by.search_params = filter.search_params;

                    Aftercare_Model[] aftercares = null;
                    if (all_selected || deselected_ids.Length != 0)
                    {
                        aftercares = Get_Aftercares.GetAftercaresFilteredIDs(filter_by, data.PracticeID.ToString(), Array.ConvertAll(deselected_ids, x => x.ToString()), should_submit, data.AccountInformation.role.Contains("practice"), "", "treatment_date", false, rangeParameters, securityTicket);
                    }
                    else
                    {
                        aftercares = Get_Aftercares.GetAftercaresForIDArray(data.PracticeID, data.AccountInformation.role.Contains("practice"), Array.ConvertAll(case_ids, x => x.ToString()), should_submit, "", "treatment_date", false, securityTicket).ToArray();
                    }

                    foreach (var aftercare in aftercares)
                    {
                        var aftercare_date = DateTime.ParseExact(aftercare_performed_date, "dd.MM.yyyy", culture);

                        if (aftercare_date >= aftercare.treatment_date && aftercare_date <= DateTime.Now)
                        {
                            response.Add(Guid.Parse(aftercare.id));
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

            return response.ToArray();
        }

        public MulitiSubmitValidation CheckIfAlreadyExistAftercare(IEnumerable<Guid> case_ids, string aftercare_performed_date, string connectionString, string sessionTicket, out TransactionalInformation transaction)
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
                if (!case_ids.Any())
                {
                    return returnObject;
                }

                var culture = new System.Globalization.CultureInfo("de", true);
                var aftercareDate = DateTime.Parse(aftercare_performed_date, culture, System.Globalization.DateTimeStyles.AssumeLocal);

                var aftercarePlannedActionTypeID = cls_Get_ActionTypeID.Invoke(dbConnection, dbTransaction, new P_CAS_GATID_1514()
                {
                    action_type_gpmid = EActionType.PlannedAftercare.Value()
                }, securityTicket).Result;

                var aftercarePerformedActionTypeID = cls_Get_ActionTypeID.Invoke(dbConnection, dbTransaction, new P_CAS_GATID_1514()
                {
                    action_type_gpmid = EActionType.PerformedAftercare.Value()
                }, securityTicket).Result;

                var excludeFSStatuses = new List<int>() { 8, 11, 17 };
                var duplicateCases = new List<Guid>();

                var allAftercaresForSubmit = cls_Get_Aftercare_Planned_Action_with_Localization_for_CaseIDs.Invoke(dbConnection, dbTransaction, new P_CAS_GAPAwLfCIDs_1855
                {
                    ActionTypeID = aftercarePlannedActionTypeID,
                    CaseIDs = case_ids.ToArray()
                }, securityTicket).Result;


                var allSubmittedCasesForPatients = cls_Get_CaseIDs_for_Patient_and_Localization.Invoke(dbConnection, dbTransaction, new P_CAS_GCIDsfPaL_1307
                {
                    PatientIDs = allAftercaresForSubmit.Select(x => x.PatientID).Distinct().ToArray(),
                    ActionTypeID = aftercarePlannedActionTypeID
                }, securityTicket).Result;

                var numberOfInvalidCases = 0;
                var validAftercares = new List<CAS_GAPAwLfCIDs_1855>();

                if (allSubmittedCasesForPatients.Any())
                {
                    foreach (var aftercare in allAftercaresForSubmit)
                    {
                        var alreadyExistSubmitedAftercare = false;
                        var allSubmitedAftercaresForDate = allSubmittedCasesForPatients.Where(x => x.Date == aftercareDate && x.LocalizationCode == aftercare.LocalizationCode && x.PatientID == aftercare.PatientID && x.PlannedActionID != aftercare.PlannedActionID);

                        if (allSubmitedAftercaresForDate.Any())
                        {
                            var billCodes = cls_Get_Case_TransmitionCode_for_CaseIDs_and_Type.Invoke(dbConnection, dbTransaction, new P_CAS_GCTCfCIDsaT_1254
                            {
                                CaseIDs = allSubmitedAftercaresForDate.Select(x => x.CaseID).ToArray(),
                                StatusKey = "aftercare"
                            }, securityTicket).Result;

                            alreadyExistSubmitedAftercare = billCodes.Any(x => !excludeFSStatuses.Contains(x.TransmitionCode));
                        }
                        if (alreadyExistSubmitedAftercare)
                        {
                            numberOfInvalidCases++;
                        }
                        else
                        {
                            var alreadyExistInValidList = validAftercares.Any(a => a.LocalizationCode == aftercare.LocalizationCode && a.PatientID == aftercare.PatientID && a.CaseID != aftercare.CaseID);
                            if (!alreadyExistInValidList)
                            {
                                validAftercares.Add(aftercare);
                            }
                        }
                    }
                }

                return new MulitiSubmitValidation()
                {
                    number_of_all_cases = case_ids.Count(),
                    valid_case_ids = allSubmittedCasesForPatients.Any() ? validAftercares.Select(x => x.CaseID).ToList() : case_ids.ToList(),
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

            return returnObject;
        }
        #endregion
    }
}
