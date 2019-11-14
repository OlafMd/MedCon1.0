/* 
 * Generated on 21.5.2015 15:18:40
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
using BOp.Providers.TMS.Requests;
using CL1_USR;
using CL1_HEC;
using DataImporter.DBMethods.ExportData.Atomic.Retrieval;
using CL1_CMN_BPT;
using CL1_CMN_PER;
using CL1_CMN_BPT_CTM;
using CL1_ACC_BNK;
using System.Threading;
using BOp.Providers.TMS;
using BOp.Providers;
using System.Globalization;
using CL1_CMN_COM;
using DataImporter.Models;
using CL1_CMN;
using MMDocConnectElasticSearchMethods.Doctor.Manipulation;
using DataImporter.Methods;

namespace DataImporter.DBMethods.ExportData.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Doctor.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Doctor
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_DO_SD_1517 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Guid();
			//Put your code here
	     	Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("de-DE");
			Guid BusinessParticipantID = Guid.NewGuid();
			Guid personInfoID = Guid.NewGuid();
			Guid PracticeCustomerID = Guid.NewGuid();
			Guid PracticeBusinessParticipantID = Guid.NewGuid();
			Guid PracticeCompanyInfoID = Guid.NewGuid();
			String PracticeName = "";
			Guid BankAccountID = Guid.Empty;
			Guid doctor_id = Parameter.DoctorID;
			var isOpPractice = false;

				//if (!String.IsNullOrEmpty(Parameter.Login_Email))
			//uncomment this if you've created account
            if(false)	
            {
					string[] stringUser = Parameter.Login_Email.Split('@');
					string usernameStr = stringUser[0];
			
                    try
					{

						var doctorAccountInfo = ORM_USR_Account.Query.Search(Connection, Transaction, new ORM_USR_Account.Query()
						{
							IsDeleted = false,
							Tenant_RefID = securityTicket.TenantID,
							AccountSignInEmailAddress = Parameter.Login_Email,
						}).Single();

						var accountGroupQuery = new ORM_USR_Account_FunctionLevelRights_Group.Query();
						accountGroupQuery.Tenant_RefID = securityTicket.TenantID;
						accountGroupQuery.IsDeleted = false;
						accountGroupQuery.GlobalPropertyMatchingID = "mm.docconect.doc.app.group";

						var accountGroup = ORM_USR_Account_FunctionLevelRights_Group.Query.Search(Connection, Transaction, accountGroupQuery).SingleOrDefault();

						if (accountGroup == null)
						{
							accountGroup = new ORM_USR_Account_FunctionLevelRights_Group();
							accountGroup.Tenant_RefID = securityTicket.TenantID;
							accountGroup.Label = "mm.docconect.doc.app.group";
							accountGroup.GlobalPropertyMatchingID = "mm.docconect.doc.app.group";
							accountGroup.Creation_Timestamp = DateTime.Now;
							accountGroup.USR_Account_FunctionLevelRights_GroupID = Guid.NewGuid();
							accountGroup.Save(Connection, Transaction);
						}

						var PracticeAccount2UniversalProperty = ORM_HEC_MedicalPractice_2_UniversalProperty.Query.Search(Connection, Transaction, new ORM_HEC_MedicalPractice_2_UniversalProperty.Query()
						{
							IsDeleted = false,
							Tenant_RefID = securityTicket.TenantID,
							HEC_MedicalPractice_RefID = Parameter.PracticeID
						}).ToList();

						List<ORM_HEC_MedicalPractice_UniversalProperty> PracticeUniversalPropertyList = new List<ORM_HEC_MedicalPractice_UniversalProperty>();
						foreach (var item in PracticeAccount2UniversalProperty)
						{
							var PracticeUniversalProperty = ORM_HEC_MedicalPractice_UniversalProperty.Query.Search(Connection, Transaction, new ORM_HEC_MedicalPractice_UniversalProperty.Query()
							{
								IsDeleted = false,
								Tenant_RefID = securityTicket.TenantID,
								HEC_MedicalPractice_UniversalPropertyID = item.HEC_MedicalPractice_UniversalProperty_RefID
							}).Single();
							PracticeUniversalPropertyList.Add(PracticeUniversalProperty);
						};

                        P_DO_GPAIDfPID_1522 practiceAccountIDParameter = new P_DO_GPAIDfPID_1522();
						practiceAccountIDParameter.PracticeID = Parameter.PracticeID;

						var practiceAccountToFunctionLevelRightQ = new ORM_USR_Account_2_FunctionLevelRight.Query();
						practiceAccountToFunctionLevelRightQ.Account_RefID = cls_Get_Practice_AccountID_for_PracticeID.Invoke(Connection, Transaction, practiceAccountIDParameter, securityTicket).Result.accountID;
						practiceAccountToFunctionLevelRightQ.Tenant_RefID = securityTicket.TenantID;
						practiceAccountToFunctionLevelRightQ.IsDeleted = false;

						var practiceAccountToFunctionLevelRight = ORM_USR_Account_2_FunctionLevelRight.Query.Search(Connection, Transaction, practiceAccountToFunctionLevelRightQ).SingleOrDefault();

						if (practiceAccountToFunctionLevelRight != null)
						{
							var practiceAccountFunctionLevelRightQ = new ORM_USR_Account_FunctionLevelRight.Query();
							practiceAccountFunctionLevelRightQ.Tenant_RefID = securityTicket.TenantID;
							practiceAccountFunctionLevelRightQ.IsDeleted = false;
							practiceAccountFunctionLevelRightQ.USR_Account_FunctionLevelRightID = practiceAccountToFunctionLevelRight.FunctionLevelRight_RefID;

							var practiceAccountFunctionLevelRight = ORM_USR_Account_FunctionLevelRight.Query.Search(Connection, Transaction, practiceAccountFunctionLevelRightQ).SingleOrDefault();

							if (practiceAccountFunctionLevelRight != null)
							{
								isOpPractice = practiceAccountFunctionLevelRight.GlobalPropertyMatchingID.Equals("mm.docconect.doc.app.op.practice");
							}
						}

						var functionLevelRightQ = new ORM_USR_Account_FunctionLevelRight.Query();
						functionLevelRightQ.Tenant_RefID = securityTicket.TenantID;
						functionLevelRightQ.IsDeleted = false;
						functionLevelRightQ.GlobalPropertyMatchingID = isOpPractice ? "mm.docconect.doc.app.op.doctor" : "mm.docconect.doc.app.ac.doctor";

						var existingFunctionLevelRight = ORM_USR_Account_FunctionLevelRight.Query.Search(Connection, Transaction, functionLevelRightQ).SingleOrDefault();

						var tempFunctionLevelRightID = Guid.Empty;

						if (existingFunctionLevelRight == null)
						{
							ORM_USR_Account_FunctionLevelRight functionLevelRight = new ORM_USR_Account_FunctionLevelRight();
							functionLevelRight.USR_Account_FunctionLevelRightID = Guid.NewGuid();
							functionLevelRight.FunctionLevelRights_Group_RefID = accountGroup.USR_Account_FunctionLevelRights_GroupID;
							functionLevelRight.Tenant_RefID = securityTicket.TenantID;
							functionLevelRight.Creation_Timestamp = DateTime.Now;

							functionLevelRight.RightName = isOpPractice ? "mm.docconect.doc.app.op.doctor" : "mm.docconect.doc.app.ac.doctor";
							functionLevelRight.GlobalPropertyMatchingID = isOpPractice ? "mm.docconect.doc.app.op.doctor" : "mm.docconect.doc.app.ac.doctor";

							functionLevelRight.Save(Connection, Transaction);

							tempFunctionLevelRightID = functionLevelRight.USR_Account_FunctionLevelRightID;
						}
						else
						{
							tempFunctionLevelRightID = existingFunctionLevelRight.USR_Account_FunctionLevelRightID;
						}

						var accountToFunctionLevelRight = new ORM_USR_Account_2_FunctionLevelRight();
						accountToFunctionLevelRight.Tenant_RefID = securityTicket.TenantID;
						accountToFunctionLevelRight.Creation_Timestamp = DateTime.Now;
						accountToFunctionLevelRight.AssignmentID = Guid.NewGuid();
						accountToFunctionLevelRight.Account_RefID = doctorAccountInfo.USR_AccountID;
						accountToFunctionLevelRight.FunctionLevelRight_RefID = tempFunctionLevelRightID;

						accountToFunctionLevelRight.Save(Connection, Transaction);

						var businessParticipantQ = new ORM_CMN_BPT_BusinessParticipant.Query();

						businessParticipantQ.IsDeleted = false;
						businessParticipantQ.Tenant_RefID = securityTicket.TenantID;
						businessParticipantQ.CMN_BPT_BusinessParticipantID = doctorAccountInfo.BusinessParticipant_RefID;
						BusinessParticipantID = doctorAccountInfo.BusinessParticipant_RefID;

						var DoctorBusinessParticipant = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, businessParticipantQ).Single();
						DoctorBusinessParticipant.IfNaturalPerson_CMN_PER_PersonInfo_RefID = Guid.NewGuid();
						DoctorBusinessParticipant.DisplayName = Parameter.First_Name + " " + Parameter.Last_Name;
						DoctorBusinessParticipant.IsNaturalPerson = true;
						DoctorBusinessParticipant.Modification_Timestamp = DateTime.Now;
						DoctorBusinessParticipant.Save(Connection, Transaction);
						personInfoID = DoctorBusinessParticipant.IfNaturalPerson_CMN_PER_PersonInfo_RefID;


						var companyInfoPractice = new ORM_CMN_PER_PersonInfo();
						companyInfoPractice.IsDeleted = false;
						companyInfoPractice.Tenant_RefID = securityTicket.TenantID;
						companyInfoPractice.CMN_PER_PersonInfoID = personInfoID;
						companyInfoPractice.FirstName = Parameter.First_Name;
						companyInfoPractice.LastName = Parameter.Last_Name;
						companyInfoPractice.Salutation_General = Parameter.Salutation;
						companyInfoPractice.Title = Parameter.Title;
						companyInfoPractice.Save(Connection, Transaction);

						var communicationContact = new ORM_CMN_PER_CommunicationContact();
						communicationContact.IsDeleted = false;
						communicationContact.Contact_Type = Guid.NewGuid();
						communicationContact.Tenant_RefID = securityTicket.TenantID;
						communicationContact.Modification_Timestamp = DateTime.Now;
						communicationContact.PersonInfo_RefID = personInfoID;
						communicationContact.Content = Parameter.Email;
						communicationContact.Save(Connection, Transaction);
						Guid CommunicationContactTypeID = communicationContact.Contact_Type;


						var communicationContactType = new ORM_CMN_PER_CommunicationContact_Type();
						communicationContactType.IsDeleted = false;
						communicationContactType.Tenant_RefID = securityTicket.TenantID;
						communicationContactType.CMN_PER_CommunicationContact_TypeID = CommunicationContactTypeID;
						communicationContactType.Type = "Email";
						communicationContactType.Save(Connection, Transaction);

						var communicationContact2 = new ORM_CMN_PER_CommunicationContact();
						communicationContact2.IsDeleted = false;
						communicationContact2.Contact_Type = Guid.NewGuid();
						communicationContact2.Tenant_RefID = securityTicket.TenantID;
						communicationContact2.Modification_Timestamp = DateTime.Now;
						communicationContact2.PersonInfo_RefID = personInfoID;
						communicationContact2.Content = Parameter.Phone;
						communicationContact2.Save(Connection, Transaction);
						Guid CommunicationContactTypeID2 = communicationContact2.Contact_Type;


						var communicationContactType2 = new ORM_CMN_PER_CommunicationContact_Type();
						communicationContactType2.IsDeleted = false;
						communicationContactType2.Tenant_RefID = securityTicket.TenantID;
						communicationContactType2.CMN_PER_CommunicationContact_TypeID = CommunicationContactTypeID2;
						communicationContactType2.Type = "Phone";
						communicationContactType2.Save(Connection, Transaction);

						var doctor = new ORM_HEC_Doctor();
						doctor.HEC_DoctorID = Guid.NewGuid();
						doctor.IsDeleted = false;
						doctor.Tenant_RefID = securityTicket.TenantID;
						doctor.BusinessParticipant_RefID = BusinessParticipantID;
						doctor.DoctorIDNumber = Parameter.LANR.ToString();
						doctor.Save(Connection, Transaction);

						doctor_id = doctor.HEC_DoctorID;

						var ogranizationUnitPractice = ORM_CMN_BPT_CTM_OrganizationalUnit.Query.Search(Connection, Transaction, new ORM_CMN_BPT_CTM_OrganizationalUnit.Query()
						{
							IsDeleted = false,
							Tenant_RefID = securityTicket.TenantID,
							IfMedicalPractise_HEC_MedicalPractice_RefID = Parameter.PracticeID
						}).Single();


						var organizationalunit_Staff = new ORM_CMN_BPT_CTM_OrganizationalUnit_Staff();
						organizationalunit_Staff.IsDeleted = false;
						organizationalunit_Staff.Tenant_RefID = securityTicket.TenantID;
						organizationalunit_Staff.BusinessParticipant_RefID = BusinessParticipantID;
						organizationalunit_Staff.OrganizationalUnit_RefID = ogranizationUnitPractice.CMN_BPT_CTM_OrganizationalUnitID;
						organizationalunit_Staff.Save(Connection, Transaction);

						var CustomerPRactice = ORM_CMN_BPT_CTM_Customer.Query.Search(Connection, Transaction, new ORM_CMN_BPT_CTM_Customer.Query()
						{
							IsDeleted = false,
							Tenant_RefID = securityTicket.TenantID,
							CMN_BPT_CTM_CustomerID = ogranizationUnitPractice.Customer_RefID
						}).Single();
						var PracticeBusinessParticipant = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, new ORM_CMN_BPT_BusinessParticipant.Query()
						{
							IsDeleted = false,
							Tenant_RefID = securityTicket.TenantID,
							CMN_BPT_BusinessParticipantID = CustomerPRactice.Ext_BusinessParticipant_RefID
						}).Single();

						PracticeName = PracticeBusinessParticipant.DisplayName;
						PracticeBusinessParticipantID = PracticeBusinessParticipant.CMN_BPT_BusinessParticipantID;
						PracticeCompanyInfoID = PracticeBusinessParticipant.IfCompany_CMN_COM_CompanyInfo_RefID;

						if (Parameter.From_Practice_Bank)
						{

							var PracticeBusinessParticipant2bankaccount = ORM_CMN_BPT_BusinessParticipant_2_BankAccount.Query.Search(Connection, Transaction, new ORM_CMN_BPT_BusinessParticipant_2_BankAccount.Query()
							{
								IsDeleted = false,
								Tenant_RefID = securityTicket.TenantID,
								CMN_BPT_BusinessParticipant_RefID = PracticeBusinessParticipant.CMN_BPT_BusinessParticipantID,
							}).Single();


							var business2bankAccount = new ORM_CMN_BPT_BusinessParticipant_2_BankAccount();
							business2bankAccount.IsDeleted = false;
							business2bankAccount.Tenant_RefID = securityTicket.TenantID;
							business2bankAccount.CMN_BPT_BusinessParticipant_RefID = BusinessParticipantID;
							business2bankAccount.ACC_BNK_BankAccount_RefID = PracticeBusinessParticipant2bankaccount.ACC_BNK_BankAccount_RefID;
							business2bankAccount.Creation_Timestamp = DateTime.Now;
							business2bankAccount.Save(Connection, Transaction);

							BankAccountID = PracticeBusinessParticipant2bankaccount.ACC_BNK_BankAccount_RefID;
							//end of save bank data if inherited from practice   
						}
						else
						{
							if (!String.IsNullOrEmpty(Parameter.IBAN) || !String.IsNullOrEmpty(Parameter.Bank))
							{
								var business2bankAccount = new ORM_CMN_BPT_BusinessParticipant_2_BankAccount();
								business2bankAccount.IsDeleted = false;
								business2bankAccount.Tenant_RefID = securityTicket.TenantID;
								business2bankAccount.CMN_BPT_BusinessParticipant_RefID = BusinessParticipantID;
								business2bankAccount.ACC_BNK_BankAccount_RefID = Guid.NewGuid();
								business2bankAccount.Creation_Timestamp = DateTime.Now;
								business2bankAccount.Save(Connection, Transaction);

								var bankAccountDoctor = new ORM_ACC_BNK_BankAccount();
								bankAccountDoctor.IsDeleted = false;
								bankAccountDoctor.Tenant_RefID = securityTicket.TenantID;
								bankAccountDoctor.ACC_BNK_BankAccountID = business2bankAccount.ACC_BNK_BankAccount_RefID;
								bankAccountDoctor.OwnerText = Parameter.Account_Holder;
								bankAccountDoctor.IBAN = Parameter.IBAN;
								bankAccountDoctor.Bank_RefID = Guid.NewGuid();
								bankAccountDoctor.Creation_Timestamp = DateTime.Now;
								bankAccountDoctor.Save(Connection, Transaction);

								if (!String.IsNullOrEmpty(Parameter.Bank))
								{
									var bank = new ORM_ACC_BNK_Bank();
									bank.IsDeleted = false;
									bank.Tenant_RefID = securityTicket.TenantID;
									bank.ACC_BNK_BankID = bankAccountDoctor.Bank_RefID;
									bank.BICCode = Parameter.BIC;
									bank.BankName = Parameter.Bank;
									bank.Creation_Timestamp = DateTime.Now;
									bank.Save(Connection, Transaction);
								}

								BankAccountID = business2bankAccount.ACC_BNK_BankAccount_RefID;
								// end save bank data
							}
						}
					}
					catch
					{
						throw new Exception();
					}
				}
				else
				{
					var DoctorBusinessParticipant = new ORM_CMN_BPT_BusinessParticipant();

					DoctorBusinessParticipant.IsDeleted = false;
					DoctorBusinessParticipant.Tenant_RefID = securityTicket.TenantID;
					DoctorBusinessParticipant.CMN_BPT_BusinessParticipantID = Guid.NewGuid();
					DoctorBusinessParticipant.IfNaturalPerson_CMN_PER_PersonInfo_RefID = Guid.NewGuid();
					DoctorBusinessParticipant.DisplayName = Parameter.First_Name + " " + Parameter.Last_Name;
					DoctorBusinessParticipant.IsNaturalPerson = true;
					DoctorBusinessParticipant.Modification_Timestamp = DateTime.Now;
					DoctorBusinessParticipant.Save(Connection, Transaction);
					personInfoID = DoctorBusinessParticipant.IfNaturalPerson_CMN_PER_PersonInfo_RefID;
					BusinessParticipantID = DoctorBusinessParticipant.CMN_BPT_BusinessParticipantID;

					var companyInfoPractice = new ORM_CMN_PER_PersonInfo();
					companyInfoPractice.IsDeleted = false;
					companyInfoPractice.Tenant_RefID = securityTicket.TenantID;
					companyInfoPractice.CMN_PER_PersonInfoID = personInfoID;
					companyInfoPractice.FirstName = Parameter.First_Name;
					companyInfoPractice.LastName = Parameter.Last_Name;
					companyInfoPractice.Salutation_General = Parameter.Salutation;
					companyInfoPractice.Title = Parameter.Title;
					companyInfoPractice.Save(Connection, Transaction);

					var communicationContact = new ORM_CMN_PER_CommunicationContact();
					communicationContact.IsDeleted = false;
					communicationContact.Contact_Type = Guid.NewGuid();
					communicationContact.Tenant_RefID = securityTicket.TenantID;
					communicationContact.Modification_Timestamp = DateTime.Now;
					communicationContact.PersonInfo_RefID = personInfoID;
					communicationContact.Content = Parameter.Email;
					communicationContact.Save(Connection, Transaction);
					Guid CommunicationContactTypeID = communicationContact.Contact_Type;

					var communicationContactType = new ORM_CMN_PER_CommunicationContact_Type();
					communicationContactType.IsDeleted = false;
					communicationContactType.Tenant_RefID = securityTicket.TenantID;
					communicationContactType.CMN_PER_CommunicationContact_TypeID = CommunicationContactTypeID;
					communicationContactType.Type = "Email";
					communicationContactType.Save(Connection, Transaction);

					var communicationContact2 = new ORM_CMN_PER_CommunicationContact();
					communicationContact2.IsDeleted = false;
					communicationContact2.Contact_Type = Guid.NewGuid();
					communicationContact2.Tenant_RefID = securityTicket.TenantID;
					communicationContact2.Modification_Timestamp = DateTime.Now;
					communicationContact2.PersonInfo_RefID = personInfoID;
					communicationContact2.Content = Parameter.Phone;
					communicationContact2.Save(Connection, Transaction);
					Guid CommunicationContactTypeID2 = communicationContact2.Contact_Type;


					var communicationContactType2 = new ORM_CMN_PER_CommunicationContact_Type();
					communicationContactType2.IsDeleted = false;
					communicationContactType2.Tenant_RefID = securityTicket.TenantID;
					communicationContactType2.CMN_PER_CommunicationContact_TypeID = CommunicationContactTypeID2;
					communicationContactType2.Type = "Phone";
					communicationContactType2.Save(Connection, Transaction);

					var doctor = new ORM_HEC_Doctor();
					doctor.HEC_DoctorID = Guid.NewGuid();
					doctor.IsDeleted = false;
					doctor.Tenant_RefID = securityTicket.TenantID;
					doctor.BusinessParticipant_RefID = BusinessParticipantID;
					doctor.DoctorIDNumber = Parameter.LANR.ToString();
					doctor.Save(Connection, Transaction);

					doctor_id = doctor.HEC_DoctorID;

					var ogranizationUnitPractice = ORM_CMN_BPT_CTM_OrganizationalUnit.Query.Search(Connection, Transaction, new ORM_CMN_BPT_CTM_OrganizationalUnit.Query()
					{
						IsDeleted = false,
						Tenant_RefID = securityTicket.TenantID,
						IfMedicalPractise_HEC_MedicalPractice_RefID = Parameter.PracticeID
					}).Single();


					var organizationalunit_Staff = new ORM_CMN_BPT_CTM_OrganizationalUnit_Staff();
					organizationalunit_Staff.IsDeleted = false;
					organizationalunit_Staff.Tenant_RefID = securityTicket.TenantID;
					organizationalunit_Staff.BusinessParticipant_RefID = BusinessParticipantID;
					organizationalunit_Staff.OrganizationalUnit_RefID = ogranizationUnitPractice.CMN_BPT_CTM_OrganizationalUnitID;
					organizationalunit_Staff.Save(Connection, Transaction);


					var CustomerPRactice = ORM_CMN_BPT_CTM_Customer.Query.Search(Connection, Transaction, new ORM_CMN_BPT_CTM_Customer.Query()
					{
						IsDeleted = false,
						Tenant_RefID = securityTicket.TenantID,
						CMN_BPT_CTM_CustomerID = ogranizationUnitPractice.Customer_RefID
					}).Single();
					var PracticeBusinessParticipant = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, new ORM_CMN_BPT_BusinessParticipant.Query()
					{
						IsDeleted = false,
						Tenant_RefID = securityTicket.TenantID,
						CMN_BPT_BusinessParticipantID = CustomerPRactice.Ext_BusinessParticipant_RefID
					}).Single();
					PracticeName = PracticeBusinessParticipant.DisplayName;
					PracticeBusinessParticipantID = PracticeBusinessParticipant.CMN_BPT_BusinessParticipantID;
					PracticeCompanyInfoID = PracticeBusinessParticipant.IfCompany_CMN_COM_CompanyInfo_RefID;
					if (Parameter.From_Practice_Bank == true)
					{


						var PracticeBusinessParticipant2bankaccount = ORM_CMN_BPT_BusinessParticipant_2_BankAccount.Query.Search(Connection, Transaction, new ORM_CMN_BPT_BusinessParticipant_2_BankAccount.Query()
						{
							IsDeleted = false,
							Tenant_RefID = securityTicket.TenantID,
							CMN_BPT_BusinessParticipant_RefID = PracticeBusinessParticipant.CMN_BPT_BusinessParticipantID,
						}).Single();


						var business2bankAccount = new ORM_CMN_BPT_BusinessParticipant_2_BankAccount();
						business2bankAccount.IsDeleted = false;
						business2bankAccount.Tenant_RefID = securityTicket.TenantID;
						business2bankAccount.CMN_BPT_BusinessParticipant_RefID = BusinessParticipantID;
						business2bankAccount.ACC_BNK_BankAccount_RefID = PracticeBusinessParticipant2bankaccount.ACC_BNK_BankAccount_RefID;
						business2bankAccount.Creation_Timestamp = DateTime.Now;
						business2bankAccount.Save(Connection, Transaction);

						BankAccountID = PracticeBusinessParticipant2bankaccount.ACC_BNK_BankAccount_RefID;
						//end of save bank data if inherited from practice   
					}
					else
					{
						if (!String.IsNullOrEmpty(Parameter.IBAN) || !String.IsNullOrEmpty(Parameter.Bank))
						{
							var business2bankAccount = new ORM_CMN_BPT_BusinessParticipant_2_BankAccount();
							business2bankAccount.IsDeleted = false;
							business2bankAccount.Tenant_RefID = securityTicket.TenantID;
							business2bankAccount.CMN_BPT_BusinessParticipant_RefID = BusinessParticipantID;
							business2bankAccount.ACC_BNK_BankAccount_RefID = Guid.NewGuid();
							business2bankAccount.Creation_Timestamp = DateTime.Now;
							business2bankAccount.Save(Connection, Transaction);

							var bankAccountDoctor = new ORM_ACC_BNK_BankAccount();
							bankAccountDoctor.IsDeleted = false;
							bankAccountDoctor.Tenant_RefID = securityTicket.TenantID;
							bankAccountDoctor.ACC_BNK_BankAccountID = business2bankAccount.ACC_BNK_BankAccount_RefID;
							bankAccountDoctor.OwnerText = Parameter.Account_Holder;
							bankAccountDoctor.IBAN = Parameter.IBAN;
							bankAccountDoctor.Bank_RefID = Guid.NewGuid();
							bankAccountDoctor.Creation_Timestamp = DateTime.Now;
							bankAccountDoctor.Save(Connection, Transaction);

							if (!String.IsNullOrEmpty(Parameter.Bank))
							{
								var bank = new ORM_ACC_BNK_Bank();
								bank.IsDeleted = false;
								bank.Tenant_RefID = securityTicket.TenantID;
								bank.ACC_BNK_BankID = bankAccountDoctor.Bank_RefID;
								bank.BICCode = Parameter.BIC;
								bank.BankName = Parameter.Bank;
								bank.Creation_Timestamp = DateTime.Now;
								bank.Save(Connection, Transaction);
							}

							BankAccountID = business2bankAccount.ACC_BNK_BankAccount_RefID;
							// end save bank data
						}
					}

				}
                var PracticeCompanyInfoAddress = ORM_CMN_COM_CompanyInfo_Address.Query.Search(Connection, Transaction, new ORM_CMN_COM_CompanyInfo_Address.Query()
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID,
                    CompanyInfo_RefID = PracticeCompanyInfoID,
                    Address_Description = "Standard address for billing, shipping",
                }).SingleOrDefault();

                Practice_Doctors_Model DPModel = new Practice_Doctors_Model();

                if (PracticeCompanyInfoAddress != null)
                {
                    var PracticeUCD = ORM_CMN_UniversalContactDetail.Query.Search(Connection, Transaction, new ORM_CMN_UniversalContactDetail.Query()
                    {
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID,
                        CMN_UniversalContactDetailID = PracticeCompanyInfoAddress.Address_UCD_RefID,
                    }).SingleOrDefault();
                    DPModel.address = PracticeUCD.Street_Name + " " + PracticeUCD.Street_Number;
                    DPModel.zip = PracticeUCD.ZIP;
                    DPModel.city = PracticeUCD.Town;
                }

                DPModel.account_status = "aktiv";
                DPModel.id = doctor_id.ToString();

                var title = string.IsNullOrEmpty(Parameter.Title) ? "" : Parameter.Title.Trim();

                DPModel.name = title + " " + Parameter.Last_Name + " " + Parameter.First_Name;
                DPModel.name_untouched = Parameter.Last_Name + " " + Parameter.First_Name;
                DPModel.bsnr_lanr = Parameter.LANR.ToString();

                DPModel.salutation = title;

                DPModel.type = "Doctor";

                DPModel.bank = string.IsNullOrEmpty(Parameter.Bank) ? "" : Parameter.Bank;

                DPModel.bank_untouched = string.IsNullOrEmpty(Parameter.Bank) ? "" : Parameter.Bank;


                DPModel.phone = Parameter.Phone;

                DPModel.email = string.IsNullOrEmpty(Parameter.Email) ? "" : Parameter.Email;

                DPModel.iban = string.IsNullOrEmpty(Parameter.IBAN) ? "" : Parameter.IBAN;

                DPModel.bic = string.IsNullOrEmpty(Parameter.BIC) ? "" : Parameter.BIC;

                DPModel.bank_id = BankAccountID.ToString();
                DPModel.bank_info_inherited = Parameter.From_Practice_Bank;
                DPModel.aditional_info = "";
                DPModel.contract = 0;
                

                DPModel.tenantid = securityTicket.TenantID.ToString();
                DPModel.practice_name_for_doctor = PracticeName;
                DPModel.practice_for_doctor_id = Parameter.PracticeID.ToString();

                DPModel.role = isOpPractice ? "op" : "ac";

                List<Practice_Doctors_Model> DPModelL = new List<Practice_Doctors_Model>();
                DPModelL.Add(DPModel);

                Add_New_Practice.Import_Practice_Data_to_ElasticDB(DPModelL, securityTicket.TenantID.ToString());
            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_DO_SD_1517 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_DO_SD_1517 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_DO_SD_1517 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_DO_SD_1517 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Doctor",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_DO_SD_1517 for attribute P_DO_SD_1517
		[DataContract]
		public class P_DO_SD_1517 
		{
			//Standard type parameters
			[DataMember]
			public Guid DoctorID { get; set; } 
			[DataMember]
			public String Salutation { get; set; } 
			[DataMember]
			public String Title { get; set; } 
			[DataMember]
			public String First_Name { get; set; } 
			[DataMember]
			public String Last_Name { get; set; } 
			[DataMember]
			public String Email { get; set; } 
			[DataMember]
			public String Phone { get; set; } 
			[DataMember]
			public int LANR { get; set; } 
			[DataMember]
			public Guid PracticeID { get; set; } 
			[DataMember]
			public String Account_Holder { get; set; } 
			[DataMember]
			public String IBAN { get; set; } 
			[DataMember]
			public String BIC { get; set; } 
			[DataMember]
			public String Bank { get; set; } 
			[DataMember]
			public String Login_Email { get; set; } 
			[DataMember]
			public String Account_Password { get; set; } 
			[DataMember]
			public String Account_PasswordForEmail { get; set; } 
			[DataMember]
			public bool From_Practice_Bank { get; set; } 
			[DataMember]
			public bool Account_Deactivated { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Doctor(,P_DO_SD_1517 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Doctor.Invoke(connectionString,P_DO_SD_1517 Parameter,securityTicket);
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
var parameter = new DataImporter.DBMethods.ExportData.Complex.Manipulation.P_DO_SD_1517();
parameter.DoctorID = ...;
parameter.Salutation = ...;
parameter.Title = ...;
parameter.First_Name = ...;
parameter.Last_Name = ...;
parameter.Email = ...;
parameter.Phone = ...;
parameter.LANR = ...;
parameter.PracticeID = ...;
parameter.Account_Holder = ...;
parameter.IBAN = ...;
parameter.BIC = ...;
parameter.Bank = ...;
parameter.Login_Email = ...;
parameter.Account_Password = ...;
parameter.Account_PasswordForEmail = ...;
parameter.From_Practice_Bank = ...;
parameter.Account_Deactivated = ...;

*/
