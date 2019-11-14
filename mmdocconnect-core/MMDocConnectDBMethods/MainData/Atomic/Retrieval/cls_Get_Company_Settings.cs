/* 
 * Generated on 10.9.2015 9:14:55
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
using CL1_CMN;
using System.Xml;
using System.Web.Configuration;

namespace MMDocConnectDBMethods.MainData.Atomic.Retrieval
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Get_Company_Settings.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Get_Company_Settings
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_MD_GCS_0909 Execute(DbConnection Connection, DbTransaction Transaction, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            //Leave UserCode region to enable user code saving
            #region UserCode
            var returnValue = new FR_MD_GCS_0909();
            //Put your code here
            MD_GCS_0909 parameter = new MD_GCS_0909();
            returnValue.Result = parameter;
            var tenantSettingsQ = ORM_CMN_Tenant_ApplicationSetting.Query.Search(Connection, Transaction, new ORM_CMN_Tenant_ApplicationSetting.Query()
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID
            }).SingleOrDefault();
            if (tenantSettingsQ != null)
            {
                XmlDocument xmlDoc = new XmlDocument();

                xmlDoc.LoadXml(tenantSettingsQ.ItemValue);
                XmlNodeList parentNodeEmail = xmlDoc.GetElementsByTagName("Email");
                foreach (XmlNode childrenNode in parentNodeEmail)
                {
                    parameter.Email = childrenNode.FirstChild.Value;

                }

                XmlNodeList parentNodeAccount = xmlDoc.GetElementsByTagName("AccountID");
                foreach (XmlNode childrenNode in parentNodeAccount)
                {
                    parameter.AccountID = Guid.Parse(childrenNode.FirstChild.Value);

                }
                XmlNodeList parentNodeImmediateOrder = xmlDoc.GetElementsByTagName("ImmediateOrderInterval");
                foreach (XmlNode childrenNode in parentNodeImmediateOrder)
                {
                    parameter.ImmediateOrderInterval = Int32.Parse(childrenNode.FirstChild.Value);

                }
                XmlNodeList parentNodeOrderInterval = xmlDoc.GetElementsByTagName("OrderInterval");
                foreach (XmlNode childrenNode in parentNodeOrderInterval)
                {
                    parameter.OrderInterval = Int32.Parse(childrenNode.FirstChild.Value);

                }
            }
            else
            {
                parameter.Email = WebConfigurationManager.AppSettings["mailInfo"];
                parameter.ImmediateOrderInterval = 120;
                parameter.OrderInterval = 120;

            }
            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_MD_GCS_0909 Invoke(string ConnectionString, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_MD_GCS_0909 Invoke(DbConnection Connection, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_MD_GCS_0909 Invoke(DbConnection Connection, DbTransaction Transaction, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_MD_GCS_0909 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_MD_GCS_0909 functionReturn = new FR_MD_GCS_0909();
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

                functionReturn = Execute(Connection, Transaction, securityTicket);

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

                throw new Exception("Exception occured in method cls_Get_Company_Settings", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Custom Return Type
    [Serializable]
    public class FR_MD_GCS_0909 : FR_Base
    {
        public MD_GCS_0909 Result { get; set; }

        public FR_MD_GCS_0909() : base() { }

        public FR_MD_GCS_0909(Exception ex) : base(ex) { }

    }
    #endregion

    #region Support Classes
    #region SClass MD_GCS_0909 for attribute MD_GCS_0909
    [DataContract]
    public class MD_GCS_0909
    {
        //Standard type parameters
        [DataMember]
        public Guid AccountID { get; set; }
        [DataMember]
        public String Email { get; set; }
        [DataMember]
        public int OrderInterval { get; set; }
        [DataMember]
        public int ImmediateOrderInterval { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_MD_GCS_0909 cls_Get_Company_Settings(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_MD_GCS_0909 invocationResult = cls_Get_Company_Settings.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

