/* 
 * Generated on 9.9.2015 17:02:12
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
using System.IO;
using System.Xml;
using System.Text;
using CL1_CMN;
using System.Web;

namespace MMDocConnectDBMethods.MainData.Atomic.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Save_Company_Settings.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Save_Company_Settings
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Guid Execute(DbConnection Connection, DbTransaction Transaction, P_MD_SCS_1700 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            //Leave UserCode region to enable user code saving
            #region UserCode
            var returnValue = new FR_Guid();
            //Put your code here

            //create xml file
            var ms = new MemoryStream();
            var w = new XmlTextWriter(ms, new UTF8Encoding(false)) { Formatting = Formatting.Indented };


            w.WriteStartDocument();
            w.WriteStartElement("AppSettings");
            w.WriteElementString("AccountID", Parameter.AccountID.ToString());
            w.WriteElementString("Email", Parameter.Email);
            w.WriteElementString("ImmediateOrderInterval", Parameter.ImmediateOrderInterval.ToString());
            w.WriteElementString("OrderInterval", Parameter.OrderInterval.ToString());
            w.WriteEndElement();

            w.WriteEndDocument();
            w.Flush();

            var xml = Encoding.UTF8.GetString(ms.ToArray());
            var tenantSettingsQ = ORM_CMN_Tenant_ApplicationSetting.Query.Search(Connection, Transaction, new ORM_CMN_Tenant_ApplicationSetting.Query()
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID
            }).SingleOrDefault();
            if (tenantSettingsQ == null)
            {

                var tenantSettings = new ORM_CMN_Tenant_ApplicationSetting();
                tenantSettings.IsDeleted = false;
                tenantSettings.Tenant_RefID = securityTicket.TenantID;
                tenantSettings.ItemValue = xml;
                tenantSettings.Creation_Timestamp = DateTime.Now;
                tenantSettings.Save(Connection, Transaction);

            }
            else
            {

                tenantSettingsQ.ItemValue = xml;
                tenantSettingsQ.Save(Connection, Transaction);
            }
            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_Guid Invoke(string ConnectionString, P_MD_SCS_1700 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, P_MD_SCS_1700 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, P_MD_SCS_1700 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_MD_SCS_1700 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

                throw new Exception("Exception occured in method cls_Save_Company_Settings", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes
    #region SClass P_MD_SCS_1700 for attribute P_MD_SCS_1700
    [DataContract]
    public class P_MD_SCS_1700
    {
        //Standard type parameters
        [DataMember]
        public Guid AccountID { get; set; }
        [DataMember]
        public string Email { get; set; }
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
FR_Guid cls_Save_Company_Settings(,P_MD_SCS_1700 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Company_Settings.Invoke(connectionString,P_MD_SCS_1700 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.MainData.Atomic.Manipulation.P_MD_SCS_1700();
parameter.AccountID = ...;
parameter.Email = ...;
parameter.OrderInterval = ...;
parameter.ImmediateOrderInterval = ...;

*/
