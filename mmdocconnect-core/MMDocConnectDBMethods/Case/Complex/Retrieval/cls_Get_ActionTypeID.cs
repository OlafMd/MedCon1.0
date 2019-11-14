/* 
 * Generated on 08/22/16 15:17:21
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

namespace MMDocConnectDBMethods.Case.Complex.Retrieval
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Get_ActionTypeID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Get_ActionTypeID
    {
        public static readonly int QueryTimeout = 6000;

        #region Method Execution
        protected static FR_Guid Execute(DbConnection Connection, DbTransaction Transaction, P_CAS_GATID_1514 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_Guid();
            //Put your code here
            var oct_planned_action_type = ORM_HEC_ACT_ActionType.Query.Search(Connection, Transaction, new ORM_HEC_ACT_ActionType.Query()
            {
                GlobalPropertyMatchingID = Parameter.action_type_gpmid,
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            }).SingleOrDefault();

            if (oct_planned_action_type == null)
            {
                oct_planned_action_type = new ORM_HEC_ACT_ActionType();
                oct_planned_action_type.GlobalPropertyMatchingID = Parameter.action_type_gpmid;
                oct_planned_action_type.Modification_Timestamp = DateTime.Now;
                oct_planned_action_type.Tenant_RefID = securityTicket.TenantID;

                oct_planned_action_type.Save(Connection, Transaction);
            }

            returnValue.Result = oct_planned_action_type.HEC_ACT_ActionTypeID;
            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_Guid Invoke(string ConnectionString, P_CAS_GATID_1514 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, P_CAS_GATID_1514 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, P_CAS_GATID_1514 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_CAS_GATID_1514 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

                throw new Exception("Exception occured in method cls_Get_ActionTypeID", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes
    #region SClass P_CAS_GATID_1514 for attribute P_CAS_GATID_1514
    [DataContract]
    public class P_CAS_GATID_1514
    {
        //Standard type parameters
        [DataMember]
        public String action_type_gpmid { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Get_ActionTypeID(,P_CAS_GATID_1514 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Get_ActionTypeID.Invoke(connectionString,P_CAS_GATID_1514 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Case.Complex.Retrieval.P_CAS_GATID_1514();
parameter.action_type_gpmid = ...;

*/
