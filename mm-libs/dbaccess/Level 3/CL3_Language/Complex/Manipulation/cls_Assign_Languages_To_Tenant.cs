/* 
 * Generated on 10/18/2014 4:01:27 PM
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
using CL1_CMN_BPT;

namespace CL3_Language.Complex.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Assign_Languages_To_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Assign_Languages_To_Tenant
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Base Execute(DbConnection Connection, DbTransaction Transaction, P_L3_ALTT_1558 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            //Leave UserCode region to enable user code saving
            #region UserCode
            var returnValue = new FR_Base();

            if (Parameter == null)
            {
                returnValue.Status = FR_Status.Error_Internal;
                returnValue.ErrorMessage = "Assign_Languages_To_Tenant method returned error message: Parameter is null.";
                return returnValue;
            }

            ORM_CMN_Language[] languages = null;

            #region Retrieve all languages for tenant

            languages = ORM_CMN_Language.Query.Search(Connection, Transaction, new ORM_CMN_Language.Query()
            {
                Tenant_RefID = securityTicket.TenantID
            }).ToArray();


            #endregion

            #region Assign/deassign languages

            foreach (var languageToAssign in Parameter.AssignedLanguages)
            {
                var language = languages.FirstOrDefault(l => l.ISO_639_1.ToLower() == languageToAssign.LanguageISoCode.ToLower());
                if (language == null)
                {
                    language = new ORM_CMN_Language();
                    language.CMN_LanguageID = Guid.NewGuid();
                    language.Creation_Timestamp = DateTime.Now;
                    language.IsDeleted = false;
                    language.ISO_639_1 = languageToAssign.LanguageISoCode;
                    language.Name = languageToAssign.LanguageName;
                    language.Tenant_RefID = securityTicket.TenantID;
                    language.Save(Connection, Transaction);
                }

                if (language.IsDeleted == true)
                {
                    language.IsDeleted = false;
                    language.Save(Connection, Transaction);
                }
            }

            foreach (var language in languages.Where(l => l.IsDeleted == false))
            {
                var languageToAssign = Parameter.AssignedLanguages.FirstOrDefault(lta => lta.LanguageISoCode.ToLower() == language.ISO_639_1.ToLower());
                if (languageToAssign == null)
                {
                    language.IsDeleted = true;
                    language.Save(Connection, Transaction);
                }
            }

            #endregion

            #region Set default language for tenant

            if (Parameter.DefaultLanguage != null)
            {
                ORM_CMN_BPT_BusinessParticipant businesParticipant = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, new ORM_CMN_BPT_BusinessParticipant.Query()
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID,
                    IfTenant_Tenant_RefID = securityTicket.TenantID
                }).FirstOrDefault();

                if (businesParticipant != null)
                {
                    var defaultLanguage = languages.FirstOrDefault(l => l.ISO_639_1.ToLower() == Parameter.DefaultLanguage.LanguageISoCode.ToLower());
                    if (defaultLanguage != null)
                    {
                        businesParticipant.DefaultLanguage_RefID = defaultLanguage.CMN_LanguageID;
                        businesParticipant.Save(Connection, Transaction);
                    }
                }
            }

            #endregion

            returnValue.Status = FR_Status.Success;

            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_Base Invoke(string ConnectionString, P_L3_ALTT_1558 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Base Invoke(DbConnection Connection, P_L3_ALTT_1558 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction, P_L3_ALTT_1558 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_L3_ALTT_1558 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

                throw new Exception("Exception occured in method cls_Assign_Languages_To_Tenant", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes
    #region SClass P_L3_ALTT_1558 for attribute P_L3_ALTT_1558
    [DataContract]
    public class P_L3_ALTT_1558
    {
        [DataMember]
        public P_L3_ALTT_1558a[] AssignedLanguages { get; set; }

        //Standard type parameters
        [DataMember]
        public P_L3_ALTT_1558a DefaultLanguage { get; set; }

    }
    #endregion
    #region SClass P_L3_ALTT_1558a for attribute AssignedLanguages
    [DataContract]
    public class P_L3_ALTT_1558a
    {
        //Standard type parameters
        [DataMember]
        public string LanguageISoCode { get; set; }
        [DataMember]
        public Dict LanguageName { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Base cls_Assign_Languages_To_Tenant(,P_L3_ALTT_1558 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Base invocationResult = cls_Assign_Languages_To_Tenant.Invoke(connectionString,P_L3_ALTT_1558 Parameter,securityTicket);
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
var parameter = new CL3_Language.Complex.Manipulation.P_L3_ALTT_1558();
parameter.AssignedLanguages = ...;

parameter.DefaultLanguage = ...;

*/
