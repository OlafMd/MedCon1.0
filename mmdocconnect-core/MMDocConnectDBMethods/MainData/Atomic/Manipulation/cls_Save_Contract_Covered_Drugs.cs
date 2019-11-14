/* 
 * Generated on 10/12/15 18:11:36
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
using CL1_HEC_CTR;

namespace MMDocConnectDBMethods.MainData.Atomic.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Save_Contract_Covered_Drugs.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Save_Contract_Covered_Drugs
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Guid Execute(DbConnection Connection, DbTransaction Transaction, P_MD_SCCD_1811 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            //Leave UserCode region to enable user code saving
            #region UserCode
            var returnValue = new FR_Guid();
            //Put your code here
            var insuranceToBrokerContract = ORM_HEC_CRT_InsuranceToBrokerContract.Query.Search(Connection, Transaction, new ORM_HEC_CRT_InsuranceToBrokerContract.Query()
            {
                Ext_CMN_CTR_Contract_RefID = Parameter.ContractID,
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID
            }).SingleOrDefault();

            if (insuranceToBrokerContract != null)
            {
                var allCoveredDrugs = ORM_HEC_CTR_InsuranceToBrokerContracts_CoveredHealthcareProduct.Query.Search(Connection, Transaction, new ORM_HEC_CTR_InsuranceToBrokerContracts_CoveredHealthcareProduct.Query()
                {
                    InsuranceToBrokerContract_RefID = insuranceToBrokerContract.HEC_CRT_InsuranceToBrokerContractID,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                });

                if (allCoveredDrugs.Count != 0)
                {
                    foreach (var coveredDrug in allCoveredDrugs)
                    {
                        if (Parameter.DrugIDs.Length == 0 || !Parameter.DrugIDs.Any(did => did == coveredDrug.HealthcareProduct_RefID))
                        {
                            coveredDrug.IsDeleted = true;
                            coveredDrug.Modification_Timestamp = DateTime.Now;

                            coveredDrug.Save(Connection, Transaction);
                        }
                    }

                }

                foreach (var drugID in Parameter.DrugIDs)
                {
                    if (!allCoveredDrugs.Any(acd => acd.HealthcareProduct_RefID == drugID))
                    {
                        var coveredDrug = new ORM_HEC_CTR_InsuranceToBrokerContracts_CoveredHealthcareProduct();
                        coveredDrug.Creation_Timestamp = DateTime.Now;
                        coveredDrug.HealthcareProduct_RefID = drugID;
                        coveredDrug.HEC_CTR_InsuranceToBrokerContracts_CoveredHealthcareProductID = Guid.NewGuid();
                        coveredDrug.InsuranceToBrokerContract_RefID = insuranceToBrokerContract.HEC_CRT_InsuranceToBrokerContractID;
                        coveredDrug.Modification_Timestamp = DateTime.Now;
                        coveredDrug.Tenant_RefID = securityTicket.TenantID;

                        coveredDrug.Save(Connection, Transaction);
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
        public static FR_Guid Invoke(string ConnectionString, P_MD_SCCD_1811 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, P_MD_SCCD_1811 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, P_MD_SCCD_1811 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_MD_SCCD_1811 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

                throw new Exception("Exception occured in method cls_Save_Contract_Covered_Drugs", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes
    #region SClass P_MD_SCCD_1811 for attribute P_MD_SCCD_1811
    [DataContract]
    public class P_MD_SCCD_1811
    {
        //Standard type parameters
        [DataMember]
        public Guid[] DrugIDs { get; set; }
        [DataMember]
        public Guid ContractID { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Contract_Covered_Drugs(,P_MD_SCCD_1811 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Contract_Covered_Drugs.Invoke(connectionString,P_MD_SCCD_1811 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.MainData.Atomic.Manipulation.P_MD_SCCD_1811();
parameter.DrugIDs = ...;
parameter.ContractID = ...;

*/
