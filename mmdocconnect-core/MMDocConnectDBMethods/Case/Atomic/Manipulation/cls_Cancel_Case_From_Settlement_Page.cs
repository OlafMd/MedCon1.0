/* 
 * Generated on 02/10/16 13:23:04
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 * Required Assemblies:
 * System.Runtime.Serialization
 * CSV2Core
 * CSV2Core_MySQL
 */
using System;
using System.Linq;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;
using System.Runtime.Serialization;
using MMDocConnectDBMethods.Case.Atomic.Retrieval;
using CL1_BIL;
using MMDocConnectDBMethods.Case.Complex.Manipulation;
using MMDocConnectElasticSearchMethods.Models;
using MMDocConnectDBMethods.Doctor.Atomic.Retrieval;
using MMDocConnectDBMethods.Patient.Atomic.Retrieval;
using CL1_HEC_ACT;
using MMDocConnectElasticSearchMethods.Case.Retrieval;
using MMDocConnectElasticSearchMethods.Settlement.Retrieval;
using MMDocConnectElasticSearchMethods.Case.Manipulation;
using MMDocConnectElasticSearchMethods.Settlement.Manipulation;
using System.Text;
using MMDocConnectUtils;
using System.Web.Configuration;
using System.Threading;
using System.Globalization;
using MMDocConnectElasticSearchMethods.Patient.Manipulation;
using MMDocConnectDBMethods.MainData.Atomic.Retrieval;
using System.Web;
using System.IO;
using Newtonsoft.Json;
using MMDocConnectDocApp;
using MMDocConnectDBMethods.Case.Complex.Retrieval;
using CL1_HEC_CAS;
using MMDocConnectElasticSearchMethods;
using CL1_CMN_CTR;

