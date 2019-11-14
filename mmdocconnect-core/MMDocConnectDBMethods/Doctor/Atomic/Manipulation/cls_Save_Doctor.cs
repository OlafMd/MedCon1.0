/* 
 * Generated on 3/28/2017 10:09:40 AM
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
using MMDocConnectElasticSearchMethods.Doctor.Manipulation;
using MMDocConnectElasticSearchMethods.Models;
using CL1_ACC_BNK;
using CL1_CMN_BPT;
using CL1_CMN_BPT_CTM;
using CL1_HEC;
using CL1_CMN_PER;
using CL1_USR;
using CSV2Core.SMTP;
using System.Text;
using BOp.Providers.TMS.Requests;
using BOp.Providers;
using System.Globalization;
using BOp.Providers.TMS;
using System.Threading;
using CL1_CMN_COM;
using CL1_CMN;
using MMDocConnectDBMethods.Doctor.Atomic.Retrieval;
using MMDocConnectUtils;
using System.Configuration;
using System.Web.Configuration;
using CL1_HEC_ACT;
using CL1_HEC_CAS;
using MMDocConnectElasticSearchMethods.Case.Manipulation;
using MMDocConnectElasticSearchMethods.Case.Retrieval;
using MMDocConnectElasticSearchMethods.Doctor.Retrieval;
using MMDocConnectElasticSearchMethods;
using MMDocConnectDBMethods.MainData.Atomic.Retrieval;
using MMDocConnectDBMethods.Case.Atomic.Retrieval;
using MMDocConnectDBMethods.Patient.Atomic.Retrieval;
using MMDocConnectElasticSearchMethods.Patient.Manipulation;
using MMDocConnectElasticSearchMethods.Settlement.Retrieval;
using MMDocConnectElasticSearchMethods.Order.Retrieval;
using MMDocConnectElasticSearchMethods.Settlement.Manipulation;
using System.Web;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using MMDocConnectDocApp;
using MMDocConnectDBMethods.Case.Complex.Retrieval;
namespace MMDocConnectDBMethods.Doctor.Atomic.Manipulation
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
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_DO_SD_1026 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_Guid();
            //Put your code here
            #region init
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("de-DE");
            IAccountServiceProvider accountService;
            var _providerFactory = ProviderFactory.Instance;
            accountService = _providerFactory.CreateAccountServiceProvider();
            var accId = Guid.NewGuid();
            Guid BusinessParticipantID = Guid.NewGuid();
            Guid personInfoID = Guid.NewGuid();
            Guid PracticeCustomerID = Guid.NewGuid();
            Guid PracticeBusinessParticipantID = Guid.NewGuid();
            Guid PracticeCompanyInfoID = Guid.NewGuid();
            String PracticeName = "";
            Guid BankAccountID = Guid.Empty;
            Guid doctor_id = Parameter.DoctorID;
            var isOpPractice = false;
            #endregion

            if (Parameter.DoctorID == Guid.Empty)
            {
                if (!String.IsNullOrEmpty(Parameter.Login_Email))
                {
                    string[] stringUser = Parameter.Login_Email.Split('@');
                    string usernameStr = stringUser[0];

                    try
                    {
                        #region Account
                        Person DoctorAccount = new Person();
                        DoctorAccount.FirstName = Parameter.First_Name;
                        DoctorAccount.LastName = Parameter.Last_Name;
                        DoctorAccount.Title =  Parameter.Title;
                        Account account = new Account();
                        account.Person = DoctorAccount;
                        account.ID = accId;
                        account.TenantID = securityTicket.TenantID;
                        account.Email = Parameter.Login_Email;
                        account.PasswordHash = Parameter.Account_Password;
                        account.Username = usernameStr;
                        account.AccountType = EAccountType.Standard;
                        account.Verified = true;
                        accountService.CreateAccount(account, securityTicket.SessionTicket);
                        accountService.VerifyAccount(account.ID);
                        string emailTo = Parameter.Login_Email;

                        try
                        {
                            string appName = WebConfigurationManager.AppSettings["docAppUrl"];
                            var prefix = HttpContext.Current.Request.Url.AbsoluteUri.Contains("https") ? "https://" : "http://";
                            var imageUrl = HttpContext.Current.Request.Url.AbsoluteUri.Substring(0, HttpContext.Current.Request.Url.AbsoluteUri.IndexOf("api")) + "Content/images/logo.png";
                            var email_template = File.ReadAllText(HttpContext.Current.Server.MapPath("~/EmailTemplates/DoctorWelcomeEmailTemplate.html"));

                            var subjectsJson = File.ReadAllText(HttpContext.Current.Server.MapPath("~/EmailTemplates/EmailSubjects.json"));
                            dynamic subjects = JsonConvert.DeserializeObject(subjectsJson);
                            var subjectMail = subjects["DoctorWelcomeSubject"].ToString();

                            email_template = EmailTemplater.SetTemplateData(email_template, new
                            {
                                salutation = Parameter.Salutation,
                                title = Parameter.Title,
                                last_name = Parameter.Last_Name,
                                first_name = Parameter.First_Name,
                                password = Parameter.Account_PasswordForEmail,
                                doc_app_url = prefix + HttpContext.Current.Request.Url.Authority + "/" + appName,
                                medios_connect_logo_url = imageUrl
                            }, "{{", "}}");

                            //    string mailFrom = cls_Get_Company_Settings.Invoke(Connection, Transaction, securityTicket).Result.Email;
                            string mailFrom = WebConfigurationManager.AppSettings["mailFrom"];
                            EmailNotificationSenderUtil.SendEmail(mailFrom, emailTo, subjectMail, email_template);
                        }
                        catch (Exception ex)
                        {
                            LogUtils.Logger.LogDocAppInfo(new LogUtils.LogEntry(System.Reflection.MethodInfo.GetCurrentMethod(), ex, null, "Save doctor: Email sending failed."), "EmailExceptions");
                        }
                        var doctorAccountInfo = ORM_USR_Account.Query.Search(Connection, Transaction, new ORM_USR_Account.Query()
                        {
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID,
                            USR_AccountID = accId
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
                        #endregion

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

                        P_DO_GPAIDfPID_1351 practiceAccountIDParameter = new P_DO_GPAIDfPID_1351();
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
                        doctor.DoctorIDNumber = Parameter.LANR;
                        doctor.Account_RefID = accId;

                        doctor.Save(Connection, Transaction);

                        doctor_id = doctor.HEC_DoctorID;
                        returnValue.Result = doctor_id;

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

                        #region Customer number
                        var customerNumberProperty = ORM_HEC_Doctor_UniversalProperty.Query.Search(Connection, Transaction, new ORM_HEC_Doctor_UniversalProperty.Query()
                        {
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false,
                            GlobalPropertyMatchingID = "mm.docconnect.doctor.customer.number"
                        }).SingleOrDefault();

                        if (customerNumberProperty == null)
                        {
                            customerNumberProperty = new ORM_HEC_Doctor_UniversalProperty();
                            customerNumberProperty.GlobalPropertyMatchingID = "mm.docconnect.doctor.customer.number";
                            customerNumberProperty.IsValue_String = true;
                            customerNumberProperty.Modification_Timestamp = DateTime.Now;
                            customerNumberProperty.PropertyName = "Customer number";
                            customerNumberProperty.Tenant_RefID = securityTicket.TenantID;

                            customerNumberProperty.Save(Connection, Transaction);
                        }

                        var customerNumberPropertyValue = new ORM_HEC_Doctor_UniversalPropertyValue();
                        customerNumberPropertyValue.HEC_Doctor_RefID = doctor_id;
                        customerNumberPropertyValue.Modification_Timestamp = DateTime.Now;
                        customerNumberPropertyValue.Tenant_RefID = securityTicket.TenantID;
                        customerNumberPropertyValue.UniversalProperty_RefID = customerNumberProperty.HEC_Doctor_UniversalPropertyID;
                        customerNumberPropertyValue.Value_String = Parameter.CustomerNumber;

                        customerNumberPropertyValue.Save(Connection, Transaction);
                        #endregion

                        #region Is Certificated For OCT
                        var isDoctorCertificatedProperty = ORM_HEC_Doctor_UniversalProperty.Query.Search(Connection, Transaction, new ORM_HEC_Doctor_UniversalProperty.Query()
                        {
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false,
                            GlobalPropertyMatchingID = "mm.docconnect.doctor.oct.certificated"
                        }).SingleOrDefault();

                        if (isDoctorCertificatedProperty == null)
                        {
                            isDoctorCertificatedProperty = new ORM_HEC_Doctor_UniversalProperty();
                            isDoctorCertificatedProperty.GlobalPropertyMatchingID = "mm.docconnect.doctor.oct.certificated";
                            isDoctorCertificatedProperty.IsValue_Boolean = true;
                            isDoctorCertificatedProperty.IsValue_Number = false;
                            isDoctorCertificatedProperty.IsValue_String = false;

                            isDoctorCertificatedProperty.Modification_Timestamp = DateTime.Now;
                            isDoctorCertificatedProperty.PropertyName = "Certificated doctor for OCT";
                            isDoctorCertificatedProperty.Tenant_RefID = securityTicket.TenantID;

                            isDoctorCertificatedProperty.Save(Connection, Transaction);
                        }

                        var isDoctorCertificatedPropertyValue = new ORM_HEC_Doctor_UniversalPropertyValue();
                        isDoctorCertificatedPropertyValue.HEC_Doctor_RefID = doctor_id;
                        isDoctorCertificatedPropertyValue.Modification_Timestamp = DateTime.Now;
                        isDoctorCertificatedPropertyValue.Tenant_RefID = securityTicket.TenantID;
                        isDoctorCertificatedPropertyValue.UniversalProperty_RefID = isDoctorCertificatedProperty.HEC_Doctor_UniversalPropertyID;
                        isDoctorCertificatedPropertyValue.Value_String = "";
                        isDoctorCertificatedPropertyValue.Value_Boolean = Parameter.IsCertificatedForOCT;

                        isDoctorCertificatedPropertyValue.Save(Connection, Transaction);
                        #endregion

                        #region OCT valid from date
                        var octValidFromDateProperty = ORM_HEC_Doctor_UniversalProperty.Query.Search(Connection, Transaction, new ORM_HEC_Doctor_UniversalProperty.Query()
                        {
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false,
                            GlobalPropertyMatchingID = "mm.docconnect.doctor.oct.valid.from.date"
                        }).SingleOrDefault();

                        if (octValidFromDateProperty == null)
                        {
                            octValidFromDateProperty = new ORM_HEC_Doctor_UniversalProperty();
                            octValidFromDateProperty.GlobalPropertyMatchingID = "mm.docconnect.doctor.oct.valid.from.date";
                            octValidFromDateProperty.IsValue_String = true;
                            octValidFromDateProperty.Modification_Timestamp = DateTime.Now;
                            octValidFromDateProperty.PropertyName = "Oct valid from date";
                            octValidFromDateProperty.Tenant_RefID = securityTicket.TenantID;

                            octValidFromDateProperty.Save(Connection, Transaction);
                        }

                        var octValidFromDatePropertyValue = new ORM_HEC_Doctor_UniversalPropertyValue();
                        octValidFromDatePropertyValue.HEC_Doctor_RefID = doctor_id;
                        octValidFromDatePropertyValue.Modification_Timestamp = DateTime.Now;
                        octValidFromDatePropertyValue.Tenant_RefID = securityTicket.TenantID;
                        octValidFromDatePropertyValue.UniversalProperty_RefID = octValidFromDateProperty.HEC_Doctor_UniversalPropertyID;
                        octValidFromDatePropertyValue.Value_String = Parameter.OctValidFrom;

                        octValidFromDatePropertyValue.Save(Connection, Transaction);
                        #endregion

                        if (Parameter.TemporaryDoctorID != Guid.Empty)
                        {
                            var temporary_doctor_bpt_id = Guid.Empty;
                            List<Guid> case_ids = new List<Guid>();

                            #region PURGE TEMPORARY DOCTOR
                            var temporary_doctor = ORM_HEC_Doctor.Query.Search(Connection, Transaction, new ORM_HEC_Doctor.Query() { HEC_DoctorID = Parameter.TemporaryDoctorID, IsDeleted = false, Tenant_RefID = securityTicket.TenantID }).SingleOrDefault();
                            if (temporary_doctor != null)
                            {
                                temporary_doctor.IsDeleted = true;
                                temporary_doctor.Save(Connection, Transaction);

                                var temporary_doctor_bpt = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, new ORM_CMN_BPT_BusinessParticipant.Query() { CMN_BPT_BusinessParticipantID = temporary_doctor.BusinessParticipant_RefID, IsDeleted = false, Tenant_RefID = securityTicket.TenantID }).SingleOrDefault();
                                if (temporary_doctor_bpt != null)
                                {
                                    temporary_doctor_bpt_id = temporary_doctor_bpt.CMN_BPT_BusinessParticipantID;
                                    temporary_doctor_bpt.IsDeleted = true;
                                    temporary_doctor_bpt.Save(Connection, Transaction);

                                    var temporary_doctor_person_info = ORM_CMN_PER_PersonInfo.Query.Search(Connection, Transaction, new ORM_CMN_PER_PersonInfo.Query() { CMN_PER_PersonInfoID = temporary_doctor_bpt.IfNaturalPerson_CMN_PER_PersonInfo_RefID, IsDeleted = false, Tenant_RefID = securityTicket.TenantID }).SingleOrDefault();
                                    if (temporary_doctor_person_info != null)
                                    {
                                        temporary_doctor_person_info.IsDeleted = true;
                                        temporary_doctor_person_info.Save(Connection, Transaction);

                                        var temporary_doctor_communication_contact = ORM_CMN_PER_CommunicationContact.Query.Search(Connection, Transaction, new ORM_CMN_PER_CommunicationContact.Query() { PersonInfo_RefID = temporary_doctor_person_info.CMN_PER_PersonInfoID, IsDeleted = false, Tenant_RefID = securityTicket.TenantID });
                                        foreach (var tdc in temporary_doctor_communication_contact)
                                        {
                                            tdc.IsDeleted = true;
                                            tdc.Save(Connection, Transaction);
                                        }
                                    }
                                }

                                var temporary_doctor_universal_property_value = ORM_HEC_Doctor_UniversalPropertyValue.Query.Search(Connection, Transaction, new ORM_HEC_Doctor_UniversalPropertyValue.Query() { HEC_Doctor_RefID = temporary_doctor.HEC_DoctorID, IsDeleted = false, Tenant_RefID = securityTicket.TenantID }).SingleOrDefault();
                                if (temporary_doctor_universal_property_value != null)
                                {
                                    temporary_doctor_universal_property_value.IsDeleted = true;
                                    temporary_doctor_universal_property_value.Save(Connection, Transaction);

                                    var temporary_doctor_universal_property = ORM_HEC_Doctor_UniversalProperty.Query.Search(Connection, Transaction, new ORM_HEC_Doctor_UniversalProperty.Query() { PropertyName = "Comment", HEC_Doctor_UniversalPropertyID = temporary_doctor_universal_property_value.HEC_Doctor_UniversalPropertyValueID, IsDeleted = false, Tenant_RefID = securityTicket.TenantID }).SingleOrDefault();
                                    if (temporary_doctor_universal_property != null)
                                    {
                                        temporary_doctor_universal_property.IsDeleted = true;
                                        temporary_doctor_universal_property.Save(Connection, Transaction);
                                    }
                                }
                            }
                            #endregion

                            #region LINK AFTERCARES TO THE NEW DOCTOR
                            var aftercare_planned_actions = ORM_HEC_ACT_PlannedAction.Query.Search(Connection, Transaction, new ORM_HEC_ACT_PlannedAction.Query()
                            {
                                Tenant_RefID = securityTicket.TenantID,
                                IsDeleted = false,
                                IsPerformed = false,
                                IsCancelled = false,
                                ToBePerformedBy_BusinessParticipant_RefID = temporary_doctor_bpt_id
                            });

                            foreach (var aftercare in aftercare_planned_actions)
                            {
                                aftercare.ToBePerformedBy_BusinessParticipant_RefID = BusinessParticipantID;
                                aftercare.Modification_Timestamp = DateTime.Now;

                                aftercare.Save(Connection, Transaction);

                                var case_id = ORM_HEC_CAS_Case_RelevantPlannedAction.Query.Search(Connection, Transaction, new ORM_HEC_CAS_Case_RelevantPlannedAction.Query() { PlannedAction_RefID = aftercare.HEC_ACT_PlannedActionID, IsDeleted = false, Tenant_RefID = securityTicket.TenantID }).SingleOrDefault();
                                if (case_id != null)
                                {
                                    case_ids.Add(case_id.Case_RefID);
                                }
                            }
                            #endregion

                            #region UPDATE ELASTIC
                            List<Case_Model> cases = new List<Case_Model>();
                            List<Aftercare_Model> aftercares = new List<Aftercare_Model>();
                            List<PatientDetailViewModel> patientDetailList = new List<PatientDetailViewModel>();
                            Dictionary<Guid, CAS_GDDfDID_1608> diagnose_data_cache = new Dictionary<Guid, CAS_GDDfDID_1608>();
                            Dictionary<Guid, CAS_GDDfDID_1614> drug_data_cache = new Dictionary<Guid, CAS_GDDfDID_1614>();
                            Dictionary<Guid, DO_GDDfDID_0823> treatment_doctor_data_cache = new Dictionary<Guid, DO_GDDfDID_0823>();
                            Dictionary<Guid, P_PA_GPDfPID_1124> patient_data_cache = new Dictionary<Guid, P_PA_GPDfPID_1124>();
                            Dictionary<Guid, DO_GPDfPID_1432> treatment_practice_data_cache = new Dictionary<Guid, DO_GPDfPID_1432>();

                            foreach (var case_id in case_ids)
                            {
                                #region IF CASE SUBMITTED, CREATE AFTERCARE
                                var treatment_planned_action = cls_Get_Treatment_Planned_Action_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GTPAfCID_0946() { CaseID = case_id }, securityTicket).Result;
                                if (treatment_planned_action != null && treatment_planned_action.is_treatment_performed)
                                {
                                    var case_details = cls_Get_Case_Details_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GCDfCID_1435() { CaseID = case_id }, securityTicket).Result;

                                    #region CACHE
                                    if (!diagnose_data_cache.ContainsKey(case_details.diagnose_id))
                                    {
                                        diagnose_data_cache.Add(case_details.diagnose_id, cls_Get_Diagnose_Details_for_DiagnoseID.Invoke(Connection, Transaction, new P_CAS_GDDfDID_1608() { DiagnoseID = case_details.diagnose_id }, securityTicket).Result);
                                    }
                                    var diagnose_details = diagnose_data_cache[case_details.diagnose_id];

                                    if (!drug_data_cache.ContainsKey(case_details.drug_id))
                                    {
                                        drug_data_cache.Add(case_details.drug_id, cls_Get_Drug_Details_for_DrugID.Invoke(Connection, Transaction, new P_CAS_GDDfDID_1614() { DrugID = case_details.drug_id }, securityTicket).Result);
                                    }
                                    var drug_details = drug_data_cache[case_details.drug_id];

                                    if (!treatment_doctor_data_cache.ContainsKey(case_details.op_doctor_id))
                                    {
                                        treatment_doctor_data_cache.Add(case_details.op_doctor_id, cls_Get_Doctor_Details_for_DoctorID.Invoke(Connection, Transaction, new P_DO_GDDfDID_0823() { DoctorID = case_details.op_doctor_id }, securityTicket).Result.SingleOrDefault());
                                    }
                                    var treatment_doctor_details = treatment_doctor_data_cache[case_details.op_doctor_id];

                                    if (!patient_data_cache.ContainsKey(case_details.patient_id))
                                    {
                                        patient_data_cache.Add(case_details.patient_id, cls_Get_Patient_Details_for_PatientID.Invoke(Connection, Transaction, new P_P_PA_GPDfPID_1124() { PatientID = case_details.patient_id }, securityTicket).Result);
                                    }
                                    var patient_details = patient_data_cache[case_details.patient_id];

                                    if (!treatment_practice_data_cache.ContainsKey(case_details.practice_id))
                                    {
                                        treatment_practice_data_cache.Add(case_details.practice_id, cls_Get_Practice_Details_for_PracticeID.Invoke(Connection, Transaction, new P_DO_GPDfPID_1432() { PracticeID = case_details.practice_id }, securityTicket).Result.FirstOrDefault());
                                    }
                                    var treatment_practice_details = treatment_practice_data_cache[case_details.practice_id];

                                    #endregion

                                    if (case_details != null)
                                    {
                                        #region CREATE NEW AFTERCARE
                                        Aftercare_Model aftercare = new Aftercare_Model();
                                        aftercare.hip_ik_number = patient_details.HealthInsurance_IKNumber;
                                        aftercare.aftercare_doctor_name = GenericUtils.GetDoctorNameUppercaseOrdinals(Parameter);
                                        aftercare.diagnose = diagnose_details != null ? diagnose_details.diagnose_name + " (" + diagnose_details.catalog_display_name + ": " + diagnose_details.diagnose_icd_10 + ")" : "";
                                        aftercare.id = case_details.aftercare_planned_action_id.ToString();
                                        aftercare.localization = case_details.localization;
                                        aftercare.patient_birthdate = case_details.Patient_BirthDate;
                                        aftercare.patient_birthdate_string = case_details.Patient_BirthDate.ToString("dd.MM.yyyy");
                                        aftercare.patient_name = patient_details != null ? patient_details.patient_last_name + ", " + patient_details.patient_first_name : "";
                                        aftercare.practice_id = Parameter.PracticeID.ToString();
                                        aftercare.status = "AC1";
                                        aftercare.treatment_date = case_details.treatment_date;
                                        aftercare.treatment_date_day_month = case_details.treatment_date.ToString("dd.MM.");
                                        aftercare.treatment_date_month_year = case_details.treatment_date.ToString("MMMM yyyy", new System.Globalization.CultureInfo("de", true));
                                        aftercare.treatment_doctor_name = treatment_doctor_details != null ? MMDocConnectDocApp.GenericUtils.GetDoctorName(treatment_doctor_details) : "-";
                                        aftercare.treatment_doctor_practice_name = treatment_doctor_details.practice;
                                        aftercare.case_id = case_id.ToString();
                                        aftercare.hip = patient_details.health_insurance_provider;
                                        aftercare.patient_insurance_number = patient_details.insurance_id;
                                        aftercare.op_lanr = treatment_doctor_details == null ? "" : treatment_doctor_details.lanr;
                                        aftercare.ac_lanr = Parameter.LANR;
                                        aftercare.bsnr = treatment_doctor_details == null ? "" : treatment_doctor_details.BSNR;
                                        aftercare.aftercare_doctor_account_id = accId.ToString();
                                        aftercare.aftercare_doctor_practice_id = doctor_id.ToString();
                                        aftercare.treatment_doctor_id = treatment_doctor_details == null ? "" : treatment_doctor_details.id.ToString();
                                        aftercare.diagnose_id = case_details.diagnose_id.ToString();
                                        aftercare.drug_id = case_details.drug_id.ToString();
                                        aftercare.patient_id = case_details.patient_id.ToString();
                                        aftercare.treatment_doctors_practice_id = case_details.practice_id.ToString();

                                        aftercares.Add(aftercare);

                                        PatientDetailViewModel patientDetal_elastic = new PatientDetailViewModel();
                                        patientDetal_elastic.id = aftercare.id;
                                        patientDetal_elastic.drug_id = aftercare.drug_id;
                                        patientDetal_elastic.case_id = aftercare.case_id;
                                        patientDetal_elastic.practice_id = aftercare.practice_id;
                                        patientDetal_elastic.date = aftercare.treatment_date;
                                        patientDetal_elastic.date_string = aftercare.treatment_date.ToString("dd.MM.");
                                        patientDetal_elastic.detail_type = "ac";
                                        patientDetal_elastic.diagnose_or_medication = aftercare.diagnose;
                                        patientDetal_elastic.doctor = aftercare.aftercare_doctor_name;
                                        patientDetal_elastic.localisation = aftercare.localization;
                                        patientDetal_elastic.patient_id = aftercare.patient_id;
                                        patientDetal_elastic.treatment_doctor_id = aftercare.treatment_doctor_id;
                                        patientDetal_elastic.aftercare_doctor_practice_id = aftercare.aftercare_doctor_practice_id;
                                        patientDetal_elastic.diagnose_id = aftercare.diagnose_id;
                                        patientDetal_elastic.status = "FS0";
                                        patientDetal_elastic.hip_ik = patient_details.HealthInsurance_IKNumber;

                                        patientDetailList.Add(patientDetal_elastic);
                                        #endregion
                                    }
                                }
                                #endregion
                                else
                                {
                                    var planning_case = Get_Cases.GetCaseforCaseID(case_id.ToString(), securityTicket);
                                    planning_case.aftercare_doctor_lanr = Parameter.LANR;
                                    planning_case.aftercare_doctor_practice_id = doctor_id.ToString();
                                    var practice_details = cls_Get_Practice_Details_for_PracticeID.Invoke(Connection, Transaction, new P_DO_GPDfPID_1432() { PracticeID = Parameter.PracticeID }, securityTicket).Result.FirstOrDefault();
                                    if (practice_details != null)
                                    {
                                        planning_case.aftercare_doctors_practice_name = practice_details.practice_name;
                                        planning_case.aftercare_name = GenericUtils.GetDoctorNameUppercaseOrdinals(Parameter);
                                        planning_case.aftercare_practice_bsnr = practice_details.practice_BSNR;
                                        planning_case.is_aftercare_doctor = true;
                                    }

                                    cases.Add(planning_case);
                                }
                                #region IF CASE NOT SUBMITTED, UPDATE AFTERCARE DATA
                                #endregion
                            }

                            #region UPDATE LAST USED DOCTORS/PRACTICES LIST FOR ALL DOCTORS WHO USED TEMPORARY DOCTOR
                            var types = Elastic_Utils.GetAllTypes(securityTicket.TenantID.ToString());
                            var length = Guid.Empty.ToString().Length;
                            length += 5;
                            List<string> last_used_types = new List<string>();
                            for (int i = 0; i < types.Length; i += length)
                            {
                                int index = types.IndexOf("user_", i);
                                if (index != -1 && !last_used_types.Contains(types.Substring(index, length)))
                                    last_used_types.Add(types.Substring(index, length));
                            }

                            foreach (var type in last_used_types)
                            {
                                Practice_Doctor_Last_Used_Model new_last_used = new Practice_Doctor_Last_Used_Model();
                                try
                                {
                                    var last_used = Get_Practices_and_Doctors.GetLastUsedDoctorPracticeForID(Parameter.TemporaryDoctorID.ToString(), type, securityTicket);

                                    new_last_used.display_name = GenericUtils.GetDoctorNameUppercaseOrdinals(Parameter) + "(" + Parameter.LANR + ")";
                                    new_last_used.id = doctor_id.ToString();
                                    new_last_used.practice_id = Parameter.PracticeID.ToString();
                                    new_last_used.date_of_use = last_used.date_of_use;

                                    Add_New_Practice_Last_Used.Delete_Practice_Last_Used(securityTicket.TenantID.ToString(), type, Parameter.TemporaryDoctorID.ToString());
                                    Add_New_Practice_Last_Used.Import_Practice_Last_Used_Data_to_ElasticDB(new List<Practice_Doctor_Last_Used_Model>() { new_last_used }, securityTicket.TenantID.ToString(), type.Substring(5));
                                }
                                catch (Exception ex)
                                {
                                    // left empty because it's not really an exception, rather a check whether object with given id exists 
                                }
                            }
                            #endregion

                            if (cases.Count != 0)
                                Add_New_Case.Import_Case_Data_to_ElasticDB(cases, securityTicket.TenantID.ToString());

                            if (aftercares.Count != 0)
                                Add_New_Aftercare.Import_Aftercare_Data_to_ElasticDB(aftercares, securityTicket.TenantID.ToString());

                            if (patientDetailList.Count != 0)
                                Add_New_Patient.ImportPatientDetailsToElastic(patientDetailList, securityTicket.TenantID.ToString());

                            Add_New_Practice.Delete_Doctor_Practice(securityTicket.TenantID.ToString(), Parameter.TemporaryDoctorID.ToString());

                            #endregion
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Account error", ex);
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
                    doctor.DoctorIDNumber = Parameter.LANR;
                    doctor.Account_RefID = accId;

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
            }
            #region EDIT
            else
            {
                if (Parameter.Account_Deactivated)
                {
                    var doctorAccoundID = cls_Get_Doctor_AccountID_for_DoctorID.Invoke(Connection, Transaction, new P_DO_GDAIDfDID_1549() { DoctorID = Parameter.DoctorID }, securityTicket).Result.accountID;

                    var accountStatus = accountService.GetAccountStatusHistory(securityTicket.TenantID, doctorAccoundID).OrderBy(sth => sth.CreationTimestamp).Reverse().FirstOrDefault();

                    if (accountStatus.Status != EAccountStatus.BANNED)
                        accountService.BanAccount(doctorAccoundID, "Konto wurde vom Administrator deaktiviert");
                }
                else
                {
                    var doctorAccoundID = cls_Get_Doctor_AccountID_for_DoctorID.Invoke(Connection, Transaction, new P_DO_GDAIDfDID_1549() { DoctorID = Parameter.DoctorID }, securityTicket).Result.accountID;

                    var accountStatus = accountService.GetAccountStatusHistory(securityTicket.TenantID, doctorAccoundID).OrderBy(sth => sth.CreationTimestamp).Reverse().FirstOrDefault();

                    if (accountStatus.Status == EAccountStatus.BANNED)
                        accountService.UnbanAccount(doctorAccoundID);

                }

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

                var CustomerPractice = ORM_CMN_BPT_CTM_Customer.Query.Search(Connection, Transaction, new ORM_CMN_BPT_CTM_Customer.Query()
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID,
                    CMN_BPT_CTM_CustomerID = ogranizationUnitPractice.Customer_RefID
                }).Single();

                var PracticeBusinessParticipant = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, new ORM_CMN_BPT_BusinessParticipant.Query()
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID,
                    CMN_BPT_BusinessParticipantID = CustomerPractice.Ext_BusinessParticipant_RefID
                }).Single();

                PracticeName = PracticeBusinessParticipant.DisplayName;
                PracticeCompanyInfoID = PracticeBusinessParticipant.IfCompany_CMN_COM_CompanyInfo_RefID;

                var doctorQ = new ORM_HEC_Doctor.Query();
                doctorQ.Tenant_RefID = securityTicket.TenantID;
                doctorQ.IsDeleted = false;
                doctorQ.HEC_DoctorID = Parameter.DoctorID;

                var doctor = ORM_HEC_Doctor.Query.Search(Connection, Transaction, doctorQ).SingleOrDefault();

                if (doctor != null)
                {
                    doctor.DoctorIDNumber = Parameter.LANR;
                    doctor.Save(Connection, Transaction);


                    #region Customer number
                    var customerNumberProperty = ORM_HEC_Doctor_UniversalProperty.Query.Search(Connection, Transaction, new ORM_HEC_Doctor_UniversalProperty.Query()
                    {
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false,
                        GlobalPropertyMatchingID = "mm.docconnect.doctor.customer.number"
                    }).SingleOrDefault();

                    if (customerNumberProperty == null)
                    {
                        customerNumberProperty = new ORM_HEC_Doctor_UniversalProperty();
                        customerNumberProperty.GlobalPropertyMatchingID = "mm.docconnect.doctor.customer.number";
                        customerNumberProperty.IsValue_String = true;
                        customerNumberProperty.Modification_Timestamp = DateTime.Now;
                        customerNumberProperty.PropertyName = "Customer number";
                        customerNumberProperty.Tenant_RefID = securityTicket.TenantID;

                        customerNumberProperty.Save(Connection, Transaction);
                    }

                    var customerNumberPropertyValue = ORM_HEC_Doctor_UniversalPropertyValue.Query.Search(Connection, Transaction, new ORM_HEC_Doctor_UniversalPropertyValue.Query()
                    {
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false,
                        HEC_Doctor_RefID = Parameter.DoctorID,
                        UniversalProperty_RefID = customerNumberProperty.HEC_Doctor_UniversalPropertyID
                    }).SingleOrDefault();

                    if (customerNumberPropertyValue == null)
                    {
                        customerNumberPropertyValue = new ORM_HEC_Doctor_UniversalPropertyValue();
                        customerNumberPropertyValue.HEC_Doctor_RefID = Parameter.DoctorID;
                        customerNumberPropertyValue.Tenant_RefID = securityTicket.TenantID;
                        customerNumberPropertyValue.UniversalProperty_RefID = customerNumberProperty.HEC_Doctor_UniversalPropertyID;
                    }

                    customerNumberPropertyValue.Value_String = Parameter.CustomerNumber;
                    customerNumberPropertyValue.Modification_Timestamp = DateTime.Now;

                    customerNumberPropertyValue.Save(Connection, Transaction);
                    #endregion

                    #region Is Certificated For OCT
                    var isDoctorCertificatedProperty = ORM_HEC_Doctor_UniversalProperty.Query.Search(Connection, Transaction, new ORM_HEC_Doctor_UniversalProperty.Query()
                    {
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false,
                        GlobalPropertyMatchingID = "mm.docconnect.doctor.oct.certificated"
                    }).SingleOrDefault();

                    if (isDoctorCertificatedProperty == null)
                    {
                        isDoctorCertificatedProperty = new ORM_HEC_Doctor_UniversalProperty();
                        isDoctorCertificatedProperty.GlobalPropertyMatchingID = "mm.docconnect.doctor.oct.certificated";
                        isDoctorCertificatedProperty.IsValue_Boolean = true;
                        isDoctorCertificatedProperty.IsValue_String = false;
                        isDoctorCertificatedProperty.IsValue_Number = false;

                        isDoctorCertificatedProperty.Modification_Timestamp = DateTime.Now;
                        isDoctorCertificatedProperty.PropertyName = "Certificated doctor for OCT";
                        isDoctorCertificatedProperty.Tenant_RefID = securityTicket.TenantID;

                        isDoctorCertificatedProperty.Save(Connection, Transaction);
                    }

                    var isDoctorCertificatedPropertyValue = ORM_HEC_Doctor_UniversalPropertyValue.Query.Search(Connection, Transaction, new ORM_HEC_Doctor_UniversalPropertyValue.Query()
                    {
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false,
                        HEC_Doctor_RefID = Parameter.DoctorID,
                        UniversalProperty_RefID = isDoctorCertificatedProperty.HEC_Doctor_UniversalPropertyID
                    }).SingleOrDefault();

                    if (isDoctorCertificatedPropertyValue == null)
                    {
                        isDoctorCertificatedPropertyValue = new ORM_HEC_Doctor_UniversalPropertyValue();
                        isDoctorCertificatedPropertyValue.HEC_Doctor_RefID = Parameter.DoctorID;
                        isDoctorCertificatedPropertyValue.Tenant_RefID = securityTicket.TenantID;
                        isDoctorCertificatedPropertyValue.UniversalProperty_RefID = isDoctorCertificatedProperty.HEC_Doctor_UniversalPropertyID;
                    }

                    isDoctorCertificatedPropertyValue.Value_String = "";
                    isDoctorCertificatedPropertyValue.Value_Boolean = Parameter.IsCertificatedForOCT;
                    isDoctorCertificatedPropertyValue.Modification_Timestamp = DateTime.Now;

                    isDoctorCertificatedPropertyValue.Save(Connection, Transaction);
                    #endregion

                    #region OCT valid from date
                    var octValidFromDateProperty = ORM_HEC_Doctor_UniversalProperty.Query.Search(Connection, Transaction, new ORM_HEC_Doctor_UniversalProperty.Query()
                    {
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false,
                        GlobalPropertyMatchingID = "mm.docconnect.doctor.oct.valid.from.date"
                    }).SingleOrDefault();

                    if (octValidFromDateProperty == null)
                    {
                        octValidFromDateProperty = new ORM_HEC_Doctor_UniversalProperty();
                        octValidFromDateProperty.GlobalPropertyMatchingID = "mm.docconnect.doctor.oct.valid.from.date";
                        octValidFromDateProperty.IsValue_String = true;
                        octValidFromDateProperty.Modification_Timestamp = DateTime.Now;
                        octValidFromDateProperty.PropertyName = "Oct valid from date";
                        octValidFromDateProperty.Tenant_RefID = securityTicket.TenantID;

                        octValidFromDateProperty.Save(Connection, Transaction);
                    }

                    var octValidFromDatePropertyValue = ORM_HEC_Doctor_UniversalPropertyValue.Query.Search(Connection, Transaction, new ORM_HEC_Doctor_UniversalPropertyValue.Query()
                    {
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false,
                        HEC_Doctor_RefID = Parameter.DoctorID,
                        UniversalProperty_RefID = octValidFromDateProperty.HEC_Doctor_UniversalPropertyID
                    }).SingleOrDefault();

                    if (octValidFromDatePropertyValue == null)
                    {
                        octValidFromDatePropertyValue = new ORM_HEC_Doctor_UniversalPropertyValue();
                        octValidFromDatePropertyValue.HEC_Doctor_RefID = Parameter.DoctorID;
                        octValidFromDatePropertyValue.Tenant_RefID = securityTicket.TenantID;
                        octValidFromDatePropertyValue.UniversalProperty_RefID = octValidFromDateProperty.HEC_Doctor_UniversalPropertyID;
                    }

                    octValidFromDatePropertyValue.Value_String = Parameter.OctValidFrom;
                    octValidFromDatePropertyValue.Modification_Timestamp = DateTime.Now;

                    octValidFromDatePropertyValue.Save(Connection, Transaction);
                    #endregion

                    var doctorBusinessParticipantQ = new ORM_CMN_BPT_BusinessParticipant.Query();
                    doctorBusinessParticipantQ.Tenant_RefID = securityTicket.TenantID;
                    doctorBusinessParticipantQ.IsDeleted = false;
                    doctorBusinessParticipantQ.CMN_BPT_BusinessParticipantID = doctor.BusinessParticipant_RefID;

                    var doctorBusinessParticipant = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, doctorBusinessParticipantQ).SingleOrDefault();
                    if (doctorBusinessParticipant != null)
                    {
                        doctorBusinessParticipant.DisplayName = Parameter.First_Name + " " + Parameter.Last_Name;
                        doctorBusinessParticipant.Modification_Timestamp = DateTime.Now;
                        doctorBusinessParticipant.Save(Connection, Transaction);

                        var doctorPersonInfoQ = new ORM_CMN_PER_PersonInfo.Query();
                        doctorPersonInfoQ.Tenant_RefID = securityTicket.TenantID;
                        doctorPersonInfoQ.IsDeleted = false;
                        doctorPersonInfoQ.CMN_PER_PersonInfoID = doctorBusinessParticipant.IfNaturalPerson_CMN_PER_PersonInfo_RefID;

                        var doctorPersonInfo = ORM_CMN_PER_PersonInfo.Query.Search(Connection, Transaction, doctorPersonInfoQ).SingleOrDefault();

                        if (doctorPersonInfo != null)
                        {
                            doctorPersonInfo.FirstName = Parameter.First_Name;
                            doctorPersonInfo.LastName = Parameter.Last_Name;
                            doctorPersonInfo.Title = Parameter.Title;
                            doctorPersonInfo.Modification_Timestamp = DateTime.Now;
                            if (Parameter.Salutation != null && Parameter.Salutation != string.Empty)
                                doctorPersonInfo.Salutation_General = Parameter.Salutation;
                            doctorPersonInfo.Save(Connection, Transaction);

                            var doctorCommunicationContactQ = new ORM_CMN_PER_CommunicationContact.Query();
                            doctorCommunicationContactQ.Tenant_RefID = securityTicket.TenantID;
                            doctorCommunicationContactQ.IsDeleted = false;
                            doctorCommunicationContactQ.PersonInfo_RefID = doctorPersonInfo.CMN_PER_PersonInfoID;

                            var doctorCommunicationContactList = ORM_CMN_PER_CommunicationContact.Query.Search(Connection, Transaction, doctorCommunicationContactQ);
                            foreach (var doctorCommunicationContact in doctorCommunicationContactList)
                            {
                                var doctorCommunicationContactTypeQ = new ORM_CMN_PER_CommunicationContact_Type.Query();
                                doctorCommunicationContactTypeQ.Tenant_RefID = securityTicket.TenantID;
                                doctorCommunicationContactTypeQ.IsDeleted = false;
                                doctorCommunicationContactTypeQ.CMN_PER_CommunicationContact_TypeID = doctorCommunicationContact.Contact_Type;

                                var doctorCommunicationContactType = ORM_CMN_PER_CommunicationContact_Type.Query.Search(Connection, Transaction, doctorCommunicationContactTypeQ).SingleOrDefault();

                                if (doctorCommunicationContactType != null)
                                {
                                    if (doctorCommunicationContactType.Type.Equals("Email"))
                                    {
                                        doctorCommunicationContact.Content = Parameter.Email;
                                    }
                                    if (doctorCommunicationContactType.Type.Equals("Phone"))
                                    {
                                        doctorCommunicationContact.Content = Parameter.Phone;
                                    }

                                    doctorCommunicationContact.Modification_Timestamp = DateTime.Now;
                                    doctorCommunicationContact.Save(Connection, Transaction);
                                }
                            }
                        }


                        P_DO_GPAIDfPID_1351 practiceAccountIDParameter = new P_DO_GPAIDfPID_1351();
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

                        var practiceBankInfo = cls_Get_BankInfo_for_Practice.Invoke(Connection, Transaction, new P_DO_GBAfPR_1524() { PracticeID = Parameter.PracticeID }, securityTicket).Result.SingleOrDefault();

                        if (Parameter.From_Practice_Bank)
                        {
                            var doctorBusinessParticipant2BankAccountQ = new ORM_CMN_BPT_BusinessParticipant_2_BankAccount.Query();
                            doctorBusinessParticipant2BankAccountQ.Tenant_RefID = securityTicket.TenantID;
                            doctorBusinessParticipant2BankAccountQ.IsDeleted = false;
                            doctorBusinessParticipant2BankAccountQ.ACC_BNK_BankAccount_RefID = practiceBankInfo.BankAccountID;
                            doctorBusinessParticipant2BankAccountQ.CMN_BPT_BusinessParticipant_RefID = doctorBusinessParticipant.CMN_BPT_BusinessParticipantID;

                            var oldDoctorBusinessParticipant2BankAccount = ORM_CMN_BPT_BusinessParticipant_2_BankAccount.Query.Search(Connection, Transaction, doctorBusinessParticipant2BankAccountQ).SingleOrDefault();

                            if (oldDoctorBusinessParticipant2BankAccount == null)
                            {
                                var currentDoctorBusinessParticipant2BankAccountQ = new ORM_CMN_BPT_BusinessParticipant_2_BankAccount.Query();
                                currentDoctorBusinessParticipant2BankAccountQ.Tenant_RefID = securityTicket.TenantID;
                                currentDoctorBusinessParticipant2BankAccountQ.IsDeleted = false;
                                currentDoctorBusinessParticipant2BankAccountQ.CMN_BPT_BusinessParticipant_RefID = doctorBusinessParticipant.CMN_BPT_BusinessParticipantID;

                                var currentDoctorBusinessParticipant2BankAccount = ORM_CMN_BPT_BusinessParticipant_2_BankAccount.Query.Search(Connection, Transaction, currentDoctorBusinessParticipant2BankAccountQ).SingleOrDefault();

                                if (currentDoctorBusinessParticipant2BankAccount != null)
                                {
                                    currentDoctorBusinessParticipant2BankAccount.IsDeleted = true;
                                    currentDoctorBusinessParticipant2BankAccount.Save(Connection, Transaction);
                                }

                                var doctorBusinessParticipant2BankAccount = new ORM_CMN_BPT_BusinessParticipant_2_BankAccount();
                                doctorBusinessParticipant2BankAccount.Tenant_RefID = securityTicket.TenantID;
                                doctorBusinessParticipant2BankAccount.CMN_BPT_BusinessParticipant_RefID = doctorBusinessParticipant.CMN_BPT_BusinessParticipantID;
                                doctorBusinessParticipant2BankAccount.ACC_BNK_BankAccount_RefID = practiceBankInfo.BankAccountID;
                                doctorBusinessParticipant2BankAccount.Creation_Timestamp = DateTime.Now;

                                doctorBusinessParticipant2BankAccount.Save(Connection, Transaction);
                            }

                            BankAccountID = practiceBankInfo.BankAccountID;
                        }
                        else
                        {
                            var doctorBankInfo = cls_Get_BankInfo_for_DoctorID.Invoke(Connection, Transaction, new P_DO_BBIfDID_1424() { DoctorID = Parameter.DoctorID }, securityTicket).Result;

                            if (doctorBankInfo != null)
                            {
                                var doctorBusinessParticipant2BankAccountQ = new ORM_CMN_BPT_BusinessParticipant_2_BankAccount.Query();
                                doctorBusinessParticipant2BankAccountQ.CMN_BPT_BusinessParticipant_RefID = doctorBusinessParticipant.CMN_BPT_BusinessParticipantID;
                                doctorBusinessParticipant2BankAccountQ.ACC_BNK_BankAccount_RefID = doctorBankInfo.BankAccountID;
                                doctorBusinessParticipant2BankAccountQ.Tenant_RefID = securityTicket.TenantID;
                                doctorBusinessParticipant2BankAccountQ.IsDeleted = false;

                                var doctorBusinessParticipant2BankAccount = ORM_CMN_BPT_BusinessParticipant_2_BankAccount.Query.Search(Connection, Transaction, doctorBusinessParticipant2BankAccountQ).SingleOrDefault();

                                if (doctorBusinessParticipant2BankAccount != null)
                                {
                                    var doctorBankAccountQ = new ORM_ACC_BNK_BankAccount.Query();
                                    doctorBankAccountQ.Tenant_RefID = securityTicket.TenantID;
                                    doctorBankAccountQ.IsDeleted = false;
                                    doctorBankAccountQ.ACC_BNK_BankAccountID = doctorBusinessParticipant2BankAccount.ACC_BNK_BankAccount_RefID;

                                    var doctorBankAccount = ORM_ACC_BNK_BankAccount.Query.Search(Connection, Transaction, doctorBankAccountQ).SingleOrDefault();

                                    if (doctorBankAccount != null)
                                    {
                                        if (practiceBankInfo != null && doctorBankAccount.ACC_BNK_BankAccountID != practiceBankInfo.BankAccountID)
                                        {
                                            doctorBankAccount.IBAN = Parameter.IBAN;
                                            doctorBankAccount.OwnerText = Parameter.Account_Holder;

                                            doctorBankAccount.Save(Connection, Transaction);

                                            var doctorBankQ = new ORM_ACC_BNK_Bank.Query();
                                            doctorBankQ.Tenant_RefID = securityTicket.TenantID;
                                            doctorBankQ.IsDeleted = false;
                                            doctorBankQ.ACC_BNK_BankID = doctorBankInfo.BankID;

                                            var doctorBank = ORM_ACC_BNK_Bank.Query.Search(Connection, Transaction, doctorBankQ).SingleOrDefault();

                                            if (doctorBank != null)
                                            {
                                                doctorBank.BICCode = Parameter.BIC;
                                                doctorBank.BankName = Parameter.Bank;

                                                doctorBank.Save(Connection, Transaction);
                                            }
                                        }
                                        else
                                        {
                                            var newDoctorBank = new ORM_ACC_BNK_Bank();
                                            newDoctorBank.Tenant_RefID = securityTicket.TenantID;
                                            newDoctorBank.Creation_Timestamp = DateTime.Now;
                                            newDoctorBank.BICCode = string.IsNullOrEmpty(Parameter.BIC) ? "" : Parameter.BIC;
                                            newDoctorBank.BankName = string.IsNullOrEmpty(Parameter.Bank) ? "" : Parameter.Bank;
                                            newDoctorBank.ACC_BNK_BankID = Guid.NewGuid();

                                            newDoctorBank.Save(Connection, Transaction);

                                            var newDoctorBankAccount = new ORM_ACC_BNK_BankAccount();
                                            newDoctorBankAccount.Bank_RefID = newDoctorBank.ACC_BNK_BankID;
                                            newDoctorBankAccount.Tenant_RefID = securityTicket.TenantID;
                                            newDoctorBankAccount.Creation_Timestamp = DateTime.Now;
                                            newDoctorBankAccount.IBAN = string.IsNullOrEmpty(Parameter.IBAN) ? "" : Parameter.IBAN;
                                            newDoctorBankAccount.OwnerText = string.IsNullOrEmpty(Parameter.Account_Holder) ? "" : Parameter.Account_Holder;
                                            newDoctorBankAccount.ACC_BNK_BankAccountID = Guid.NewGuid();

                                            newDoctorBankAccount.Save(Connection, Transaction);

                                            doctorBusinessParticipant2BankAccount.ACC_BNK_BankAccount_RefID = newDoctorBankAccount.ACC_BNK_BankAccountID;
                                            doctorBusinessParticipant2BankAccount.Save(Connection, Transaction);

                                            BankAccountID = newDoctorBankAccount.ACC_BNK_BankAccountID;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                var newDoctorBank = new ORM_ACC_BNK_Bank();
                                newDoctorBank.Tenant_RefID = securityTicket.TenantID;
                                newDoctorBank.Creation_Timestamp = DateTime.Now;
                                newDoctorBank.BICCode = string.IsNullOrEmpty(Parameter.BIC) ? "" : Parameter.BIC;
                                newDoctorBank.BankName = string.IsNullOrEmpty(Parameter.Bank) ? "" : Parameter.Bank;
                                newDoctorBank.ACC_BNK_BankID = Guid.NewGuid();

                                newDoctorBank.Save(Connection, Transaction);

                                var newDoctorBankAccount = new ORM_ACC_BNK_BankAccount();
                                newDoctorBankAccount.Bank_RefID = newDoctorBank.ACC_BNK_BankID;
                                newDoctorBankAccount.Tenant_RefID = securityTicket.TenantID;
                                newDoctorBankAccount.Creation_Timestamp = DateTime.Now;
                                newDoctorBankAccount.IBAN = string.IsNullOrEmpty(Parameter.IBAN) ? "" : Parameter.IBAN;
                                newDoctorBankAccount.OwnerText = string.IsNullOrEmpty(Parameter.Account_Holder) ? "" : Parameter.Account_Holder;
                                newDoctorBankAccount.ACC_BNK_BankAccountID = Guid.NewGuid();

                                newDoctorBankAccount.Save(Connection, Transaction);

                                var doctorBusinessParticipant2BankAccount = new ORM_CMN_BPT_BusinessParticipant_2_BankAccount();
                                doctorBusinessParticipant2BankAccount.Tenant_RefID = securityTicket.TenantID;
                                doctorBusinessParticipant2BankAccount.CMN_BPT_BusinessParticipant_RefID = doctorBusinessParticipant.CMN_BPT_BusinessParticipantID;
                                doctorBusinessParticipant2BankAccount.ACC_BNK_BankAccount_RefID = newDoctorBankAccount.ACC_BNK_BankAccountID;
                                doctorBusinessParticipant2BankAccount.Creation_Timestamp = DateTime.Now;

                                doctorBusinessParticipant2BankAccount.Save(Connection, Transaction);

                                BankAccountID = newDoctorBankAccount.ACC_BNK_BankAccountID;
                            }

                        }
                    }
                }
            }
            #endregion

            #region IMPORT TO ELASTIC
            List<Practice_Doctors_Model> DPModelL = new List<Practice_Doctors_Model>();

            #region IMPORT DOCTOR TO ELASTIC
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

            DPModel.account_status = Parameter.Account_Deactivated ? "inaktiv" : "aktiv";
            DPModel.id = doctor_id.ToString();

            var title = string.IsNullOrEmpty(Parameter.Title) ? "" : Parameter.Title.Trim();

            DPModel.name = title + " " + Parameter.First_Name + " " + Parameter.Last_Name;
            DPModel.name_untouched = Parameter.First_Name + " " + Parameter.Last_Name;
            DPModel.autocomplete_name = title + " " + Parameter.First_Name + " " + Parameter.Last_Name;
            DPModel.bsnr_lanr = Parameter.LANR;

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

            if (Parameter.DoctorID != Guid.Empty)
            {
                P_DO_CDCD_1505 ParameterDoctorID = new P_DO_CDCD_1505();
                ParameterDoctorID.DoctorID = Parameter.DoctorID;
                TransactionalInformation transaction = new TransactionalInformation();

                var data = cls_Check_Doctor_Contracts_Dates.Invoke(Connection, Transaction, new P_DO_CDCD_1505() { DoctorID = Parameter.DoctorID }, securityTicket).Result;

                DPModel.contract = data.Count();
            }
            else
            {
                DPModel.contract = 0;
            }

            DPModel.tenantid = securityTicket.TenantID.ToString();
            DPModel.practice_name_for_doctor = PracticeName;
            DPModel.practice_for_doctor_id = Parameter.PracticeID.ToString();

            DPModel.role = isOpPractice ? "op" : "ac";
            DPModelL.Add(DPModel);
            #endregion

            if (DPModelL.Count != 0)
                Add_New_Practice.Import_Practice_Data_to_ElasticDB(DPModelL, securityTicket.TenantID.ToString());

            #endregion

            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_DO_SD_1026 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_DO_SD_1026 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_DO_SD_1026 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_DO_SD_1026 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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
		#region SClass P_DO_SD_1026 for attribute P_DO_SD_1026
		[DataContract]
		public class P_DO_SD_1026 
		{
			//Standard type parameters
			[DataMember]
			public Guid TemporaryDoctorID { get; set; } 
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
			public String LANR { get; set; } 
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
			[DataMember]
			public String CustomerNumber { get; set; } 
			[DataMember]
			public bool IsCertificatedForOCT { get; set; } 
			[DataMember]
			public String OctValidFrom { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Doctor(,P_DO_SD_1026 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Doctor.Invoke(connectionString,P_DO_SD_1026 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Doctor.Atomic.Manipulation.P_DO_SD_1026();
parameter.TemporaryDoctorID = ...;
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
parameter.CustomerNumber = ...;
parameter.IsCertificatedForOCT = ...;
parameter.OctValidFrom = ...;

*/
