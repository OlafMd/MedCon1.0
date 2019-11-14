using CL1_BIL;
using CL1_CMN_CTR;
using CL1_HEC;
using CL1_HEC_ACT;
using CL1_HEC_CAS;
using CL1_HEC_CRT;
using CL1_HEC_DIA;
using CSV2Core.SessionSecurity;
using CSV2Core_MySQL.Support;
using DLCore_TokenVerification;
using LogUtils;
using MMDocConnectDBMethods.Case.Atomic.Manipulation;
using MMDocConnectDBMethods.Case.Atomic.Retrieval;
using MMDocConnectDBMethods.Case.Complex.Manipulation;
using MMDocConnectDBMethods.Case.Complex.Retrieval;
using MMDocConnectDBMethods.Doctor.Atomic.Retrieval;
using MMDocConnectDBMethods.Doctor.Model;
using MMDocConnectDBMethods.MainData.Atomic.Retrieval;
using MMDocConnectDBMethods.MainData.Complex.Retrieval;
using MMDocConnectDBMethods.Patient.Atomic.Retrieval;
using MMDocConnectDocApp;
using MMDocConnectDocAppInterfaces;
using MMDocConnectDocAppModels;
using MMDocConnectElasticSearchMethods.Case.Retrieval;
using MMDocConnectElasticSearchMethods.Models;
using MMDocConnectElasticSearchMethods.Oct.Entity;
using MMDocConnectElasticSearchMethods.Patient.Manipulation;
using MMDocConnectUtils;
using SharedServiceUtils;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;

namespace MMDocConnectDocAppServices
{
    public class OctService : BaseVerification, IOctService
    {
        #region Retrieval

        public long GetOctCount(ElasticParameterObject parameter, string connectionString, string sessionTicket, out TransactionalInformation transaction)
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
                var dbConnection = DBSQLSupport.CreateConnection(connectionString);
                DbTransaction dbTransaction = null;

                try
                {
                    dbConnection.Open();
                    dbTransaction = dbConnection.BeginTransaction();

                    var hip_name = !String.IsNullOrEmpty(parameter.hip_name) ? parameter.hip_name.ToLower() : null;
                    var search_params = !String.IsNullOrEmpty(parameter.search_params) ? parameter.search_params.ToLower() : null;

                    parameter.hip_name = hip_name;
                    parameter.search_params = search_params;

                    var rangeParameters = GetRangeParameters(dbConnection, dbTransaction, securityTicket);
                    result = Retrieve_Octs.GetOctCount(parameter, data.PracticeID, securityTicket.TenantID.ToString(), rangeParameters);

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

            return result;
        }

        public Guid GetOctIDForCaseID(Guid caseID, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var request = HttpContext.Current.Request;
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(request);

            transaction = new TransactionalInformation();
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;
            var result = Guid.Empty;

            try
            {
                var dbConnection = DBSQLSupport.CreateConnection(connectionString);
                DbTransaction dbTransaction = null;

                try
                {
                    dbConnection.Open();
                    dbTransaction = dbConnection.BeginTransaction();

                    var allOCTs = cls_Get_OctID_for_CaseID.Invoke(connectionString, new P_CAS_GOIDfCID_1552
                    {
                        CaseID = caseID
                    }, securityTicket).Result;

                    result = allOCTs.OrderByDescending(x => x.Creation_Timestamp).First().PlannedAction_RefID;

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
                result = Guid.Empty;
            }

            return result;
        }

        public IEnumerable<Oct_Model> GetOcts(ElasticParameterObject sort_parameter, string connectionString, string sessionTicket, out TransactionalInformation transaction)
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

                    var all_oct_contract_parameters = cls_Get_Oct_Contract_Parameters.Invoke(dbConnection, dbTransaction, new P_MD_GOctCP_1756() { GposCatalogID = EGposType.Oct.Value() }, securityTicket).Result
                        .GroupBy(t => t.Contract_RefID).ToDictionary(t => t.Key, t => t);

                    var contract_id = all_oct_contract_parameters.First().Key;
                    var treatment_year_length_ctr_parameter = all_oct_contract_parameters[contract_id].SingleOrDefault(t => t.ParameterName == EContractParameter.PreexaminationsDays.Value());
                    var max_octs_per_treatment_year_ctr_parameter = all_oct_contract_parameters[contract_id].SingleOrDefault(x => x.ParameterName == EContractParameter.MaxNumberOfOcts.Value());
                    var max_octs_per_treatment_year = max_octs_per_treatment_year_ctr_parameter != null ? max_octs_per_treatment_year_ctr_parameter.IfNumericValue_Value : Int32.MaxValue;
                    var treatment_year_length = treatment_year_length_ctr_parameter != null ? treatment_year_length_ctr_parameter.IfNumericValue_Value : 365;
                    var max_days_before_submit_parameter = all_oct_contract_parameters[contract_id].SingleOrDefault(t => t.ParameterName == EContractParameter.NumberOfDaysBetweenTreatmentAndSettlement.Value());
                    var max_days_to_submit_oct = max_days_before_submit_parameter != null && max_days_before_submit_parameter.IfNumericValue_Value < 2000000 ? max_days_before_submit_parameter.IfNumericValue_Value : 0;

                    var rangeParameters = GetRangeParameters(dbConnection, dbTransaction, securityTicket);

                    var octs = Retrieve_Octs.GetAllOcts(data.PracticeID, sort_parameter, securityTicket, rangeParameters);
                    if (octs.Any())
                    {
                        var insurance_to_broker_contracts_cache = ORM_HEC_CRT_InsuranceToBrokerContract.Query.Search(dbConnection, dbTransaction, new ORM_HEC_CRT_InsuranceToBrokerContract.Query()
                        {
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false
                        }).ToDictionary(t => t.HEC_CRT_InsuranceToBrokerContractID, t => t.Ext_CMN_CTR_Contract_RefID);

                        var all_patient_ids = octs.Select(x => x.patient_id).Distinct().ToArray();

                        var all_consents = cls_Get_Patient_Consents_for_PatientIDs.Invoke(dbConnection, dbTransaction, new P_PA_GPCfPIDs_1358()
                        {
                            PatientIDs = all_patient_ids
                        }, securityTicket).Result.GroupBy(t => t.Patient_RefID).ToDictionary(t => t.Key, t => t.OrderByDescending(x => x.ValidFrom).ToList());

                        var op_dates_with_localization = cls_Get_PerformedOpDates_with_localization_for_PatientIDs.Invoke(dbConnection, dbTransaction, new P_CAS_GPODwLfPIDs_1530
                        {
                            PatientIDs = all_patient_ids
                        }, securityTicket).Result.GroupBy(x => x.patient_id).ToDictionary(t => t.Key, t => t.ToList());


                        octs = octs.Select(t =>
                        {
                            if (all_consents.ContainsKey(t.patient_id))
                            {
                                var last_potential_consent = all_consents[t.patient_id].FirstOrDefault(x => x.ValidFrom.Date <= t.oct_date);
                                if (last_potential_consent == null)
                                {
                                    last_potential_consent = all_consents[t.patient_id].First();
                                }
                                contract_id = insurance_to_broker_contracts_cache[last_potential_consent.InsuranceToBrokerContract_RefID];

                                if (all_oct_contract_parameters.ContainsKey(contract_id))
                                {
                                    treatment_year_length_ctr_parameter = all_oct_contract_parameters[contract_id].SingleOrDefault(x => x.ParameterName == EContractParameter.PreexaminationsDays.Value());
                                    treatment_year_length = treatment_year_length_ctr_parameter != null ? treatment_year_length_ctr_parameter.IfNumericValue_Value : 365;
                                    max_octs_per_treatment_year_ctr_parameter = all_oct_contract_parameters[contract_id].SingleOrDefault(x => x.ParameterName == EContractParameter.MaxNumberOfOcts.Value());
                                    max_octs_per_treatment_year = max_octs_per_treatment_year_ctr_parameter != null ? max_octs_per_treatment_year_ctr_parameter.IfNumericValue_Value : double.MaxValue;
                                    max_days_before_submit_parameter = all_oct_contract_parameters[contract_id].SingleOrDefault(x => x.ParameterName == EContractParameter.NumberOfDaysBetweenTreatmentAndSettlement.Value());
                                    max_days_to_submit_oct = max_days_before_submit_parameter != null && max_days_before_submit_parameter.IfNumericValue_Value < 2000000 ? max_days_before_submit_parameter.IfNumericValue_Value : 0;
                                }

                                if (t.status != "OCT4" && t.status != "OCT6")
                                {
                                    var op_dates = op_dates_with_localization.ContainsKey(t.patient_id) ? op_dates_with_localization[t.patient_id] : null;
                                    if (op_dates != null && op_dates.Any(x => x.localization_code == t.localization))
                                    {
                                        var last_op_date = op_dates.First(x => x.localization_code == t.localization);
                                        var overdue_start_date = last_op_date.treatment_date.AddDays(treatment_year_length);
                                        var overdue_end_date = overdue_start_date.AddDays(max_days_to_submit_oct);

                                        if (t.treatment_year_octs < max_octs_per_treatment_year && overdue_start_date <= DateTime.Now.Date && DateTime.Now.Date <= overdue_end_date)
                                        {
                                            t.status = "OCT3";
                                        }
                                        else if (t.treatment_year_octs == max_octs_per_treatment_year && t.treatment_year_date >= sort_parameter.min_treatment_year_start_date)
                                        {
                                            t.status = "OCT5";
                                        }
                                    }
                                    else
                                    {
                                        var overdue_start_date = t.treatment_date.AddDays(treatment_year_length);
                                        var overdue_end_date = overdue_start_date.AddDays(max_days_to_submit_oct);
                                        if (t.treatment_year_octs < max_octs_per_treatment_year && overdue_start_date <= DateTime.Now.Date && DateTime.Now.Date <= overdue_end_date)
                                        {
                                            t.status = "OCT3";
                                        }
                                        else if (t.treatment_year_octs == max_octs_per_treatment_year && t.treatment_year_date >= sort_parameter.min_treatment_year_start_date)
                                        {
                                            t.status = "OCT5";
                                        }
                                    }
                                }

                                switch (sort_parameter.sort_by)
                                {
                                    case "patient_name": t.group_name = t.patient_name.Substring(0, 1).ToUpper(); break;
                                    case "diagnose": t.group_name = string.IsNullOrEmpty(t.diagnose) ? "-" : t.diagnose; break;
                                    case "localization": t.group_name = t.localization; break;
                                    case "treatment_doctor_name": t.group_name = t.treatment_doctor_name; break;
                                    default:
                                        var date = t.oct_date == DateTime.MinValue ? t.treatment_date : t.oct_date;
                                        t.group_name = date.ToString("MMMM yyyy", new System.Globalization.CultureInfo("de", true)).ToUpper();
                                        break;
                                }
                            }
                            return t;
                        }).ToList();

                        dbTransaction.Commit();
                        return octs;
                    }

                    return Enumerable.Empty<Oct_Model>();
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

            return Enumerable.Empty<Oct_Model>();
        }

