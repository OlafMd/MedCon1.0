/* 
 * Generated on 3/24/2014 10:31:57 AM
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
using CL3_Doctors.Atomic.Manipulation;
using CL1_HEC;
using CL1_ACC_BNK;
using CL1_CMN_BPT;

namespace CL5_Lucentis_Diagnosis.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_DoctorLucentis.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_DoctorLucentis
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,PL5DO_SD_1349 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            if (Parameter.isDeleted == true)
            {
                P_L3MD_DDbID_1031 param1 = new P_L3MD_DDbID_1031();
                param1.DoctorID = Parameter.DoctorID;

                var deleteQuery = new ORM_HEC_Patient_Treatment.Query();
                deleteQuery.IsTreatmentPerformed = true;
                deleteQuery.IfTreatmentPerformed_ByDoctor_RefID = Parameter.DoctorID;

                var treatmentsList = ORM_HEC_Patient_Treatment.Query.Search(Connection, Transaction, deleteQuery).ToList();

                foreach (var treatment in treatmentsList)
                {
                    treatment.IsTreatmentPerformed = false;
                    treatment.Save(Connection, Transaction);
                }


                cls_Delete_Doctor_byID.Invoke(Connection, Transaction, param1,securityTicket);
            }

            else
            {
                P_L3MD_SDBI_1349 param = new P_L3MD_SDBI_1349();

                param.Account_RefID = Parameter.Account_RefID;
                param.DoctorID = Parameter.DoctorID;
                param.Title = Parameter.Title;
                param.FirstName = Parameter.FirstName;
                param.LastName = Parameter.LastName;
                param.ifLucentis_LoginEmail = Parameter.LoginEmail;
                param.isLucentisSave = true;
                param.ifLucentis_LANR = Parameter.ifLucentis_LANR;

                List<P_L3MD_SDBI_1349_Practice> practiceNewList = new List<P_L3MD_SDBI_1349_Practice>();

                foreach(var practice in Parameter.Practices){

                    P_L3MD_SDBI_1349_Practice practiceNew = new P_L3MD_SDBI_1349_Practice();
                    practiceNew.AssociatedParticipant_FunctionName = practice.AssociatedParticipant_FunctionName;
                    practiceNew.isDeleted = practice.isDeleted;
                    practiceNew.PracticeID = practice.PracticeID;
                    practiceNewList.Add(practiceNew);
                }

                

                param.Practices = practiceNewList.ToArray();



                List<P_L3MD_SDBI_1349_Contacts> contactsNewList = new List<P_L3MD_SDBI_1349_Contacts>();

                foreach (var contact in Parameter.Contacts)
                {
                    P_L3MD_SDBI_1349_Contacts contactNew = new P_L3MD_SDBI_1349_Contacts();
                    contactNew.CMN_PER_CommunicationContact_TypeID = contact.CMN_PER_CommunicationContact_TypeID;
                    contactNew.Content = contact.Content;
                    contactsNewList.Add(contactNew);
                }


                param.Contacts = contactsNewList.ToArray();


                Guid Hec_Doctor_ID = cls_Save_Doctor_BaseInfo.Invoke(Connection, Transaction, param, securityTicket).Result;


                if (Parameter.DoctorID != Guid.Empty)
                {
                    #region Edit

                    var doctorQuery = new ORM_HEC_Doctor.Query();

                    doctorQuery.IsDeleted = false;
                    doctorQuery.HEC_DoctorID = Hec_Doctor_ID;

                    var doctor = ORM_HEC_Doctor.Query.Search(Connection, Transaction, doctorQuery).FirstOrDefault();

                    if (doctor != null)
                    {
                        var bussiness_2_BankaAccountQuery = new ORM_CMN_BPT_BusinessParticipant_2_BankAccount.Query();
                        bussiness_2_BankaAccountQuery.IsDeleted = false;
                        bussiness_2_BankaAccountQuery.CMN_BPT_BusinessParticipant_RefID = doctor.BusinessParticipant_RefID;

                        var bussiness_2_BankaAccount = ORM_CMN_BPT_BusinessParticipant_2_BankAccount.Query.Search(Connection, Transaction, bussiness_2_BankaAccountQuery).FirstOrDefault();

                        if (bussiness_2_BankaAccount != null)
                        {
                            var bankAccountQuery = new ORM_ACC_BNK_BankAccount.Query();
                            bankAccountQuery.IsDeleted = false;
                            bankAccountQuery.ACC_BNK_BankAccountID = bussiness_2_BankaAccount.ACC_BNK_BankAccount_RefID;

                            var bankAccount = ORM_ACC_BNK_BankAccount.Query.Search(Connection, Transaction, bankAccountQuery).FirstOrDefault();


                            bankAccount.OwnerText = Parameter.AccountHolder;
                            bankAccount.AccountNumber = Parameter.AccountNumber;
                            bankAccount.IBAN = Parameter.IBAN;
                            bankAccount.Save(Connection, Transaction);


                            var bankQuery = new ORM_ACC_BNK_Bank.Query();
                            bankQuery.IsDeleted = false;
                            bankQuery.ACC_BNK_BankID = bankAccount.Bank_RefID;

                            var bank = ORM_ACC_BNK_Bank.Query.Search(Connection, Transaction, bankQuery).FirstOrDefault();


                            bank.BankName = Parameter.BankName;
                            bank.BICCode = Parameter.BIC;
                            bank.BankNumber = Parameter.BankNumber;
                            bank.Save(Connection, Transaction);
                        }
                        else
                        {
                            ORM_CMN_BPT_BusinessParticipant_2_BankAccount bussiness_2_BankaAccount1 = new ORM_CMN_BPT_BusinessParticipant_2_BankAccount();
                            bussiness_2_BankaAccount1.AssignmentID = Guid.NewGuid();
                            bussiness_2_BankaAccount1.CMN_BPT_BusinessParticipant_RefID = doctor.BusinessParticipant_RefID;
                            bussiness_2_BankaAccount1.ACC_BNK_BankAccount_RefID = Guid.NewGuid();
                            bussiness_2_BankaAccount1.Creation_Timestamp = DateTime.Now;
                            bussiness_2_BankaAccount1.Tenant_RefID = securityTicket.TenantID;
                            bussiness_2_BankaAccount1.IsDeleted = false;

                            bussiness_2_BankaAccount1.Save(Connection, Transaction);

                            ORM_ACC_BNK_BankAccount bankAccount = new ORM_ACC_BNK_BankAccount();

                            bankAccount.ACC_BNK_BankAccountID = bussiness_2_BankaAccount1.ACC_BNK_BankAccount_RefID;
                            bankAccount.Creation_Timestamp = DateTime.Now;
                            bankAccount.Tenant_RefID = securityTicket.TenantID;
                            bankAccount.OwnerText = Parameter.AccountHolder;
                            bankAccount.AccountNumber = Parameter.AccountNumber;
                            bankAccount.IBAN = Parameter.IBAN;
                            bankAccount.Bank_RefID = Guid.NewGuid();
                            bankAccount.IsDeleted = false;

                            bankAccount.Save(Connection, Transaction);

                            ORM_ACC_BNK_Bank bank = new ORM_ACC_BNK_Bank();
                            bank.ACC_BNK_BankID = bankAccount.Bank_RefID;
                            bank.Tenant_RefID = securityTicket.TenantID;
                            bank.IsDeleted = false;
                            bank.Creation_Timestamp = DateTime.Now;
                            bank.BankName = Parameter.BankName;
                            bank.BICCode = Parameter.BIC;
                            bank.BankNumber = Parameter.BankNumber;

                            bank.Save(Connection, Transaction);
                        }
                    }


                    #endregion
                }
                else
                {
                    #region Save

                    var doctorQuery = new ORM_HEC_Doctor.Query();

                    doctorQuery.IsDeleted = false;
                    doctorQuery.HEC_DoctorID = Hec_Doctor_ID;

                    var doctor = ORM_HEC_Doctor.Query.Search(Connection, Transaction, doctorQuery).FirstOrDefault();

                    if (doctor != null)
                    {
                        ORM_CMN_BPT_BusinessParticipant_2_BankAccount bussiness_2_BankaAccount = new ORM_CMN_BPT_BusinessParticipant_2_BankAccount();
                        bussiness_2_BankaAccount.AssignmentID = Guid.NewGuid();
                        bussiness_2_BankaAccount.CMN_BPT_BusinessParticipant_RefID = doctor.BusinessParticipant_RefID;
                        bussiness_2_BankaAccount.ACC_BNK_BankAccount_RefID = Guid.NewGuid();
                        bussiness_2_BankaAccount.Creation_Timestamp = DateTime.Now;
                        bussiness_2_BankaAccount.Tenant_RefID = securityTicket.TenantID;
                        bussiness_2_BankaAccount.IsDeleted = false;

                        bussiness_2_BankaAccount.Save(Connection, Transaction);

                        ORM_ACC_BNK_BankAccount bankAccount = new ORM_ACC_BNK_BankAccount();

                        bankAccount.ACC_BNK_BankAccountID = bussiness_2_BankaAccount.ACC_BNK_BankAccount_RefID;
                        bankAccount.Creation_Timestamp = DateTime.Now;
                        bankAccount.Tenant_RefID = securityTicket.TenantID;
                        bankAccount.OwnerText = Parameter.AccountHolder;
                        bankAccount.AccountNumber = Parameter.AccountNumber;
                        bankAccount.IBAN = Parameter.IBAN;
                        bankAccount.Bank_RefID = Guid.NewGuid();
                        bankAccount.IsDeleted = false;

                        bankAccount.Save(Connection, Transaction);

                        ORM_ACC_BNK_Bank bank = new ORM_ACC_BNK_Bank();
                        bank.ACC_BNK_BankID = bankAccount.Bank_RefID;
                        bank.Tenant_RefID = securityTicket.TenantID;
                        bank.IsDeleted = false;
                        bank.Creation_Timestamp = DateTime.Now;
                        bank.BankName = Parameter.BankName;
                        bank.BICCode = Parameter.BIC;
                        bank.BankNumber = Parameter.BankNumber;

                        bank.Save(Connection, Transaction);

                    }

                    #endregion
                }

                returnValue.Result = Hec_Doctor_ID;
            }
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,PL5DO_SD_1349 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,PL5DO_SD_1349 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,PL5DO_SD_1349 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,PL5DO_SD_1349 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_DoctorLucentis",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass PL5DO_SD_1349 for attribute PL5DO_SD_1349
		[DataContract]
		public class PL5DO_SD_1349 
		{
			[DataMember]
			public PL5DO_SD_1349_Practice[] Practices { get; set; }
			[DataMember]
			public PL5DO_SD_1349_Contacts[] Contacts { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid DoctorID { get; set; } 
			[DataMember]
			public Guid Account_RefID { get; set; } 
			[DataMember]
			public String Title { get; set; } 
			[DataMember]
			public String FirstName { get; set; } 
			[DataMember]
			public String LastName { get; set; } 
			[DataMember]
			public String LoginEmail { get; set; } 
			[DataMember]
			public Boolean isOphthalSave { get; set; } 
			[DataMember]
			public String ifOphthal_Salutation_General { get; set; } 
			[DataMember]
			public String ifOphthal_Salutation_Letter { get; set; } 
			[DataMember]
			public Boolean isLucentisSave { get; set; } 
			[DataMember]
			public String ifLucentis_LANR { get; set; } 
			[DataMember]
			public String AccountHolder { get; set; } 
			[DataMember]
			public String BankNumber { get; set; } 
			[DataMember]
			public String AccountNumber { get; set; } 
			[DataMember]
			public String BankName { get; set; } 
			[DataMember]
			public String BIC { get; set; } 
			[DataMember]
			public String IBAN { get; set; } 
			[DataMember]
			public bool isDeleted { get; set; } 

		}
		#endregion
		#region SClass PL5DO_SD_1349_Practice for attribute Practices
		[DataContract]
		public class PL5DO_SD_1349_Practice 
		{
			//Standard type parameters
			[DataMember]
			public Guid PracticeID { get; set; } 
			[DataMember]
			public Boolean isDeleted { get; set; } 
			[DataMember]
			public String AssociatedParticipant_FunctionName { get; set; } 

		}
		#endregion
		#region SClass PL5DO_SD_1349_Contacts for attribute Contacts
		[DataContract]
		public class PL5DO_SD_1349_Contacts 
		{
			//Standard type parameters
			[DataMember]
			public String Content { get; set; } 
			[DataMember]
			public Guid CMN_PER_CommunicationContact_TypeID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_DoctorLucentis(,PL5DO_SD_1349 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_DoctorLucentis.Invoke(connectionString,PL5DO_SD_1349 Parameter,securityTicket);
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
var parameter = new CL5_Lucentis_Diagnosis.Complex.Manipulation.PL5DO_SD_1349();
parameter.Practices = ...;
parameter.Contacts = ...;

parameter.DoctorID = ...;
parameter.Account_RefID = ...;
parameter.Title = ...;
parameter.FirstName = ...;
parameter.LastName = ...;
parameter.LoginEmail = ...;
parameter.isOphthalSave = ...;
parameter.ifOphthal_Salutation_General = ...;
parameter.ifOphthal_Salutation_Letter = ...;
parameter.isLucentisSave = ...;
parameter.ifLucentis_LANR = ...;
parameter.AccountHolder = ...;
parameter.BankNumber = ...;
parameter.AccountNumber = ...;
parameter.BankName = ...;
parameter.BIC = ...;
parameter.IBAN = ...;
parameter.isDeleted = ...;

*/
