/* 
 * Generated on 04/24/15 15:22:25
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
using BOp.Providers.TMS;
using BOp.Providers;
using BOp.Providers.TMS.Requests;

namespace MMDocConnectDBMethods.Doctor.Atomic.Retrieval
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Check_LoginEmail.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Check_LoginEmail
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_DO_CLE_1414 Execute(DbConnection Connection, DbTransaction Transaction, P_DO_CLE_1414 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_DO_CLE_1414();
            returnValue.Result = new DO_CLE_1414();

            IAccountServiceProvider accountService;
            var _providerFactory = ProviderFactory.Instance;
            accountService = _providerFactory.CreateAccountServiceProvider();

            List<Account> AllAccounts = accountService.GetAllAccountsForTenant(securityTicket.TenantID);

            var account_id = Guid.Empty;
            bool ifExists = false;

            if (Parameter.ID != Guid.Empty)
            {
                if (Parameter.Type.ToLower().Equals("doctor"))
                {
                    var account = cls_Get_Doctor_AccountID_for_DoctorID.Invoke(Connection, Transaction, new P_DO_GDAIDfDID_1549() { DoctorID = Parameter.ID }, securityTicket).Result;
                    if (account != null)
                    {
                        account_id = account.accountID;
                    }
                    else
                    {
                        returnValue.Result.EMailExists = false;
                        return returnValue;
                    }
                }

                if (Parameter.Type.ToLower().Equals("practice"))
                {
                    account_id = cls_Get_Practice_AccountID_for_PracticeID.Invoke(Connection, Transaction, new P_DO_GPAIDfPID_1351() { PracticeID = Parameter.ID }, securityTicket).Result.accountID;
                }

                ifExists = AllAccounts.Exists(ac => ac.Email == Parameter.LoginEmail && ac.ID != account_id);
            }
            else
            {
                ifExists = AllAccounts.Exists(ac => ac.Email == Parameter.LoginEmail);
            }

            returnValue.Result.EMailExists = ifExists;
            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_DO_CLE_1414 Invoke(string ConnectionString, P_DO_CLE_1414 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_DO_CLE_1414 Invoke(DbConnection Connection, P_DO_CLE_1414 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_DO_CLE_1414 Invoke(DbConnection Connection, DbTransaction Transaction, P_DO_CLE_1414 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_DO_CLE_1414 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_DO_CLE_1414 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_DO_CLE_1414 functionReturn = new FR_DO_CLE_1414();
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

                throw new Exception("Exception occured in method cls_Check_LoginEmail", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Custom Return Type
    [Serializable]
    public class FR_DO_CLE_1414 : FR_Base
    {
        public DO_CLE_1414 Result { get; set; }

        public FR_DO_CLE_1414() : base() { }

        public FR_DO_CLE_1414(Exception ex) : base(ex) { }

    }
    #endregion

    #region Support Classes
    #region SClass P_DO_CLE_1414 for attribute P_DO_CLE_1414
    [DataContract]
    public class P_DO_CLE_1414
    {
        //Standard type parameters
        [DataMember]
        public String LoginEmail { get; set; }
        [DataMember]
        public Guid ID { get; set; }
        [DataMember]
        public String Type { get; set; }

    }
    #endregion
    #region SClass DO_CLE_1414 for attribute DO_CLE_1414
    [DataContract]
    public class DO_CLE_1414
    {
        //Standard type parameters
        [DataMember]
        public bool EMailExists { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_DO_CLE_1414 cls_Check_LoginEmail(,P_DO_CLE_1414 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_DO_CLE_1414 invocationResult = cls_Check_LoginEmail.Invoke(connectionString,P_DO_CLE_1414 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Doctor.Atomic.Retrieval.P_DO_CLE_1414();
parameter.LoginEmail = ...;
parameter.ID = ...;
parameter.Type = ...;

*/