        public object CheckIsSameOctDoctor(Guid oct_doctor_id, Guid patient_id, bool is_left_eye, string treatment_date, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var request = HttpContext.Current.Request;
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(request);

            transaction = new TransactionalInformation();
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            try
            {
                if (oct_doctor_id == Guid.Empty)
                {
                    return new
                    {
                        is_same = true
                    };
                }

                var op_date = DateTime.ParseExact(treatment_date, "dd.MM.yyyy", new System.Globalization.CultureInfo("de", true));

                var dbConnection = DBSQLSupport.CreateConnection(connectionString);
                DbTransaction dbTransaction = null;
                try
                {
                    dbConnection.Open();
                    dbTransaction = dbConnection.BeginTransaction();

                    var localization_code = is_left_eye ? "L" : "R";

                    var treatment_year_start_date = cls_Get_TreatmentYear.Invoke(dbConnection, dbTransaction, new P_CAS_GTY_1125()
                    {
                        Date = op_date,
                        LocalizationCode = localization_code,
                        PatientID = patient_id
                    }, securityTicket).Result;

                    var oct_gpos_ids = cls_Get_GposIDs_for_GposType.Invoke(dbConnection, dbTransaction, new P_MD_GGpoIDsfGposT_1145() { GposType = EGposType.Oct.Value() }, securityTicket).Result.Select(t => t.GposID).ToArray();

                    var patient_consents = cls_Get_Patient_Consents_before_Date_and_GposIDs.Invoke(dbConnection, dbTransaction, new P_PA_GPCbDaGposIDs_1154()
                    {
                        Date = op_date,
                        GposIDs = oct_gpos_ids,
                        PatientID = patient_id
                    }, securityTicket).Result;

                    if (patient_consents.Any())
                    {
                        var patient_consent = patient_consents.First();

                        var contract_parameters = ORM_CMN_CTR_Contract_Parameter.Query.Search(dbConnection, dbTransaction, new ORM_CMN_CTR_Contract_Parameter.Query()
                        {
                            Contract_RefID = patient_consent.contract_id,
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false
                        });

                        var oct_planned_action_type_id = cls_Get_ActionTypeID.Invoke(dbConnection, dbTransaction, new P_CAS_GATID_1514()
                        {
                            action_type_gpmid = EActionType.PlannedOct.Value()
                        }, securityTicket).Result;

                        var current_oct_doctor = cls_Get_NonSubmittedOct_DoctorID_for_PatientID_and_LocalizationID.Invoke(dbConnection, dbTransaction, new P_CAS_GNSOctDIDfPIDaLC_1817()
                        {
                            LocalizationCode = localization_code,
                            PatientID = patient_id,
                            OctActionTypeID = oct_planned_action_type_id
                        }, securityTicket).Result;

                        var max_octs = contract_parameters.SingleOrDefault(t => t.ParameterName == EContractParameter.MaxNumberOfOcts.Value());
                        var treatment_year_length_ctr_parameter = contract_parameters.SingleOrDefault(t => t.ParameterName == EContractParameter.PreexaminationsDays.Value());
                        var treatment_year_length = treatment_year_length_ctr_parameter != null ? treatment_year_length_ctr_parameter.IfNumericValue_Value : 365;
                        var treatment_year_end_date = treatment_year_start_date.AddDays(treatment_year_length - 1);
                        var oct_performed_action_type_id = cls_Get_ActionTypeID.Invoke(dbConnection, dbTransaction, new P_CAS_GATID_1514() { action_type_gpmid = EActionType.PerformedOct.Value() }, securityTicket).Result;
                        var current_oct_dates = cls_Get_PerformedActionsDates_for_PatientID_and_LocalizationCode_in_Timespan.Invoke(dbConnection, dbTransaction, new P_CAS_GPADfPIDaLCiTs_1130()
                        {
                            ActionTypeID = oct_performed_action_type_id,
                            DateFrom = treatment_year_start_date,
                            DateTo = treatment_year_end_date,
                            LocalizationCode = localization_code,
                            PatientID = patient_id
                        }, securityTicket).Result.OrderBy(t => t.creation_timestamp).ToList();

                        var current_oct_count = 0;
                        var latest_oct_date = DateTime.MinValue;
                        if (current_oct_dates.Any())
                        {
                            var oct_fs_statuses = cls_Get_OctFsStatuses_for_PatientID_in_TimeSpan.Invoke(dbConnection, dbTransaction, new P_CAS_GOctFSSfPIDiTS_1103s()
                            {
                                DateFrom = treatment_year_start_date,
                                DateTo = treatment_year_end_date,
                                LocalizationCode = localization_code,
                                PatientID = patient_id
                            }, securityTicket).Result;

                            var cancelled_statuses = new int[] { 8, 11, 17 };
                            for (var i = 0; i < current_oct_dates.Count; i++)
                            {
                                if (i >= oct_fs_statuses.Length)
                                {
                                    throw new Exception(String.Format("OCT FS status and oct dates count mismatch. Patient id: {0}, localization: {1}, treatment year start date: {2}", patient_id, localization_code, treatment_year_start_date.ToString("yyyy-MM-dd")));
                                }
                                else if (!cancelled_statuses.Any(t => t == oct_fs_statuses[i].fs_status))
                                {
                                    var oct_date = current_oct_dates[i].treatment_date;
                                    if (latest_oct_date < oct_date)
                                    {
                                        latest_oct_date = oct_date;
                                    }

                                    current_oct_count++;
                                }
                            }
                        }

                        if (current_oct_doctor != null && current_oct_doctor.OctDoctorID != oct_doctor_id)
                        {
                            var new_oct_doctor_practice = cls_Get_PracticeID_for_DoctorID.Invoke(dbConnection, dbTransaction, new P_DO_GPIDfDID_1353() { DoctorID = oct_doctor_id }, securityTicket).Result.SingleOrDefault();
                            var old_oct_doctor_practice = cls_Get_PracticeID_for_DoctorID.Invoke(dbConnection, dbTransaction, new P_DO_GPIDfDID_1353() { DoctorID = current_oct_doctor.OctDoctorID }, securityTicket).Result.Single();
                            if (new_oct_doctor_practice == null)
                            {
                                throw new Exception(String.Format("Practice not found for new oct doctor: {0}", oct_doctor_id));
                            }

                            if (new_oct_doctor_practice.HEC_MedicalPractiseID != old_oct_doctor_practice.HEC_MedicalPractiseID)
                            {
                                return new
                                {
                                    is_same = false,
                                    name = current_oct_doctor.OctDoctorName,
                                    max_octs = max_octs != null ? max_octs.IfNumericValue_Value.ToString() : "∞",
                                    current_octs = current_oct_count,
                                    latest_oct_date = latest_oct_date != DateTime.MinValue ? latest_oct_date.ToString("dd.MM.yyyy") : "-"
                                };
                            }
                        }
                    }

                    dbTransaction.Commit();
                    return new { is_same = true };
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

            return new
            {
                is_same = true
            };
        }

        public string GetFS6CommentForDoctor(Guid case_id, Guid oct_id, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var request = HttpContext.Current.Request;
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(request);

            transaction = new TransactionalInformation();
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;
            var result = String.Empty;

            try
            {
                var dbConnection = DBSQLSupport.CreateConnection(connectionString);
                DbTransaction dbTransaction = null;

                try
                {
                    dbConnection.Open();
                    dbTransaction = dbConnection.BeginTransaction();

                    var relevant_action = ORM_HEC_CAS_Case_RelevantPlannedAction.Query.Search(dbConnection, dbTransaction, new ORM_HEC_CAS_Case_RelevantPlannedAction.Query()
                    {
                        PlannedAction_RefID = oct_id,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).Single();
                    var case_to_submit = new ORM_HEC_CAS_Case();
                    case_to_submit.Load(dbConnection, dbTransaction, relevant_action.Case_RefID);

                    var oct_planned_action_type_id = cls_Get_ActionTypeID.Invoke(dbConnection, dbTransaction, new P_CAS_GATID_1514() { action_type_gpmid = EActionType.PlannedOct.Value() }, securityTicket).Result;

                    var relevant_actions = cls_Get_PlannedActionIDs_for_PatientID_and_ActionTypeID.Invoke(dbConnection, dbTransaction, new P_CAS_GPAIDsfPIDaATID_1705()
                    {
                        ActionTypeID = oct_planned_action_type_id,
                        PatientID = case_to_submit.Patient_RefID
                    }, securityTicket).Result.Where(t => t.performed).ToList();

                    var case_bill_positions = cls_Get_BillPositionIDs_for_PatientID_and_GposType.Invoke(dbConnection, dbTransaction, new P_CAS_GBPIDsfPIDaGposT_1709()
                    {
                        PatientID = case_to_submit.Patient_RefID,
                        GposType = EGposType.Oct.Value()
                    }, securityTicket).Result.Where(t => t.status_id != Guid.Empty).ToList();

                    for (var i = 0; i < relevant_actions.Count; i++)
                    {
                        if (relevant_actions[i].action_id == oct_id)
                        {
                            var bill_position = case_bill_positions[i];

                            var fs_status = ORM_BIL_BillPosition_TransmitionStatus.Query.Search(dbConnection, dbTransaction, new ORM_BIL_BillPosition_TransmitionStatus.Query()
                            {
                                BillPosition_RefID = bill_position.bill_position_id,
                                IsActive = true,
                                TransmitionCode = 6,
                                TransmitionStatusKey = "oct",
                                Tenant_RefID = securityTicket.TenantID,
                                IsDeleted = false
                            }).SingleOrDefault();

                            if (fs_status != null)
                            {
                                result = fs_status.PrimaryComment;
                            }

                            break;
                        }
                    }

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

            return result;
        }

        #endregion Retrieval

        #region Manipulation

        public void MultiEditOct(IEnumerable<Guid> oct_ids, string oct_date, Guid oct_doctor_id, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var request = HttpContext.Current.Request;
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(request);

            transaction = new TransactionalInformation();
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;
            var patient_ids = new List<Guid>();
            try
            {
                var dbConnection = DBSQLSupport.CreateConnection(connectionString);
                DbTransaction dbTransaction = null;

                try
                {
                    dbConnection.Open();
                    dbTransaction = dbConnection.BeginTransaction();

                    var octs = new List<Oct_Model>();
                    var patient_details_list = new List<PatientDetailViewModel>();

                    foreach (var oct_id in oct_ids)
                    {
                        var doctor = cls_Get_Doctor_BasicInformation_for_DoctorID.Invoke(dbConnection, dbTransaction, new P_DO_GDBIfDID_1034() { DoctorID = oct_doctor_id }, securityTicket).Result;
                        var oct_planned_action = ORM_HEC_ACT_PlannedAction.Query.Search(dbConnection, dbTransaction, new ORM_HEC_ACT_PlannedAction.Query() { HEC_ACT_PlannedActionID = oct_id, Tenant_RefID = securityTicket.TenantID, IsDeleted = false }).Single();
                        if (doctor != null)
                        {
                            oct_planned_action.ToBePerformedBy_BusinessParticipant_RefID = doctor.bpt_id;
                        }

                        if (!String.IsNullOrEmpty(oct_date))
                        {
                            oct_planned_action.PlannedFor_Date = DateTime.ParseExact(oct_date, "dd.MM.yyyy", new System.Globalization.CultureInfo("de", true));
                        }
                        oct_planned_action.Modification_Timestamp = DateTime.Now;

                        oct_planned_action.Save(dbConnection, dbTransaction);

                        patient_ids.Add(oct_planned_action.Patient_RefID);
                    }

                    var elasticRefresher = new ElasticRefresher(patient_ids.Distinct(), dbConnection, dbTransaction, securityTicket, true);
                    elasticRefresher
                        .UpdateOct()
                        .RebuildElastic();

                    dbTransaction.Commit();

                    Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, new
                    {
                        oct_ids = oct_ids,
                        oct_date = oct_date,
                        oct_doctor_id = oct_doctor_id
                    }), data.PracticeName);
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

        public string SubmitOct(IEnumerable<Guid> oct_ids, string oct_date, Guid authorizing_doctor_id, bool is_resubmit, string connectionString, string sessionTicket, out TransactionalInformation transaction, bool documentation_only = false, DbConnection dbConnection = null, DbTransaction dbTransaction = null)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = HttpContext.Current != null ? Util.GetIPInfo(HttpContext.Current.Request) : new IPInfo() { address = "none", agent = "none" };

            transaction = new TransactionalInformation();
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;
            string response = null;

            try
            {
                var handle_connection = dbConnection == null;
                var handle_transaction = dbTransaction == null;
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

                    var fs_status_prefix = "FS";
                    var fs_status_code = documentation_only ? 13 : 1;
                    var fs_status = String.Format("{0}{1}", fs_status_prefix, fs_status_code);
                    var elastic_index = securityTicket.TenantID.ToString();
                    var shouldDownloadReportProperty = cls_Get_Practice_PropertyValue_for_PropertyName_and_PracticeID.Invoke(dbConnection, dbTransaction, new P_DO_GPPVfPNaPID_0916() { PracticeID = data.PracticeID, PropertyName = "Download Report Upon Submission" }, securityTicket).Result;
                    var pdf_report_data = new Dictionary<Guid, List<Guid>>();

                    var patient_ids = new List<Guid>();

                    foreach (var oct_id in oct_ids)
                    {
                        #region Data

                        var oct_datetime = DateTime.ParseExact(oct_date, "dd.MM.yyyy", new System.Globalization.CultureInfo("de", true));
                        var case_id = ORM_HEC_CAS_Case_RelevantPlannedAction.Query.Search(dbConnection, dbTransaction, new ORM_HEC_CAS_Case_RelevantPlannedAction.Query() { PlannedAction_RefID = oct_id }).Single().Case_RefID;
                        var case_details = cls_Get_Case_Details_for_CaseID.Invoke(dbConnection, dbTransaction, new P_CAS_GCDfCID_1435() { CaseID = case_id }, securityTicket).Result;
                        var diagnose_details = cls_Get_Diagnose_Details_for_DiagnoseID.Invoke(dbConnection, dbTransaction, new P_CAS_GDDfDID_1608() { DiagnoseID = case_details.diagnose_id }, securityTicket).Result;
                        var oct_doctor_details = cls_Get_Doctor_Details_for_DoctorID.Invoke(dbConnection, dbTransaction, new P_DO_GDDfDID_0823() { DoctorID = authorizing_doctor_id }, securityTicket).Result.First();
                        var authorizing_bpt_id = oct_doctor_details.doctor_bpt_id;
                        var oct_practice_details = cls_Get_Practice_Details_for_PracticeID.Invoke(dbConnection, dbTransaction, new P_DO_GPDfPID_1432() { PracticeID = oct_doctor_details.practice_id }, securityTicket).Result.First();
                        var patient_details = cls_Get_Patient_Details_for_PatientID.Invoke(dbConnection, dbTransaction, new P_P_PA_GPDfPID_1124() { PatientID = case_details.patient_id }, securityTicket).Result;
                        var drug = cls_Get_Drug_Details_for_DrugID.Invoke(dbConnection, dbTransaction, new P_CAS_GDDfDID_1614() { DrugID = case_details.drug_id }, securityTicket).Result;
                        var is_management_fee_waived = cls_Get_Practice_PropertyValue_for_PropertyName_and_PracticeID.Invoke(dbConnection, dbTransaction, new P_DO_GPPVfPNaPID_0916() { PracticeID = oct_doctor_details.practice_id, PropertyName = "Waive Service Fee" }, securityTicket).Result.BooleanValue;
                        var oct_planned_action_type_id = cls_Get_ActionTypeID.Invoke(dbConnection, dbTransaction, new P_CAS_GATID_1514() { action_type_gpmid = EActionType.PlannedOct.Value() }, securityTicket).Result;

                        var oct_gpos_ids = cls_Get_GposIDs_for_GposType.Invoke(dbConnection, dbTransaction, new P_MD_GGpoIDsfGposT_1145() { GposType = EGposType.Oct.Value() }, securityTicket).Result;

                        var last_potential_consent = cls_Get_Patient_Consents_before_Date_and_GposIDs.Invoke(dbConnection, dbTransaction, new P_PA_GPCbDaGposIDs_1154()
                        {
                            Date = oct_datetime,
                            GposIDs = oct_gpos_ids.Select(t => t.GposID).ToArray(),
                            PatientID = case_details.patient_id
                        }, securityTicket).Result.FirstOrDefault(t => t.consent_valid_from.Date <= oct_datetime);

                        var all_contract_parameters = ORM_CMN_CTR_Contract_Parameter.Query.Search(dbConnection, dbTransaction, new ORM_CMN_CTR_Contract_Parameter.Query()
                        {
                            Contract_RefID = last_potential_consent.contract_id,
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false
                        });

                        var useSettlementYear = all_contract_parameters.Any(t => t.ParameterName == EContractParameter.UseSettlementYear.Value());


                        var treatment_year_length = cls_Get_TreatmentYearLength.Invoke(dbConnection, dbTransaction, new P_CAS_GTYL_1317() { Date = oct_datetime, PatientID = case_details.patient_id }, securityTicket).Result;
                        var current_treatment_year_start_date = cls_Get_TreatmentYear.Invoke(dbConnection, dbTransaction, new P_CAS_GTY_1125()
                        {
                            Date = oct_datetime,
                            LocalizationCode = case_details.localization,
                            PatientID = case_details.patient_id,
                            //DoctorID = case_details.oct_doctor_id
                        }, securityTicket).Result;
                        var current_treatment_year_end_date = current_treatment_year_start_date.AddDays(treatment_year_length - 1);

                        var opAndOctDates = cls_Get_Oct_and_OP_Dates_for_PatientID_and_Localization.Invoke(dbConnection, dbTransaction, new P_CAS_GOctaOpDfPIDaL_1527()
                        {
                            Localization = case_details.localization,
                            PatientID = case_details.patient_id
                        }, securityTicket).Result;

                        var performedOpExists = opAndOctDates.Any(t =>
                        {
                            var isOpAndPerformed = t.IsOp && t.IsOpPerformed;
                            var isOpDateInRequiredTimespan = t.TreatmentDate.Date <= oct_datetime && t.TreatmentDate.Date >= oct_datetime.AddDays(-treatment_year_length).Date;
                            var isOpInCurrentTreatmentYear = t.TreatmentDate.Date >= current_treatment_year_start_date && t.TreatmentDate.Date < current_treatment_year_end_date;

                            return isOpAndPerformed && (isOpDateInRequiredTimespan || isOpInCurrentTreatmentYear);
                        });

                        var latest_case_in_treatment_year = cls_Get_Latest_CaseID_for_PatientID_DiagnoseID_and_Localization_in_TreatmentYear.Invoke(dbConnection, dbTransaction, new P_CAS_GLCIDfPIDDIDaLiTY_1705()
                        {
                            LocalizationCode = case_details.localization,
                            PatientID = case_details.patient_id,
                            TreatmentYearStartDate = current_treatment_year_start_date.Date,
                            TreatmentYearEndDate = current_treatment_year_end_date
                        }, securityTicket).Result;

                        var latest_case_id = latest_case_in_treatment_year != null ? latest_case_in_treatment_year.case_id : case_id;

                        if (!pdf_report_data.ContainsKey(case_id))
                        {
                            pdf_report_data.Add(case_id, new List<Guid>());
                        }
                        pdf_report_data[case_id].Add(oct_id);

                        #endregion Data

                        patient_ids.Add(case_details.patient_id);

                        var oct_planned_action = ORM_HEC_ACT_PlannedAction.Query.Search(dbConnection, dbTransaction, new ORM_HEC_ACT_PlannedAction.Query()
                        {
                            HEC_ACT_PlannedActionID = oct_id,
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false
                        }).SingleOrDefault();

                        if (oct_planned_action == null)
                        {
                            throw new KeyNotFoundException(String.Format("Oct not found for id: {0}", oct_id));
                        }

                        if (!is_resubmit)
                        {
                            #region Performed action

                            var oct_performed_action = new ORM_HEC_ACT_PerformedAction();
                            oct_performed_action.IfPerfomed_DateOfAction = oct_datetime;
                            oct_performed_action.IfPerformed_DateOfAction_Day = oct_datetime.Day;
                            oct_performed_action.IfPerformed_DateOfAction_Month = oct_datetime.Month;
                            oct_performed_action.IfPerformed_DateOfAction_Year = oct_datetime.Year;
                            oct_performed_action.IfPerformedInternaly_ResponsibleBusinessParticipant_RefID = authorizing_bpt_id;
                            oct_performed_action.IsPerformed_MedicalPractice_RefID = oct_planned_action.MedicalPractice_RefID;
                            oct_performed_action.Modification_Timestamp = DateTime.Now;
                            oct_performed_action.Patient_RefID = oct_planned_action.Patient_RefID;
                            oct_performed_action.Tenant_RefID = securityTicket.TenantID;

                            oct_performed_action.Save(dbConnection, dbTransaction);

                            var oct_performed_action_type_id = cls_Get_ActionTypeID.Invoke(dbConnection, dbTransaction, new P_CAS_GATID_1514() { action_type_gpmid = EActionType.PerformedOct.Value() }, securityTicket).Result;

                            var oct_performed_action_2_type = new ORM_HEC_ACT_PerformedAction_2_ActionType();
                            oct_performed_action_2_type.HEC_ACT_ActionType_RefID = oct_performed_action_type_id;
                            oct_performed_action_2_type.HEC_ACT_PerformedAction_RefID = oct_performed_action.HEC_ACT_PerformedActionID;
                            oct_performed_action_2_type.Modification_Timestamp = DateTime.Now;
                            oct_performed_action_2_type.IM_ActionType_Name = EActionType.PerformedOct.Value();
                            oct_performed_action_2_type.Tenant_RefID = securityTicket.TenantID;

                            oct_performed_action_2_type.Save(dbConnection, dbTransaction);

                            #endregion Performed action

                            #region Diagnose and localization

                            var diagnose_update = new ORM_HEC_ACT_PerformedAction_DiagnosisUpdate();
                            diagnose_update.HEC_ACT_PerformedAction_RefID = oct_performed_action.HEC_ACT_PerformedActionID;
                            diagnose_update.IM_PotentialDiagnosis_Code = diagnose_details.diagnose_icd_10;
                            diagnose_update.IM_PotentialDiagnosis_Name = diagnose_details.diagnose_name;
                            diagnose_update.IM_PotentialDiagnosisCatalog_Name = diagnose_details.catalog_display_name;
                            diagnose_update.Tenant_RefID = securityTicket.TenantID;
                            diagnose_update.PotentialDiagnosis_RefID = case_details.diagnose_id;
                            diagnose_update.Modification_Timestamp = DateTime.Now;

                            diagnose_update.Save(dbConnection, dbTransaction);

                            var diagnose_localization = new ORM_HEC_DIA_Diagnosis_Localization();
                            diagnose_localization.Diagnosis_RefID = case_details.diagnose_id;
                            diagnose_localization.LocalizationCode = case_details.localization;
                            diagnose_localization.Modification_Timestamp = DateTime.Now;
                            diagnose_localization.Tenant_RefID = securityTicket.TenantID;

                            diagnose_localization.Save(dbConnection, dbTransaction);

                            var diagnose_update_localization = new ORM_HEC_ACT_PerformedAction_DiagnosisUpdate_Localization();
                            diagnose_update_localization.HEX_EXC_Action_DiagnosisUpdate_RefID = diagnose_update.HEC_ACT_PerformedAction_DiagnosisUpdateID;
                            diagnose_update_localization.IM_PotentialDiagnosisLocalization_Code = case_details.localization;
                            diagnose_update_localization.Modification_Timestamp = DateTime.Now;
                            diagnose_update_localization.Tenant_RefID = securityTicket.TenantID;
                            diagnose_update_localization.HEC_DIA_Diagnosis_Localization_RefID = diagnose_localization.HEC_DIA_Diagnosis_LocalizationID;

                            diagnose_update_localization.Save(dbConnection, dbTransaction);

                            #endregion Diagnose and localization

                            #region Planned action

                            oct_planned_action.IsPerformed = true;
                            oct_planned_action.Modification_Timestamp = DateTime.Now;
                            oct_planned_action.IfPerformed_PerformedAction_RefID = oct_performed_action.HEC_ACT_PerformedActionID;

                            oct_planned_action.Save(dbConnection, dbTransaction);

                            #endregion Planned action

                            #region New planned action

                            var new_oct_planned_action = new ORM_HEC_ACT_PlannedAction();
                            new_oct_planned_action.MedicalPractice_RefID = oct_planned_action.MedicalPractice_RefID;
                            new_oct_planned_action.Patient_RefID = oct_planned_action.Patient_RefID;
                            new_oct_planned_action.Tenant_RefID = securityTicket.TenantID;
                            new_oct_planned_action.ToBePerformedBy_BusinessParticipant_RefID = oct_planned_action.ToBePerformedBy_BusinessParticipant_RefID;

                            new_oct_planned_action.Save(dbConnection, dbTransaction);

                            var new_oct_relevant_planned_action = new ORM_HEC_CAS_Case_RelevantPlannedAction();
                            new_oct_relevant_planned_action.Case_RefID = latest_case_id;
                            new_oct_relevant_planned_action.PlannedAction_RefID = new_oct_planned_action.HEC_ACT_PlannedActionID;
                            new_oct_relevant_planned_action.Tenant_RefID = securityTicket.TenantID;
                            new_oct_relevant_planned_action.Modification_Timestamp = DateTime.Now;

                            new_oct_relevant_planned_action.Save(dbConnection, dbTransaction);

                            var new_oct_planned_action_2_type = new ORM_HEC_ACT_PlannedAction_2_ActionType();
                            new_oct_planned_action_2_type.HEC_ACT_ActionType_RefID = oct_planned_action_type_id;
                            new_oct_planned_action_2_type.HEC_ACT_PlannedAction_RefID = new_oct_planned_action.HEC_ACT_PlannedActionID;
                            new_oct_planned_action_2_type.Modification_Timestamp = DateTime.Now;
                            new_oct_planned_action_2_type.Tenant_RefID = securityTicket.TenantID;

                            new_oct_planned_action_2_type.Save(dbConnection, dbTransaction);

                            #endregion New planned action

                            #region Bill position
                            var existing_bill_position = cls_Get_Existing_OCT_BillPosition_for_PatientID_and_LocalizationCode.Invoke(dbConnection, dbTransaction, new P_CAS_GEBPfPIDaLC_1803()
                            {
                                LocalizationCode = case_details.localization,
                                PatientID = case_details.patient_id
                            }, securityTicket).Result;

                            if (existing_bill_position == null)
                            {
                                throw new ArgumentException(String.Format("Oct bill position not found for patient: {0}, localization: {1}", case_details.patient_id, case_details.localization));
                            }

                            var bill_position = new ORM_BIL_BillPosition();
                            bill_position.Load(dbConnection, dbTransaction, existing_bill_position.BillPositionID);

                            var latest = 0;
                            var latestBill = cls_Get_Latest_Bill_Position_Number.Invoke(dbConnection, dbTransaction, securityTicket).Result;
                            if (latestBill != null && !string.IsNullOrEmpty(latestBill.latest_bill_position_number))
                            {
                                latest = Convert.ToInt32(latestBill.latest_bill_position_number);
                            }

                            bill_position.PositionNumber = SynchronizedSequentialNumberGenerator.Instance.Generate(latest).ToString();
                            bill_position.Modification_Timestamp = DateTime.Now;

                            bill_position.Save(dbConnection, dbTransaction);

                            cls_Calculate_Case_GPOS.Invoke(dbConnection, dbTransaction, new P_CAS_CCGPOS_1000()
                            {
                                case_id = latest_case_id,
                                diagnose_id = case_details.diagnose_id,
                                drug_id = case_details.drug_id,
                                patient_id = case_details.patient_id,
                                localization = case_details.localization,
                                treatment_date = case_details.treatment_date,
                                oct_doctor_id = case_details.oct_doctor_id
                            }, securityTicket);

                            var oct_fs_status = new ORM_BIL_BillPosition_TransmitionStatus();
                            oct_fs_status.BillPosition_RefID = existing_bill_position.BillPositionID;
                            oct_fs_status.IsActive = true;
                            oct_fs_status.Modification_Timestamp = DateTime.Now;
                            oct_fs_status.Tenant_RefID = securityTicket.TenantID;
                            oct_fs_status.TransmitionCode = performedOpExists ? fs_status_code : 21;
                            oct_fs_status.TransmitionStatusKey = "oct";
                            oct_fs_status.TransmittedOnDate = DateTime.Now;

                            #region Snapshot

                            DateTime today = DateTime.Today;
                            var age = today.Year - patient_details.birthday.Year;
                            if (patient_details.birthday > today.AddYears(-age))
                                age--;

                            var snapshot = cls_Create_XML_for_Immutable_Fields.Invoke(dbConnection, dbTransaction, new P_CAS_CXFIF_0830()
                            {
                                DiagnosisCatalogCode = diagnose_details.diagnose_icd_10,
                                DiagnosisCatalogName = diagnose_details.catalog_display_name,
                                DiagnosisName = diagnose_details.diagnose_name,
                                IFPerformedResponsibleBPFullName = MMDocConnectDocApp.GenericUtils.GetDoctorName(oct_doctor_details),
                                IFPerformedMedicalPracticeName = oct_practice_details.practice_name,
                                Localization = case_details.localization,
                                PatientBirthDate = patient_details.birthday.ToString("dd.MM.yyyy"),
                                PatientFirstName = patient_details.patient_first_name,
                                PatientGender = patient_details.gender.ToString(),
                                PatientLastName = patient_details.patient_last_name,
                                PatientAge = age.ToString()
                            }, securityTicket).Result;

                            if (snapshot != null)
                            {
                                oct_fs_status.TransmissionDataXML = snapshot.XmlFileString;
                            }

                            #endregion Snapshot

                            oct_fs_status.Save(dbConnection, dbTransaction);

                            #endregion Bill position
                        }
                        else
                        {
                            var relevant_actions = cls_Get_RelevanActionIDs_for_CaseID_and_ActionTypeID.Invoke(dbConnection, dbTransaction, new P_CAS_GRAIDsfCIDaATID_1547()
                            {
                                ActionTypeID = oct_planned_action_type_id,
                                CaseID = case_id
                            }, securityTicket).Result;
                            var bill_positions = cls_Get_BillPositionIDs_for_CaseID.Invoke(dbConnection, dbTransaction, new P_CAS_GBPIDsfCID_0928() { CaseID = case_id }, securityTicket).Result.Where(t => t.gpos_type == EGposType.Oct.Value()).ToList();

                            for (var i = 0; i < relevant_actions.Length; i++)
                            {
                                if (relevant_actions[i].action_id == oct_id)
                                {
                                    var bill_position = bill_positions[i];

                                    var transmition_statusQ = new ORM_BIL_BillPosition_TransmitionStatus.Query();
                                    transmition_statusQ.BillPosition_RefID = bill_position.bill_position_id;
                                    transmition_statusQ.TransmitionStatusKey = "oct";
                                    transmition_statusQ.Tenant_RefID = securityTicket.TenantID;
                                    transmition_statusQ.IsDeleted = false;
                                    transmition_statusQ.IsActive = true;

                                    var transmition_status = ORM_BIL_BillPosition_TransmitionStatus.Query.Search(dbConnection, dbTransaction, transmition_statusQ).SingleOrDefault();
                                    if (transmition_status != null && transmition_status.TransmitionCode != 8 && transmition_status.TransmitionCode != 11 && transmition_status.TransmitionCode != 17)
                                    {
                                        transmition_status.IsActive = false;
                                        transmition_status.Modification_Timestamp = DateTime.Now;
                                        transmition_status.Save(dbConnection, dbTransaction);

                                        ORM_BIL_BillPosition_TransmitionStatus position_status = new ORM_BIL_BillPosition_TransmitionStatus();
                                        position_status.BIL_BillPosition_TransmitionStatusID = Guid.NewGuid();
                                        position_status.BillPosition_RefID = bill_position.bill_position_id;
                                        position_status.Creation_Timestamp = DateTime.Now;
                                        position_status.IsActive = true;
                                        position_status.Modification_Timestamp = DateTime.Now;
                                        position_status.TransmitionCode = fs_status_code;
                                        position_status.TransmittedOnDate = DateTime.Now;
                                        position_status.Tenant_RefID = securityTicket.TenantID;
                                        position_status.TransmitionStatusKey = "oct";

                                        #region CREATE SNAPSHOT

                                        DateTime today = DateTime.Today;
                                        int age = today.Year - patient_details.birthday.Year;
                                        if (patient_details.birthday > today.AddYears(-age))
                                            age--;

                                        var snapshot = cls_Create_XML_for_Immutable_Fields.Invoke(dbConnection, dbTransaction, new P_CAS_CXFIF_0830()
                                        {
                                            DiagnosisCatalogCode = diagnose_details.diagnose_icd_10,
                                            DiagnosisCatalogName = diagnose_details.catalog_display_name,
                                            DiagnosisName = diagnose_details.diagnose_name,
                                            IFPerformedMedicalPracticeName = oct_doctor_details.practice,
                                            IFPerformedResponsibleBPFullName = GenericUtils.GetDoctorName(oct_doctor_details),
                                            Localization = case_details.localization,
                                            PatientBirthDate = patient_details.birthday.ToString("dd.MM.yyyy"),
                                            PatientFirstName = patient_details.patient_first_name,
                                            PatientGender = patient_details.gender.ToString(),
                                            PatientLastName = patient_details.patient_last_name,
                                            PatientAge = age.ToString()
                                        }, securityTicket).Result;

                                        if (snapshot != null)
                                        {
                                            position_status.TransmissionDataXML = snapshot.XmlFileString;
                                        }

                                        #endregion CREATE SNAPSHOT

                                        position_status.Save(dbConnection, dbTransaction);
                                    }
                                }
                            }
                        }
                    }

                    #region PDF REPORT

                    if (HttpContext.Current != null)
                    {
                        var host = HttpContext.Current.Request.UserHostAddress;
                        var logoUrl = HttpContext.Current.Server.MapPath("~/Content/images/medioslogo.jpg");
                        var reportContentPath = HttpContext.Current.Server.MapPath("~/ReportContent/SubmissionReportContent.xml");
                        var docOnlyReportContentPath = HttpContext.Current.Server.MapPath("~/ReportContent/DocumentationOnlySubmissionReportContent.xml");
                        var case_data = new List<P_CAS_CPRfSC_1813a>();
                        var action_ids = new List<Guid>();
                        var oct_id_list = oct_ids.ToList();
                        foreach (var pdf_param in pdf_report_data)
                        {
                            foreach (var pdf_oct_id in pdf_param.Value)
                            {
                                var action_id = Guid.Empty;
                                case_data.Add(new P_CAS_CPRfSC_1813a()
                                {
                                    CaseID = pdf_param.Key,
                                    CaseType = "oct",
                                    ActionID = pdf_oct_id
                                });
                            }
                        }

                        var reportParameter = new P_CAS_CPRfSC_1813()
                        {
                            CaseData = case_data.ToArray(),
                            UploadedFrom = host,
                            LogoImageUrl = logoUrl,
                            ReportContentPath = reportContentPath,
                            DocumentationOnlyReportContentPath = docOnlyReportContentPath
                        };

                        if (shouldDownloadReportProperty != null && shouldDownloadReportProperty.BooleanValue)
                        {
                            response = cls_Create_Pdf_Report_for_Submitted_Case.Invoke(dbConnection, dbTransaction, reportParameter, securityTicket).Result.PdfUploaded;
                        }
                        else
                        {
                            var asyncDelay = 5000;
                            try
                            {
                                asyncDelay = Int32.Parse(WebConfigurationManager.AppSettings["pdfReceiptAsyncDelay"]);
                            }
                            catch { }
                            Task.Run(async delegate
                            {
                                await Task.Delay(asyncDelay);
                                try
                                {
                                    reportParameter.IsBackgroundTask = true;
                                    cls_Create_Pdf_Report_for_Submitted_Case.Invoke(connectionString, reportParameter, securityTicket);
                                }
                                catch { }
                            });
                        }
                    }

                    #endregion PDF REPORT

                    var elasticRefresher = new ElasticRefresher(patient_ids.Distinct(), dbConnection, dbTransaction, securityTicket, true);
                    elasticRefresher
                        .UpdateOct()
                        .UpdateIvoms()
                        .RebuildElastic();

                    if (handle_transaction)
                    {
                        dbTransaction.Commit();
                    }

                    Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, new
                    {
                        OctIds = oct_ids,
                        OctDate = oct_date,
                        AuthorizingDoctorId = authorizing_doctor_id,
                        IsResubmit = is_resubmit,
                        DocumentationOnly = documentation_only
                    }), data.PracticeName);
                }
                finally
                {
                    if (dbConnection.State == System.Data.ConnectionState.Open && handle_connection)
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

        public void RejectOct(Guid oct_id, string connectionString, string sessionTicket, out TransactionalInformation transaction)
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

                    var current_oct_planned_action = ORM_HEC_ACT_PlannedAction.Query.Search(dbConnection, dbTransaction, new ORM_HEC_ACT_PlannedAction.Query() { HEC_ACT_PlannedActionID = oct_id }).SingleOrDefault();
                    if (current_oct_planned_action == null)
                    {
                        throw new Exception(String.Format("OCT planned action not found for id: {0}", oct_id));
                    }

                    var relevant_oct_action = ORM_HEC_CAS_Case_RelevantPlannedAction.Query.Search(dbConnection, dbTransaction, new ORM_HEC_CAS_Case_RelevantPlannedAction.Query() { PlannedAction_RefID = oct_id }).Single();
                    var case_id = relevant_oct_action.Case_RefID;

                    var case_treatment_data = cls_Get_Case_Treatment_Data_for_CaseID.Invoke(dbConnection, dbTransaction, new P_CAS_GCTDfCID_1143() { CaseID = case_id }, securityTicket).Result;

                    var oct_planned_action_type_id = cls_Get_ActionTypeID.Invoke(dbConnection, dbTransaction, new P_CAS_GATID_1514() { action_type_gpmid = EActionType.PlannedOct.Value() }, securityTicket).Result;

                    var relevant_oct_actions = cls_Get_PlannedActionIDs_for_PatientID_and_ActionTypeID.Invoke(dbConnection, dbTransaction, new P_CAS_GPAIDsfPIDaATID_1705()
                    {
                        ActionTypeID = oct_planned_action_type_id,
                        PatientID = case_treatment_data.patient_id
                    }, securityTicket).Result;

                    var case_bill_positions = cls_Get_BillPositionIDs_for_PatientID_and_GposType.Invoke(dbConnection, dbTransaction, new P_CAS_GBPIDsfPIDaGposT_1709()
                    {
                        PatientID = case_treatment_data.patient_id,
                        GposType = EGposType.Oct.Value()
                    }, securityTicket).Result;

                    if (case_bill_positions.Any())
                    {
                        for (var i = 0; i < relevant_oct_actions.Length; i++)
                        {
                            if (relevant_oct_actions[i].action_id == oct_id)
                            {
                                if (i >= case_bill_positions.Length)
                                {
                                    throw new Exception(String.Format("Relevant actions and bill positions count mismatch. OCT id: {0}, case id: {1}, action count: {2}, bill position count: {3}", oct_id, case_id, relevant_oct_actions.Length, case_bill_positions.Length));
                                }

                                cls_Delete_BillingData_for_BillPositionID.Invoke(dbConnection, dbTransaction, new P_CAS_DBDfHBPID_1549()
                                {
                                    bill_position_id = case_bill_positions[i].bill_position_id
                                }, securityTicket);
                            }
                        }
                    }

                    var existing_rejection_properties = cls_Get_Localizations_where_Oct_Rejected.Invoke(dbConnection, dbTransaction, new P_CAS_GLwOctR_1026()
                    {
                        PatientID = case_treatment_data.patient_id,
                        RejectedOctPropertyID = ECaseProperty.HasRejectedOct.Value()
                    }, securityTicket).Result;

                    foreach (var existing_rejection_property in existing_rejection_properties.Where(t => t.localization == case_treatment_data.localization))
                    {
                        ORM_HEC_CAS_Case_UniversalPropertyValue.Query.SoftDelete(dbConnection, dbTransaction, new ORM_HEC_CAS_Case_UniversalPropertyValue.Query()
                        {
                            HEC_CAS_Case_UniversalPropertyValueID = existing_rejection_property.property_id,
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false
                        });
                    }

                    cls_Save_Case_Property.Invoke(dbConnection, dbTransaction, new P_CAS_SCP_1308()
                    {
                        case_id = case_id,
                        property_string_value = case_treatment_data.localization,
                        property_gpm_id = ECaseProperty.HasRejectedOct.Value(),
                        property_name = "Case has rejected OCT"
                    }, securityTicket);

                    relevant_oct_action.IsDeleted = true;
                    relevant_oct_action.Modification_Timestamp = DateTime.Now;

                    relevant_oct_action.Save(dbConnection, dbTransaction);

                    current_oct_planned_action.IsDeleted = true;
                    current_oct_planned_action.Modification_Timestamp = DateTime.Now;

                    current_oct_planned_action.Save(dbConnection, dbTransaction);

                    var patients = new List<Patient_Model>();
                    var patient = Retrieve_Patients.Get_Patient_for_PatientID(current_oct_planned_action.Patient_RefID.ToString(), securityTicket);
                    if (patient != null)
                    {
                        patient.has_rejected_oct = true;
                        patients.Add(patient);
                    }

                    if (patients.Any())
                    {
                        Add_New_Patient.Import_Patients_to_ElasticDB(patients, securityTicket.TenantID.ToString());
                    }

                    var elasticRefresher = new ElasticRefresher(new Guid[] { case_treatment_data.patient_id }, dbConnection, dbTransaction, securityTicket, true);
                    elasticRefresher
                        .UpdateOct()
                        .RebuildElastic();

                    dbTransaction.Commit();

                    Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, oct_id), data.PracticeName);
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

        public object EditOctForErrorCorrection(Guid oct_id, string oct_date, Guid oct_doctor_id, bool is_left_eye, string connectionString, string sessionTicket, out TransactionalInformation transaction, DbConnection dbConnection = null, DbTransaction dbTransaction = null)
        {
            var handle_connection = dbConnection == null;
            var handle_transaction = dbTransaction == null;

            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = HttpContext.Current != null ? Util.GetIPInfo(HttpContext.Current.Request) : new IPInfo() { address = "none", agent = "none" };

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

                    var localization_changed = false;
                    var new_localization = is_left_eye ? "L" : "R";
                    var previous_oct_performed_date = "";
                    var oct_performed_date = DateTime.ParseExact(oct_date, "dd.MM.yyyy", new CultureInfo("de", true));

                    var patients = new List<Patient_Model>();

                    #region Actions

                    var oct_planned_action = ORM_HEC_ACT_PlannedAction.Query.Search(dbConnection, dbTransaction, new ORM_HEC_ACT_PlannedAction.Query()
                    {
                        HEC_ACT_PlannedActionID = oct_id,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).SingleOrDefault();

                    if (oct_planned_action == null)
                    {
                        throw new ArgumentException(String.Format("Oct planned action not found for id: {0}", oct_id));
                    }

                    var oct_doctor = ORM_HEC_Doctor.Query.Search(dbConnection, dbTransaction, new ORM_HEC_Doctor.Query()
                    {
                        HEC_DoctorID = oct_doctor_id,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).SingleOrDefault();

                    if (oct_doctor == null)
                    {
                        throw new ArgumentException(String.Format("Doctor not found for id: {0}", oct_doctor_id));
                    }

                    oct_planned_action.ToBePerformedBy_BusinessParticipant_RefID = oct_doctor.BusinessParticipant_RefID;
                    oct_planned_action.Modification_Timestamp = DateTime.Now;

                    oct_planned_action.Save(dbConnection, dbTransaction);

                    var oct_performed_action = ORM_HEC_ACT_PerformedAction.Query.Search(dbConnection, dbTransaction, new ORM_HEC_ACT_PerformedAction.Query()
                    {
                        HEC_ACT_PerformedActionID = oct_planned_action.IfPerformed_PerformedAction_RefID,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).SingleOrDefault();

                    if (oct_performed_action == null)
                    {
                        throw new ArgumentException(String.Format("Oct performed action not found for performed action id: {0}", oct_planned_action.IfPerformed_PerformedAction_RefID));
                    }
                    previous_oct_performed_date = oct_performed_action.IfPerfomed_DateOfAction.ToString("dd.MM.yyyy");
                    oct_performed_action.IfPerfomed_DateOfAction = oct_performed_date;
                    oct_performed_action.IfPerformed_DateOfAction_Day = oct_performed_date.Day;
                    oct_performed_action.IfPerformed_DateOfAction_Month = oct_performed_date.Month;
                    oct_performed_action.IfPerformed_DateOfAction_Year = oct_performed_date.Year;
                    oct_performed_action.IfPerformedInternaly_ResponsibleBusinessParticipant_RefID = oct_doctor.BusinessParticipant_RefID;
                    oct_performed_action.Modification_Timestamp = DateTime.Now;

                    oct_performed_action.Save(dbConnection, dbTransaction);

                    #endregion Actions

                    #region Localization

                    var oct_performed_action_diagnose = ORM_HEC_ACT_PerformedAction_DiagnosisUpdate.Query.Search(dbConnection, dbTransaction, new ORM_HEC_ACT_PerformedAction_DiagnosisUpdate.Query()
                    {
                        HEC_ACT_PerformedAction_RefID = oct_performed_action.HEC_ACT_PerformedActionID,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).SingleOrDefault();

                    if (oct_performed_action_diagnose == null)
                    {
                        throw new ArgumentException(String.Format("Oct performed action diagnose not found for performed action id: {0}", oct_performed_action.HEC_ACT_PerformedActionID));
                    }

                    var oct_performed_action_diagnose_localization = ORM_HEC_ACT_PerformedAction_DiagnosisUpdate_Localization.Query.Search(dbConnection, dbTransaction, new ORM_HEC_ACT_PerformedAction_DiagnosisUpdate_Localization.Query()
                    {
                        HEX_EXC_Action_DiagnosisUpdate_RefID = oct_performed_action_diagnose.HEC_ACT_PerformedAction_DiagnosisUpdateID,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).SingleOrDefault();

                    if (oct_performed_action_diagnose_localization == null)
                    {
                        throw new ArgumentException(String.Format("Oct performed action diagnose localization not found for performed action diagnose id: {0}", oct_performed_action_diagnose.HEC_ACT_PerformedAction_DiagnosisUpdateID));
                    }

                    var is_previous_localization_left_eye = oct_performed_action_diagnose_localization.IM_PotentialDiagnosisLocalization_Code == "L";
                    localization_changed = is_previous_localization_left_eye != is_left_eye;

                    oct_performed_action_diagnose_localization.IM_PotentialDiagnosisLocalization_Code = is_left_eye ? "L" : "R";
                    oct_performed_action_diagnose_localization.IM_PotentialDiagnosisLocalization_Name = is_left_eye ? "Left eye" : "Right eye";
                    oct_performed_action_diagnose_localization.Modification_Timestamp = DateTime.Now;

                    oct_performed_action_diagnose_localization.Save(dbConnection, dbTransaction);

                    var diagnose_localization = ORM_HEC_DIA_Diagnosis_Localization.Query.Search(dbConnection, dbTransaction, new ORM_HEC_DIA_Diagnosis_Localization.Query()
                    {
                        HEC_DIA_Diagnosis_LocalizationID = oct_performed_action_diagnose_localization.HEC_DIA_Diagnosis_Localization_RefID,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).SingleOrDefault();

                    if (diagnose_localization == null)
                    {
                        throw new ArgumentException(String.Format("Diagnose localization not found for performed action diagnose localization id: {0}", oct_performed_action_diagnose_localization.HEC_DIA_Diagnosis_Localization_RefID));
                    }

                    diagnose_localization.LocalizationCode = new_localization;
                    diagnose_localization.Modification_Timestamp = DateTime.Now;

                    diagnose_localization.Save(dbConnection, dbTransaction);

                    #endregion Localization

                    #region Change case if localization changed

                    if (localization_changed)
                    {
                        var current_treatment_year_start_date = cls_Get_TreatmentYear.Invoke(dbConnection, dbTransaction, new P_CAS_GTY_1125()
                        {
                            Date = oct_performed_date,
                            LocalizationCode = new_localization,
                            PatientID = oct_planned_action.Patient_RefID,
                        }, securityTicket).Result;

                        var treatment_year_length = cls_Get_TreatmentYearLength.Invoke(dbConnection, dbTransaction, new P_CAS_GTYL_1317()
                        {
                            Date = oct_performed_date,
                            PatientID = oct_planned_action.Patient_RefID
                        }, securityTicket).Result;

                        var current_treatment_year_end_date = current_treatment_year_start_date.AddDays(treatment_year_length - 1);

                        var latest_case_in_treatment_year = cls_Get_Latest_CaseID_for_PatientID_DiagnoseID_and_Localization_in_TreatmentYear.Invoke(dbConnection, dbTransaction, new P_CAS_GLCIDfPIDDIDaLiTY_1705()
                        {
                            LocalizationCode = new_localization,
                            PatientID = oct_planned_action.Patient_RefID,
                            TreatmentYearStartDate = current_treatment_year_start_date,
                            TreatmentYearEndDate = current_treatment_year_end_date,
                        }, securityTicket).Result;

                        if (latest_case_in_treatment_year == null)
                        {
                            return new
                            {
                                label = "LABEL_NO_VALID_OP_FOR_LOCALIZATION_IN_TREATMENT_YEAR",
                                treatment_year = String.Format("{0} - {1}", current_treatment_year_start_date.ToString("dd.MM.yyyy"), current_treatment_year_end_date.ToString("dd.MM.yyyy"))
                            };
                        }

                        var oct_planned_action_type_id = cls_Get_ActionTypeID.Invoke(dbConnection, dbTransaction, new P_CAS_GATID_1514() { action_type_gpmid = EActionType.PlannedOct.Value() }, securityTicket).Result;

                        var all_contract_parameters = ORM_CMN_CTR_Contract_Parameter.Query.Search(dbConnection, dbTransaction, new ORM_CMN_CTR_Contract_Parameter.Query()
                        {
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false
                        }).GroupBy(t => t.Contract_RefID).ToDictionary(t => t.Key, t => t);

                        var op_dates = cls_Get_PerformedOpDates_for_PatientID.Invoke(dbConnection, dbTransaction, new P_CAS_GPOpDfPID_0959()
                        {
                            PatientID = oct_planned_action.Patient_RefID
                        }, securityTicket).Result;

                        PA_GPCbDaGposIDs_1154 active_consent = null;
                        var oct_gpos_ids = cls_Get_GposIDs_for_GposType.Invoke(dbConnection, dbTransaction, new P_MD_GGpoIDsfGposT_1145() { GposType = EGposType.Oct.Value() }, securityTicket).Result.Select(t => t.GposID).ToArray();

                        var patient_consents = cls_Get_Patient_Consents_before_Date_and_GposIDs.Invoke(dbConnection, dbTransaction, new P_PA_GPCbDaGposIDs_1154()
                        {
                            Date = oct_performed_date,
                            GposIDs = oct_gpos_ids,
                            PatientID = oct_planned_action.Patient_RefID
                        }, securityTicket).Result;
                        var last_consent = patient_consents.First();
                        var is_consent_auto_renewed_by_op = all_contract_parameters[last_consent.contract_id].Any(p => p.ParameterName == "OP renews patient consent");
                        var consent_valid_for_months = all_contract_parameters[last_consent.contract_id].SingleOrDefault(p => p.ParameterName == "Duration of participation consent – Month");
                        var last_consent_valid_to = last_consent.consent_valid_from.Date.AddMonths(Convert.ToInt32(consent_valid_for_months.IfNumericValue_Value));
                        var last_consent_timespan = "";
                        if (last_consent_valid_to >= oct_performed_date)
                        {
                            active_consent = last_consent;
                        }
                        else if (is_consent_auto_renewed_by_op)
                        {
                            var last_op_date = op_dates.First();
                            var last_consent_valid_until = last_op_date.treatment_date.Date.AddMonths(Convert.ToInt32(consent_valid_for_months.IfNumericValue_Value));
                            if (last_consent_valid_until > oct_performed_date)
                            {
                                active_consent = last_consent;
                            }
                            else
                            {
                                last_consent_timespan = String.Format("{0} - {1}", last_op_date.treatment_date.ToString("dd.MM.yyyy"), last_consent_valid_until.AddDays(-1).ToString("dd.MM.yyyy"));
                            }
                        }

                        var contract_parameters = all_contract_parameters[active_consent.contract_id];
                        var max_number_of_preexaminations = contract_parameters.SingleOrDefault(t => t.ParameterName == EContractParameter.MaxNumberOfOcts.Value());
                        var useSettlementYear = contract_parameters.SingleOrDefault(t => t.ParameterName == EContractParameter.UseSettlementYear.Value()) != null;

                        if (max_number_of_preexaminations != null)
                        {
                            var oct_count_in_treatment_year = cls_Get_TreatmentYearOctCount.Invoke(dbConnection, dbTransaction, new P_CAS_GTYOctC_1939()
                            {
                                LocalizationCode = new_localization,
                                OctPlannedActionTypeID = oct_planned_action_type_id,
                                PatientID = oct_planned_action.Patient_RefID,
                                TreatmentYearEndDate = current_treatment_year_end_date,
                                TreatmentYearStartDate = current_treatment_year_start_date
                            }, securityTicket).Result.fs_status_count;

                            if (useSettlementYear)
                            {
                                var orher_localization = new_localization == "L" ? "R" : "L";

                                oct_count_in_treatment_year += cls_Get_TreatmentYearOctCount.Invoke(dbConnection, dbTransaction, new P_CAS_GTYOctC_1939()
                                {
                                    LocalizationCode = orher_localization,
                                    OctPlannedActionTypeID = oct_planned_action_type_id,
                                    PatientID = oct_planned_action.Patient_RefID,
                                    TreatmentYearStartDate = current_treatment_year_end_date,
                                    TreatmentYearEndDate = current_treatment_year_start_date
                                }, securityTicket).Result.fs_status_count;
                            }

                            if (oct_count_in_treatment_year > max_number_of_preexaminations.IfNumericValue_Value)
                            {
                                return new
                                {
                                    label = "LABEL_OCT_COUNT_PER_TREATMENT_YEAR_EXCEEDED",
                                    max_count = max_number_of_preexaminations.IfNumericValue_Value,
                                    date = current_treatment_year_end_date.AddDays(1).ToString("dd.MM.yyyy")
                                };
                            }
                        }

                        var relevant_oct_action = ORM_HEC_CAS_Case_RelevantPlannedAction.Query.Search(dbConnection, dbTransaction, new ORM_HEC_CAS_Case_RelevantPlannedAction.Query()
                        {
                            PlannedAction_RefID = oct_planned_action.HEC_ACT_PlannedActionID,
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false
                        }).Single();

                        var case_bill_code_ids = cls_Get_Case_BillCodeIDs_for_CaseID_And_GposTypeID.Invoke(dbConnection, dbTransaction, new P_CAS_GCBCIDsfCIDaGposT_1342()
                        {
                            CaseID = relevant_oct_action.Case_RefID,
                            GposTypeGpmID = EGposType.Oct.Value()
                        }, securityTicket).Result;

                        var relevant_case_oct_actions = cls_Get_RelevanActionIDs_for_CaseID_and_ActionTypeID.Invoke(dbConnection, dbTransaction, new P_CAS_GRAIDsfCIDaATID_1547()
                        {
                            CaseID = relevant_oct_action.Case_RefID,
                            ActionTypeID = oct_planned_action_type_id
                        }, securityTicket).Result;

                        for (var i = 0; i < relevant_case_oct_actions.Length; i++)
                        {
                            if (relevant_case_oct_actions[i].action_id == relevant_oct_action.PlannedAction_RefID)
                            {
                                var case_bill_code_id = case_bill_code_ids[i].case_bill_code_id;
                                var case_bill_code = new ORM_HEC_CAS_Case_BillCode();
                                case_bill_code.Load(dbConnection, dbTransaction, case_bill_code_id);

                                case_bill_code.HEC_CAS_Case_RefID = latest_case_in_treatment_year.case_id;
                                case_bill_code.Modification_Timestamp = DateTime.Now;

                                case_bill_code.Save(dbConnection, dbTransaction);
                                break;
                            }
                        }

                        relevant_oct_action.Case_RefID = latest_case_in_treatment_year.case_id;
                        relevant_oct_action.Modification_Timestamp = DateTime.Now;

                        relevant_oct_action.Save(dbConnection, dbTransaction);
                    }

                    #endregion

                    var elasticRefresher = new ElasticRefresher(new Guid[] { oct_planned_action.Patient_RefID }, dbConnection, dbTransaction, securityTicket, true);
                    elasticRefresher
                        .UpdateOct()
                        .UpdateIvoms()
                        .RebuildElastic();

                    if (patients.Any())
                    {
                        Add_New_Patient.Import_Patients_to_ElasticDB(patients, securityTicket.TenantID.ToString());
                    }

                    if (handle_transaction)
                    {
                        dbTransaction.Commit();
                    }

                    Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, new
                    {
                        OctId = oct_id,
                        OctDate = oct_date,
                        OctDoctorID = oct_doctor_id,
                        Localization = new_localization
                    }, new
                    {
                        OctId = oct_id,
                        OctDate = previous_oct_performed_date,
                        OctDoctorID = oct_doctor_id,
                        IsLeftEye = localization_changed ? new_localization == "L" ? "R" : "L" : new_localization
                    }), data.PracticeName);
                }
                finally
                {
                    if (dbConnection.State == System.Data.ConnectionState.Open && handle_connection)
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

        public void EditOctDoctor(Guid patient_id, bool is_left_eye, Guid oct_doctor_id, bool withdraw_oct, string submit_oct_until_date_string, string connectionString, string sessionTicket, out TransactionalInformation transaction)
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
                    var localization = is_left_eye ? "L" : "R";
                    var elastic_index = securityTicket.TenantID.ToString();
                    var submit_oct_until_date = !String.IsNullOrEmpty(submit_oct_until_date_string) ? DateTime.ParseExact(submit_oct_until_date_string, "dd.MM.yyyy", new CultureInfo("de", true)) : DateTime.MinValue;
                    var patients = new List<Patient_Model>();

                    var latest_case = cls_Get_Latest_CaseID_for_PatientID_and_Localization.Invoke(dbConnection, dbTransaction, new P_CAS_GLCIDfPIDaL_0917()
                    {
                        Localization = localization,
                        PatientID = patient_id
                    }, securityTicket).Result;

                    if (latest_case == null)
                    {
                        throw new ArgumentException(String.Format("No case exists for patient id {0} on localization {1}", patient_id, localization));
                    }

                    var case_details = cls_Get_Case_Details_for_CaseID.Invoke(dbConnection, dbTransaction, new P_CAS_GCDfCID_1435() { CaseID = latest_case.CaseID }, securityTicket).Result;

                    var submit_until_date_case_properties = cls_Get_SubmitUntilDate_CasePropertyValues_for_PatientID.Invoke(dbConnection, dbTransaction, new P_CAS_GSUDCPVfPID_1438() { PatientID = case_details.patient_id }, securityTicket).Result;
                    foreach (var property in submit_until_date_case_properties)
                    {
                        var property_case_details = cls_Get_Case_Details_for_CaseID.Invoke(dbConnection, dbTransaction, new P_CAS_GCDfCID_1435()
                        {
                            CaseID = property.case_id
                        }, securityTicket).Result;
                        if (property_case_details != null && property_case_details.localization == localization)
                        {
                            ORM_HEC_CAS_Case_UniversalPropertyValue.Query.SoftDelete(dbConnection, dbTransaction, new ORM_HEC_CAS_Case_UniversalPropertyValue.Query()
                            {
                                HEC_CAS_Case_UniversalPropertyValueID = property.property_value_id
                            });
                        }
                    }

                    var oct_planned_action_type_id = cls_Get_ActionTypeID.Invoke(dbConnection, dbTransaction, new P_CAS_GATID_1514() { action_type_gpmid = EActionType.PlannedOct.Value() }, securityTicket).Result;

                    var current_treatment_year_start_date = cls_Get_TreatmentYear.Invoke(dbConnection, dbTransaction, new P_CAS_GTY_1125()
                    {
                        Date = case_details.treatment_date,
                        LocalizationCode = localization,
                        PatientID = patient_id
                    }, securityTicket).Result;

                    var treatment_year_length = cls_Get_TreatmentYearLength.Invoke(dbConnection, dbTransaction, new P_CAS_GTYL_1317() { Date = case_details.treatment_date, PatientID = patient_id }, securityTicket).Result;

                    var current_treatment_year_end_date = current_treatment_year_start_date.AddDays(treatment_year_length - 1);

                    var first_treatment_date = cls_Get_FirstOpDate_for_PatientID_and_LocalizationCode_in_TreatmentYear.Invoke(dbConnection, dbTransaction, new P_CAS_GFOpDfPIDaLCiTY_1441()
                    {
                        PatientID = patient_id,
                        LocalizationCode = localization,
                        TreatmentYearStartDate = current_treatment_year_start_date,
                        TreatmentYearEndDate = current_treatment_year_end_date
                    }, securityTicket).Result;

                    var diagnose_details = cls_Get_Diagnose_Details_for_DiagnoseID.Invoke(dbConnection, dbTransaction, new P_CAS_GDDfDID_1608() { DiagnoseID = case_details.diagnose_id }, securityTicket).Result;
                    var patient_details = cls_Get_Patient_Details_for_PatientID.Invoke(dbConnection, dbTransaction, new P_P_PA_GPDfPID_1124() { PatientID = patient_id }, securityTicket).Result;
                    var treatment_doctor_details = cls_Get_Doctor_Details_for_DoctorID.Invoke(dbConnection, dbTransaction, new P_DO_GDDfDID_0823() { DoctorID = case_details.op_doctor_id }, securityTicket).Result.First();

                    var number_of_performed_octs = cls_Get_TreatmentYearOctCount.Invoke(dbConnection, dbTransaction, new P_CAS_GTYOctC_1939()
                    {
                        LocalizationCode = localization,
                        OctPlannedActionTypeID = oct_planned_action_type_id,
                        PatientID = patient_id,
                        TreatmentYearEndDate = current_treatment_year_end_date,
                        TreatmentYearStartDate = current_treatment_year_start_date
                    }, securityTicket).Result.fs_status_count;

                    var is_oct_open = first_treatment_date != null ? true : number_of_performed_octs == 0;

                    var oct_doctor = cls_Get_Doctor_Details_for_DoctorID.Invoke(dbConnection, dbTransaction, new P_DO_GDDfDID_0823() { DoctorID = oct_doctor_id }, securityTicket).Result.First();
                    var previous_doctor_bpt_id = Guid.Empty;
                    if (withdraw_oct)
                    {
                        var latest_oct_planned_action_id = cls_Get_Latest_PlannedActionID_for_PatientID_ActionTypeID_and_LocalizationCode.Invoke(dbConnection, dbTransaction, new P_CAS_GLPAIDfPIDATIDaLC_1545()
                        {
                            ActionTypeID = oct_planned_action_type_id,
                            LocalizationCode = localization,
                            PatientID = patient_id
                        }, securityTicket).Result.FirstOrDefault();

                        var latest_oct_planned_action = new ORM_HEC_ACT_PlannedAction();
                        latest_oct_planned_action.Load(dbConnection, dbTransaction, latest_oct_planned_action_id.PlannedActionID);

                        if (submit_oct_until_date == DateTime.MinValue)
                        {
                            latest_oct_planned_action.IsCancelled = true;
                            latest_oct_planned_action.Modification_Timestamp = DateTime.Now;

                            latest_oct_planned_action.Save(dbConnection, dbTransaction);

                            cls_Create_OCT.Invoke(dbConnection, dbTransaction, new P_CAS_COCT_1703()
                            {
                                case_id = latest_case.CaseID,
                                oct_action_type_id = oct_planned_action_type_id,
                                oct_bpt_id = oct_doctor.doctor_bpt_id,
                                patient_id = patient_id,
                                treatment_date = case_details.treatment_date,
                                practice_id = case_details.practice_id
                            }, securityTicket);

                            cls_Calculate_Case_GPOS.Invoke(dbConnection, dbTransaction, new P_CAS_CCGPOS_1000()
                            {
                                case_id = case_details.case_id,
                                diagnose_id = case_details.diagnose_id,
                                drug_id = case_details.drug_id,
                                patient_id = patient_id,
                                localization = localization,
                                treatment_date = case_details.treatment_date,
                                oct_doctor_id = oct_doctor_id
                            }, securityTicket);

                            var original_patient = Retrieve_Patients.Get_Patient_for_PatientID(case_details.patient_id.ToString(), securityTicket);
                            if (Guid.Parse(original_patient.practice_id) != oct_doctor.practice_id)
                            {
                                var existing_patient = Retrieve_Patients.GetPatientsWhereIDPresent(case_details.patient_id.ToString(), "originating_patient_id", elastic_index).SingleOrDefault(t => Guid.Parse(t.practice_id) == oct_doctor.practice_id);
                                if (existing_patient == null)
                                {
                                    var patient_practice_name = cls_Get_Patient_PracticeName_for_PatientID.Invoke(dbConnection, dbTransaction, new P_P_PA_GPPNfPID_1131() { PatientID = case_details.patient_id }, securityTicket).Result;

                                    existing_patient = new Patient_Model();
                                    var oct_practice_details = cls_Get_Practice_Details_for_Report.Invoke(dbConnection, dbTransaction, new P_DO_GPDFR_0840() { PracticeID = oct_doctor.practice_id }, securityTicket).Result;

                                    GenericUtils.CloneObject<Patient_Model>(original_patient, existing_patient);
                                    existing_patient.id = Guid.NewGuid().ToString();
                                    existing_patient.practice_id = oct_doctor.practice_id.ToString();
                                    existing_patient.practice = oct_practice_details.Name;
                                    existing_patient.originating_patient_id = original_patient.id;
                                    existing_patient.originating_practice_id = original_patient.practice_id;
                                    existing_patient.originating_practice_name = patient_practice_name.name;

                                    patients.Add(existing_patient);
                                }
                            }
                        }
                        else
                        {
                            cls_Save_Case_Property.Invoke(dbConnection, dbTransaction, new P_CAS_SCP_1308()
                            {
                                case_id = latest_oct_planned_action_id.CaseID,
                                property_gpm_id = ECaseProperty.SubmitOctUntilDate.Value(),
                                property_name = "Submit OCT until date",
                                property_string_value = String.Format("{0};{1};{2};{3}", submit_oct_until_date.ToString("yyyy-MM-ddTHH:mm:ss"), latest_oct_planned_action_id.DoctorBptID, localization, latest_oct_planned_action_id.PlannedActionID)
                            }, securityTicket);
                        }
                    }
                    else
                    {
                        var rejected_oct_property = cls_Get_CasePropertyValue_for_CaseID_and_CasePropertyGpmID.Invoke(dbConnection, dbTransaction, new P_CAS_GCPVfCIDaCGpmID_1346()
                        {
                            CaseID = latest_case.CaseID,
                            PropertyGpmID = ECaseProperty.HasRejectedOct.Value()
                        }, securityTicket).Result;

                        if (rejected_oct_property != null)
                        {
                            ORM_HEC_CAS_Case_UniversalPropertyValue.Query.SoftDelete(dbConnection, dbTransaction, new ORM_HEC_CAS_Case_UniversalPropertyValue.Query()
                            {
                                HEC_CAS_Case_UniversalPropertyValueID = rejected_oct_property.ID,
                                Tenant_RefID = securityTicket.TenantID,
                                IsDeleted = false
                            });

                            cls_Create_OCT.Invoke(dbConnection, dbTransaction, new P_CAS_COCT_1703()
                            {
                                case_id = latest_case.CaseID,
                                oct_action_type_id = oct_planned_action_type_id,
                                oct_bpt_id = oct_doctor.doctor_bpt_id,
                                patient_id = patient_id,
                                treatment_date = case_details.treatment_date
                            }, securityTicket);

                            cls_Calculate_Case_GPOS.Invoke(dbConnection, dbTransaction, new P_CAS_CCGPOS_1000()
                            {
                                case_id = case_details.case_id,
                                diagnose_id = case_details.diagnose_id,
                                drug_id = case_details.drug_id,
                                patient_id = patient_id,
                                localization = localization,
                                treatment_date = case_details.treatment_date,
                                oct_doctor_id = oct_doctor_id
                            }, securityTicket);
                        }
                        else if (submit_oct_until_date != DateTime.MinValue)
                        {
                            var latest_oct_planned_action_id = cls_Get_Latest_PlannedActionID_for_PatientID_ActionTypeID_and_LocalizationCode.Invoke(dbConnection, dbTransaction, new P_CAS_GLPAIDfPIDATIDaLC_1545()
                            {
                                ActionTypeID = oct_planned_action_type_id,
                                LocalizationCode = localization,
                                PatientID = patient_id
                            }, securityTicket).Result.FirstOrDefault();

                            if (latest_oct_planned_action_id != null)
                            {
                                cls_Save_Case_Property.Invoke(dbConnection, dbTransaction, new P_CAS_SCP_1308()
                                {
                                    case_id = latest_oct_planned_action_id.CaseID,
                                    property_gpm_id = ECaseProperty.SubmitOctUntilDate.Value(),
                                    property_name = "Submit OCT until date",
                                    property_string_value = String.Format("{0};{1};{2};{3}", submit_oct_until_date.ToString("yyyy-MM-ddTHH:mm:ss"), latest_oct_planned_action_id.DoctorBptID, localization, latest_oct_planned_action_id.PlannedActionID)
                                }, securityTicket);

                                cls_Create_OCT.Invoke(dbConnection, dbTransaction, new P_CAS_COCT_1703()
                                {
                                    case_id = latest_oct_planned_action_id.CaseID,
                                    oct_action_type_id = oct_planned_action_type_id,
                                    oct_bpt_id = oct_doctor.doctor_bpt_id,
                                    patient_id = patient_id,
                                    treatment_date = case_details.treatment_date
                                }, securityTicket);

                                cls_Calculate_Case_GPOS.Invoke(dbConnection, dbTransaction, new P_CAS_CCGPOS_1000()
                                {
                                    case_id = latest_oct_planned_action_id.CaseID,
                                    diagnose_id = case_details.diagnose_id,
                                    drug_id = case_details.drug_id,
                                    patient_id = patient_id,
                                    localization = localization,
                                    treatment_date = case_details.treatment_date,
                                    oct_doctor_id = oct_doctor_id
                                }, securityTicket);
                            }
                        }
                        else
                        {
                            var existing_oct = Retrieve_Octs.GetOctsWhereFieldsHaveValues(new List<FieldValueParameter>() {
                                new FieldValueParameter() { FieldName = "localization", FieldValue = localization },
                                new FieldValueParameter() { FieldName = "patient_id", FieldValue = patient_id.ToString() },
                                new FieldValueParameter() { FieldName = "status.lower_case_sort", FieldValue = "oct4", Negation = true },
                            }, null, elastic_index).SingleOrDefault();

                            if (existing_oct != null)
                            {
                                var oct_planned_action = ORM_HEC_ACT_PlannedAction.Query.Search(dbConnection, dbTransaction, new ORM_HEC_ACT_PlannedAction.Query()
                                {
                                    HEC_ACT_PlannedActionID = Guid.Parse(existing_oct.id),
                                    Tenant_RefID = securityTicket.TenantID,
                                    IsDeleted = false
                                }).Single();
                                previous_doctor_bpt_id = oct_planned_action.ToBePerformedBy_BusinessParticipant_RefID;
                                oct_planned_action.ToBePerformedBy_BusinessParticipant_RefID = oct_doctor.doctor_bpt_id;
                                oct_planned_action.Save(dbConnection, dbTransaction);
                            }
                        }
                    }

                    var patient = Retrieve_Patients.Get_Patient_for_PatientID(patient_id.ToString(), securityTicket);
                    if (patient != null)
                    {
                        patient.has_rejected_oct = false;
                        patients.Add(patient);
                    }

                    if (patients.Any())
                    {
                        Add_New_Patient.Import_Patients_to_ElasticDB(patients, elastic_index);
                    }

                    var elasticRefresher = new ElasticRefresher(new Guid[] { patient_id }, dbConnection, dbTransaction, securityTicket, true);
                    elasticRefresher
                        .UpdateOct()
                        .RebuildElastic();

                    dbTransaction.Commit();

                    Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, new
                    {
                        OctDoctorID = oct_doctor_id,
                        PatientID = patient_id,
                        IsLeftEye = is_left_eye,
                        WithdrawOct = withdraw_oct,
                        SubmitOctUntilDate = submit_oct_until_date_string
                    },
                    new
                    {
                        OctDoctorBptID = previous_doctor_bpt_id,
                        PatientID = patient_id,
                        IsLeftEye = is_left_eye
                    }), data.PracticeName);
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

        #region Validation

        public bool ValidateOctDate(string oct_date, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var request = HttpContext.Current.Request;
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(request);

            transaction = new TransactionalInformation();
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            List<Guid> response = new List<Guid>();
            try
            {
                var oct_datetime = DateTime.ParseExact(oct_date, "dd.MM.yyyy", new System.Globalization.CultureInfo("de", true)).Date;

                if (oct_datetime.Date > DateTime.Now.Date)
                {
                    return false;
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

        public List<ConsentValidationResponse> ValidateOctSubmission(Guid oct_id, Guid case_id, string oct_date, bool is_resubmit, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var request = HttpContext.Current.Request;
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(request);

            transaction = new TransactionalInformation();
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;
            var dbConnection = DBSQLSupport.CreateConnection(connectionString);
            DbTransaction dbTransaction = null;
            var result = new List<ConsentValidationResponse>();

            try
            {
                dbConnection.Open();
                dbTransaction = dbConnection.BeginTransaction();

                var practiceHasOctDevice = cls_Get_Practice_PropertyValue_for_PropertyName_and_PracticeID.Invoke(dbConnection, dbTransaction, new P_DO_GPPVfPNaPID_0916()
                {
                    PracticeID = data.PracticeID,
                    PropertyName = "Practice has OCT device"
                }, securityTicket).Result;

                if (practiceHasOctDevice == null || !practiceHasOctDevice.BooleanValue)
                {
                    result.Add(new ConsentValidationResponse() { message = "LABEL_NO_OCT_DEVICE_IN_PRACTICE" });
                    return result;
                }

                var oct_gposes = cls_Get_GposIDs_for_GposType.Invoke(dbConnection, dbTransaction, new P_MD_GGpoIDsfGposT_1145() { GposType = EGposType.Oct.Value() }, securityTicket).Result;
                if (!oct_gposes.Any())
                {
                    result.Add(new ConsentValidationResponse() { message = "LABEL_NO_OCT_CONTRACT" });
                    return result;
                }

                var treatment_data = cls_Get_Case_Treatment_Data_for_CaseID.Invoke(dbConnection, dbTransaction, new P_CAS_GCTDfCID_1143() { CaseID = case_id }, securityTicket).Result;

                var oct_localization = treatment_data.localization;
                if (is_resubmit)
                {
                    var oct_performed_action_data = cls_Get_PerformedActionDate_for_PlannedActionID.Invoke(dbConnection, dbTransaction, new P_CAS_GPADfPAID_1613() { ActionID = oct_id }, securityTicket).Result;
                    oct_localization = oct_performed_action_data.localization;
                }

                var oct_datetime = DateTime.ParseExact(oct_date, "dd.MM.yyyy", new System.Globalization.CultureInfo("de", true)).Date;

                if (oct_datetime.Date > DateTime.Now.Date)
                {
                    result.Add(new ConsentValidationResponse() { message = "LABEL_CANT_SUBMIT_OCT_IN_FUTURE", date = oct_date });
                    return result;
                }

                var oct_gpos_ids = oct_gposes.Select(t => t.GposID).ToArray();

                var case_props = cls_Get_Case_Properties_for_CaseID.Invoke(dbConnection, dbTransaction, new P_CAS_GCPfCID_1204() { CaseID = case_id }, securityTicket).Result;
                var missing_ivom_case = case_props.SingleOrDefault(t => t.property_gpmid == ECaseProperty.MissingIvom.Value());
                if (missing_ivom_case != null)
                {
                    result.Add(new ConsentValidationResponse() { message = "LABEL_CANT_SUBMIT_OCT_SINCE_IVOM_AUTO_GENERATED", date = oct_date });
                    return result;
                }

                #region Consents

                var patient_consents = cls_Get_Patient_Consents_before_Date_and_GposIDs.Invoke(dbConnection, dbTransaction, new P_PA_GPCbDaGposIDs_1154()
                {
                    Date = oct_datetime,
                    GposIDs = oct_gpos_ids,
                    PatientID = treatment_data.patient_id
                }, securityTicket).Result;

                if (!patient_consents.Any())
                {
                    var patient_details = cls_Get_Patient_Details_for_PatientID.Invoke(dbConnection, dbTransaction, new P_P_PA_GPDfPID_1124() { PatientID = treatment_data.patient_id }, securityTicket).Result;
                    result.Add(new ConsentValidationResponse()
                    {
                        message = "LABEL_PATIENT_HAS_NO_CONSENT_ON_AN_OCT_CONTRACT",
                        name = String.Format("{0} {1}", patient_details.patient_first_name, patient_details.patient_last_name),
                        date = oct_date
                    });

                    return result;
                }

                var oct_planned_action_type_id = cls_Get_ActionTypeID.Invoke(dbConnection, dbTransaction, new P_CAS_GATID_1514()
                {
                    action_type_gpmid = EActionType.PlannedOct.Value()
                }, securityTicket).Result;

                var oct_planned_action = ORM_HEC_ACT_PlannedAction.Query.Search(dbConnection, dbTransaction, new ORM_HEC_ACT_PlannedAction.Query()
                {
                    HEC_ACT_PlannedActionID = oct_id
                }).Single();

                var oct_doctor = cls_Get_Case_DoctorData_for_DoctorBptID.Invoke(dbConnection, dbTransaction, new P_CAS_GCDDfDBptID_1242()
                {
                    DoctorBptID = oct_planned_action.ToBePerformedBy_BusinessParticipant_RefID
                }, securityTicket).Result;

                var doctor_consents = cls_Get_Doctor_Consents_before_Date_and_GposIDs.Invoke(dbConnection, dbTransaction, new P_DO_GDCbDaGposIDs_1154()
                {
                    Date = oct_datetime,
                    DoctorID = oct_doctor.id,
                    GposIDs = oct_gpos_ids
                }, securityTicket).Result;

                if (!doctor_consents.Any())
                {
                    result.Add(new ConsentValidationResponse()
                    {
                        message = "LABEL_DOCTOR_HAS_NO_CONSENT_ON_AN_OCT_CONTRACT",
                        name = GenericUtils.GetDoctorName(oct_doctor),
                        date = oct_date
                    });
                    return result;
                }

                if (!doctor_consents.Any(t => t.consent_valid_through == DateTime.MinValue ? true : t.consent_valid_through.Date >= oct_datetime))
                {
                    result.Add(new ConsentValidationResponse()
                    {
                        message = "LABEL_DOCTOR_HAS_NO_VALID_CONSENT_ON_AN_OCT_CONTRACT",
                        name = GenericUtils.GetDoctorName(oct_doctor),
                        date = oct_date
                    });
                    return result;
                }

                var treatment_year_start_date = cls_Get_TreatmentYear.Invoke(dbConnection, dbTransaction, new P_CAS_GTY_1125()
                {
                    Date = oct_datetime,
                    LocalizationCode = oct_localization,
                    PatientID = treatment_data.patient_id,
                    DoctorID = oct_doctor.id
                }, securityTicket).Result;

                var all_contract_parameters = ORM_CMN_CTR_Contract_Parameter.Query.Search(dbConnection, dbTransaction, new ORM_CMN_CTR_Contract_Parameter.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).GroupBy(t => t.Contract_RefID).ToDictionary(t => t.Key, t => t);

                var op_dates = cls_Get_PerformedOpDates_for_PatientID_and_LocalizationCode.Invoke(dbConnection, dbTransaction, new P_CAS_GPOpDfPIDaLC_1042()
                {
                    LocalizationCode = oct_localization,
                    PatientID = treatment_data.patient_id
                }, securityTicket).Result;

                PA_GPCbDaGposIDs_1154 active_consent = null;

                var last_consent = patient_consents.First();


                var is_consent_auto_renewed_by_op = all_contract_parameters[last_consent.contract_id].Any(p => p.ParameterName == "OP renews patient consent");
                var consent_valid_for_months = all_contract_parameters[last_consent.contract_id].SingleOrDefault(p => p.ParameterName == "Duration of participation consent – Month");

                #region check contract and doctors parameters
                var useSettlementYear = all_contract_parameters[last_consent.contract_id].Any(t => t.ParameterName == EContractParameter.UseSettlementYear.Value());
                var doctorNeedsCertificate = all_contract_parameters[last_consent.contract_id].Any(t => t.ParameterName == EContractParameter.DoctorNeedCertification.Value());


                var doctorHasCertificate = false;
                var doctorCertificateValidFrom = DateTime.MinValue;

                if (doctorNeedsCertificate && oct_doctor.id != Guid.Empty)
                {
                    IFormatProvider culture = new System.Globalization.CultureInfo("de", true);
                    var doctor_properties = cls_Get_Doctors_Properties_for_DoctorID.Invoke(dbConnection, dbTransaction, new P_DO_GDPfDID_1016 { DoctorID = oct_doctor.id }, securityTicket).Result;

                    var is_certificated_for_oct = doctor_properties.SingleOrDefault(x => x.GlobalPropertyMatchingID == EDoctorPropertyType.OctCertificated.Value());
                    doctorHasCertificate = is_certificated_for_oct != null ? is_certificated_for_oct.Value_Boolean : false;

                    var oct_valid_from = doctor_properties.SingleOrDefault(x => x.GlobalPropertyMatchingID == EDoctorPropertyType.OctValidFrom.Value());
                    var validFrom = oct_valid_from != null ? oct_valid_from.Value_String : null;
                    if (validFrom != null)
                    {
                        doctorCertificateValidFrom = DateTime.Parse(validFrom, culture, System.Globalization.DateTimeStyles.AssumeLocal);
                    }
                }

                if (doctorNeedsCertificate)
                {
                    if (doctorHasCertificate && doctorCertificateValidFrom != DateTime.MinValue)
                    {
                        if (oct_datetime.Date < doctorCertificateValidFrom)
                        {
                            result.Add(new ConsentValidationResponse()
                            {
                                message = "LABEL_DOCTOR_DONT_HAVE_CREDENTIONALS_FOR_DATE",
                                name = GenericUtils.GetDoctorName(oct_doctor),
                                date = oct_date
                            });
                            return result;
                        }
                    }
                    else
                    {
                        result.Add(new ConsentValidationResponse()
                        {
                            message = "LABEL_DOCTOR_DONT_HAVE_CREDENTIONALS_FOR_DATE",
                            name = GenericUtils.GetDoctorName(oct_doctor),
                            date = oct_date
                        });
                        return result;
                    }
                }
                #endregion


                var last_consent_valid_to = last_consent.consent_valid_from.Date.AddMonths(Convert.ToInt32(consent_valid_for_months.IfNumericValue_Value));
                var last_consent_timespan = "";
                if (last_consent_valid_to >= oct_datetime)
                {
                    active_consent = last_consent;
                }
                else if (is_consent_auto_renewed_by_op)
                {
                    var localization_op_dates = cls_Get_PerformedOpDates_for_PatientID.Invoke(dbConnection, dbTransaction, new P_CAS_GPOpDfPID_0959()
                    {
                        PatientID = treatment_data.patient_id
                    }, securityTicket).Result;

                    if (localization_op_dates.Any())
                    {
                        var last_op_date = localization_op_dates.First();
                        var last_consent_valid_until = last_op_date.treatment_date.Date.AddMonths(Convert.ToInt32(consent_valid_for_months.IfNumericValue_Value));
                        if (last_consent_valid_until > oct_datetime)
                        {
                            active_consent = last_consent;
                        }
                        else
                        {
                            last_consent_timespan = String.Format("{0} - {1}", last_op_date.treatment_date.ToString("dd.MM.yyyy"), last_consent_valid_until.AddDays(-1).ToString("dd.MM.yyyy"));
                        }
                    }
                }

                if (active_consent == null)
                {
                    var patient_details = cls_Get_Patient_Details_for_PatientID.Invoke(dbConnection, dbTransaction, new P_P_PA_GPDfPID_1124() { PatientID = treatment_data.patient_id }, securityTicket).Result;
                    var op_doctor_id = cls_Get_Treatment_DoctorID_for_CaseID.Invoke(dbConnection, dbTransaction, new P_CAS_GTDIDfCID_1650 { CaseID = case_id }, securityTicket).Result.treatment_doctor_id;

                    if (is_consent_auto_renewed_by_op || oct_doctor.id == op_doctor_id)
                    {
                        result.Add(new ConsentValidationResponse()
                        {
                            message = "LABEL_PATIENT_HAS_NO_VALID_CONSENT_ON_AN_OCT_CONTRACT",
                            name = String.Format("{0} {1}", patient_details.patient_first_name, patient_details.patient_last_name),
                            date = oct_date,
                            consent_timespan = last_consent_timespan
                        });
                    }
                    else
                    {
                        #region get op doctor contacts
                        var op_doctor_details = cls_Get_Doctor_Details_for_DoctorID.Invoke(connectionString, new P_DO_GDDfDID_0823 { DoctorID = op_doctor_id }, securityTicket).Result.Single();

                        var op_doctor_mail = "";
                        var op_doctor_phone = "";

                        if (op_doctor_details.DoctorComunication.Where(k => k.Type == "Phone").SingleOrDefault() != null)
                            op_doctor_phone = op_doctor_details.DoctorComunication.Where(k => k.Type == "Phone").Single().Content;

                        if (op_doctor_details.DoctorComunication.Where(k => k.Type == "Email").SingleOrDefault() != null)
                            op_doctor_mail = op_doctor_details.DoctorComunication.Where(k => k.Type == "Email").Single().Content;
                        #endregion

                        #region get response message
                        var message = "LABEL_NO_VALID_CONSENT_CONTACT_DOCTOR";
                        if (string.IsNullOrEmpty(op_doctor_mail) && string.IsNullOrEmpty(op_doctor_phone))
                        {
                            message = "LABEL_NO_VALID_CONSENT_CONTACT_DOCTOR_WOE_WOP";
                        }
                        else if (string.IsNullOrEmpty(op_doctor_mail) && !string.IsNullOrEmpty(op_doctor_phone))
                        {
                            message = "LABEL_NO_VALID_CONSENT_CONTACT_DOCTOR_WOE_WP";
                        }
                        else if (!string.IsNullOrEmpty(op_doctor_mail) && string.IsNullOrEmpty(op_doctor_phone))
                        {
                            message = "LABEL_NO_VALID_CONSENT_CONTACT_DOCTOR_WE_WOP";
                        }
                        #endregion

                        result.Add(new ConsentValidationResponse()
                        {
                            message = message,
                            name = String.Format("{0} {1}", patient_details.patient_first_name, patient_details.patient_last_name),
                            date = oct_date,
                            consent_timespan = last_consent_timespan,
                            op_doctor_name = String.Format("{0} {1}", op_doctor_details.first_name, op_doctor_details.last_name),
                            op_doctor_email = op_doctor_mail,
                            op_doctor_phone = op_doctor_phone,
                            hip_name = patient_details.health_insurance_provider,
                            is_warning_message = true
                        });
                    }
                    return result;
                }
                #endregion Consents

                var contract_parameters = all_contract_parameters[active_consent.contract_id];
                var treatment_year_length_ctr_parameter = contract_parameters.SingleOrDefault(t => t.ParameterName == EContractParameter.PreexaminationsDays.Value());
                var treatment_year_length = treatment_year_length_ctr_parameter != null ? treatment_year_length_ctr_parameter.IfNumericValue_Value : 365;
                var max_number_of_preexaminations = contract_parameters.SingleOrDefault(t => t.ParameterName == EContractParameter.MaxNumberOfOcts.Value());
                var treatment_year_end_date = treatment_year_start_date.Date.AddDays(treatment_year_length - 1);
                useSettlementYear = contract_parameters.SingleOrDefault(t => t.ParameterName == EContractParameter.UseSettlementYear.Value()) != null;

                #region Max OCT's per treatment year

                if (max_number_of_preexaminations != null)
                {
                    var current_performed_octs_count = cls_Get_TreatmentYearOctCount.Invoke(dbConnection, dbTransaction, new P_CAS_GTYOctC_1939()
                    {
                        LocalizationCode = oct_localization,
                        OctPlannedActionTypeID = oct_planned_action_type_id,
                        PatientID = treatment_data.patient_id,
                        TreatmentYearStartDate = treatment_year_start_date,
                        TreatmentYearEndDate = treatment_year_end_date,
                        OctActionIdToOmit = is_resubmit ? oct_id : Guid.Empty
                    }, securityTicket).Result.fs_status_count;

                    if (useSettlementYear)
                    {
                        var orher_localization = oct_localization == "L" ? "R" : "L";

                        current_performed_octs_count += cls_Get_TreatmentYearOctCount.Invoke(dbConnection, dbTransaction, new P_CAS_GTYOctC_1939()
                        {
                            LocalizationCode = orher_localization,
                            OctPlannedActionTypeID = oct_planned_action_type_id,
                            PatientID = treatment_data.patient_id,
                            TreatmentYearStartDate = treatment_year_start_date,
                            TreatmentYearEndDate = treatment_year_end_date,
                            OctActionIdToOmit = is_resubmit ? oct_id : Guid.Empty
                        }, securityTicket).Result.fs_status_count;
                    }

                    var is_limit_exceeded = current_performed_octs_count >= max_number_of_preexaminations.IfNumericValue_Value;
                    if (is_limit_exceeded)
                    {
                        result.Add(new ConsentValidationResponse()
                        {
                            message = "LABEL_OCT_COUNT_PER_TREATMENT_YEAR_EXCEEDED",
                            max_count = max_number_of_preexaminations.IfNumericValue_Value.ToString(),
                            date = treatment_year_start_date.AddDays(treatment_year_length).ToString("dd.MM.yyyy")
                        });

                        return result;
                    }
                }

                #endregion Max OCT's per treatment year

                var contract_details = ORM_CMN_CTR_Contract.Query.Search(dbConnection, dbTransaction, new ORM_CMN_CTR_Contract.Query() { CMN_CTR_ContractID = active_consent.contract_id }).Single();

                #region Max days before OP
                var op_dates_ordered = op_dates.OrderBy(t => t.treatment_date).ToList();

                var gaps = op_dates_ordered.Where(t =>
                {
                    var isLast = op_dates_ordered.Last().treatment_date == t.treatment_date;
                    if (isLast)
                    {
                        return false;
                    }

                    var gapExists = !op_dates.Any(r => r.treatment_date > t.treatment_date && r.treatment_date < t.treatment_date.AddDays(treatment_year_length));
                    return useSettlementYear ? gapExists && !t.is_op : gapExists && t.is_op;
                }).ToList();

                var first_op_date_in_treatment_year = gaps.Select(t => t.treatment_date).Where(t => t <= oct_datetime).DefaultIfEmpty().Max();
                if (first_op_date_in_treatment_year == DateTime.MinValue && op_dates_ordered.Any())
                {
                    first_op_date_in_treatment_year = op_dates_ordered.First(t => t.is_op).treatment_date;
                }

                var first_op_in_treatment_year = op_dates.FirstOrDefault(t => t.is_op && t.treatment_date == first_op_date_in_treatment_year);
                if (first_op_in_treatment_year != null)
                {
                    if (oct_datetime.Date < first_op_in_treatment_year.treatment_date.Date)
                    {
                        var active_oct_fs_statuses = cls_Get_OctFsStatuses_for_PatientID_in_TimeSpan.Invoke(dbConnection, dbTransaction, new P_CAS_GOctFSSfPIDiTS_1103s()
                        {
                            DateFrom = first_op_date_in_treatment_year.AddDays(-treatment_year_length),
                            DateTo = first_op_date_in_treatment_year,
                            LocalizationCode = treatment_data.localization,
                            PatientID = treatment_data.patient_id
                        }, securityTicket).Result;

                        if (active_oct_fs_statuses.Any(t => t.fs_status != 8 && t.fs_status != 11 && t.fs_status != 17))
                        {
                            var case_performed_octs = cls_Get_OctPerformedDates_for_PatientID.Invoke(dbConnection, dbTransaction, new P_CAS_GOctPDfPID_0908()
                            {
                                PatientID = treatment_data.patient_id,
                                ActionTypeID = oct_planned_action_type_id
                            }, securityTicket).Result.Where(t => t.localization == treatment_data.localization && t.perfromed_on_date.Date <= first_op_in_treatment_year.treatment_date.Date && t.action_id != oct_id).ToList();

                            for (var i = 0; i < case_performed_octs.Count; i++)
                            {
                                var performed_oct_date = case_performed_octs[i].perfromed_on_date;
                                var fs_status = active_oct_fs_statuses[i].fs_status;

                                if (fs_status != 8 && fs_status != 11 && fs_status != 17)
                                {
                                    result.Add(new ConsentValidationResponse()
                                    {
                                        message = "LABEL_OCT_BEFORE_FIRST_OP_ALREADY_EXISTS",
                                        date = first_op_in_treatment_year.treatment_date.Date.ToString("dd.MM.yyyy"),
                                        first_oct_date = performed_oct_date.ToString("dd.MM.yyyy")
                                    });

                                    return result;
                                }
                            }
                        }
                    }

                    var max_days_before_op = contract_parameters.SingleOrDefault(t => t.ParameterName == "OCT - Max number of days before OP");
                    if (max_days_before_op != null)
                    {
                        var max_oct_date_before_op = first_op_in_treatment_year.treatment_date.AddDays(-max_days_before_op.IfNumericValue_Value).Date;
                        if (max_days_before_op != null && max_oct_date_before_op > oct_datetime.Date)
                        {
                            result.Add(new ConsentValidationResponse()
                            {
                                message = "LABEL_OCT_TOO_FAR_BEFORE_OP",
                                date = max_oct_date_before_op.ToString("dd.MM.yyyy")
                            });

                            return result;
                        }
                    }
                }

                #endregion Max days before OP

                #region Max date for submission

                var treatment_constraint_parameter = contract_parameters.SingleOrDefault(cp => cp.ParameterName == EContractParameter.NumberOfDaysBetweenTreatmentAndSettlement.Value() && cp.IsNumericValue);
                var treatment_constraint = treatment_constraint_parameter != null ? treatment_constraint_parameter.IfNumericValue_Value : double.MaxValue;
                var max_date_for_submission = DateTime.MaxValue;

                max_date_for_submission = treatment_constraint_parameter != null && treatment_constraint != double.MaxValue ? oct_datetime.AddDays(treatment_constraint) : DateTime.MaxValue;

                if (oct_datetime < contract_details.ValidFrom || (!is_resubmit && DateTime.Now.Date > max_date_for_submission))
                {
                    result.Add(new ConsentValidationResponse()
                    {
                        message = "LABEL_OCT_DATE_OUTSIDE_OF_SUBMISSION_TIMESPAN",
                        date = oct_date,
                        consent_timespan = max_date_for_submission.ToString("dd.MM.yyyy")
                    });

                    return result;
                }

                #endregion Max date for submission

                #region Submit oct only up to 365 days after last ivom
                var latest_op_date = op_dates.Select(t => t.treatment_date).DefaultIfEmpty().Max();
                if (latest_op_date != DateTime.MinValue)
                {
                    var latest_op_date_plus_treatment_year_length = latest_op_date.AddDays(treatment_year_length);
                    if (oct_datetime > latest_op_date_plus_treatment_year_length)
                    {
                        result.Add(new ConsentValidationResponse()
                        {
                            message = "LABEL_OCT_CAN_BE_SUBMITTED_ONLY_UNTIL_LATE",
                            date = latest_op_date_plus_treatment_year_length.ToString("dd.MM.yyyy"),
                            treatment_year_length = treatment_year_length
                        });

                        return result;

                    }
                }


                #endregion

                #region Submit until date

                var submit_until_date_case_properties = cls_Get_SubmitUntilDate_CasePropertyValues_for_PatientID.Invoke(dbConnection, dbTransaction, new P_CAS_GSUDCPVfPID_1438() { PatientID = treatment_data.patient_id }, securityTicket).Result;

                foreach (var submit_until_date_case_property in submit_until_date_case_properties)
                {
                    var string_parts = submit_until_date_case_property.property_string_value.Split(';');
                    var date_part = string_parts[0];
                    var doctor_bpt_id_part = string_parts[1];
                    var localization = string_parts[2];
                    if (localization == oct_localization)
                    {
                        var submit_until_date = DateTime.Parse(date_part);
                        var doctor_bpt_id = Guid.Parse(doctor_bpt_id_part);

                        if (oct_planned_action.ToBePerformedBy_BusinessParticipant_RefID == doctor_bpt_id)
                        {
                            if (submit_until_date.Date < oct_datetime.Date)
                            {
                                result.Add(new ConsentValidationResponse()
                                {
                                    message = "LABEL_DOCTOR_CAN_ONLY_SUBMIT_OCT_UNTIL_DATE",
                                    name = GenericUtils.GetDoctorName(oct_doctor),
                                    date = submit_until_date.ToString("dd.MM.yyyy")
                                });

                                return result;
                            }
                        }
                    }
                }

                #endregion Submit until date

                dbTransaction.Commit();
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

            return result;
        }

        public List<Guid> ValidateConsentsMultiSubmit(IEnumerable<Guid> oct_ids, string oct_date, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var request = HttpContext.Current.Request;
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(request);

            transaction = new TransactionalInformation();
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            List<Guid> response = new List<Guid>();
            try
            {
                var dbConnection = DBSQLSupport.CreateConnection(connectionString);
                DbTransaction dbTransaction = null;

                try
                {
                    dbConnection.Open();
                    dbTransaction = dbConnection.BeginTransaction();

                    var case_ids = cls_Get_OctCaseIDs_for_ActionIDs.Invoke(dbConnection, dbTransaction, new P_CAS_GOctCIDsfAIDs_1047() { ActionIDs = oct_ids.ToArray() }, securityTicket).Result.ToDictionary(t => t.action_id, t => t.case_id);

                    foreach (var oct_id in oct_ids)
                    {
                        var validation_response = ValidateOctSubmission(oct_id, case_ids[oct_id], oct_date, false, connectionString, sessionTicket, out transaction);
                        if (!validation_response.Any())
                        {
                            response.Add(oct_id);
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

            return response;
        }

        public IEnumerable<MultiSubmitOctObject> InitiateOctMultiSubmit(ElasticParameterObjectMultiSubmit parameter, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var request = HttpContext.Current.Request;
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(request);

            transaction = new TransactionalInformation();
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            var response = new List<MultiSubmitOctObject>();
            try
            {
                var dbConnection = DBSQLSupport.CreateConnection(connectionString);
                DbTransaction dbTransaction = null;

                try
                {
                    dbConnection.Open();
                    dbTransaction = dbConnection.BeginTransaction();

                    var oct_ids = parameter.selected_ids.ToArray();
                    if (parameter.all_selected || parameter.deselected_ids.Any())
                    {
                        parameter.omit_withdrawn = true;
                        var rangeParameters = GetRangeParameters(dbConnection, dbTransaction, securityTicket);

                        oct_ids = Retrieve_Octs.GetAllOcts(data.PracticeID, parameter, securityTicket, rangeParameters).Select(t => Guid.Parse(t.id)).ToArray();
                    }

                    if (oct_ids.Any())
                    {
                        var doctor_assignments = cls_Get_DoctorAssignmentActionIDs_for_ActionIDs.Invoke(dbConnection, dbTransaction, new P_CAS_GDAAIDsfAIDs_0851() { ActionIDs = oct_ids }, securityTicket).Result;
                        if (doctor_assignments.Any())
                        {
                            if (parameter.oct_doctor_id != Guid.Empty)
                            {
                                response.Add(new MultiSubmitOctObject()
                                {
                                    count = 1,
                                    doctor_id = parameter.oct_doctor_id,
                                    oct_ids = doctor_assignments.Select(t => t.action_id)
                                });
                            }
                            else
                            {
                                var doctor_assignments_grouped = doctor_assignments.GroupBy(t => t.doctor_id).ToDictionary(t => t.Key, t => t.ToList());
                                response = doctor_assignments_grouped.Select(t => new MultiSubmitOctObject()
                                {
                                    doctor_id = t.Key,
                                    oct_ids = t.Value.Select(x => x.action_id),
                                    count = t.Value.Count
                                }).ToList();
                            }
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

            return response;
        }

        public MulitiSubmitValidation CheckIfAlreadyExistOCT(IEnumerable<Guid> oct_ids, string oct_date, bool is_resubmit, string connectionString, string sessionTicket, out TransactionalInformation transaction)
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
                if (!oct_ids.Any())
                {
                    return new MulitiSubmitValidation();
                }

                var culture = new System.Globalization.CultureInfo("de", true);
                var octDate = DateTime.Parse(oct_date, culture, System.Globalization.DateTimeStyles.AssumeLocal);

                var octPlannedActionTypeID = cls_Get_ActionTypeID.Invoke(dbConnection, dbTransaction, new P_CAS_GATID_1514()
                {
                    action_type_gpmid = EActionType.PlannedOct.Value()
                }, securityTicket).Result;

                var octPerformedActionTypeID = cls_Get_ActionTypeID.Invoke(dbConnection, dbTransaction, new P_CAS_GATID_1514()
                {
                    action_type_gpmid = EActionType.PerformedOct.Value()
                }, securityTicket).Result;

                var excludeFSStatuses = new List<int>() { 8, 11, 17 };
                var duplicateCases = new List<Guid>();

                var allOCTsForSubmit = cls_Get_Oct_Basic_Info_for_OctIDs.Invoke(dbConnection, dbTransaction, new P_CAS_GOBIfOIDs_1435
                {
                    ActionTypeID = octPlannedActionTypeID,
                    OctIDs = oct_ids.ToArray()
                }, securityTicket).Result;


                var allSubmittedCasesForPatients = new List<CAS_GCIDsfPaL_1307>();

                if (allOCTsForSubmit.Any())
                {
                    allSubmittedCasesForPatients = cls_Get_CaseIDs_for_Patient_and_Localization.Invoke(dbConnection, dbTransaction, new P_CAS_GCIDsfPaL_1307
                    {
                        PatientIDs = allOCTsForSubmit.Select(x => x.PatientID).Distinct().ToArray(),
                        ActionTypeID = octPlannedActionTypeID
                    }, securityTicket).Result.ToList();
                }

                var numberOfInvalidCases = 0;
                var validOcts = new List<CAS_GOBIfOIDs_1435>();

                if (allSubmittedCasesForPatients.Any())
                {
                    foreach (var oct in allOCTsForSubmit)
                    {
                        var alreadyExistSubmitedOCT = false;
                        var allSubmitedOCTsForDate = allSubmittedCasesForPatients.Where(x =>
                        {
                            var matches = x.Date == octDate && x.LocalizationCode == oct.LocalizationCode && x.PatientID == oct.PatientID;
                            if (is_resubmit)
                            {
                                matches = matches && x.PlannedActionID != oct.OctID;
                            }

                            return matches;
                        }).ToList();

                        if (allSubmitedOCTsForDate.Any())
                        {
                            var billCodes = cls_Get_Case_TransmitionCode_for_CaseIDs_and_Type.Invoke(dbConnection, dbTransaction, new P_CAS_GCTCfCIDsaT_1254
                               {
                                   CaseIDs = allSubmitedOCTsForDate.Select(x => x.CaseID).ToArray(),
                                   StatusKey = "oct"
                               }, securityTicket).Result;

                            alreadyExistSubmitedOCT = billCodes.Any(x => !excludeFSStatuses.Contains(x.TransmitionCode));
                        }
                        if (alreadyExistSubmitedOCT)
                        {
                            numberOfInvalidCases++;
                        }
                        else
                        {
                            var alreadyExistInValidList = validOcts.Any(a => a.LocalizationCode == oct.LocalizationCode && a.PatientID == oct.PatientID && a.CaseID != oct.CaseID);
                            if (!alreadyExistInValidList)
                            {
                                validOcts.Add(oct);
                            }
                        }
                    }
                }

                return new MulitiSubmitValidation()
                {
                    number_of_all_cases = oct_ids.Count(),
                    valid_case_ids = allSubmittedCasesForPatients.Any() ? validOcts.Select(x => x.OctID).ToList() : oct_ids.ToList(),
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
        #endregion Validation

        #region Support
        private List<OctHipParameter> GetRangeParameters(DbConnection dbConnection, DbTransaction dbTransaction, SessionSecurityTicket securityTicket, Dictionary<string, List<MD_GHCPoT_1617>> hipData = null)
        {
            if (hipData == null)
            {
                hipData = cls_Get_Hip_Contract_Parameters_on_Tenant.Invoke(dbConnection, dbTransaction, securityTicket).Result.GroupBy(hip => hip.HipIK).ToDictionary(t => t.Key, t => t.ToList());
            }

            var rangeParameters = hipData.Select(t =>
            {
                var result = new OctHipParameter();
                if (t.Value.Any(x => x.ParameterValue != double.MaxValue && x.ParameterValue < 20000000 && x.ParameterValue != 0))
                {
                    try
                    {
                        var treatmentYearLength = Convert.ToInt32(t.Value.First(x => x.ParameterName == EContractParameter.PreexaminationsDays.Value()).ParameterValue);
                        var daysToSubmitOct = Convert.ToInt32(t.Value.First(x => x.ParameterName == EContractParameter.NumberOfDaysBetweenTreatmentAndSettlement.Value()).ParameterValue);
                        var maxOCTs = Convert.ToInt32(t.Value.First(x => x.ParameterName == EContractParameter.MaxNumberOfOcts.Value()).ParameterValue);

                        result.MinimumTreatmentDate = DateTime.Now.AddDays(-(daysToSubmitOct + treatmentYearLength)).ToString("yyyy-MM-dd");
                        result.OverdueDate = DateTime.Now.AddDays(-treatmentYearLength).ToString("yyyy-MM-dd");
                        result.MaxOCTs = maxOCTs.ToString();
                    }
                    catch { }
                }

                result.HipIk = t.Key;

                return result;
            }).ToList();

            return rangeParameters;
        }

        #endregion
    }
}