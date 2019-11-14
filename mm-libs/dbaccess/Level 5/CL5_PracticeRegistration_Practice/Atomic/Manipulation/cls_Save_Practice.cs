/* 
 * Generated on 02.08.2014 12:53:12
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
using CL1_CMN_BPT;
using CL1_CMN_PER;
using CL1_HEC;
using CL1_CMN_COM;
using CL1_ACC_BNK;

namespace CL5_PracticeRegistration_Practice.Atomic.Manipulation
{
	/// <summary>
    /// No description found in <meta/> tag
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Practice.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Practice
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5PR_SP_1538 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            var practice = new ORM_HEC_MedicalPractis()
            {
                HEC_MedicalPractiseID = Guid.NewGuid(),
                Tenant_RefID = securityTicket.TenantID,
                Ext_CompanyInfo_RefID = Guid.NewGuid()
            };
            practice.Save(Connection, Transaction);

            var companyInfo = new ORM_CMN_COM_CompanyInfo()
            {
                CMN_COM_CompanyInfoID = practice.Ext_CompanyInfo_RefID,
                Tenant_RefID = securityTicket.TenantID,
                CompanyInfo_EstablishmentNumber = Parameter.Practice_BSNR
            };
            companyInfo.Save(Connection, Transaction);

            var bParticipant = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, new ORM_CMN_BPT_BusinessParticipant.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                IsTenant = true
            }).Single();

            bParticipant.IsCompany = true;
            bParticipant.IfCompany_CMN_COM_CompanyInfo_RefID = companyInfo.CMN_COM_CompanyInfoID;
            bParticipant.Save(Connection, Transaction);

            if (Parameter.Doctor != null)
            {
                var account2personInfo = ORM_CMN_PER_PersonInfo_2_Account.Query.Search(Connection, Transaction, new ORM_CMN_PER_PersonInfo_2_Account.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false,
                    USR_Account_RefID = Parameter.Doctor.AccountID
                }).Single();

                var query2 = new ORM_CMN_PER_PersonInfo.Query();
                query2.CMN_PER_PersonInfoID = account2personInfo.CMN_PER_PersonInfo_RefID;

                var personInfo = ORM_CMN_PER_PersonInfo.Query.Search(Connection, Transaction, new ORM_CMN_PER_PersonInfo.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false,
                    CMN_PER_PersonInfoID = account2personInfo.CMN_PER_PersonInfo_RefID
                }).First();

                personInfo.FirstName = Parameter.Doctor.FirstName;
                personInfo.LastName = Parameter.Doctor.LastName;
                personInfo.Title = Parameter.Doctor.Title;
                personInfo.Save(Connection, Transaction);

                var bussinessParticipantTable = new ORM_CMN_BPT_BusinessParticipant();
                bussinessParticipantTable.CMN_BPT_BusinessParticipantID = Guid.NewGuid();
                bussinessParticipantTable.IsNaturalPerson = true;
                bussinessParticipantTable.Tenant_RefID = securityTicket.TenantID;
                bussinessParticipantTable.IfNaturalPerson_CMN_PER_PersonInfo_RefID = personInfo.CMN_PER_PersonInfoID;
                bussinessParticipantTable.Save(Connection, Transaction);

                var doctor = new ORM_HEC_Doctor();
                doctor.Tenant_RefID = securityTicket.TenantID;
                doctor.BusinessParticipant_RefID = bussinessParticipantTable.CMN_BPT_BusinessParticipantID;
                doctor.Account_RefID = Parameter.Doctor.AccountID;
                doctor.DoctorIDNumber = Parameter.Doctor.LANR;
                doctor.Save(Connection, Transaction);

                var associatedbusinessparticipants = new ORM_CMN_BPT_BusinessParticipant_AssociatedBusinessParticipant();
                associatedbusinessparticipants.BusinessParticipant_RefID = bussinessParticipantTable.CMN_BPT_BusinessParticipantID;
                associatedbusinessparticipants.AssociatedBusinessParticipant_RefID = bParticipant.CMN_BPT_BusinessParticipantID;
                associatedbusinessparticipants.Tenant_RefID = securityTicket.TenantID;
                associatedbusinessparticipants.Save(Connection, Transaction);

                if (Parameter.Doctor.BankData != null)
                {
                    ORM_CMN_BPT_BusinessParticipant_2_BankAccount bussiness_2_BankaAccount = new ORM_CMN_BPT_BusinessParticipant_2_BankAccount();
                    bussiness_2_BankaAccount.AssignmentID = Guid.NewGuid();
                    bussiness_2_BankaAccount.CMN_BPT_BusinessParticipant_RefID = doctor.BusinessParticipant_RefID;
                    bussiness_2_BankaAccount.ACC_BNK_BankAccount_RefID = Guid.NewGuid();
                    bussiness_2_BankaAccount.Tenant_RefID = securityTicket.TenantID;

                    bussiness_2_BankaAccount.Save(Connection, Transaction);

                    ORM_ACC_BNK_BankAccount bankAccount = new ORM_ACC_BNK_BankAccount();

                    bankAccount.ACC_BNK_BankAccountID = bussiness_2_BankaAccount.ACC_BNK_BankAccount_RefID;
                    bankAccount.Tenant_RefID = securityTicket.TenantID;
                    bankAccount.OwnerText = Parameter.Doctor.BankData.AccountHolder;
                    bankAccount.AccountNumber = Parameter.Doctor.BankData.AccountNumber;
                    bankAccount.IBAN = Parameter.Doctor.BankData.IBAN;
                    bankAccount.Bank_RefID = Guid.NewGuid();

                    bankAccount.Save(Connection, Transaction);

                    ORM_ACC_BNK_Bank bank = new ORM_ACC_BNK_Bank();
                    bank.ACC_BNK_BankID = bankAccount.Bank_RefID;
                    bank.Tenant_RefID = securityTicket.TenantID;
                    bank.BankName = Parameter.Doctor.BankData.BankName;
                    bank.BICCode = Parameter.Doctor.BankData.BIC;
                    bank.BankNumber = Parameter.Doctor.BankData.BankNumber;

                    bank.Save(Connection, Transaction);
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
		public static FR_Guid Invoke(string ConnectionString,P_L5PR_SP_1538 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5PR_SP_1538 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5PR_SP_1538 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5PR_SP_1538 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Practice",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5PR_SP_1538 for attribute P_L5PR_SP_1538
		[DataContract]
		public class P_L5PR_SP_1538 
		{
			[DataMember]
			public P_L5PR_SP_1538_Doctor Doctor { get; set; }
			[DataMember]
			public P_L5PR_SP_1538_ImportWebshopCatalog ImportWebshopCatalog { get; set; }
			[DataMember]
			public P_L5PR_SP_1538_ImportTreatmentCatalog ImportTreatmentCatalog { get; set; }

			//Standard type parameters
			[DataMember]
			public String User_Title { get; set; } 
			[DataMember]
			public String User_FirstName { get; set; } 
			[DataMember]
			public String User_LastName { get; set; } 
			[DataMember]
			public String User_Email { get; set; } 
			[DataMember]
			public String User_Password { get; set; } 
			[DataMember]
			public String Practice_Name { get; set; } 
			[DataMember]
			public String Practice_BSNR { get; set; } 
			[DataMember]
			public String Practice_Street { get; set; } 
			[DataMember]
			public String Practice_StreetNumber { get; set; } 
			[DataMember]
			public String Practice_ZIP { get; set; } 
			[DataMember]
			public String Practice_Town { get; set; } 

		}
		#endregion
		#region SClass P_L5PR_SP_1538_Doctor for attribute Doctor
		[DataContract]
		public class P_L5PR_SP_1538_Doctor 
		{
			[DataMember]
			public P_L5PR_SP_1538_Doctor_BankData BankData { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid AccountID { get; set; } 
			[DataMember]
			public String FirstName { get; set; } 
			[DataMember]
			public String Email { get; set; } 
			[DataMember]
			public String Password { get; set; } 
			[DataMember]
			public String LastName { get; set; } 
			[DataMember]
			public bool IsAdminAccount { get; set; } 
			[DataMember]
			public String LANR { get; set; } 
			[DataMember]
			public String Title { get; set; } 

		}
		#endregion
		#region SClass P_L5PR_SP_1538_Doctor_BankData for attribute BankData
		[DataContract]
		public class P_L5PR_SP_1538_Doctor_BankData 
		{
			//Standard type parameters
			[DataMember]
			public String AccountHolder { get; set; } 
			[DataMember]
			public String BankName { get; set; } 
			[DataMember]
			public String AccountNumber { get; set; } 
			[DataMember]
			public String BankNumber { get; set; } 
			[DataMember]
			public String IBAN { get; set; } 
			[DataMember]
			public String BIC { get; set; } 

		}
		#endregion
		#region SClass P_L5PR_SP_1538_ImportWebshopCatalog for attribute ImportWebshopCatalog
		[DataContract]
		public class P_L5PR_SP_1538_ImportWebshopCatalog 
		{
			//Standard type parameters
			[DataMember]
			public string CatalogCode { get; set; } 
			[DataMember]
			public Guid CustomerTRCompany { get; set; } 

		}
		#endregion
		#region SClass P_L5PR_SP_1538_ImportTreatmentCatalog for attribute ImportTreatmentCatalog
		[DataContract]
		public class P_L5PR_SP_1538_ImportTreatmentCatalog 
		{
			//Standard type parameters
			[DataMember]
			public string CatalogCode { get; set; } 
			[DataMember]
			public Guid BillingTRCompany { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Practice(,P_L5PR_SP_1538 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Practice.Invoke(connectionString,P_L5PR_SP_1538 Parameter,securityTicket);
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
var parameter = new CL5_PracticeRegistration_Practice.Atomic.Manipulation.P_L5PR_SP_1538();
parameter.Doctor = ...;
parameter.ImportWebshopCatalog = ...;
parameter.ImportTreatmentCatalog = ...;

parameter.User_Title = ...;
parameter.User_FirstName = ...;
parameter.User_LastName = ...;
parameter.User_Email = ...;
parameter.User_Password = ...;
parameter.Practice_Name = ...;
parameter.Practice_BSNR = ...;
parameter.Practice_Street = ...;
parameter.Practice_StreetNumber = ...;
parameter.Practice_ZIP = ...;
parameter.Practice_Town = ...;

*/
