/* 
 * Generated on 10/14/15 09:51:49
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
using CL1_HEC_CAS;
using MMDocConnectDBMethods.Case.Atomic.Retrieval;

namespace MMDocConnectDBMethods.Case.Complex.Retrieval
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Get_is_Aftercares_Status_Editable_for_CaseID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Get_is_Aftercares_Status_Editable_for_CaseID
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_CAS_GiASEfCID_1127 Execute(DbConnection Connection, DbTransaction Transaction, P_CAS_GiASEfCID_1127 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_CAS_GiASEfCID_1127();
            returnValue.Result = new CAS_GiASEfCID_1127();
            //Put your code here

            var relevant_aftercares = ORM_HEC_CAS_Case_RelevantPlannedAction.Query.Search(Connection, Transaction, new ORM_HEC_CAS_Case_RelevantPlannedAction.Query()
            {
                Case_RefID = Parameter.CaseID,
                Tenant_RefID = securityTicket.TenantID
            });

            if (relevant_aftercares.Count == 1)
            {
                returnValue.Result.IsEditable = true;
            }
            else
            {
                var fs_statuses = cls_Get_Case_TransmitionCode_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GCTCfCID_1427() { CaseID = Parameter.CaseID }, securityTicket).Result.Where(fs => fs.fs_key == "aftercare").ToArray();
                if (fs_statuses.Length > 1)
                {
                    returnValue.Result.IsEditable = !fs_statuses.Select(fs =>
                    {
                        return fs.fs_status != 8;
                    }).Any(fs => fs);
                }
                else
                {
                    returnValue.Result.IsEditable = false;
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
        public static FR_CAS_GiASEfCID_1127 Invoke(string ConnectionString, P_CAS_GiASEfCID_1127 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_CAS_GiASEfCID_1127 Invoke(DbConnection Connection, P_CAS_GiASEfCID_1127 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_CAS_GiASEfCID_1127 Invoke(DbConnection Connection, DbTransaction Transaction, P_CAS_GiASEfCID_1127 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_CAS_GiASEfCID_1127 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_CAS_GiASEfCID_1127 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_CAS_GiASEfCID_1127 functionReturn = new FR_CAS_GiASEfCID_1127();
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

                throw new Exception("Exception occured in method cls_Get_is_Aftercares_Status_Editable_for_CaseID", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Custom Return Type
    [Serializable]
    public class FR_CAS_GiASEfCID_1127 : FR_Base
    {
        public CAS_GiASEfCID_1127 Result { get; set; }

        public FR_CAS_GiASEfCID_1127() : base() { }

        public FR_CAS_GiASEfCID_1127(Exception ex) : base(ex) { }

    }
    #endregion

    #region Support Classes
    #region SClass P_CAS_GiASEfCID_1127 for attribute P_CAS_GiASEfCID_1127
    [DataContract]
    public class P_CAS_GiASEfCID_1127
    {
        //Standard type parameters
        [DataMember]
        public Guid CaseID { get; set; }
        [DataMember]
        public Guid[] AftercareIDs { get; set; }

    }
    #endregion
    #region SClass CAS_GiASEfCID_1127 for attribute CAS_GiASEfCID_1127
    [DataContract]
    public class CAS_GiASEfCID_1127
    {
        //Standard type parameters
        [DataMember]
        public Boolean IsEditable { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_CAS_GiASEfCID_1127 cls_Get_is_Aftercares_Status_Editable_for_CaseID(,P_CAS_GiASEfCID_1127 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_CAS_GiASEfCID_1127 invocationResult = cls_Get_is_Aftercares_Status_Editable_for_CaseID.Invoke(connectionString,P_CAS_GiASEfCID_1127 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Case.Complex.Retrieval.P_CAS_GiASEfCID_1127();
parameter.CaseID = ...;
parameter.AftercareIDs = ...;

*/
