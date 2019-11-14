/* 
 * Generated on 2/1/2017 3:28:24 PM
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
using CL1_HEC;
using CL1_CMN_BPT;
using CL1_CMN_PER;
using CL1_CMN_COM;
using CL1_CMN;

namespace MMDocConnectDBMethods.Pharmacy.Atomic.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Delete_Pharmacy.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Delete_Pharmacy
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Bool Execute(DbConnection Connection, DbTransaction Transaction, P_PH_DP_1523 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_Bool();
            //Put your code here

            #region delete pharmacy
            var pharmacy = ORM_HEC_Pharmacy.Query.Search(Connection, Transaction, new ORM_HEC_Pharmacy.Query
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                HEC_PharmacyID = Parameter.PharmacyID
            }).SingleOrDefault();
            ORM_HEC_Pharmacy.Query.SoftDelete(Connection, Transaction, new ORM_HEC_Pharmacy.Query
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                HEC_PharmacyID = pharmacy.HEC_PharmacyID
            });
            #endregion

            #region delete person info
            var contactInfo = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, new ORM_CMN_BPT_BusinessParticipant.Query
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                CMN_BPT_BusinessParticipantID = pharmacy.ContactPerson_BusinessParticipant_RefID
            }).SingleOrDefault();

            ORM_CMN_BPT_BusinessParticipant.Query.SoftDelete(Connection, Transaction, new ORM_CMN_BPT_BusinessParticipant.Query
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                CMN_BPT_BusinessParticipantID = contactInfo.CMN_BPT_BusinessParticipantID
            });

            ORM_CMN_PER_PersonInfo.Query.SoftDelete(Connection, Transaction, new ORM_CMN_PER_PersonInfo.Query
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDead = false,
                CMN_PER_PersonInfoID = contactInfo.IfNaturalPerson_CMN_PER_PersonInfo_RefID
            });
            #endregion

            #region delete company info
            var companyInfo = ORM_CMN_COM_CompanyInfo.Query.Search(Connection, Transaction, new ORM_CMN_COM_CompanyInfo.Query
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                CMN_COM_CompanyInfoID = pharmacy.Ext_CompanyInfo_RefID
            }).SingleOrDefault();

            ORM_CMN_COM_CompanyInfo.Query.SoftDelete(Connection, Transaction, new ORM_CMN_COM_CompanyInfo.Query
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                CMN_COM_CompanyInfoID = companyInfo.CMN_COM_CompanyInfoID
            });

            ORM_CMN_UniversalContactDetail.Query.SoftDelete(Connection, Transaction, new ORM_CMN_UniversalContactDetail.Query
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                CMN_UniversalContactDetailID = companyInfo.Contact_UCD_RefID
            });

            var ciBusinessParticipant = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, new ORM_CMN_BPT_BusinessParticipant.Query
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                IfCompany_CMN_COM_CompanyInfo_RefID = companyInfo.CMN_COM_CompanyInfoID
            }).SingleOrDefault();

            ORM_CMN_BPT_BusinessParticipant.Query.SoftDelete(Connection, Transaction, new ORM_CMN_BPT_BusinessParticipant.Query
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                IfCompany_CMN_COM_CompanyInfo_RefID = companyInfo.CMN_COM_CompanyInfoID
            });

            ORM_CMN_BPT_BusinessParticipant_2_BusinessParticipantGroup.Query.Search(Connection, Transaction, new ORM_CMN_BPT_BusinessParticipant_2_BusinessParticipantGroup.Query
             {
                 Tenant_RefID = securityTicket.TenantID,
                 IsDeleted = false,
                 CMN_BPT_BusinessParticipant_RefID = ciBusinessParticipant.CMN_BPT_BusinessParticipantID
             });
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
        public static FR_Bool Invoke(string ConnectionString, P_PH_DP_1523 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Bool Invoke(DbConnection Connection, P_PH_DP_1523 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction, P_PH_DP_1523 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_PH_DP_1523 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

                throw new Exception("Exception occured in method cls_Delete_Pharmacy", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes
    #region SClass P_PH_DP_1523 for attribute P_PH_DP_1523
    [DataContract]
    public class P_PH_DP_1523
    {
        //Standard type parameters
        [DataMember]
        public Guid PharmacyID { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Bool cls_Delete_Pharmacy(,P_PH_DP_1523 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Bool invocationResult = cls_Delete_Pharmacy.Invoke(connectionString,P_PH_DP_1523 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Pharmacy.Atomic.Manipulation.P_PH_DP_1523();
parameter.PharmacyID = ...;

*/
