/* 
 * Generated on 8.9.2015 12:29:14
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
using CL1_USR;

namespace MMDocConnectDBMethods.MainData.Atomic.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Save_Permisions_to_User.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Save_Permisions_to_User
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Guid Execute(DbConnection Connection, DbTransaction Transaction, P_MD_SPtMU_1433 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_Guid();

            //check if mm group exists
            var accountGroupQuery = new ORM_USR_Account_FunctionLevelRights_Group.Query();
            accountGroupQuery.Tenant_RefID = securityTicket.TenantID;
            accountGroupQuery.IsDeleted = false;
            accountGroupQuery.GlobalPropertyMatchingID = Parameter.GroupName;

            var accountGroup = ORM_USR_Account_FunctionLevelRights_Group.Query.Search(Connection, Transaction, accountGroupQuery).SingleOrDefault();

            if (accountGroup == null)
            {
                accountGroup = new ORM_USR_Account_FunctionLevelRights_Group();
                accountGroup.Tenant_RefID = securityTicket.TenantID;
                accountGroup.Label = Parameter.GroupName;
                accountGroup.GlobalPropertyMatchingID = Parameter.GroupName;
                accountGroup.Creation_Timestamp = DateTime.Now;
                accountGroup.USR_Account_FunctionLevelRights_GroupID = Guid.NewGuid();

                accountGroup.Save(Connection, Transaction);
            }

            var existingFunctionLevelRight = ORM_USR_Account_FunctionLevelRight.Query.Search(Connection, Transaction, new ORM_USR_Account_FunctionLevelRight.Query()
            {
                GlobalPropertyMatchingID = Parameter.Role,
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                FunctionLevelRights_Group_RefID = accountGroup.USR_Account_FunctionLevelRights_GroupID
            }).FirstOrDefault();

            if (existingFunctionLevelRight == null)
            {
                existingFunctionLevelRight = new ORM_USR_Account_FunctionLevelRight();
                existingFunctionLevelRight.USR_Account_FunctionLevelRightID = Guid.NewGuid();
                existingFunctionLevelRight.FunctionLevelRights_Group_RefID = accountGroup.USR_Account_FunctionLevelRights_GroupID;
                existingFunctionLevelRight.Tenant_RefID = securityTicket.TenantID;
                existingFunctionLevelRight.Creation_Timestamp = DateTime.Now;
                existingFunctionLevelRight.RightName = Parameter.Role;
                existingFunctionLevelRight.GlobalPropertyMatchingID = Parameter.Role;

                existingFunctionLevelRight.Save(Connection, Transaction);
            }

            var acc2functionlevelRight = ORM_USR_Account_2_FunctionLevelRight.Query.Search(Connection, Transaction, new ORM_USR_Account_2_FunctionLevelRight.Query()
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID,
                Account_RefID = Parameter.AccountID
            }).SingleOrDefault();

            if (acc2functionlevelRight != null)
            {
                acc2functionlevelRight.IsDeleted = true;
                acc2functionlevelRight.Save(Connection, Transaction);
            }

            var newAcc2functionlevelRight = new ORM_USR_Account_2_FunctionLevelRight();
            newAcc2functionlevelRight.Tenant_RefID = securityTicket.TenantID;
            newAcc2functionlevelRight.FunctionLevelRight_RefID = existingFunctionLevelRight.USR_Account_FunctionLevelRightID;
            newAcc2functionlevelRight.Creation_Timestamp = DateTime.Now;
            newAcc2functionlevelRight.AssignmentID = Guid.NewGuid();
            newAcc2functionlevelRight.Account_RefID = Parameter.AccountID;

            newAcc2functionlevelRight.Save(Connection, Transaction);

            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_Guid Invoke(string ConnectionString, P_MD_SPtMU_1433 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, P_MD_SPtMU_1433 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, P_MD_SPtMU_1433 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_MD_SPtMU_1433 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

                throw new Exception("Exception occured in method cls_Save_Permisions_to_User", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes
    #region SClass P_MD_SPtMU_1433 for attribute P_MD_SPtMU_1433
    [DataContract]
    public class P_MD_SPtMU_1433
    {
        //Standard type parameters
        [DataMember]
        public Guid AccountID { get; set; }
        [DataMember]
        public string GroupName { get; set; }
        [DataMember]
        public string Role { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Permisions_to_User(,P_MD_SPtMU_1433 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Permisions_to_User.Invoke(connectionString,P_MD_SPtMU_1433 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.MainData.Atomic.Manipulation.P_MD_SPtMU_1433();
parameter.AccountID = ...;
parameter.GroupName = ...;
parameter.Role = ...;

*/
