/* 
 * Generated on 06/12/15 16:43:16
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
using MMDocConnectElasticSearchMethods.Case.Manipulation;
using MMDocConnectElasticSearchMethods.Models;
using CL1_ORD_PRC;
using MMDocConnectDBMethods.Doctor.Atomic.Retrieval;
using MMDocConnectDBMethods.Patient.Atomic.Retrieval;
using CL1_CMN;
using CL1_USR;
using CL1_HEC_ACT;
using CL1_HEC_CAS;
using MMDocConnectElasticSearchMethods.Case.Retrieval;
using MMDocConnectElasticSearchMethods.Order.Retrieval;
using MMDocConnectElasticSearchMethods.Patient.Manipulation;
using MMDocConnectDBMethods.Case.Complex.Retrieval;
using MMDocConnectUtils;
using System.Web;
using MMDocConnectDBMethods.MainData.Atomic.Retrieval;
using System.Web.Configuration;
using System.IO;
using Newtonsoft.Json;
using CL1_HEC_PRC;
using MMDocConnectElasticSearchMethods;

namespace MMDocConnectDBMethods.Case.Atomic.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Cancel_Case.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Cancel_Case
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Guid Execute(DbConnection Connection, DbTransaction Transaction, P_CAS_CC_1641 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            //Leave UserCode region to enable user code saving
            #region UserCode
            var returnValue = new FR_Guid();

            //Put your code here
            var case_to_cancel = cls_Get_Case_Details_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GCDfCID_1435() { CaseID = Parameter.case_id }, securityTicket).Result;
            returnValue.Result = case_to_cancel.patient_id;

            var drug_order_details = cls_Get_DrugOrderIDs_for_PlannedActionID.Invoke(Connection, Transaction, new P_CAS_GDOIDsfPAID_1243() { PlannedActionID = case_to_cancel.treatment_planned_action_id }, securityTicket).Result;

            var all_languagesQ = new ORM_CMN_Language.Query();
            all_languagesQ.Tenant_RefID = securityTicket.TenantID;
            all_languagesQ.IsDeleted = false;

            var all_languagesL = ORM_CMN_Language.Query.Search(Connection, Transaction, all_languagesQ).ToArray();

            var trigger_accQ = new ORM_USR_Account.Query();
            trigger_accQ.Tenant_RefID = securityTicket.TenantID;
            trigger_accQ.USR_AccountID = securityTicket.AccountID;
            trigger_accQ.IsDeleted = false;

            var delete_drug_order = false;
            var cancel_order = false;
            var drug_order_header_id = Guid.Empty;

            var trigger_acc = ORM_USR_Account.Query.Search(Connection, Transaction, trigger_accQ).SingleOrDefault();

            var op_planned_action_id = Guid.Empty;

            string previous_status = "";
            var planned_action = cls_Get_Treatment_Planned_Action_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GTPAfCID_0946() { CaseID = Parameter.case_id }, securityTicket).Result;

            if (planned_action != null)
            {
                op_planned_action_id = planned_action.planned_action_id;
                var drug_order_ids = cls_Get_DrugOrderIDs_for_PlannedActionID.Invoke(Connection, Transaction, new P_CAS_GDOIDsfPAID_1243() { PlannedActionID = planned_action.planned_action_id }, securityTicket).Result;
                if (drug_order_ids != null)
                {
                    var ord_drug_order_headerQ = new ORM_ORD_PRC_ProcurementOrder_Header.Query();
                    ord_drug_order_headerQ.Tenant_RefID = securityTicket.TenantID;
                    ord_drug_order_headerQ.IsDeleted = false;
                    ord_drug_order_headerQ.ORD_PRC_ProcurementOrder_HeaderID = drug_order_ids.ORD_PRC_ProcurementOrder_HeaderID;

                    var ord_drug_order_header = ORM_ORD_PRC_ProcurementOrder_Header.Query.Search(Connection, Transaction, ord_drug_order_headerQ).SingleOrDefault();

                    var existing_treatment_planned_action_required_product = ORM_HEC_ACT_PlannedAction_PotentialProcedure_RequiredProduct.Query.Search(Connection, Transaction, new ORM_HEC_ACT_PlannedAction_PotentialProcedure_RequiredProduct.Query()
                    {
                        HEC_ACT_PlannedAction_PotentialProcedure_RequiredProductID = drug_order_ids.HEC_ACT_PlannedAction_PotentialProcedure_RequiredProductID
                    }).Single();

                    if (Parameter.cancel_drug_order)
                    {
                        if (ord_drug_order_header != null)
                        {
                            drug_order_header_id = ord_drug_order_header.ORD_PRC_ProcurementOrder_HeaderID;

                            var drug_order_status_latest = ORM_ORD_PRC_ProcurementOrder_Status.Query.Search(Connection, Transaction, new ORM_ORD_PRC_ProcurementOrder_Status.Query()
                            {
                                ORD_PRC_ProcurementOrder_StatusID = ord_drug_order_header.Current_ProcurementOrderStatus_RefID,
                                Tenant_RefID = securityTicket.TenantID,
                                IsDeleted = false
                            }).Single();

                            previous_status = cls_Cancel_Drug_Order.Invoke(Connection, Transaction, new P_CAS_CDO_1250()
                            {
                                all_languagesL = all_languagesL,
                                created_by_bpt = trigger_acc.BusinessParticipant_RefID,
                                ord_drug_order_header = ord_drug_order_header,
                                procurement_order_position_id = drug_order_ids.HEC_PRC_ProcurementOrder_PositionID,
                                case_id = Parameter.case_id
                            }, securityTicket).Result.previous_status;

                            delete_drug_order = previous_status == "MO0";
                            cancel_order = !delete_drug_order && previous_status != "MO9";
                        }
                    }
                }
            }

            if (Parameter.cancel_treatment)
            {
                var treatment_planned_actionQ = new ORM_HEC_ACT_PlannedAction.Query();
                treatment_planned_actionQ.HEC_ACT_PlannedActionID = case_to_cancel.treatment_planned_action_id;
                treatment_planned_actionQ.IsDeleted = false;
                treatment_planned_actionQ.IsCancelled = false;
                treatment_planned_actionQ.IsPerformed = false;
                treatment_planned_actionQ.Tenant_RefID = securityTicket.TenantID;

                var treatment_planned_action = ORM_HEC_ACT_PlannedAction.Query.Search(Connection, Transaction, treatment_planned_actionQ).SingleOrDefault();
                if (treatment_planned_action != null)
                {
                    treatment_planned_action.IsCancelled = true;
                    treatment_planned_action.Save(Connection, Transaction);
                }

                var aftercare_planned_actionQ = new ORM_HEC_ACT_PlannedAction.Query();
                aftercare_planned_actionQ.HEC_ACT_PlannedActionID = case_to_cancel.aftercare_planned_action_id;
                aftercare_planned_actionQ.IsDeleted = false;
                aftercare_planned_actionQ.IsCancelled = false;
                aftercare_planned_actionQ.IsPerformed = false;
                aftercare_planned_actionQ.Tenant_RefID = securityTicket.TenantID;

                var aftercare_planned_action = ORM_HEC_ACT_PlannedAction.Query.Search(Connection, Transaction, treatment_planned_actionQ).SingleOrDefault();
                if (aftercare_planned_action != null)
                {
                    aftercare_planned_action.IsCancelled = true;
                    aftercare_planned_action.Save(Connection, Transaction);
                }

                var cancelled_caseQ = new ORM_HEC_CAS_Case.Query();
                cancelled_caseQ.HEC_CAS_CaseID = Parameter.case_id;
                cancelled_caseQ.Tenant_RefID = securityTicket.TenantID;
                cancelled_caseQ.IsDeleted = false;

                var cancelled_case = ORM_HEC_CAS_Case.Query.Search(Connection, Transaction, cancelled_caseQ).SingleOrDefault();
                if (cancelled_case != null)
                {
                    cls_Withdraw_OCT_or_Send_Email.Invoke(Connection, Transaction, new P_CAS_WOctoSE_0938()
                    {
                        case_id = Parameter.case_id,
                        op_doctor_id = case_to_cancel.op_doctor_id,
                        patient_id = case_to_cancel.patient_id,
                        localization = case_to_cancel.localization,
                        diagnose_id = case_to_cancel.diagnose_id,
                        drug_id = case_to_cancel.drug_id,
                        oct_doctor_id = case_to_cancel.oct_doctor_id,
                        treatment_date = case_to_cancel.treatment_date
                    }, securityTicket);

                    cancelled_case.IsDeleted = true;
                    cancelled_case.Save(Connection, Transaction);
                }
            }

            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_Guid Invoke(string ConnectionString, P_CAS_CC_1641 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, P_CAS_CC_1641 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, P_CAS_CC_1641 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_CAS_CC_1641 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

                throw new Exception("Exception occured in method cls_Cancel_Case", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes
    #region SClass P_CAS_CC_1641 for attribute P_CAS_CC_1641
    [DataContract]
    public class P_CAS_CC_1641
    {
        //Standard type parameters
        [DataMember]
        public Guid case_id { get; set; }
        [DataMember]
        public Boolean cancel_drug_order { get; set; }
        [DataMember]
        public Boolean cancel_treatment { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Cancel_Case(,P_CAS_CC_1641 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Cancel_Case.Invoke(connectionString,P_CAS_CC_1641 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Case.Atomic.Manipulation.P_CAS_CC_1641();
parameter.case_id = ...;
parameter.cancel_drug_order = ...;
parameter.cancel_treatment = ...;

*/
