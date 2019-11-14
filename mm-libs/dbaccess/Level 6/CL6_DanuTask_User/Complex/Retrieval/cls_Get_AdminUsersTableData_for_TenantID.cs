/* 
 * Generated on 12-Dec-14 10:59:29 AM
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
using CL3_User.Atomic.Retrieval;
using System.Web.Configuration;
using CL1_CMN;
using CL5_DanuTask_User.Atomic.Retrieval;
using CL1_USR;

namespace CL6_DanuTask_User.Complex.Retrieval
{
    /// <summary>
    /// 
    
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Get_AdminUsersTableData_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Get_AdminUsersTableData_for_TenantID
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_L6US_GAUTDfT_1343_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
            #region UserCode 
            var returnValue = new FR_L6US_GAUTDfT_1343_Array();
            //Put your code here
            List<L6US_GAUTDfT_1343> tempResult = new List<L6US_GAUTDfT_1343>();

            var tempUsers = cls_Get_UsersBasicInfo_for_TenantID.Invoke(Connection, Transaction, securityTicket).Result;
            ORM_CMN_Account_ApplicationSubscription.Query appSubscriptionQuery = new ORM_CMN_Account_ApplicationSubscription.Query();
            Guid ApplicationID = Guid.Parse(WebConfigurationManager.AppSettings["ApplicationID"].ToString());

            foreach (var currentUser in tempUsers)
            {
                L6US_GAUTDfT_1343 tempResultItem = new L6US_GAUTDfT_1343();
                tempResultItem.User_ID = currentUser.USR_AccountID;
                tempResultItem.User_FirsName = currentUser.FirstName;
                tempResultItem.User_LastName = currentUser.LastName;
                tempResultItem.User_Email = currentUser.PrimaryEmail;

                P_L5US_GARfAID_1319 userRightsParameter = new P_L5US_GARfAID_1319();
                userRightsParameter.Account_ID = tempResultItem.User_ID;

                tempResultItem.User_AccountRights = cls_Get_AccountRights_for_AccountID.Invoke(Connection, Transaction, userRightsParameter, securityTicket).Result;

                L6US_GAMDMDfAU_1317a tempUser = new L6US_GAMDMDfAU_1317a();
                appSubscriptionQuery.Account_RefID = currentUser.USR_AccountID;
                appSubscriptionQuery.IsDeleted = false;
                appSubscriptionQuery.Tenant_RefID = securityTicket.TenantID;

                List<ORM_CMN_Account_ApplicationSubscription> tempSubscriptionResult = ORM_CMN_Account_ApplicationSubscription.Query.Search(Connection, Transaction, appSubscriptionQuery);
                if (tempSubscriptionResult != null && tempSubscriptionResult.Count > 0)
                {
                    tempResultItem.User_HasAccessToApp = tempSubscriptionResult.Exists(ts => ts.Application_RefID == ApplicationID && !ts.IsDisabled);
                }
                else
                {
                    tempResultItem.User_HasAccessToApp = false;
                }

                tempResultItem.IsAdmin = false;
                tempResultItem.IsManager = false;
                tempResultItem.IsDeveloper = false;


                tempResult.Add(tempResultItem);
            }


            returnValue.Result = tempResult.ToArray();

            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_L6US_GAUTDfT_1343_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString,securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_L6US_GAUTDfT_1343_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null,securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_L6US_GAUTDfT_1343_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null,securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_L6US_GAUTDfT_1343_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_L6US_GAUTDfT_1343_Array functionReturn = new FR_L6US_GAUTDfT_1343_Array();
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

                functionReturn = Execute(Connection, Transaction,securityTicket);

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
                    if (cleanupTransaction == true && Transaction!=null)
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

                throw new Exception("Exception occured in method cls_Get_AdminUsersTableData_for_TenantID",ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Custom Return Type
    [Serializable]
    public class FR_L6US_GAUTDfT_1343_Array : FR_Base
    {
        public L6US_GAUTDfT_1343[] Result	{ get; set; } 
        public FR_L6US_GAUTDfT_1343_Array() : base() {}

        public FR_L6US_GAUTDfT_1343_Array(Exception ex): base(ex) {}

    }
    #endregion

    #region Support Classes
        #region SClass L6US_GAUTDfT_1343 for attribute L6US_GAUTDfT_1343
        [DataContract]
        public class L6US_GAUTDfT_1343 
        {
            //Standard type parameters
            [DataMember]
            public Guid User_ID { get; set; } 
            [DataMember]
            public String User_FirsName { get; set; } 
            [DataMember]
            public String User_LastName { get; set; } 
            [DataMember]
            public bool User_HasAccessToApp { get; set; } 
            [DataMember]
            public String User_Email { get; set; } 
            [DataMember]
            public L5US_GARfAID_1319[] User_AccountRights { get; set; } 
            [DataMember]
            public bool IsAdmin { get; set; } 
            [DataMember]
            public bool IsManager { get; set; } 
            [DataMember]
            public bool IsDeveloper { get; set; } 

        }
        #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6US_GAUTDfT_1343_Array cls_Get_AdminUsersTableData_for_TenantID(string sessionToken = null)
{
    try
    {
        var securityTicket = Verify(sessionToken);
        FR_L6US_GAUTDfT_1343_Array invocationResult = cls_Get_AdminUsersTableData_for_TenantID.Invoke(connectionString,securityTicket);
        return invocationResult.result;
    } 
    catch(Exception ex)
    {
        //LOG The exception with your standard logger...
        throw;
    }
}
*/

