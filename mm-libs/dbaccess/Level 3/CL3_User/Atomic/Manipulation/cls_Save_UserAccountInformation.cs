/* 
 * Generated on 16-Dec-14 4:44:30 PM
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
using CL1_CMN_PER;

namespace CL3_User.Atomic.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Save_UserAccountInformation.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Save_UserAccountInformation
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Base Execute(DbConnection Connection,DbTransaction Transaction,P_L3US_SUAI_1642 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
            #region UserCode 
            var returnValue = new FR_Base();
            returnValue.Status = FR_Status.Error_Internal;
            //Put your code here

            //EDIT
            if (Parameter.AccountID != null && Parameter.AccountID != Guid.Empty)
            {
                var item = new ORM_USR_Account();
                if (item.Load(Connection, Transaction, Parameter.AccountID) == null)
                {
                    returnValue.Status = FR_Status.Error_Internal;
                    return returnValue;
                }

                ORM_CMN_PER_PersonInfo_2_Account.Query searchConnection = new CL1_CMN_PER.ORM_CMN_PER_PersonInfo_2_Account.Query();
                searchConnection.IsDeleted = false;
                searchConnection.Tenant_RefID = securityTicket.TenantID;
                searchConnection.USR_Account_RefID = Parameter.AccountID;

                ORM_CMN_PER_PersonInfo_2_Account personInfo2Account = ORM_CMN_PER_PersonInfo_2_Account.Query.Search(Connection, Transaction, searchConnection).FirstOrDefault();

                if (personInfo2Account != null)
                {
                    ORM_CMN_PER_PersonInfo PersonInfo = new ORM_CMN_PER_PersonInfo();
                    PersonInfo.Load(Connection, Transaction, personInfo2Account.CMN_PER_PersonInfo_RefID);

                    if (PersonInfo != null)
                    {
                        PersonInfo.FirstName = Parameter.FirstName;
                        PersonInfo.LastName = Parameter.LastName;

                        PersonInfo.Save(Connection, Transaction);

                        returnValue.Status = FR_Status.Success;
                        return returnValue;
                    }
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
        public static FR_Base Invoke(string ConnectionString,P_L3US_SUAI_1642 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString,Parameter,securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Base Invoke(DbConnection Connection,P_L3US_SUAI_1642 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null,Parameter,securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction,P_L3US_SUAI_1642 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null,Parameter,securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3US_SUAI_1642 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_Base functionReturn = new FR_Base();
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

                throw new Exception("Exception occured in method cls_Save_UserAccountInformation",ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes
        #region SClass P_L3US_SUAI_1642 for attribute P_L3US_SUAI_1642
        [DataContract]
        public class P_L3US_SUAI_1642 
        {
            //Standard type parameters
            [DataMember]
            public Guid AccountID { get; set; } 
            [DataMember]
            public String FirstName { get; set; } 
            [DataMember]
            public String LastName { get; set; } 

        }
        #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Base cls_Save_UserAccountInformation(,P_L3US_SUAI_1642 Parameter, string sessionToken = null)
{
    try
    {
        var securityTicket = Verify(sessionToken);
        FR_Base invocationResult = cls_Save_UserAccountInformation.Invoke(connectionString,P_L3US_SUAI_1642 Parameter,securityTicket);
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
var parameter = new CL3_User.Atomic.Manipulation.P_L3US_SUAI_1642();
parameter.AccountID = ...;
parameter.FirstName = ...;
parameter.LastName = ...;

*/