namespace MMDocConnectDBMethods.Case.Atomic.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Cancel_Case_From_Settlement_Page.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Cancel_Case_From_Settlement_Page
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Guid Execute(DbConnection Connection, DbTransaction Transaction, P_CAS_CCFSP_1751 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("de-DE");
            var returnValue = new FR_Guid();
            var mailSent = false;

            bool isACCanceled = false;
            Guid aftercareID = Guid.Empty;
            var gpos_type = EGposType.Oct.Value();
            if (Parameter.caseType == "op")
                gpos_type = EGposType.Operation.Value();
            else if (Parameter.caseType == "ac")
                gpos_type = EGposType.Aftercare.Value();

            var case_to_submit = cls_Get_Case_Details_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GCDfCID_1435() { CaseID = Parameter.case_id }, securityTicket).Result;
            var treatment_practice_details = cls_Get_Practice_Details_for_PracticeID.Invoke(Connection, Transaction, new P_DO_GPDfPID_1432() { PracticeID = case_to_submit.practice_id }, securityTicket).Result.FirstOrDefault();
            var aftercare_practice_details = cls_Get_Practice_Details_for_PracticeID.Invoke(Connection, Transaction, new P_DO_GPDfPID_1432() { PracticeID = case_to_submit.aftercare_doctors_practice_id }, securityTicket).Result.FirstOrDefault();
            var patient_details = cls_Get_Patient_Details_for_PatientID.Invoke(Connection, Transaction, new P_P_PA_GPDfPID_1124() { PatientID = case_to_submit.patient_id }, securityTicket).Result;
            var treatment_doctor_details = cls_Get_Doctor_Details_for_DoctorID.Invoke(Connection, Transaction, new P_DO_GDDfDID_0823() { DoctorID = case_to_submit.op_doctor_id }, securityTicket).Result.SingleOrDefault();
            var diagnose_details = cls_Get_Diagnose_Details_for_DiagnoseID.Invoke(Connection, Transaction, new P_CAS_GDDfDID_1608() { DiagnoseID = case_to_submit.diagnose_id }, securityTicket).Result;
            var aftercare_doctor_details = cls_Get_Doctor_Details_for_DoctorID.Invoke(Connection, Transaction, new P_DO_GDDfDID_0823() { DoctorID = case_to_submit.ac_doctor_id }, securityTicket).Result.SingleOrDefault();

            if (Parameter.caseType == "oct")
            {
                var relevant_action = ORM_HEC_CAS_Case_RelevantPlannedAction.Query.Search(Connection, Transaction, new ORM_HEC_CAS_Case_RelevantPlannedAction.Query()
                {
                    PlannedAction_RefID = Parameter.planned_action_id,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).Single();

                if (relevant_action.Case_RefID != Parameter.case_id)
                {
                    Parameter.case_id = relevant_action.Case_RefID;
                }
            }
            var current_case_status = cls_Get_Case_TransmitionCode_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GCTCfCID_1427() { CaseID = Parameter.case_id }, securityTicket).Result.FirstOrDefault(st => st.gpos_type == gpos_type && st.fs_status != 8 && st.fs_status != 17 && st.fs_status != 11);
            if (current_case_status == null)
            {
                throw new Exception(String.Format("Current FS status not found for case id: {0}, planned action id: {1}, case type: {2}", Parameter.case_id, Parameter.planned_action_id, Parameter.caseType));
            }
            var current_status = "FS" + current_case_status.fs_status;

            if (Parameter.caseType == "op")
            {
                var bill_positions = cls_Get_BillPositionIDs_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GBPIDsfCID_0928() { CaseID = Parameter.case_id }, securityTicket).Result;

                #region CHANGE TREATMENT STATUS
                foreach (var bill_position in bill_positions)
                {
                    ORM_BIL_BillPosition_TransmitionStatus.Query transmition_statusQ = new ORM_BIL_BillPosition_TransmitionStatus.Query();
                    transmition_statusQ.BillPosition_RefID = bill_position.bill_position_id;
                    transmition_statusQ.TransmitionStatusKey = "treatment";
                    transmition_statusQ.Tenant_RefID = securityTicket.TenantID;
                    transmition_statusQ.IsDeleted = false;
                    transmition_statusQ.IsActive = true;

                    var transmition_status = ORM_BIL_BillPosition_TransmitionStatus.Query.Search(Connection, Transaction, transmition_statusQ).SingleOrDefault();
                    if (transmition_status != null && transmition_status.TransmitionCode != 8 && transmition_status.TransmitionCode != 11)
                    {
                        transmition_status.IsActive = false;
                        transmition_status.Modification_Timestamp = DateTime.Now;
                        transmition_status.Save(Connection, Transaction);

                        ORM_BIL_BillPosition_TransmitionStatus position_status = new ORM_BIL_BillPosition_TransmitionStatus();
                        position_status.BIL_BillPosition_TransmitionStatusID = Guid.NewGuid();
                        position_status.BillPosition_RefID = bill_position.bill_position_id;
                        position_status.Creation_Timestamp = DateTime.Now;
                        position_status.IsActive = true;
                        position_status.PrimaryComment = Parameter.reasonForCancelation;
                        position_status.Modification_Timestamp = DateTime.Now;
                        position_status.TransmitionCode = transmition_status.TransmitionCode != 2 ? 8 : 11;
                        position_status.TransmittedOnDate = DateTime.Now;
                        position_status.Tenant_RefID = securityTicket.TenantID;
                        position_status.TransmitionStatusKey = "treatment";

                        #region CREATE SNAPSHOT
                        DateTime today = DateTime.Today;
                        int age = today.Year - patient_details.birthday.Year;
                        if (patient_details.birthday > today.AddYears(-age))
                            age--;

                        var snapshot = cls_Create_XML_for_Immutable_Fields.Invoke(Connection, Transaction, new P_CAS_CXFIF_0830()
                        {
                            DiagnosisCatalogCode = diagnose_details == null ? "-" : diagnose_details.diagnose_icd_10,
                            DiagnosisCatalogName = diagnose_details == null ? "-" : diagnose_details.catalog_display_name,
                            DiagnosisName = diagnose_details == null ? "-" : diagnose_details.diagnose_name,
                            IFPerformedMedicalPracticeName = treatment_practice_details.practice_name,
                            IFPerformedResponsibleBPFullName = GenericUtils.GetDoctorName(treatment_doctor_details),
                            Localization = case_to_submit.localization,
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

                        #endregion

                        position_status.Save(Connection, Transaction);

                        current_status = "FS" + position_status.TransmitionCode;
                    }
                }

                #region Aftercare e-mail
                var aftercarePlannedAction = cls_Get_Aftercare_Planned_Action_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GAPAfCID_0959 { CaseID = Parameter.case_id }, securityTicket).Result;

                if (aftercarePlannedAction != null)
                {
                    var originalAftercarePlannedAction = ORM_HEC_ACT_PlannedAction.Query.Search(Connection, Transaction, new ORM_HEC_ACT_PlannedAction.Query { HEC_ACT_PlannedActionID = aftercarePlannedAction.planned_action_id, Tenant_RefID = securityTicket.TenantID, IsDeleted = false, IsCancelled = false }).SingleOrDefault();

                    if (originalAftercarePlannedAction != null)
                    {
                        if (!originalAftercarePlannedAction.IsPerformed)
                        {
                            originalAftercarePlannedAction.IsCancelled = true;
                            originalAftercarePlannedAction.Save(Connection, Transaction);
                            isACCanceled = true;
                            aftercareID = originalAftercarePlannedAction.HEC_ACT_PlannedActionID;
                        }
                        else
                        {
                            if (!mailSent)
                            {
                                var mailToL = new List<String>();

                                var accountMails = cls_Get_All_Account_LoginEmails_Who_Receive_Notifications.Invoke(Connection, Transaction, securityTicket).Result.ToList();
                                foreach (var mail in accountMails)
                                {
                                    mailToL.Add(mail.LoginEmail);
                                }
                                //  mailToL.Add(emailTo);
                                var mailToFromCompanySettings = cls_Get_Company_Settings.Invoke(Connection, Transaction, securityTicket).Result.Email;
                                mailToL.Add(mailToFromCompanySettings);

                                var appName = WebConfigurationManager.AppSettings["mmAppUrl"];
                                var prefix = HttpContext.Current.Request.Url.AbsoluteUri.Contains("https") ? "https://" : "http://";
                                var imageUrl = HttpContext.Current.Request.Url.AbsoluteUri.Substring(0, HttpContext.Current.Request.Url.AbsoluteUri.IndexOf("api")) + "Content/images/logo.png";
                                var email_template = File.ReadAllText(HttpContext.Current.Server.MapPath("~/EmailTemplates/TreatmentCancelledFromSettlementPageEmailTemplate.html"));

                                var subjectsJson = File.ReadAllText(HttpContext.Current.Server.MapPath("~/EmailTemplates/EmailSubjects.json"));
                                dynamic subjects = JsonConvert.DeserializeObject(subjectsJson);
                                var subjectMail = subjects["TreatmentCancelledFromSettlementPageSubject"].ToString();

                                email_template = EmailTemplater.SetTemplateData(email_template, new
                                {
                                    patient_first_name = patient_details.patient_first_name,
                                    patient_last_name = patient_details.patient_last_name,
                                    treatment_date = case_to_submit.treatment_date.ToString("dd.MM.yyyy"),
                                    treatment_doctor_title = treatment_doctor_details.title,
                                    treatment_doctor_first_name = treatment_doctor_details.first_name,
                                    treatment_doctor_last_name = treatment_doctor_details.last_name,
                                    aftercare_doctor_title = aftercare_doctor_details.title,
                                    doctors_comment = Parameter.reasonForCancelation,
                                    aftercare_doctor_first_name = aftercare_doctor_details.first_name,
                                    aftercare_doctor_last_name = aftercare_doctor_details.last_name,
                                    mmapp_treatment_page_url = prefix + HttpContext.Current.Request.Url.Authority + "/" + appName + "/#/treatment",
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
                                    mailSent = true;

                                }
                                catch (Exception ex)
                                {
                                    LogUtils.Logger.LogDocAppInfo(new LogUtils.LogEntry(System.Reflection.MethodInfo.GetCurrentMethod(), ex, null, "Cancel case from settlement: Email sending failed."), "EmailExceptions");
                                }
                            }
                        }
                    }
                }
                #endregion

                #region OCT e-mail
                var oct_planned_action_type_id = cls_Get_ActionTypeID.Invoke(Connection, Transaction, new P_CAS_GATID_1514() { action_type_gpmid = EActionType.PlannedOct.Value() }, securityTicket).Result;

                var patient_consent_valid_for_months_parameter = cls_Get_ConsentValidForMonths_for_LatestConsent_before_TreatmentDate_for_PatientID.Invoke(Connection, Transaction, new P_PA_GCVfMfLCbTDfPID_0930()
                {
                    PatientID = case_to_submit.patient_id,
                    TreatmentDate = case_to_submit.treatment_date.Date
                }, securityTicket).Result;

                var performedOcts = cls_Get_NonCancelledOcts_in_OpRenewedConsentTimespan.Invoke(Connection, Transaction, new P_CAS_GNCOctsiOPRCT_1416()
                {
                    PatientID = case_to_submit.patient_id,
                    PlannedOctActionTypeID = oct_planned_action_type_id,
                    ConsentStart = case_to_submit.treatment_date.Date,
                    ConsentEnd = case_to_submit.treatment_date.Date.AddMonths(patient_consent_valid_for_months_parameter != null && patient_consent_valid_for_months_parameter.consent_valid_for_months < 200000 ? Convert.ToInt32(patient_consent_valid_for_months_parameter.consent_valid_for_months) : 12)
                }, securityTicket).Result;

                if (performedOcts.Any())
                {
                    var mailToL = new List<String>();

                    var accountMails = cls_Get_All_Account_LoginEmails_Who_Receive_Notifications.Invoke(Connection, Transaction, securityTicket).Result.ToList();
                    foreach (var mail in accountMails)
                    {
                        mailToL.Add(mail.LoginEmail);
                    }

                    var mailToFromCompanySettings = cls_Get_Company_Settings.Invoke(Connection, Transaction, securityTicket).Result.Email;
                    mailToL.Add(mailToFromCompanySettings);

                    var appName = WebConfigurationManager.AppSettings["mmAppUrl"];
                    var prefix = HttpContext.Current.Request.Url.AbsoluteUri.Contains("https") ? "https://" : "http://";
                    var imageUrl = HttpContext.Current.Request.Url.AbsoluteUri.Substring(0, HttpContext.Current.Request.Url.AbsoluteUri.IndexOf("api")) + "Content/images/logo.png";
                    var email_template = File.ReadAllText(HttpContext.Current.Server.MapPath("~/EmailTemplates/TreatmentCancelledFromSettlementPageOctSubmittedEmailTemplate .html"));

                    var subjectsJson = File.ReadAllText(HttpContext.Current.Server.MapPath("~/EmailTemplates/EmailSubjects.json"));
                    dynamic subjects = JsonConvert.DeserializeObject(subjectsJson);
                    var subjectMail = subjects["TreatmentCancelledFromSettlementPageSubject"].ToString();

                    email_template = EmailTemplater.SetTemplateData(email_template, new
                    {
                        patient_first_name = patient_details.patient_first_name,
                        patient_last_name = patient_details.patient_last_name,
                        treatment_date = case_to_submit.treatment_date.ToString("dd.MM.yyyy"),
                        treatment_doctor_title = treatment_doctor_details.title,
                        treatment_doctor_first_name = treatment_doctor_details.first_name,
                        treatment_doctor_last_name = treatment_doctor_details.last_name,
                        octs = performedOcts,
                        doctors_comment = Parameter.reasonForCancelation,
                        mmapp_treatment_page_url = prefix + HttpContext.Current.Request.Url.Authority + "/" + appName + "/#/treatment",
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
                        mailSent = true;

                    }
                    catch (Exception ex)
                    {
                        LogUtils.Logger.LogDocAppInfo(new LogUtils.LogEntry(System.Reflection.MethodInfo.GetCurrentMethod(), ex, null, "Cancel case from settlement: Email sending failed."), "EmailExceptions");
                    }
                }
                #endregion

                #region OCT withdrawal
                var treatment_year_start_date = cls_Get_TreatmentYear.Invoke(Connection, Transaction, new P_CAS_GTY_1125()
                {
                    Date = case_to_submit.treatment_date,
                    LocalizationCode = case_to_submit.localization,
                    PatientID = case_to_submit.patient_id
                }, securityTicket).Result;

                var treatment_year_length = cls_Get_TreatmentYearLength.Invoke(Connection, Transaction, new P_CAS_GTYL_1317()
                {
                    Date = case_to_submit.treatment_date,
                    PatientID = case_to_submit.patient_id
                }, securityTicket).Result;

                var ops_in_treatment_year = cls_Get_OpDates_for_PatientID_and_LocalizationCode_in_TreatmentYear.Invoke(Connection, Transaction, new P_CAS_GOpDfPIDaLCiTY_1110()
                {
                    LocalizationCode = case_to_submit.localization,
                    PatientID = case_to_submit.patient_id,
                    TreatmentYearStartDate = treatment_year_start_date,
                    TreatmentYearEndDate = treatment_year_start_date.AddDays(treatment_year_length - 1)
                }, securityTicket).Result;

                if (!ops_in_treatment_year.Any(t => t.CaseID != Parameter.case_id && ((!t.IsPerformed && !t.IsDeleted) || (t.IsPerformed && t.FsStatus != 8 && t.FsStatus != 11 && t.FsStatus != 17))))
                {
                    foreach (var potential_op in ops_in_treatment_year)
                    {
                        var non_performed_oct = cls_Get_NonPerformed_Oct_for_CaseID_and_PlannedActionTypeID.Invoke(Connection, Transaction, new P_CAS_GNPOctfCIDaPATID_1240()
                        {
                            CaseID = potential_op.CaseID,
                            OctPlannedActionTypeID = oct_planned_action_type_id
                        }, securityTicket).Result;

                        if (non_performed_oct != null)
                        {
                            var oct_planned_action = ORM_HEC_ACT_PlannedAction.Query.Search(Connection, Transaction, new ORM_HEC_ACT_PlannedAction.Query()
                            {
                                HEC_ACT_PlannedActionID = non_performed_oct.action_id
                            }).Single();

                            oct_planned_action.IsCancelled = true;
                            oct_planned_action.Modification_Timestamp = DateTime.Now;
                            oct_planned_action.Save(Connection, Transaction);

                            break;
                        }
                    }
                }
                #endregion

                #endregion
            }
            else if (Parameter.caseType == "oct")
            {
                #region CHANGE OCT STATUS
                var oct_planned_action_type_id = cls_Get_ActionTypeID.Invoke(Connection, Transaction, new P_CAS_GATID_1514() { action_type_gpmid = EActionType.PlannedOct.Value() }, securityTicket).Result;

                var oct_performed_data = cls_Get_PerformedActionDate_for_PlannedActionID.Invoke(Connection, Transaction, new P_CAS_GPADfPAID_1613() { ActionID = Parameter.planned_action_id }, securityTicket).Result;

                var treatment_year_start_date = cls_Get_TreatmentYear.Invoke(Connection, Transaction, new P_CAS_GTY_1125()
                {
                    Date = oct_performed_data.performed_on_date,
                    LocalizationCode = oct_performed_data.localization,
                    PatientID = case_to_submit.patient_id
                }, securityTicket).Result;

                var treatment_year_length = cls_Get_TreatmentYearLength.Invoke(Connection, Transaction, new P_CAS_GTYL_1317() { Date = oct_performed_data.performed_on_date, PatientID = case_to_submit.patient_id }, securityTicket).Result;

                var relevant_actions = cls_Get_RelevantActionIDs_for_PatientID_and_LocalizationCode.Invoke(Connection, Transaction, new P_CAS_GRAIDsfPIDaLC_1011()
                {
                    ActionTypeID = oct_planned_action_type_id,
                    PatientID = case_to_submit.patient_id,
                    LocalizationCode = oct_performed_data.localization,
                    TreatmentYearStartDate = treatment_year_start_date,
                    TreatmentYearEndDate = treatment_year_start_date.AddDays(treatment_year_length - 1)
                }, securityTicket).Result;

                var case_ids = relevant_actions.Select(t => t.case_id).ToArray();
                var bill_positions = cls_Get_BillPositionIDs_for_CaseIDs_and_GposType.Invoke(Connection, Transaction, new P_CAS_GBPIDsfCIDsaGposT_1018()
                {
                    CaseIDs = case_ids,
                    GposType = EGposType.Oct.Value()
                }, securityTicket).Result;

                for (var i = 0; i < relevant_actions.Length; i++)
                {
                    var relevant_action = relevant_actions[i];
                    if (relevant_action.action_id == Parameter.planned_action_id)
                    {
                        var bill_position = bill_positions[i];
                        ORM_BIL_BillPosition_TransmitionStatus.Query transmition_statusQ = new ORM_BIL_BillPosition_TransmitionStatus.Query();
                        transmition_statusQ.BillPosition_RefID = bill_position.bill_position_id;
                        transmition_statusQ.TransmitionStatusKey = "oct";
                        transmition_statusQ.Tenant_RefID = securityTicket.TenantID;
                        transmition_statusQ.IsDeleted = false;
                        transmition_statusQ.IsActive = true;

                        var transmition_status = ORM_BIL_BillPosition_TransmitionStatus.Query.Search(Connection, Transaction, transmition_statusQ).SingleOrDefault();
                        if (transmition_status != null && transmition_status.TransmitionCode != 8 && transmition_status.TransmitionCode != 11 && transmition_status.TransmitionCode != 17)
                        {
                            transmition_status.IsActive = false;
                            transmition_status.Modification_Timestamp = DateTime.Now;
                            transmition_status.Save(Connection, Transaction);

                            ORM_BIL_BillPosition_TransmitionStatus position_status = new ORM_BIL_BillPosition_TransmitionStatus();
                            position_status.BIL_BillPosition_TransmitionStatusID = Guid.NewGuid();
                            position_status.BillPosition_RefID = bill_position.bill_position_id;
                            position_status.Creation_Timestamp = DateTime.Now;
                            position_status.IsActive = true;
                            position_status.PrimaryComment = Parameter.reasonForCancelation;
                            position_status.Modification_Timestamp = DateTime.Now;
                            position_status.TransmitionCode = transmition_status.TransmitionCode != 2 ? 8 : 11;
                            position_status.TransmittedOnDate = DateTime.Now;
                            position_status.Tenant_RefID = securityTicket.TenantID;
                            position_status.TransmitionStatusKey = "oct";

                            #region CREATE SNAPSHOT
                            DateTime today = DateTime.Today;
                            int age = today.Year - patient_details.birthday.Year;
                            if (patient_details.birthday > today.AddYears(-age))
                                age--;
                            var oct_doctor_details = cls_Get_Doctor_Details_for_DoctorID.Invoke(Connection, Transaction, new P_DO_GDDfDID_0823() { DoctorID = case_to_submit.oct_doctor_id }, securityTicket).Result.SingleOrDefault();

                            var snapshot = cls_Create_XML_for_Immutable_Fields.Invoke(Connection, Transaction, new P_CAS_CXFIF_0830()
                            {
                                DiagnosisCatalogCode = diagnose_details.diagnose_icd_10,
                                DiagnosisCatalogName = diagnose_details.catalog_display_name,
                                DiagnosisName = diagnose_details.diagnose_name,
                                IFPerformedMedicalPracticeName = oct_doctor_details != null ? oct_doctor_details.practice : null,
                                IFPerformedResponsibleBPFullName = oct_doctor_details != null ? GenericUtils.GetDoctorName(oct_doctor_details) : null,
                                Localization = case_to_submit.localization,
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

                            #endregion

                            position_status.Save(Connection, Transaction);
                            current_status = "FS" + position_status.TransmitionCode;
                        }

                        break;
                    }
                }
                #endregion
            }
            else
            {
                var bill_positions = cls_Get_BillPositionIDs_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GBPIDsfCID_0928() { CaseID = Parameter.case_id }, securityTicket).Result;

                foreach (var bill_position in bill_positions)
                {
                    #region CHANGE AFTERCARE STATUS
                    ORM_BIL_BillPosition_TransmitionStatus.Query transmition_statusQ = new ORM_BIL_BillPosition_TransmitionStatus.Query();
                    transmition_statusQ.BillPosition_RefID = bill_position.bill_position_id;
                    transmition_statusQ.TransmitionStatusKey = "aftercare";
                    transmition_statusQ.Tenant_RefID = securityTicket.TenantID;
                    transmition_statusQ.IsDeleted = false;
                    transmition_statusQ.IsActive = true;

                    var transmition_status = ORM_BIL_BillPosition_TransmitionStatus.Query.Search(Connection, Transaction, transmition_statusQ).SingleOrDefault();
                    if (transmition_status != null && transmition_status.TransmitionCode != 8 && transmition_status.TransmitionCode != 11 && transmition_status.TransmitionCode != 17)
                    {
                        transmition_status.IsActive = false;
                        transmition_status.Modification_Timestamp = DateTime.Now;
                        transmition_status.Save(Connection, Transaction);

                        ORM_BIL_BillPosition_TransmitionStatus position_status = new ORM_BIL_BillPosition_TransmitionStatus();
                        position_status.BIL_BillPosition_TransmitionStatusID = Guid.NewGuid();
                        position_status.BillPosition_RefID = bill_position.bill_position_id;
                        position_status.Creation_Timestamp = DateTime.Now;
                        position_status.IsActive = true;
                        position_status.PrimaryComment = Parameter.reasonForCancelation;
                        position_status.Modification_Timestamp = DateTime.Now;
                        position_status.TransmitionCode = transmition_status.TransmitionCode != 2 ? 8 : 11;
                        position_status.TransmittedOnDate = DateTime.Now;
                        position_status.Tenant_RefID = securityTicket.TenantID;
                        position_status.TransmitionStatusKey = "aftercare";

                        #region CREATE SNAPSHOT
                        DateTime today = DateTime.Today;
                        int age = today.Year - patient_details.birthday.Year;
                        if (patient_details.birthday > today.AddYears(-age))
                            age--;

                        var snapshot = cls_Create_XML_for_Immutable_Fields.Invoke(Connection, Transaction, new P_CAS_CXFIF_0830()
                        {
                            DiagnosisCatalogCode = diagnose_details.diagnose_icd_10,
                            DiagnosisCatalogName = diagnose_details.catalog_display_name,
                            DiagnosisName = diagnose_details.diagnose_name,
                            IFPerformedMedicalPracticeName = treatment_practice_details.practice_name,
                            IFPerformedResponsibleBPFullName = GenericUtils.GetDoctorName(treatment_doctor_details),
                            Localization = case_to_submit.localization,
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

                        #endregion

                        position_status.Save(Connection, Transaction);
                        current_status = "FS" + position_status.TransmitionCode;
                    }

                    #endregion
                }
            }

            #region Send e-mail
            if (current_case_status != null && current_case_status.fs_status != 1 && !mailSent)
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("de-DE");
                List<String> mailToL = new List<String>();

                var accountMails = cls_Get_All_Account_LoginEmails_Who_Receive_Notifications.Invoke(Connection, Transaction, securityTicket).Result.ToList();
                foreach (var mail in accountMails)
                {
                    mailToL.Add(mail.LoginEmail);
                }

                //  mailToL.Add(emailTo);
                string mailToFromCompanySettings = cls_Get_Company_Settings.Invoke(Connection, Transaction, securityTicket).Result.Email;
                mailToL.Add(mailToFromCompanySettings);

                string appName = WebConfigurationManager.AppSettings["mmAppUrl"];
                var prefix = HttpContext.Current.Request.Url.AbsoluteUri.Contains("https") ? "https://" : "http://";
                var imageUrl = HttpContext.Current.Request.Url.AbsoluteUri.Substring(0, HttpContext.Current.Request.Url.AbsoluteUri.IndexOf("api")) + "Content/images/logo.png";
                var email_template = File.ReadAllText(HttpContext.Current.Server.MapPath("~/EmailTemplates/AftercareCancelledFromSettlementPageEmailTemplate.html"));

                var subjectsJson = File.ReadAllText(HttpContext.Current.Server.MapPath("~/EmailTemplates/EmailSubjects.json"));
                dynamic subjects = JsonConvert.DeserializeObject(subjectsJson);
                var subjectMail = subjects["AftercareCancelledFromSettlementPageSubject"].ToString();

                email_template = EmailTemplater.SetTemplateData(email_template, new
                {
                    case_type = Parameter.caseType == "op" ? "Behandlung" : Parameter.caseType == "ac" ? "Nachsorge" : "OCT",
                    patient_first_name = patient_details.patient_first_name,
                    patient_last_name = patient_details.patient_last_name,
                    treatment_date = case_to_submit.treatment_date.ToString("dd.MM.yyyy"),
                    doctor_title = Parameter.caseType == "op" || Parameter.caseType == "oct" ? treatment_doctor_details.title : aftercare_doctor_details.title,
                    doctor_first_name = Parameter.caseType == "op" || Parameter.caseType == "oct" ? treatment_doctor_details.first_name : aftercare_doctor_details.first_name,
                    doctor_last_name = Parameter.caseType == "op" || Parameter.caseType == "oct" ? treatment_doctor_details.last_name : aftercare_doctor_details.last_name,
                    mmapp_treatment_page_url = prefix + HttpContext.Current.Request.Url.Authority + "/" + appName + "/#/treatment",
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
                    LogUtils.Logger.LogDocAppInfo(new LogUtils.LogEntry(System.Reflection.MethodInfo.GetCurrentMethod(), ex, null, "Cancel treatment/aftercare from settlement: Email sending failed."), "EmailExceptions");
                }

            }
            #endregion

            returnValue.Result = case_to_submit.patient_id;
            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_Guid Invoke(string ConnectionString, P_CAS_CCFSP_1751 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, P_CAS_CCFSP_1751 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, P_CAS_CCFSP_1751 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_CAS_CCFSP_1751 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_Guid functionReturn = new FR_Guid();
            try
            {

                if (cleanupConnection == true)
                {
                    Connection = CSV2Core_MySQL.Support.DBSQLSupport.CreateConnection(ConnectionString);
                    Connection.Open();
                }
                if (cleanupTransaction == true)
                {
                    Transaction = Connection.BeginTransaction();
                }

                functionReturn = Execute(Connection, Transaction, Parameter, securityTicket);

                #region Cleanup Connection/Transaction
                //Commit the transaction 
                if (cleanupTransaction == true)
                {
                    Transaction.Commit();
                }
                //Close the connection
                if (cleanupConnection == true)
                {
                    Connection.Close();
                }
                #endregion
            }
            catch (Exception ex)
            {
                try
                {
                    if (cleanupTransaction == true && Transaction != null)
                    {
                        Transaction.Rollback();
                    }
                }
                catch { }

                try
                {
                    if (cleanupConnection == true && Connection != null)
                    {
                        Connection.Close();
                    }
                }
                catch { }

                throw new Exception("Exception occured in method cls_Cancel_Case_From_Settlement_Page", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes
    #region SClass P_CAS_CCFSP_1751 for attribute P_CAS_CCFSP_1751
    [DataContract]
    public class P_CAS_CCFSP_1751
    {
        //Standard type parameters
        [DataMember]
        public Guid case_id { get; set; }
        [DataMember]
        public Guid planned_action_id { get; set; }
        [DataMember]
        public Guid doctor { get; set; }
        [DataMember]
        public String caseType { get; set; }
        [DataMember]
        public String reasonForCancelation { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Cancel_Case_From_Settlement_Page(,P_CAS_CCFSP_1751 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Cancel_Case_From_Settlement_Page.Invoke(connectionString,P_CAS_CCFSP_1751 Parameter,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

/* Support for Parameter Invocation (Copy&Paste)
var parameter = new MMDocConnectDBMethods.Case.Atomic.Manipulation.P_CAS_CCFSP_1751();
parameter.case_id = ...;
parameter.planned_action_id = ...;
parameter.doctor = ...;
parameter.caseType = ...;
parameter.reasonForCancelation = ...;

*/
