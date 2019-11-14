/* 
 * Generated on 10/21/2014 4:44:22 PM
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
using CL1_CMN_BPT;
using CL1_CMN;

namespace CL3_Language.Complex.Retrieval
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Get_Default_Language_For_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Get_Default_Language_For_Tenant
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_L3CR_GDLfT_1641 Execute(DbConnection Connection, DbTransaction Transaction, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            //Leave UserCode region to enable user code saving
            #region UserCode
            var returnValue = new FR_L3CR_GDLfT_1641();

            ORM_CMN_BPT_BusinessParticipant businesParticipant = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, new ORM_CMN_BPT_BusinessParticipant.Query()
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID,
                IfTenant_Tenant_RefID = securityTicket.TenantID
            }).FirstOrDefault();

            if (businesParticipant == null)
            {
                returnValue.ErrorMessage = String.Format("BusinessParticipant could not be found for tenant {0}", securityTicket.TenantID.ToString());
                returnValue.Status = FR_Status.Error_Internal;
                return returnValue;
            }


            Guid defaultLanguageId = businesParticipant.DefaultLanguage_RefID;
            ORM_CMN_Language defaultLanguage = null;

            if (defaultLanguageId != Guid.Empty)
            {
                defaultLanguage = ORM_CMN_Language.Query.Search(Connection, Transaction, new ORM_CMN_Language.Query()
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID,
                    CMN_LanguageID = defaultLanguageId
                }).FirstOrDefault();
            }

            returnValue.Result = new L3CR_GDLfT_1641();
            returnValue.Result.DefaultLanguage = defaultLanguage;


            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_L3CR_GDLfT_1641 Invoke(string ConnectionString, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_L3CR_GDLfT_1641 Invoke(DbConnection Connection, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_L3CR_GDLfT_1641 Invoke(DbConnection Connection, DbTransaction Transaction, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_L3CR_GDLfT_1641 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_L3CR_GDLfT_1641 functionReturn = new FR_L3CR_GDLfT_1641();
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

                throw new Exception("Exception occured in method cls_Get_Default_Language_For_Tenant", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Custom Return Type
    [Serializable]
    public class FR_L3CR_GDLfT_1641 : FR_Base
    {
        public L3CR_GDLfT_1641 Result { get; set; }

        public FR_L3CR_GDLfT_1641() : base() { }

        public FR_L3CR_GDLfT_1641(Exception ex) : base(ex) { }

    }
    #endregion

    #region Support Classes
    #region SClass L3CR_GDLfT_1641 for attribute L3CR_GDLfT_1641
    [DataContract]
    public class L3CR_GDLfT_1641
    {
        [DataMember]
        public ORM_CMN_Language DefaultLanguage { get; set; }

        //Standard type parameters
    }
    #endregion


    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3CR_GDLfT_1641 cls_Get_Default_Language_For_Tenant(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3CR_GDLfT_1641 invocationResult = cls_Get_Default_Language_For_Tenant.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

