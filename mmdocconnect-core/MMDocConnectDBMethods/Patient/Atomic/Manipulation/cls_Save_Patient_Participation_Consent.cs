/* 
 * Generated on 10/6/2015 1:26:43 PM
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
using MMDocConnectElasticSearchMethods.Models;
using CL1_HEC_CRT;
using MMDocConnectElasticSearchMethods.Patient.Manipulation;
using CL1_CMN_CTR;

namespace MMDocConnectDBMethods.Patient.Atomic.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Save_Patient_Participation_Consent.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Save_Patient_Participation_Consent
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Guid Execute(DbConnection Connection, DbTransaction Transaction, P_PA_SPPC_1413 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_Guid();
            List<PatientDetailViewModel> patientDetailList = new List<PatientDetailViewModel>();
            PatientDetailViewModel elasticPatientDetailModel = new PatientDetailViewModel();

            if (Parameter.participation_id == Guid.Empty)
            {
                var InsuranceToBrokerContractQuery = new ORM_HEC_CRT_InsuranceToBrokerContract.Query();
                InsuranceToBrokerContractQuery.Tenant_RefID = securityTicket.TenantID;
                InsuranceToBrokerContractQuery.IsDeleted = false;
                InsuranceToBrokerContractQuery.Ext_CMN_CTR_Contract_RefID = Parameter.contract_id;

                ORM_HEC_CRT_InsuranceToBrokerContract InsuranceToBrokerContract = ORM_HEC_CRT_InsuranceToBrokerContract.Query.Search(Connection, Transaction, InsuranceToBrokerContractQuery).Single();


                ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingPatient InsuranceToBrokerContract_ParticipatingPatient = new ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingPatient();
                InsuranceToBrokerContract_ParticipatingPatient.HEC_CRT_InsuranceToBrokerContract_ParticipatingPatientID = Guid.NewGuid();
                InsuranceToBrokerContract_ParticipatingPatient.InsuranceToBrokerContract_RefID = InsuranceToBrokerContract.HEC_CRT_InsuranceToBrokerContractID;
                InsuranceToBrokerContract_ParticipatingPatient.Creation_Timestamp = DateTime.Now;
                InsuranceToBrokerContract_ParticipatingPatient.Modification_Timestamp = DateTime.Now;
                InsuranceToBrokerContract_ParticipatingPatient.Tenant_RefID = securityTicket.TenantID;
                InsuranceToBrokerContract_ParticipatingPatient.ValidFrom = Parameter.issue_date;
                if (Parameter.participation_consent_valid_days != 0)
                    InsuranceToBrokerContract_ParticipatingPatient.ValidThrough = Parameter.issue_date.AddMonths(Parameter.participation_consent_valid_days);
                else
                    InsuranceToBrokerContract_ParticipatingPatient.ValidThrough = Parameter.contract_ValidTo;
                InsuranceToBrokerContract_ParticipatingPatient.Patient_RefID = Parameter.patient_id;
                InsuranceToBrokerContract_ParticipatingPatient.Save(Connection, Transaction);

                #region UpdateElastic

                Patient_Model patientModel = new Patient_Model();
                patientModel = Retrieve_Patients.Get_Patient_for_PatientID(Parameter.patient_id.ToString(), securityTicket);

                var InsuranceToBrokerContract_ParticipatingPatientQuery = new ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingPatient.Query();
                InsuranceToBrokerContract_ParticipatingPatientQuery.IsDeleted = false;
                InsuranceToBrokerContract_ParticipatingPatientQuery.Tenant_RefID = securityTicket.TenantID;
                InsuranceToBrokerContract_ParticipatingPatientQuery.Patient_RefID = Parameter.patient_id;

                var allInsuranceToBrokerContract_ParticipatingPatient = ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingPatient.Query.Search(Connection, Transaction, InsuranceToBrokerContract_ParticipatingPatientQuery).ToList();
                var latest_participation_date = allInsuranceToBrokerContract_ParticipatingPatient.OrderByDescending(m => m.ValidFrom).FirstOrDefault();

                patientModel.participation_consent_from = latest_participation_date.ValidFrom;
                patientModel.participation_consent_to = latest_participation_date.ValidThrough;
                patientModel.has_participation_consent = true;


                ///
                elasticPatientDetailModel.id = InsuranceToBrokerContract_ParticipatingPatient.HEC_CRT_InsuranceToBrokerContract_ParticipatingPatientID.ToString();
                elasticPatientDetailModel.practice_id = Parameter.practice_id.ToString();
                elasticPatientDetailModel.patient_id = Parameter.patient_id.ToString();
                elasticPatientDetailModel.date = Parameter.issue_date;
                elasticPatientDetailModel.date_string = Parameter.issue_date.ToString("dd.MM.");
                elasticPatientDetailModel.detail_type = "participation";

                var insuranceBrokerContractQuery = new ORM_HEC_CRT_InsuranceToBrokerContract.Query();
                insuranceBrokerContractQuery.IsDeleted = false;
                insuranceBrokerContractQuery.Tenant_RefID = securityTicket.TenantID;
                insuranceBrokerContractQuery.HEC_CRT_InsuranceToBrokerContractID = InsuranceToBrokerContract.HEC_CRT_InsuranceToBrokerContractID;
                var insuranceBrokerContract = ORM_HEC_CRT_InsuranceToBrokerContract.Query.Search(Connection, Transaction, insuranceBrokerContractQuery).Single();

                var contractQuery = new ORM_CMN_CTR_Contract.Query();
                contractQuery.IsDeleted = false;
                contractQuery.Tenant_RefID = securityTicket.TenantID;
                contractQuery.CMN_CTR_ContractID = insuranceBrokerContract.Ext_CMN_CTR_Contract_RefID;
                var contract = ORM_CMN_CTR_Contract.Query.Search(Connection, Transaction, contractQuery).Single();

                var contractParameters = ORM_CMN_CTR_Contract_Parameter.Query.Search(Connection, Transaction, new ORM_CMN_CTR_Contract_Parameter.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false,
                    Contract_RefID = Parameter.contract_id
                });

                var validUntil = contractParameters.Where(t => t.ParameterName == "Duration of participation consent – Month").SingleOrDefault();

                var aftercareDays = contractParameters.Where(t => t.ParameterName == "Number of days between surgery and aftercare - Days").SingleOrDefault();


                var validUntilDate = validUntil == null || validUntil.IfNumericValue_Value == double.MaxValue ? DateTime.MaxValue : Parameter.issue_date.AddMonths(Convert.ToInt32(validUntil.IfNumericValue_Value));

                if (aftercareDays != null && aftercareDays.IfNumericValue_Value != double.MaxValue)
                {
                    validUntilDate = validUntilDate.AddDays(-Convert.ToInt32(aftercareDays.IfNumericValue_Value));
                }
                var validUntilStr = validUntilDate == DateTime.MaxValue ? "∞" : validUntilDate.ToString("dd.MM.yyyy");

                elasticPatientDetailModel.diagnose_or_medication = Properties.Resources.participarionConsent + " " + contract.ContractName + ", " + Properties.Resources.goodUntil + " " + validUntilStr;
                elasticPatientDetailModel.case_id = contract.CMN_CTR_ContractID.ToString();
                
                patientDetailList.Add(elasticPatientDetailModel);

                Add_New_Patient.Import_Patients_to_ElasticDB(new List<Patient_Model>() { patientModel }, securityTicket.TenantID.ToString());
                Add_New_Patient.ImportPatientDetailsToElastic(patientDetailList, securityTicket.TenantID.ToString());
                #endregion
            }
            else
            {
                //#EDIT******

                //find new contract
                var InsuranceToBrokerContractQuery = new ORM_HEC_CRT_InsuranceToBrokerContract.Query();
                InsuranceToBrokerContractQuery.Tenant_RefID = securityTicket.TenantID;
                InsuranceToBrokerContractQuery.IsDeleted = false;
                InsuranceToBrokerContractQuery.Ext_CMN_CTR_Contract_RefID = Parameter.contract_id;

                ORM_HEC_CRT_InsuranceToBrokerContract InsuranceToBrokerContract = ORM_HEC_CRT_InsuranceToBrokerContract.Query.Search(Connection, Transaction, InsuranceToBrokerContractQuery).Single();



                var queryParticipant = new ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingPatient.Query();
                queryParticipant.IsDeleted = false;
                queryParticipant.Tenant_RefID = securityTicket.TenantID;
                queryParticipant.HEC_CRT_InsuranceToBrokerContract_ParticipatingPatientID = Parameter.participation_id;

                var InsuranceToBrokerContract_ParticipatingPatient = ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingPatient.Query.Search(Connection, Transaction, queryParticipant).Single();
                InsuranceToBrokerContract_ParticipatingPatient.InsuranceToBrokerContract_RefID = InsuranceToBrokerContract.HEC_CRT_InsuranceToBrokerContractID;
                InsuranceToBrokerContract_ParticipatingPatient.Modification_Timestamp = DateTime.Now;
                InsuranceToBrokerContract_ParticipatingPatient.ValidFrom = Parameter.issue_date;
                InsuranceToBrokerContract_ParticipatingPatient.ValidFrom = Parameter.issue_date;
                if (Parameter.participation_consent_valid_days != 0)
                    InsuranceToBrokerContract_ParticipatingPatient.ValidThrough = Parameter.issue_date.AddMonths(Parameter.participation_consent_valid_days);
                else
                    InsuranceToBrokerContract_ParticipatingPatient.ValidThrough = Parameter.contract_ValidTo;
                InsuranceToBrokerContract_ParticipatingPatient.Save(Connection, Transaction);


                #region Update Elastic

                Patient_Model patientModel = new Patient_Model();
                patientModel = Retrieve_Patients.Get_Patient_for_PatientID(Parameter.patient_id.ToString(), securityTicket);

                var InsuranceToBrokerContract_ParticipatingPatientQuery = new ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingPatient.Query();
                InsuranceToBrokerContract_ParticipatingPatientQuery.IsDeleted = false;
                InsuranceToBrokerContract_ParticipatingPatientQuery.Tenant_RefID = securityTicket.TenantID;
                InsuranceToBrokerContract_ParticipatingPatientQuery.Patient_RefID = Parameter.patient_id;

                var allInsuranceToBrokerContract_ParticipatingPatient = ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingPatient.Query.Search(Connection, Transaction, InsuranceToBrokerContract_ParticipatingPatientQuery).ToList();
                var latest_participation_date = allInsuranceToBrokerContract_ParticipatingPatient.OrderByDescending(m => m.ValidFrom).FirstOrDefault();

                patientModel.participation_consent_from = latest_participation_date.ValidFrom;
                patientModel.participation_consent_to = latest_participation_date.ValidThrough;
                patientModel.has_participation_consent = true;

                var insuranceBrokerContractQuery = new ORM_HEC_CRT_InsuranceToBrokerContract.Query();
                insuranceBrokerContractQuery.IsDeleted = false;
                insuranceBrokerContractQuery.Tenant_RefID = securityTicket.TenantID;
                insuranceBrokerContractQuery.HEC_CRT_InsuranceToBrokerContractID = InsuranceToBrokerContract.HEC_CRT_InsuranceToBrokerContractID;
                var insuranceBrokerContract = ORM_HEC_CRT_InsuranceToBrokerContract.Query.Search(Connection, Transaction, insuranceBrokerContractQuery).Single();

                var contractQuery = new ORM_CMN_CTR_Contract.Query();
                contractQuery.IsDeleted = false;
                contractQuery.Tenant_RefID = securityTicket.TenantID;
                contractQuery.CMN_CTR_ContractID = insuranceBrokerContract.Ext_CMN_CTR_Contract_RefID;
                var contract = ORM_CMN_CTR_Contract.Query.Search(Connection, Transaction, contractQuery).Single();

                var elasticPatientDetailModel2 = Retrieve_Patients.Get_PatientDetaiForID(Parameter.participation_id.ToString(), securityTicket);
                if (elasticPatientDetailModel2 != null)
                {
                    elasticPatientDetailModel2.date = Parameter.issue_date;
                    elasticPatientDetailModel2.date_string = Parameter.issue_date.ToString("dd.MM.");


                    var contractParameters = ORM_CMN_CTR_Contract_Parameter.Query.Search(Connection, Transaction, new ORM_CMN_CTR_Contract_Parameter.Query()
                    {
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false,
                        Contract_RefID = Parameter.contract_id
                    });

                    var validUntil = contractParameters.Where(t => t.ParameterName == "Duration of participation consent – Month").SingleOrDefault();

                    var aftercareDays = contractParameters.Where(t => t.ParameterName == "Number of days between surgery and aftercare - Days").SingleOrDefault();


                    var validUntilDate = validUntil == null || validUntil.IfNumericValue_Value == double.MaxValue ? DateTime.MaxValue : Parameter.issue_date.AddMonths(Convert.ToInt32(validUntil.IfNumericValue_Value));

                    if (aftercareDays != null && aftercareDays.IfNumericValue_Value != double.MaxValue)
                    {
                        validUntilDate = validUntilDate.AddDays(-Convert.ToInt32(aftercareDays.IfNumericValue_Value));
                    }
                    var validUntilStr = validUntilDate == DateTime.MaxValue ? "∞" : validUntilDate.ToString("dd.MM.yyyy");

                    elasticPatientDetailModel2.diagnose_or_medication = Properties.Resources.participarionConsent + " " + contract.ContractName + ", " + Properties.Resources.goodUntil + " " + validUntilStr;
                    
                    patientDetailList.Add(elasticPatientDetailModel2);
                }

                Add_New_Patient.Import_Patients_to_ElasticDB(new List<Patient_Model>() { patientModel }, securityTicket.TenantID.ToString());

                if (patientDetailList.Count != 0)
                    Add_New_Patient.ImportPatientDetailsToElastic(patientDetailList, securityTicket.TenantID.ToString());

                #endregion

            }

            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_Guid Invoke(string ConnectionString, P_PA_SPPC_1413 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, P_PA_SPPC_1413 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, P_PA_SPPC_1413 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_PA_SPPC_1413 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

                throw new Exception("Exception occured in method cls_Save_Patient_Participation_Consent", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes
    #region SClass P_PA_SPPC_1413 for attribute P_PA_SPPC_1413
    [DataContract]
    public class P_PA_SPPC_1413
    {
        //Standard type parameters
        [DataMember]
        public Guid patient_id { get; set; }
        [DataMember]
        public Guid practice_id { get; set; }
        [DataMember]
        public Guid contract_id { get; set; }
        [DataMember]
        public Guid participation_id { get; set; }
        [DataMember]
        public DateTime issue_date { get; set; }
        [DataMember]
        public int participation_consent_valid_days { get; set; }
        [DataMember]
        public DateTime contract_ValidTo { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Patient_Participation_Consent(,P_PA_SPPC_1413 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Patient_Participation_Consent.Invoke(connectionString,P_PA_SPPC_1413 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Patient.Atomic.Manipulation.P_PA_SPPC_1413();
parameter.patient_id = ...;
parameter.practice_id = ...;
parameter.contract_id = ...;
parameter.participation_id = ...;
parameter.issue_date = ...;
parameter.participation_consent_valid_days = ...;
parameter.contract_ValidTo = ...;

*/
