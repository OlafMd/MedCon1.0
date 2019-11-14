/* 
 * Generated on 10/21/15 14:24:08
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
using CL1_HEC_CRT;
using CL1_HEC_HIS;
using CL1_CMN_CTR;

namespace MMDocConnectDBMethods.MainData.Atomic.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Save_Contract_Participating_HIPs.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Save_Contract_Participating_HIPs
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Guid Execute(DbConnection Connection, DbTransaction Transaction, P_MD_SCPHIPs_1341 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            //Leave UserCode region to enable user code saving
            #region UserCode
            var returnValue = new FR_Guid();
            //Put your code here

            var participatingHIPs = ORM_CMN_CTR_Contract_Party.Query.Search(Connection, Transaction, new ORM_CMN_CTR_Contract_Party.Query()
            {
                Contract_RefID = Parameter.ContractID,
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            });

            if (participatingHIPs.Count != 0)
            {
                foreach (var hip in participatingHIPs)
                {
                    if (Parameter.HipIDs.Length == 0 || !Parameter.HipIDs.Any(hid => hid == hip.Undersigning_BusinessParticipant_RefID))
                    {
                        hip.IsDeleted = true;
                        hip.Modification_Timestamp = DateTime.Now;

                        hip.Save(Connection, Transaction);
                    }
                }
            }


            var contractPartiesRolesHIP = ORM_CMN_CTR_Contract_Role.Query.Search(Connection, Transaction, new ORM_CMN_CTR_Contract_Role.Query()
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID,
                RoleName = "Health Insurance Provider"
            }).SingleOrDefault();

            if (contractPartiesRolesHIP == null)
            {
                contractPartiesRolesHIP = new ORM_CMN_CTR_Contract_Role();
                contractPartiesRolesHIP.CMN_CTR_Contract_RoleID = Guid.NewGuid();
                contractPartiesRolesHIP.IsDeleted = false;
                contractPartiesRolesHIP.Tenant_RefID = securityTicket.TenantID;
                contractPartiesRolesHIP.Creation_Timestamp = DateTime.Now;
                contractPartiesRolesHIP.Modification_Timestamp = DateTime.Now;
                contractPartiesRolesHIP.RoleName = "Health Insurance Provider";

                contractPartiesRolesHIP.Save(Connection, Transaction);
            }

            foreach (var hipBptID in Parameter.HipIDs)
            {
                if (!participatingHIPs.Any(hip => hip.Undersigning_BusinessParticipant_RefID == hipBptID))
                {
                    var contractParty = new ORM_CMN_CTR_Contract_Party();
                    contractParty.CMN_CTR_Contract_PartyID = Guid.NewGuid();
                    contractParty.Contract_RefID = Parameter.ContractID;
                    contractParty.Creation_Timestamp = DateTime.Now;
                    contractParty.Modification_Timestamp = DateTime.Now;
                    contractParty.Party_ContractRole_RefID = contractPartiesRolesHIP.CMN_CTR_Contract_RoleID;
                    contractParty.Tenant_RefID = securityTicket.TenantID;
                    contractParty.Undersigning_BusinessParticipant_RefID = hipBptID;

                    contractParty.Save(Connection, Transaction);
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
        public static FR_Guid Invoke(string ConnectionString, P_MD_SCPHIPs_1341 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, P_MD_SCPHIPs_1341 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, P_MD_SCPHIPs_1341 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_MD_SCPHIPs_1341 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

                throw new Exception("Exception occured in method cls_Save_Contract_Participating_HIPs", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes
    #region SClass P_MD_SCPHIPs_1341 for attribute P_MD_SCPHIPs_1341
    [DataContract]
    public class P_MD_SCPHIPs_1341
    {
        //Standard type parameters
        [DataMember]
        public Guid[] HipIDs { get; set; }
        [DataMember]
        public Guid ContractID { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Contract_Participating_HIPs(,P_MD_SCPHIPs_1341 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Contract_Participating_HIPs.Invoke(connectionString,P_MD_SCPHIPs_1341 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.MainData.Atomic.Manipulation.P_MD_SCPHIPs_1341();
parameter.HipIDs = ...;
parameter.ContractID = ...;

*/
