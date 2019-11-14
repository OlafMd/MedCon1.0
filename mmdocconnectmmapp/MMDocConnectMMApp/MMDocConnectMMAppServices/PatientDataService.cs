using CL1_CMN_CTR;
using CL1_HEC_CAS;
using CL1_HEC_CRT;
using CSV2Core_MySQL.Support;
using DLCore_TokenVerification;
using LogUtils;
using MMDocConnectDBMethods.Case.Atomic.Retrieval;
using MMDocConnectDBMethods.Case.Complex.Retrieval;
using MMDocConnectDBMethods.MainData.Complex.Retrieval;
using MMDocConnectDBMethods.Patient.Atomic.Retrieval;
using MMDocConnectDBMethods.Patient.Complex.Retrieval;
using MMDocConnectDocApp;
using MMDocConnectElasticSearchMethods.Models;
using MMDocConnectElasticSearchMethods.Patient.Manipulation;
using MMDocConnectMMAppInterfaces;
using MMDocConnectMMAppModels;
using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MMDocConnectMMAppServices
{
    public class PatientDataService : BaseVerification, IPatientDataServices
    {
        /// <summary>
        /// get all patients for patients page 
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="connectionString"></param>
        /// <param name="sessionTicket"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public List<PatientModelFront> GetPatients(ElasticParameterObject parameter, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            List<PatientModelFront> patientList = new List<PatientModelFront>();
            transaction = new TransactionalInformation();

            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);
            var securityTicket = VerifySessionToken(sessionTicket);

            try
            {
                var dbConnection = DBSQLSupport.CreateConnection(connectionString);
                DbTransaction dbTransaction = null;

                try
                {
                    dbConnection.Open();
                    dbTransaction = dbConnection.BeginTransaction();
                    var consentsDB = ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingPatient.Query.Search(connectionString, new ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingPatient.Query()
                    {
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    });

                    Dictionary<Guid, DateTime> contractValidToCache = new Dictionary<Guid, DateTime>();
                    Dictionary<Guid, Guid> contractIDCache = new Dictionary<Guid, Guid>();
                    var allContractParameters = ORM_CMN_CTR_Contract_Parameter.Query.Search(dbConnection, dbTransaction, new ORM_CMN_CTR_Contract_Parameter.Query()
                    {
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).GroupBy(t => t.Contract_RefID).ToDictionary(t => t.Key, t => t);

                    Dictionary<Guid, List<ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingPatient>> consentCache = new Dictionary<Guid, List<ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingPatient>>();
                    consentCache = consentsDB.GroupBy(t => t.Patient_RefID).Select(gr => new { id = gr.Key, value = gr.ToList() }).ToDictionary(t => t.id, t => t.value);

                    var start = parameter.start_row_index;
                    var size = 100;
                    var sort_by = parameter.sort_by;

                    if (parameter.sort_by == "participation_consent")
                    {
                        parameter.start_row_index = 0;
                        parameter.page_size = int.MaxValue;
                    }

                    patientList = Retrieve_Patients.Get_Patients_On_Tenant(parameter, securityTicket);
                    if (patientList.Any())
                    {
                        var patient_ids = patientList.Select(t => Guid.Parse(t.id)).ToArray();

                        var op_performed_action_type_id = cls_Get_ActionTypeID.Invoke(dbConnection, dbTransaction, new P_CAS_GATID_1514() { action_type_gpmid = EActionType.PerformedOperation.Value() }, securityTicket).Result;
                        var opDates = cls_Get_PerformedActionData_for_PatientIDs_and_ActionTypeID.Invoke(dbConnection, dbTransaction, new P_CAS_GPADfPIDsaATID_1335()
                        {
                            ActionTypeID = op_performed_action_type_id,
                            PatientIDs = patient_ids
                        }, securityTicket).Result.GroupBy(t => t.patient_id).ToDictionary(t => t.Key, t => t);

                        patientList = patientList.Select(item =>
                        {
                            var todaysDate = DateTime.Now.Date;
                            var patientID = Guid.Parse(item.id);
                            if (consentCache.ContainsKey(patientID))
                            {
                                var hasValidConsent = false;
                                var consents = consentCache[patientID];
                                foreach (var consent in consents)
                                {
                                    var contractID = Guid.Empty;
                                    if (!contractIDCache.ContainsKey(consent.InsuranceToBrokerContract_RefID))
                                    {
                                        contractID = ORM_HEC_CRT_InsuranceToBrokerContract.Query.Search(dbConnection, dbTransaction, new ORM_HEC_CRT_InsuranceToBrokerContract.Query()
                                        {
                                            HEC_CRT_InsuranceToBrokerContractID = consent.InsuranceToBrokerContract_RefID,
                                            IsDeleted = false,
                                            Tenant_RefID = securityTicket.TenantID
                                        }).Single().Ext_CMN_CTR_Contract_RefID;

                                        contractIDCache.Add(consent.InsuranceToBrokerContract_RefID, contractID);
                                    }

                                    contractID = contractIDCache[consent.InsuranceToBrokerContract_RefID];

                                    if (!contractValidToCache.ContainsKey(contractID))
                                    {
                                        contractValidToCache.Add(contractID, ORM_CMN_CTR_Contract.Query.Search(dbConnection, dbTransaction, new ORM_CMN_CTR_Contract.Query()
                                        {
                                            CMN_CTR_ContractID = contractID,
                                            Tenant_RefID = securityTicket.TenantID,
                                            IsDeleted = false
                                        }).Single().ValidThrough);
                                    }

                                    var contractValidTo = contractValidToCache[contractID];

                                    if (allContractParameters.ContainsKey(contractID))
                                    {
                                        double days = 0;

                                        var parameterValue = allContractParameters[contractID].SingleOrDefault(t => t.ParameterName == "Number of days between surgery and aftercare - Days");
                                        if (parameterValue != null && parameterValue.IfNumericValue_Value != double.MaxValue)
                                        {
                                            days = parameterValue.IfNumericValue_Value;
                                        }

                                        var contractParameter = allContractParameters[contractID].SingleOrDefault(t => t.ParameterName == "Duration of participation consent – Month");
                                        var opRenewsConsent = allContractParameters[contractID].Any(p => p.ParameterName == "OP renews patient consent");

                                        if (opRenewsConsent && opDates.ContainsKey(consent.Patient_RefID))
                                        {
                                            var potentialRenewalOp = opDates[consent.Patient_RefID].FirstOrDefault(t => t.treatment_date.Date >= consent.ValidFrom.Date);
                                            if (potentialRenewalOp != null && potentialRenewalOp.treatment_date.Date.AddMonths(Convert.ToInt32(contractParameter.IfNumericValue_Value)).AddDays(-days) >= todaysDate)
                                            {
                                                hasValidConsent = true;
                                                break;
                                            }
                                        }

                                        if (contractParameter != null && contractParameter.IfNumericValue_Value != double.MaxValue)
                                        {
                                            if (consent.ValidFrom <= todaysDate && consent.ValidFrom.AddMonths(Convert.ToInt32(contractParameter.IfNumericValue_Value)).AddDays(-days) >= todaysDate)
                                            {
                                                hasValidConsent = true;
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            if (consent.ValidFrom <= todaysDate && (contractValidTo == DateTime.MinValue || contractValidTo >= todaysDate))
                                            {
                                                hasValidConsent = true;
                                                break;
                                            }
                                        }
                                    }
                                }

                                item.participation_consent_status = hasValidConsent ? "LABEL_ACTIVE_CONSENT" : "LABEL_EXPIRED_CONSENT";
                            }
                            else
                            {
                                item.participation_consent_status = "/";
                            }

                            return item;
                        }).ToList();

                        if (sort_by == "participation_consent")
                        {
                            if (parameter.isAsc)
                            {
                                patientList = patientList.OrderBy(t => t.participation_consent_status).Skip(start).Take(size).ToList();
                            }
                            else
                            {
                                patientList = patientList.OrderByDescending(t => t.participation_consent_status).Skip(start).Take(size).ToList();
                            }
                        }
                    }
                }
                catch
                {
                    if (dbTransaction != null)
                    {
                        dbTransaction.Rollback();
                    }

                    throw;
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
                Logger.LogInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, ex));

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }

            return patientList;
        }
        /// <summary>
        /// Get patient details
        /// </summary>
        /// <param name="isPracticeLoggedIn"></param>
        /// <param name="practiceID"></param>
        /// <param name="id"></param>
        /// <param name="connectionString"></param>
        /// <param name="sessionTicket"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public PatientDetailViewData Get_PatientDetails(Guid id, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            PatientDetailViewData patientDetails = new PatientDetailViewData();
            PatientDetail patient = new PatientDetail();
            List<ContractModel> ContractList = new List<ContractModel>();

            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);
            var securityTicket = VerifySessionToken(sessionTicket);

            transaction = new TransactionalInformation();
            try
            {
                var dataFromDB = cls_Get_PatientData_With_ContractListTenant.Invoke(connectionString, new P_PA_GPDWCLT_1118 { PatientID = id }, securityTicket).Result;
                var data = dataFromDB.PatientData;
                patient.health_insurance_provider = data.health_insurance_provider;
                patient.id = data.id.ToString();
                patient.insurance_id = data.insurance_id;
                patient.insurance_status = data.insurance_status;
                patient.name = data.name;
                patient.birthday = data.birthday.ToString("dd.MM.yyyy");
                patient.cases = data.contract_number.ToString();
                patient.is_privately_insured = dataFromDB.PatientData.insurance_id == "privat";

                var left_eye_localization_code = "L";
                var right_eye_localization_code = "R";

                try
                {
                    var dbConnection = DBSQLSupport.CreateConnection(connectionString);
                    DbTransaction dbTransaction = null;

                    try
                    {
                        dbConnection.Open();
                        dbTransaction = dbConnection.BeginTransaction();

                        #region Fee waiver
                        var fee_waivers = cls_Get_Patient_Properties_for_PatientID_and_PropertyGpmID.Invoke(dbConnection, dbTransaction, new P_PA_GPPfPIDaPGpmID_1620()
                        {
                            PatientID = id,
                            PropertyGpmID = EPatientProperty.FeeWaived.Value()
                        }, securityTicket).Result.Select(t => DateTime.Parse(t.string_value)).ToList();
                        var fee_waiver = fee_waivers.SingleOrDefault(t => t.Year == DateTime.Now.Year);

                        if (fee_waiver != null && fee_waiver != DateTime.MinValue)
                        {
                            patient.fee_waived_from = fee_waiver.ToString("dd.MM.yyyy");
                        }
                        #endregion

                        #region External id
                        var external_id = cls_Get_Patient_Properties_for_PatientID_and_PropertyGpmID.Invoke(dbConnection, dbTransaction, new P_PA_GPPfPIDaPGpmID_1620()
                        {
                            PatientID = id,
                            PropertyGpmID = EPatientProperty.ExternalId.Value()
                        }, securityTicket).Result.SingleOrDefault();

                        if (external_id != null)
                        {
                            patient.external_id = external_id.string_value;
                        }
                        #endregion

                        var patientCaseIDs = ORM_HEC_CAS_Case.Query.Search(dbConnection, dbTransaction, new ORM_HEC_CAS_Case.Query()
                        {
                            Patient_RefID = id,
                            Tenant_RefID = securityTicket.TenantID,
                        }).Select(t => t.HEC_CAS_CaseID).ToArray();
                        
                        if (patientCaseIDs.Any())
                        {
                            var documentation_cases = cls_Get_Case_Properties_for_GpmID.Invoke(dbConnection, dbTransaction, new P_CAS_GCPfGpmID_1235()
                            {
                                PropertyGpmID = ECaseProperty.DocumentationOnly.Value(),
                                PatientID = id
                            }, securityTicket).Result.GroupBy(t => t.CaseID).ToDictionary(t => t.Key, t => t.SingleOrDefault());

                            var excludeFSStatuses = new List<int>() { 8, 11, 17 };
                            var allTreatments = cls_Get_TretmentDates_for_PatientID.Invoke(dbConnection, dbTransaction, new P_CAS_GTDfPID_1509() { PatientID = id, CaseIDs = patientCaseIDs }, securityTicket).Result
                                .Where(x => (documentation_cases.ContainsKey(x.case_id) && documentation_cases[x.case_id].Value_Boolean) || (x.transmition_status_key != null && x.transmition_status_key == "treatment" && !excludeFSStatuses.Any(status => status == x.transmition_code)));

                            var treatments = allTreatments.GroupBy(t => t.localization).ToDictionary(t => t.Key, t => t.ToList());
                            if (treatments.ContainsKey(left_eye_localization_code))
                            {
                                var left_eye_treatments = treatments[left_eye_localization_code];
                                patient.left_eye.latest_op_date = left_eye_treatments.Max(t => t.treatment_date);
                                patient.left_eye.op_count = left_eye_treatments.Count;
                            }

                            if (treatments.ContainsKey(right_eye_localization_code))
                            {
                                var right_eye_treatments = treatments[right_eye_localization_code];
                                patient.right_eye.latest_op_date = right_eye_treatments.Max(t => t.treatment_date);
                                patient.right_eye.op_count = right_eye_treatments.Count;
                            }
                        }

                        var oct_planned_action_type_id = cls_Get_ActionTypeID.Invoke(dbConnection, dbTransaction, new P_CAS_GATID_1514() { action_type_gpmid = EActionType.PlannedOct.Value() }, securityTicket).Result;

                        var latest_left_eye_bill_position = cls_Get_Existing_OCT_BillPosition_for_PatientID_and_LocalizationCode.Invoke(dbConnection, dbTransaction, new P_CAS_GEBPfPIDaLC_1803()
                        {
                            LocalizationCode = left_eye_localization_code,
                            PatientID = id
                        }, securityTicket).Result;

                        if (latest_left_eye_bill_position != null)
                        {
                            var oct_doctor = cls_Get_Latest_Oct_Doctor_for_CaseID.Invoke(dbConnection, dbTransaction, new P_CAS_GLOctDfCID_1644()
                            {
                                PlannedActionTypeID = oct_planned_action_type_id,
                                CaseID = latest_left_eye_bill_position.CaseID
                            }, securityTicket).Result;

                            if (oct_doctor != null)
                            {
                                patient.left_eye.oct_doctor_id = oct_doctor.id;
                                patient.left_eye.oct_doctor_name = GenericUtils.GetDoctorName(oct_doctor);
                            }
                        }

                        var latest_right_eye_bill_position = cls_Get_Existing_OCT_BillPosition_for_PatientID_and_LocalizationCode.Invoke(dbConnection, dbTransaction, new P_CAS_GEBPfPIDaLC_1803()
                        {
                            LocalizationCode = right_eye_localization_code,
                            PatientID = id
                        }, securityTicket).Result;

                        if (latest_right_eye_bill_position != null)
                        {
                            var oct_doctor = cls_Get_Latest_Oct_Doctor_for_CaseID.Invoke(dbConnection, dbTransaction, new P_CAS_GLOctDfCID_1644()
                            {
                                PlannedActionTypeID = oct_planned_action_type_id,
                                CaseID = latest_right_eye_bill_position.CaseID
                            }, securityTicket).Result;

                            if (oct_doctor != null)
                            {
                                patient.right_eye.oct_doctor_id = oct_doctor.id;
                                patient.right_eye.oct_doctor_name = GenericUtils.GetDoctorName(oct_doctor);
                            }
                        }

                        var rejected_oct_localizations = cls_Get_Localizations_where_Oct_Rejected.Invoke(dbConnection, dbTransaction, new P_CAS_GLwOctR_1026()
                        {
                            PatientID = id,
                            RejectedOctPropertyID = ECaseProperty.HasRejectedOct.Value()
                        }, securityTicket).Result;

                        #region Check if oct rejected
                        if (patient.left_eye.oct_doctor_id == Guid.Empty)
                        {
                            var oct_rejected = rejected_oct_localizations.Any(t => t.localization == left_eye_localization_code);
                            if (oct_rejected)
                            {
                                patient.left_eye.oct_doctor_name = "LABEL_REJECTED_OCT";
                            }
                        }

                        if (patient.right_eye.oct_doctor_id == Guid.Empty)
                        {
                            var oct_rejected = rejected_oct_localizations.Any(t => t.localization == right_eye_localization_code);
                            if (oct_rejected)
                            {
                                patient.right_eye.oct_doctor_name = "LABEL_REJECTED_OCT";
                            }
                        }
                        #endregion


                        var oct_performed_dates = cls_Get_OctPerformedDates_for_PatientID.Invoke(dbConnection, dbTransaction, new P_CAS_GOctPDfPID_0908() { ActionTypeID = oct_planned_action_type_id, PatientID = id }, securityTicket).Result;

                        var case_ids = oct_performed_dates.Select(t => t.case_id).ToArray();
                        var fs_statuses = cls_Get_OctFsStatuses_for_PatientID.Invoke(dbConnection, dbTransaction, new P_CAS_GOctFSSfPID_1054() { PatientID = id }, securityTicket).Result;
                        var non_cancelled_dates = new Dictionary<string, List<DateTime>>();
                        non_cancelled_dates.Add(left_eye_localization_code, new List<DateTime>());
                        non_cancelled_dates.Add(right_eye_localization_code, new List<DateTime>());

                        for (var i = 0; i < fs_statuses.Length; i++)
                        {
                            var fs_status = fs_statuses[i].fs_status;
                            if (fs_status != 8 && fs_status != 11 && fs_status != 17)
                            {
                                var oct_date = oct_performed_dates[i];
                                non_cancelled_dates[oct_date.localization].Add(oct_date.perfromed_on_date);
                            }
                        }

                        var left_eye_oct_dates = non_cancelled_dates[left_eye_localization_code];
                        if (left_eye_oct_dates.Any())
                        {
                            patient.left_eye.latest_oct_date = left_eye_oct_dates.Max();

                            var latest_treatment_year_start_date = cls_Get_TreatmentYear.Invoke(dbConnection, dbTransaction, new P_CAS_GTY_1125()
                            {
                                Date = patient.left_eye.latest_oct_date.Value,
                                PatientID = id,
                                LocalizationCode = left_eye_localization_code
                            }, securityTicket).Result;

                            var treatment_year_length = cls_Get_TreatmentYearLength.Invoke(dbConnection, dbTransaction, new P_CAS_GTYL_1317()
                            {
                                Date = patient.left_eye.latest_oct_date.Value,
                                PatientID = id
                            }, securityTicket).Result;

                            var latest_treatment_year_end_date = latest_treatment_year_start_date.AddDays(treatment_year_length);

                            patient.left_eye.start_treatment_year = latest_treatment_year_start_date.ToString("dd.MM.yyyy");
                            patient.left_eye.oct_count = left_eye_oct_dates.Count(t => t >= latest_treatment_year_start_date && t < latest_treatment_year_end_date);
                        }

                        var right_eye_oct_dates = non_cancelled_dates[right_eye_localization_code];
                        if (right_eye_oct_dates.Any())
                        {
                            patient.right_eye.latest_oct_date = right_eye_oct_dates.Max();

                            var latest_treatment_year_start_date = cls_Get_TreatmentYear.Invoke(dbConnection, dbTransaction, new P_CAS_GTY_1125()
                            {
                                Date = patient.right_eye.latest_oct_date.Value,
                                PatientID = id,
                                LocalizationCode = right_eye_localization_code
                            }, securityTicket).Result;

                            var treatment_year_length = cls_Get_TreatmentYearLength.Invoke(dbConnection, dbTransaction, new P_CAS_GTYL_1317()
                            {
                                Date = patient.right_eye.latest_oct_date.Value,
                                PatientID = id
                            }, securityTicket).Result;

                            var latest_treatment_year_end_date = latest_treatment_year_start_date.AddDays(treatment_year_length);

                            patient.right_eye.start_treatment_year = latest_treatment_year_start_date.ToString("dd.MM.yyyy");
                            patient.right_eye.oct_count = right_eye_oct_dates.Count(t => t >= latest_treatment_year_start_date && t < latest_treatment_year_end_date);
                        }

                        var patientParticipations = new List<ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingPatient>();

                        patientDetails.patient = patient;

                        var insuranceToBrokerContractCacheByContractID = ORM_HEC_CRT_InsuranceToBrokerContract.Query.Search(dbConnection, dbTransaction, new ORM_HEC_CRT_InsuranceToBrokerContract.Query()
                        {
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false
                        }).GroupBy(t => t.Ext_CMN_CTR_Contract_RefID).Select(t => new { Key = t.Key, Value = t.Single() }).ToDictionary(t => t.Key, t => t.Value);

                        var insuranceToBrokerContractCacheByInsuranceToBrokerContractID = ORM_HEC_CRT_InsuranceToBrokerContract.Query.Search(dbConnection, dbTransaction, new ORM_HEC_CRT_InsuranceToBrokerContract.Query()
                        {
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false
                        }).GroupBy(t => t.HEC_CRT_InsuranceToBrokerContractID).Select(t => new { Key = t.Key, Value = t.Single() }).ToDictionary(t => t.Key, t => t.Value);

                        var contractParametersCache = ORM_CMN_CTR_Contract_Parameter.Query.Search(dbConnection, dbTransaction, new ORM_CMN_CTR_Contract_Parameter.Query()
                        {
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false,
                            ParameterName = "Duration of participation consent – Month"
                        }).GroupBy(t => t.Contract_RefID).Select(t => new { Key = t.Key, Value = t.First() }).ToDictionary(t => t.Key, t => t.Value);

                        var allContractParameters = ORM_CMN_CTR_Contract_Parameter.Query.Search(dbConnection, dbTransaction, new ORM_CMN_CTR_Contract_Parameter.Query()
                        {
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false
                        }).GroupBy(t => t.Contract_RefID).ToDictionary(t => t.Key, t => t);

                        var op_performed_action_type_id = cls_Get_ActionTypeID.Invoke(dbConnection, dbTransaction, new P_CAS_GATID_1514() { action_type_gpmid = EActionType.PerformedOperation.Value() }, securityTicket).Result;
                        var opDates = cls_Get_PerformedActionData_for_PatientIDs_and_ActionTypeID.Invoke(dbConnection, dbTransaction, new P_CAS_GPADfPIDsaATID_1335()
                        {
                            ActionTypeID = op_performed_action_type_id,
                            PatientIDs = new Guid[] { id }
                        }, securityTicket).Result.GroupBy(t => t.patient_id).ToDictionary(t => t.Key, t => t);

                        foreach (var item in dataFromDB.InitalData.Contracts)
                        {
                            ContractModel model = new ContractModel();
                            model.id = item.ID.ToString();
                            model.name = item.Name;
                            model.ValidFrom = item.ValidFrom;
                            model.ValidTo = item.ValidThrough;
                            model.participation_consent_valid_days = item.participation_consent_valid_days;
                            ContractList.Add(model);

                            var pacientParticipationsOnContract = ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingPatient.Query.Search(dbConnection, dbTransaction, new ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingPatient.Query()
                            {
                                Tenant_RefID = securityTicket.TenantID,
                                IsDeleted = false,
                                InsuranceToBrokerContract_RefID = insuranceToBrokerContractCacheByContractID[item.ID].HEC_CRT_InsuranceToBrokerContractID,
                                Patient_RefID = id
                            });

                            if (pacientParticipationsOnContract.Any())
                                patientParticipations.AddRange(pacientParticipationsOnContract);
                        }

                        var posiblyActiveConsents = patientParticipations.Where(t => t.ValidFrom <= DateTime.Now.Date);
                        var activeConsents = posiblyActiveConsents.Where(t =>
                        {
                            var contractId = insuranceToBrokerContractCacheByInsuranceToBrokerContractID[t.InsuranceToBrokerContract_RefID].Ext_CMN_CTR_Contract_RefID;

                            double days = 0;

                            var parameterValue = allContractParameters[contractId].SingleOrDefault(x => x.ParameterName == "Number of days between surgery and aftercare - Days");
                            if (parameterValue != null && parameterValue.IfNumericValue_Value != double.MaxValue)
                            {
                                days = parameterValue.IfNumericValue_Value;
                            }

                            var consentDuration = allContractParameters[contractId].SingleOrDefault(x => x.ParameterName == "Duration of participation consent – Month");
                            var opRenewsConsent = allContractParameters[contractId].Any(p => p.ParameterName == "OP renews patient consent");

                            if (opRenewsConsent && opDates.ContainsKey(t.Patient_RefID))
                            {
                                var potentialRenewalOp = opDates[t.Patient_RefID].FirstOrDefault(x => x.treatment_date.Date >= t.ValidFrom.Date);
                                var op_renewed_consent = potentialRenewalOp != null && potentialRenewalOp.treatment_date.Date.AddMonths(Convert.ToInt32(consentDuration.IfNumericValue_Value)).AddDays(-days) >= DateTime.Now.Date;
                                var consent_valid_without_op = t.ValidFrom.AddMonths(Convert.ToInt32(consentDuration.IfNumericValue_Value)).AddDays(-days) >= DateTime.Now.Date;
                                return op_renewed_consent || consent_valid_without_op;
                            }
                            else
                            {
                                return t.ValidFrom.AddMonths(Convert.ToInt32(consentDuration.IfNumericValue_Value)).AddDays(-days).Date >= DateTime.Now.Date;
                            }
                        });

                        if (activeConsents.Any())
                        {
                            patient.participation_consent = String.Format("aktualisiert ( {0} )", activeConsents.OrderBy(t => t.ValidFrom).First().ValidFrom.ToString("dd.MM.yyyy"));
                        }
                        else
                        {
                            if (posiblyActiveConsents.Any())
                            {
                                patient.participation_consent = String.Format("abgelaufen ( {0} )", posiblyActiveConsents.OrderBy(t => t.ValidFrom).Last().ValidFrom.ToString("dd.MM.yyyy"));
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
                catch (Exception consentException)
                {
                    Logger.LogInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, consentException));
                }

                patientDetails.patient = patient;
                patientDetails.ContractList = ContractList;
            }
            catch (Exception ex)
            {
                Logger.LogInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, ex));

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }
            return patientDetails;
        }
        /// <summary>
        /// This method retrieves patient cases and participation consents from elastic for patient ID.
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="id"></param>
        /// <param name="connectionString"></param>
        /// <param name="sessionTicket"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public List<PatientDetailViewModelExtended> Get_PatientCasesAndParticipationConsents(ElasticParameterObject parameter, Guid id, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            var patientDetailList = new List<PatientDetailViewModelExtended>();
            var securityTicket = VerifySessionToken(sessionTicket);
            transaction = new TransactionalInformation();
            var todaysDate = DateTime.Now.Date;

            try
            {
                var dbConnection = DBSQLSupport.CreateConnection(connectionString);
                DbTransaction dbTransaction = null;

                try
                {
                    dbConnection.Open();
                    dbTransaction = dbConnection.BeginTransaction();

                    var contractValidToCache = ORM_CMN_CTR_Contract.Query.Search(dbConnection, dbTransaction, new ORM_CMN_CTR_Contract.Query()
                    {
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).GroupBy(t => t.CMN_CTR_ContractID).ToDictionary(t => t.Key, t => t.Single().ValidThrough);

                    patientDetailList = Retrieve_Patients.Get_PatientDetailListTenant(parameter, id.ToString(), securityTicket);
                    var participations = patientDetailList.Where(p => p.detail_type == "participation" && p.status != "LABEL_PARTICIPATION_NOT_ACTIVE");
                    Dictionary<Guid, List<PatientDetailViewModelExtended>> participationsOnContract = null;
                    PA_GPCfIDA_1007[] consents = null;

                    if (participations.Any())
                    {
                        consents = cls_Get_Patient_Consents_for_ID_Array.Invoke(dbConnection, dbTransaction, new P_PA_GPCfIDA_1007() { ConsentIDs = participations.Select(p => Guid.Parse(p.id)).ToArray() }, securityTicket).Result;
                        if (consents.Any())
                        {
                            participationsOnContract = participations.GroupBy(p => consents.Where(con => con.ConsentID == Guid.Parse(p.id)).Single().ContractID).ToDictionary(t => t.Key, t => t.ToList());
                        }
                    }

                    if (participationsOnContract != null)
                    {
                        var allContractParameters = ORM_CMN_CTR_Contract_Parameter.Query.Search(dbConnection, dbTransaction, new ORM_CMN_CTR_Contract_Parameter.Query()
                        {
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false
                        }).GroupBy(t => t.Contract_RefID).ToDictionary(t => t.Key, t => t);

                        var contractCache = ORM_CMN_CTR_Contract.Query.Search(dbConnection, dbTransaction, new ORM_CMN_CTR_Contract.Query() { Tenant_RefID = securityTicket.TenantID, IsDeleted = false });

                        var op_performed_action_type_id = cls_Get_ActionTypeID.Invoke(dbConnection, dbTransaction, new P_CAS_GATID_1514() { action_type_gpmid = EActionType.PerformedOperation.Value() }, securityTicket).Result;
                        var opDates = cls_Get_PerformedActionData_for_PatientIDs_and_ActionTypeID.Invoke(dbConnection, dbTransaction, new P_CAS_GPADfPIDsaATID_1335()
                        {
                            ActionTypeID = op_performed_action_type_id,
                            PatientIDs = new Guid[] { id }
                        }, securityTicket).Result.GroupBy(t => t.patient_id).ToDictionary(t => t.Key, t => t.ToList());

                        var caseIDs = patientDetailList.Where(p => p.detail_type == "op" || p.detail_type == "ac").Select(cas => { return Guid.Parse(cas.case_id); }).ToArray();

                        var op_dates_for_acs = new Dictionary<Guid, DateTime>();
                        if (caseIDs.Any())
                        {
                            op_dates_for_acs = cls_Get_Case_Treatment_Data_for_CaseIDs.Invoke(dbConnection, dbTransaction, new P_CAS_GCTDfCIDs_1624() { CaseIDs = caseIDs }, securityTicket).Result.ToDictionary(t => t.case_id, t => t.treatment_date);
                        }

                        patientDetailList = patientDetailList.Select(pat =>
                        {
                            Guid current_practice_id = Guid.Empty;
                            Guid.TryParse(pat.practice_id, out current_practice_id);

                            var contractName = "";
                            var validUntil = "";

                            var consent = consents.FirstOrDefault(t => t.ValidFrom.Date <= pat.date.Date);

                            #region Fee waiver
                            if (pat.detail_type == "fee_waiver")
                            {
                                var currentYear = DateTime.Now.Year;
                                var lastDayInYear = new DateTime(currentYear, 12, 31);

                                if (pat.date.Year == currentYear)
                                {
                                    pat.status = "LABEL_FEE_WAIVER_ACTIVE";
                                }
                                else
                                {
                                    if (pat.date.Year > currentYear)
                                    {
                                        pat.status = "LABEL_FEE_WAIVER_NOT_YET_ACTIVE";
                                    }
                                    else
                                    {
                                        pat.status = "LABEL_FEE_WAIVER_EXPIRED";
                                    }
                                }
                            }
                            #endregion

                            #region Consent
                            else if (pat.detail_type == "participation" && participations.Any())
                            {
                                try
                                {
                                    consent = consents.SingleOrDefault(c => c.ConsentID == Guid.Parse(pat.id));
                                    if (consent == null)
                                        return pat;

                                    var ctr = contractCache.SingleOrDefault(t => t.CMN_CTR_ContractID == consent.ContractID);
                                    if (ctr != null)
                                    {
                                        contractName = ctr.ContractName;
                                    }

                                    var contractValidTo = contractValidToCache[consent.ContractID];

                                    if (allContractParameters.ContainsKey(consent.ContractID))
                                    {
                                        var contractParameter = allContractParameters[consent.ContractID].SingleOrDefault(t => t.ParameterName == "Duration of participation consent – Month");

                                        if (contractParameter != null && contractParameter.IfNumericValue_Value != double.MaxValue)
                                        {
                                            double days = 0;

                                            var parameterValue = allContractParameters[consent.ContractID].SingleOrDefault(t => t.ParameterName == "Number of days between surgery and aftercare - Days");
                                            if (parameterValue != null && parameterValue.IfNumericValue_Value != double.MaxValue)
                                            {
                                                days = parameterValue.IfNumericValue_Value;
                                            }
                                            var opRenewsConsent = allContractParameters[consent.ContractID].Any(p => p.ParameterName == "OP renews patient consent");

                                            var isConsentActive = false;
                                            if (opRenewsConsent && opDates.ContainsKey(consent.PatientID))
                                            {
                                                var potentialRenewalOp = opDates[consent.PatientID].FirstOrDefault(t => t.treatment_date.Date >= consent.ValidFrom.Date);
                                                if (potentialRenewalOp != null)
                                                {
                                                    var consentValidUntil = potentialRenewalOp.treatment_date.Date.AddMonths(Convert.ToInt32(contractParameter.IfNumericValue_Value));
                                                    isConsentActive = potentialRenewalOp != null && consentValidUntil >= todaysDate;
                                                    validUntil = consentValidUntil.ToString("dd.MM.yyyy");
                                                }
                                            }

                                            if (!isConsentActive)
                                            {
                                                var consentValidUntil = consent.ValidFrom.AddMonths(Convert.ToInt32(contractParameter.IfNumericValue_Value)).AddDays(-days);
                                                if (consent.ValidFrom <= todaysDate && consentValidUntil >= todaysDate && !participationsOnContract[consent.ContractID].Any(p => consentValidUntil > p.date.AddMonths(Convert.ToInt32(contractParameter.IfNumericValue_Value))
                                                    && p.date.AddMonths(Convert.ToInt32(contractParameter.IfNumericValue_Value)).AddDays(-days) >= todaysDate))
                                                {
                                                    pat.status = "LABEL_PARTICIPATION_ACTIVE";
                                                }
                                                else
                                                {
                                                    pat.status = consentValidUntil >= todaysDate ? "LABEL_PARTICIPATION_NOT_YET_ACTIVE" : "LABEL_PARTICIPATION_NOT_ACTIVE";
                                                }
                                                validUntil = consentValidUntil.ToString("dd.MM.yyyy");
                                            }
                                            else
                                            {
                                                pat.status = "LABEL_PARTICIPATION_ACTIVE";
                                            }
                                        }
                                        else
                                        {
                                            pat.status = (consent.ValidFrom <= todaysDate && (contractValidTo == DateTime.MinValue || contractValidTo >= todaysDate)) &&
                                                !participationsOnContract[consent.ContractID].Any(p => consent.ValidFrom < p.date && Guid.Parse(p.id) != consent.ConsentID) ? "LABEL_PARTICIPATION_ACTIVE" : "LABEL_PARTICIPATION_NOT_YET_ACTIVE";
                                        }
                                    }
                                    else
                                    {
                                        pat.status = (consent.ValidFrom <= todaysDate && (contractValidTo == DateTime.MinValue || contractValidTo >= todaysDate)) &&
                                            !participationsOnContract[consent.ContractID].Any(p => consent.ValidFrom < p.date) ? "LABEL_PARTICIPATION_ACTIVE" : "LABEL_PARTICIPATION_NOT_YET_ACTIVE";
                                    }

                                    pat.diagnose_or_medication = String.Format("{0} {1}, {2} {3}", "Teilnahmeerklärung", contractName, "gültig bis", validUntil);
                                }
                                catch
                                {

                                }
                            }
                            #endregion

                            #region Cases
                            else
                            {
                                if (pat.detail_type == "ac")
                                {
                                    var case_id = Guid.Parse(pat.case_id);
                                    if (op_dates_for_acs.ContainsKey(case_id))
                                    {
                                        pat.op_date_string = op_dates_for_acs[case_id].ToString("dd.MM.yyyy");
                                    }
                                }
                            }
                            #endregion

                            return pat;
                        }).ToList();
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
                Logger.LogInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, ex));

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }
            return patientDetailList;
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

                var hip = cls_Get_is_Patient_HIP_on_an_Oct_Contract.Invoke(connection, dbTransaction, new P_PA_GiPHipoaOctC_1811() { PatientID = patient_id }, securityTicket).Result;

                dbTransaction.Commit();

                return hip != null;
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
    }
}
