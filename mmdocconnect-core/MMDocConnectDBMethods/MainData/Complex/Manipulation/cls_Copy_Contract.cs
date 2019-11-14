/* 
 * Generated on 10/22/15 10:39:32
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
using CL1_CMN_CTR;
using CL1_HEC_CRT;
using MMDocConnectDBMethods.MainData.Atomic.Manipulation;
using MMDocConnectDBMethods.Case.Atomic.Retrieval;
using MMDocConnectDBMethods.MainData.Atomic.Retrieval;

namespace MMDocConnectDBMethods.MainData.Complex.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Copy_Contract.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Copy_Contract
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Guid Execute(DbConnection Connection, DbTransaction Transaction, P_MD_CC_1039 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            //Leave UserCode region to enable user code saving
            #region UserCode
            var returnValue = new FR_Guid();
            //Put your code here

            #region NEW CONTRACT
            var contractToCopy = ORM_CMN_CTR_Contract.Query.Search(Connection, Transaction, new ORM_CMN_CTR_Contract.Query()
            {
                CMN_CTR_ContractID = Parameter.ContractID,
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            }).SingleOrDefault();

            var newContractName = "Copy of " + contractToCopy.ContractName;
            var existingContractName = cls_Get_Existing_ContractName_for_ContractName.Invoke(Connection, Transaction, new P_MD_GECNfCN_1119() { ContractName = newContractName + "%" }, securityTicket).Result;
            if (existingContractName != null)
            {
                var existingName = existingContractName.ContractName.Substring(newContractName.Length).Trim();
                try
                {
                    newContractName += Convert.ToInt32(existingContractName.ContractName.Substring(newContractName.Length).Trim()) + " " + 1;
                }
                catch (Exception ex)
                {
                    newContractName += " " + 1;
                }
            }

            ORM_CMN_CTR_Contract contract = new ORM_CMN_CTR_Contract()
            {
                ContractName = newContractName,
                CMN_CTR_ContractID = Guid.NewGuid(),
                Creation_Timestamp = DateTime.Now,
                Modification_Timestamp = DateTime.Now,
                Tenant_RefID = securityTicket.TenantID,
                ValidFrom = contractToCopy.ValidFrom,
                ValidThrough = contractToCopy.ValidThrough
            };

            contract.Save(Connection, Transaction);

            var contractID = contract.CMN_CTR_ContractID;

            var insuranceToBrokerContract = new ORM_HEC_CRT_InsuranceToBrokerContract();
            insuranceToBrokerContract.Creation_Timestamp = DateTime.Now;
            insuranceToBrokerContract.Ext_CMN_CTR_Contract_RefID = contractID;
            insuranceToBrokerContract.HEC_CRT_InsuranceToBrokerContractID = Guid.NewGuid();
            insuranceToBrokerContract.Modification_Timestamp = DateTime.Now;
            insuranceToBrokerContract.Tenant_RefID = securityTicket.TenantID;

            insuranceToBrokerContract.Save(Connection, Transaction);
            #endregion

            #region UPDATE COVERED DRUGS
            var CoveredDrugs = cls_Get_All_Drugs_for_ContractID.Invoke(Connection, Transaction, new P_CAS_GADfCID_1220() { ContractID = Parameter.ContractID }, securityTicket).Result;

            if (CoveredDrugs.Length != 0)
                cls_Save_Contract_Covered_Drugs.Invoke(Connection, Transaction, new P_MD_SCCD_1811() { ContractID = contractID, DrugIDs = CoveredDrugs.Select(cd => cd.drug_id).ToArray() }, securityTicket);

            #endregion

            #region UPDATE COVERED DIAGNOSES

            var CoveredDiagnoses = cls_Get_All_Diagnoses_for_ContractID.Invoke(Connection, Transaction, new P_CAS_GADfCID_1306() { ContractID = Parameter.ContractID }, securityTicket).Result;

            if (CoveredDiagnoses.Length != 0)
                cls_Save_Contract_Covered_Diagnoses.Invoke(Connection, Transaction, new P_MD_SCCD_1854() { ContractID = contractID, DiagnoseIDs = CoveredDiagnoses.Select(dia => dia.diagnose_id).ToArray() }, securityTicket);

            #endregion

            #region UPDATE GPOSES

            var connectedDrugs = cls_Get_GPOS_DrugIDs_for_ContractID.Invoke(Connection, Transaction, new P_MD_GGPOSDIDsfCID_1629() { ContractID = Parameter.ContractID }, securityTicket).Result;
            var connectedDiagnoses = cls_Get_GPOS_DiagnoseIDs_for_ContractID.Invoke(Connection, Transaction, new P_MD_GGPOSDIDsfCID_1633() { ContractID = Parameter.ContractID }, securityTicket).Result;

            var GposData = cls_Get_GPOS_Details_for_ContractID.Invoke(Connection, Transaction, new P_MD_GGPOSDfCID_1616() { ContractID = Parameter.ContractID }, securityTicket).Result;
            cls_Save_Contract_GPOS_Data.Invoke(Connection, Transaction, new P_MD_SCGPOSD_1306()
            {
                ContractID = contractID,
                GposData = GposData.Select(gpos =>
                {
                    return new P_MD_SCGPOSD_1306_Array()
                    {
                        DiagnoseIDs = connectedDiagnoses.Where(dia => dia.GposID == gpos.GposID).Select(dia => dia.DiagnoseID).ToArray(),
                        DrugIDs = connectedDrugs.Where(drug => drug.GposID == gpos.GposID).Select(drug => drug.DrugID).ToArray(),
                        FeeValue = gpos.FeeValue,
                        FromInjection = gpos.FromInjection,
                        GposID = Guid.Empty,
                        GposName = gpos.GposName,
                        GposNumber = gpos.GposNumber,
                        GposType = gpos.GposType,
                        ManagementFeeValue = gpos.ManagementFeeValue,
                        WaiveServiceFeeWithOrder = gpos.WaiveWithOrder
                    };
                }).ToArray()
            }, securityTicket);

            #endregion UPDATE GPOSES

            #region UPDATE CONTRACT PARAMETERS

            var currentDueDates = cls_Get_Due_Dates_for_ContractID.Invoke(Connection, Transaction, new P_MD_GDDfCID_1544() { ContractID = Parameter.ContractID }, securityTicket).Result;
            if (currentDueDates.Length != 0)
            {
                cls_Save_Contract_Due_Dates.Invoke(Connection, Transaction, new P_MD_SCDD_1729()
                {
                    ContractID = contractID,
                    DueDates = currentDueDates.Select(dd =>
                    {
                        return new P_MD_SCDD_1729_Array()
                        {
                            Value = dd.Value,
                            Name = dd.Name,
                            IsActive = true
                        };
                    }).ToArray()
                }, securityTicket);
            }
            #endregion

            #region UPDATE HIPS
            var currentHIPs = cls_Get_All_HIPs_for_ContractID.Invoke(Connection, Transaction, new P_MD_GAHIPsfCID_1905() { ContractID = Parameter.ContractID }, securityTicket).Result;

            if (currentHIPs.Length != 0)
                cls_Save_Contract_Participating_HIPs.Invoke(Connection, Transaction, new P_MD_SCPHIPs_1341() { ContractID = contractID, HipIDs = currentHIPs.Select(hip => hip.HipBptID).ToArray() }, securityTicket);

            #endregion UPDATE HIPS

            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_Guid Invoke(string ConnectionString, P_MD_CC_1039 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, P_MD_CC_1039 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, P_MD_CC_1039 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_MD_CC_1039 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

                throw new Exception("Exception occured in method cls_Copy_Contract", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes
    #region SClass P_MD_CC_1039 for attribute P_MD_CC_1039
    [DataContract]
    public class P_MD_CC_1039
    {
        //Standard type parameters
        [DataMember]
        public Guid ContractID { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Copy_Contract(,P_MD_CC_1039 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Copy_Contract.Invoke(connectionString,P_MD_CC_1039 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.MainData.Complex.Manipulation.P_MD_CC_1039();
parameter.ContractID = ...;

*/
