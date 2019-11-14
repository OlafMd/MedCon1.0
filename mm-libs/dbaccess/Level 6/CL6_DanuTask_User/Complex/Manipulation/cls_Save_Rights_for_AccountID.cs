/* 
 * Generated on 12-Dec-14 1:23:46 PM
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

namespace CL6_DanuTask_User.Complex.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Save_Rights_for_AccountID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Save_Rights_for_AccountID
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Bool Execute(DbConnection Connection,DbTransaction Transaction,P_L6US_SRfAID_1237 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
            #region UserCode 
            var returnValue = new FR_Bool();
            //Put your code here

            returnValue.Result = false;

            ORM_USR_Account_2_FunctionLevelRight.Query searchUserRights = new ORM_USR_Account_2_FunctionLevelRight.Query();
            searchUserRights.Account_RefID = Parameter.AccountID;
            searchUserRights.IsDeleted = false;
            searchUserRights.Tenant_RefID = securityTicket.TenantID;

            List<ORM_USR_Account_2_FunctionLevelRight> RightsForAccountID = ORM_USR_Account_2_FunctionLevelRight.Query.Search(Connection, Transaction, searchUserRights);

            if (RightsForAccountID == null)
            {
                RightsForAccountID = new List<ORM_USR_Account_2_FunctionLevelRight>();
            }

            #region ASSIGN ADMIN RIGHTS

            if (Parameter.AssignAdministratorRights && Parameter.AdministratorRightID != null && Parameter.AdministratorRightID != Guid.Empty)
            {
                if (RightsForAccountID.Any(r => r.FunctionLevelRight_RefID == Parameter.AdministratorRightID) == false)
                {
                    ORM_USR_Account_2_FunctionLevelRight newRight = new ORM_USR_Account_2_FunctionLevelRight();
                    newRight.Account_RefID = Parameter.AccountID;
                    newRight.FunctionLevelRight_RefID = Parameter.AdministratorRightID;
                    newRight.Tenant_RefID = securityTicket.TenantID;
                    newRight.IsDeleted = false;

                    newRight.Save(Connection, Transaction);   
                }

                if (RightsForAccountID.Any(r => r.FunctionLevelRight_RefID == Parameter.AdministratorRightID) == true)
                {
                    ORM_USR_Account_2_FunctionLevelRight.Query searchAdmin = new ORM_USR_Account_2_FunctionLevelRight.Query();
                    searchAdmin.IsDeleted = false;
                    searchAdmin.Account_RefID = Parameter.AccountID;
                    searchAdmin.FunctionLevelRight_RefID = Parameter.AdministratorRightID;
                    searchAdmin.Tenant_RefID = securityTicket.TenantID;

                    ORM_USR_Account_2_FunctionLevelRight.Query.SoftDelete(Connection, Transaction, searchAdmin);

                    // Manager is not a manager without ADMIN rights too ( MANAGER -> Admin, Business, Technical rights)
                    // delete business if exists
                    ORM_USR_Account_2_FunctionLevelRight.Query searchBusiness = new ORM_USR_Account_2_FunctionLevelRight.Query();
                    searchBusiness.IsDeleted = false;
                    searchBusiness.Account_RefID = Parameter.AccountID;
                    searchBusiness.FunctionLevelRight_RefID = Parameter.BusinessRightID;
                    searchBusiness.Tenant_RefID = securityTicket.TenantID;

                    ORM_USR_Account_2_FunctionLevelRight.Query.SoftDelete(Connection, Transaction, searchBusiness);

                    // delete technical if exists
                    ORM_USR_Account_2_FunctionLevelRight.Query searchTechnical = new ORM_USR_Account_2_FunctionLevelRight.Query();
                    searchTechnical.IsDeleted = false;
                    searchTechnical.Account_RefID = Parameter.AccountID;
                    searchTechnical.FunctionLevelRight_RefID = Parameter.TechnicalRightID;
                    searchTechnical.Tenant_RefID = securityTicket.TenantID;

                    ORM_USR_Account_2_FunctionLevelRight.Query.SoftDelete(Connection, Transaction, searchTechnical);
                }
            }

            #endregion

            #region ASSIGN MANAGER RIGHTS

            if (Parameter.AssignManagerRights && Parameter.AdministratorRightID != null && Parameter.AdministratorRightID != Guid.Empty && Parameter.BusinessRightID != null && Parameter.BusinessRightID != Guid.Empty && Parameter.TechnicalRightID != null && Parameter.TechnicalRightID != Guid.Empty)
            {

                //add admin
                if (RightsForAccountID.Any(r => r.FunctionLevelRight_RefID == Parameter.AdministratorRightID) == false)
                {
                    ORM_USR_Account_2_FunctionLevelRight newRight = new ORM_USR_Account_2_FunctionLevelRight();
                    newRight.Account_RefID = Parameter.AccountID;
                    newRight.FunctionLevelRight_RefID = Parameter.AdministratorRightID;
                    newRight.Tenant_RefID = securityTicket.TenantID;
                    newRight.IsDeleted = false;

                    newRight.Save(Connection, Transaction);
                }

                // add business
                if (RightsForAccountID.Any(r => r.FunctionLevelRight_RefID == Parameter.BusinessRightID) == false)
                {
                    ORM_USR_Account_2_FunctionLevelRight newRight = new ORM_USR_Account_2_FunctionLevelRight();
                    newRight.Account_RefID = Parameter.AccountID;
                    newRight.FunctionLevelRight_RefID = Parameter.BusinessRightID;
                    newRight.Tenant_RefID = securityTicket.TenantID;
                    newRight.IsDeleted = false;

                    newRight.Save(Connection, Transaction);
                }

                if (RightsForAccountID.Any(r => r.FunctionLevelRight_RefID == Parameter.BusinessRightID) == true)
                {
                    ORM_USR_Account_2_FunctionLevelRight.Query searchQuery = new ORM_USR_Account_2_FunctionLevelRight.Query();
                    searchQuery.IsDeleted = false;
                    searchQuery.Account_RefID = Parameter.AccountID;
                    searchQuery.FunctionLevelRight_RefID = Parameter.BusinessRightID;

                    ORM_USR_Account_2_FunctionLevelRight.Query.SoftDelete(Connection, Transaction, searchQuery);
                }

                //add technical
                if (RightsForAccountID.Any(r => r.FunctionLevelRight_RefID == Parameter.TechnicalRightID) == false)
                {
                    ORM_USR_Account_2_FunctionLevelRight newRight = new ORM_USR_Account_2_FunctionLevelRight();
                    newRight.Account_RefID = Parameter.AccountID;
                    newRight.FunctionLevelRight_RefID = Parameter.TechnicalRightID;
                    newRight.Tenant_RefID = securityTicket.TenantID;
                    newRight.IsDeleted = false;

                    newRight.Save(Connection, Transaction);
                }

                if (RightsForAccountID.Any(r => r.FunctionLevelRight_RefID == Parameter.TechnicalRightID) == true)
                {
                    ORM_USR_Account_2_FunctionLevelRight.Query searchQuery = new ORM_USR_Account_2_FunctionLevelRight.Query();
                    searchQuery.IsDeleted = false;
                    searchQuery.Account_RefID = Parameter.AccountID;
                    searchQuery.FunctionLevelRight_RefID = Parameter.TechnicalRightID;

                    ORM_USR_Account_2_FunctionLevelRight.Query.SoftDelete(Connection, Transaction, searchQuery);
                }

            }

            #endregion

            #region ASSIGN DEVELOPER RIGHTS

            if (Parameter.AssignDeveloperRights && Parameter.DeveloperRightID != Guid.Empty && Parameter.DeveloperRightID != null)
            {
                if (RightsForAccountID.Any(r => r.FunctionLevelRight_RefID == Parameter.DeveloperRightID) == false)
                {
                    ORM_USR_Account_2_FunctionLevelRight newRight = new ORM_USR_Account_2_FunctionLevelRight();
                    newRight.Account_RefID = Parameter.AccountID;
                    newRight.FunctionLevelRight_RefID = Parameter.DeveloperRightID;
                    newRight.Tenant_RefID = securityTicket.TenantID;
                    newRight.IsDeleted = false;

                    newRight.Save(Connection, Transaction);
                }

                if (RightsForAccountID.Any(r => r.FunctionLevelRight_RefID == Parameter.DeveloperRightID) == true)
                {
                    ORM_USR_Account_2_FunctionLevelRight.Query searchQuery = new ORM_USR_Account_2_FunctionLevelRight.Query();
                    searchQuery.IsDeleted = false;
                    searchQuery.Account_RefID = Parameter.AccountID;
                    searchQuery.FunctionLevelRight_RefID = Parameter.DeveloperRightID;

                    ORM_USR_Account_2_FunctionLevelRight.Query.SoftDelete(Connection, Transaction, searchQuery);
                }
            }

            #endregion

            returnValue.Result = true;
            
            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_Bool Invoke(string ConnectionString,P_L6US_SRfAID_1237 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString,Parameter,securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Bool Invoke(DbConnection Connection,P_L6US_SRfAID_1237 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null,Parameter,securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction,P_L6US_SRfAID_1237 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null,Parameter,securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6US_SRfAID_1237 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_Bool functionReturn = new FR_Bool();
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

                functionReturn = Execute(Connection, Transaction,Parameter,securityTicket);

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

                throw new Exception("Exception occured in method cls_Save_Rights_for_AccountID",ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes
        #region SClass P_L6US_SRfAID_1237 for attribute P_L6US_SRfAID_1237
        [DataContract]
        public class P_L6US_SRfAID_1237 
        {
            //Standard type parameters
            [DataMember]
            public Guid AccountID { get; set; } 
            [DataMember]
            public bool AssignAdministratorRights { get; set; } 
            [DataMember]
            public bool AssignManagerRights { get; set; } 
            [DataMember]
            public bool AssignDeveloperRights { get; set; } 
            [DataMember]
            public Guid AdministratorRightID { get; set; } 
            [DataMember]
            public Guid BusinessRightID { get; set; } 
            [DataMember]
            public Guid TechnicalRightID { get; set; } 
            [DataMember]
            public Guid DeveloperRightID { get; set; } 

        }
        #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Bool cls_Save_Rights_for_AccountID(,P_L6US_SRfAID_1237 Parameter, string sessionToken = null)
{
    try
    {
        var securityTicket = Verify(sessionToken);
        FR_Bool invocationResult = cls_Save_Rights_for_AccountID.Invoke(connectionString,P_L6US_SRfAID_1237 Parameter,securityTicket);
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
var parameter = new CL6_DanuTask_User.Complex.Manipulation.P_L6US_SRfAID_1237();
parameter.AccountID = ...;
parameter.AssignAdministratorRights = ...;
parameter.AssignManagerRights = ...;
parameter.AssignDeveloperRights = ...;
parameter.AdministratorRightID = ...;
parameter.BusinessRightID = ...;
parameter.TechnicalRightID = ...;
parameter.DeveloperRightID = ...;

*/
