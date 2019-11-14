/* 
 * Generated on 12/15/16 19:44:33
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
using System.Runtime.Serialization;
using MMDocConnectElasticSearchMethods.Models;
using MMDocConnectDBMethods.Case.Complex.Retrieval;
using MMDocConnectDBMethods.Case.Atomic.Retrieval;
using CL1_HEC_ACT;
using CL1_HEC;
using MMDocConnectElasticSearchMethods.Case.Retrieval;
using MMDocConnectElasticSearchMethods.Case.Manipulation;
using MMDocConnectElasticSearchMethods.Patient.Manipulation;
using MMDocConnectUtils;
using MMDocConnectDBMethods.Patient.Atomic.Retrieval;
using MMDocConnectDBMethods.MainData.Atomic.Retrieval;
using CL1_CMN_CTR;
using CL1_HEC_CTR;
using CL1_HEC_CAS;
using MMDocConnectElasticSearchMethods.Settlement.Retrieval;
using MMDocConnectElasticSearchMethods.Settlement.Manipulation;
using System.Web.Configuration;
using System.Web;
using System.IO;
using Newtonsoft.Json;
using MMDocConnectDBMethods.Doctor.Atomic.Retrieval;
using MMDocConnectDocApp;
using CL1_BIL;
using MMDocConnectElasticSearchMethods;
using MMDocConnectDBMethods.ElasticRefresh;
using CL1_HEC_BIL;

namespace MMDocConnectDBMethods.Case.Atomic.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Handle_OCT.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Handle_OCT
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Guid Execute(DbConnection Connection, DbTransaction Transaction, P_CAS_HOCT_1013 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_Guid();
            //Put your code here
            var oct_planned_action_type_id = cls_Get_ActionTypeID.Invoke(Connection, Transaction, new P_CAS_GATID_1514()
            {
                action_type_gpmid = EActionType.PlannedOct.Value()
            }, securityTicket).Result;

            var elastic_index = securityTicket.TenantID.ToString();

            var oct_performed_action_type_id = cls_Get_ActionTypeID.Invoke(Connection, Transaction, new P_CAS_GATID_1514()
            {
                action_type_gpmid = EActionType.PerformedOct.Value()
            }, securityTicket).Result;

            var oct_doctor = ORM_HEC_Doctor.Query.Search(Connection, Transaction, new ORM_HEC_Doctor.Query() { HEC_DoctorID = Parameter.oct_doctor_id, Tenant_RefID = securityTicket.TenantID, IsDeleted = false }).SingleOrDefault();
            var patient_practice_name = cls_Get_Patient_PracticeName_for_PatientID.Invoke(Connection, Transaction, new P_P_PA_GPPNfPID_1131() { PatientID = Parameter.patient_id }, securityTicket).Result;

            var current_treatment_year_start_date = DateTime.MaxValue;

            if (oct_doctor != null)
            {
                current_treatment_year_start_date = cls_Get_TreatmentYear.Invoke(Connection, Transaction, new P_CAS_GTY_1125()
                {
                    Date = Parameter.treatment_date,
                    LocalizationCode = Parameter.localization,
                    PatientID = Parameter.patient_id,
                }, securityTicket).Result;
            }
            else {
                current_treatment_year_start_date = cls_Get_TreatmentYear.Invoke(Connection, Transaction, new P_CAS_GTY_1125()
                {
                    Date = Parameter.treatment_date,
                    LocalizationCode = Parameter.localization,
                    PatientID = Parameter.patient_id
                }, securityTicket).Result;
            }
            var treatment_year_length = cls_Get_TreatmentYearLength.Invoke(Connection, Transaction, new P_CAS_GTYL_1317()
            {
                Date = Parameter.treatment_date,
                PatientID = Parameter.patient_id
            }, securityTicket).Result;

            var current_treatment_year_end_date = current_treatment_year_start_date.AddDays(treatment_year_length - 1);

            var oct_gpos_ids = cls_Get_GposIDs_for_GposType.Invoke(Connection, Transaction, new P_MD_GGpoIDsfGposT_1145() { GposType = EGposType.Oct.Value() }, securityTicket).Result;
            if (!oct_gpos_ids.Any())
            {
                return returnValue;
            }

            var last_potential_consent = cls_Get_Patient_Consents_before_Date_and_GposIDs.Invoke(Connection, Transaction, new P_PA_GPCbDaGposIDs_1154()
            {
                Date = Parameter.treatment_date.Date,
                GposIDs = oct_gpos_ids.Select(t => t.GposID).ToArray(),
                PatientID = Parameter.patient_id
            }, securityTicket).Result.FirstOrDefault(t => t.consent_valid_from.Date <= Parameter.treatment_date.Date);

            var latest_oct_planned_actions = cls_Get_Latest_PlannedActionID_for_PatientID_ActionTypeID_and_LocalizationCode.Invoke(Connection, Transaction, new P_CAS_GLPAIDfPIDATIDaLC_1545()
            {
                ActionTypeID = oct_planned_action_type_id,
                LocalizationCode = Parameter.localization,
                PatientID = Parameter.patient_id
            }, securityTicket).Result;

            if (last_potential_consent == null && Parameter.oct_doctor_id != Guid.Empty && latest_oct_planned_actions.Any(t => t.OpDate >= current_treatment_year_start_date.Date && t.OpDate < current_treatment_year_start_date.AddDays(treatment_year_length).Date))
            {
                var latest_oct_planned_action_id = latest_oct_planned_actions.FirstOrDefault(t => t.CaseID != Parameter.case_id && t.OpDate >= current_treatment_year_start_date.Date && t.OpDate < current_treatment_year_start_date.AddDays(treatment_year_length).Date);
                if (latest_oct_planned_action_id == null)
                {
                    latest_oct_planned_action_id = latest_oct_planned_actions.FirstOrDefault(t => t.CaseID == Parameter.case_id && t.OpDate >= current_treatment_year_start_date.Date && t.OpDate < current_treatment_year_start_date.AddDays(treatment_year_length).Date);
                }
                var latest_oct_planned_action = ORM_HEC_ACT_PlannedAction.Query.Search(Connection, Transaction, new ORM_HEC_ACT_PlannedAction.Query()
                {
                    HEC_ACT_PlannedActionID = latest_oct_planned_action_id.PlannedActionID
                }).Single();
            }
            else
            {
                var case_properties = cls_Get_Case_Properties_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GCPfCID_1204() { CaseID = Parameter.case_id }, securityTicket).Result;

                var oct_planned_action_id = cls_Get_Latest_PlannedActionID_for_CaseID_and_ActionTypeID.Invoke(Connection, Transaction, new P_CAS_GLPAIDfCIDaATID_1635()
                {
                    ActionTypeID = oct_planned_action_type_id,
                    CaseID = Parameter.case_id
                }, securityTicket).Result;

                #region Case creation
                if (!Parameter.is_submit)
                {
                    var case_fs_statuses = cls_Get_Case_TransmitionCode_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GCTCfCID_1427() { CaseID = Parameter.case_id }, securityTicket).Result;
                    var op_submitted = case_fs_statuses.Any(t => t.gpos_type == EGposType.Operation.Value());

                    var latest_oct_planned_action_id = cls_Get_Latest_PlannedActionID_for_PatientID_ActionTypeID_and_LocalizationCode.Invoke(Connection, Transaction, new P_CAS_GLPAIDfPIDATIDaLC_1545()
                    {
                        ActionTypeID = oct_planned_action_type_id,
                        LocalizationCode = Parameter.localization,
                        PatientID = Parameter.patient_id
                    }, securityTicket).Result.FirstOrDefault(t => t.CaseID != Parameter.case_id && t.OpDate >= current_treatment_year_start_date.Date && t.OpDate < current_treatment_year_start_date.AddDays(treatment_year_length).Date);

                    var properties_to_delete = case_properties.Where(t => t.property_gpmid == ECaseProperty.WithdrawOct.Value() || t.property_gpmid == ECaseProperty.SubmitOctUntilDate.Value());
                    if (Parameter.withdraw_oct && latest_oct_planned_action_id != null)
                    {
                        var latest_oct_planned_action = ORM_HEC_ACT_PlannedAction.Query.Search(Connection, Transaction, new ORM_HEC_ACT_PlannedAction.Query()
                        {
                            HEC_ACT_PlannedActionID = latest_oct_planned_action_id.PlannedActionID
                        }).Single();

                        if (Parameter.submit_oct_until_date != DateTime.MinValue)
                        {
                            cls_Save_Case_Property.Invoke(Connection, Transaction, new P_CAS_SCP_1308()
                            {
                                case_id = Parameter.case_id,
                                property_gpm_id = ECaseProperty.SubmitOctUntilDate.Value(),
                                property_name = "Submit OCT until date",
                                property_string_value = String.Format("{0};{1};{2};{3}", Parameter.submit_oct_until_date.ToString("yyyy-MM-ddTHH:mm:ss"), latest_oct_planned_action.ToBePerformedBy_BusinessParticipant_RefID, Parameter.localization, latest_oct_planned_action.HEC_ACT_PlannedActionID)
                            }, securityTicket);

                            properties_to_delete = properties_to_delete.Where(t => t.property_gpmid == ECaseProperty.WithdrawOct.Value()).ToList();
                        }
                        else if (Parameter.withdraw_oct)
                        {
                            cls_Save_Case_Property.Invoke(Connection, Transaction, new P_CAS_SCP_1308()
                            {
                                case_id = Parameter.case_id,
                                property_name = "Withdraw OCT",
                                property_gpm_id = ECaseProperty.WithdrawOct.Value(),
                                property_string_value = String.Format("{0}", latest_oct_planned_action.ToBePerformedBy_BusinessParticipant_RefID.ToString())
                            }, securityTicket);

                            properties_to_delete = properties_to_delete.Where(t => t.property_gpmid == ECaseProperty.SubmitOctUntilDate.Value()).ToList();
                        }
                    }

                    foreach (var prop in properties_to_delete)
                    {
                        ORM_HEC_CAS_Case_UniversalPropertyValue.Query.SoftDelete(Connection, Transaction, new ORM_HEC_CAS_Case_UniversalPropertyValue.Query() { HEC_CAS_Case_UniversalPropertyValueID = prop.id });
                    }

                    if (!op_submitted || Parameter.is_documentation)
                    {
                        if (oct_planned_action_id != null)
                        {
                            var latest_oct_planned_action = ORM_HEC_ACT_PlannedAction.Query.Search(Connection, Transaction, new ORM_HEC_ACT_PlannedAction.Query() { HEC_ACT_PlannedActionID = oct_planned_action_id.PlannedActionID }).Single();

                            if (Parameter.oct_doctor_id == Guid.Empty)
                            {
                                latest_oct_planned_action.IsDeleted = true;
                            }
                            else
                            {
                                latest_oct_planned_action.ToBePerformedBy_BusinessParticipant_RefID = oct_doctor.BusinessParticipant_RefID;
                            }

                            latest_oct_planned_action.Modification_Timestamp = DateTime.Now;
                            latest_oct_planned_action.Save(Connection, Transaction);

                            returnValue.Result = latest_oct_planned_action.HEC_ACT_PlannedActionID;

                            #region localization changed
                            if (Parameter.localization_changed)
                            {
                                var old_localization = Parameter.localization == "L" ? "R" : "L";

                                var latest_new_localization_oct_bill_position = cls_Get_Existing_OCT_BillPosition_for_PatientID_and_LocalizationCode.Invoke(Connection, Transaction, new P_CAS_GEBPfPIDaLC_1803()
                                {
                                    LocalizationCode = Parameter.localization,
                                    PatientID = Parameter.patient_id
                                }, securityTicket).Result;

                                var latest_old_localization_op = cls_Get_OpDates_for_PatientID_and_LocalizationCode_in_TreatmentYear.Invoke(Connection, Transaction, new P_CAS_GOpDfPIDaLCiTY_1110()
                                {
                                    LocalizationCode = old_localization,
                                    PatientID = Parameter.patient_id,
                                    TreatmentYearEndDate = DateTime.Now
                                }, securityTicket).Result.FirstOrDefault();

                                if (latest_new_localization_oct_bill_position != null && latest_new_localization_oct_bill_position.CaseID == Parameter.case_id)
                                {
                                    if (latest_old_localization_op == null)
                                    {
                                        // check if case has pending oct
                                        var case_has_pending_oct = cls_Get_CaseIDs_with_Pending_Octs_for_PatientID_and_LocalizationCode.Invoke(Connection, Transaction, new P_CAS_GCIDswPOctsfPIDaLC_1103()
                                        {
                                            LocalizationCode = Parameter.localization,
                                            PatientID = Parameter.patient_id
                                        }, securityTicket).Result.Any(t => t.case_id == Parameter.case_id);

                                        if (case_has_pending_oct)
                                        {
                                            throw new Exception(String.Format("Case has a pending OCT attached and there isn't another IVOM to transfer OCT to. Localization cannot be changed. Case id: {0}", Parameter.case_id));
                                        }
                                    }
                                    else
                                    {
                                        var case_details = cls_Get_Case_Details_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GCDfCID_1435() { CaseID = latest_old_localization_op.CaseID }, securityTicket).Result;

                                        cls_Calculate_Case_GPOS.Invoke(Connection, Transaction, new P_CAS_CCGPOS_1000()
                                        {
                                            case_id = latest_old_localization_op.CaseID,
                                            diagnose_id = case_details.diagnose_id,
                                            drug_id = case_details.drug_id,
                                            patient_id = case_details.patient_id,
                                            localization = case_details.localization,
                                            treatment_date = case_details.treatment_date,
                                            oct_doctor_id = Parameter.oct_doctor_id
                                        }, securityTicket);
                                    }
                                }

                                var new_localization_oct_bill_position = cls_Get_Existing_OCT_BillPosition_for_PatientID_and_LocalizationCode_where_not_CaseID.Invoke(Connection, Transaction, new P_CAS_GEBPfPIDaLCwnCID_1438()
                                {
                                    CaseID = Parameter.case_id,
                                    PatientID = Parameter.patient_id,
                                    LocalizationCode = Parameter.localization
                                }, securityTicket).Result;

                                if (new_localization_oct_bill_position != null)
                                {
                                    cls_Delete_BillingData_for_BillPositionID.Invoke(Connection, Transaction, new P_CAS_DBDfHBPID_1549() { bill_position_id = new_localization_oct_bill_position.BillPositionID }, securityTicket);
                                }
                            }
                            #endregion
                        }
                        else if (Parameter.oct_doctor_id != Guid.Empty)
                        {
                            var existing_rejection_properties = cls_Get_Localizations_where_Oct_Rejected.Invoke(Connection, Transaction, new P_CAS_GLwOctR_1026()
                            {
                                PatientID = Parameter.patient_id,
                                RejectedOctPropertyID = ECaseProperty.HasRejectedOct.Value()
                            }, securityTicket).Result;

                            foreach (var existing_rejection_property in existing_rejection_properties.Where(t => t.localization == Parameter.localization))
                            {
                                ORM_HEC_CAS_Case_UniversalPropertyValue.Query.SoftDelete(Connection, Transaction, new ORM_HEC_CAS_Case_UniversalPropertyValue.Query()
                                {
                                    HEC_CAS_Case_UniversalPropertyValueID = existing_rejection_property.property_id,
                                    Tenant_RefID = securityTicket.TenantID,
                                    IsDeleted = false
                                });
                            }

                            returnValue = cls_Create_OCT.Invoke(Connection, Transaction, new P_CAS_COCT_1703()
                            {
                                case_id = Parameter.case_id,
                                oct_action_type_id = oct_planned_action_type_id,
                                oct_bpt_id = oct_doctor.BusinessParticipant_RefID,
                                patient_id = Parameter.patient_id,
                                treatment_date = Parameter.treatment_date,
                                practice_id = Parameter.oct_doctor_practice_id
                            }, securityTicket);

                            var existingBillPosition = cls_Get_Existing_OCT_BillPosition_for_PatientID_and_LocalizationCode.Invoke(Connection, Transaction, new P_CAS_GEBPfPIDaLC_1803()
                            {
                                LocalizationCode = Parameter.localization,
                                PatientID = Parameter.patient_id
                            }, securityTicket).Result;

                            if (existingBillPosition == null)
                            {
                                cls_Calculate_Case_GPOS.Invoke(Connection, Transaction, new P_CAS_CCGPOS_1000()
                                {
                                    case_id = Parameter.case_id,
                                    diagnose_id = Parameter.diagnose_id,
                                    drug_id = Parameter.drug_id,
                                    patient_id = Parameter.patient_id,
                                    localization = Parameter.localization,
                                    treatment_date = Parameter.treatment_date,
                                    oct_doctor_id = Parameter.oct_doctor_id
                                }, securityTicket);
                            }
                            else
                            {
                                cls_Delete_BillingData_for_BillPositionID.Invoke(Connection, Transaction, new P_CAS_DBDfHBPID_1549() { bill_position_id = existingBillPosition.BillPositionID }, securityTicket);

                                var isAutoGenerated = cls_Get_CasePropertyValue_for_CaseIDs_and_CasePropertyGpmID.Invoke(Connection, Transaction, new P_CAS_GCPVfCIDsaCGpmID_0832()
                                {
                                    CaseIDs = new Guid[] { existingBillPosition.CaseID },
                                    IncludeDeleted = true,
                                    PropertyGpmID = ECaseProperty.MissingIvom.Value()
                                }, securityTicket).Result.Any();

                                var octIds = new List<Guid>();
                                if (isAutoGenerated)
                                {
                                    var caseBillCodeIds = cls_Get_CaseBillCodeIDs_for_GposType_and_CaseID.Invoke(Connection, Transaction, new P_CAS_GCBCIDsfGposTaCID_1622()
                                    {
                                        CaseID = existingBillPosition.CaseID,
                                        OctGposType = EGposType.Oct.Value()
                                    }, securityTicket).Result;

                                    foreach (var caseBillCodeId in caseBillCodeIds)
                                    {
                                        var caseBillCode = new ORM_HEC_CAS_Case_BillCode();
                                        caseBillCode.Load(Connection, Transaction, caseBillCodeId.HEC_CAS_Case_BillCodeID);

                                        caseBillCode.HEC_CAS_Case_RefID = Parameter.case_id;
                                        caseBillCode.Modification_Timestamp = DateTime.Now;

                                        caseBillCode.Save(Connection, Transaction);
                                    }

                                    var relevantActions = ORM_HEC_CAS_Case_RelevantPlannedAction.Query.Search(Connection, Transaction, new ORM_HEC_CAS_Case_RelevantPlannedAction.Query()
                                    {
                                        Case_RefID = existingBillPosition.CaseID,
                                        Tenant_RefID = securityTicket.TenantID,
                                        IsDeleted = false
                                    });

                                    foreach (var relevantAction in relevantActions)
                                    {
                                        relevantAction.Case_RefID = Parameter.case_id;
                                        relevantAction.Modification_Timestamp = DateTime.Now;

                                        relevantAction.Save(Connection, Transaction);

                                        octIds.Add(relevantAction.PlannedAction_RefID);
                                    }
                                }

                                cls_Calculate_Case_GPOS.Invoke(Connection, Transaction, new P_CAS_CCGPOS_1000()
                                {
                                    case_id = Parameter.case_id,
                                    diagnose_id = Parameter.diagnose_id,
                                    drug_id = Parameter.drug_id,
                                    patient_id = Parameter.patient_id,
                                    localization = Parameter.localization,
                                    treatment_date = Parameter.treatment_date,
                                    oct_doctor_id = Parameter.oct_doctor_id
                                }, securityTicket);
                            }
                        }
                    }
                    else if (Parameter.localization_changed)
                    {
                        var old_localization = Parameter.localization == "L" ? "R" : "L";

                        #region OCT e-mail
                        var patient_consent_valid_for_months_parameter = cls_Get_ConsentValidForMonths_for_LatestConsent_before_TreatmentDate_for_PatientID.Invoke(Connection, Transaction, new P_PA_GCVfMfLCbTDfPID_0930()
                        {
                            PatientID = Parameter.patient_id,
                            TreatmentDate = Parameter.treatment_date.Date
                        }, securityTicket).Result;

                        var performedOcts = cls_Get_NonCancelledOcts_in_OpRenewedConsentTimespan.Invoke(Connection, Transaction, new P_CAS_GNCOctsiOPRCT_1416()
                        {
                            PatientID = Parameter.patient_id,
                            PlannedOctActionTypeID = oct_planned_action_type_id,
                            ConsentStart = Parameter.treatment_date.Date,
                            ConsentEnd = Parameter.treatment_date.Date.AddMonths(patient_consent_valid_for_months_parameter != null && patient_consent_valid_for_months_parameter.consent_valid_for_months < 200000 ? Convert.ToInt32(patient_consent_valid_for_months_parameter.consent_valid_for_months) : 12)
                        }, securityTicket).Result.Where(t => t.localization == old_localization).ToList();

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

                            var patient_information = cls_Get_Patient_Details_for_PatientID.Invoke(Connection, Transaction, new P_P_PA_GPDfPID_1124() { PatientID = Parameter.patient_id }, securityTicket).Result;
                            var treatment_doctor_details = cls_Get_Doctor_Details_for_DoctorID.Invoke(Connection, Transaction, new P_DO_GDDfDID_0823() { DoctorID = Parameter.treatment_doctor_id }, securityTicket).Result.First();

                            email_template = EmailTemplater.SetTemplateData(email_template, new
                            {
                                patient_first_name = patient_information.patient_first_name,
                                patient_last_name = patient_information.patient_last_name,
                                treatment_date = Parameter.treatment_date.ToString("dd.MM.yyyy"),
                                treatment_doctor_title = treatment_doctor_details.title,
                                treatment_doctor_first_name = treatment_doctor_details.first_name,
                                treatment_doctor_last_name = treatment_doctor_details.last_name,
                                octs = performedOcts,
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
                                LogUtils.Logger.LogDocAppInfo(new LogUtils.LogEntry(System.Reflection.MethodInfo.GetCurrentMethod(), ex, null, "Cancel case from settlement: Email sending failed."), "EmailExceptions");
                            }
                        }
                        #endregion

                        #region OCT withdrawal
                        var existing_open_bill_position = cls_Get_Existing_OCT_BillPosition_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GEBPfCID_1522() { CaseID = Parameter.case_id }, securityTicket).Result;

                        if (existing_open_bill_position != null)
                        {
                            var non_performed_oct = cls_Get_NonPerformed_Oct_for_CaseID_and_PlannedActionTypeID.Invoke(Connection, Transaction, new P_CAS_GNPOctfCIDaPATID_1240()
                            {
                                CaseID = Parameter.case_id,
                                OctPlannedActionTypeID = oct_planned_action_type_id
                            }, securityTicket).Result;

                            var oct_planned_action = ORM_HEC_ACT_PlannedAction.Query.Search(Connection, Transaction, new ORM_HEC_ACT_PlannedAction.Query()
                            {
                                HEC_ACT_PlannedActionID = non_performed_oct.action_id
                            }).Single();

                            oct_planned_action.IsCancelled = true;
                            oct_planned_action.Modification_Timestamp = DateTime.Now;
                            oct_planned_action.Save(Connection, Transaction);

                            var new_id = cls_Create_OCT.Invoke(Connection, Transaction, new P_CAS_COCT_1703()
                            {
                                case_id = Parameter.case_id,
                                oct_action_type_id = oct_planned_action_type_id,
                                oct_bpt_id = oct_doctor.BusinessParticipant_RefID,
                                patient_id = Parameter.patient_id,
                                practice_id = Parameter.oct_doctor_practice_id,
                                treatment_date = Parameter.treatment_date
                            }, securityTicket).Result;
                        }
                        #endregion
                    }
                }
                #endregion

                #region Case submission
                else
                {
                    var existingBillPosition = cls_Get_Existing_OCT_BillPosition_for_PatientID_and_LocalizationCode.Invoke(Connection, Transaction, new P_CAS_GEBPfPIDaLC_1803()
                    {
                        LocalizationCode = Parameter.localization,
                        PatientID = Parameter.patient_id
                    }, securityTicket).Result;

                    if (existingBillPosition != null)
                    {
                        var oct_planned_actions = cls_Get_Latest_PlannedActionID_for_PatientID_ActionTypeID_and_LocalizationCode.Invoke(Connection, Transaction, new P_CAS_GLPAIDfPIDATIDaLC_1545()
                        {
                            ActionTypeID = oct_planned_action_type_id,
                            PatientID = Parameter.patient_id,
                            LocalizationCode = Parameter.localization
                        }, securityTicket).Result;
                        var oct = new Oct_Model();

                        #region Magic
                        // don't ask 
                        var i = 0;
                        do
                        {
                            var oct_planned_action = oct_planned_actions[i++];
                            oct = Retrieve_Octs.GetOctForID(oct_planned_action.PlannedActionID.ToString(), elastic_index);
                            returnValue.Result = oct_planned_action.PlannedActionID;
                        } while (i < oct_planned_actions.Length && oct == null);
                        #endregion

                        if (oct != null)
                        {
                            if (case_properties.Any(t => t.property_gpmid == ECaseProperty.WithdrawOct.Value() || t.property_gpmid == ECaseProperty.SubmitOctUntilDate.Value()))
                            {
                                var withdraw_oct_property = case_properties.SingleOrDefault(t => t.property_gpmid == ECaseProperty.WithdrawOct.Value());
                                if (withdraw_oct_property != null)
                                {
                                    var doctor_whose_oct_is_withdrawn_bpt_id = Guid.Parse(withdraw_oct_property.string_value);
                                    var planned_oct_to_withdraw = oct_planned_actions.First(t => t.CaseID != Parameter.case_id && t.DoctorBptID == doctor_whose_oct_is_withdrawn_bpt_id);
                                    var planned_oct_action = new ORM_HEC_ACT_PlannedAction();
                                    planned_oct_action.Load(Connection, Transaction, planned_oct_to_withdraw.PlannedActionID);
                                    planned_oct_action.IsCancelled = true;
                                    planned_oct_action.Modification_Timestamp = DateTime.Now;

                                    planned_oct_action.Save(Connection, Transaction);
                                }
                            }
                            else
                            {
                                var oct_doctor_bpt_id = ORM_HEC_Doctor.Query.Search(Connection, Transaction, new ORM_HEC_Doctor.Query() { HEC_DoctorID = Parameter.oct_doctor_id }).Single().BusinessParticipant_RefID;
                                var oct_planned = ORM_HEC_ACT_PlannedAction.Query.Search(Connection, Transaction, new ORM_HEC_ACT_PlannedAction.Query() { HEC_ACT_PlannedActionID = returnValue.Result }).Single();
                                oct_planned.ToBePerformedBy_BusinessParticipant_RefID = oct_doctor_bpt_id;
                                oct_planned.Modification_Timestamp = DateTime.Now;

                                oct_planned.Save(Connection, Transaction);

                                if (oct.status == "OCT6")
                                {
                                    var case_with_pending_oct = cls_Get_CaseIDs_with_Pending_Octs_for_PatientID_and_LocalizationCode.Invoke(Connection, Transaction, new P_CAS_GCIDswPOctsfPIDaLC_1103()
                                    {
                                        LocalizationCode = Parameter.localization,
                                        PatientID = Parameter.patient_id
                                    }, securityTicket).Result.SingleOrDefault();

                                    if (case_with_pending_oct != null)
                                    {
                                        var fs_status = ORM_BIL_BillPosition_TransmitionStatus.Query.Search(Connection, Transaction, new ORM_BIL_BillPosition_TransmitionStatus.Query() { BIL_BillPosition_TransmitionStatusID = case_with_pending_oct.fs_status_id }).Single();
                                        fs_status.IsActive = false;
                                        fs_status.Modification_Timestamp = DateTime.Now;

                                        fs_status.Save(Connection, Transaction);

                                        var new_fs_status = new ORM_BIL_BillPosition_TransmitionStatus();
                                        new_fs_status.IsActive = true;
                                        new_fs_status.IsTransmitionStatusManuallySet = false;
                                        new_fs_status.BillPosition_RefID = fs_status.BillPosition_RefID;
                                        new_fs_status.Modification_Timestamp = DateTime.Now;
                                        new_fs_status.Tenant_RefID = securityTicket.TenantID;
                                        new_fs_status.TransmissionDataXML = fs_status.TransmissionDataXML;
                                        new_fs_status.TransmitionCode = 1;
                                        new_fs_status.TransmitionStatusKey = "oct";
                                        new_fs_status.TransmittedOnDate = DateTime.Now;

                                        new_fs_status.Save(Connection, Transaction);
                                    }
                                }
                            }
                        }
                    }
                }
                #endregion
            }

            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_Guid Invoke(string ConnectionString, P_CAS_HOCT_1013 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, P_CAS_HOCT_1013 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, P_CAS_HOCT_1013 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_CAS_HOCT_1013 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

                throw new Exception("Exception occured in method cls_Handle_OCT", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes
    #region SClass P_CAS_HOCT_1013 for attribute P_CAS_HOCT_1013
    [DataContract]
    public class P_CAS_HOCT_1013
    {
        //Standard type parameters
        [DataMember]
        public Boolean localization_changed { get; set; }
        [DataMember]
        public Boolean is_submit { get; set; }
        [DataMember]
        public Guid case_id { get; set; }
        [DataMember]
        public Guid patient_id { get; set; }
        [DataMember]
        public DateTime treatment_date { get; set; }
        [DataMember]
        public String diagnose_name { get; set; }
        [DataMember]
        public Guid diagnose_id { get; set; }
        [DataMember]
        public Guid drug_id { get; set; }
        [DataMember]
        public String localization { get; set; }
        [DataMember]
        public Guid oct_doctor_id { get; set; }
        [DataMember]
        public Guid oct_doctor_practice_id { get; set; }
        [DataMember]
        public String oct_doctor_name { get; set; }
        [DataMember]
        public DateTime patient_birthdate { get; set; }
        [DataMember]
        public String patient_name { get; set; }
        [DataMember]
        public Guid treatment_doctor_id { get; set; }
        [DataMember]
        public String treatment_doctor_name { get; set; }
        [DataMember]
        public Guid treatment_doctor_practice_id { get; set; }
        [DataMember]
        public String treatment_doctor_practice_name { get; set; }
        [DataMember]
        public String treatment_doctor_lanr { get; set; }
        [DataMember]
        public String oct_doctor_lanr { get; set; }
        [DataMember]
        public String patient_insurance_number { get; set; }
        [DataMember]
        public String patient_hip { get; set; }
        [DataMember]
        public String treatment_doctor_practice_bsnr { get; set; }
        [DataMember]
        public Guid id { get; set; }
        [DataMember]
        public Boolean withdraw_oct { get; set; }
        [DataMember]
        public DateTime submit_oct_until_date { get; set; }
        [DataMember]
        public Boolean is_documentation { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Handle_OCT(,P_CAS_HOCT_1013 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Handle_OCT.Invoke(connectionString,P_CAS_HOCT_1013 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Case.Atomic.Manipulation.P_CAS_HOCT_1013();
parameter.localization_changed = ...;
parameter.is_submit = ...;
parameter.case_id = ...;
parameter.patient_id = ...;
parameter.treatment_date = ...;
parameter.diagnose_name = ...;
parameter.diagnose_id = ...;
parameter.drug_id = ...;
parameter.localization = ...;
parameter.oct_doctor_id = ...;
parameter.oct_doctor_practice_id = ...;
parameter.oct_doctor_name = ...;
parameter.patient_birthdate = ...;
parameter.patient_name = ...;
parameter.treatment_doctor_id = ...;
parameter.treatment_doctor_name = ...;
parameter.treatment_doctor_practice_id = ...;
parameter.treatment_doctor_practice_name = ...;
parameter.treatment_doctor_lanr = ...;
parameter.oct_doctor_lanr = ...;
parameter.patient_insurance_number = ...;
parameter.patient_hip = ...;
parameter.treatment_doctor_practice_bsnr = ...;
parameter.id = ...;
parameter.withdraw_oct = ...;
parameter.submit_oct_until_date = ...;
parameter.is_documentation = ...;

*/
