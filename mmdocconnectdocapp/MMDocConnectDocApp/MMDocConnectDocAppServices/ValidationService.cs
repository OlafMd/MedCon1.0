using CL1_CMN_CTR;
using CL1_HEC;
using CL1_HEC_CRT;
using CSV2Core_MySQL.Support;
using DLCore_TokenVerification;
using LogUtils;
using MMDocConnectDBMethods.Case.Atomic.Retrieval;
using MMDocConnectDBMethods.Case.Complex.Retrieval;
using MMDocConnectDBMethods.Doctor.Atomic.Retrieval;
using MMDocConnectDBMethods.MainData.Atomic.Retrieval;
using MMDocConnectDBMethods.MainData.Complex.Retrieval;
using MMDocConnectDBMethods.Patient.Atomic.Retrieval;
using MMDocConnectDocApp;
using MMDocConnectDocAppInterfaces;
using MMDocConnectDocAppModels;
using MMDocConnectElasticSearchMethods.Case.Entity;
using MMDocConnectElasticSearchMethods.Case.Retrieval;
using MMDocConnectElasticSearchMethods.Models;
using MMDocConnectUtils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;

namespace MMDocConnectDocAppServices
{
    public class ValidationService : BaseVerification, IValidationService
    {
        // TODO: cache doctor consents for the multi submit validation

