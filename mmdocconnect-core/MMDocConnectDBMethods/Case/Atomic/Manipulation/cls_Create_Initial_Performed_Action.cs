/* 
 * Generated on 02/09/16 10:09:00
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
using CL1_HEC_ACT;
using CL1_HEC_CAS;
using CL1_CMN;

namespace MMDocConnectDBMethods.Case.Atomic.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Create_Initial_Performed_Action.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Create_Initial_Performed_Action
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Guid Execute(DbConnection Connection, DbTransaction Transaction, P_CAS_CIPA_1140 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_Guid();

            ORM_HEC_ACT_ActionType.Query initial_action_typeQ = new ORM_HEC_ACT_ActionType.Query();
            initial_action_typeQ.GlobalPropertyMatchingID = Parameter.action_type_gpmid;
            initial_action_typeQ.Tenant_RefID = securityTicket.TenantID;
            initial_action_typeQ.IsDeleted = false;

            var initial_action_type = ORM_HEC_ACT_ActionType.Query.Search(Connection, Transaction, initial_action_typeQ).SingleOrDefault();
            var initial_action_type_id = Guid.Empty;
            if (initial_action_type == null)
            {
                Dict action_type_name_dict = new Dict(ORM_HEC_ACT_ActionType.TableName);

                initial_action_type = new ORM_HEC_ACT_ActionType();

                foreach (var lang in Parameter.all_languagesL)
                {
                    var content = Parameter.action_type_gpmid.Replace("mm.docconect.doc.app.performed.action.", "");
                    action_type_name_dict.AddEntry(lang.CMN_LanguageID, content);
                }

                initial_action_type.ActionType_Name = action_type_name_dict;
                initial_action_type.Creation_Timestamp = DateTime.Now;
                initial_action_type.GlobalPropertyMatchingID = Parameter.action_type_gpmid;
                initial_action_type.Modification_Timestamp = DateTime.Now;
                initial_action_type.HEC_ACT_ActionTypeID = Guid.NewGuid();
                initial_action_type.Tenant_RefID = securityTicket.TenantID;
                initial_action_type.Save(Connection, Transaction);

                initial_action_type_id = initial_action_type.HEC_ACT_ActionTypeID;
            }
            else
            {
                initial_action_type_id = initial_action_type.HEC_ACT_ActionTypeID;
            }

            ORM_HEC_ACT_PerformedAction initial_performed_action = new ORM_HEC_ACT_PerformedAction();
            initial_performed_action.IfPerfomed_DateOfAction = DateTime.Now;
            initial_performed_action.IfPerformed_DateOfAction_Day = DateTime.Now.Day;
            initial_performed_action.IfPerformed_DateOfAction_Month = DateTime.Now.Month;
            initial_performed_action.IfPerformed_DateOfAction_Year = DateTime.Now.Year;
            initial_performed_action.Tenant_RefID = securityTicket.TenantID;
            initial_performed_action.IsPerformed_Internally = true;
            initial_performed_action.IsPerformed_MedicalPractice_RefID = Parameter.practice_id;
            initial_performed_action.Patient_RefID = Parameter.patient_id;
            initial_performed_action.IfPerformedInternaly_ResponsibleBusinessParticipant_RefID = Parameter.created_by_bpt;

            initial_performed_action.Save(Connection, Transaction);

            ORM_HEC_CAS_Case_RelevantPerformedAction initial_performed_action_to_case = new ORM_HEC_CAS_Case_RelevantPerformedAction();
            initial_performed_action_to_case.Case_RefID = Parameter.case_id;
            initial_performed_action_to_case.Creation_Timestamp = DateTime.Now;
            initial_performed_action_to_case.Modification_Timestamp = DateTime.Now;
            initial_performed_action_to_case.PerformedAction_RefID = initial_performed_action.HEC_ACT_PerformedActionID;
            initial_performed_action_to_case.Tenant_RefID = securityTicket.TenantID;

            initial_performed_action_to_case.Save(Connection, Transaction);

            ORM_HEC_ACT_PerformedAction_2_ActionType initial_performed_action_2_type = new ORM_HEC_ACT_PerformedAction_2_ActionType();
            initial_performed_action_2_type.Tenant_RefID = securityTicket.TenantID;
            initial_performed_action_2_type.Creation_Timestamp = DateTime.Now;
            initial_performed_action_2_type.IsDeleted = false;
            initial_performed_action_2_type.HEC_ACT_ActionType_RefID = initial_action_type_id;
            initial_performed_action_2_type.HEC_ACT_PerformedAction_RefID = initial_performed_action.HEC_ACT_PerformedActionID;
            initial_performed_action_2_type.IM_ActionType_Name = Parameter.action_type_gpmid.Replace("mm.docconect.doc.app.performed.action.", "");
            initial_performed_action_2_type.Modification_Timestamp = DateTime.Now;
            initial_performed_action_2_type.AssignmentID = Guid.NewGuid();

            initial_performed_action_2_type.Save(Connection, Transaction);

            returnValue.Result = initial_performed_action.HEC_ACT_PerformedActionID;
            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_Guid Invoke(string ConnectionString, P_CAS_CIPA_1140 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, P_CAS_CIPA_1140 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, P_CAS_CIPA_1140 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_CAS_CIPA_1140 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

                throw new Exception("Exception occured in method cls_Create_Initial_Performed_Action", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes
    #region SClass P_CAS_CIPA_1140 for attribute P_CAS_CIPA_1140
    [DataContract]
    public class P_CAS_CIPA_1140
    {
        //Standard type parameters
        [DataMember]
        public Guid case_id { get; set; }
        [DataMember]
        public Guid created_by_bpt { get; set; }
        [DataMember]
        public ORM_CMN_Language[] all_languagesL { get; set; }
        [DataMember]
        public Guid patient_id { get; set; }
        [DataMember]
        public Guid practice_id { get; set; }
        [DataMember]
        public String action_type_gpmid { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Create_Initial_Performed_Action(,P_CAS_CIPA_1140 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Create_Initial_Performed_Action.Invoke(connectionString,P_CAS_CIPA_1140 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Case.Atomic.Manipulation.P_CAS_CIPA_1140();
parameter.case_id = ...;
parameter.created_by_bpt = ...;
parameter.all_languagesL = ...;
parameter.patient_id = ...;
parameter.practice_id = ...;
parameter.action_type_gpmid = ...;

*/
