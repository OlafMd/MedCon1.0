/* 
 * Generated on 12/09/15 14:54:02
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
using CL1_HEC_CRT;
using CL1_CMN_CTR;
using DataImporter.DBMethods.Patient.Atomic.Retrieval;

namespace DataImporter.DBMethods.Patient.Atomic.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Add_Consents_to_Patients.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Add_Consents_to_Patients
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Base Execute(DbConnection Connection, DbTransaction Transaction, P_PA_ACtP_1452 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_Base();
            //Put your code here
            var consentsGrouped = Parameter.consents.GroupBy(t => t.insurance_id).Select(t => new { key = t.Key, value = t }).ToDictionary(t => t.key, t => t.value);

            var iviContract = ORM_CMN_CTR_Contract.Query.Search(Connection, Transaction, new ORM_CMN_CTR_Contract.Query() { Tenant_RefID = securityTicket.TenantID, IsDeleted = false, ContractName = "IVI-Vertrag" }).SingleOrDefault();
            if (iviContract != null)
            {
                var iviInsuranceToBrokerContract = ORM_HEC_CRT_InsuranceToBrokerContract.Query.Search(Connection, Transaction, new ORM_HEC_CRT_InsuranceToBrokerContract.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false,
                    Ext_CMN_CTR_Contract_RefID = iviContract.CMN_CTR_ContractID
                }).SingleOrDefault();
                if (iviInsuranceToBrokerContract != null)
                {
                    foreach (var consent in consentsGrouped)
                    {
                        foreach (var data in consent.Value)
                        {
                            var patient = cls_Get_PatientID_for_PatientInsuranceID_and_PracticeBSNR.Invoke(Connection, Transaction, new P_PA_GPIDfPIIDaPBSNR_1552()
                            {
                                BSNR = data.bsnr,
                                InsuranceID = data.insurance_id
                            }, securityTicket).Result;

                            if (patient != null)
                            {
                                var patient_consents = ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingPatient.Query.Search(Connection, Transaction, new ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingPatient.Query()
                                {
                                    Tenant_RefID = securityTicket.TenantID,
                                    IsDeleted = false,
                                    Patient_RefID = patient.PatientID
                                });

                                #region delete existing consents
                                foreach (var existing_consent in patient_consents)
                                {
                                    existing_consent.Modification_Timestamp = DateTime.Now;
                                    existing_consent.IsDeleted = true;

                                    existing_consent.Save(Connection, Transaction);
                                }
                                
                                #endregion

                                #region add new consents

                                foreach (var newConsent in consent.Value)
                                {
                                    var newParticipationConsent = new ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingPatient();
                                    newParticipationConsent.InsuranceToBrokerContract_RefID = iviInsuranceToBrokerContract.HEC_CRT_InsuranceToBrokerContractID;
                                    newParticipationConsent.Modification_Timestamp = DateTime.Now;
                                    newParticipationConsent.Patient_RefID = patient.PatientID;
                                    newParticipationConsent.Tenant_RefID = securityTicket.TenantID;
                                    newParticipationConsent.ValidFrom = newConsent.start_date;

                                    newParticipationConsent.Save(Connection, Transaction);
                                }
                                #endregion
                            }
                            else
                            {
                                throw new Exception("No patient found for insurance id: " + data.insurance_id + " and bsnr: " + data.bsnr);
                            }
                        }
                    }
                }
                else
                {
                    throw new Exception("IVI-Vertrag insurance to broker contract not found.");
                }
            }
            else
            {
                throw new Exception("IVI-Vertrag contract not found.");
            }
            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_Base Invoke(string ConnectionString, P_PA_ACtP_1452 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Base Invoke(DbConnection Connection, P_PA_ACtP_1452 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction, P_PA_ACtP_1452 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_PA_ACtP_1452 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

                throw new Exception("Exception occured in method cls_Add_Consents_to_Patients", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes
    #region SClass P_PA_ACtP_1452 for attribute P_PA_ACtP_1452
    [DataContract]
    public class P_PA_ACtP_1452
    {
        [DataMember]
        public P_PA_ACtP_1452a[] consents { get; set; }

        //Standard type parameters
    }
    #endregion
    #region SClass P_PA_ACtP_1452a for attribute consents
    [DataContract]
    public class P_PA_ACtP_1452a
    {
        //Standard type parameters
        [DataMember]
        public String insurance_id { get; set; }
        [DataMember]
        public String bsnr { get; set; }
        [DataMember]
        public DateTime start_date { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Base cls_Add_Consents_to_Patients(,P_PA_ACtP_1452 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Base invocationResult = cls_Add_Consents_to_Patients.Invoke(connectionString,P_PA_ACtP_1452 Parameter,securityTicket);
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
var parameter = new DataImporter.DBMethods.Patient.Atomic.Manipulation.P_PA_ACtP_1452();
parameter.consents = ...;


*/