        public List<ConsentValidationResponse> ValidateDoctorsAndPatientsParticipationConsent(Guid case_id, bool is_treatment, bool validate_treatment_doctor, Guid treatment_doctor_id, Guid aftercare_doctor_practice_id, Guid patient_id, string treatment_date_string, string case_treatment_date, Guid diagnose_id, Guid drug_id, string connectionString, string sessionTicket, out TransactionalInformation transaction, bool is_resubmission = false)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            transaction = new TransactionalInformation();
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            List<ConsentValidationResponse> response = new List<ConsentValidationResponse>();
            try
            {
                var dbConnection = DBSQLSupport.CreateConnection(connectionString);
                DbTransaction dbTransaction = null;

                try
                {
                    dbConnection.Open();
                    dbTransaction = dbConnection.BeginTransaction();

                    var treatment_date = DateTime.ParseExact(treatment_date_string, "dd.MM.yyyy", new System.Globalization.CultureInfo("de", true));
                    var case_treatment_datetime = case_treatment_date == null ? DateTime.MinValue : DateTime.ParseExact(case_treatment_date, "dd.MM.yyyy", new System.Globalization.CultureInfo("de", true));
                    var gpos_type = is_treatment ? "mm.docconnect.gpos.catalog.operation" : "mm.docconnect.gpos.catalog.nachsorge";
                    var is_submitted = cls_Get_Case_TransmitionCode_for_CaseID.Invoke(dbConnection, dbTransaction, new P_CAS_GCTCfCID_1427() { CaseID = case_id }, securityTicket).Result.Where(fs => fs.gpos_type == gpos_type).Any();
                    var date_to_check = is_treatment ? treatment_date : case_treatment_datetime;
                    var potential_bill_code_result = cls_Get_GPOS_Potential_Bill_Code_ID_for_Drug_and_Diagnosis.Invoke(dbConnection, dbTransaction, new P_CAS_GGPOSPBCIDfDaD_1501
                    {
                        DiagnosisID = diagnose_id,
                        DrugID = drug_id
                    }, securityTicket).Result;
                    var case_details = cls_Get_Case_Details_for_CaseID.Invoke(dbConnection, dbTransaction, new P_CAS_GCDfCID_1435() { CaseID = case_id }, securityTicket).Result;

                    if (!is_treatment)
                    {
                        var aftercare_planned_action_type_id = cls_Get_ActionTypeID.Invoke(dbConnection, dbTransaction, new P_CAS_GATID_1514() { action_type_gpmid = EActionType.PlannedAftercare.Value() }, securityTicket).Result;
                        var aftercare_doctor_id_in_the_db = cls_Get_Aftercare_DoctorID_for_CaseID.Invoke(dbConnection, dbTransaction, new P_CAS_GADIDfCID_1657()
                        {
                            CaseID = case_id,
                            PlannedActionTypeID = aftercare_planned_action_type_id
                        }, securityTicket).Result;
                        if (aftercare_doctor_id_in_the_db != null)
                        {
                            if (aftercare_doctor_id_in_the_db.aftercare_doctor_id != aftercare_doctor_practice_id)
                            {
                                var email_patient_details = cls_Get_Patient_Details_for_PatientID.Invoke(dbConnection, dbTransaction, new P_P_PA_GPDfPID_1124() { PatientID = case_details.patient_id }, securityTicket).Result;
                                var elastic_doctor_details = cls_Get_Doctor_BasicInformation_for_DoctorID.Invoke(dbConnection, dbTransaction, new P_DO_GDBIfDID_1034() { DoctorID = aftercare_doctor_practice_id }, securityTicket).Result;
                                var relational_doctor_details = cls_Get_Doctor_BasicInformation_for_DoctorID.Invoke(dbConnection, dbTransaction, new P_DO_GDBIfDID_1034() { DoctorID = aftercare_doctor_id_in_the_db.aftercare_doctor_id }, securityTicket).Result;

                                #region E-mail
                                var mailToL = new List<String>();

                                var accountMails = cls_Get_All_Account_LoginEmails_Who_Receive_Notifications.Invoke(dbConnection, dbTransaction, securityTicket).Result.ToList();
                                foreach (var mail in accountMails)
                                {
                                    mailToL.Add(mail.LoginEmail);
                                }
                                //  mailToL.Add(emailTo);
                                var mailToFromCompanySettings = cls_Get_Company_Settings.Invoke(dbConnection, dbTransaction, securityTicket).Result.Email;
                                mailToL.Add(mailToFromCompanySettings);

                                var appName = WebConfigurationManager.AppSettings["mmAppUrl"];
                                var prefix = HttpContext.Current.Request.Url.AbsoluteUri.Contains("https") ? "https://" : "http://";
                                var imageUrl = HttpContext.Current.Request.Url.AbsoluteUri.Substring(0, HttpContext.Current.Request.Url.AbsoluteUri.IndexOf("api")) + "Content/images/logo.png";
                                var email_template = File.ReadAllText(HttpContext.Current.Server.MapPath("~/EmailTemplates/AftercareDoctorMismatch.html"));

                                var subjectsJson = File.ReadAllText(HttpContext.Current.Server.MapPath("~/EmailTemplates/EmailSubjects.json"));
                                dynamic subjects = JsonConvert.DeserializeObject(subjectsJson);
                                var subjectMail = subjects["AftercareDoctorDifferentOnElastic"].ToString();

                                email_template = EmailTemplater.SetTemplateData(email_template, new
                                {
                                    patient_first_name = email_patient_details.patient_first_name,
                                    patient_last_name = email_patient_details.patient_last_name,
                                    case_number = case_details.case_number,
                                    elastic_doctor_title = elastic_doctor_details.title,
                                    elastic_doctor_last_name = elastic_doctor_details.last_name,
                                    elastic_doctor_first_name = elastic_doctor_details.first_name,
                                    relational_db_doctor_title = relational_doctor_details.title,
                                    relational_db_doctor_first_name = relational_doctor_details.first_name,
                                    relational_db_doctor_last_name = relational_doctor_details.last_name,
                                    treatment_date = case_details.treatment_date.ToString("dd.MM.yyyy"),
                                    mmapp_dashboard_url = prefix + HttpContext.Current.Request.Url.Authority + "/" + appName,
                                    medios_connect_logo_url = imageUrl
                                }, "{{", "}}");

                                try
                                {
                                    string mailFrom = WebConfigurationManager.AppSettings["mailFrom"];

                                    var mailsDistinct = mailToL.Distinct().ToList();
                                    foreach (var mailTo in mailsDistinct)
                                    {
                                        EmailNotificationSenderUtil.SendEmail(mailFrom, mailTo, subjectMail, email_template);
                                    }

                                }
                                catch (Exception ex)
                                {
                                    LogUtils.Logger.LogDocAppInfo(new LogUtils.LogEntry(System.Reflection.MethodInfo.GetCurrentMethod(), ex, null, "Aftercare doctor different in the db than on the elastic: Email sending failed."), "EmailExceptions");
                                }
                                #endregion

                                throw new ArgumentException(String.Format("Aftercare doctor on the elastic not the same as the doctor in the relational db. Case id: {0}, expected doctor: {1}, received: {2}", case_id, aftercare_doctor_id_in_the_db.aftercare_doctor_id, aftercare_doctor_practice_id));
                            }
                        }
                    }
                    else
                    {
                        if (case_details.op_doctor_id == Guid.Empty)
                        {
                            response.Add(new ConsentValidationResponse() { message = "LABEL_IVOM_DOCTOR_MANDATORY_FOR_SETTLEMENT" });
                        }

                        if (!(case_details.ac_doctor_id != Guid.Empty || case_details.ac_practice_id != Guid.Empty))
                        {
                            response.Add(new ConsentValidationResponse() { message = "LABEL_AFTERCARE_DOCTOR_MANDATORY_FOR_SETTLEMENT" });
                        }

                        if (!is_submitted && case_details.oct_doctor_id == Guid.Empty)
                        {
                            var patient_consents = cls_Get_Patient_Consents_for_PatientIDs.Invoke(dbConnection, dbTransaction, new P_PA_GPCfPIDs_1358() { PatientIDs = new Guid[] { case_details.patient_id } }, securityTicket).Result.OrderBy(t => t.ValidFrom).ToList();
                            var last_active_consent = patient_consents.LastOrDefault(t => t.ValidFrom.Date <= case_details.treatment_date.Date);
                            if (last_active_consent == null)
                            {
                                last_active_consent = patient_consents.FirstOrDefault();
                            }

                            if (last_active_consent != null)
                            {
                                var is_oct_contract = cls_Get_CoveredGposID_for_InsuranceToBrokerContractID_and_GposTypeID.Invoke(dbConnection, dbTransaction, new P_MD_GCGposIDfITBCIDaGposTID_1501()
                                {
                                    GposTypeID = EGposType.Oct.Value(),
                                    InsuranceToBrokerContractID = last_active_consent.InsuranceToBrokerContract_RefID
                                }, securityTicket).Result != null;

                                var contractID = ORM_HEC_CRT_InsuranceToBrokerContract.Query.Search(dbConnection, dbTransaction, new ORM_HEC_CRT_InsuranceToBrokerContract.Query
                                {
                                    Tenant_RefID = securityTicket.TenantID,
                                    IsDeleted = false,
                                    HEC_CRT_InsuranceToBrokerContractID = last_active_consent.InsuranceToBrokerContract_RefID
                                }).Single().Ext_CMN_CTR_Contract_RefID;

                                var all_contract_parameters = ORM_CMN_CTR_Contract_Parameter.Query.Search(dbConnection, dbTransaction, new ORM_CMN_CTR_Contract_Parameter.Query()
                                {
                                    Tenant_RefID = securityTicket.TenantID,
                                    IsDeleted = false,
                                    Contract_RefID = contractID
                                });

                                var useSettlementYear = all_contract_parameters.SingleOrDefault(t => t.ParameterName == EContractParameter.UseSettlementYear.Value()) != null;

                                if (is_oct_contract && !useSettlementYear)
                                {
                                    response.Add(new ConsentValidationResponse() { message = "LABEL_OCT_DOCTOR_MANDATORY_FOR_SETTLEMENT" });
                                }
                            }
                        }

                        if (response.Any())
                        {
                            return response;
                        }
                    }

                    if (potential_bill_code_result == null || potential_bill_code_result.PotentialBillCode_RefID == Guid.Empty)
                    {
                        response.Add(new ConsentValidationResponse() { message = "LABEL_GPOS_DOESNT_EXIST" });
                        return response;
                    }

                    if (case_treatment_datetime == DateTime.MinValue)
                    {
                        var treatment_performed_date = cls_Get_Treatment_Planned_Action_for_CaseID.Invoke(dbConnection, dbTransaction, new P_CAS_GTPAfCID_0946() { CaseID = case_id }, securityTicket).Result;
                        case_treatment_datetime = treatment_performed_date != null ? treatment_performed_date.treatment_date : DateTime.MinValue;
                    }

                    if (treatment_date > DateTime.Now)
                    {
                        response.Add(new ConsentValidationResponse() { message = "LABEL_TREATMENT_DATE_IN_FUTURE" });
                        return response;
                    }

                    if (case_treatment_datetime != DateTime.MinValue)
                    {
                        if (treatment_date < case_treatment_datetime)
                        {
                            response.Add(new ConsentValidationResponse() { message = "LABEL_AFTERCARE_DATE_BEFORE_TREATMENT_DATE" });
                            return response;
                        }
                    }

                    var doctors_consent_timespan = "-";
                    var aftercare_doctors_consent_timespan = "-";
                    var patients_consent_timespan = "-";

                    var patient_participation_consents = ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingPatient.Query.Search(connectionString, new ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingPatient.Query()
                    {
                        Patient_RefID = patient_id,
                        IsDeleted = false
                    });

                    if (!patient_participation_consents.Any())
                    {
                        response.Add(new ConsentValidationResponse() { message = "LABEL_PATIENT_HAS_NO_CONSENT" });
                        return response;
                    }

                    var drugDiagnoseContracts = cls_Get_InsuranceToBrokerContractID_And_ContractID_for_DrugID_and_DiagnoseID.Invoke(dbConnection, dbTransaction, new P_CAS_GItBCIDaCIDfDIDaDID_1923()
                    {
                        DiagnoseID = diagnose_id,
                        DrugID = drug_id
                    }, securityTicket).Result;

                    if (!drugDiagnoseContracts.Any())
                    {
                        response.Add(new ConsentValidationResponse() { message = "LABEL_NO_CONTRACT_FOUND" });
                        return response;
                    }

                    var contracts = cls_Get_InsuranceToBrokerContractID_for_DrugID_and_DiagnoseID.Invoke(dbConnection, dbTransaction, new P_CAS_GItBCIDfDIDaDID_1541()
                    {
                        DiagnoseID = diagnose_id,
                        DrugID = drug_id,
                        PatientID = patient_id,
                        TreatmentDate = date_to_check,
                        TakeExpiredConsentsIntoAccount = is_resubmission
                    }, securityTicket).Result;

                    var patient_details = cls_Get_Patient_Details_for_PatientID.Invoke(dbConnection, dbTransaction, new P_P_PA_GPDfPID_1124() { PatientID = patient_id }, securityTicket).Result;

                    if (!contracts.Any())
                    {
                        response.Add(new ConsentValidationResponse()
                        {
                            message = "LABEL_PATIENT_CONSENT_NOT_VALID",
                            name = patient_details.patient_first_name + " " + patient_details.patient_last_name,
                            date = treatment_date_string,
                            consent_timespan = patients_consent_timespan
                        });

                        return response;
                    }

                    var contract_ids = contracts.Where(ctr => ctr.patient_consent_valid_from.Date <= date_to_check.Date);
                    CAS_GItBCIDfDIDaDID_1541 contract_id = null;
                    if (contract_ids.Any())
                    {
                        contract_id = contract_ids.OrderByDescending(t => t.patient_consent_valid_from).FirstOrDefault();
                    }
                    else
                    {
                        contract_id = contracts.OrderBy(t => t.patient_consent_valid_from).FirstOrDefault();
                    }

                    var any_doctor_consent_valid = !validate_treatment_doctor;
                    var any_aftercare_consent_valid = is_treatment;
                    var any_patient_consent_valid = false;
                    var aftercare_constraint = 0.0;

                    if (contract_id != null)
                    {
                        var contract_parameters = ORM_CMN_CTR_Contract_Parameter.Query.Search(dbConnection, dbTransaction, new ORM_CMN_CTR_Contract_Parameter.Query()
                        {
                            Contract_RefID = contract_id.contract_id,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        });

                        var contract_details = ORM_CMN_CTR_Contract.Query.Search(dbConnection, dbTransaction, new ORM_CMN_CTR_Contract.Query() { CMN_CTR_ContractID = contract_id.contract_id, IsDeleted = false, Tenant_RefID = securityTicket.TenantID }).SingleOrDefault();
                        if (contract_details != null && contract_parameters.Count != 0 && !is_submitted)
                        {
                            var contractHasGpos = cls_Check_Contract_GPOS_for_ContractID_and_GPOSType.Invoke(dbConnection, dbTransaction, new P_MD_CCGPOSfCIDaGPOST_1919() { ContractID = contract_details.CMN_CTR_ContractID, GposType = gpos_type }, securityTicket).Result != null;
                            if (!contractHasGpos)
                            {
                                response.Add(new ConsentValidationResponse()
                                {
                                    message = is_treatment ? "LABEL_CONTRACT_HAS_NO_OP_GPOS" : "LABEL_CONTRACT_HAS_NO_AC_GPOS"
                                });

                                return response;
                            }

                            var treatment_constraint_parameter = contract_parameters.SingleOrDefault(cp => cp.ParameterName == "Number of days between treatment and settlement claim - Days" && cp.IsNumericValue);
                            var treatment_constraint = treatment_constraint_parameter != null ? treatment_constraint_parameter.IfNumericValue_Value : double.MaxValue;
                            var aftercare_contraint_parameter = contract_parameters.SingleOrDefault(cp => cp.ParameterName == "Number of days between surgery and aftercare - Days" && cp.IsNumericValue);
                            aftercare_constraint = aftercare_contraint_parameter != null ? aftercare_contraint_parameter.IfNumericValue_Value : double.MaxValue;

                            var max_date_for_submission = DateTime.MaxValue;

                            if (!is_treatment)
                            {
                                var aftercare_max_date = aftercare_constraint == double.MaxValue ? DateTime.MaxValue : case_treatment_datetime.AddDays(aftercare_constraint);
                                if (treatment_date > aftercare_max_date)
                                {
                                    response.Add(new ConsentValidationResponse()
                                    {
                                        message = "LABEL_AFTERCARE_TOO_MANY_DAYS_HAVE_PASSED_SINCE_TREATMENT",
                                        date = treatment_date_string,
                                        consent_timespan = case_treatment_date + " und " + case_treatment_datetime.AddDays(aftercare_constraint).ToString("dd.MM.yyyy")
                                    });

                                    return response;
                                }
                            }

                            max_date_for_submission = treatment_constraint_parameter != null && treatment_constraint != double.MaxValue ? treatment_date.AddDays(treatment_constraint) : DateTime.MaxValue;

                            if (treatment_date < contract_details.ValidFrom || DateTime.Now.Date > max_date_for_submission)
                            {
                                response.Add(new ConsentValidationResponse()
                                {
                                    message = is_treatment ? "LABEL_TREATMENT_DATE_OUTSIDE_OF_SUBMISSION_TIMESPAN" : "LABEL_AFTERCARE_DATE_OUTSIDE_OF_SUBMISSION_TIMESPAN",
                                    date = treatment_date_string,
                                    consent_timespan = is_treatment ? max_date_for_submission.ToString("dd.MM.yyyy") : case_treatment_datetime.ToString("dd.MM.yyyy") + " und " + max_date_for_submission.ToString("dd.MM.yyyy")
                                });

                                return response;
                            }
                        }

                        var treatment_doctor_details = cls_Get_Doctor_Details_for_DoctorID.Invoke(dbConnection, dbTransaction, new P_DO_GDDfDID_0823() { DoctorID = treatment_doctor_id }, securityTicket).Result.SingleOrDefault();
                        var aftercare_doctor_details = cls_Get_Doctor_Details_for_DoctorID.Invoke(dbConnection, dbTransaction, new P_DO_GDDfDID_0823() { DoctorID = aftercare_doctor_practice_id }, securityTicket).Result.SingleOrDefault();
                        var aftercare_practice_details = aftercare_doctor_details != null ? null : cls_Get_Practice_Details_for_PracticeID.Invoke(dbConnection, dbTransaction, new P_DO_GPDfPID_1432() { PracticeID = aftercare_doctor_practice_id }, securityTicket).Result.FirstOrDefault(); ;

                        if (validate_treatment_doctor && treatment_doctor_details != null)
                        {
                            #region CHECK TREATMENT DOCTOR PARTCIPATION
                            ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingDoctor.Query doctor_participationsQ = new ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingDoctor.Query();
                            doctor_participationsQ.Tenant_RefID = securityTicket.TenantID;
                            doctor_participationsQ.IsDeleted = false;
                            doctor_participationsQ.InsuranceToBrokerContract_RefID = contract_id.insurance_to_broker_contract;
                            doctor_participationsQ.Doctor_RefID = treatment_doctor_id;

                            var doctor_participations = ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingDoctor.Query.Search(connectionString, doctor_participationsQ);

                            foreach (var doctor_participation in doctor_participations)
                            {
                                var valid_through = doctor_participation.ValidThrough == DateTime.MinValue ? contract_id.contract_valid_through : doctor_participation.ValidThrough;

                                var left_side = doctor_participation.ValidFrom <= treatment_date;
                                var right_side = valid_through == DateTime.MinValue ? true : valid_through >= treatment_date;
                                any_doctor_consent_valid = left_side && right_side;

                                if (any_doctor_consent_valid)
                                    break;
                            }

                            if (!any_doctor_consent_valid)
                            {
                                if (doctor_participations.Count != 0)
                                {
                                    var filtered_doctor_participations = doctor_participations.Where(t => t.ValidThrough == DateTime.MinValue || t.ValidThrough.Date >= treatment_date.Date).Where(t => t.ValidFrom.Date <= treatment_date).OrderByDescending(t => t.ValidFrom).ToList();
                                    if (filtered_doctor_participations.Any())
                                    {
                                        var date_until_string = filtered_doctor_participations.First().ValidThrough == DateTime.MinValue ? "∞" : filtered_doctor_participations.First().ValidThrough.ToString("dd.MM.yyyy");
                                        doctors_consent_timespan = filtered_doctor_participations.First().ValidFrom.ToString("dd.MM.yyyy") + " - " + date_until_string;
                                    }
                                    else
                                    {
                                        var refiltered_doctor_participations = doctor_participations.Where(t => t.ValidFrom.Date <= treatment_date.Date).OrderByDescending(t => t.ValidFrom);
                                        var doctor_participations_not_yet_active = doctor_participations.Where(t => t.ValidFrom.Date > treatment_date.Date);

                                        if (refiltered_doctor_participations.Any())
                                        {
                                            var date = refiltered_doctor_participations.First().ValidFrom.Date;
                                            var date_until_string = "∞";
                                            if (doctor_participations_not_yet_active.Any())
                                            {
                                                if (treatment_date - refiltered_doctor_participations.First().ValidFrom.Date > doctor_participations_not_yet_active.First().ValidFrom - treatment_date)
                                                    date = doctor_participations_not_yet_active.First().ValidFrom.Date;
                                            }

                                            if (contract_id.contract_consent_valid_for_months < 2000000 && contract_id.contract_consent_valid_for_months != 0)
                                                date_until_string = date.AddMonths(contract_id.contract_consent_valid_for_months).ToString("dd.MM.yyyy");

                                            doctors_consent_timespan = date.ToString("dd.MM.yyyy") + " - " + date_until_string;
                                        }
                                        else if (doctor_participations_not_yet_active.Any())
                                        {
                                            var date_until_string = "∞";
                                            if (contract_id.contract_consent_valid_for_months < 2000000 && contract_id.contract_consent_valid_for_months != 0)
                                                date_until_string = doctor_participations_not_yet_active.First().ValidFrom.AddMonths(contract_id.contract_consent_valid_for_months).ToString("dd.MM.yyyy");

                                            doctors_consent_timespan = doctor_participations_not_yet_active.First().ValidFrom.ToString("dd.MM.yyyy") + " - " + date_until_string;
                                        }
                                        else
                                        {
                                            doctor_participations = doctor_participations.OrderByDescending(t => t.ValidFrom).ToList();
                                            var date_until_string = doctor_participations.First().ValidThrough == DateTime.MinValue ? "∞" : doctor_participations.First().ValidThrough.ToString("dd.MM.yyyy");
                                            doctors_consent_timespan = doctor_participations.First().ValidFrom.ToString("dd.MM.yyyy") + " - " + date_until_string;
                                        }
                                    }
                                }
                            }
                            #endregion
                        }

                        if (!is_treatment)
                        {
                            #region CHECK AFTERCARE PARTICIPATION
                            if (aftercare_doctor_details != null)
                            {
                                var doctor_participationsQ = new ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingDoctor.Query();
                                doctor_participationsQ.Tenant_RefID = securityTicket.TenantID;
                                doctor_participationsQ.IsDeleted = false;
                                doctor_participationsQ.InsuranceToBrokerContract_RefID = contract_id.insurance_to_broker_contract;
                                doctor_participationsQ.Doctor_RefID = aftercare_doctor_practice_id;

                                var doctor_participations = ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingDoctor.Query.Search(connectionString, doctor_participationsQ);

                                foreach (var doctor_participation in doctor_participations)
                                {
                                    var valid_through = doctor_participation.ValidThrough == DateTime.MinValue ? contract_id.contract_valid_through : doctor_participation.ValidThrough;

                                    var left_side = doctor_participation.ValidFrom <= treatment_date;
                                    var right_side = valid_through == DateTime.MinValue ? true : valid_through >= treatment_date;

                                    any_aftercare_consent_valid = left_side && right_side;
                                    if (any_aftercare_consent_valid)
                                        break;
                                }

                                if (!any_aftercare_consent_valid)
                                {
                                    if (doctor_participations.Count != 0)
                                    {
                                        var filtered_doctor_participations = doctor_participations.Where(t => t.ValidThrough == DateTime.MinValue || t.ValidThrough.Date >= treatment_date.Date).Where(t => t.ValidFrom.Date <= treatment_date).OrderByDescending(t => t.ValidFrom).ToList();
                                        if (filtered_doctor_participations.Any())
                                        {
                                            var date_until_string = filtered_doctor_participations.First().ValidThrough == DateTime.MinValue ? "∞" : filtered_doctor_participations.First().ValidThrough.ToString("dd.MM.yyyy");
                                            aftercare_doctors_consent_timespan = filtered_doctor_participations.First().ValidFrom.ToString("dd.MM.yyyy") + " - " + date_until_string;
                                        }
                                        else
                                        {
                                            var refiltered_doctor_participations = doctor_participations.Where(t => t.ValidFrom.Date <= treatment_date.Date).OrderByDescending(t => t.ValidFrom);
                                            var doctor_participations_not_yet_active = doctor_participations.Where(t => t.ValidFrom.Date > treatment_date.Date);

                                            if (refiltered_doctor_participations.Any())
                                            {
                                                var date = refiltered_doctor_participations.First().ValidFrom.Date;
                                                var date_until_string = "∞";
                                                if (doctor_participations_not_yet_active.Any())
                                                {
                                                    if (treatment_date - refiltered_doctor_participations.First().ValidFrom.Date > doctor_participations_not_yet_active.First().ValidFrom - treatment_date)
                                                        date = doctor_participations_not_yet_active.First().ValidFrom.Date;
                                                }

                                                if (contract_id.contract_consent_valid_for_months < 2000000 && contract_id.contract_consent_valid_for_months != 0)
                                                    date_until_string = date.AddMonths(contract_id.contract_consent_valid_for_months).ToString("dd.MM.yyyy");

                                                aftercare_doctors_consent_timespan = date.ToString("dd.MM.yyyy") + " - " + date_until_string;
                                            }
                                            else if (doctor_participations_not_yet_active.Any())
                                            {
                                                var date_until_string = "∞";
                                                if (contract_id.contract_consent_valid_for_months < 2000000 && contract_id.contract_consent_valid_for_months != 0)
                                                    date_until_string = doctor_participations_not_yet_active.First().ValidFrom.AddMonths(contract_id.contract_consent_valid_for_months).ToString("dd.MM.yyyy");

                                                aftercare_doctors_consent_timespan = doctor_participations_not_yet_active.First().ValidFrom.ToString("dd.MM.yyyy") + " - " + date_until_string;
                                            }
                                            else
                                            {
                                                doctor_participations = doctor_participations.OrderByDescending(t => t.ValidFrom).ToList();
                                                var date_until_string = doctor_participations.First().ValidThrough == DateTime.MinValue ? "∞" : doctor_participations.First().ValidThrough.ToString("dd.MM.yyyy");
                                                aftercare_doctors_consent_timespan = doctor_participations.First().ValidFrom.ToString("dd.MM.yyyy") + " - " + date_until_string;
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                var all_doctor_assignmentss_in_practice = cls_Get_all_Doctors_Contract_Assignment_for_PracticeID.Invoke(connectionString, new P_DO_GCfPID_1507() { PracticeID = aftercare_doctor_practice_id }, securityTicket).Result.Where(assignment => assignment.Contract == contract_id.contract_id);
                                foreach (var assignment in all_doctor_assignmentss_in_practice)
                                {
                                    var doctor_participationsQ = new ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingDoctor.Query();
                                    doctor_participationsQ.Tenant_RefID = securityTicket.TenantID;
                                    doctor_participationsQ.IsDeleted = false;
                                    doctor_participationsQ.InsuranceToBrokerContract_RefID = contract_id.insurance_to_broker_contract;
                                    doctor_participationsQ.HEC_CRT_InsuranceToBrokerContract_ParticipatingDoctorID = assignment.AssignmentID;

                                    var doctor_participations = ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingDoctor.Query.Search(connectionString, doctor_participationsQ);

                                    foreach (var doctor_participation in doctor_participations)
                                    {
                                        var valid_through = doctor_participation.ValidThrough == DateTime.MinValue ? contract_id.contract_valid_through : doctor_participation.ValidThrough;

                                        if (doctor_participation.ValidFrom <= DateTime.Now && valid_through == DateTime.MinValue ? true : valid_through > DateTime.Now)
                                        {
                                            var date_until_string = valid_through == DateTime.MinValue ? "∞" : valid_through.ToString("dd.MM.yyyy");
                                        }

                                        any_aftercare_consent_valid = doctor_participation.ValidFrom <= treatment_date && valid_through == DateTime.MinValue ? true : valid_through >= treatment_date;
                                        if (any_aftercare_consent_valid)
                                            break;
                                    }

                                    if (any_aftercare_consent_valid)
                                        break;
                                }
                            }
                            #endregion
                        }

                        #region CHECK PATIENT PARTICIPATION
                        ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingPatient.Query patient_participationsQ = new ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingPatient.Query();
                        patient_participationsQ.Tenant_RefID = securityTicket.TenantID;
                        if (!is_resubmission)
                            patient_participationsQ.IsDeleted = false;
                        patient_participationsQ.InsuranceToBrokerContract_RefID = contract_id.insurance_to_broker_contract;
                        patient_participationsQ.Patient_RefID = patient_id;


                        var patient_participations = ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingPatient.Query.Search(dbConnection, dbTransaction, patient_participationsQ).OrderBy(x => x.ValidFrom).ToList();

                        if (aftercare_constraint == 0.0)
                        {
                            var aftercare_contraint_parameter = contract_parameters.SingleOrDefault(cp => cp.ParameterName == "Number of days between surgery and aftercare - Days" && cp.IsNumericValue);
                            aftercare_constraint = aftercare_contraint_parameter != null ? aftercare_contraint_parameter.IfNumericValue_Value : double.MaxValue;
                        }

                        any_patient_consent_valid = patient_participations.Any(patient_participation =>
                        {
                            var validFrom = patient_participation.ValidFrom;
                            var validTo = patient_participation.ValidFrom.AddMonths(contract_id.contract_consent_valid_for_months);
                            var contractShouldStart = treatment_date.Date.Subtract(validTo.Date.AddDays(-aftercare_constraint)).Days;

                            if (validFrom <= treatment_date.Date && treatment_date.Date <= validTo)
                            {
                                var consent_valid_to = is_treatment ? validTo.AddDays(-aftercare_constraint).Date : validTo.Date;

                                if ((validFrom <= treatment_date.Date && consent_valid_to >= treatment_date.Date) ||
                                    (patient_participations.Any(x => x.ValidFrom >= validFrom.AddDays(contractShouldStart) && x.ValidFrom <= validTo)) ||
                                    (patient_participations.Any(x => x.ValidFrom == validTo)))
                                {
                                    return true;
                                }
                            }

                            return false;
                        });

                        var all_contract_parameters = ORM_CMN_CTR_Contract_Parameter.Query.Search(dbConnection, dbTransaction, new ORM_CMN_CTR_Contract_Parameter.Query()
                        {
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false
                        }).GroupBy(t => t.Contract_RefID).ToDictionary(t => t.Key, t => t);

                        var is_consent_renewed_by_op = all_contract_parameters[contract_id.contract_id].Any(p => p.ParameterName == "OP renews patient consent");

                        if (!any_patient_consent_valid)
                        {
                            if (is_consent_renewed_by_op)
                            {
                                var last_consent = patient_participations.OrderByDescending(t => t.ValidFrom).First();
                                var op_dates = cls_Get_PerformedOpDates_for_PatientID.Invoke(dbConnection, dbTransaction, new P_CAS_GPOpDfPID_0959() { PatientID = patient_id }, securityTicket).Result;

                                var last_op_date = op_dates.FirstOrDefault();
                                if (last_op_date != null)
                                {
                                    var last_consent_valid_until = last_op_date.treatment_date.Date.AddMonths(Convert.ToInt32(contract_id.contract_consent_valid_for_months));
                                    if (last_consent_valid_until > treatment_date.Date)
                                    {
                                        any_patient_consent_valid = true;
                                    }
                                    else
                                    {
                                        patients_consent_timespan = String.Format("{0} - {1}", last_op_date.treatment_date.ToString("dd.MM.yyyy"), last_consent_valid_until.AddDays(-1).ToString("dd.MM.yyyy"));
                                    }
                                }
                            }
                        }

                        if (!any_patient_consent_valid)
                        {
                            if (!is_consent_renewed_by_op)
                            {
                                if (patient_participations.Count != 0)
                                {
                                    var filtered_patient_participations = contract_id.contract_consent_valid_for_months < 2000000 && contract_id.contract_consent_valid_for_months != 0 ?
                                        patient_participations.Where(t => t.ValidFrom.AddMonths(contract_id.contract_consent_valid_for_months).Date >= treatment_date.Date)
                                            .Where(t => t.ValidFrom.Date <= treatment_date).OrderByDescending(t => t.ValidFrom).ToList() :
                                        patient_participations.Where(t => t.ValidFrom.Date <= treatment_date.Date).ToList();
                                    if (filtered_patient_participations.Any())
                                    {
                                        var date_until_string = "∞";
                                        if (contract_id.contract_consent_valid_for_months < 2000000 && contract_id.contract_consent_valid_for_months != 0)
                                            date_until_string = filtered_patient_participations.First().ValidFrom.AddMonths(contract_id.contract_consent_valid_for_months).ToString("dd.MM.yyyy");

                                        patients_consent_timespan = filtered_patient_participations.First().ValidFrom.ToString("dd.MM.yyyy") + " - " + date_until_string;
                                    }
                                    else
                                    {
                                        var refiltered_patient_participations = patient_participations.Where(t => t.ValidFrom.Date <= treatment_date.Date).OrderByDescending(t => t.ValidFrom);

                                        var patient_participations_not_yet_active = patient_participations.Where(t => t.ValidFrom.Date > treatment_date.Date).OrderBy(t => t.ValidFrom);
                                        if (refiltered_patient_participations.Any())
                                        {
                                            var date = refiltered_patient_participations.First().ValidFrom.Date;
                                            var date_until_string = "∞";
                                            if (patient_participations_not_yet_active.Any())
                                            {
                                                if (treatment_date - refiltered_patient_participations.First().ValidFrom.Date > patient_participations_not_yet_active.First().ValidFrom - treatment_date)
                                                    date = patient_participations_not_yet_active.First().ValidFrom.Date;
                                            }

                                            if (contract_id.contract_consent_valid_for_months < 2000000 && contract_id.contract_consent_valid_for_months != 0)
                                                date_until_string = date.AddMonths(contract_id.contract_consent_valid_for_months).ToString("dd.MM.yyyy");

                                            patients_consent_timespan = date.ToString("dd.MM.yyyy") + " - " + date_until_string;
                                        }
                                        else if (patient_participations_not_yet_active.Any())
                                        {
                                            var date_until_string = "∞";
                                            if (contract_id.contract_consent_valid_for_months < 2000000 && contract_id.contract_consent_valid_for_months != 0)
                                                date_until_string = patient_participations_not_yet_active.First().ValidFrom.AddMonths(contract_id.contract_consent_valid_for_months).ToString("dd.MM.yyyy");

                                            patients_consent_timespan = patient_participations_not_yet_active.First().ValidFrom.ToString("dd.MM.yyyy") + " - " + date_until_string;
                                        }
                                        else
                                        {
                                            patient_participations = patient_participations.OrderByDescending(t => t.ValidFrom).ToList();
                                            var date_until_string = "∞";
                                            if (contract_id.contract_consent_valid_for_months < 2000000 && contract_id.contract_consent_valid_for_months != 0)
                                                date_until_string = patient_participations.First().ValidFrom.AddMonths(contract_id.contract_consent_valid_for_months).ToString("dd.MM.yyyy");

                                            patients_consent_timespan = patient_participations.First().ValidFrom.ToString("dd.MM.yyyy") + " - " + date_until_string;
                                        }
                                    }
                                }
                            }
                        }

                        var any_non_valid_consent_valid_for_case = false;
                        if (!any_patient_consent_valid)
                        {
                            var valid_contracts_ids = contract_ids.Select(c => c.contract_id);

                            var other_consents = cls_Get_All_Patient_Consents_for_PatientIDs.Invoke(dbConnection, dbTransaction, new P_PA_GAPCfPIDs_1417
                            {
                                PatientIDs = new Guid[] { patient_id }
                            }, securityTicket).Result.Where(ctr => ctr.consent_valid_from.Date <= date_to_check.Date && !valid_contracts_ids.Contains(ctr.contract_id));

                            var last_non_valid_consent = other_consents.OrderByDescending(t => t.consent_valid_from).FirstOrDefault();
                            if (last_non_valid_consent != null)
                            {
                                ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingPatient.Query patient_non_valid_participationsQ = new ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingPatient.Query();
                                patient_non_valid_participationsQ.Tenant_RefID = securityTicket.TenantID;
                                if (!is_resubmission)
                                    patient_non_valid_participationsQ.IsDeleted = false;
                                patient_non_valid_participationsQ.InsuranceToBrokerContract_RefID = last_non_valid_consent.insurance_to_broker_contract_id;
                                patient_non_valid_participationsQ.Patient_RefID = patient_id;

                                var patient_non_valid_participations = ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingPatient.Query.Search(dbConnection, dbTransaction, patient_non_valid_participationsQ);

                                any_non_valid_consent_valid_for_case = patient_non_valid_participations.Any(patient_participation => patient_participation.ValidFrom.Date <= treatment_date.Date && patient_participation.ValidFrom.AddMonths(contract_id.contract_consent_valid_for_months).Date >= treatment_date.Date);
                                if (any_non_valid_consent_valid_for_case)
                                {
                                    response.Add(new ConsentValidationResponse()
                                    {
                                        message = "LABEL_CONSENT_COMBINATION_NOT_VALID",
                                        name = GenericUtils.GetDoctorName(treatment_doctor_details),
                                        date = treatment_date_string,
                                        consent_timespan = doctors_consent_timespan
                                    });
                                }
                            }
                        }
                        #endregion

                        if (!any_doctor_consent_valid && treatment_doctor_details != null)
                        {
                            response.Add(new ConsentValidationResponse()
                            {
                                message = "LABEL_DOCTOR_CONSENT_NOT_VALID",
                                name = GenericUtils.GetDoctorName(treatment_doctor_details),
                                date = treatment_date_string,
                                consent_timespan = doctors_consent_timespan
                            });
                        }

                        if (!any_aftercare_consent_valid)
                        {
                            ConsentValidationResponse cv_response = new ConsentValidationResponse();
                            cv_response.message = aftercare_doctor_details != null ? "LABEL_AFTERCARE_DOCTOR_CONSENT_NOT_VALID" : "LABEL_AFTERCARE_PRACTICE_CONSENT_NOT_VALID";
                            cv_response.name = aftercare_doctor_details != null ? GenericUtils.GetDoctorName(aftercare_doctor_details) : aftercare_practice_details.practice_name;
                            cv_response.date = treatment_date_string;
                            cv_response.consent_timespan = aftercare_doctor_details != null ? aftercare_doctors_consent_timespan : "";
                            response.Add(cv_response);
                        }

                        if (!any_patient_consent_valid && !any_non_valid_consent_valid_for_case)
                        {
                            response.Add(new ConsentValidationResponse()
                            {
                                message = "LABEL_PATIENT_CONSENT_NOT_VALID",
                                name = patient_details.patient_first_name + " " + patient_details.patient_last_name,
                                date = treatment_date_string,
                                consent_timespan = patients_consent_timespan
                            });
                        }
                    }
                    else
                    {
                        response.Add(new ConsentValidationResponse()
                        {
                            message = "LABEL_PATIENT_CONSENT_NOT_VALID",
                            name = patient_details.patient_first_name + " " + patient_details.patient_last_name,
                            date = treatment_date_string,
                            consent_timespan = patients_consent_timespan
                        });
                    }

                    var patientService = new PatientDataService();
                    var patientInsuranceNumberValid = patientService.CheckIfKVNRIsValid(patient_details.insurance_id, connectionString, sessionTicket, out transaction);
                    if (!patientInsuranceNumberValid)
                    {
                        response.Add(new ConsentValidationResponse()
                        {
                            message = "LABEL_ERROR_NEW_KVR_VALIDATION_FOR_PATIENT",
                            name = patient_details.patient_first_name + " " + patient_details.patient_last_name,
                            insurance_number = patient_details.insurance_id
                        });

                        return response;
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

        public Guid[] ValidateDoctorsAndPatientsParticipationConsentMulti(Guid authorizing_doctor_id, bool validate_treatment_doctor, string type, bool should_submit, Guid[] case_ids, Guid[] deselected_ids, bool all_selected, Guid doctor_id, Guid aftercare_doctor_practice_id, FilterObject filter, string date_performed_string, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

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

                    ElasticParameterObject filter_by = new ElasticParameterObject();
                    filter_by.date_from = filter.date_from;
                    filter_by.date_to = filter.date_to;
                    filter_by.filter_by.filter_status = filter.filter_by.filter_status;
                    filter_by.filter_by.filter_type = filter.filter_by.filter_type;
                    filter_by.search_params = filter.search_params;
                    filter_by.filter_by.orders = filter.filter_by.orders;
                    filter_by.filter_by.filter_current = filter.filter_by.filter_current;
                    filter_by.filter_by.localization = filter.filter_by.localization;

                    var doc_id_to_validate = Guid.Empty;

                    switch (type)
                    {
                        case "case":
                            Case_Model[] cases = null;
                            doc_id_to_validate = authorizing_doctor_id == doctor_id ? doctor_id : authorizing_doctor_id;
                            if (all_selected || deselected_ids.Length != 0)
                            {
                                cases = Get_Cases.GetCasesFilteredIDs(filter_by, data.PracticeID.ToString(), Array.ConvertAll(deselected_ids, x => x.ToString()), should_submit, doc_id_to_validate.ToString(), doctor_id.ToString(), "treatment_date", false, securityTicket);
                            }
                            else
                            {
                                cases = Get_Cases.GetCasesforIDArray(data.PracticeID, Array.ConvertAll(case_ids, x => x.ToString()), should_submit, doc_id_to_validate.ToString(), doctor_id.ToString(), "treatment_date", false, securityTicket).ToArray();
                            }

                            foreach (var planning_case in cases)
                            {
                                var treatment_doctor_id = doctor_id != Guid.Empty ? doctor_id : Guid.Parse(planning_case.treatment_doctor_id);
                                var aftercare_doctor_practice = aftercare_doctor_practice_id == Guid.Empty ? Guid.Parse(planning_case.aftercare_doctor_practice_id) : aftercare_doctor_practice_id;
                                var consent_validation_response = ValidateDoctorsAndPatientsParticipationConsent(Guid.Parse(planning_case.id), true, validate_treatment_doctor, treatment_doctor_id, aftercare_doctor_practice, Guid.Parse(planning_case.patient_id), planning_case.treatment_date.ToString("dd.MM.yyyy"), planning_case.treatment_date.ToString("dd.MM.yyyy"), Guid.Parse(planning_case.diagnose_id), Guid.Parse(planning_case.drug_id), connectionString, sessionTicket, out transaction);
                                if (consent_validation_response.Count == 0)
                                {
                                    response.Add(Guid.Parse(planning_case.id));
                                }
                            }
                            break;
                        case "aftercare":
                            var hipData = cls_Get_Hip_Contract_Parameters_on_Tenant.Invoke(dbConnection, dbTransaction, securityTicket).Result.GroupBy(hip => hip.HipIK).ToDictionary(t => t.Key, t => t);
                            var rangeParameters = hipData.Select(t =>
                            {
                                var result = new AftercareHipParameter();
                                if (t.Value.Any(x => x.ParameterValue != double.MaxValue && x.ParameterValue < 20000000 && x.ParameterValue != 0))
                                {
                                    try
                                    {
                                        result.MinimumTreatmentDate = DateTime.Now.AddDays(-Convert.ToInt32(t.Value.Single(x => x.ParameterName == "Number of days between surgery and aftercare - Days").ParameterValue +
                                            t.Value.Single(x => x.ParameterName == "Number of days between treatment and settlement claim - Days").ParameterValue)).ToString("yyyy-MM-dd");
                                    }
                                    catch
                                    {
                                        result.MinimumTreatmentDate = "0001-01-01";
                                    }
                                }
                                else
                                {
                                    result.MinimumTreatmentDate = "0001-01-01";
                                }
                                result.HipIk = t.Key;

                                return result;
                            }).ToList();
                            Aftercare_Model[] aftercares = null;
                            doc_id_to_validate = authorizing_doctor_id == aftercare_doctor_practice_id ? aftercare_doctor_practice_id : authorizing_doctor_id;
                            if (all_selected || deselected_ids.Length != 0)
                            {
                                aftercares = Get_Aftercares.GetAftercaresFilteredIDs(filter_by, data.PracticeID.ToString(), Array.ConvertAll(deselected_ids, x => x.ToString()), should_submit, data.AccountInformation.role.Contains("practice"), doc_id_to_validate.ToString(), "treatment_date", false, rangeParameters, securityTicket);
                            }
                            else
                            {
                                aftercares = Get_Aftercares.GetAftercaresForIDArray(data.PracticeID, data.AccountInformation.role.Contains("practice"), Array.ConvertAll(case_ids, x => x.ToString()), should_submit, doc_id_to_validate.ToString(), "treatment_date", false, securityTicket).ToArray();
                            }

                            var doctors = ORM_HEC_Doctor.Query.Search(dbConnection, dbTransaction, new ORM_HEC_Doctor.Query()
                            {
                                Tenant_RefID = securityTicket.TenantID,
                                IsDeleted = false
                            }).ToDictionary(t => t.HEC_DoctorID, t => t);

                            foreach (var aftercare in aftercares)
                            {
                                if (doctors.ContainsKey(Guid.Parse(aftercare.aftercare_doctor_practice_id)))
                                {
                                    var aftercare_doctor_practice = aftercare_doctor_practice_id == Guid.Empty ? Guid.Parse(aftercare.aftercare_doctor_practice_id) : aftercare_doctor_practice_id;
                                    var consent_validation_response = ValidateDoctorsAndPatientsParticipationConsent(Guid.Parse(aftercare.case_id), false, validate_treatment_doctor, doctor_id, aftercare_doctor_practice, Guid.Parse(aftercare.patient_id), date_performed_string, aftercare.treatment_date.ToString("dd.MM.yyyy"), Guid.Parse(aftercare.diagnose_id), Guid.Parse(aftercare.drug_id), connectionString, sessionTicket, out transaction, true);
                                    if (consent_validation_response.Count == 0)
                                    {
                                        response.Add(Guid.Parse(aftercare.case_id));
                                    }
                                }
                            }

                            break;
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
    }
}
