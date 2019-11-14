using CL1_CMN_CTR;
using CL1_HEC_ACT;
using CL1_HEC_CAS;
using CL1_HEC_CRT;
using CSV2Core_MySQL.Support;
using DLCore_TokenVerification;
using LogUtils;
using MMDocConnectDBMethods.Case.Atomic.Manipulation;
using MMDocConnectDBMethods.Case.Atomic.Retrieval;
using MMDocConnectDBMethods.Case.Complex.Manipulation;
using MMDocConnectDBMethods.Case.Complex.Retrieval;
using MMDocConnectDBMethods.Doctor.Atomic.Retrieval;
using MMDocConnectDBMethods.MainData.Atomic.Retrieval;
using MMDocConnectDBMethods.MainData.Complex.Retrieval;
using MMDocConnectDBMethods.Patient.Atomic.Retrieval;
using MMDocConnectDocApp;
using MMDocConnectDocAppInterfaces;
using MMDocConnectDocAppModels;
using MMDocConnectElasticSearchMethods.Case.Entity;
using MMDocConnectElasticSearchMethods.Case.Manipulation;
using MMDocConnectElasticSearchMethods.Case.Retrieval;
using MMDocConnectElasticSearchMethods.Doctor.Retrieval;
using MMDocConnectElasticSearchMethods.Models;
using MMDocConnectElasticSearchMethods.Patient.Manipulation;
using MMDocConnectElasticSearchMethods.Settlement.Manipulation;
using MMDocConnectElasticSearchMethods.Settlement.Retrieval;
using MMDocConnectUtils;
using SharedServiceUtils;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace MMDocConnectDocAppServices
{
    public class SettlementDataService : BaseVerification, ISettlementDataService
    {

        #region RETRIEVAL

        public List<Guid> GetEligibleSettlementsForSubmissionReport(SubmissionReportParameter parameter, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            transaction = new TransactionalInformation();
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            try
            {
                //var settlements = Get_Settlement.GetAllSettlementsEligibleForSubmissionReport
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

            return new List<Guid>();
        }

        public string DownloadSubmissionReport(SubmissionReportParameter parameter, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            transaction = new TransactionalInformation();
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            try
            {
                P_CAS_CPRfSC_1813 reportParameter = null;
                IEnumerable<Settlement_Model> settlements = new List<Settlement_Model>();

                if (parameter.IsAllSelected)
                {
                    settlements = Get_Settlement.GetAllSettlementsEligibleForSubmissionReport(data.PracticeID, securityTicket);
                }
                else
                {
                    settlements = Get_Settlement.GetAllSettlementsEligibleForSubmissionReport(data.PracticeID, securityTicket, Array.ConvertAll(parameter.CaseParameters.Select(t => t.CaseID).ToArray(), x => x.ToString()));
                }

                if (settlements.Any())
                {
                    var host = HttpContext.Current.Request.UserHostAddress;
                    var logoUrl = HttpContext.Current.Server.MapPath("~/Content/images/medioslogo.jpg");
                    var reportContentPath = HttpContext.Current.Server.MapPath("~/ReportContent/SubmissionReportContent.xml");
                    var docOnlyReportContentPath = HttpContext.Current.Server.MapPath("~/ReportContent/DocumentationOnlySubmissionReportContent.xml");

                    reportParameter = new P_CAS_CPRfSC_1813()
                    {
                        CaseData = settlements.Select(t => new P_CAS_CPRfSC_1813a()
                        {
                            ActionID = Guid.Parse(t.id),
                            CaseID = Guid.Parse(t.case_id),
                            CaseType = t.case_type
                        }).ToArray(),
                        UploadedFrom = host,
                        LogoImageUrl = logoUrl,
                        ReportContentPath = reportContentPath,
                        DocumentationOnlyReportContentPath = docOnlyReportContentPath
                    };
                }

                if (reportParameter != null)
                {
                    var result = cls_Create_Pdf_Report_for_Submitted_Case.Invoke(connectionString, reportParameter, securityTicket).Result.PdfUploaded;

                    var patientDetailsList = new List<PatientDetailViewModel>();
                    foreach (var sett in settlements)
                    {
                        sett.is_report_downloaded = true;

                        var patientDetails = Retrieve_Patients.Get_PatientDetaiForID(sett.id, securityTicket);
                        if (patientDetails != null)
                        {
                            patientDetails.if_settlement_is_report_downloaded = true;
                            patientDetailsList.Add(patientDetails);
                        }
                    }

                    if (settlements.Any())
                    {
                        Add_new_Settlement.Import_Settlement_to_ElasticDB(settlements.ToList(), securityTicket.TenantID.ToString());
                    }

                    if (patientDetailsList.Any())
                    {
                        Add_New_Patient.ImportPatientDetailsToElastic(patientDetailsList, securityTicket.TenantID.ToString());
                    }

                    return result;
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
        public List<Settlement_Model> getSettlementData(ElasticParameterObject sort_parameter, string connectionString, string sessionTicket, out TransactionalInformation transaction)
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
                    List<AftercareHipParameter> rangeParameters = null;
                    if (sort_parameter.filter_by.ops_with_overdue_acs)
                    {
                        var hipData = cls_Get_Hip_Contract_Parameters_on_Tenant.Invoke(dbConnection, dbTransaction, securityTicket).Result.GroupBy(hip => hip.HipIK).ToDictionary(t => t.Key, t => t);
                        rangeParameters = hipData.Select(t =>
                        {
                            var result = new AftercareHipParameter();
                            if (t.Value.Any(x => x.ParameterValue != double.MaxValue && x.ParameterValue < 20000000 && x.ParameterValue != 0))
                            {
                                try
                                {
                                    result.MinimumTreatmentDate = DateTime.Now.AddDays(-Convert.ToInt32(t.Value.Single(x => x.ParameterName == "Number of days between surgery and aftercare - Days").ParameterValue)).ToString("yyyy-MM-dd");
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
                    }

                    var settlementData = Get_Settlement.Get_Settlement_items(sort_parameter, data.PracticeID.ToString(), securityTicket, rangeParameters);

                    if (settlementData.Any())
                    {
                        var case_ids = settlementData.Select(cas => { return Guid.Parse(cas.case_id); }).ToArray();

                        var aftercare_performed = cls_Get_is_Aftercare_Performed_for_CaseIDs.Invoke(dbConnection, dbTransaction, new P_CAS_GiAPfCIDs_1458() { CaseIDs = case_ids }, securityTicket).Result.GroupBy(t => t.case_id).ToDictionary(t => t.Key, t => t.Any(r => !r.is_aftercare_performed));
                        var aftercare_planned_actions = cls_Get_Aftercare_Planned_Actions_for_CaseIDs.Invoke(dbConnection, dbTransaction, new P_CAS_GAPAfCIDs_1501() { CaseIDs = case_ids }, securityTicket).Result.ToDictionary(t => t.case_id, t => t);
                        var fs_statusesDB = cls_Get_Case_TransmitionCode_for_CaseIDs.Invoke(connectionString, new P_CAS_GCTCfCIDs_1519 { CaseID = case_ids }, securityTicket).Result;
                        var fsCache = fs_statusesDB.GroupBy(t => t.case_id).ToDictionary(t => t.Key, t => t.ToList());

                        var all_contract_parameters = ORM_CMN_CTR_Contract_Parameter.Query.Search(dbConnection, dbTransaction, new ORM_CMN_CTR_Contract_Parameter.Query()
                        {
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false
                        }).GroupBy(t => t.Contract_RefID).ToDictionary(t => t.Key, t => t.ToList());

                        var patient_ids = settlementData.Select(t => Guid.Parse(t.patient_id)).ToArray();
                        var all_patient_consents = cls_Get_All_Patient_Consents_for_PatientIDs.Invoke(dbConnection, dbTransaction, new P_PA_GAPCfPIDs_1417() { PatientIDs = patient_ids }, securityTicket).Result.
                            GroupBy(t => t.patient_id).ToDictionary(t => t.Key, t => t.OrderByDescending(x => x.consent_valid_from).First());

                        return settlementData.Select(item =>
                        {

                            var case_id = Guid.Parse(item.case_id);
                            if (!fsCache.ContainsKey(case_id))
                            {
                                return item;
                            }

                            var fs_statuses = fsCache[case_id];

                            item.is_edit_button_visible = true;

                            if (item.ac_status == "AC1")
                            {
                                var patient_id = Guid.Parse(item.patient_id);
                                if (all_patient_consents.ContainsKey(patient_id))
                                {
                                    var consent = all_patient_consents[patient_id];
                                    if (all_contract_parameters.ContainsKey(consent.contract_id))
                                    {
                                        var contract_parameters = all_contract_parameters[consent.contract_id];

                                        var daysBetweenOpAndAcParameter = contract_parameters.SingleOrDefault(t => t.ParameterName == "Number of days between surgery and aftercare - Days");
                                        var daysBetweenOpAndAc = 1000;
                                        if (daysBetweenOpAndAcParameter != null && daysBetweenOpAndAcParameter.IfNumericValue_Value < 200000)
                                        {
                                            daysBetweenOpAndAc = Convert.ToInt32(daysBetweenOpAndAcParameter.IfNumericValue_Value);
                                        }

                                        if (item.surgery_date.AddDays(daysBetweenOpAndAc).Date < DateTime.Now.Date)
                                        {
                                            item.ac_status = "AC3";
                                        }
                                    }
                                }
                            }

                            if (item.status == "FS8" && item.case_type == "op")
                            {
                                item.is_edit_button_visible = false;
                            }
                            else
                            {
                                if (item.status == "FS6")
                                {
                                    item.is_edit_button_visible = data.AccountInformation.role.Contains("mm.docconect.doc.app.op") || item.case_type == "ac" || item.case_type == "oct";
                                    item.is_aftercare_performed = aftercare_performed.ContainsKey(case_id) && !aftercare_performed[case_id];
                                }
                                else
                                {
                                    if (item.status != "FS13")
                                    {
                                        if (item.case_type == "op")
                                        {
                                            var filtered_fs_statuses = fs_statuses.Where(fs => fs.gpos_type == EGposType.Aftercare.Value()).ToList();
                                            if (filtered_fs_statuses.Count > 1)
                                            {
                                                item.is_edit_button_visible = aftercare_planned_actions.ContainsKey(case_id) && !aftercare_planned_actions[case_id].is_cancelled;
                                            }
                                            else if (filtered_fs_statuses.Count == 1)
                                            {
                                                var fs_status = filtered_fs_statuses.Single();
                                                if (fs_status != null)
                                                {
                                                    if (fs_status.fs_status == 8 || fs_status.fs_status == 17 || fs_status.fs_status == 11)
                                                    {
                                                        var op_status = fs_statuses.First(fs => fs.gpos_type == EGposType.Operation.Value()).fs_status;
                                                        item.is_edit_button_visible = op_status != 8;
                                                    }
                                                    else
                                                    {
                                                        item.is_edit_button_visible = false;
                                                    }
                                                }
                                                else
                                                {
                                                    item.is_edit_button_visible = true;
                                                }
                                            }
                                            else
                                            {
                                                item.is_edit_button_visible = !filtered_fs_statuses.Any(fs => fs.fs_status != 8 && fs.fs_status != 11 && fs.fs_status != 17);
                                            }
                                        }
                                        else
                                        {
                                            item.is_edit_button_visible = false;
                                        }
                                    }
                                    else
                                    {
                                        item.is_edit_button_visible = false;
                                    }
                                }
                            }

                            return item;
                        }).ToList();
                    }
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

            return new List<Settlement_Model>();

        }

        public Case GetCaseDetailsforCaseID(Guid case_id, string connectionString, string sessionTicket, out TransactionalInformation transaction, HttpRequest request = null)
        {
            if (request == null)
                request = HttpContext.Current.Request;
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(request);

            transaction = new TransactionalInformation();
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            Case case_details = new Case();
            try
            {
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
                    case_details.is_orders_drug = case_from_db.order_id != Guid.Empty && case_from_db.order_status_code != 6;
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
                    case_details.is_documentation_only = case_from_db.is_documentation_only;
                    case_details.oct_doctor_id = case_from_db.oct_doctor_id;
                    case_details.oct_doctor_display_name = case_from_db.oct_doctor_display_name;
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

        public string GetFS6CommentForDoctor(Guid case_id, Guid planned_action_id, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {

            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            transaction = new TransactionalInformation();
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            string response = "";

            try
            {
                var gpmid = cls_Get_PlannedActionType_GlobalPropertyMatchingID_for_PlannedActionID.Invoke(connectionString, new P_CAS_GPAGPMIDfPAID_1652() { PlannedActionID = planned_action_id }, securityTicket).Result;
                if (gpmid != null)
                {
                    var response_from_hip = cls_Get_Response_from_HIP_and_Comment_for_Doctor_for_CaseID.Invoke(connectionString, new P_CAS_GRfHIPaCfDfCID_1537() { CaseID = case_id, StatusKey = gpmid.GlobalPropertyMatchingID.Replace("mm.docconect.doc.app.planned.action.", ""), StatusCode = 6 }, securityTicket).Result;
                    response = response_from_hip != null ? response_from_hip.response_from_hip.Trim() : "";
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
        public settlementMultiResult MultiEditSaveCase(MultiEditSettlement itemsForEdit, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            settlementMultiResult result_of_multiedit_settlement = new settlementMultiResult();

            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            transaction = new TransactionalInformation();
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            try
            {
                List<Guid> Ids_eligible = new List<Guid>();
                List<Settlement_Model> settlements = new List<Settlement_Model>();
                int itemsForChange = itemsForEdit.items_for_multiedit.Count();
                int itemsChanged;

                foreach (var id in itemsForEdit.items_for_multiedit)
                {
                    if (itemsForEdit.status == 8)
                    {
                        Settlement_Model settlementEdit = Get_Settlement.GetSettlementForID(id.ToString(), securityTicket);

                        if (settlementEdit != null)
                            if (settlementEdit.status == "FS4" || settlementEdit.status == "FS12")
                            {
                                Ids_eligible.Add(id);
                            }
                    }
                    else if (itemsForEdit.status == 9)
                    {
                        Settlement_Model settlementEdit = Get_Settlement.GetSettlementForID(id.ToString(), securityTicket);
                        if (settlementEdit != null)
                            if (settlementEdit.status == "FS7")
                            {
                                Ids_eligible.Add(id);
                            }
                    }
                }
                itemsChanged = Ids_eligible.Count();
                result_of_multiedit_settlement.ids_to_change_list = Ids_eligible;
                result_of_multiedit_settlement.ids_changed = Convert.ToInt32(itemsChanged);
                result_of_multiedit_settlement.ids_to_change = Convert.ToInt32(itemsForChange);
                result_of_multiedit_settlement.status = Convert.ToInt32(itemsForEdit.status);
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

            return result_of_multiedit_settlement;
        }

        public string DownloadAllNonDowloadedReports(string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            transaction = new TransactionalInformation();
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            try
            {
                string doctorId = null;
                if (!data.AccountInformation.role.Contains("practice"))
                {
                    doctorId = data.DoctorID.ToString();
                }

                var settlements = Get_Settlement.GetAllSettlementsWithNonDownloadedSubmissionReport(data.PracticeID, securityTicket.TenantID.ToString(), doctorId).ToList();
                if (settlements.Any())
                {
                    var host = HttpContext.Current.Request.UserHostAddress;
                    var logoUrl = HttpContext.Current.Server.MapPath("~/Content/images/medioslogo.jpg");
                    var reportContentPath = HttpContext.Current.Server.MapPath("~/ReportContent/SubmissionReportContent.xml");
                    var docOnlyReportContentPath = HttpContext.Current.Server.MapPath("~/ReportContent/DocumentationOnlySubmissionReportContent.xml");

                    var reportParameter = new P_CAS_CPRfSC_1813()
                    {
                        CaseData = settlements.Select(t => new P_CAS_CPRfSC_1813a()
                        {
                            ActionID = Guid.Parse(t.id),
                            CaseID = Guid.Parse(t.case_id),
                            CaseType = t.case_type
                        }).ToArray(),
                        UploadedFrom = host,
                        LogoImageUrl = logoUrl,
                        ReportContentPath = reportContentPath,
                        DocumentationOnlyReportContentPath = docOnlyReportContentPath
                    };

                    var response = cls_Create_Pdf_Report_for_Submitted_Case.Invoke(connectionString, reportParameter, securityTicket).Result.PdfUploaded;

                    var patientDetailsList = new List<PatientDetailViewModel>();
                    foreach (var sett in settlements)
                    {
                        sett.is_report_downloaded = true;

                        var patientDetails = Retrieve_Patients.Get_PatientDetaiForID(sett.id, securityTicket);
                        if (patientDetails != null)
                        {
                            patientDetails.if_settlement_is_report_downloaded = true;
                            patientDetailsList.Add(patientDetails);
                        }
                    }

                    if (settlements.Any())
                    {
                        Add_new_Settlement.Import_Settlement_to_ElasticDB(settlements.ToList(), securityTicket.TenantID.ToString());
                    }

                    if (patientDetailsList.Any())
                    {
                        Add_New_Patient.ImportPatientDetailsToElastic(patientDetailsList, securityTicket.TenantID.ToString());
                    }

                    return response;
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

        public bool IsDownloadAllNonDownloadedReportsVisible(string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            transaction = new TransactionalInformation();
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            try
            {
                var shouldDownloadReportProperty = cls_Get_Practice_PropertyValue_for_PropertyName_and_PracticeID.Invoke(connectionString, new P_DO_GPPVfPNaPID_0916() { PracticeID = data.PracticeID, PropertyName = "Download Report Upon Submission" }, securityTicket).Result;
                if (shouldDownloadReportProperty != null)
                {
                    return !shouldDownloadReportProperty.BooleanValue;
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
        public void CancelCase(Guid case_id, Guid planned_action_id, String reasonForCancelation, Guid authorizing_doctor_id, string caseType, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            transaction = new TransactionalInformation();
            try
            {
                using (var dbConnection = DBSQLSupport.CreateConnection(connectionString))
                {
                    dbConnection.Open();
                    var dbTransaction = dbConnection.BeginTransaction();
                    var parameter = new P_CAS_CCFSP_1751() { case_id = case_id, doctor = authorizing_doctor_id, reasonForCancelation = reasonForCancelation, caseType = caseType, planned_action_id = planned_action_id };
                    var patient_id = cls_Cancel_Case_From_Settlement_Page.Invoke(dbConnection, dbTransaction, parameter, securityTicket).Result;

                    var elasticRefresher = new ElasticRefresher(new Guid[] { patient_id }, dbConnection, dbTransaction, securityTicket, true);
                    elasticRefresher
                        .UpdateIvoms()
                        .UpdateOct()
                        .UpdateAftercare()
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
        }

        public String SubmitCase(DateTime date_of_performed_action, bool is_treatment, Guid case_id, Guid planned_action_id, Guid authorizing_doctor_id, string connectionString, string sessionTicket, out TransactionalInformation transaction, DbConnection dbConnection = null, DbTransaction dbTransaction = null)
        {
            var handle_connection = dbConnection == null;

            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            var report_url = "";
            transaction = new TransactionalInformation();

            try
            {
                if (handle_connection)
                {
                    dbConnection = DBSQLSupport.CreateConnection(connectionString);
                    dbConnection.Open();
                }

                if (handle_connection)
                {
                    dbTransaction = dbConnection.BeginTransaction();
                }

                try
                {
                    var current_fs_statuses = cls_Get_Case_TransmitionCode_for_CaseID.Invoke(connectionString, new P_CAS_GCTCfCID_1427() { CaseID = case_id }, securityTicket).Result;
                    if (current_fs_statuses.Length == 0)
                        return null;

                    var parameter = new P_CAS_SC_1425()
                    {
                        case_ids = new Guid[] { case_id },
                        is_treatment = is_treatment,
                        practice_id = data.PracticeID,
                        authorizing_doctor_id = authorizing_doctor_id,
                        is_settlement = true,
                        date_of_performed_action = date_of_performed_action,
                        planned_action_id = planned_action_id
                    };

                    var result = cls_Submit_Case.Invoke(dbConnection, dbTransaction, parameter, securityTicket).Result;

                    if (result != null)
                    {
                        if (!String.IsNullOrEmpty(result.pdf_report_url))
                        {
                            report_url = result.pdf_report_url;
                        }

                        var elasticRefresher = new ElasticRefresher(result.patient_ids, dbConnection, dbTransaction, securityTicket, true);
                        elasticRefresher
                            .UpdateAftercare()
                            .UpdateOct()
                            .UpdateIvoms()
                            .RebuildElastic();
                    }

                    Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, parameter), data.PracticeName);

                    if (handle_connection)
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

        public Guid EditAftercareInErrorCorrectionState(ErrorCorrectionAftercare aftercare, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var request = HttpContext.Current.Request;
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(request);

            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            transaction = new TransactionalInformation();

            try
            {
                using (var dbConnection = DBSQLSupport.CreateConnection(connectionString))
                {
                    dbConnection.Open();
                    var dbTransaction = dbConnection.BeginTransaction();
                    var culture = new System.Globalization.CultureInfo("de", true);

                    var performed_on_date = DateTime.Parse(aftercare.surgery_date_string, culture, System.Globalization.DateTimeStyles.AssumeLocal);
                    var doctor = cls_Get_Doctor_BasicInformation_for_DoctorID.Invoke(dbConnection, dbTransaction, new P_DO_GDBIfDID_1034() { DoctorID = aftercare.aftercare_doctor_practice_id }, securityTicket).Result;

                    var aftercare_planned_action = new ORM_HEC_ACT_PlannedAction();
                    aftercare_planned_action.Load(dbConnection, dbTransaction, aftercare.id);
                    aftercare_planned_action.PlannedFor_Date = performed_on_date;
                    aftercare_planned_action.ToBePerformedBy_BusinessParticipant_RefID = doctor.bpt_id;

                    aftercare_planned_action.Save(dbConnection, dbTransaction);

                    var aftercare_performed_action = new ORM_HEC_ACT_PerformedAction();
                    aftercare_performed_action.Load(dbConnection, dbTransaction, aftercare_planned_action.IfPerformed_PerformedAction_RefID);

                    aftercare_performed_action.IfPerfomed_DateOfAction = performed_on_date;
                    aftercare_performed_action.IfPerformed_DateOfAction_Day = performed_on_date.Day;
                    aftercare_performed_action.IfPerformed_DateOfAction_Month = performed_on_date.Month;
                    aftercare_performed_action.IfPerformed_DateOfAction_Year = performed_on_date.Year;

                    aftercare_performed_action.Save(dbConnection, dbTransaction);

                    var elasticRefresher = new ElasticRefresher(new Guid[] { aftercare_planned_action.Patient_RefID }, dbConnection, dbTransaction, securityTicket, true);
                    elasticRefresher
                        .UpdateIvoms()
                        .RebuildElastic();

                    dbTransaction.Commit();

                    Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, aftercare, aftercare_planned_action), data.PracticeName);
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

            return aftercare.id;
        }


        public Guid CreateCase(Case new_case, string connectionString, string sessionTicket, out TransactionalInformation transaction, DbConnection dbConnection = null, DbTransaction dbTransaction = null)
        {
            var handle_connection = dbConnection == null;
            var handle_transaction = dbTransaction == null;

            var request = HttpContext.Current.Request;
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(request);

            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            transaction = new TransactionalInformation();

            Guid new_case_id = Guid.Empty;

            try
            {
                if (handle_connection)
                {
                    dbConnection = DBSQLSupport.CreateConnection(connectionString);
                }


                try
                {
                    IFormatProvider culture = new System.Globalization.CultureInfo("de", true);

                    #region PARAMETER
                    P_CAS_SC_1711 parameter = new P_CAS_SC_1711();
                    parameter.aftercare_doctor_practice_id = new_case.aftercare_doctor_practice_id;
                    parameter.delivery_date = DateTime.Parse(new_case.treatment_date, culture, System.Globalization.DateTimeStyles.AssumeLocal);
                    if (!String.IsNullOrEmpty(new_case.min_delivery_date))
                    {
                        parameter.min_delivery_date = DateTime.Parse(new_case.min_delivery_date, culture, System.Globalization.DateTimeStyles.AssumeLocal);
                    }
                    parameter.alternative_delivery_date_from = DateTime.Parse(new_case.treatment_date, culture, System.Globalization.DateTimeStyles.AssumeLocal);
                    parameter.alternative_delivery_date_to = DateTime.Parse(new_case.treatment_date, culture, System.Globalization.DateTimeStyles.AssumeLocal);
                    parameter.case_id = new_case.case_id;
                    parameter.diagnose_id = new_case.diagnose_id;
                    parameter.drug_id = new_case.drug_id;
                    parameter.is_confirmed = new_case.is_confirmed;
                    parameter.is_label_only = new_case.is_label_only;
                    parameter.is_left_eye = new_case.is_left_eye;
                    parameter.is_orders_drug = new_case.is_orders_drug;
                    parameter.is_patient_fee_waived = new_case.is_patient_fee_waived;
                    parameter.is_send_invoice_to_practice = new_case.is_send_invoice_to_practice;
                    parameter.patient_id = new_case.patient_id;
                    parameter.practice_id = data.PracticeID;
                    parameter.treatment_date = DateTime.Parse(new_case.treatment_date, culture, System.Globalization.DateTimeStyles.AssumeLocal);
                    parameter.treatment_doctor_id = new_case.treatment_doctor_id;
                    parameter.planned_action_id = new_case.planned_action_id;
                    if (new_case.aftercare_performed_date != null)
                        parameter.aftercare_performed_date = DateTime.Parse(new_case.aftercare_performed_date, culture, System.Globalization.DateTimeStyles.AssumeLocal);
                    #endregion

                    Case previous_state = null;

                    Thread detailsThread = new Thread(() => GetCasePreviousDetails(out previous_state, new_case.case_id, connectionString, sessionTicket, request));
                    detailsThread.Start();

                    new_case_id = cls_Save_Case.Invoke(dbConnection, dbTransaction, parameter, securityTicket).Result;

                    var elasticRefresher = new ElasticRefresher(new Guid[] { new_case.patient_id }, dbConnection, dbTransaction, securityTicket, true);
                    elasticRefresher
                        .UpdateAftercare()
                        .UpdateIvoms()
                        .UpdateOct()
                        .RebuildElastic();

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
        public settlementMultiResult ConfirmMultiEditSaveCase(MultiEditSettlement itemsForEdit, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            settlementMultiResult result_of_multiedit_settlement = new settlementMultiResult();

            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            transaction = new TransactionalInformation();

            try
            {
                P_CAS_SCCS_1520 parameter = new P_CAS_SCCS_1520();
                parameter.ids_to_change = itemsForEdit.items_for_multiedit;
                parameter.status_to = itemsForEdit.status;
                var itemsChanged = cls_Settlement_Change_Case_Status.Invoke(connectionString, parameter, securityTicket).Result;

                result_of_multiedit_settlement.ids_changed = Convert.ToInt32(itemsChanged.number_of_ids_changed);
                result_of_multiedit_settlement.ids_to_change = Convert.ToInt32(itemsChanged.number_of_ids_to_change);
                result_of_multiedit_settlement.status = Convert.ToInt32(itemsChanged.status_to);

                Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, itemsForEdit), data.PracticeName);
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

            return result_of_multiedit_settlement;
        }
        #endregion

        #region UTIL
        private static void GetCasePreviousDetails(out Case previous_state, Guid id, string connectionString, string sessionTicket, HttpRequest request)
        {
            var transaction = new TransactionalInformation();
            var dd = new SettlementDataService();

            previous_state = dd.GetCaseDetailsforCaseID(id, connectionString, sessionTicket, out transaction, request);
        }
        #endregion
    }
}
