using BOp.Exceptions;
using BOp.Providers;
using BOp.Providers.TMS;
using BOp.Providers.TMS.Requests;
using CL1_BIL;
using CL1_HEC_CAS;
using CL1_USR;
using CSV2Core_MySQL.Support;
using DLCore_TokenVerification;
using LogUtils;
using MMDocConnectDBMethods.Case.Atomic.Manipulation;
using MMDocConnectDBMethods.Case.Atomic.Retrieval;
using MMDocConnectDBMethods.Case.Complex.Retrieval;
using MMDocConnectDBMethods.Order.Complex.Manipulation;
using MMDocConnectElasticSearchMethods.Case.Retrieval;
using MMDocConnectElasticSearchMethods.Models;
using MMDocConnectElasticSearchMethods.Order.Retrieval;
using MMDocConnectMMApp.Models;
using MMDocConnectMMAppInterfaces;
using MMDocConnectMMAppModels;
using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;

namespace MMDocConnectMMAppServices
{
    public class TreatmentDataService : BaseVerification, ITreatmentDataService
    {
        #region RETRIEVAL
        public List<Submitted_Case_Model> GetSubmittedCasesList(ElasticParameterObject sort_parameter, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            transaction = new TransactionalInformation();
            List<Submitted_Case_Model> SubmittedCasesList = new List<Submitted_Case_Model>();
            var securityTicket = VerifySessionToken(sessionTicket);

            try
            {
                SubmittedCasesList = Get_Submitted_Cases.GetAllCases(sort_parameter, securityTicket);
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

            return SubmittedCasesList;
        }
        public string GetResponseFromHIP(Guid case_id, Guid planned_action_id, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            transaction = new TransactionalInformation();
            string response = "";
            var securityTicket = VerifySessionToken(sessionTicket);

            try
            {
                using (var dbConnection = DBSQLSupport.CreateConnection(connectionString))
                {
                    dbConnection.Open();
                    var dbTransaction = dbConnection.BeginTransaction();

                    var action_gpmid = cls_Get_PlannedActionType_GlobalPropertyMatchingID_for_PlannedActionID.Invoke(dbConnection, dbTransaction, new P_CAS_GPAGPMIDfPAID_1652() { PlannedActionID = planned_action_id }, securityTicket).Result.GlobalPropertyMatchingID;
                    if (action_gpmid == EActionType.PlannedOct.Value())
                    {
                        var relevant_action = ORM_HEC_CAS_Case_RelevantPlannedAction.Query.Search(dbConnection, dbTransaction, new ORM_HEC_CAS_Case_RelevantPlannedAction.Query()
                        {
                            PlannedAction_RefID = planned_action_id,
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false
                        }).Single();

                        if (relevant_action.Case_RefID != case_id)
                        {
                            case_id = relevant_action.Case_RefID;
                        }

                        var relevant_case = new ORM_HEC_CAS_Case();
                        relevant_case.Load(dbConnection, dbTransaction, case_id);

                        var oct_planned_action_type_id = cls_Get_ActionTypeID.Invoke(dbConnection, dbTransaction, new P_CAS_GATID_1514() { action_type_gpmid = EActionType.PlannedOct.Value() }, securityTicket).Result;

                        var case_relevant_actions = cls_Get_PlannedActionIDs_for_PatientID_and_ActionTypeID.Invoke(dbConnection, dbTransaction, new P_CAS_GPAIDsfPIDaATID_1705()
                        {
                            ActionTypeID = oct_planned_action_type_id,
                            PatientID = relevant_case.Patient_RefID
                        }, securityTicket).Result.Where(t => t.performed).ToList();

                        var case_bill_positions = cls_Get_BillPositionIDs_for_PatientID_and_GposType.Invoke(dbConnection, dbTransaction, new P_CAS_GBPIDsfPIDaGposT_1709()
                        {
                            PatientID = relevant_case.Patient_RefID,
                            GposType = EGposType.Oct.Value()
                        }, securityTicket).Result.Where(t => t.status_id != Guid.Empty).ToList();

                        var bill_position_id = Guid.Empty;
                        for (var i = 0; i < case_relevant_actions.Count; i++)
                        {
                            if (case_relevant_actions[i].action_id == planned_action_id)
                            {
                                bill_position_id = case_bill_positions[i].bill_position_id;
                                break;
                            }
                        }

                        if (bill_position_id == Guid.Empty)
                        {
                            throw new ArgumentException(String.Format("No bill position found for case: {0} and planned action id: {1}", case_id, planned_action_id));
                        }

                        var transmition_status = ORM_BIL_BillPosition_TransmitionStatus.Query.Search(dbConnection, dbTransaction, new ORM_BIL_BillPosition_TransmitionStatus.Query()
                        {
                            BillPosition_RefID = bill_position_id,
                            IsActive = true,
                            TransmitionCode = 5,
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false
                        }).Single();

                        response = transmition_status.PrimaryComment;
                    }
                    else
                    {
                        var response_from_hip = cls_Get_Response_from_HIP_and_Comment_for_Doctor_for_CaseID.Invoke(connectionString, new P_CAS_GRfHIPaCfDfCID_1537()
                        {
                            CaseID = case_id,
                            StatusKey = action_gpmid.Replace("mm.docconect.doc.app.planned.action.", ""),
                            StatusCode = 5
                        }, securityTicket).Result;

                        response = response_from_hip != null ? response_from_hip.response_from_hip : "";
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

            return response;
        }
        public Guid[] GetEligibleCases(bool all_selected, Guid[] selected_action_ids, Guid[] deselected_action_ids, FilterObject filter, CaseStatus? case_status, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            transaction = new TransactionalInformation();
            var securityTicket = VerifySessionToken(sessionTicket);
            Submitted_Case_Model[] selected_cases = new Submitted_Case_Model[] { };

            try
            {
                if (all_selected || deselected_action_ids.Length != 0)
                {
                    ElasticParameterObject filter_by = new ElasticParameterObject();
                    filter_by.date_from = filter.date_from;
                    filter_by.date_to = filter.date_to;
                    filter_by.filter_by.filter_status = filter.filter_by.filter_status;
                    filter_by.filter_by.filter_type = filter.filter_by.filter_type;
                    filter_by.search_params = filter.search_params;

                    selected_cases = Get_Submitted_Cases.GetSubmittedCasesFilteredIDs(filter_by, case_status.HasValue ? case_status.Value.ToString().ToLower() : null, securityTicket);
                }
                else
                {
                    selected_cases = Get_Submitted_Cases.GetSubmittedCaseforIDArray(Array.ConvertAll(selected_action_ids, x => x.ToString()), case_status.HasValue ? case_status.Value.ToString().ToLower() : null, securityTicket);
                }

                selected_action_ids = selected_cases.Select(ac =>
                {
                    if (ac.status == "FS13")
                    {
                        return Guid.Empty;
                    }

                    if (ac.type == "op")
                    {
                        return Guid.Parse(ac.id);
                    }
                    else
                    {
                        var acs = selected_cases.Where(selAc => selAc.type == "ac" && selAc.status == "FS8").GroupBy(selAc => selAc.case_id, selAc => selAc.id, (key, value) => new { CaseID = key, AcIDs = value.ToList() });
                        var data = acs.Where(t => t.CaseID == ac.case_id);
                        if (data.Count() != 0 && data.Single().AcIDs.Count > 1)
                        {
                            return Guid.Empty;
                        }
                        else
                        {
                            if (ac.status != "FS8")
                            {
                                return Guid.Parse(ac.id);
                            }
                            else if (cls_Get_is_Aftercares_Status_Editable_for_CaseID.Invoke(connectionString, new P_CAS_GiASEfCID_1127() { CaseID = Guid.Parse(ac.case_id) }, securityTicket).Result.IsEditable)
                            {
                                return Guid.Parse(ac.id);
                            }
                        }
                    }

                    return Guid.Empty;
                }).Where(id => id != Guid.Empty).ToArray();

                if (deselected_action_ids.Length != 0)
                    selected_action_ids = selected_action_ids.Except(deselected_action_ids).ToArray();
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

            return selected_action_ids;
        }
        public long GetSubmittedCasesCount(ElasticParameterObject parameter, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            transaction = new TransactionalInformation();
            long response = 0;
            var securityTicket = VerifySessionToken(sessionTicket);

            try
            {
                response = Get_Submitted_Cases.GetSubmittedCasesCount(parameter, securityTicket);
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

            return response;
        }
        #endregion

        #region MANIPULATION
        public Guid[] SubmitCaseForErrorCorrection(Guid case_id, Guid planned_action_id, string comment, string action_type, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            transaction = new TransactionalInformation();
            Guid[] response = new Guid[] { };
            var securityTicket = VerifySessionToken(sessionTicket);

            try
            {
                var parameter = new P_CAS_SCfEC_1641() { case_id = case_id, comment = comment, action_type = action_type, planned_action_id = planned_action_id };
                response = cls_Submit_Case_for_Error_Correction.Invoke(connectionString, parameter, securityTicket).Result;

                Logger.LogInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, parameter));
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

            return response;
        }

        public Guid[] ChangeCaseStatus(bool all_selected, Guid[] selected_action_ids, Guid[] deselected_action_ids, FilterObject filter, Guid[] case_ids, bool? is_management_fee_waived, CaseStatus? case_status, string case_status_ground, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            transaction = new TransactionalInformation();
            var securityTicket = VerifySessionToken(sessionTicket);

            try
            {
                if (case_status.HasValue)
                {
                    var parameter = new P_CAS_CPASfPAID_1654() { change_status = case_status.HasValue, planned_action_ids = case_ids, new_status = (int)case_status.Value, new_status_ground = case_status_ground };
                    cls_Change_PerformedAction_Status_for_PlannedActionID.Invoke(connectionString, parameter, securityTicket);

                    Logger.LogInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, parameter));
                }

                if (is_management_fee_waived.HasValue)
                {
                    if (all_selected || deselected_action_ids.Length != 0)
                    {
                        ElasticParameterObject filter_by = new ElasticParameterObject();
                        filter_by.date_from = filter.date_from;
                        filter_by.date_to = filter.date_to;
                        filter_by.filter_by.filter_status = filter.filter_by.filter_status;
                        filter_by.filter_by.filter_type = filter.filter_by.filter_type;
                        filter_by.search_params = filter.search_params;

                        var ids = Get_Submitted_Cases.GetSubmittedCasesFilteredIDs(filter_by, null, securityTicket).Select(cas => Guid.Parse(cas.id));
                        selected_action_ids = ids.Except(deselected_action_ids).ToArray();
                    }
                    var parameter = new P_CAS_CMFSfPAID_1502() { is_management_fee_waived = is_management_fee_waived.Value, planned_action_ids = selected_action_ids };
                    cls_Change_ManagementFee_Status_for_PlannedActionID.Invoke(connectionString, parameter, securityTicket);

                    Logger.LogInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, parameter));
                }
            }
            catch (Exception ex)
            {
                Logger.LogInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, ex));

                transaction.ReturnMessage = new List<string>();
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(ex.Message);
                if (ex.InnerException != null)
                {
                    transaction.ReturnMessage.Add(ex.InnerException.Message);
                    transaction.ReturnMessage.Add(ex.InnerException.StackTrace);

                    if (ex.InnerException.InnerException != null)
                    {
                        transaction.ReturnMessage.Add(ex.InnerException.InnerException.Message);
                    }
                }
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }

            return case_ids;
        }
        #endregion



    }
}