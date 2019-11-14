/* 
 * Generated on 08/17/15 15:02:55
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
using CL1_HEC_CAS;
using CL1_HEC_ACT;
using MMDocConnectElasticSearchMethods.Models;
using MMDocConnectElasticSearchMethods.Case.Retrieval;
using MMDocConnectElasticSearchMethods.Case.Manipulation;
using MMDocConnectUtils;
using MMDocConnectDBMethods.Case.Complex.Retrieval;
using CL1_HEC_BIL;

namespace MMDocConnectDBMethods.Case.Atomic.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Change_ManagementFee_Status_for_PlannedActionID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Change_ManagementFee_Status_for_PlannedActionID
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Guids Execute(DbConnection Connection, DbTransaction Transaction, P_CAS_CMFSfPAID_1502 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            //Leave UserCode region to enable user code saving
            #region UserCode
            var returnValue = new FR_Guids();
            List<Submitted_Case_Model> submitted_cases = new List<Submitted_Case_Model>();

            // todo: update to support OCT
            foreach (var planned_action_id in Parameter.planned_action_ids)
            {
                var action_gpmid = cls_Get_PlannedActionType_GlobalPropertyMatchingID_for_PlannedActionID.Invoke(Connection, Transaction, new P_CAS_GPAGPMIDfPAID_1652() { PlannedActionID = planned_action_id }, securityTicket).Result.GlobalPropertyMatchingID;
                var is_treatment = action_gpmid == EActionType.PlannedOperation.Value();
                var case_id = Guid.Empty;
                if (is_treatment)
                {
                    ORM_HEC_ACT_PlannedAction.Query planned_actionQ = new ORM_HEC_ACT_PlannedAction.Query();
                    planned_actionQ.HEC_ACT_PlannedActionID = planned_action_id;
                    planned_actionQ.Tenant_RefID = securityTicket.TenantID;
                    planned_actionQ.IsDeleted = false;
                    var planned_action = ORM_HEC_ACT_PlannedAction.Query.Search(Connection, Transaction, planned_actionQ).SingleOrDefault();
                    if (planned_action != null)
                    {
                        ORM_HEC_CAS_Case_RelevantPerformedAction.Query relevant_performed_actionQ = new ORM_HEC_CAS_Case_RelevantPerformedAction.Query();
                        relevant_performed_actionQ.PerformedAction_RefID = planned_action.IfPlannedFollowup_PreviousAction_RefID;
                        relevant_performed_actionQ.Tenant_RefID = securityTicket.TenantID;
                        relevant_performed_actionQ.IsDeleted = false;

                        var relevant_performed_action = ORM_HEC_CAS_Case_RelevantPerformedAction.Query.Search(Connection, Transaction, relevant_performed_actionQ).SingleOrDefault();
                        if (relevant_performed_action != null)
                        {
                            case_id = relevant_performed_action.Case_RefID;
                        }
                    }
                }
                else
                {
                    ORM_HEC_CAS_Case_RelevantPlannedAction.Query relevant_planned_actionQ = new ORM_HEC_CAS_Case_RelevantPlannedAction.Query();
                    relevant_planned_actionQ.PlannedAction_RefID = planned_action_id;
                    relevant_planned_actionQ.Tenant_RefID = securityTicket.TenantID;
                    relevant_planned_actionQ.IsDeleted = false;
                    var relevant_planned_action = ORM_HEC_CAS_Case_RelevantPlannedAction.Query.Search(Connection, Transaction, relevant_planned_actionQ).SingleOrDefault();
                    if (relevant_planned_action != null)
                    {
                        case_id = relevant_planned_action.Case_RefID;
                    }
                }

                var gpos_type = EGposType.Aftercare.Value();
                if (action_gpmid == EActionType.PlannedOperation.Value())
                {
                    gpos_type = EGposType.Operation.Value();
                }
                else if (action_gpmid == EActionType.PlannedOct.Value())
                {
                    gpos_type = EGposType.Oct.Value();
                }

                var all_bill_positions = cls_Get_BillPositionIDs_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GBPIDsfCID_0928() { CaseID = case_id }, securityTicket).Result;
                if (all_bill_positions.Any())
                {
                    List<CAS_GBPIDsfCID_0928> bill_positions_to_update = new List<CAS_GBPIDsfCID_0928>();
                    if (action_gpmid == EActionType.PlannedOperation.Value())
                    {
                        bill_positions_to_update = all_bill_positions.Where(t => t.gpos_type == gpos_type).ToList();
                    }
                    else if (action_gpmid == EActionType.PlannedOct.Value())
                    {
                        var oct_planned_action_type_id = cls_Get_ActionTypeID.Invoke(Connection, Transaction, new P_CAS_GATID_1514() { action_type_gpmid = EActionType.PlannedOct.Value() }, securityTicket).Result;
                        var relevant_octs = cls_Get_RelevanActionIDs_for_CaseID_and_ActionTypeID.Invoke(Connection, Transaction, new P_CAS_GRAIDsfCIDaATID_1547()
                        {
                            CaseID = case_id,
                            ActionTypeID = oct_planned_action_type_id
                        }, securityTicket).Result;

                        var index = -1;
                        for (int i = 0; i < relevant_octs.Length; i++)
                        {
                            if (relevant_octs[i].action_id == planned_action_id)
                            {
                                index = i;
                                break;
                            }
                        }

                        var bill_positions = all_bill_positions.Where(t => t.gpos_type == EGposType.Oct.Value()).ToList();
                        var bill_position = bill_positions.Any() ? bill_positions[index] : bill_positions.First();
                        bill_positions_to_update.Add(bill_position);
                    }
                    else
                    {
                        var aftercare_planned_action_type_id = cls_Get_ActionTypeID.Invoke(Connection, Transaction, new P_CAS_GATID_1514() { action_type_gpmid = EActionType.PlannedAftercare.Value() }, securityTicket).Result;
                        var relevant_aftercares = cls_Get_RelevanActionIDs_for_CaseID_and_ActionTypeID.Invoke(Connection, Transaction, new P_CAS_GRAIDsfCIDaATID_1547()
                        {
                            CaseID = case_id,
                            ActionTypeID = aftercare_planned_action_type_id
                        }, securityTicket).Result;

                        var index = -1;
                        for (int i = 0; i < relevant_aftercares.Length; i++)
                        {
                            if (relevant_aftercares[i].action_id == planned_action_id)
                            {
                                index = i;
                                break;
                            }
                        }

                        var bill_positions = all_bill_positions.Where(t => t.gpos_type == EGposType.Aftercare.Value()).ToList();
                        var bill_position = bill_positions.Any() ? bill_positions[index] : bill_positions.First();
                        bill_positions_to_update.Add(bill_position);
                        
                        foreach (var other_bill_position in bill_positions)
                        {
                            var update_bill_position_status = false;

                            var any_covered_diagnoses = ORM_HEC_BIL_PotentialCode_2_PotentialDiagnosis.Query.Search(Connection, Transaction, new ORM_HEC_BIL_PotentialCode_2_PotentialDiagnosis.Query()
                            {
                                HEC_BIL_PotentialCode_RefID = other_bill_position.gpos_id,
                                Tenant_RefID = securityTicket.TenantID,
                                IsDeleted = false
                            }).Any();

                            if (any_covered_diagnoses)
                            {
                                update_bill_position_status = ORM_HEC_BIL_PotentialCode_2_HealthcareProduct.Query.Search(Connection, Transaction, new ORM_HEC_BIL_PotentialCode_2_HealthcareProduct.Query()
                                {
                                    HEC_BIL_PotentialCode_RefID = other_bill_position.gpos_id,
                                    Tenant_RefID = securityTicket.TenantID,
                                    IsDeleted = false
                                }).Any();
                            }
                            else
                            {
                                update_bill_position_status = true;
                            }

                            if (update_bill_position_status)
                            {
                                bill_positions_to_update.Add(other_bill_position);
                            }
                        }
                    }

                    foreach (var case_bill_position in bill_positions_to_update)
                    {
                        var gpos_management_fee_property_value = ORM_BIL_BillPosition_PropertyValue.Query.Search(Connection, Transaction, new ORM_BIL_BillPosition_PropertyValue.Query()
                        {
                            BIL_BillPosition_RefID = case_bill_position.bill_position_id,
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false,
                            PropertyKey = "mm.doc.connect.management.fee"
                        }).SingleOrDefault();

                        if (gpos_management_fee_property_value == null)
                        {
                            gpos_management_fee_property_value = new ORM_BIL_BillPosition_PropertyValue();
                            gpos_management_fee_property_value.BIL_BillPosition_RefID = case_bill_position.bill_position_id;
                            gpos_management_fee_property_value.PropertyKey = "mm.doc.connect.management.fee";
                            gpos_management_fee_property_value.Tenant_RefID = securityTicket.TenantID;
                        }

                        gpos_management_fee_property_value.PropertyValue = Parameter.is_management_fee_waived ? "waived" : "deducted";
                        gpos_management_fee_property_value.Modification_Timestamp = DateTime.Now;

                        gpos_management_fee_property_value.Save(Connection, Transaction);
                    }
                }

                var submitted_case = Get_Submitted_Cases.GetSubmittedCaseforSubmittedCaseID(planned_action_id.ToString(), securityTicket);
                submitted_case.management_pauschale = Parameter.is_management_fee_waived ? "waived" : "deducted";

                submitted_cases.Add(submitted_case);
            }

            Add_New_Submitted_Case.Import_Submitted_Case_Data_to_ElasticDB(submitted_cases, securityTicket.TenantID.ToString());

            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_Guids Invoke(string ConnectionString, P_CAS_CMFSfPAID_1502 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Guids Invoke(DbConnection Connection, P_CAS_CMFSfPAID_1502 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Guids Invoke(DbConnection Connection, DbTransaction Transaction, P_CAS_CMFSfPAID_1502 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Guids Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_CAS_CMFSfPAID_1502 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_Guids functionReturn = new FR_Guids();
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

                throw new Exception("Exception occured in method cls_Change_ManagementFee_Status_for_PlannedActionID", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes
    #region SClass P_CAS_CMFSfPAID_1502 for attribute P_CAS_CMFSfPAID_1502
    [DataContract]
    public class P_CAS_CMFSfPAID_1502
    {
        //Standard type parameters
        [DataMember]
        public Guid[] planned_action_ids { get; set; }
        [DataMember]
        public Boolean is_management_fee_waived { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guids cls_Change_ManagementFee_Status_for_PlannedActionID(,P_CAS_CMFSfPAID_1502 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guids invocationResult = cls_Change_ManagementFee_Status_for_PlannedActionID.Invoke(connectionString,P_CAS_CMFSfPAID_1502 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Case.Atomic.Manipulation.P_CAS_CMFSfPAID_1502();
parameter.planned_action_ids = ...;
parameter.is_management_fee_waived = ...;

*/
