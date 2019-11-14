/* 
 * Generated on 11/03/15 14:28:13
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
using MMDocConnectDBMethods.MainData.Atomic.Manipulation;
using CL1_CMN_CTR;
using CL1_HEC_CRT;
using MMDocConnectElasticSearchMethods.Patient.Manipulation;

namespace MMDocConnectDBMethods.MainData.Complex.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Save_Contract.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Save_Contract
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Guid Execute(DbConnection Connection, DbTransaction Transaction, P_MD_SC_1653 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_Guid();
            //Put your code here
            var contractID = Guid.Empty;

            #region NEW CONTRACT
            if (Parameter.ContractID == Guid.Empty)
            {
                ORM_CMN_CTR_Contract contract = new ORM_CMN_CTR_Contract()
                {
                    ContractName = Parameter.ContractName,
                    CMN_CTR_ContractID = Guid.NewGuid(),
                    Creation_Timestamp = DateTime.Now,
                    Modification_Timestamp = DateTime.Now,
                    Tenant_RefID = securityTicket.TenantID,
                    ValidFrom = Parameter.ValidFrom,
                    ValidThrough = Parameter.ValidThrough
                };

                contract.Save(Connection, Transaction);

                contractID = contract.CMN_CTR_ContractID;

                var insuranceToBrokerContract = new ORM_HEC_CRT_InsuranceToBrokerContract();
                insuranceToBrokerContract.Creation_Timestamp = DateTime.Now;
                insuranceToBrokerContract.Ext_CMN_CTR_Contract_RefID = contractID;
                insuranceToBrokerContract.HEC_CRT_InsuranceToBrokerContractID = Guid.NewGuid();
                insuranceToBrokerContract.Modification_Timestamp = DateTime.Now;
                insuranceToBrokerContract.Tenant_RefID = securityTicket.TenantID;

                insuranceToBrokerContract.Save(Connection, Transaction);
            }
            #endregion

            #region EDIT CONTRACT
            else
            {
                contractID = Parameter.ContractID;

                var contract = ORM_CMN_CTR_Contract.Query.Search(Connection, Transaction, new ORM_CMN_CTR_Contract.Query()
                {
                    CMN_CTR_ContractID = Parameter.ContractID,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).SingleOrDefault();

                if (contract != null)
                {
                    contract.ContractName = Parameter.ContractName;
                    contract.ValidFrom = Parameter.ValidFrom;
                    contract.ValidThrough = Parameter.ValidThrough;

                    contract.Save(Connection, Transaction);
                }
            }
            #endregion

            #region UPDATE COVERED DRUGS

            if (Parameter.CoveredDrugIDs != null)
                cls_Save_Contract_Covered_Drugs.Invoke(Connection, Transaction, new P_MD_SCCD_1811() { ContractID = contractID, DrugIDs = Parameter.CoveredDrugIDs }, securityTicket);

            #endregion

            #region UPDATE COVERED DIAGNOSES

            if (Parameter.CoveredDiagnoseIDs != null)
                cls_Save_Contract_Covered_Diagnoses.Invoke(Connection, Transaction, new P_MD_SCCD_1854() { ContractID = contractID, DiagnoseIDs = Parameter.CoveredDiagnoseIDs }, securityTicket);

            #endregion

            #region UPDATE GPOSES

            if (Parameter.GposData != null)
            {
                Parameter.GposData.ContractID = contractID;
                cls_Save_Contract_GPOS_Data.Invoke(Connection, Transaction, Parameter.GposData, securityTicket);
            }

            #endregion UPDATE GPOSES

            #region UPDATE CONTRACT PARAMETERS

            if (Parameter.DueDates != null)
                cls_Save_Contract_Due_Dates.Invoke(Connection, Transaction, new P_MD_SCDD_1729() { ContractID = contractID, DueDates = Parameter.DueDates }, securityTicket);

            #endregion

            #region UPDATE HIPS

            if (Parameter.ParticipatingHIPs != null)
                cls_Save_Contract_Participating_HIPs.Invoke(Connection, Transaction, new P_MD_SCPHIPs_1341() { ContractID = contractID, HipIDs = Parameter.ParticipatingHIPs }, securityTicket);

            #endregion UPDATE HIPS

            #region UPDATE DOCTORS

            if (Parameter.ParticipatingDoctors != null && Parameter.ParticipatingDoctors.Length != 0)
                cls_Save_Contract_Participating_Doctors.Invoke(Connection, Transaction, new P_MD_SCPD_1341() { ContractID = contractID, ParticipatingDoctors = Parameter.ParticipatingDoctors }, securityTicket);

            #endregion

            #region UPDATE ELASTIC
            if (Parameter.DueDates != null)
            {
                var validUntilParam = Parameter.DueDates.Where(t => t.Name == "Duration of participation consent – Month").SingleOrDefault();
                var aftercareParam = Parameter.DueDates.Where(t => t.Name == "Number of days between surgery and aftercare - Days").SingleOrDefault();
                if (validUntilParam != null && aftercareParam != null)
                {
                    var validUntil = !validUntilParam.IsActive ? double.MaxValue : validUntilParam.Value;

                    var aftercareDays = !aftercareParam.IsActive ? double.MaxValue : aftercareParam.Value;

                    var patientDetailsList = Retrieve_Patients.GetPatientDetailsListForContractID(Parameter.ContractID.ToString(), securityTicket);
                    if (patientDetailsList.Any())
                    {
                        Add_New_Patient.ImportPatientDetailsToElastic(patientDetailsList.Select(item =>
                        {
                            var validUntilDate = validUntil == double.MaxValue ? DateTime.MaxValue : item.date.AddMonths(Convert.ToInt32(validUntil));
                            if (aftercareDays != double.MaxValue)
                            {
                                validUntilDate = validUntilDate.AddDays(-aftercareDays);
                            }
                            var validUntilStr = validUntilDate == DateTime.MaxValue ? "∞" : validUntilDate.ToString("dd.MM.yyyy");

                            item.diagnose_or_medication = Properties.Resources.participarionConsent + " " + Parameter.ContractName + ", " + Properties.Resources.goodUntil + " " + validUntilStr;
                            return item;
                        }).ToList(),
                        securityTicket.TenantID.ToString());
                    }
                }
            }
            #endregion

            returnValue.Result = contractID;
            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_Guid Invoke(string ConnectionString, P_MD_SC_1653 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, P_MD_SC_1653 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, P_MD_SC_1653 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_MD_SC_1653 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

                throw new Exception("Exception occured in method cls_Save_Contract", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes
    #region SClass P_MD_SC_1653 for attribute P_MD_SC_1653
    [DataContract]
    public class P_MD_SC_1653
    {
        //Standard type parameters
        [DataMember]
        public Guid ContractID { get; set; }
        [DataMember]
        public String ContractName { get; set; }
        [DataMember]
        public DateTime ValidFrom { get; set; }
        [DataMember]
        public DateTime ValidThrough { get; set; }
        [DataMember]
        public P_MD_SCGPOSD_1306 GposData { get; set; }
        [DataMember]
        public Guid[] CoveredDrugIDs { get; set; }
        [DataMember]
        public Guid[] CoveredDiagnoseIDs { get; set; }
        [DataMember]
        public P_MD_SCDD_1729_Array[] DueDates { get; set; }
        [DataMember]
        public P_MD_SCPD_1341_Doctors[] ParticipatingDoctors { get; set; }
        [DataMember]
        public Guid[] ParticipatingHIPs { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Contract(,P_MD_SC_1653 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Contract.Invoke(connectionString,P_MD_SC_1653 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.MainData.Complex.Manipulation.P_MD_SC_1653();
parameter.ContractID = ...;
parameter.ContractName = ...;
parameter.ValidFrom = ...;
parameter.ValidThrough = ...;
parameter.GposData = ...;
parameter.CoveredDrugIDs = ...;
parameter.CoveredDiagnoseIDs = ...;
parameter.DueDates = ...;
parameter.ParticipatingDoctors = ...;
parameter.ParticipatingHIPs = ...;

*/
