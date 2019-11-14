/* 
 * Generated on 12/24/2014 3:12:00 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Linq;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;
using CL1_HEC;
using CL1_ACC_BNK;
using CL1_CMN_BPT;

namespace CL5_MyHealthClub_Patient.Atomic.Manipulation
{
	[Serializable]
	public class cls_Save_PatienHealthInsurance_and_BankData
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5PA_SPHIaBD_1143 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            #region Save
            if (!Parameter.IsDeleted)
            {
                //ORM_HEC_Patient
                var patientQuery = new ORM_HEC_Patient.Query();
                patientQuery.IsDeleted = false;
                patientQuery.Tenant_RefID = securityTicket.TenantID;
                patientQuery.HEC_PatientID = Parameter.PatientID;

                var patient = ORM_HEC_Patient.Query.Search(Connection, Transaction, patientQuery).Single();

                var businessParticipantBank_2_accountQuery = new ORM_CMN_BPT_BusinessParticipant_2_BankAccount.Query();
                businessParticipantBank_2_accountQuery.CMN_BPT_BusinessParticipant_RefID = patient.CMN_BPT_BusinessParticipant_RefID;
                businessParticipantBank_2_accountQuery.IsDeleted = false;
                businessParticipantBank_2_accountQuery.Tenant_RefID = securityTicket.TenantID;

                var businessParticipantBank_2_account = ORM_CMN_BPT_BusinessParticipant_2_BankAccount.Query.Search(Connection, Transaction, businessParticipantBank_2_accountQuery).SingleOrDefault();

                if (businessParticipantBank_2_account == null)
                {
                    //ORM_CMN_BPT_BusinessParticipant_2_BankAccount
                    businessParticipantBank_2_account = new ORM_CMN_BPT_BusinessParticipant_2_BankAccount();
                    businessParticipantBank_2_account.CMN_BPT_BusinessParticipant_RefID = patient.CMN_BPT_BusinessParticipant_RefID;
                    businessParticipantBank_2_account.ACC_BNK_BankAccount_RefID = Guid.NewGuid();
                    businessParticipantBank_2_account.AssignmentID = Guid.NewGuid();
                    businessParticipantBank_2_account.Tenant_RefID = securityTicket.TenantID;
                    businessParticipantBank_2_account.Creation_Timestamp = DateTime.Now;
                    businessParticipantBank_2_account.Save(Connection, Transaction);

                    //ORM_ACC_BNK_BankAccount
                    var bankAccount = new ORM_ACC_BNK_BankAccount();
                    bankAccount.ACC_BNK_BankAccountID = businessParticipantBank_2_account.ACC_BNK_BankAccount_RefID;
                    bankAccount.OwnerText = Parameter.OwnerText;
                    bankAccount.AccountNumber = Parameter.AccountNumber;
                    bankAccount.IBAN = Parameter.IBAN;
                    bankAccount.Bank_RefID = Guid.NewGuid();
                    bankAccount.Tenant_RefID = securityTicket.TenantID;
                    bankAccount.Creation_Timestamp = DateTime.Now;
                    bankAccount.Save(Connection, Transaction);

                    //ORM_ACC_BNK_Bank
                    var bank = new ORM_ACC_BNK_Bank();
                    bank.ACC_BNK_BankID = bankAccount.Bank_RefID;
                    bank.BankName = Parameter.BankName;
                    bank.BICCode = Parameter.BICCode;
                    bank.Tenant_RefID = securityTicket.TenantID;
                    bank.Creation_Timestamp = DateTime.Now;
                    bank.Save(Connection, Transaction);

                    //ORM_HEC_Patient_HealthInsurance
                    var healthInsurance = new ORM_HEC_Patient_HealthInsurance();
                    healthInsurance.HEC_Patient_HealthInsurancesID = Guid.NewGuid();
                    healthInsurance.Patient_RefID = Parameter.PatientID;
                    healthInsurance.HealthInsurance_Number = Parameter.HealthInsurance_Number;
                    healthInsurance.HIS_HealthInsurance_Company_RefID = Parameter.HEC_HealthInsurance_CompanyID;
                    healthInsurance.HealthInsurance_State_RefID = Parameter.HEC_Patient_HealthInsurance_StateID;
                    healthInsurance.InsuranceValidFrom = Parameter.InsuranceValidFrom;
                    healthInsurance.InsuranceValidThrough = Parameter.InsuranceValidThrough;
                    healthInsurance.IsNotSelfInsured = Parameter.IsNotSelfInsured;

                    if (healthInsurance.IsNotSelfInsured)
                    {
                        healthInsurance.IsNotSelfInsured_InsuredPersonBirthday = Parameter.IsNotSelfInsured_InsuredPersonBirthday;
                        healthInsurance.IsNotSelfInsured_InsuredPersonName = Parameter.IsNotSelfInsured_InsuredPersonName;
                    }
                    healthInsurance.Creation_Timestamp = DateTime.Now;
                    healthInsurance.Tenant_RefID = securityTicket.TenantID;
                    healthInsurance.Save(Connection, Transaction);
                }
                else
                {
                    var bankAccountQuery = new ORM_ACC_BNK_BankAccount.Query();
                    bankAccountQuery.IsDeleted = false;
                    bankAccountQuery.Tenant_RefID = securityTicket.TenantID;
                    bankAccountQuery.ACC_BNK_BankAccountID = businessParticipantBank_2_account.ACC_BNK_BankAccount_RefID;

                    var bankAccount = ORM_ACC_BNK_BankAccount.Query.Search(Connection, Transaction, bankAccountQuery).Single();
                    bankAccount.OwnerText = Parameter.OwnerText;
                    bankAccount.AccountNumber = Parameter.AccountNumber;
                    bankAccount.IBAN = Parameter.IBAN;
                    bankAccount.Save(Connection, Transaction);

                    var bankQuery = new ORM_ACC_BNK_Bank.Query();
                    bankQuery.ACC_BNK_BankID = bankAccount.Bank_RefID;
                    bankQuery.IsDeleted = false;
                    bankQuery.Tenant_RefID = securityTicket.TenantID;

                    var bank = ORM_ACC_BNK_Bank.Query.Search(Connection, Transaction, bankQuery).Single();
                    bank.BankName = Parameter.BankName;
                    bank.BICCode = Parameter.BICCode;
                    bank.Save(Connection, Transaction);

                    var healthInsuranceQuery = new ORM_HEC_Patient_HealthInsurance.Query();
                    healthInsuranceQuery.Patient_RefID = patient.HEC_PatientID;
                    healthInsuranceQuery.IsDeleted = false;
                    healthInsuranceQuery.Tenant_RefID = securityTicket.TenantID;

                    var healthInsurance = ORM_HEC_Patient_HealthInsurance.Query.Search(Connection, Transaction, healthInsuranceQuery).Single();
                    healthInsurance.HealthInsurance_Number = Parameter.HealthInsurance_Number;
                    healthInsurance.HIS_HealthInsurance_Company_RefID = Parameter.HEC_HealthInsurance_CompanyID;
                    healthInsurance.HealthInsurance_State_RefID = Parameter.HEC_Patient_HealthInsurance_StateID;
                    healthInsurance.InsuranceValidFrom = Parameter.InsuranceValidFrom;
                    healthInsurance.InsuranceValidThrough = Parameter.InsuranceValidThrough;
                    healthInsurance.IsNotSelfInsured = Parameter.IsNotSelfInsured;
                    healthInsurance.IsNotSelfInsured_InsuredPersonBirthday = Parameter.IsNotSelfInsured_InsuredPersonBirthday;
                    healthInsurance.IsNotSelfInsured_InsuredPersonName = Parameter.IsNotSelfInsured_InsuredPersonName;
                    healthInsurance.Save(Connection, Transaction);
                }
                
            }
            #endregion
            else
            {
                #region delete

                    var patientQuery = new ORM_HEC_Patient.Query();
                    patientQuery.IsDeleted = false;
                    patientQuery.Tenant_RefID = securityTicket.TenantID;
                    patientQuery.HEC_PatientID = Parameter.PatientID;

                    var patient = ORM_HEC_Patient.Query.Search(Connection, Transaction, patientQuery).Single();
                    patient.IsDeleted = true;
                    patient.Save(Connection, Transaction);

                    var businessParticipantBank_2_accountQuery = new ORM_CMN_BPT_BusinessParticipant_2_BankAccount.Query();
                    businessParticipantBank_2_accountQuery.CMN_BPT_BusinessParticipant_RefID = patient.CMN_BPT_BusinessParticipant_RefID;
                    businessParticipantBank_2_accountQuery.IsDeleted = false;
                    businessParticipantBank_2_accountQuery.Tenant_RefID = securityTicket.TenantID;

                    var businessParticipantBank_2_account = ORM_CMN_BPT_BusinessParticipant_2_BankAccount.Query.Search(Connection, Transaction, businessParticipantBank_2_accountQuery).Single();
                    businessParticipantBank_2_account.IsDeleted = true;
                    businessParticipantBank_2_account.Save(Connection, Transaction);

                    var bankAccountQuery = new ORM_ACC_BNK_BankAccount.Query();
                    bankAccountQuery.IsDeleted = false;
                    bankAccountQuery.Tenant_RefID = securityTicket.TenantID;
                    bankAccountQuery.ACC_BNK_BankAccountID = businessParticipantBank_2_account.ACC_BNK_BankAccount_RefID;

                    var bankAccount = ORM_ACC_BNK_BankAccount.Query.Search(Connection, Transaction, bankAccountQuery).Single();
                    bankAccount.IsDeleted = true;
                    bankAccount.Save(Connection, Transaction);

                    var bankQuery = new ORM_ACC_BNK_Bank.Query();
                    bankQuery.ACC_BNK_BankID = bankAccount.Bank_RefID;
                    bankQuery.IsDeleted = false;
                    bankQuery.Tenant_RefID = securityTicket.TenantID;

                    var bank = ORM_ACC_BNK_Bank.Query.Search(Connection, Transaction, bankQuery).Single();
                    bank.IsDeleted = true;
                    bank.Save(Connection, Transaction);

                    var healthInsuranceQuery  = new ORM_HEC_Patient_HealthInsurance.Query();
                    healthInsuranceQuery.Patient_RefID = patient.HEC_PatientID;
                    healthInsuranceQuery.IsDeleted = false;
                    healthInsuranceQuery.Tenant_RefID = securityTicket.TenantID;

                    var healthInsurance = ORM_HEC_Patient_HealthInsurance.Query.Search(Connection, Transaction, healthInsuranceQuery).Single();
                    healthInsurance.IsDeleted = true;
                    healthInsurance.Save(Connection, Transaction);

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
		public static FR_Guid Invoke(string ConnectionString,P_L5PA_SPHIaBD_1143 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5PA_SPHIaBD_1143 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5PA_SPHIaBD_1143 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5PA_SPHIaBD_1143 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw ex;
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5PA_SPHIaBD_1143 for attribute P_L5PA_SPHIaBD_1143
		[Serializable]
		public class P_L5PA_SPHIaBD_1143 
		{
			//Standard type parameters
			public String HealthInsurance_Number; 
			public DateTime InsuranceValidFrom; 
			public DateTime InsuranceValidThrough; 
			public bool IsNotSelfInsured; 
			public String IsNotSelfInsured_InsuredPersonName; 
			public DateTime IsNotSelfInsured_InsuredPersonBirthday; 
			public String CompanyName; 
			public String AccountNumber; 
			public String OwnerText; 
			public String BICCode; 
			public String IBAN; 
			public String BankName; 
			public Guid HEC_Patient_HealthInsurance_StateID; 
			public Guid HEC_HealthInsurance_CompanyID; 
			public bool IsDeleted; 
			public Guid PatientID; 

		}
		#endregion

	#endregion
}
