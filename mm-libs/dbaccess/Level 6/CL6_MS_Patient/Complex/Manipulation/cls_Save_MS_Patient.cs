/* 
 * Generated on 7/22/2013 3:47:03 PM
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
using CSV2Core.Core;
using System.Runtime.Serialization;
using CL1_CMN_PER;
using CL1_CMN_BPT;
using CL1_HEC;
using CL1_HEC_STU;
using CL1_USR;
using CL2_DeviceAccountCode.Complex.Retrieval;
using Core_ClassLibrarySupport.Inscpecific;

namespace CL6_MS_Patient.Complex.Manipulation
{
	/// <summary>
    /// 
      
    
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_MS_Patient.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_MS_Patient
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L6PA_SMSP_1548 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Guid();
            ORM_HEC_Patient patient = new ORM_HEC_Patient();
            if (Parameter.HEC_PatientID != Guid.Empty)
            {
                var result = patient.Load(Connection, Transaction, Parameter.HEC_PatientID);
                if (result.Status != FR_Status.Success || patient.HEC_PatientID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }
            patient.IsPatientParticipationPolicyValidated = Parameter.HasFulfilledParticipationPolicyRequirements;
            patient.PatientComment = Parameter.Comment;
            patient.Tenant_RefID = securityTicket.TenantID;

            ORM_CMN_BPT_BusinessParticipant bParticipant = new ORM_CMN_BPT_BusinessParticipant();
            if (patient.CMN_BPT_BusinessParticipant_RefID != Guid.Empty)
            {
                var result = bParticipant.Load(Connection, Transaction, patient.CMN_BPT_BusinessParticipant_RefID);
                if (result.Status != FR_Status.Success || bParticipant.CMN_BPT_BusinessParticipantID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }
            bParticipant.IsNaturalPerson = true;
            bParticipant.Tenant_RefID = securityTicket.TenantID;


            ORM_CMN_PER_PersonInfo person = new ORM_CMN_PER_PersonInfo();
            if (bParticipant.IfNaturalPerson_CMN_PER_PersonInfo_RefID != Guid.Empty)
            {
                var result = person.Load(Connection, Transaction, bParticipant.IfNaturalPerson_CMN_PER_PersonInfo_RefID);
                if (result.Status != FR_Status.Success || person.CMN_PER_PersonInfoID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }
            person.FirstName = Parameter.FirstName;
            person.LastName = Parameter.LastName;
            person.PrimaryEmail = Parameter.Mail;
            person.Tenant_RefID = securityTicket.TenantID;
            person.Salutation_General = Parameter.Salutation;
            person.Save(Connection, Transaction);

            bParticipant.IfNaturalPerson_CMN_PER_PersonInfo_RefID = person.CMN_PER_PersonInfoID;
            bParticipant.Save(Connection, Transaction);

            patient.CMN_BPT_BusinessParticipant_RefID = bParticipant.CMN_BPT_BusinessParticipantID;
            patient.Save(Connection, Transaction);

            ORM_CMN_PER_CommunicationContact.Query contactQuery = new ORM_CMN_PER_CommunicationContact.Query();
            contactQuery.IsDeleted = false;
            contactQuery.Tenant_RefID = securityTicket.TenantID;
            contactQuery.PersonInfo_RefID = person.CMN_PER_PersonInfoID;
            var contactQueryRes = ORM_CMN_PER_CommunicationContact.Query.Search(Connection, Transaction, contactQuery);
            ORM_CMN_PER_CommunicationContact contactPhone = contactQueryRes.FirstOrDefault(c => c.Contact_Type == STLD_ContactTypes.Phone);
            ORM_CMN_PER_CommunicationContact contactFax = contactQueryRes.FirstOrDefault(c => c.Contact_Type == STLD_ContactTypes.Fax);

            if (contactPhone == null)
            {
                contactPhone = new ORM_CMN_PER_CommunicationContact();
                contactPhone.Contact_Type = STLD_ContactTypes.Phone;
                contactPhone.Tenant_RefID = securityTicket.TenantID;
                contactPhone.PersonInfo_RefID = person.CMN_PER_PersonInfoID;
            }
            contactPhone.Content = Parameter.Phone;
            contactPhone.Save(Connection, Transaction);

            if (contactFax == null)
            {
                contactFax = new ORM_CMN_PER_CommunicationContact();
                contactFax.Content = Parameter.Fax;
                contactFax.Contact_Type = STLD_ContactTypes.Fax;
                contactFax.Tenant_RefID = securityTicket.TenantID;
                contactFax.PersonInfo_RefID = person.CMN_PER_PersonInfoID;
                contactFax.Save(Connection, Transaction);
            }
            contactFax.Content = Parameter.Fax;
            contactFax.Save(Connection, Transaction);

            ORM_HEC_Patient_HealthInsurance.Query Patient_HealthInsuranceQuery = new ORM_HEC_Patient_HealthInsurance.Query();
            Patient_HealthInsuranceQuery.Tenant_RefID = securityTicket.TenantID;
            Patient_HealthInsuranceQuery.IsDeleted = false;
            Patient_HealthInsuranceQuery.Patient_RefID = patient.HEC_PatientID;

            ORM_HEC_Patient_HealthInsurance Patient_HealthInsurance;
            var Patient_HealthInsuranceQueryRes = ORM_HEC_Patient_HealthInsurance.Query.Search(Connection, Transaction, Patient_HealthInsuranceQuery);
            if (Patient_HealthInsuranceQueryRes.Count == 1)
            {
                Patient_HealthInsurance = Patient_HealthInsuranceQueryRes[0];
            }
            else
            {
                Patient_HealthInsurance = new ORM_HEC_Patient_HealthInsurance();
                Patient_HealthInsurance.Patient_RefID = patient.HEC_PatientID;
                Patient_HealthInsurance.Tenant_RefID = securityTicket.TenantID;
                Patient_HealthInsurance.IsPrimary = true;
            }
            Patient_HealthInsurance.HealthInsurance_Number = Parameter.HealthcareNumber;
            Patient_HealthInsurance.Save(Connection, Transaction);

            ORM_HEC_STU_Study_ParticipatingPatient.Query Study_ParticipatingPatientsQuery = new ORM_HEC_STU_Study_ParticipatingPatient.Query();
            Study_ParticipatingPatientsQuery.Tenant_RefID = securityTicket.TenantID;
            Study_ParticipatingPatientsQuery.IsDeleted = false;
            Study_ParticipatingPatientsQuery.Patient_RefID = patient.HEC_PatientID;

            ORM_HEC_STU_Study_ParticipatingPatient Study_ParticipatingPatients;

            var Study_ParticipatingPatientsQueryRes = ORM_HEC_STU_Study_ParticipatingPatient.Query.Search(Connection, Transaction, Study_ParticipatingPatientsQuery);
            if (Study_ParticipatingPatientsQueryRes.Count == 1)
            {
                Study_ParticipatingPatients = Study_ParticipatingPatientsQueryRes[0];
            }
            else
            {
                Study_ParticipatingPatients = new ORM_HEC_STU_Study_ParticipatingPatient();
                Study_ParticipatingPatients.Patient_RefID = patient.HEC_PatientID;
                Study_ParticipatingPatients.Tenant_RefID = securityTicket.TenantID;
            }
            Study_ParticipatingPatients.HasFulfilledParticipationPolicyRequirements = Parameter.HasFulfilledParticipationPolicyRequirements;
            Study_ParticipatingPatients.Save(Connection, Transaction);


            ORM_USR_Account account;
            ORM_USR_Account.Query ORM_USR_AccountQuery = new ORM_USR_Account.Query();
            ORM_USR_AccountQuery.IsDeleted = false;
            ORM_USR_AccountQuery.Tenant_RefID = securityTicket.TenantID;
            ORM_USR_AccountQuery.BusinessParticipant_RefID = bParticipant.CMN_BPT_BusinessParticipantID;
            var accountRes = ORM_USR_Account.Query.Search(Connection, Transaction, ORM_USR_AccountQuery);
            if (accountRes.Count == 1)
            {
                account = accountRes[0];
            }
            else
            {
                account = new ORM_USR_Account();
                account.Tenant_RefID = securityTicket.TenantID;
                account.BusinessParticipant_RefID = bParticipant.CMN_BPT_BusinessParticipantID;
                account.AccountType = 3;
                account.Save(Connection, Transaction);
            }

            ORM_USR_Device_AccountCode.Query ORM_USR_Device_AccountCodeQuery = new ORM_USR_Device_AccountCode.Query();
            ORM_USR_Device_AccountCodeQuery.IsDeleted = false;
            ORM_USR_Device_AccountCodeQuery.Tenant_RefID = securityTicket.TenantID;
            ORM_USR_Device_AccountCodeQuery.Account_RefID = account.USR_AccountID;
            var accountCodeRes = ORM_USR_Device_AccountCode.Query.Search(Connection, Transaction, ORM_USR_Device_AccountCodeQuery);
            if (accountCodeRes.Count == 0)
            {
                P_L2DC_GUDCfT_1505 codeParam = new P_L2DC_GUDCfT_1505();
                codeParam.codeLength = 8;
                var checkCodeValue = cls_GetUniqueDeviceCodeForTenant.Invoke(Connection, Transaction, codeParam, securityTicket).Result;

                ORM_USR_Device_AccountCode_StatusHistory AccountCode_StatusHistory = new ORM_USR_Device_AccountCode_StatusHistory();
                AccountCode_StatusHistory.Tenant_RefID = securityTicket.TenantID;
                AccountCode_StatusHistory.IsAccountCode_Active = true;
                AccountCode_StatusHistory.Save(Connection, Transaction);

                ORM_USR_Device_AccountCode devoceAccpimtCpde = new ORM_USR_Device_AccountCode();
                devoceAccpimtCpde.Account_RefID = account.USR_AccountID;
                devoceAccpimtCpde.Tenant_RefID = securityTicket.TenantID;
                devoceAccpimtCpde.AccountCode_Value = checkCodeValue.CodeValue;
                devoceAccpimtCpde.IsAccountCode_Expirable = false;
                devoceAccpimtCpde.AccountCode_CurrentStatus_RefID = AccountCode_StatusHistory.USR_Device_AccountCode_StatusHistoryID;
                devoceAccpimtCpde.Save(Connection, Transaction);

                AccountCode_StatusHistory.Device_AccountCode_RefID = devoceAccpimtCpde.USR_Device_AccountCodeID;
                AccountCode_StatusHistory.Save(Connection, Transaction);
            }

            returnValue.Result = patient.HEC_PatientID;
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L6PA_SMSP_1548 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L6PA_SMSP_1548 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L6PA_SMSP_1548 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6PA_SMSP_1548 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				functionReturn = Execute(Connection, Transaction,Parameter,securityTicket);

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
					if (cleanupTransaction == true && Transaction!=null)
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

				throw new Exception("Exception occured in method cls_Save_MS_Patient",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L6PA_SMSP_1548 for attribute P_L6PA_SMSP_1548
		[DataContract]
		public class P_L6PA_SMSP_1548 
		{
			//Standard type parameters
			[DataMember]
			public string Salutation { get; set; } 
			[DataMember]
			public string FirstName { get; set; } 
			[DataMember]
			public string LastName { get; set; } 
			[DataMember]
			public string Phone { get; set; } 
			[DataMember]
			public string Mail { get; set; } 
			[DataMember]
			public string Fax { get; set; } 
			[DataMember]
			public string Comment { get; set; } 
			[DataMember]
			public string HealthcareNumber { get; set; } 
			[DataMember]
			public bool HasFulfilledParticipationPolicyRequirements { get; set; } 
			[DataMember]
			public Guid HEC_PatientID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_MS_Patient(,P_L6PA_SMSP_1548 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_MS_Patient.Invoke(connectionString,P_L6PA_SMSP_1548 Parameter,securityTicket);
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
var parameter = new CL6_MS_Patient.Complex.Manipulation.P_L6PA_SMSP_1548();
parameter.Salutation = ...;
parameter.FirstName = ...;
parameter.LastName = ...;
parameter.Phone = ...;
parameter.Mail = ...;
parameter.Fax = ...;
parameter.Comment = ...;
parameter.HealthcareNumber = ...;
parameter.HasFulfilledParticipationPolicyRequirements = ...;
parameter.HEC_PatientID = ...;

*/
