/* 
 * Generated on 10/23/15 16:58:33
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
using CL1_HEC_HIS;
using CL1_CMN_BPT;

namespace MMDocConnectDBMethods.MainData.Atomic.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Save_New_Insurance_Companies_and_Return_New_IDs.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Save_New_Insurance_Companies_and_Return_New_IDs
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Guids Execute(DbConnection Connection, DbTransaction Transaction, P_MD_SNICaRNIDs_1653[] Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_Guids();

            returnValue.Result = Parameter.Select(hip =>
            {
                var Hip = ORM_HEC_HIS_HealthInsurance_Company.Query.Search(Connection, Transaction, new ORM_HEC_HIS_HealthInsurance_Company.Query()
                {
                    HealthInsurance_IKNumber = hip.IKNumber,
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID
                }).SingleOrDefault();
                if (Hip != null)
                {
                    return Hip.CMN_BPT_BusinessParticipant_RefID;
                }
                else
                {
                    var businessParticipantHIP = new ORM_CMN_BPT_BusinessParticipant();
                    businessParticipantHIP.CMN_BPT_BusinessParticipantID = Guid.NewGuid();
                    businessParticipantHIP.IsDeleted = false;
                    businessParticipantHIP.IsCompany = true;
                    businessParticipantHIP.Tenant_RefID = securityTicket.TenantID;
                    businessParticipantHIP.Creation_Timestamp = DateTime.Now;
                    businessParticipantHIP.Modification_Timestamp = DateTime.Now;
                    businessParticipantHIP.DisplayName = hip.HIPName;
                    businessParticipantHIP.Save(Connection, Transaction);

                    var healthInsuranceCompany = new ORM_HEC_HIS_HealthInsurance_Company();
                    healthInsuranceCompany.IsDeleted = false;
                    healthInsuranceCompany.Tenant_RefID = securityTicket.TenantID;
                    healthInsuranceCompany.Creation_Timestamp = DateTime.Now;
                    healthInsuranceCompany.CMN_BPT_BusinessParticipant_RefID = businessParticipantHIP.CMN_BPT_BusinessParticipantID;
                    healthInsuranceCompany.HealthInsurance_IKNumber = hip.IKNumber;
                    healthInsuranceCompany.Save(Connection, Transaction);

                    return businessParticipantHIP.CMN_BPT_BusinessParticipantID;
                }
            }).ToArray();

            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_Guids Invoke(string ConnectionString, P_MD_SNICaRNIDs_1653[] Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Guids Invoke(DbConnection Connection, P_MD_SNICaRNIDs_1653[] Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Guids Invoke(DbConnection Connection, DbTransaction Transaction, P_MD_SNICaRNIDs_1653[] Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Guids Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_MD_SNICaRNIDs_1653[] Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_Guids functionReturn = new FR_Guids();
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

                throw new Exception("Exception occured in method cls_Save_New_Insurance_Companies_and_Return_New_IDs", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes
    #region SClass P_MD_SNICaRNIDs_1653[] for attribute P_MD_SNICaRNIDs_1653[]
    [DataContract]
    public class P_MD_SNICaRNIDs_1653
    {
        //Standard type parameters
        [DataMember]
        public String IKNumber { get; set; }
        [DataMember]
        public String HIPName { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guids cls_Save_New_Insurance_Companies_and_Return_New_IDs(,P_MD_SNICaRNIDs_1653[] Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guids invocationResult = cls_Save_New_Insurance_Companies_and_Return_New_IDs.Invoke(connectionString,P_MD_SNICaRNIDs_1653[] Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.MainData.Atomic.Manipulation.P_MD_SNICaRNIDs_1653[]();
parameter.IKNumber = ...;
parameter.HIPName = ...;

*/
