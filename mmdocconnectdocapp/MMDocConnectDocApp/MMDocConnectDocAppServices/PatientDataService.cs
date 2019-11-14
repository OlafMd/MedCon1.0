using CL1_CMN_CTR;
using CL1_HEC;
using CL1_HEC_BIL;
using CL1_HEC_CRT;
using CSV2Core.SessionSecurity;
using CSV2Core_MySQL.Support;
using DLCore_TokenVerification;
using LogUtils;
using MMDocConnectDBMethods.Case.Atomic.Retrieval;
using MMDocConnectDBMethods.Case.Complex.Retrieval;
using MMDocConnectDBMethods.Doctor.Atomic.Retrieval;
using MMDocConnectDBMethods.ElasticRefresh;
using MMDocConnectDBMethods.MainData.Atomic.Manipulation;
using MMDocConnectDBMethods.MainData.Atomic.Retrieval;
using MMDocConnectDBMethods.MainData.Complex.Retrieval;
using MMDocConnectDBMethods.Patient.Atomic.Manipulation;
using MMDocConnectDBMethods.Patient.Atomic.Retrieval;
using MMDocConnectDBMethods.Patient.Complex.Retrieval;
using MMDocConnectDocApp;
using MMDocConnectDocAppInterfaces;
using MMDocConnectDocAppModels;
using MMDocConnectElasticSearchMethods;
using MMDocConnectElasticSearchMethods.Case.Entity;
using MMDocConnectElasticSearchMethods.Doctor.Retrieval;
using MMDocConnectElasticSearchMethods.HIP.Retrieval;
using MMDocConnectElasticSearchMethods.Models;
using MMDocConnectElasticSearchMethods.Oct.Entity;
using MMDocConnectElasticSearchMethods.Patient.Manipulation;
using MMDocConnectUtils;
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
    public class PatientDataService : BaseVerification, IPatientDataService
    {
        private IDocumentationOnlyDataService documentationOnlyService;

        public PatientDataService()
        {
            documentationOnlyService = new DocumentationOnlyDataService();
        }

        #region RETRIEVAL


        public IEnumerable<ContractModel> GetContractsWhereHIPisParticipating(String ik_number, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            IEnumerable<ContractModel> response = new List<ContractModel>();

            transaction = new TransactionalInformation();

            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);
            var securityTicket = VerifySessionToken(sessionTicket);
            var userData = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            try
            {
                return cls_Get_Contracts_Where_Hip_Participating_for_HipID.Invoke(connectionString, new P_PA_GCwHipPfHipID_0954() { HipIkNumber = ik_number }, securityTicket).Result.Select(ctr =>
                {
                    return new ContractModel()
                    {
                        id = ctr.ContractID.ToString(),
                        name = ctr.ContractName,
                        participation_consent_valid_days = ctr.ParticipationConsentValidForMonths,
                        ValidFrom = ctr.ValidFrom,
                        ValidTo = ctr.ValidThrough
                    };
                });
            }
            catch (Exception ex)
            {
                Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, ex), userData.PracticeName);

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }

            return response;
        }

        public ACAutocompleteModel GetHIPsForSearchCriteria(string search_criteria, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            transaction = new TransactionalInformation();
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            try
            {
                var lastUsedHips = Get_HIPs.Get_LastUsed_HIPs(securityTicket.TenantID.ToString(), data.PracticeID.ToString());
                IEnumerable<HIP_Model> hips = null;

                if (!string.IsNullOrEmpty(search_criteria))
                {
                    hips = Get_HIPs.Get_HIPs_for_Search_Criteria(search_criteria);
                }
                return new ACAutocompleteModel()
                {
                    last_used = lastUsedHips.Select(t => new AutocompleteModel() { id = Guid.Parse(t.id), display_name = t.display_name, secondary_display_name = t.secondary_display_name }).ToList(),
                    doctors = hips != null ? hips.Select(hip => new AutocompleteModel { name = hip.name, secondary_display_name = hip.ik_number, id = Guid.Parse(hip.id), display_name = hip.name + " (" + hip.ik_number + ")", type = "LABEL_HEALTH_INSURANCE_PROVIDER" }).ToList() : new List<AutocompleteModel>()
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

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="practiceID"></param>
        /// <param name="connectionString"></param>
        /// <param name="sessionTicket"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public List<PatientModelFront> GetPatients(ElasticParameterObject parameter, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var patientList = new List<PatientModelFront>();
            transaction = new TransactionalInformation();

            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            try
            {
                var dbConnection = DBSQLSupport.CreateConnection(connectionString);

                try
                {
                    dbConnection.Open();
                    var dbTransaction = dbConnection.BeginTransaction();
                    var patient_ids_from_practice = Retrieve_Patients.Get_Patients_for_Autocomplete("", data.PracticeID, connectionString, securityTicket).Select(t => Guid.Parse(t.id)).ToList();

                    var consentCache = ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingPatient.Query.Search(dbConnection, dbTransaction, new ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingPatient.Query()
                    {
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).GroupBy(t => t.Patient_RefID).ToDictionary(t => t.Key, t => t.ToList());

                    var contractValidToCache = ORM_CMN_CTR_Contract.Query.Search(dbConnection, dbTransaction, new ORM_CMN_CTR_Contract.Query()
                    {
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).GroupBy(t => t.CMN_CTR_ContractID).ToDictionary(t => t.Key, t => t.Single().ValidThrough);

                    var contractIDCache = ORM_HEC_CRT_InsuranceToBrokerContract.Query.Search(dbConnection, dbTransaction, new ORM_HEC_CRT_InsuranceToBrokerContract.Query()
                    {
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID
                    }).GroupBy(t => t.HEC_CRT_InsuranceToBrokerContractID).ToDictionary(t => t.Key, t => t.Single().Ext_CMN_CTR_Contract_RefID);

                    var allContractParameters = ORM_CMN_CTR_Contract_Parameter.Query.Search(dbConnection, dbTransaction, new ORM_CMN_CTR_Contract_Parameter.Query()
                    {
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).GroupBy(t => t.Contract_RefID).ToDictionary(t => t.Key, t => t);

                    var start = parameter.start_row_index;
                    var size = 100;
                    var sort_by = parameter.sort_by;

                    if (parameter.sort_by == "participation_consent")
                    {
                        parameter.start_row_index = 0;
                        parameter.page_size = int.MaxValue;
                    }

                    var performedOpDatesCache = cls_Get_PerformedOpDates_for_PatientIDs.Invoke(dbConnection, dbTransaction, new P_CAS_GPOpDfPIDs_1509() { PatientIDs = patient_ids_from_practice.Any() ? patient_ids_from_practice.ToArray() : new Guid[] { Guid.Empty } }, securityTicket).Result
                        .GroupBy(t => t.PatientID).ToDictionary(t => t.Key, t => t);

                    var patientIDsWithInvalidConsents = parameter.invalid_consent ? patient_ids_from_practice.Where(id =>
                    {
                        if (!consentCache.ContainsKey(id))
                        {
                            return true;
                        }

                        var consents = consentCache[id];
                        var anyConsentValid = consents.Any(consent =>
                        {
                            try
                            {
                                var contractID = contractIDCache[consent.InsuranceToBrokerContract_RefID];
                                var contractParameters = allContractParameters[contractID];
                                var days = 0d;

                                var daysBeetwenOpAndAc = allContractParameters[contractID].SingleOrDefault(t => t.ParameterName == "Number of days between surgery and aftercare - Days");
                                if (daysBeetwenOpAndAc != null && daysBeetwenOpAndAc.IfNumericValue_Value != double.MaxValue)
                                {
                                    days = daysBeetwenOpAndAc.IfNumericValue_Value;
                                }

                                var consentValidForMonths = allContractParameters[contractID].SingleOrDefault(t => t.ParameterName == "Duration of participation consent – Month");
                                var opRenewsConsent = allContractParameters[contractID].Any(p => p.ParameterName == "OP renews patient consent");
                                var consentValid = consent.ValidFrom.AddMonths(Convert.ToInt32(consentValidForMonths.IfNumericValue_Value)).AddDays(-days).Date >= DateTime.Now.Date;

                                if (opRenewsConsent && !consentValid)
                                {
                                    if (performedOpDatesCache.ContainsKey(consent.Patient_RefID))
                                    {
                                        var opDates = performedOpDatesCache[consent.Patient_RefID];
                                        consentValid = opDates.Any(op => op.TreatmentDate.Date >= consent.ValidFrom && op.TreatmentDate.Date.AddMonths(Convert.ToInt32(consentValidForMonths.IfNumericValue_Value)).AddDays(-days).Date >= DateTime.Now.Date);
                                    }
                                }

                                return consentValid;
                            }
                            catch
                            {
                                return true;
                            }
                        });

                        return !anyConsentValid;
                    }).ToList() : new List<Guid>();

                    patientList = Retrieve_Patients.Get_PatientsList(parameter, data.PracticeID.ToString(), patientIDsWithInvalidConsents, securityTicket);
                    if (patientList.Any())
                    {
                        var patient_ids = patientList.Select(t => !String.IsNullOrEmpty(t.originating_patient_id) ? Guid.Parse(t.originating_patient_id) : Guid.Parse(t.id)).ToArray();

                        var op_performed_action_type_id = cls_Get_ActionTypeID.Invoke(dbConnection, dbTransaction, new P_CAS_GATID_1514() { action_type_gpmid = EActionType.PerformedOperation.Value() }, securityTicket).Result;
                        var opDates = cls_Get_PerformedActionData_for_PatientIDs_and_ActionTypeID.Invoke(dbConnection, dbTransaction, new P_CAS_GPADfPIDsaATID_1335()
                        {
                            ActionTypeID = op_performed_action_type_id,
                            PatientIDs = patient_ids
                        }, securityTicket).Result.GroupBy(t => t.patient_id).ToDictionary(t => t.Key, t => t);

                        patientList = patientList.Select(item =>
                        {
                            var todaysDate = DateTime.Now.Date;
                            var patientID = !String.IsNullOrEmpty(item.originating_patient_id) ? Guid.Parse(item.originating_patient_id) : Guid.Parse(item.id);
                            if (consentCache.ContainsKey(patientID))
                            {
                                var hasValidConsent = false;
                                var consents = consentCache[patientID];
                                foreach (var consent in consents)
                                {
                                    var contractID = contractIDCache[consent.InsuranceToBrokerContract_RefID];
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

            return patientList;
        }

        public PatientDetailViewData Get_PatientDetails(Guid id, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var patientDetails = new PatientDetailViewData();
            var patient = new PatientDetail();
            var ContractList = new List<ContractModel>();

            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);
            var securityTicket = VerifySessionToken(sessionTicket);
            var userData = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            transaction = new TransactionalInformation();
            try
            {
                try
                {
                    var dbConnection = DBSQLSupport.CreateConnection(connectionString);
                    DbTransaction dbTransaction = null;

                    try
                    {
                        dbConnection.Open();
                        dbTransaction = dbConnection.BeginTransaction();

                        var isPracticeLoggedIn = userData.AccountInformation.role.Contains("practice");
                        var practiceID = isPracticeLoggedIn ? userData.PracticeID : userData.DoctorID;

                        var dataFromDB = cls_Get_PatientData_With_ContractList.Invoke(dbConnection, dbTransaction, new P_PA_GPDWCL_1118 { isPracticeLoggedIn = isPracticeLoggedIn, PatientID = id, ID = practiceID }, securityTicket).Result;
                        var data = dataFromDB.PatientData;
                        var patient_practice = ORM_HEC_Patient_MedicalPractice.Query.Search(dbConnection, dbTransaction, new ORM_HEC_Patient_MedicalPractice.Query()
                        {
                            HEC_Patient_RefID = id,
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false
                        }).Single();

                        if (patient_practice.HEC_MedicalPractices_RefID != userData.PracticeID)
                        {
                            var practice_details = cls_Get_Practice_Details_for_PracticeID.Invoke(dbConnection, dbTransaction, new P_DO_GPDfPID_1432() { PracticeID = patient_practice.HEC_MedicalPractices_RefID }, securityTicket).Result.First();
                            patient.originating_practice_name = practice_details.practice_name;
                        }

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


                        var doctor_ids = Get_Doctors_for_PracticeID.Get_Doctors_That_Work_In_Practice_for_PracticeID(new Practice_Parameter()
                        {
                            practice_id = userData.PracticeID
                        }, securityTicket).Select(t => t.id).ToList();

                        doctor_ids.Add(userData.PracticeID.ToString());

                        var allContractParameters = ORM_CMN_CTR_Contract_Parameter.Query.Search(dbConnection, dbTransaction, new ORM_CMN_CTR_Contract_Parameter.Query() { Tenant_RefID = securityTicket.TenantID, IsDeleted = false }).GroupBy(t => t.Contract_RefID).ToDictionary(t => t.Key, t => t);

                        var practice_bpt_id = cls_Get_Practice_BptID_for_PracticeID.Invoke(dbConnection, dbTransaction, new P_DO_GPBptIDfPID_1446() { PracticeID = userData.PracticeID }, securityTicket).Result.practice_bpt_id;
                        var doctor_bpt_ids = cls_Get_DoctorBptIDs_for_PracticeID.Invoke(dbConnection, dbTransaction, new P_DO_GDBptIDsfPID_1621() { PracticeID = userData.PracticeID }, securityTicket).Result.Select(x => x.doctor_bpt_id).ToList();
                        doctor_bpt_ids.Add(practice_bpt_id);

                        var doctor_bpt_ids_array = doctor_bpt_ids.ToArray();
                        var op_case_ids = cls_Get_CaseIDs_where_PatientID_and_BptID.Invoke(dbConnection, dbTransaction, new P_CAS_GCIDswPIDaBptID_1700()
                        {
                            BptIDs = doctor_bpt_ids_array,
                            PatientID = id
                        }, securityTicket).Result.Select(t => t.case_id).ToList();

                        var other_case_ids = cls_Get_NonOpCaseIDs_where_PatientID_and_BptID.Invoke(dbConnection, dbTransaction, new P_CAS_GNOpCIDswPIDaBptID_1541()
                        {
                            BptIDs = doctor_bpt_ids_array,
                            PatientID = id
                        }, securityTicket).Result.Select(t => t.case_id).ToList();
                        var case_ids = new List<Guid>();
                        case_ids.AddRange(op_case_ids);
                        case_ids.AddRange(other_case_ids);
                        if (case_ids.Any())
                        {
                            var case_id_array = case_ids.Distinct().ToArray();

                            var fake_case_properties = cls_Get_CasePropertyValue_for_CaseIDs_and_CasePropertyGpmID.Invoke(dbConnection, dbTransaction, new P_CAS_GCPVfCIDsaCGpmID_0832()
                            {
                                CaseIDs = case_id_array,
                                PropertyGpmID = ECaseProperty.FakeCase.Value()
                            }, securityTicket).Result.Select(t => t.CaseID).ToList();

                            var documentation_cases = cls_Get_Case_Properties_for_GpmID.Invoke(dbConnection, dbTransaction, new P_CAS_GCPfGpmID_1235()
                            {
                                PropertyGpmID = ECaseProperty.DocumentationOnly.Value(),
                                PatientID = id
                            }, securityTicket).Result.GroupBy(t => t.CaseID).ToDictionary(t => t.Key, t => t.SingleOrDefault());

                            var excludeFSStatuses = new List<int>() { 8, 11, 17 };
                            var allTreatments = cls_Get_TretmentDates_for_PatientID.Invoke(dbConnection, dbTransaction, new P_CAS_GTDfPID_1509() { PatientID = id, CaseIDs = case_id_array }, securityTicket).Result
                                .Where(x => (documentation_cases.ContainsKey(x.case_id) && documentation_cases[x.case_id].Value_Boolean) || x.transmition_status_key == null || (x.transmition_status_key != null && x.transmition_status_key == "treatment" && !excludeFSStatuses.Any(status => status == x.transmition_code)));

                            var treatments = allTreatments.GroupBy(t => t.localization).ToDictionary(t => t.Key, t => t.Where(x => !fake_case_properties.Any(r => r == x.case_id)).ToList());

                            if (treatments.ContainsKey(left_eye_localization_code))
                            {
                                var left_eye_treatments = treatments[left_eye_localization_code];
                                if (left_eye_treatments.Any())
                                {
                                    patient.left_eye.latest_op_date = left_eye_treatments.Max(t => t.treatment_date);
                                    patient.left_eye.op_count = left_eye_treatments.GroupBy(t => t.case_id).ToDictionary(t => t.Key, t => t).Keys.Count;
                                }
                            }

                            if (treatments.ContainsKey(right_eye_localization_code))
                            {
                                var right_eye_treatments = treatments[right_eye_localization_code];
                                if (right_eye_treatments.Any())
                                {
                                    patient.right_eye.latest_op_date = right_eye_treatments.Max(t => t.treatment_date);
                                    patient.right_eye.op_count = right_eye_treatments.GroupBy(t => t.case_id).ToDictionary(t => t.Key, t => t).Keys.Count; ;
                                }
                            }
                        }

                        var oct_planned_action_type_id = cls_Get_ActionTypeID.Invoke(dbConnection, dbTransaction, new P_CAS_GATID_1514() { action_type_gpmid = EActionType.PlannedOct.Value() }, securityTicket).Result;
                        var oct_performed_action_type_id = cls_Get_ActionTypeID.Invoke(dbConnection, dbTransaction, new P_CAS_GATID_1514() { action_type_gpmid = EActionType.PerformedOct.Value() }, securityTicket).Result;

                        var latest_left_eye_bill_position = cls_Get_Existing_OCT_BillPosition_for_PatientID_and_LocalizationCode.Invoke(dbConnection, dbTransaction, new P_CAS_GEBPfPIDaLC_1803()
                        {
                            LocalizationCode = left_eye_localization_code,
                            PatientID = id
                        }, securityTicket).Result;

                        if (latest_left_eye_bill_position != null)
                        {
                            var oct_doctor = cls_Get_Latest_Oct_Doctor_for_PatientID_and_Localization.Invoke(dbConnection, dbTransaction, new P_CAS_GLOctDfPIDaLC_1644()
                            {
                                PlannedActionTypeID = oct_planned_action_type_id,
                                PatientID = id,
                                LocalizationCode = left_eye_localization_code
                            }, securityTicket).Result;

                            if (oct_doctor != null)
                            {
                                patient.left_eye.oct_doctor_id = oct_doctor.id;
                                patient.left_eye.oct_doctor_name = GenericUtils.GetDoctorName(oct_doctor);
                                patient.left_eye.oct_doctor_editable = true;

                                patient.left_eye.can_change_doctor = !cls_Get_CasePropertyValue_for_CaseIDs_and_CasePropertyGpmID.Invoke(dbConnection, dbTransaction, new P_CAS_GCPVfCIDsaCGpmID_0832()
                                {
                                    CaseIDs = new Guid[] { latest_left_eye_bill_position.CaseID },
                                    PropertyGpmID = ECaseProperty.MissingIvom.Value()
                                }, securityTicket).Result.Any();
                            }
                        }

                        var latest_right_eye_bill_position = cls_Get_Existing_OCT_BillPosition_for_PatientID_and_LocalizationCode.Invoke(dbConnection, dbTransaction, new P_CAS_GEBPfPIDaLC_1803()
                        {
                            LocalizationCode = right_eye_localization_code,
                            PatientID = id
                        }, securityTicket).Result;

                        if (latest_right_eye_bill_position != null)
                        {
                            var oct_doctor = cls_Get_Latest_Oct_Doctor_for_PatientID_and_Localization.Invoke(dbConnection, dbTransaction, new P_CAS_GLOctDfPIDaLC_1644()
                            {
                                PlannedActionTypeID = oct_planned_action_type_id,
                                PatientID = id,
                                LocalizationCode = right_eye_localization_code
                            }, securityTicket).Result;

                            if (oct_doctor != null)
                            {
                                patient.right_eye.oct_doctor_id = oct_doctor.id;
                                patient.right_eye.oct_doctor_name = GenericUtils.GetDoctorName(oct_doctor);
                                patient.right_eye.oct_doctor_editable = true;

                                patient.right_eye.can_change_doctor = !cls_Get_CasePropertyValue_for_CaseIDs_and_CasePropertyGpmID.Invoke(dbConnection, dbTransaction, new P_CAS_GCPVfCIDsaCGpmID_0832()
                                {
                                    CaseIDs = new Guid[] { latest_right_eye_bill_position.CaseID },
                                    PropertyGpmID = ECaseProperty.MissingIvom.Value()
                                }, securityTicket).Result.Any();
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
                            patient.left_eye.oct_doctor_editable = rejected_oct_localizations.Any(t => t.localization == left_eye_localization_code);
                            if (patient.left_eye.oct_doctor_editable)
                            {
                                patient.left_eye.oct_doctor_name = "LABEL_REJECTED";
                                patient.left_eye.oct_rejected = true;
                            }
                        }

                        if (patient.right_eye.oct_doctor_id == Guid.Empty)
                        {
                            patient.right_eye.oct_doctor_editable = rejected_oct_localizations.Any(t => t.localization == right_eye_localization_code);
                            if (patient.right_eye.oct_doctor_editable)
                            {
                                patient.right_eye.oct_doctor_name = "LABEL_REJECTED";
                                patient.right_eye.oct_rejected = true;
                            }
                        }
                        #endregion

                        #region Oct count and treatment year
                        #region preapare data
                        var oct_performed_dates = cls_Get_OctPerformedDates_for_PatientID.Invoke(dbConnection, dbTransaction, new P_CAS_GOctPDfPID_0908() { ActionTypeID = oct_planned_action_type_id, PatientID = id }, securityTicket).Result;
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

                        var octGposCatalog = ORM_HEC_BIL_PotentialCode_Catalog.Query.Search(dbConnection, dbTransaction, new ORM_HEC_BIL_PotentialCode_Catalog.Query() { GlobalPropertyMatchingID = EGposType.Oct.Value(), Tenant_RefID = securityTicket.TenantID, IsDeleted = false }).Single();
                        var gposIds = ORM_HEC_BIL_PotentialCode.Query.Search(dbConnection, dbTransaction, new ORM_HEC_BIL_PotentialCode.Query() { PotentialCode_Catalog_RefID = octGposCatalog.HEC_BIL_PotentialCode_CatalogID }).Select(t => t.HEC_BIL_PotentialCodeID).ToArray();
                        var lastPotentialConsent = cls_Get_PatientConsents_on_Contract_by_GposIDs_and_PatientID.Invoke(dbConnection, dbTransaction, new P_ER_GPCoCbGposIDsaPID_2020() { PatientID = id, GposIDs = gposIds }, securityTicket).Result.OrderByDescending(t => t.consent_valid_from.Date).FirstOrDefault();
                        var all_dates = cls_Get_Oct_and_Op_Dates_by_PatientID.Invoke(dbConnection, dbTransaction, new P_ER_GOctaOpDbPID_1824() { PatientID = id }, securityTicket).Result;
                        var useSettlementYear = false;
                        if (lastPotentialConsent != null)
                        {
                            var contract = ORM_CMN_CTR_Contract.Query.Search(dbConnection, dbTransaction, new ORM_CMN_CTR_Contract.Query() { Tenant_RefID = securityTicket.TenantID, IsDeleted = false, CMN_CTR_ContractID = lastPotentialConsent.contract_id }).SingleOrDefault();
                            useSettlementYear = allContractParameters[lastPotentialConsent.contract_id].Any(t => t.ParameterName == EContractParameter.UseSettlementYear.Value());
                        }

                        var all_performed_dates = useSettlementYear ? all_dates.Where(x => !x.IsOp).ToArray() : all_dates.Where(x => !x.IsOp || (x.IsOp && x.IsOpPerformed)).ToArray();


                        var left_eye_oct_dates = non_cancelled_dates[left_eye_localization_code];
                        var right_eye_oct_dates = non_cancelled_dates[right_eye_localization_code];

                        var all_performed_left_data = all_performed_dates.Where(x => x.Localization == left_eye_localization_code);
                        var all_performed_right_data = all_performed_dates.Where(x => x.Localization == right_eye_localization_code);
                        #endregion

                        var treatment_year_start_date = DateTime.MaxValue;
                        var treatment_year_end_date = DateTime.MaxValue;
                        if (useSettlementYear)
                        {
                            var doctors = all_performed_dates.Select(x => x.DoctorID).Distinct();
                            foreach (var doc in doctors)
                            {
                                var last_performed_date = all_performed_dates.First(x => x.DoctorID == doc);

                                var treatment_year_length = cls_Get_TreatmentYearLength.Invoke(dbConnection, dbTransaction, new P_CAS_GTYL_1317()
                                {
                                    Date = last_performed_date.TreatmentDate,
                                    PatientID = id,
                                }, securityTicket).Result;

                                var current_treatment_year_start_date = cls_Get_TreatmentYear.Invoke(dbConnection, dbTransaction, new P_CAS_GTY_1125()
                                {
                                    Date = last_performed_date.TreatmentDate,
                                    LocalizationCode = left_eye_localization_code,
                                    PatientID = id,
                                    DoctorID = doc
                                }, securityTicket).Result;

                                if (treatment_year_start_date > current_treatment_year_start_date)
                                {
                                    treatment_year_start_date = current_treatment_year_start_date;
                                    treatment_year_end_date = treatment_year_start_date.Date.AddDays(treatment_year_length - 1);

                                }
                            }
                        }
                        if (treatment_year_start_date != DateTime.MaxValue && treatment_year_end_date != DateTime.MaxValue && (all_performed_left_data.Any() || all_performed_right_data.Any()) && useSettlementYear)
                        {
                            patient.left_eye.start_treatment_year = treatment_year_start_date.ToString("dd.MM.yyyy");
                            patient.right_eye.start_treatment_year = treatment_year_start_date.ToString("dd.MM.yyyy");
                        }

                        #region left eye
                        if (all_dates.Any())
                        {
                            if (!useSettlementYear)
                            {
                                var last_performed_date = all_dates.Max(x => x.TreatmentDate);

                                var treatment_year_length = cls_Get_TreatmentYearLength.Invoke(dbConnection, dbTransaction, new P_CAS_GTYL_1317()
                                {
                                    Date = last_performed_date,
                                    PatientID = id
                                }, securityTicket).Result;

                                treatment_year_start_date = cls_Get_TreatmentYear.Invoke(dbConnection, dbTransaction, new P_CAS_GTY_1125()
                                {
                                    Date = last_performed_date,
                                    LocalizationCode = left_eye_localization_code,
                                    PatientID = id,
                                }, securityTicket).Result;
                                treatment_year_end_date = treatment_year_start_date.Date.AddDays(treatment_year_length - 1);

                                patient.left_eye.start_treatment_year = treatment_year_start_date.ToString("dd.MM.yyyy");
                            }

                            if (left_eye_oct_dates.Any())
                            {
                                patient.left_eye.latest_oct_date = left_eye_oct_dates.Max();
                                patient.left_eye.oct_count = left_eye_oct_dates.Count(t => t >= treatment_year_start_date && t < treatment_year_end_date);
                            }
                        }
                        #endregion

                        #region right eye
                        if (all_performed_right_data.Any())
                        {
                            if (!useSettlementYear)
                            {
                                var last_performed_date = all_performed_right_data.Max(x => x.TreatmentDate);

                                var treatment_year_length = cls_Get_TreatmentYearLength.Invoke(dbConnection, dbTransaction, new P_CAS_GTYL_1317()
                                {
                                    Date = last_performed_date,
                                    PatientID = id
                                }, securityTicket).Result;

                                treatment_year_start_date = cls_Get_TreatmentYear.Invoke(dbConnection, dbTransaction, new P_CAS_GTY_1125()
                                {
                                    Date = last_performed_date,
                                    LocalizationCode = right_eye_localization_code,
                                    PatientID = id
                                }, securityTicket).Result;

                                treatment_year_end_date = treatment_year_start_date.Date.AddDays(treatment_year_length - 1);

                                patient.right_eye.start_treatment_year = treatment_year_start_date.ToString("dd.MM.yyyy");
                            }

                            if (right_eye_oct_dates.Any())
                            {
                                patient.right_eye.latest_oct_date = right_eye_oct_dates.Max();
                                patient.right_eye.oct_count = right_eye_oct_dates.Count(t => t >= treatment_year_start_date && t < treatment_year_end_date);
                            }
                        }
                        #endregion
                        #endregion

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

                        var op_performed_action_type_id = cls_Get_ActionTypeID.Invoke(dbConnection, dbTransaction, new P_CAS_GATID_1514() { action_type_gpmid = EActionType.PerformedOperation.Value() }, securityTicket).Result;
                        var opDates = cls_Get_PerformedActionData_for_PatientIDs_and_ActionTypeID.Invoke(dbConnection, dbTransaction, new P_CAS_GPADfPIDsaATID_1335()
                        {
                            ActionTypeID = op_performed_action_type_id,
                            PatientIDs = new Guid[] { id }
                        }, securityTicket).Result.GroupBy(t => t.patient_id).ToDictionary(t => t.Key, t => t);

                        foreach (var item in dataFromDB.InitalData.Contracts)
                        {
                            var model = new ContractModel();
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

                        patientDetails.ContractList = ContractList;

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
                    Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, consentException), userData.PracticeName);
                    throw consentException;
                }
            }
            catch (Exception ex)
            {
                Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, ex), userData.PracticeName);

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }
            return patientDetails;
        }

        public List<PatientDetailViewModelExtended> Get_PatientCasesAndParticipationConsents(ElasticParameterObject parameter, Guid id, string sessionTicket, string connectionString, out TransactionalInformation transaction)
        {
            var patientDetailList = new List<PatientDetailViewModelExtended>();
            transaction = new TransactionalInformation();

            var ordersDataService = new OrdersDataService();

            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);
            var securityTicket = VerifySessionToken(sessionTicket);
            var userData = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;
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

                    var contractIDCache = new Dictionary<Guid, Guid>();

                    var allContractParameters = ORM_CMN_CTR_Contract_Parameter.Query.Search(dbConnection, dbTransaction, new ORM_CMN_CTR_Contract_Parameter.Query()
                    {
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).GroupBy(t => t.Contract_RefID).ToDictionary(t => t.Key, t => t.ToList());
                    var patient_hip = cls_Get_Patient_Insurance_Data_for_PatientIDs.Invoke(dbConnection, dbTransaction, new P_PA_GPIDfPIDs_1002() { PatientIDs = new Guid[] { id } }, securityTicket).Result.First();
                    var oldest_contract_where_hip_participating = cls_Get_Contracts_Where_Hip_Participating_for_HipID.Invoke(connectionString, new P_PA_GCwHipPfHipID_0954() { HipIkNumber = patient_hip.HipIkNumber }, securityTicket).Result.FirstOrDefault();
                    var contract_parameters = oldest_contract_where_hip_participating != null ? allContractParameters[oldest_contract_where_hip_participating.ContractID] : new List<ORM_CMN_CTR_Contract_Parameter>();
                    var consent_valid_for_months = 12;
                    var consent_valid_for_months_parameter = contract_parameters.SingleOrDefault(t => t.ParameterName == EContractParameter.DurationOfParticipationConsent.Value());
                    if (consent_valid_for_months_parameter != null)
                    {
                        consent_valid_for_months = Convert.ToInt32(consent_valid_for_months_parameter.IfNumericValue_Value);
                    }
                    var is_consent_auto_renewed_by_op = contract_parameters.Any(t => t.ParameterName == EContractParameter.OpRenewsConsent.Value());

                    var doctor_ids = Get_Doctors_for_PracticeID.Get_Doctors_That_Work_In_Practice_for_PracticeID(new Practice_Parameter()
                    {
                        practice_id = userData.PracticeID
                    }, securityTicket).Select(t => t.id).ToList();

                    doctor_ids.Add(userData.PracticeID.ToString());

                    var practice_bpt_id = cls_Get_Practice_BptID_for_PracticeID.Invoke(dbConnection, dbTransaction, new P_DO_GPBptIDfPID_1446() { PracticeID = userData.PracticeID }, securityTicket).Result.practice_bpt_id;
                    var doctor_bpt_ids = cls_Get_DoctorBptIDs_for_PracticeID.Invoke(dbConnection, dbTransaction, new P_DO_GDBptIDsfPID_1621() { PracticeID = userData.PracticeID }, securityTicket).Result.Select(x => x.doctor_bpt_id).ToList();
                    doctor_bpt_ids.Add(practice_bpt_id);

                    var doctor_bpt_ids_array = doctor_bpt_ids.ToArray();
                    var op_case_ids = cls_Get_CaseIDs_where_PatientID_and_BptID.Invoke(dbConnection, dbTransaction, new P_CAS_GCIDswPIDaBptID_1700()
                    {
                        BptIDs = doctor_bpt_ids_array,
                        PatientID = id,
                        PracticeID = userData.PracticeID
                    }, securityTicket).Result.Select(t => t.case_id).ToArray();
                    var all_consents = cls_Get_Patient_Consents_for_PatientIDs.Invoke(dbConnection, dbTransaction, new P_PA_GPCfPIDs_1358() { PatientIDs = new Guid[] { id } }, securityTicket).Result;

                    var other_case_ids = cls_Get_NonOpCaseIDs_where_PatientID_and_BptID.Invoke(dbConnection, dbTransaction, new P_CAS_GNOpCIDswPIDaBptID_1541()
                    {
                        BptIDs = doctor_bpt_ids_array,
                        PatientID = id
                    }, securityTicket).Result.Select(t => t.case_id).ToArray();

                    var non_op_dates = cls_Get_NonOpDates_where_PatientID_and_BptID.Invoke(dbConnection, dbTransaction, new P_CAS_GNOpDwPIDaBptID_1117()
                    {
                        BptIDs = doctor_bpt_ids_array,
                        PatientID = id
                    }, securityTicket).Result;
                    var consent_ids = all_consents.Where(consent =>
                    {
                        var consent_visible = non_op_dates.Any(date =>
                        {
                            var performed_on_date = date.is_performed ? date.performed_on_date : date.op_date;
                            var valid_from_condition = consent.ValidFrom.Date <= performed_on_date.Date;
                            var valid_to_condition = !all_consents.Any(x =>
                            {
                                return x.HEC_CRT_InsuranceToBrokerContract_ParticipatingPatientID != consent.HEC_CRT_InsuranceToBrokerContract_ParticipatingPatientID && x.ValidFrom.Date > consent.ValidFrom.Date && x.ValidFrom.Date <= performed_on_date;
                            });

                            if (!is_consent_auto_renewed_by_op)
                            {
                                valid_to_condition = consent.ValidFrom.Date.AddMonths(consent_valid_for_months).Date >= performed_on_date && valid_to_condition;
                            }

                            return valid_from_condition && valid_to_condition;
                        });

                        return consent_visible;
                    }).Select(t => t.HEC_CRT_InsuranceToBrokerContract_ParticipatingPatientID.ToString()).ToList();

                    var non_op_dates_grouped_by_year = non_op_dates.GroupBy(t => t.is_performed ? t.performed_on_date.Year : t.op_date.Year).ToDictionary(t => t.Key, t => t.Max(r => r.is_performed ? r.performed_on_date : r.op_date));
                    var min_fee_waiver_dates = non_op_dates_grouped_by_year.Select(t => t.Value).ToList();

                    var hipData = cls_Get_Hip_Contract_Parameters_on_Tenant.Invoke(dbConnection, dbTransaction, securityTicket).Result.GroupBy(hip => hip.HipIK).ToDictionary(t => t.Key, t => t.ToList());
                    var octRangeParameters = GetOCTRangeParameters(dbConnection, dbTransaction, securityTicket, hipData);
                    var acRangeParameters = GetACRangeParameters(dbConnection, dbTransaction, securityTicket, hipData);

                    patientDetailList = Retrieve_Patients.Get_PatientDetailList(parameter, id.ToString(), Array.ConvertAll(op_case_ids, t => t.ToString()), doctor_ids,
                        Array.ConvertAll(other_case_ids, t => t.ToString()), min_fee_waiver_dates, userData.PracticeID.ToString(), consent_ids, octRangeParameters, acRangeParameters, securityTicket);
                    var participations = patientDetailList.Where(p => p.detail_type == "participation" && p.status != "LABEL_PARTICIPATION_NOT_ACTIVE");
                    Dictionary<Guid, List<PatientDetailViewModelExtended>> participationsOnContract = null;
                    var consents = new PA_GPCfIDA_1007[] { };

                    if (participations.Any())
                    {
                        consents = cls_Get_Patient_Consents_for_ID_Array.Invoke(dbConnection, dbTransaction, new P_PA_GPCfIDA_1007() { ConsentIDs = participations.Select(p => Guid.Parse(p.id)).ToArray() }, securityTicket).Result;
                        if (consents.Any())
                        {
                            participationsOnContract = participations.Where(t => consents.Any(r => r.ConsentID == Guid.Parse(t.id))).GroupBy(p => consents.Single(con => con.ConsentID == Guid.Parse(p.id)).ContractID).ToDictionary(t => t.Key, t => t.ToList());
                        }
                    }

                    var fsCache = new Dictionary<Guid, List<CAS_GCTCfCIDs_1519>>();
                    var caseIDs = patientDetailList.Where(p => p.detail_type == "op" || p.detail_type == "ac" || p.detail_type == "order").Select(cas => { return Guid.Parse(cas.case_id); }).Distinct().ToArray();

                    var contractCache = ORM_CMN_CTR_Contract.Query.Search(dbConnection, dbTransaction, new ORM_CMN_CTR_Contract.Query() { Tenant_RefID = securityTicket.TenantID, IsDeleted = false });

                    var op_performed_action_type_id = cls_Get_ActionTypeID.Invoke(dbConnection, dbTransaction, new P_CAS_GATID_1514() { action_type_gpmid = EActionType.PerformedOperation.Value() }, securityTicket).Result;

                    var allOpDates = cls_Get_PerformedActionData_for_PatientIDs_and_ActionTypeID.Invoke(dbConnection, dbTransaction, new P_CAS_GPADfPIDsaATID_1335()
                    {
                        ActionTypeID = op_performed_action_type_id,
                        PatientIDs = new Guid[] { id }
                    }, securityTicket).Result;

                    var opDates = new Dictionary<Guid, List<CAS_GPADfPIDsaATID_1335>>();
                    var missingIvomCaseIds = new List<Guid>();
                    var oct_ids = new Dictionary<Guid, List<CAS_GOctIDsfCIDs_1340>>();
                    var bill_positions = new Dictionary<Guid, List<CAS_GBPIDsfCIDsaGposT_1018>>();
                    var op_dates_for_acs = new Dictionary<Guid, DateTime>();
                    var all_treatment_information = new Dictionary<Guid, CAS_GCToT_1418>();
                    var oct_planned_action_type_id = cls_Get_ActionTypeID.Invoke(dbConnection, dbTransaction, new P_CAS_GATID_1514() { action_type_gpmid = EActionType.PlannedOct.Value() }, securityTicket).Result;

                    if (caseIDs.Any())
                    {
                        op_dates_for_acs = cls_Get_Case_Treatment_Data_for_CaseIDs.Invoke(dbConnection, dbTransaction, new P_CAS_GCTDfCIDs_1624() { CaseIDs = caseIDs }, securityTicket).Result
                            .GroupBy(x => x.case_id)
                            .ToDictionary(t => t.Key, t => t.First().treatment_date);
                        var missingIvomCaseProperties = cls_Get_CasePropertyValue_for_CaseIDs_and_CasePropertyGpmID.Invoke(dbConnection, dbTransaction, new P_CAS_GCPVfCIDsaCGpmID_0832()
                        {
                            CaseIDs = caseIDs,
                            PropertyGpmID = ECaseProperty.MissingIvom.Value(),
                            IncludeDeleted = true
                        }, securityTicket).Result.GroupBy(t => t.CaseID).ToDictionary(t => t.Key, t => t);
                        missingIvomCaseIds = missingIvomCaseProperties.Keys.ToList();

                        var fs_statusesDB = cls_Get_Case_TransmitionCode_for_CaseIDs.Invoke(dbConnection, dbTransaction, new P_CAS_GCTCfCIDs_1519 { CaseID = caseIDs }, securityTicket).Result;
                        fsCache = fs_statusesDB.GroupBy(t => t.case_id).ToDictionary(t => t.Key, t => t.ToList());

                        opDates = allOpDates.Where(t => !missingIvomCaseIds.Any(x => x == t.case_id)).GroupBy(t => t.patient_id).ToDictionary(t => t.Key, t => t.ToList());

                        oct_ids = cls_Get_OctIDs_for_CaseIDs.Invoke(dbConnection, dbTransaction, new P_CAS_GOctIDsfCIDs_1340() { ActionTypeID = oct_planned_action_type_id, CaseIDs = caseIDs }, securityTicket).Result
                            .GroupBy(t => t.case_id).ToDictionary(t => t.Key, t => t.ToList());
                        bill_positions = cls_Get_BillPositionIDs_for_CaseIDs_and_GposType.Invoke(dbConnection, dbTransaction, new P_CAS_GBPIDsfCIDsaGposT_1018() { CaseIDs = caseIDs, GposType = EGposType.Oct.Value() }, securityTicket).Result
                            .GroupBy(t => t.case_id).ToDictionary(t => t.Key, t => t.ToList());

                        all_treatment_information = cls_Get_Case_Treatments_on_Tenant.Invoke(dbConnection, dbTransaction, new P_CAS_GCToT_1418
                        {
                            CaseIDs = caseIDs
                        }, securityTicket).Result.GroupBy(x => x.CaseID).ToDictionary(x => x.Key, x => x.First());
                    }
                    else
                    {
                        opDates = allOpDates.GroupBy(t => t.patient_id).ToDictionary(t => t.Key, t => t.ToList());
                    }


                    var default_shipping_date_offset = ordersDataService.GetDefaultShippingDateOffset(userData.PracticeID, dbConnection, dbTransaction, securityTicket);
                    var statuses_to_preserve = new List<string>() { "FS0", "FS8", "FS1", "AC1", "AC3", "OP1", "OP3", "FS13", "OCT1", "AC4" };
                    var open_ac_statuses = new List<string>() { "AC1", "AC3", "FS0" };

                    var op_dates_with_localization = patientDetailList.Any() ? cls_Get_PerformedOpDates_with_localization_for_PatientIDs.Invoke(dbConnection, dbTransaction, new P_CAS_GPODwLfPIDs_1530
                    {
                        PatientIDs = patientDetailList.Select(x => Guid.Parse(x.patient_id)).Distinct().ToArray()
                    }, securityTicket).Result.GroupBy(x => x.patient_id).ToDictionary(t => t.Key, t => t.ToList()) : new Dictionary<Guid, List<CAS_GPODwLfPIDs_1530>>();

                    patientDetailList = patientDetailList.Select(pat =>
                    {
                        Guid current_practice_id = Guid.Empty;
                        Guid.TryParse(pat.practice_id, out current_practice_id);

                        var contractName = "";
                        var validUntil = "";

                        var consent = consents.FirstOrDefault(t => t.ValidFrom.Date <= pat.date.Date);

                        pat.is_my_practice = current_practice_id == userData.PracticeID;

                        #region Order
                        if (pat.detail_type == "order")
                        {
                            if (pat.order_status == "MO0" && pat.date.AddDays(-default_shipping_date_offset).Date <= DateTime.Now.Date)
                            {
                                pat.order_status = "MO8";
                            }

                            var case_id = Guid.Parse(pat.case_id);
                            if (all_treatment_information.ContainsKey(case_id))
                            {
                                var treatment = all_treatment_information[case_id];
                                pat.is_edit_button_visible = !treatment.IsPerformed;
                                pat.cancel_disabled = treatment.IsPerformed;
                            }
                            else
                            {
                                pat.is_edit_button_visible = true;
                            }
                        }
                        #endregion

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
                            if (pat.status == "FS0")
                            {
                                switch (pat.detail_type)
                                {
                                    case "op":
                                        if (pat.date.Date < DateTime.Now.Date)
                                        {
                                            pat.status = "OP3";
                                        }

                                        break;
                                    case "ac":
                                        double days = 0;
                                        if (consent != null)
                                        {
                                            var parameterValue = allContractParameters[consent.ContractID].SingleOrDefault(t => t.ParameterName == "Number of days between surgery and aftercare - Days");
                                            if (parameterValue != null && parameterValue.IfNumericValue_Value != double.MaxValue)
                                            {
                                                days = parameterValue.IfNumericValue_Value;
                                            }
                                        }

                                        if (pat.date.Date.AddDays(days) < DateTime.Now.Date)
                                        {
                                            pat.status = "AC3";
                                        }

                                        break;
                                    default:
                                        break;
                                }
                            }

                            if (pat.status == "OCT1")
                            {
                                var treatment_year_length_ctr_parameter = contract_parameters.SingleOrDefault(t => t.ParameterName == EContractParameter.PreexaminationsDays.Value());
                                var treatment_year_length = treatment_year_length_ctr_parameter != null ? treatment_year_length_ctr_parameter.IfNumericValue_Value : 365;
                                var max_octs_parameter = contract_parameters.SingleOrDefault(t => t.ParameterName == EContractParameter.MaxNumberOfOcts.Value());
                                var max_octs_per_treatment_year = max_octs_parameter != null ? max_octs_parameter.IfNumericValue_Value : double.MaxValue;
                                var max_days_before_submit_parameter = contract_parameters.SingleOrDefault(x => x.ParameterName == EContractParameter.NumberOfDaysBetweenTreatmentAndSettlement.Value());
                                var max_days_to_submit_oct = max_days_before_submit_parameter != null && max_days_before_submit_parameter.IfNumericValue_Value < 2000000 ? max_days_before_submit_parameter.IfNumericValue_Value : 0;
                                var useSettlementYear = contract_parameters.SingleOrDefault(t => t.ParameterName == EContractParameter.UseSettlementYear.Value()) != null;

                                var min_treatment_year_start_date = treatment_year_length != 0 ? DateTime.Now.Date.AddDays(-treatment_year_length) : DateTime.MinValue;

                                var op_dates = op_dates_with_localization.ContainsKey(Guid.Parse(pat.patient_id)) ? op_dates_with_localization[Guid.Parse(pat.patient_id)] : null;

                                var treatment_year_start = cls_Get_TreatmentYear.Invoke(dbConnection, dbTransaction, new P_CAS_GTY_1125()
                                {
                                    Date = pat.date,
                                    LocalizationCode = pat.localisation,
                                    PatientID = id
                                }, securityTicket).Result;

                                var oct_count = cls_Get_TreatmentYearOctCount.Invoke(dbConnection, dbTransaction, new P_CAS_GTYOctC_1939()
                                {
                                    OctPlannedActionTypeID = oct_planned_action_type_id,
                                    LocalizationCode = pat.localisation,
                                    PatientID = id,
                                    TreatmentYearStartDate = treatment_year_start,
                                    TreatmentYearEndDate = treatment_year_start.AddDays(treatment_year_length)
                                }, securityTicket).Result.fs_status_count;

                                if (useSettlementYear)
                                {
                                    var orher_localization = pat.localisation == "L" ? "R" : "L";

                                    oct_count += cls_Get_TreatmentYearOctCount.Invoke(dbConnection, dbTransaction, new P_CAS_GTYOctC_1939()
                                    {
                                        OctPlannedActionTypeID = oct_planned_action_type_id,
                                        LocalizationCode = orher_localization,
                                        PatientID = id,
                                        TreatmentYearStartDate = treatment_year_start,
                                        TreatmentYearEndDate = treatment_year_start.AddDays(treatment_year_length)
                                    }, securityTicket).Result.fs_status_count;
                                }

                                //if (op_dates != null && op_dates.Any(x => x.localization_code == pat.localisation && x.case_id == Guid.Parse(pat.case_id)))
                                if (op_dates != null && op_dates.Any(x => x.localization_code == pat.localisation))
                                {
                                    var last_op_date = op_dates.First(x => x.localization_code == pat.localisation);
                                    var overdue_start_date = last_op_date.treatment_date.AddDays(treatment_year_length);
                                    var overdue_end_date = overdue_start_date.AddDays(max_days_to_submit_oct);

                                    if (oct_count < max_octs_per_treatment_year && overdue_start_date <= DateTime.Now.Date && DateTime.Now.Date <= overdue_end_date)
                                    {
                                        pat.status = "OCT3";
                                    }
                                    else if (oct_count >= max_octs_per_treatment_year && treatment_year_start >= min_treatment_year_start_date)
                                    {
                                        pat.status = "OCT5";
                                    }
                                }
                                else
                                {
                                    var overdue_start_date = pat.date.AddDays(treatment_year_length);
                                    var overdue_end_date = overdue_start_date.AddDays(max_days_to_submit_oct);
                                    if (oct_count < max_octs_per_treatment_year && overdue_start_date <= DateTime.Now.Date && DateTime.Now.Date <= overdue_end_date)
                                    {
                                        pat.status = "OCT3";
                                    }
                                    else if (oct_count >= max_octs_per_treatment_year && pat.date >= min_treatment_year_start_date)
                                    {
                                        pat.status = "OCT5";
                                    }
                                }
                            }

                            if (pat.detail_type == "ac")
                            {
                                var case_id = Guid.Parse(pat.case_id);
                                if (op_dates_for_acs.ContainsKey(case_id))
                                {
                                    pat.op_date_string = op_dates_for_acs[case_id].ToString("dd.MM.yyyy");
                                }
                            }

                            if (!pat.is_my_practice)
                            {
                                if (pat.status != "FS1")
                                {
                                    if (!statuses_to_preserve.Any(x => x == pat.status))
                                    {
                                        pat.status = "FS1";
                                    }
                                }

                                return pat;
                            }

                            if (pat.detail_type == "ac" && open_ac_statuses.Any(t => t == pat.status))
                            {
                                if (!String.IsNullOrEmpty(pat.aftercare_doctor_practice_id))
                                {
                                    pat.is_ac_submissible = Guid.Parse(pat.aftercare_doctor_practice_id) != userData.PracticeID;
                                }
                            }

                            if (pat.case_id != null && pat.detail_type != "order")
                            {
                                var case_id = Guid.Parse(pat.case_id);

                                pat.is_edit_button_visible = true;

                                if (pat.status != "FS0")
                                {
                                    if (pat.status == "FS6")
                                    {
                                        pat.is_edit_button_visible = userData.AccountInformation.role.Contains("mm.docconect.doc.app.op") ? true : pat.detail_type == "ac";
                                        var is_aftercare_performed = cls_Get_is_Aftercare_Performed_for_CaseID.Invoke(dbConnection, dbTransaction, new P_CAS_GiAPfCID_1130() { CaseID = case_id }, securityTicket).Result;
                                        pat.is_aftercare_performed = is_aftercare_performed != null ? is_aftercare_performed.is_aftercare_performed : false;
                                    }
                                    else if (pat.status == "FS8")
                                    {
                                        pat.is_edit_button_visible = false;
                                    }
                                    else if (pat.status == "OP4")
                                    {
                                        pat.is_edit_button_visible = false;
                                    }
                                    else if (pat.status == "OCT4")
                                    {
                                        pat.is_edit_button_visible = false;
                                    }
                                    else if ((pat.detail_type == "op" || pat.detail_type == "ac") && fsCache.ContainsKey(case_id))
                                    {
                                        var fs_statuses = fsCache[case_id];

                                        if (pat.detail_type == "op")
                                        {
                                            var filtered_fs_statuses = fs_statuses.Where(fs => fs.gpos_type == "mm.docconnect.gpos.catalog.nachsorge").ToArray();
                                            if (filtered_fs_statuses.Length == 0)
                                            {
                                                var ac_planned_action = cls_Get_Aftercare_Planned_Action_for_CaseID.Invoke(dbConnection, dbTransaction, new P_CAS_GAPAfCID_0959() { CaseID = case_id }, securityTicket).Result;
                                                pat.is_edit_button_visible = ac_planned_action != null ? !ac_planned_action.is_cancelled : false;
                                            }
                                            else if (filtered_fs_statuses.Length == 1)
                                            {
                                                var fs_status = filtered_fs_statuses.Single();
                                                if (fs_status != null)
                                                {
                                                    if (fs_status.fs_status == 8 || fs_status.fs_status == 17 || fs_status.fs_status == 11)
                                                    {
                                                        var op_status = fs_statuses.Where(fs => fs.gpos_type == "mm.docconnect.gpos.catalog.operation").First().fs_status;
                                                        pat.is_edit_button_visible = op_status != 8;
                                                    }
                                                    else
                                                    {
                                                        pat.is_edit_button_visible = false;
                                                    }
                                                }
                                                else
                                                {
                                                    pat.is_edit_button_visible = true;
                                                }
                                            }
                                            else
                                            {
                                                pat.is_edit_button_visible = !filtered_fs_statuses.Any(fs => fs.fs_status != 8 && fs.fs_status != 11 && fs.fs_status != 17);
                                            }
                                        }
                                        else
                                        {
                                            pat.is_edit_button_visible = false;
                                        }
                                    }
                                    else if (pat.status == "FS13")
                                    {
                                        pat.is_edit_button_visible = false;
                                    }
                                }
                            }

                            if (pat.detail_type == "op" && pat.status == "FS13" && missingIvomCaseIds.Any(t => t == Guid.Parse(pat.case_id)))
                            {
                                var case_id = Guid.Parse(pat.case_id);

                                if (oct_ids.ContainsKey(case_id))
                                {
                                    var octs = oct_ids[case_id];
                                    if (octs.Count == 1)
                                    {
                                        pat.is_deleteable = true;
                                    }
                                    else
                                    {
                                        var fs_statuses = fsCache[case_id];
                                        var case_bill_positions = bill_positions[case_id];
                                        var total_octs = 0;
                                        for (var i = 0; i < octs.Count; i++)
                                        {
                                            if (case_bill_positions.Count > i)
                                            {
                                                var fs_status = fs_statuses.SingleOrDefault(fs => fs.bill_position_id == case_bill_positions[i].bill_position_id);
                                                if (fs_status == null || (fs_status.fs_status != 8 && fs_status.fs_status != 11 && fs_status.fs_status != 17))
                                                {
                                                    total_octs++;
                                                    if (total_octs > 1)
                                                    {
                                                        break;
                                                    }
                                                }
                                            }
                                        }

                                        pat.is_deleteable = total_octs < 2;
                                    }
                                }
                                else
                                {
                                    pat.is_deleteable = true;
                                }
                            }
                        }
                        #endregion

                        return pat;
                    }).ToList();

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
                Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, ex), userData.PracticeName);

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }
            return patientDetailList;
        }

        public PatientDataWithInitalData Get_PatientDataWithInitalData(Guid patientId, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            PatientDataWithInitalData data = new PatientDataWithInitalData();
            List<ContractModel> ContractList = new List<ContractModel>();
            transaction = new TransactionalInformation();

            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);
            var securityTicket = VerifySessionToken(sessionTicket);
            var userData = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            try
            {
                using (var dbConnection = DBSQLSupport.CreateConnection(connectionString))
                {
                    dbConnection.Open();
                    var dbTransaction = dbConnection.BeginTransaction();
                    var patient = cls_Get_PatientEdit_Data_for_PatientID.Invoke(dbConnection, dbTransaction, new P_PA_GPDfPID_1101() { PatientID = patientId }, securityTicket).Result;

                    var contracts = cls_Get_Contracts_Where_Hip_Participating_for_HipID.Invoke(dbConnection, dbTransaction, new P_PA_GCwHipPfHipID_0954() { HipIkNumber = patient.hip_ik_number }, securityTicket).Result;

                    foreach (var item in contracts)
                    {
                        ContractModel model = new ContractModel();
                        model.id = item.ContractID.ToString();
                        model.name = item.ContractName;
                        model.ValidFrom = item.ValidFrom;
                        model.ValidTo = item.ValidThrough;
                        model.participation_consent_valid_days = item.ParticipationConsentValidForMonths;
                        ContractList.Add(model);
                    }

                    data.ContractList = ContractList;

                    data.PatientData.birthday = patient.birthday.ToString("dd.MM.yyyy");
                    data.PatientData.contract_id = patient.contract_id.ToString();
                    data.PatientData.first_name = patient.first_name;
                    data.PatientData.health_insurance_provider = new HipModel()
                    {
                        id = patient.health_insurance_provider_id,
                        display_name = patient.hip_display_name,
                        secondary_display_name = patient.hip_ik_number,
                        name = patient.hip_name
                    };

                    data.PatientData.id = patient.id.ToString();
                    data.PatientData.insurance_id = patient.insurance_id;
                    data.PatientData.participation_id = patient.participation_id.ToString();
                    data.PatientData.last_name = patient.last_name;
                    data.PatientData.participation_consent_date = patient.valid_from.ToString("dd.MM.yyyy");
                    data.PatientData.insurance_status = patient.insurance_status;
                    data.PatientData.hasParticipationConsent = patient.valid_from != DateTime.MinValue;
                    data.PatientData.sex = patient.sex.ToString();
                    data.PatientData.is_privately_insured = patient.insurance_id == "privat";

                    var external_id = cls_Get_Patient_Properties_for_PatientID_and_PropertyGpmID.Invoke(connectionString, new P_PA_GPPfPIDaPGpmID_1620()
                    {
                        PatientID = patientId,
                        PropertyGpmID = EPatientProperty.ExternalId.Value()
                    }, securityTicket).Result.SingleOrDefault();

                    if (external_id != null)
                    {
                        data.PatientData.external_id = external_id.string_value;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, ex), userData.PracticeName);

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }

            return data;
        }

        public object CheckPatientFeeWaiverForYear(Guid patient_id, string issue_date, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();

            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);
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

                    var patientFeeWaivedProperty = ORM_HEC_Patient_UniversalProperty.Query.Search(dbConnection, dbTransaction, new ORM_HEC_Patient_UniversalProperty.Query()
                    {
                        GlobalPropertyMatchingID = EPatientProperty.FeeWaived.Value(),
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).SingleOrDefault();

                    if (patientFeeWaivedProperty == null)
                    {
                        return new { exists = false };
                    }

                    var patientFeeWaivedPropertyValues = ORM_HEC_Patient_UniversalPropertyValue.Query.Search(dbConnection, dbTransaction, new ORM_HEC_Patient_UniversalPropertyValue.Query()
                    {
                        HEC_Patient_RefID = patient_id,
                        HEC_Patient_UniversalProperty_RefID = patientFeeWaivedProperty.HEC_Patient_UniversalPropertyID,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    });

                    if (!patientFeeWaivedPropertyValues.Any())
                    {
                        return new { exists = false };
                    }

                    var date = DateTime.ParseExact(issue_date, "dd.MM.yyyy", new CultureInfo("de", true));

                    var patientFeeWaivedDates = patientFeeWaivedPropertyValues.Select(t => DateTime.Parse(t.Value_String)).ToList();
                    if (patientFeeWaivedDates.Any(t => t.Year == date.Year))
                    {
                        return new { exists = true, year = date.Year };
                    }

                    dbTransaction.Commit();

                    return new { exists = false };
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

        public Guid Get_ContractIDForParticipationID(Guid participationID, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);
            var securityTicket = VerifySessionToken(sessionTicket);
            transaction = new TransactionalInformation();
            Guid contractID = Guid.Empty;
            try
            {
                contractID = cls_Get_ContractIDForParticipationID.Invoke(connectionString, new P_PA_GCIDfPID_1211 { ParticipationID = participationID }, securityTicket).Result.contract_id;
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

            return contractID;
        }

        public IEnumerable<object> GetUsedHips(string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);
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

                    var patient_ids_in_practice = ORM_HEC_Patient_MedicalPractice.Query.Search(dbConnection, dbTransaction, new ORM_HEC_Patient_MedicalPractice.Query()
                    {
                        HEC_MedicalPractices_RefID = data.PracticeID,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).Select(x => x.HEC_Patient_RefID).ToList();

                    var doctor_bpt_ids_in_practice = cls_Get_DoctorBptIDs_for_PracticeID.Invoke(dbConnection, dbTransaction, new P_DO_GDBptIDsfPID_1621()
                    {
                        PracticeID = data.PracticeID
                    }, securityTicket).Result.Select(x => x.doctor_bpt_id).ToArray();

                    if (doctor_bpt_ids_in_practice.Any(t => t != Guid.Empty))
                    {
                        var aftercare_planned_action_type_id = cls_Get_ActionTypeID.Invoke(dbConnection, dbTransaction, new P_CAS_GATID_1514() { action_type_gpmid = EActionType.PlannedAftercare.Value() }, securityTicket).Result;
                        var oct_planned_action_type_id = cls_Get_ActionTypeID.Invoke(dbConnection, dbTransaction, new P_CAS_GATID_1514() { action_type_gpmid = EActionType.PlannedOct.Value() }, securityTicket).Result;

                        var patient_ids_used_in_practice = cls_Get_PatientIDs_used_in_Practice_for_DoctorBptIDs.Invoke(dbConnection, dbTransaction, new P_CAS_GPIDsuiPfDBptIDs_1016()
                        {
                            DoctorBptIDs = doctor_bpt_ids_in_practice,
                            PracticeID = data.PracticeID,
                            AftercarePlannedActionTypeID = aftercare_planned_action_type_id,
                            OctPlannedActionTypeID = oct_planned_action_type_id
                        }, securityTicket).Result.Select(t => t.patient_id).ToList();

                        if (patient_ids_used_in_practice.Any(t => t != Guid.Empty))
                        {
                            patient_ids_in_practice.AddRange(patient_ids_used_in_practice);
                        }
                    }

                    if (patient_ids_in_practice.Any(t => t != Guid.Empty))
                    {
                        var used_hips = cls_Get_Used_HIPs_for_PatientIDs.Invoke(dbConnection, dbTransaction, new P_PAGUHipsfPIDs_1027() { PatientIDs = patient_ids_in_practice.ToArray() }, securityTicket).Result;

                        dbTransaction.Commit();
                        return used_hips.Select(t => new { display_name = Int32.Parse(t.hip_ik_number) != 0 ? String.Format("{0} ({1})", t.hip_name, t.hip_ik_number) : t.hip_name, name = t.hip_name });
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

            return Enumerable.Empty<object>();
        }

        public bool PatientDetailsAccessible(Guid patient_id, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);
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

                    var patient_practice = cls_Get_Patient_PracticeName_for_PatientID.Invoke(dbConnection, dbTransaction, new P_P_PA_GPPNfPID_1131() { PatientID = patient_id }, securityTicket).Result;
                    if (patient_practice.practice_id == data.PracticeID)
                    {
                        return true;
                    }

                    var practice_bpt_id = cls_Get_Practice_BptID_for_PracticeID.Invoke(dbConnection, dbTransaction, new P_DO_GPBptIDfPID_1446() { PracticeID = data.PracticeID }, securityTicket).Result.practice_bpt_id;
                    var doctor_bpt_ids = cls_Get_DoctorBptIDs_for_PracticeID.Invoke(dbConnection, dbTransaction, new P_DO_GDBptIDsfPID_1621() { PracticeID = data.PracticeID }, securityTicket).Result.Select(x => x.doctor_bpt_id).ToList();
                    doctor_bpt_ids.Add(practice_bpt_id);

                    var planned_action = cls_Get_PatientData_Accessible_for_BptIDs.Invoke(dbConnection, dbTransaction, new P_PA_GPDAfBPTIDs_0849() { BptIDs = doctor_bpt_ids.ToArray(), PatientID = patient_id }, securityTicket).Result;
                    return planned_action != null && planned_action.HEC_ACT_PlannedActionID != Guid.Empty;
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

            return false;
        }
        #endregion

        #region MANIPULATION
        public void DeleteAutoGeneratedMissingIvom(Guid case_id, string connectionString, string sessionTicket, out TransactionalInformation transaction, DbConnection dbConnection = null, DbTransaction dbTransaction = null)
        {
            transaction = new TransactionalInformation();
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = HttpContext.Current != null ? Util.GetIPInfo(HttpContext.Current.Request) : new IPInfo() { address = "none", agent = "none" };
            var securityTicket = VerifySessionToken(sessionTicket);
            var userData = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            try
            {
                var handleConnection = dbConnection == null;

                try
                {
                    if (handleConnection)
                    {
                        dbConnection = DBSQLSupport.CreateConnection(connectionString);
                        dbConnection.Open();
                        dbTransaction = dbConnection.BeginTransaction();
                    }

                    documentationOnlyService.DeleteOpData(new List<Guid> { case_id }, new List<Guid> { }, dbConnection, dbTransaction, securityTicket);

                    if (handleConnection)
                    {
                        dbTransaction.Commit();
                    }
                    Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, case_id), userData.PracticeName);
                }
                finally
                {
                    if (handleConnection)
                    {
                        dbConnection.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, ex), userData.PracticeName);

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }
        }

        public Guid CreatePatient(Patient patient, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();
            IFormatProvider culture = new System.Globalization.CultureInfo("de", true);
            Guid patient_id = Guid.Empty;

            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = HttpContext.Current != null ? Util.GetIPInfo(HttpContext.Current.Request) : new IPInfo() { address = "none", agent = "none" };
            var securityTicket = VerifySessionToken(sessionTicket);
            var userData = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            IEnumerable<IEnumerable<IElasticMapper>> elastic_backup = null;

            try
            {
                #region PARAMETER
                P_PA_SP_1013 param = new P_PA_SP_1013();
                param.bithday = DateTime.Parse(patient.bithday, culture, System.Globalization.DateTimeStyles.AssumeLocal);
                param.first_name = patient.first_name;
                param.is_privately_insured = patient.is_privately_insured;
                if (!param.is_privately_insured)
                {
                    string insurance_status = patient.insurance_status.Replace(" ", String.Empty);
                    if (insurance_status.Length == 1)
                        insurance_status = insurance_status + "  ";
                    else if (insurance_status.Length == 2)
                    {
                        char[] charArr = insurance_status.ToCharArray();
                        insurance_status = charArr[0].ToString() + " " + charArr[1].ToString() + "  ";
                    }
                    else if (insurance_status.Length == 3)
                    {
                        char[] charArr = insurance_status.ToCharArray();
                        insurance_status = charArr[0].ToString() + " " + charArr[1].ToString() + " " + charArr[2].ToString();
                    }
                    else if (insurance_status.Length == 5)
                    {
                        char[] charArr = insurance_status.ToCharArray();
                        insurance_status = charArr[0].ToString() + charArr[1].ToString() + charArr[2].ToString() + charArr[3].ToString() + " " + charArr[4].ToString();
                    }
                    param.insurance_status = insurance_status;
                    param.health_insurance_provider_id = GetHealthInsuranceCompanyIDs(patient.health_insurance_provider, connectionString, securityTicket);
                }
                param.id = string.IsNullOrEmpty(patient.id) ? Guid.Empty : new Guid(patient.id);
                param.insurance_id = patient.insurance_id;

                param.last_name = patient.last_name;
                param.medical_practice_id = userData.PracticeID;
                param.sex = Int32.Parse(patient.sex);
                param.hip_changed = patient.hip_changed;

                if (patient.contract != null && patient.contract.id != null)
                {
                    param.hasParticipationConsent = true;
                    param.contract_id = new Guid(patient.contract.id);
                    if (patient.contract.participation_consent_valid_days != 0)
                        param.issue_date_to = DateTime.Parse(patient.issue_date, culture, System.Globalization.DateTimeStyles.AssumeLocal).AddMonths(Int32.Parse(patient.contract.participation_consent_valid_days.ToString()));
                    else
                        param.issue_date_to = DateTime.Parse(patient.contract.ValidTo, null, System.Globalization.DateTimeStyles.RoundtripKind).AddMonths(Int32.Parse(patient.contract.participation_consent_valid_days.ToString()));
                    param.issue_date_from = DateTime.Parse(patient.issue_date, culture, System.Globalization.DateTimeStyles.AssumeLocal);
                    if (patient.participation_id != null)
                        param.participation_id = new Guid(patient.participation_id);
                }

                param.external_id = patient.external_id;
                #endregion

                #region UPDATE ELASTIC ON BASE CHANGE
                Guid.TryParse(patient.id, out patient_id);
                if (patient.id != null && patient_id != Guid.Empty)
                {
                    var patient_details = cls_Get_Patient_Details_for_PatientID.Invoke(connectionString, new P_P_PA_GPDfPID_1124() { PatientID = patient_id }, securityTicket).Result;
                    if (patient_details != null)
                    {
                        if (patient_details.birthday.ToString("dd.MM.yyyy") != patient.bithday || patient_details.patient_first_name != patient.first_name || patient_details.patient_last_name != patient.last_name || patient_details.insurance_id != patient.insurance_id)
                        {
                            elastic_backup = Elastic_Rollback.GetBackup(securityTicket.TenantID.ToString(), patient.id, "patient");

                            var values = new string[] {
                                patient.last_name + ", " + patient.first_name,
                                patient.insurance_id,
                                patient.bithday                                
                            };

                            var elastic_data = Elastic_Rollback.GetUpdatedData(securityTicket.TenantID.ToString(), patient.id, "patient", values);

                            Elastic_Rollback.InsertDataIntoElastic(elastic_data, securityTicket.TenantID.ToString());
                        }
                    }
                }
                #endregion

                Patient previous_state = null;

                if (patient_id != Guid.Empty)
                {
                    Thread detailsThread = new Thread(() => GetPatientPreviousDetails(out previous_state, patient_id, connectionString, securityTicket));
                    detailsThread.Start();
                }

                patient_id = cls_Save_Patient.Invoke(connectionString, param, securityTicket).Result;

                Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, patient, previous_state), userData.PracticeName);
            }
            catch (Exception ex)
            {
                Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, ex), userData.PracticeName);

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }

            return patient_id;
        }

        public void SaveParticipationConsent(ParticipationConsent participation_consent, string connectionString, string sessionTicket, out TransactionalInformation transaction, DbConnection dbConnection = null, DbTransaction dbTransaction = null)
        {
            var handle_connection = dbConnection == null;
            var handle_transaction = dbTransaction == null;

            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = HttpContext.Current != null ? Util.GetIPInfo(HttpContext.Current.Request) : new IPInfo() { address = "none", agent = "none" };
            var securityTicket = VerifySessionToken(sessionTicket);
            var userData = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            transaction = new TransactionalInformation();
            IFormatProvider culture = new System.Globalization.CultureInfo("de", true);
            try
            {
                if (handle_connection)
                {
                    dbConnection = DBSQLSupport.CreateConnection(connectionString);
                    dbConnection.Open();
                }

                if (handle_transaction)
                {
                    dbTransaction = dbConnection.BeginTransaction();
                }

                cls_Save_Patient_Participation_Consent.Invoke(dbConnection, dbTransaction, new P_PA_SPPC_1413
                {
                    contract_id = participation_consent.contract_id,
                    practice_id = userData.PracticeID,
                    contract_ValidTo = participation_consent.contract_ValidTo,
                    issue_date = DateTime.Parse(participation_consent.issue_date, culture, System.Globalization.DateTimeStyles.AssumeLocal),
                    participation_consent_valid_days = participation_consent.participation_consent_valid_days,
                    patient_id = participation_consent.patient_id,
                    participation_id = participation_consent.participation_id
                }, securityTicket);

                Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, participation_consent), userData.PracticeName);

                if (handle_transaction)
                {
                    dbTransaction.Commit();
                }
            }
            catch (Exception ex)
            {

                Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, ex), userData.PracticeName);

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }
            finally
            {
                if (handle_connection)
                {
                    dbConnection.Close();
                }
            }
        }

        public void SavePatientFeeWaiver(Guid patient_id, string issue_date, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();

            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);
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

                    var date = DateTime.ParseExact(issue_date, "dd.MM.yyyy", new CultureInfo("de", true));

                    var patientFeeWaivedProperty = ORM_HEC_Patient_UniversalProperty.Query.Search(dbConnection, dbTransaction, new ORM_HEC_Patient_UniversalProperty.Query()
                    {
                        GlobalPropertyMatchingID = EPatientProperty.FeeWaived.Value(),
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).SingleOrDefault();

                    if (patientFeeWaivedProperty == null)
                    {
                        patientFeeWaivedProperty = new ORM_HEC_Patient_UniversalProperty();
                        patientFeeWaivedProperty.GlobalPropertyMatchingID = EPatientProperty.FeeWaived.Value();
                        patientFeeWaivedProperty.IsValue_String = true;
                        patientFeeWaivedProperty.Modification_Timestamp = DateTime.Now;
                        patientFeeWaivedProperty.Tenant_RefID = securityTicket.TenantID;
                        patientFeeWaivedProperty.PropertyName = "Patient fee waived";

                        patientFeeWaivedProperty.Save(dbConnection, dbTransaction);
                    }

                    var patientFeeWaivedPropertyValue = new ORM_HEC_Patient_UniversalPropertyValue();
                    patientFeeWaivedPropertyValue.HEC_Patient_RefID = patient_id;
                    patientFeeWaivedPropertyValue.HEC_Patient_UniversalProperty_RefID = patientFeeWaivedProperty.HEC_Patient_UniversalPropertyID;
                    patientFeeWaivedPropertyValue.Modification_Timestamp = DateTime.Now;
                    patientFeeWaivedPropertyValue.Tenant_RefID = securityTicket.TenantID;
                    patientFeeWaivedPropertyValue.Value_String = date.ToString("yyyy-MM-ddTHH:mm:ss");

                    patientFeeWaivedPropertyValue.Save(dbConnection, dbTransaction);

                    var patient_details = new PatientDetailViewModel();
                    patient_details.date = date;
                    patient_details.date_string = issue_date;
                    patient_details.detail_type = "fee_waiver";
                    patient_details.id = patientFeeWaivedPropertyValue.HEC_Patient_UniversalPropertyValueID.ToString();
                    patient_details.patient_id = patient_id.ToString();
                    patient_details.practice_id = data.PracticeID.ToString();

                    Add_New_Patient.ImportPatientDetailsToElastic(new List<PatientDetailViewModel>() { patient_details }, securityTicket.TenantID.ToString());

                    dbTransaction.Commit();

                    Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, new { patient_id = patient_id, issue_date = issue_date }), data.PracticeName);
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

        public void DeletePatientFeeWaiver(Guid id, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();

            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);
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

                    var patientFeeWaivedProperty = ORM_HEC_Patient_UniversalProperty.Query.Search(dbConnection, dbTransaction, new ORM_HEC_Patient_UniversalProperty.Query()
                    {
                        GlobalPropertyMatchingID = EPatientProperty.FeeWaived.Value(),
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).SingleOrDefault();

                    if (patientFeeWaivedProperty == null)
                    {
                        patientFeeWaivedProperty = new ORM_HEC_Patient_UniversalProperty();
                        patientFeeWaivedProperty.GlobalPropertyMatchingID = EPatientProperty.FeeWaived.Value();
                        patientFeeWaivedProperty.IsValue_String = true;
                        patientFeeWaivedProperty.Modification_Timestamp = DateTime.Now;
                        patientFeeWaivedProperty.Tenant_RefID = securityTicket.TenantID;
                        patientFeeWaivedProperty.PropertyName = "Patient fee waived";

                        patientFeeWaivedProperty.Save(dbConnection, dbTransaction);
                    }

                    ORM_HEC_Patient_UniversalPropertyValue.Query.SoftDelete(dbConnection, dbTransaction, new ORM_HEC_Patient_UniversalPropertyValue.Query()
                    {
                        HEC_Patient_UniversalPropertyValueID = id
                    });

                    Elastic_Utils.Delete_Item(securityTicket.TenantID.ToString(), "patient_details", id.ToString());

                    dbTransaction.Commit();

                    Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, id), data.PracticeName);
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
        #endregion

        #region VALIDATION

        public bool CanChangeHIP(Guid PatientID, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);
            var securityTicket = VerifySessionToken(sessionTicket);
            var userData = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            transaction = new TransactionalInformation();
            try
            {
                return !cls_Get_NonPerformed_Case_Data_for_PatientID.Invoke(connectionString, new P_CAS_GNPCDfPID_1320() { PatientID = PatientID }, securityTicket).Result.Any();
            }
            catch (Exception ex)
            {
                Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, ex), userData.PracticeName);

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }

            return true;
        }
        /// <summary>
        /// Check if combination of patient first, last name and health insurance number is unique
        /// </summary>       
        public HealthInsuranceCheck Check_if_HINumberUnique(bool isOldValidationPHIS, Guid patient_id, string firstName, string lastName, string InsuranceNumber, string birthday, string health_insuracne_status, int sex, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);
            var securityTicket = VerifySessionToken(sessionTicket);
            var userData = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            transaction = new TransactionalInformation();
            HealthInsuranceCheck healthInsuranceCheck = new HealthInsuranceCheck();
            try
            {
                List<warning_message> warning_messages_list = new List<warning_message>();

                //check if InsuranceNumber contains only numbers

                if (!CheckIFValidationRulesForNewValidationRulesAreOK(InsuranceNumber))
                {
                    long insuranceNumberLong;
                    bool isNumbersOnly = long.TryParse(InsuranceNumber, out insuranceNumberLong);

                    if (!isNumbersOnly)
                        throw new System.Exception("Old insurance number can be ny numbers.");
                    else
                    {
                        warning_message warning_message = new warning_message();
                        warning_message.messaga = "LABEL_ERROR_NEW_KVR_VALIDATION";
                        warning_message.first_name = "";
                        warning_message.last_name = "";
                        warning_messages_list.Add(warning_message);
                    }
                }

                //check if health_insuracne_status matches patient data
                if (health_insuracne_status.Replace(" ", "").Length == 5)
                {
                    if (!ChecKIfPatientDataCorrespondsWithHealthInsuranceStatusCode(health_insuracne_status, sex, birthday))
                    {
                        warning_message warning_message = new warning_message();
                        warning_message.messaga = "LABEL_PATIENTDATA_NOT_ALIGNRD_WITH_HIN";
                        warning_message.first_name = "";
                        warning_message.last_name = "";
                        warning_messages_list.Add(warning_message);
                    }

                    warning_message warning_message_oldValidation = new warning_message();
                    warning_message_oldValidation.messaga = "LABEL_OLD_INSURANCE_STATUS_VALIDATION";
                    warning_message_oldValidation.first_name = health_insuracne_status.Replace(" ", String.Empty);
                    warning_message_oldValidation.last_name = "";
                    warning_messages_list.Add(warning_message_oldValidation);

                }
                var isHINumberUniqueMessage = cls_Check_if_HINumberUnique.Invoke(connectionString, new P_PA_CIHINU_1023 { InsuranceNumber = InsuranceNumber, MedicalPracticeID = userData.PracticeID, PatientID = patient_id }, securityTicket).Result.ToList();
                if (!isHINumberUniqueMessage[0].isHINumberUnique)
                {
                    warning_message warning_message = new warning_message();
                    warning_message.messaga = "LABEL_HIN_MATCHES_ANY_OTHER_PATIENT_IN_PRACTICE";
                    warning_message.first_name = isHINumberUniqueMessage[0].FirstName;
                    warning_message.last_name = isHINumberUniqueMessage[0].LastName;
                    warning_messages_list.Add(warning_message);
                }
                if (!(cls_Check_if_TheSamePatientExists.Invoke(connectionString, new P_PA_CITSPE_0917 { FirstName = firstName.ToLower(), LastName = lastName.ToLower(), Birthday = UtilMethods.getDateStringForDB(birthday, "de"), MedicalPracticeID = userData.PracticeID, PatientID = patient_id }, securityTicket).Result.Single().isPatientUnique))
                {
                    warning_message warning_message = new warning_message();
                    warning_message.messaga = "LABEL_COMBINATION_FIRST_LAST_NAME_HIM_MATCHES";
                    warning_message.first_name = firstName;
                    warning_message.last_name = lastName;
                    warning_messages_list.Add(warning_message);

                }

                if (warning_messages_list.Count > 0)
                {
                    warning_message warning_message = new warning_message();
                    warning_message.messaga = "LABEL_DO_YOU_WANT_TO_CONTINUE";
                    warning_message.first_name = "";
                    warning_message.last_name = "";
                    warning_messages_list.Add(warning_message);
                    healthInsuranceCheck.isValid = false;
                }


                healthInsuranceCheck.warning_messages = warning_messages_list;
            }
            catch (Exception ex)
            {
                Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, ex), userData.PracticeName);

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }
            return healthInsuranceCheck;
        }

        private IEnumerable<dynamic> checkIfNewInsuranceStatusNumberValid(string insuranceStatusNumber)
        {
            List<dynamic> result = new List<dynamic>();

            var validFirstDigitValues = new char[] { '1', '3', '5' };
            var validSecondDigitValues = new char[] { '4', '6', '7', '8' };
            var validThirdDigitValues = new char[] { '1', '2', '3', '4', '5', '6' };

            if (!validFirstDigitValues.Any(t => t == insuranceStatusNumber[0]))
                result.Add(new { valid = false, reason = "FIRST_DIGIT" });

            if (insuranceStatusNumber.Length > 1)
            {
                if (!validSecondDigitValues.Any(t => t == insuranceStatusNumber[1]))
                    result.Add(new { valid = false, reason = "SECOND_DIGIT" });

                if (insuranceStatusNumber.Length > 2)
                {
                    if (!validThirdDigitValues.Any(t => t == insuranceStatusNumber[2]))
                        result.Add(new { valid = false, reason = "THIRD_DIGIT" });
                }
            }

            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="insuranceNumber"></param>
        /// <param name="connectionString"></param>
        /// <param name="sessionTicket"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool CheckIfKVNRIsValid(string insuranceNumber, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);
            var securityTicket = VerifySessionToken(sessionTicket);
            var userData = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            transaction = new TransactionalInformation();
            bool isValid = false;
            try
            {
                isValid = CheckIFValidationRulesForNewValidationRulesAreOK(insuranceNumber);
            }
            catch (Exception ex)
            {
                Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, ex), userData.PracticeName);

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }
            return isValid;
        }
        #endregion

        #region UTIL
        //#Helper function ##########################################
        /// <summary>
        /// 
        /// </summary>
        /// <param name="health_insuracne_status"></param>
        /// <param name="sex"></param>
        /// <param name="birthday"></param>
        /// <returns></returns>
        public bool ChecKIfPatientDataCorrespondsWithHealthInsuranceStatusCode(string health_insuracne_status, int sex, string birthday)
        {
            var healthInsuranceStatus = health_insuracne_status.Replace(" ", "");
            if (healthInsuranceStatus.Length == 5)
            {
                char[] statusCodeArray = health_insuracne_status.ToCharArray();
                char[] female = new char[] { '1', '3', '5', '7' };
                char[] male = new char[] { '2', '4', '6', '8' };

                int isFemale = Array.IndexOf(female, statusCodeArray[1]);
                int isMale = Array.IndexOf(male, statusCodeArray[1]);

                if (isFemale == -1)
                {
                    if (sex == 1) return false;
                }

                if (isMale == -1)
                {
                    if (sex == 0) return false;
                }

                if (isFemale == -1 && isMale == -1)
                {
                    if (sex == 2) return false;
                }

                if (Int32.Parse(statusCodeArray[1].ToString()) > 0)
                {
                    string[] birthdayValuesArray = birthday.Split('.');
                    string yearFromHealthInsuranceStatus = statusCodeArray[2].ToString() + statusCodeArray[3].ToString();

                    char[] checkChars = birthdayValuesArray[2].ToCharArray();
                    string checkYear = checkChars[2].ToString() + checkChars[3].ToString();
                    if (yearFromHealthInsuranceStatus != checkYear) return false;
                }
            }
            else
            {
                for (var i = 0; i < healthInsuranceStatus.Length; i++)
                {
                    var statusCharacter = Convert.ToInt32(healthInsuranceStatus[i]);
                    switch (i)
                    {
                        case 0:
                            if (statusCharacter != 1 && statusCharacter != 3 && statusCharacter == 5)
                            {
                                return false;
                            }

                            break;
                        case 1:
                            if (statusCharacter != 4 && statusCharacter != 6 && statusCharacter != 7 && statusCharacter != 8)
                            {
                                return false;
                            }

                            break;
                        case 2:
                            if (statusCharacter < 0 || statusCharacter > 6)
                            {
                                return false;
                            }
                            break;
                        default:
                            break;
                    }
                }
            }

            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="InsuranceNumber"></param>
        /// <returns></returns>
        public bool CheckIFValidationRulesForNewValidationRulesAreOK(string InsuranceNumber)
        {
            if (InsuranceNumber.Length != 10)
                return false;

            char[] statusCodeArray = InsuranceNumber.ToCharArray();
            char[] Alphabet = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            if (!Char.IsLetter(statusCodeArray[0]))
                return false;
            if (Char.IsLower(statusCodeArray[0]))
                return false;
            for (int i = 1; i < statusCodeArray.Length; i++)
            {
                if (!Char.IsDigit(statusCodeArray[i]))
                    return false;
            }

            int checkSum = int.Parse(statusCodeArray[statusCodeArray.Length - 1].ToString());
            int totalSum = 0;
            for (int i = 0; i < statusCodeArray.Length - 1; i++)
            {
                int sum = 0;
                if (i == 0)
                {
                    int replaceInt = Array.IndexOf(Alphabet, statusCodeArray[0]) + 1;

                    if (replaceInt.ToString().Length > 1)
                    {
                        int lastDigit = replaceInt % 10;
                        int firstDigit = replaceInt;
                        while (firstDigit >= 10)
                            firstDigit /= 10;

                        lastDigit = lastDigit * 2;

                        while (lastDigit != 0)
                        {
                            sum += lastDigit % 10;
                            lastDigit /= 10;
                        }
                        totalSum = firstDigit + sum;
                    }
                    else
                    {
                        int num = replaceInt * 2;
                        while (num != 0)
                        {
                            sum += num % 10;
                            num /= 10;
                        }
                        totalSum = sum;
                    }
                }
                else
                {
                    if (i % 2 == 0)
                    {
                        //is even
                        int num = int.Parse(statusCodeArray[i].ToString()) * 2;
                        while (num != 0)
                        {
                            sum += num % 10;
                            num /= 10;
                        }
                        totalSum += sum;

                    }
                    else
                        totalSum += int.Parse(statusCodeArray[i].ToString());
                }
            }

            if (checkSum != (totalSum % 10))
                return false;

            return true;
        }
        private Guid GetHealthInsuranceCompanyIDs(HipModel hip, string connectionString, SessionSecurityTicket securityTicket)
        {
            return cls_Save_New_Insurance_Companies_and_Return_New_IDs.Invoke(connectionString,
                new P_MD_SNICaRNIDs_1653[] 
                {
                    new P_MD_SNICaRNIDs_1653()
                    {
                        HIPName = hip.name,
                        IKNumber = hip.secondary_display_name
                    }
                }, securityTicket).Result.Single();
        }

        private void GetPatientPreviousDetails(out Patient previous_state, Guid id, string connectionString, SessionSecurityTicket securityTicket)
        {
            var patient_details = cls_Get_Patient_Details_for_PatientID.Invoke(connectionString, new P_P_PA_GPDfPID_1124() { PatientID = id }, securityTicket).Result;
            if (patient_details != null)
            {
                previous_state = new Patient()
                {
                    bithday = patient_details.birthday.ToString("dd.MM.yyyy"),
                    contract = new contract() { id = patient_details.contractID.ToString() },
                    first_name = patient_details.patient_first_name,
                    health_insurance_provider = new HipModel() { id = patient_details.HealthInsuranceProviderID, name = patient_details.health_insurance_provider, secondary_display_name = patient_details.HealthInsurance_IKNumber },
                    id = id.ToString(),
                    insurance_id = patient_details.insurance_id,
                    insurance_status = patient_details.insurance_status,
                    last_name = patient_details.patient_last_name,
                    sex = patient_details.gender.ToString(),
                    is_privately_insured = patient_details.insurance_id == "privat"
                };
            }
            else
            {
                previous_state = null;
            }
        }
        #endregion

        #region SUPPORT

        //This method exist in OctService, maybe we should use it from there
        private List<OctHipParameter> GetOCTRangeParameters(DbConnection dbConnection, DbTransaction dbTransaction, SessionSecurityTicket securityTicket, Dictionary<string, List<MD_GHCPoT_1617>> hipData = null)
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

        //This method exist in AftercareDataService, maybe we should use it from there
        private List<AftercareHipParameter> GetACRangeParameters(DbConnection dbConnection, DbTransaction dbTransaction, SessionSecurityTicket securityTicket, Dictionary<string, List<MD_GHCPoT_1617>> hipData = null)
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
                        var daysBetweenSurgeryAndAftercare = Convert.ToInt32(t.Value.First(x => x.ParameterName == EContractParameter.NumberOfDaysBetweenTreatmentAndAftercare.Value()).ParameterValue);
                        var daysToSubmitAftercare = Convert.ToInt32(t.Value.First(x => x.ParameterName == EContractParameter.NumberOfDaysBetweenTreatmentAndSettlement.Value()).ParameterValue);
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

        #endregion

    }
}
