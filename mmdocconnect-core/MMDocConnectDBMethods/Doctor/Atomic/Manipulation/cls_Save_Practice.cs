/* 
 * Generated on 2/6/2017 5:28:30 PM
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
using System.Runtime.Serialization;
using System.Threading;
using System.Globalization;
using BOp.Providers.TMS;
using BOp.Providers;
using BOp.Providers.TMS.Requests;
using CL1_USR;
using CL1_CMN_BPT;
using CL1_CMN_COM;
using CL1_CMN;
using CL1_ACC_BNK;
using CL1_CMN_BPT_CTM;
using CL1_HEC;
using MMDocConnectElasticSearchMethods.Models;
using MMDocConnectElasticSearchMethods.Doctor.Manipulation;
using MMDocConnectDBMethods.Doctor.Atomic.Retrieval;
using MMDocConnectElasticSearchMethods.Doctor.Retrieval;
using MMDocConnectUtils;
using System.Web.Configuration;
using System.Web;
using System.IO;

namespace MMDocConnectDBMethods.Doctor.Atomic.Manipulation
{
	/// <summary>
    /// 
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
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_DO_SP_1547 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode

            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("de-DE");

            var returnValue = new FR_Guid();
            Guid companyInfoID = Guid.NewGuid();
            Guid BusinessParticipantID = Guid.NewGuid();
            Guid PracticeAddressID = Guid.NewGuid();
            IAccountServiceProvider accountService;
            var _providerFactory = ProviderFactory.Instance;
            accountService = _providerFactory.CreateAccountServiceProvider();
            var accId = Guid.NewGuid();
            Guid practice_id = Parameter.PracticeID;
            Guid bank_account_id = Guid.Empty;
            if (Parameter.PracticeID == Guid.Empty)
            {
                if (!String.IsNullOrEmpty(Parameter.Login_Email))
                {
                    string[] stringUser = Parameter.Login_Email.Split('@');
                    string usernameStr = stringUser[0];

                    try
                    {
                        Organization PracticeOrganization = new Organization();
                        PracticeOrganization.OrganizationName1 = Parameter.Practice_Name;
                        Account account = new Account();
                        account.ID = accId;
                        account.TenantID = securityTicket.TenantID;
                        account.Email = Parameter.Login_Email;
                        account.PasswordHash = Parameter.Account_Password;
                        account.Username = usernameStr;
                        account.AccountType = EAccountType.Standard;
                        account.Company = true;
                        account.Organization = PracticeOrganization;
                        account.Verified = true;
                        accountService.CreateAccount(account, securityTicket.SessionTicket);
                        accountService.VerifyAccount(account.ID);

                        string emailTo = Parameter.Login_Email;

                        try
                        {
                            string appName = WebConfigurationManager.AppSettings["docAppUrl"];
                            var prefix = HttpContext.Current.Request.Url.AbsoluteUri.Contains("https") ? "https://" : "http://";
                            var imageUrl = HttpContext.Current.Request.Url.AbsoluteUri.Substring(0, HttpContext.Current.Request.Url.AbsoluteUri.IndexOf("api")) + "Content/images/logo.png";
                            var email_template = File.ReadAllText(HttpContext.Current.Server.MapPath("~/EmailTemplates/PracticeWelcomeEmailTemplate.html"));

                            var subjectsJson = File.ReadAllText(HttpContext.Current.Server.MapPath("~/EmailTemplates/EmailSubjects.json"));
                            dynamic subjects = Newtonsoft.Json.JsonConvert.DeserializeObject(subjectsJson);
                            var subjectMail = subjects["PracticeWelcomeSubject"].ToString();

                            email_template = EmailTemplater.SetTemplateData(email_template, new
                            {
                                practice_name = Parameter.Practice_Name,
                                password = Parameter.Account_PasswordForEmail,
                                doc_app_url = prefix + HttpContext.Current.Request.Url.Authority + "/" + appName,
                                medios_connect_logo_url = imageUrl
                            }, "{{", "}}");

                            //string mailFrom = cls_Get_Company_Settings.Invoke(Connection, Transaction, securityTicket).Result.Email;
                            string mailFrom = WebConfigurationManager.AppSettings["mailFrom"];
                            EmailNotificationSenderUtil.SendEmail(mailFrom, emailTo, subjectMail, email_template);
                        }
                        catch (Exception ex)
                        {
                            LogUtils.Logger.LogDocAppInfo(new LogUtils.LogEntry(System.Reflection.MethodInfo.GetCurrentMethod(), ex, null, "Save practice: Email sending failed."), "EmailExceptions");
                        }

                        var practiceAccountInfo = ORM_USR_Account.Query.Search(Connection, Transaction, new ORM_USR_Account.Query()
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

                        var functionLevelRightQ = new ORM_USR_Account_FunctionLevelRight.Query();
                        functionLevelRightQ.Tenant_RefID = securityTicket.TenantID;
                        functionLevelRightQ.IsDeleted = false;
                        functionLevelRightQ.GlobalPropertyMatchingID = Parameter.Surgery_Practice ? "mm.docconect.doc.app.op.practice" : "mm.docconect.doc.app.ac.practice";

                        var existingunctionLevelRight = ORM_USR_Account_FunctionLevelRight.Query.Search(Connection, Transaction, functionLevelRightQ).SingleOrDefault();

                        Guid tempFunctionLevelRightID = Guid.Empty;

                        if (existingunctionLevelRight == null)
                        {
                            ORM_USR_Account_FunctionLevelRight functionLevelRight = new ORM_USR_Account_FunctionLevelRight();
                            functionLevelRight.USR_Account_FunctionLevelRightID = Guid.NewGuid();
                            functionLevelRight.FunctionLevelRights_Group_RefID = accountGroup.USR_Account_FunctionLevelRights_GroupID;
                            functionLevelRight.Tenant_RefID = securityTicket.TenantID;
                            functionLevelRight.Creation_Timestamp = DateTime.Now;

                            functionLevelRight.RightName = Parameter.Surgery_Practice ? "mm.docconect.doc.app.op.practice" : "mm.docconect.doc.app.ac.practice";
                            functionLevelRight.GlobalPropertyMatchingID = Parameter.Surgery_Practice ? "mm.docconect.doc.app.op.practice" : "mm.docconect.doc.app.ac.practice";

                            functionLevelRight.Save(Connection, Transaction);

                            tempFunctionLevelRightID = functionLevelRight.USR_Account_FunctionLevelRightID;
                        }
                        else
                        {
                            tempFunctionLevelRightID = existingunctionLevelRight.USR_Account_FunctionLevelRightID;
                        }

                        var accountToFunctionLevelRight = new ORM_USR_Account_2_FunctionLevelRight();
                        accountToFunctionLevelRight.Tenant_RefID = securityTicket.TenantID;
                        accountToFunctionLevelRight.Creation_Timestamp = DateTime.Now;
                        accountToFunctionLevelRight.AssignmentID = Guid.NewGuid();
                        accountToFunctionLevelRight.Account_RefID = practiceAccountInfo.USR_AccountID;
                        accountToFunctionLevelRight.FunctionLevelRight_RefID = tempFunctionLevelRightID; // USR_Account_FunctionLevelRightID
                        accountToFunctionLevelRight.Save(Connection, Transaction);

                        var businessParticipantQ = new ORM_CMN_BPT_BusinessParticipant.Query();

                        businessParticipantQ.IsDeleted = false;
                        businessParticipantQ.Tenant_RefID = securityTicket.TenantID;
                        businessParticipantQ.CMN_BPT_BusinessParticipantID = practiceAccountInfo.BusinessParticipant_RefID;
                        BusinessParticipantID = practiceAccountInfo.BusinessParticipant_RefID;

                        var practiceinfoinBusinessParticipant = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, businessParticipantQ).Single();

                        practiceinfoinBusinessParticipant.DisplayName = Parameter.Practice_Name;
                        practiceinfoinBusinessParticipant.IsCompany = true;
                        practiceinfoinBusinessParticipant.Modification_Timestamp = DateTime.Now;
                        practiceinfoinBusinessParticipant.Save(Connection, Transaction);
                        companyInfoID = practiceinfoinBusinessParticipant.IfCompany_CMN_COM_CompanyInfo_RefID;

                        var companyInfo = new ORM_CMN_COM_CompanyInfo.Query();

                        companyInfo.IsDeleted = false;
                        companyInfo.Tenant_RefID = securityTicket.TenantID;
                        companyInfo.CMN_COM_CompanyInfoID = companyInfoID;

                        var companyInfoPractice = ORM_CMN_COM_CompanyInfo.Query.Search(Connection, Transaction, companyInfo).Single();
                        companyInfoPractice.CompanyInfo_EstablishmentNumber = Parameter.BSNR;
                        companyInfoPractice.Save(Connection, Transaction);

                        var companyInfoAddressPractice = new ORM_CMN_COM_CompanyInfo_Address();
                        companyInfoAddressPractice.CompanyInfo_RefID = companyInfoID;
                        companyInfoAddressPractice.IsDefault = true;
                        companyInfoAddressPractice.IsShipping = true;
                        companyInfoAddressPractice.IsBilling = true;
                        companyInfoAddressPractice.Tenant_RefID = securityTicket.TenantID;
                        companyInfoAddressPractice.Address_UCD_RefID = Guid.NewGuid();
                        companyInfoAddressPractice.Address_Description = "Standard address for billing, shipping";
                        companyInfoAddressPractice.Save(Connection, Transaction);
                        PracticeAddressID = companyInfoAddressPractice.Address_UCD_RefID;

                        var universlContactPractice = new ORM_CMN_UniversalContactDetail();
                        universlContactPractice.IsDeleted = false;
                        universlContactPractice.Tenant_RefID = securityTicket.TenantID;
                        universlContactPractice.CMN_UniversalContactDetailID = PracticeAddressID;
                        universlContactPractice.CompanyName_Line1 = Parameter.Practice_Name;
                        universlContactPractice.IsCompany = true;
                        universlContactPractice.Street_Name = Parameter.Street;
                        universlContactPractice.Street_Number = Parameter.No;
                        universlContactPractice.ZIP = Parameter.Zip;
                        universlContactPractice.Town = Parameter.City;
                        universlContactPractice.Contact_Email = Parameter.Main_Email;
                        universlContactPractice.Contact_Telephone = Parameter.Main_Phone;
                        universlContactPractice.Contact_Fax = Parameter.Fax;
                        universlContactPractice.Creation_Timestamp = DateTime.Now;
                        universlContactPractice.Modification_Timestamp = DateTime.Now;
                        universlContactPractice.Save(Connection, Transaction);

                    }
                    catch (Exception ex)
                    {

                        throw new Exception("Exception occured durng data retrieval in method cls_Save_Practice", ex);
                        //Log the error (uncomment dex variable name and add a line here to write a log.
                    }
                }

                var companyInfoAddress2 = new ORM_CMN_COM_CompanyInfo_Address();
                companyInfoAddress2.IsDeleted = false;
                companyInfoAddress2.Tenant_RefID = securityTicket.TenantID;
                companyInfoAddress2.CompanyInfo_RefID = companyInfoID;
                companyInfoAddress2.IsDefault = true;
                companyInfoAddress2.IsContact = true;
                companyInfoAddress2.Address_UCD_RefID = Guid.NewGuid();
                companyInfoAddress2.Address_Description = "Standard contact person data";
                companyInfoAddress2.Creation_Timestamp = DateTime.Now;
                companyInfoAddress2.Save(Connection, Transaction);

                var universlContactPractice2 = new ORM_CMN_UniversalContactDetail();
                universlContactPractice2.CMN_UniversalContactDetailID = companyInfoAddress2.Address_UCD_RefID;
                universlContactPractice2.IsDeleted = false;
                universlContactPractice2.Tenant_RefID = securityTicket.TenantID;
                universlContactPractice2.IsCompany = false;
                universlContactPractice2.First_Name = Parameter.Contact_PersonFirstName;
                universlContactPractice2.Last_Name = Parameter.Contact_PersonLastName;
                universlContactPractice2.Contact_Email = Parameter.Email;
                universlContactPractice2.Contact_Telephone = Parameter.Phone;
                universlContactPractice2.Creation_Timestamp = DateTime.Now;
                universlContactPractice2.Modification_Timestamp = DateTime.Now;
                universlContactPractice2.Save(Connection, Transaction);

                var business2bankAccount = new ORM_CMN_BPT_BusinessParticipant_2_BankAccount();
                business2bankAccount.IsDeleted = false;
                business2bankAccount.Tenant_RefID = securityTicket.TenantID;
                business2bankAccount.CMN_BPT_BusinessParticipant_RefID = BusinessParticipantID;
                business2bankAccount.ACC_BNK_BankAccount_RefID = Guid.NewGuid();
                business2bankAccount.Creation_Timestamp = DateTime.Now;
                business2bankAccount.Save(Connection, Transaction);

                var bankAccountPractice = new ORM_ACC_BNK_BankAccount();
                bankAccountPractice.IsDeleted = false;
                bankAccountPractice.Tenant_RefID = securityTicket.TenantID;
                bankAccountPractice.ACC_BNK_BankAccountID = business2bankAccount.ACC_BNK_BankAccount_RefID;
                bankAccountPractice.OwnerText = Parameter.Account_Holder;
                bankAccountPractice.IBAN = Parameter.IBAN;
                bankAccountPractice.Bank_RefID = Guid.NewGuid();
                bankAccountPractice.Creation_Timestamp = DateTime.Now;
                bankAccountPractice.Save(Connection, Transaction);

                var bank = new ORM_ACC_BNK_Bank();
                bank.IsDeleted = false;
                bank.Tenant_RefID = securityTicket.TenantID;
                bank.ACC_BNK_BankID = bankAccountPractice.Bank_RefID;
                bank.BICCode = Parameter.BIC;
                bank.BankName = Parameter.Bank;
                bank.Creation_Timestamp = DateTime.Now;
                bank.Save(Connection, Transaction);

                var customer = new ORM_CMN_BPT_CTM_Customer();
                customer.IsDeleted = false;
                customer.Tenant_RefID = securityTicket.TenantID;
                customer.Ext_BusinessParticipant_RefID = BusinessParticipantID;
                customer.CMN_BPT_CTM_CustomerID = Guid.NewGuid();
                customer.Creation_Timestamp = DateTime.Now;
                customer.Save(Connection, Transaction);

                var organizationalUnit = new ORM_CMN_BPT_CTM_OrganizationalUnit();
                organizationalUnit.IsDeleted = false;
                organizationalUnit.Tenant_RefID = securityTicket.TenantID;
                organizationalUnit.Customer_RefID = customer.CMN_BPT_CTM_CustomerID;
                organizationalUnit.IsMedicalPractice = true;
                organizationalUnit.IfMedicalPractise_HEC_MedicalPractice_RefID = Guid.NewGuid();
                organizationalUnit.Creation_Timestamp = DateTime.Now;
                organizationalUnit.Modification_Timestamp = DateTime.Now;
                organizationalUnit.Save(Connection, Transaction);

                var medicalPractice = new ORM_HEC_MedicalPractis();

                medicalPractice.IsDeleted = false;
                medicalPractice.Tenant_RefID = securityTicket.TenantID;
                medicalPractice.HEC_MedicalPractiseID = organizationalUnit.IfMedicalPractise_HEC_MedicalPractice_RefID;
                medicalPractice.Creation_Timestamp = DateTime.Now;
                medicalPractice.Modification_Timestamp = DateTime.Now;
                medicalPractice.Save(Connection, Transaction);

                practice_id = medicalPractice.HEC_MedicalPractiseID;

                var medicalPRactice2Universal = new ORM_HEC_MedicalPractice_2_UniversalProperty();

                medicalPRactice2Universal.IsDeleted = false;
                medicalPRactice2Universal.Tenant_RefID = securityTicket.TenantID;
                medicalPRactice2Universal.HEC_MedicalPractice_RefID = medicalPractice.HEC_MedicalPractiseID;
                medicalPRactice2Universal.HEC_MedicalPractice_UniversalProperty_RefID = Guid.NewGuid();
                medicalPRactice2Universal.Value_Boolean = Parameter.Surgery_Practice;
                medicalPRactice2Universal.Creation_Timestamp = DateTime.Now;
                medicalPRactice2Universal.Modification_Timestamp = DateTime.Now;
                medicalPRactice2Universal.Save(Connection, Transaction);

                var practiceUniversal = new ORM_HEC_MedicalPractice_UniversalProperty();
                practiceUniversal.IsDeleted = false;
                practiceUniversal.Tenant_RefID = securityTicket.TenantID;
                practiceUniversal.HEC_MedicalPractice_UniversalPropertyID = medicalPRactice2Universal.HEC_MedicalPractice_UniversalProperty_RefID;
                practiceUniversal.PropertyName = "Surgery Practice";
                practiceUniversal.IsValue_Boolean = true;
                practiceUniversal.Creation_Timestamp = DateTime.Now;
                practiceUniversal.Modification_Timestamp = DateTime.Now;
                practiceUniversal.Save(Connection, Transaction);


                var medicalPRactice2Universal2 = new ORM_HEC_MedicalPractice_2_UniversalProperty();
                medicalPRactice2Universal2.Tenant_RefID = securityTicket.TenantID;
                medicalPRactice2Universal2.HEC_MedicalPractice_RefID = medicalPractice.HEC_MedicalPractiseID;
                medicalPRactice2Universal2.HEC_MedicalPractice_UniversalProperty_RefID = Guid.NewGuid();
                medicalPRactice2Universal2.Value_Boolean = Parameter.Orders_Drugs;
                medicalPRactice2Universal2.Creation_Timestamp = DateTime.Now;
                medicalPRactice2Universal2.Modification_Timestamp = DateTime.Now;
                medicalPRactice2Universal2.Save(Connection, Transaction);

                var practiceUniversal2 = new ORM_HEC_MedicalPractice_UniversalProperty();
                practiceUniversal2.IsDeleted = false;
                practiceUniversal2.Tenant_RefID = securityTicket.TenantID;
                practiceUniversal2.HEC_MedicalPractice_UniversalPropertyID = medicalPRactice2Universal2.HEC_MedicalPractice_UniversalProperty_RefID;
                practiceUniversal2.PropertyName = "Order Drugs";
                practiceUniversal2.IsValue_Boolean = true;
                practiceUniversal2.Creation_Timestamp = DateTime.Now;
                practiceUniversal2.Modification_Timestamp = DateTime.Now;
                practiceUniversal2.Save(Connection, Transaction);

                // default shipping date offset 

                var medicalPRactice2Universal3 = new ORM_HEC_MedicalPractice_2_UniversalProperty();
                medicalPRactice2Universal3.Tenant_RefID = securityTicket.TenantID;
                medicalPRactice2Universal3.HEC_MedicalPractice_RefID = medicalPractice.HEC_MedicalPractiseID;
                medicalPRactice2Universal3.HEC_MedicalPractice_UniversalProperty_RefID = Guid.NewGuid();
                medicalPRactice2Universal3.Value_Number = double.Parse(Parameter.Default_Shipping_Date_Offset);
                medicalPRactice2Universal3.Creation_Timestamp = DateTime.Now;
                medicalPRactice2Universal3.Modification_Timestamp = DateTime.Now;
                medicalPRactice2Universal3.Save(Connection, Transaction);

                var practiceUniversal3 = new ORM_HEC_MedicalPractice_UniversalProperty();
                practiceUniversal3.IsDeleted = false;
                practiceUniversal3.Tenant_RefID = securityTicket.TenantID;
                practiceUniversal3.HEC_MedicalPractice_UniversalPropertyID = medicalPRactice2Universal3.HEC_MedicalPractice_UniversalProperty_RefID;
                practiceUniversal3.PropertyName = "Default Shipping Date Offset";
                practiceUniversal3.IsValue_Number = true;
                practiceUniversal3.Creation_Timestamp = DateTime.Now;
                practiceUniversal3.Modification_Timestamp = DateTime.Now;
                practiceUniversal3.Save(Connection, Transaction);

                var medicalPRactice2Universal4 = new ORM_HEC_MedicalPractice_2_UniversalProperty();
                medicalPRactice2Universal4.Tenant_RefID = securityTicket.TenantID;
                medicalPRactice2Universal4.HEC_MedicalPractice_RefID = medicalPractice.HEC_MedicalPractiseID;
                medicalPRactice2Universal4.HEC_MedicalPractice_UniversalProperty_RefID = Guid.NewGuid();
                medicalPRactice2Universal4.Value_Boolean = Parameter.Only_Label_Required;
                medicalPRactice2Universal4.Creation_Timestamp = DateTime.Now;
                medicalPRactice2Universal4.Modification_Timestamp = DateTime.Now;
                medicalPRactice2Universal4.Save(Connection, Transaction);

                var practiceUniversal4 = new ORM_HEC_MedicalPractice_UniversalProperty();
                practiceUniversal4.IsDeleted = false;
                practiceUniversal4.Tenant_RefID = securityTicket.TenantID;
                practiceUniversal4.HEC_MedicalPractice_UniversalPropertyID = medicalPRactice2Universal4.HEC_MedicalPractice_UniversalProperty_RefID;
                practiceUniversal4.PropertyName = "Only Label Required";
                practiceUniversal4.IsValue_Boolean = true;
                practiceUniversal4.Creation_Timestamp = DateTime.Now;
                practiceUniversal4.Modification_Timestamp = DateTime.Now;
                practiceUniversal4.Save(Connection, Transaction);

                var medicalPRactice2Universal5 = new ORM_HEC_MedicalPractice_2_UniversalProperty();
                medicalPRactice2Universal5.Tenant_RefID = securityTicket.TenantID;
                medicalPRactice2Universal5.HEC_MedicalPractice_RefID = medicalPractice.HEC_MedicalPractiseID;
                medicalPRactice2Universal5.HEC_MedicalPractice_UniversalProperty_RefID = Guid.NewGuid();
                medicalPRactice2Universal5.Value_Boolean = Parameter.Waive_Service_Fee;
                medicalPRactice2Universal5.Creation_Timestamp = DateTime.Now;
                medicalPRactice2Universal5.Modification_Timestamp = DateTime.Now;
                medicalPRactice2Universal5.Save(Connection, Transaction);

                var practiceUniversal5 = new ORM_HEC_MedicalPractice_UniversalProperty();
                practiceUniversal5.IsDeleted = false;
                practiceUniversal5.Tenant_RefID = securityTicket.TenantID;
                practiceUniversal5.HEC_MedicalPractice_UniversalPropertyID = medicalPRactice2Universal5.HEC_MedicalPractice_UniversalProperty_RefID;
                practiceUniversal5.PropertyName = "Waive Service Fee";
                practiceUniversal5.IsValue_Boolean = true;
                practiceUniversal5.Creation_Timestamp = DateTime.Now;
                practiceUniversal5.Modification_Timestamp = DateTime.Now;
                practiceUniversal5.Save(Connection, Transaction);
            }
            else
            {
                if (Parameter.Account_Deactivated)
                {
                    var practiceAccountID = cls_Get_Practice_AccountID_for_PracticeID.Invoke(Connection, Transaction, new P_DO_GPAIDfPID_1351() { PracticeID = Parameter.PracticeID }, securityTicket).Result.accountID;

                    var accountStatus = accountService.GetAccountStatusHistory(securityTicket.TenantID, practiceAccountID).OrderBy(sth => sth.CreationTimestamp).Reverse().FirstOrDefault();

                    if (accountStatus.Status != EAccountStatus.BANNED)
                        accountService.BanAccount(practiceAccountID, "Konto wurde vom Administrator deaktiviert");

                    if (Parameter.Change_Doctor_Account_Statuses)
                    {
                        var doctor_ids = cls_Get_DoctorIDs_for_PracticeID.Invoke(Connection, Transaction, new P_DO_GDIDsfPID_1635() { PracticeID = Parameter.PracticeID }, securityTicket).Result;

                        foreach (var doctor_id in doctor_ids)
                        {
                            var doctor_account_id = cls_Get_Doctor_AccountID_for_DoctorID.Invoke(Connection, Transaction, new P_DO_GDAIDfDID_1549() { DoctorID = doctor_id.DoctorID }, securityTicket).Result.accountID;

                            var doctor_account_status = accountService.GetAccountStatusHistory(securityTicket.TenantID, doctor_account_id).OrderBy(sth => sth.CreationTimestamp).Reverse().FirstOrDefault();

                            if (doctor_account_status.Status != EAccountStatus.BANNED)
                                accountService.BanAccount(doctor_account_id, "Konto wurde vom Administrator deaktiviert");
                        }

                        var doctors_elastic = Get_Doctors_for_PracticeID.Get_Doctors_That_Work_In_Practice_for_PracticeID(new Practice_Parameter()
                        {
                            practice_id = Parameter.PracticeID
                        }, securityTicket);

                        if (doctors_elastic.Any())
                        {
                            foreach (var doctor in doctors_elastic)
                            {
                                doctor.account_status = "inaktiv";
                            }

                            Add_New_Practice.Import_Practice_Data_to_ElasticDB(doctors_elastic, securityTicket.TenantID.ToString());
                        }
                    }
                }
                else
                {
                    var practiceAccountID = cls_Get_Practice_AccountID_for_PracticeID.Invoke(Connection, Transaction, new P_DO_GPAIDfPID_1351() { PracticeID = Parameter.PracticeID }, securityTicket).Result.accountID;

                    var accountStatus = accountService.GetAccountStatusHistory(securityTicket.TenantID, practiceAccountID).OrderBy(sth => sth.CreationTimestamp).Reverse().FirstOrDefault();

                    if (accountStatus.Status == EAccountStatus.BANNED)
                        accountService.UnbanAccount(practiceAccountID);

                    if (Parameter.Change_Doctor_Account_Statuses)
                    {
                        var doctor_ids = cls_Get_DoctorIDs_for_PracticeID.Invoke(Connection, Transaction, new P_DO_GDIDsfPID_1635() { PracticeID = Parameter.PracticeID }, securityTicket).Result;

                        foreach (var doctor_id in doctor_ids)
                        {
                            var doctor_account_id = cls_Get_Doctor_AccountID_for_DoctorID.Invoke(Connection, Transaction, new P_DO_GDAIDfDID_1549() { DoctorID = doctor_id.DoctorID }, securityTicket).Result.accountID;

                            var doctor_account_status = accountService.GetAccountStatusHistory(securityTicket.TenantID, doctor_account_id).OrderBy(sth => sth.CreationTimestamp).Reverse().FirstOrDefault();

                            if (doctor_account_status.Status == EAccountStatus.BANNED)
                                accountService.UnbanAccount(doctor_account_id);
                        }

                        var doctors_elastic = Get_Doctors_for_PracticeID.Get_Doctors_That_Work_In_Practice_for_PracticeID(new Practice_Parameter()
                        {
                            practice_id = Parameter.PracticeID
                        }, securityTicket);

                        if (doctors_elastic.Any())
                        {
                            foreach (var doctor in doctors_elastic)
                            {
                                doctor.account_status = "aktiv";
                            }

                            Add_New_Practice.Import_Practice_Data_to_ElasticDB(doctors_elastic, securityTicket.TenantID.ToString());
                        }
                    }
                }

                var bankNameChanged = false;
                var accountHolderChanged = false;
                var ibanChanged = false;
                var bicChanged = false;

                var medicalPracticeQ = new ORM_HEC_MedicalPractis.Query();
                medicalPracticeQ.Tenant_RefID = securityTicket.TenantID;
                medicalPracticeQ.IsDeleted = false;
                medicalPracticeQ.HEC_MedicalPractiseID = Parameter.PracticeID;

                var medicalPractice = ORM_HEC_MedicalPractis.Query.Search(Connection, Transaction, medicalPracticeQ).SingleOrDefault();
                if (medicalPractice != null)
                {
                    var organizationalUnitQ = new ORM_CMN_BPT_CTM_OrganizationalUnit.Query();
                    organizationalUnitQ.Tenant_RefID = securityTicket.TenantID;
                    organizationalUnitQ.IfMedicalPractise_HEC_MedicalPractice_RefID = Parameter.PracticeID;
                    organizationalUnitQ.IsDeleted = false;

                    var organizationalUnit = ORM_CMN_BPT_CTM_OrganizationalUnit.Query.Search(Connection, Transaction, organizationalUnitQ).SingleOrDefault();

                    if (organizationalUnit != null)
                    {
                        var customerQ = new ORM_CMN_BPT_CTM_Customer.Query();
                        customerQ.Tenant_RefID = securityTicket.TenantID;
                        customerQ.IsDeleted = false;
                        customerQ.CMN_BPT_CTM_CustomerID = organizationalUnit.Customer_RefID;

                        var customer = ORM_CMN_BPT_CTM_Customer.Query.Search(Connection, Transaction, customerQ).SingleOrDefault();

                        if (customer != null)
                        {
                            var businessParticipantQ = new ORM_CMN_BPT_BusinessParticipant.Query();
                            businessParticipantQ.Tenant_RefID = securityTicket.TenantID;
                            businessParticipantQ.IsDeleted = false;
                            businessParticipantQ.CMN_BPT_BusinessParticipantID = customer.Ext_BusinessParticipant_RefID;

                            var businessParticipant = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, businessParticipantQ).SingleOrDefault();

                            if (businessParticipant != null)
                            {
                                businessParticipant.DisplayName = Parameter.Practice_Name;
                                businessParticipant.Save(Connection, Transaction);

                                var business2bankAccountQ = new ORM_CMN_BPT_BusinessParticipant_2_BankAccount.Query();
                                business2bankAccountQ.Tenant_RefID = securityTicket.TenantID;
                                business2bankAccountQ.IsDeleted = false;
                                business2bankAccountQ.CMN_BPT_BusinessParticipant_RefID = businessParticipant.CMN_BPT_BusinessParticipantID;

                                var business2bankAccount = ORM_CMN_BPT_BusinessParticipant_2_BankAccount.Query.Search(Connection, Transaction, business2bankAccountQ).SingleOrDefault();

                                if (business2bankAccount != null)
                                {
                                    var bankAccountPracticeQ = new ORM_ACC_BNK_BankAccount.Query();
                                    bankAccountPracticeQ.Tenant_RefID = securityTicket.TenantID;
                                    bankAccountPracticeQ.IsDeleted = false;
                                    bankAccountPracticeQ.ACC_BNK_BankAccountID = business2bankAccount.ACC_BNK_BankAccount_RefID;

                                    var bankAccountPractice = ORM_ACC_BNK_BankAccount.Query.Search(Connection, Transaction, bankAccountPracticeQ).SingleOrDefault();
                                    bank_account_id = business2bankAccount.ACC_BNK_BankAccount_RefID;

                                    if (bankAccountPractice != null)
                                    {
                                        try
                                        {
                                            accountHolderChanged = !bankAccountPractice.OwnerText.Equals(Parameter.Account_Holder);
                                            if (!String.IsNullOrEmpty(bankAccountPractice.IBAN))
                                                ibanChanged = !bankAccountPractice.IBAN.Equals(Parameter.IBAN);

                                            bankAccountPractice.OwnerText = Parameter.Account_Holder;
                                            bankAccountPractice.IBAN = Parameter.IBAN;

                                            bankAccountPractice.Save(Connection, Transaction);
                                        }
                                        catch { }
                                        var bankQ = new ORM_ACC_BNK_Bank.Query();
                                        bankQ.IsDeleted = false;
                                        bankQ.Tenant_RefID = securityTicket.TenantID;
                                        bankQ.ACC_BNK_BankID = bankAccountPractice.Bank_RefID;

                                        var bank = ORM_ACC_BNK_Bank.Query.Search(Connection, Transaction, bankQ).SingleOrDefault();

                                        if (bank != null)
                                        {
                                            bankNameChanged = !bank.BankName.Equals(Parameter.Bank);
                                            bicChanged = !bank.BICCode.Equals(Parameter.BIC);

                                            bank.BICCode = Parameter.BIC;
                                            bank.BankName = Parameter.Bank;

                                            bank.Save(Connection, Transaction);
                                        }
                                    }
                                }

                                var companyInfoQ = new ORM_CMN_COM_CompanyInfo.Query();
                                companyInfoQ.Tenant_RefID = securityTicket.TenantID;
                                companyInfoQ.IsDeleted = false;
                                companyInfoQ.CMN_COM_CompanyInfoID = businessParticipant.IfCompany_CMN_COM_CompanyInfo_RefID;

                                var companyInfo = ORM_CMN_COM_CompanyInfo.Query.Search(Connection, Transaction, companyInfoQ).SingleOrDefault();

                                if (companyInfo != null)
                                {
                                    companyInfo.CompanyInfo_EstablishmentNumber = Parameter.BSNR;
                                    var companyInfoAddressQ = new ORM_CMN_COM_CompanyInfo_Address.Query();
                                    companyInfoAddressQ.Tenant_RefID = securityTicket.TenantID;
                                    companyInfoAddressQ.IsDeleted = false;
                                    companyInfoAddressQ.CompanyInfo_RefID = companyInfo.CMN_COM_CompanyInfoID;

                                    var companyInfoAddressList = ORM_CMN_COM_CompanyInfo_Address.Query.Search(Connection, Transaction, companyInfoAddressQ);

                                    var universalContactPracticeQ = new ORM_CMN_UniversalContactDetail.Query();
                                    universalContactPracticeQ.Tenant_RefID = securityTicket.TenantID;
                                    universalContactPracticeQ.IsDeleted = false;

                                    foreach (var companyInfoAddress in companyInfoAddressList)
                                    {
                                        universalContactPracticeQ.CMN_UniversalContactDetailID = companyInfoAddress.Address_UCD_RefID;

                                        var universalContactPractice = ORM_CMN_UniversalContactDetail.Query.Search(Connection, Transaction, universalContactPracticeQ).SingleOrDefault();

                                        if (universalContactPractice != null)
                                        {
                                            if (universalContactPractice.IsCompany)
                                            {
                                                universalContactPractice.CompanyName_Line1 = Parameter.Practice_Name;
                                                universalContactPractice.Street_Name = Parameter.Street;
                                                universalContactPractice.Street_Number = Parameter.No;
                                                universalContactPractice.ZIP = Parameter.Zip;
                                                universalContactPractice.Town = Parameter.City;
                                                universalContactPractice.Contact_Email = Parameter.Main_Email;
                                                universalContactPractice.Contact_Telephone = Parameter.Main_Phone;
                                                universalContactPractice.Contact_Fax = Parameter.Fax;
                                            }
                                            else
                                            {
                                                universalContactPractice.First_Name = Parameter.Contact_PersonFirstName;
                                                universalContactPractice.Last_Name = Parameter.Contact_PersonLastName;
                                                universalContactPractice.Contact_Email = Parameter.Email;
                                                universalContactPractice.Contact_Telephone = Parameter.Phone;
                                            }

                                            universalContactPractice.Modification_Timestamp = DateTime.Now;
                                            universalContactPractice.Save(Connection, Transaction);

                                        }
                                    }
                                    companyInfo.Save(Connection, Transaction);
                                }
                            }
                        }

                        if (bankNameChanged || ibanChanged || bicChanged)
                        {
                            var doctorsThatInheritBankInfoList = Get_Doctors_for_PracticeID.Get_Doctors_for_PracticeID_with_Bank_Account_Inheritance(new Practice_Parameter()
                            {
                                practice_id = Parameter.PracticeID,
                                practice_bank_account_id = bank_account_id.ToString(),
                                account_status = null
                            }, securityTicket);

                            if (doctorsThatInheritBankInfoList.Any())
                            {
                                foreach (var doctor in doctorsThatInheritBankInfoList)
                                {
                                    doctor.bank = Parameter.Bank;
                                    doctor.iban = Parameter.IBAN;
                                    doctor.bic = Parameter.BIC;
                                }

                                Add_New_Practice.Import_Practice_Data_to_ElasticDB(doctorsThatInheritBankInfoList, securityTicket.TenantID.ToString());
                            }
                        }

                        var doctorsList = Get_Doctors_for_PracticeID.Get_Doctors_That_Work_In_Practice_for_PracticeID(new Practice_Parameter()
                        {
                            practice_id = Parameter.PracticeID
                        }, securityTicket);

                        if (doctorsList.Any())
                        {
                            foreach (var doctor in doctorsList)
                            {
                                doctor.practice_name_for_doctor = Parameter.Practice_Name;
                                doctor.address = Parameter.Street + " " + Parameter.No;
                                doctor.zip = Parameter.Zip;
                                doctor.city = Parameter.City;
                                doctor.role = Parameter.Surgery_Practice ? "op" : "ac";
                            }

                            Add_New_Practice.Import_Practice_Data_to_ElasticDB(doctorsList, securityTicket.TenantID.ToString());
                        }
                    }

                    var medicalPRactice2UniversalQ = new ORM_HEC_MedicalPractice_2_UniversalProperty.Query();
                    medicalPRactice2UniversalQ.Tenant_RefID = securityTicket.TenantID;
                    medicalPRactice2UniversalQ.IsDeleted = false;
                    medicalPRactice2UniversalQ.HEC_MedicalPractice_RefID = Parameter.PracticeID;

                    var medicalPRactice2UniversalList = ORM_HEC_MedicalPractice_2_UniversalProperty.Query.Search(Connection, Transaction, medicalPRactice2UniversalQ);

                    var practiceUniversalQ = new ORM_HEC_MedicalPractice_UniversalProperty.Query();
                    practiceUniversalQ.Tenant_RefID = securityTicket.TenantID;
                    practiceUniversalQ.IsDeleted = false;

                    foreach (var medicalPractice2Universal in medicalPRactice2UniversalList)
                    {
                        practiceUniversalQ.HEC_MedicalPractice_UniversalPropertyID = medicalPractice2Universal.HEC_MedicalPractice_UniversalProperty_RefID;

                        var practiceUniversal = ORM_HEC_MedicalPractice_UniversalProperty.Query.Search(Connection, Transaction, practiceUniversalQ).SingleOrDefault();

                        if (practiceUniversal != null)
                        {
                            if (practiceUniversal.PropertyName.Equals("Default Shipping Date Offset"))
                            {
                                medicalPractice2Universal.Value_Number = double.Parse(Parameter.Default_Shipping_Date_Offset);
                            }

                            if (practiceUniversal.PropertyName.Equals("Only Label Required"))
                            {
                                medicalPractice2Universal.Value_Boolean = Parameter.Only_Label_Required;
                            }

                            if (practiceUniversal.PropertyName.Equals("Waive Service Fee"))
                            {
                                medicalPractice2Universal.Value_Boolean = Parameter.Waive_Service_Fee;
                            }

                            if (practiceUniversal.PropertyName.Equals("Surgery Practice"))
                            {
                                if (medicalPractice2Universal.Value_Boolean != Parameter.Surgery_Practice)
                                {
                                    medicalPractice2Universal.Modification_Timestamp = DateTime.Now;
                                    medicalPractice2Universal.Value_Boolean = Parameter.Surgery_Practice;

                                    P_DO_GPAIDfPID_1351 practiceAccountIDParameter = new P_DO_GPAIDfPID_1351();
                                    practiceAccountIDParameter.PracticeID = Parameter.PracticeID;
                                    var practiceAccountID = cls_Get_Practice_AccountID_for_PracticeID.Invoke(Connection, Transaction, practiceAccountIDParameter, securityTicket).Result.accountID;

                                    var globalPropertyMatchingID = Parameter.Surgery_Practice ? "mm.docconect.doc.app.op.practice" : "mm.docconect.doc.app.ac.practice";

                                    var opFunctionLevelRightQ = new ORM_USR_Account_FunctionLevelRight.Query();
                                    opFunctionLevelRightQ.Tenant_RefID = securityTicket.TenantID;
                                    opFunctionLevelRightQ.IsDeleted = false;
                                    opFunctionLevelRightQ.GlobalPropertyMatchingID = globalPropertyMatchingID;

                                    var opFunctionLevelRight = ORM_USR_Account_FunctionLevelRight.Query.Search(Connection, Transaction, opFunctionLevelRightQ).SingleOrDefault();

                                    if (opFunctionLevelRight != null)
                                    {
                                        //check if connecting table already exists
                                        var practiceAccountToFunctionLevelRightQ = new ORM_USR_Account_2_FunctionLevelRight.Query();
                                        practiceAccountToFunctionLevelRightQ.Account_RefID = practiceAccountID;
                                        practiceAccountToFunctionLevelRightQ.FunctionLevelRight_RefID = opFunctionLevelRight.USR_Account_FunctionLevelRightID;
                                        practiceAccountToFunctionLevelRightQ.Tenant_RefID = securityTicket.TenantID;
                                        practiceAccountToFunctionLevelRightQ.IsDeleted = true;

                                        var practiceAccountToFunctionLevelRight = ORM_USR_Account_2_FunctionLevelRight.Query.Search(Connection, Transaction, practiceAccountToFunctionLevelRightQ).SingleOrDefault();

                                        //delete current connecting table
                                        var currentPracticeAccountToFunctionLevelRightQ = new ORM_USR_Account_2_FunctionLevelRight.Query();
                                        currentPracticeAccountToFunctionLevelRightQ.Account_RefID = practiceAccountID;
                                        currentPracticeAccountToFunctionLevelRightQ.Tenant_RefID = securityTicket.TenantID;
                                        currentPracticeAccountToFunctionLevelRightQ.IsDeleted = false;

                                        var currentPracticeAccountToFunctionLevelRight = ORM_USR_Account_2_FunctionLevelRight.Query.Search(Connection, Transaction, currentPracticeAccountToFunctionLevelRightQ).SingleOrDefault();

                                        if (currentPracticeAccountToFunctionLevelRight != null)
                                        {
                                            currentPracticeAccountToFunctionLevelRight.IsDeleted = true;
                                            currentPracticeAccountToFunctionLevelRight.Save(Connection, Transaction);
                                        }

                                        //if yes, reinstate it
                                        if (practiceAccountToFunctionLevelRight != null)
                                        {
                                            practiceAccountToFunctionLevelRight.IsDeleted = false;
                                            practiceAccountToFunctionLevelRight.Save(Connection, Transaction);
                                        }
                                        //if not, create new connecting table
                                        else
                                        {
                                            var newPracticeAccountToFunctionLevelRight = new ORM_USR_Account_2_FunctionLevelRight();
                                            newPracticeAccountToFunctionLevelRight.Account_RefID = practiceAccountID;
                                            newPracticeAccountToFunctionLevelRight.FunctionLevelRight_RefID = opFunctionLevelRight.USR_Account_FunctionLevelRightID;
                                            newPracticeAccountToFunctionLevelRight.Tenant_RefID = securityTicket.TenantID;
                                            newPracticeAccountToFunctionLevelRight.IsDeleted = false;
                                            newPracticeAccountToFunctionLevelRight.Creation_Timestamp = DateTime.Now;

                                            newPracticeAccountToFunctionLevelRight.Save(Connection, Transaction);
                                        }
                                    }
                                    else
                                    {
                                        var currentFunctionLevelRightQ = new ORM_USR_Account_FunctionLevelRight.Query();
                                        currentFunctionLevelRightQ.Tenant_RefID = securityTicket.TenantID;
                                        currentFunctionLevelRightQ.IsDeleted = false;
                                        currentFunctionLevelRightQ.GlobalPropertyMatchingID = Parameter.Surgery_Practice ? "mm.docconect.doc.app.ac.practice" : "mm.docconect.doc.app.op.practice";

                                        var currentFunctionLevelRight = ORM_USR_Account_FunctionLevelRight.Query.Search(Connection, Transaction, currentFunctionLevelRightQ).SingleOrDefault();
                                        //check if connecting table already exists
                                        var practiceAccountToFunctionLevelRightQ = new ORM_USR_Account_2_FunctionLevelRight.Query();
                                        practiceAccountToFunctionLevelRightQ.Account_RefID = practiceAccountID;
                                        practiceAccountToFunctionLevelRightQ.FunctionLevelRight_RefID = currentFunctionLevelRight.USR_Account_FunctionLevelRightID;
                                        practiceAccountToFunctionLevelRightQ.Tenant_RefID = securityTicket.TenantID;
                                        practiceAccountToFunctionLevelRightQ.IsDeleted = true;

                                        var practiceAccountToFunctionLevelRight = ORM_USR_Account_2_FunctionLevelRight.Query.Search(Connection, Transaction, practiceAccountToFunctionLevelRightQ).SingleOrDefault();

                                        //delete current connecting table
                                        var currentPracticeAccountToFunctionLevelRightQ = new ORM_USR_Account_2_FunctionLevelRight.Query();
                                        currentPracticeAccountToFunctionLevelRightQ.Account_RefID = practiceAccountID;
                                        currentPracticeAccountToFunctionLevelRightQ.Tenant_RefID = securityTicket.TenantID;
                                        currentPracticeAccountToFunctionLevelRightQ.IsDeleted = false;

                                        var currentPracticeAccountToFunctionLevelRight = ORM_USR_Account_2_FunctionLevelRight.Query.Search(Connection, Transaction, currentPracticeAccountToFunctionLevelRightQ).SingleOrDefault();

                                        if (currentPracticeAccountToFunctionLevelRight != null)
                                        {
                                            currentPracticeAccountToFunctionLevelRight.IsDeleted = true;
                                            currentPracticeAccountToFunctionLevelRight.Save(Connection, Transaction);
                                        }

                                        var accountGroupQuery = new ORM_USR_Account_FunctionLevelRights_Group.Query();
                                        accountGroupQuery.Tenant_RefID = securityTicket.TenantID;
                                        accountGroupQuery.IsDeleted = false;
                                        accountGroupQuery.GlobalPropertyMatchingID = "mm.docconect.doc.app.group";

                                        var accountGroup = ORM_USR_Account_FunctionLevelRights_Group.Query.Search(Connection, Transaction, accountGroupQuery).SingleOrDefault();

                                        ORM_USR_Account_FunctionLevelRight functionLevelRight = new ORM_USR_Account_FunctionLevelRight();
                                        functionLevelRight.USR_Account_FunctionLevelRightID = Guid.NewGuid();
                                        functionLevelRight.FunctionLevelRights_Group_RefID = accountGroup.USR_Account_FunctionLevelRights_GroupID;
                                        functionLevelRight.Tenant_RefID = securityTicket.TenantID;
                                        functionLevelRight.Creation_Timestamp = DateTime.Now;

                                        functionLevelRight.RightName = Parameter.Surgery_Practice ? "mm.docconect.doc.app.op.practice" : "mm.docconect.doc.app.ac.practice";
                                        functionLevelRight.GlobalPropertyMatchingID = Parameter.Surgery_Practice ? "mm.docconect.doc.app.op.practice" : "mm.docconect.doc.app.ac.practice";

                                        functionLevelRight.Save(Connection, Transaction);

                                        var newPracticeAccountToFunctionLevelRight = new ORM_USR_Account_2_FunctionLevelRight();
                                        newPracticeAccountToFunctionLevelRight.Account_RefID = practiceAccountID;
                                        newPracticeAccountToFunctionLevelRight.FunctionLevelRight_RefID = functionLevelRight.USR_Account_FunctionLevelRightID;
                                        newPracticeAccountToFunctionLevelRight.Tenant_RefID = securityTicket.TenantID;
                                        newPracticeAccountToFunctionLevelRight.IsDeleted = false;
                                        newPracticeAccountToFunctionLevelRight.Creation_Timestamp = DateTime.Now;

                                        newPracticeAccountToFunctionLevelRight.Save(Connection, Transaction);
                                    }

                                    var doctorsInPractice = cls_Get_DoctorIDs_for_PracticeID.Invoke(Connection, Transaction, new P_DO_GDIDsfPID_1635() { PracticeID = Parameter.PracticeID }, securityTicket).Result;

                                    foreach (var doctor in doctorsInPractice)
                                    {
                                        //check if connecting table already exists
                                        var doctorAccountID = cls_Get_Doctor_AccountID_for_DoctorID.Invoke(Connection, Transaction, new P_DO_GDAIDfDID_1549() { DoctorID = doctor.DoctorID }, securityTicket).Result.accountID;

                                        var doctorFunctionLevelRightQ = new ORM_USR_Account_FunctionLevelRight.Query();
                                        doctorFunctionLevelRightQ.Tenant_RefID = securityTicket.TenantID;
                                        doctorFunctionLevelRightQ.IsDeleted = false;
                                        doctorFunctionLevelRightQ.GlobalPropertyMatchingID = Parameter.Surgery_Practice ? "mm.docconect.doc.app.op.doctor" : "mm.docconect.doc.app.ac.doctor";

                                        var doctorFunctionLevelRight = ORM_USR_Account_FunctionLevelRight.Query.Search(Connection, Transaction, doctorFunctionLevelRightQ).SingleOrDefault();
                                        if (doctorFunctionLevelRight != null)
                                        {
                                            var doctorAccountToFunctionLevelRightQ = new ORM_USR_Account_2_FunctionLevelRight.Query();
                                            doctorAccountToFunctionLevelRightQ.Tenant_RefID = securityTicket.TenantID;
                                            doctorAccountToFunctionLevelRightQ.Account_RefID = doctorAccountID;
                                            doctorAccountToFunctionLevelRightQ.FunctionLevelRight_RefID = doctorFunctionLevelRight.USR_Account_FunctionLevelRightID;
                                            doctorAccountToFunctionLevelRightQ.IsDeleted = true;

                                            var doctorAccountToFunctionLevelRight = ORM_USR_Account_2_FunctionLevelRight.Query.Search(Connection, Transaction, doctorAccountToFunctionLevelRightQ).SingleOrDefault();

                                            //delete current connecting table
                                            var currentDoctorAccountToFunctionLevelRightQ = new ORM_USR_Account_2_FunctionLevelRight.Query();
                                            currentDoctorAccountToFunctionLevelRightQ.Account_RefID = doctorAccountID;
                                            currentDoctorAccountToFunctionLevelRightQ.Tenant_RefID = securityTicket.TenantID;
                                            currentDoctorAccountToFunctionLevelRightQ.IsDeleted = false;

                                            var currentDoctorAccountToFunctionLevelRight = ORM_USR_Account_2_FunctionLevelRight.Query.Search(Connection, Transaction, currentDoctorAccountToFunctionLevelRightQ).SingleOrDefault();

                                            if (currentDoctorAccountToFunctionLevelRight != null)
                                            {
                                                currentDoctorAccountToFunctionLevelRight.IsDeleted = true;
                                                currentDoctorAccountToFunctionLevelRight.Save(Connection, Transaction);
                                            }

                                            //if yes, reinstate it
                                            if (doctorAccountToFunctionLevelRight != null)
                                            {
                                                doctorAccountToFunctionLevelRight.IsDeleted = false;
                                                doctorAccountToFunctionLevelRight.Save(Connection, Transaction);
                                            }
                                            //if not, create new connecting table
                                            else
                                            {
                                                var newDoctorAccountToFunctionLevelRight = new ORM_USR_Account_2_FunctionLevelRight();
                                                newDoctorAccountToFunctionLevelRight.Account_RefID = doctorAccountID;
                                                newDoctorAccountToFunctionLevelRight.FunctionLevelRight_RefID = doctorFunctionLevelRight.USR_Account_FunctionLevelRightID;
                                                newDoctorAccountToFunctionLevelRight.Tenant_RefID = securityTicket.TenantID;
                                                newDoctorAccountToFunctionLevelRight.IsDeleted = false;
                                                newDoctorAccountToFunctionLevelRight.Creation_Timestamp = DateTime.Now;

                                                newDoctorAccountToFunctionLevelRight.Save(Connection, Transaction);
                                            }
                                        }
                                        else
                                        {
                                            var currentDoctorFunctionLevelRightQ = new ORM_USR_Account_FunctionLevelRight.Query();
                                            currentDoctorFunctionLevelRightQ.Tenant_RefID = securityTicket.TenantID;
                                            currentDoctorFunctionLevelRightQ.IsDeleted = false;
                                            currentDoctorFunctionLevelRightQ.GlobalPropertyMatchingID = Parameter.Surgery_Practice ? "mm.docconect.doc.app.ac.doctor" : "mm.docconect.doc.app.op.doctor";

                                            var currentDoctorFunctionLevelRight = ORM_USR_Account_FunctionLevelRight.Query.Search(Connection, Transaction, currentDoctorFunctionLevelRightQ).SingleOrDefault();
                                            var doctorAccountToFunctionLevelRightQ = new ORM_USR_Account_2_FunctionLevelRight.Query();
                                            doctorAccountToFunctionLevelRightQ.Tenant_RefID = securityTicket.TenantID;
                                            doctorAccountToFunctionLevelRightQ.Account_RefID = doctorAccountID;
                                            doctorAccountToFunctionLevelRightQ.FunctionLevelRight_RefID = currentDoctorFunctionLevelRight.USR_Account_FunctionLevelRightID;
                                            doctorAccountToFunctionLevelRightQ.IsDeleted = true;

                                            var doctorAccountToFunctionLevelRight = ORM_USR_Account_2_FunctionLevelRight.Query.Search(Connection, Transaction, doctorAccountToFunctionLevelRightQ).SingleOrDefault();

                                            //delete current connecting table
                                            var currentDoctorAccountToFunctionLevelRightQ = new ORM_USR_Account_2_FunctionLevelRight.Query();
                                            currentDoctorAccountToFunctionLevelRightQ.Account_RefID = doctorAccountID;
                                            currentDoctorAccountToFunctionLevelRightQ.Tenant_RefID = securityTicket.TenantID;
                                            currentDoctorAccountToFunctionLevelRightQ.IsDeleted = false;

                                            var currentDoctorAccountToFunctionLevelRight = ORM_USR_Account_2_FunctionLevelRight.Query.Search(Connection, Transaction, currentDoctorAccountToFunctionLevelRightQ).SingleOrDefault();

                                            if (currentDoctorAccountToFunctionLevelRight != null)
                                            {
                                                currentDoctorAccountToFunctionLevelRight.IsDeleted = true;
                                                currentDoctorAccountToFunctionLevelRight.Save(Connection, Transaction);
                                            }

                                            var accountGroupQuery = new ORM_USR_Account_FunctionLevelRights_Group.Query();
                                            accountGroupQuery.Tenant_RefID = securityTicket.TenantID;
                                            accountGroupQuery.IsDeleted = false;
                                            accountGroupQuery.GlobalPropertyMatchingID = "mm.docconect.doc.app.group";

                                            var accountGroup = ORM_USR_Account_FunctionLevelRights_Group.Query.Search(Connection, Transaction, accountGroupQuery).SingleOrDefault();

                                            ORM_USR_Account_FunctionLevelRight functionLevelRight = new ORM_USR_Account_FunctionLevelRight();
                                            functionLevelRight.USR_Account_FunctionLevelRightID = Guid.NewGuid();
                                            functionLevelRight.FunctionLevelRights_Group_RefID = accountGroup.USR_Account_FunctionLevelRights_GroupID;
                                            functionLevelRight.Tenant_RefID = securityTicket.TenantID;
                                            functionLevelRight.Creation_Timestamp = DateTime.Now;

                                            functionLevelRight.RightName = Parameter.Surgery_Practice ? "mm.docconect.doc.app.op.doctor" : "mm.docconect.doc.app.ac.doctor";
                                            functionLevelRight.GlobalPropertyMatchingID = Parameter.Surgery_Practice ? "mm.docconect.doc.app.op.doctor" : "mm.docconect.doc.app.ac.doctor";

                                            functionLevelRight.Save(Connection, Transaction);

                                            var newDoctorAccountToFunctionLevelRight = new ORM_USR_Account_2_FunctionLevelRight();
                                            newDoctorAccountToFunctionLevelRight.Account_RefID = doctorAccountID;
                                            newDoctorAccountToFunctionLevelRight.FunctionLevelRight_RefID = functionLevelRight.USR_Account_FunctionLevelRightID;
                                            newDoctorAccountToFunctionLevelRight.Tenant_RefID = securityTicket.TenantID;
                                            newDoctorAccountToFunctionLevelRight.IsDeleted = false;
                                            newDoctorAccountToFunctionLevelRight.Creation_Timestamp = DateTime.Now;

                                            newDoctorAccountToFunctionLevelRight.Save(Connection, Transaction);
                                        }
                                    }


                                    var doctorsThatWorkInPractice = Get_Doctors_for_PracticeID.Get_Doctors_for_PracticeID_with_Bank_Account_Inheritance(new Practice_Parameter()
                                    {
                                        practice_id = Parameter.PracticeID,
                                        account_status = null
                                    }, securityTicket);

                                    if (doctorsThatWorkInPractice.Any())
                                    {
                                        foreach (var doctor in doctorsThatWorkInPractice)
                                        {
                                            doctor.role = Parameter.Surgery_Practice ? "op" : "ac";
                                        }

                                        Add_New_Practice.Import_Practice_Data_to_ElasticDB(doctorsThatWorkInPractice, securityTicket.TenantID.ToString());
                                    }
                                }
                            }

                            if (practiceUniversal.PropertyName.Equals("Order Drugs"))
                            {
                                medicalPractice2Universal.Value_Boolean = Parameter.Orders_Drugs;
                            }
                        }

                        medicalPractice2Universal.Save(Connection, Transaction);
                    }

                    var medicalPRactice2Universal4 = new ORM_HEC_MedicalPractice_2_UniversalProperty();
                    medicalPRactice2Universal4.Tenant_RefID = securityTicket.TenantID;
                    medicalPRactice2Universal4.HEC_MedicalPractice_RefID = medicalPractice.HEC_MedicalPractiseID;
                    medicalPRactice2Universal4.HEC_MedicalPractice_UniversalProperty_RefID = Guid.NewGuid();
                    medicalPRactice2Universal4.Value_Boolean = Parameter.Only_Label_Required;
                    medicalPRactice2Universal4.Creation_Timestamp = DateTime.Now;
                    medicalPRactice2Universal4.Modification_Timestamp = DateTime.Now;
                    medicalPRactice2Universal4.Save(Connection, Transaction);

                    var practiceUniversal4 = new ORM_HEC_MedicalPractice_UniversalProperty();
                    practiceUniversal4.IsDeleted = false;
                    practiceUniversal4.Tenant_RefID = securityTicket.TenantID;
                    practiceUniversal4.HEC_MedicalPractice_UniversalPropertyID = medicalPRactice2Universal4.HEC_MedicalPractice_UniversalProperty_RefID;
                    practiceUniversal4.PropertyName = "Only Label Required";
                    practiceUniversal4.IsValue_Boolean = true;
                    practiceUniversal4.Creation_Timestamp = DateTime.Now;
                    practiceUniversal4.Modification_Timestamp = DateTime.Now;
                    practiceUniversal4.Save(Connection, Transaction);
                }
            }



            #region Should download report upon submission property
            var shouldDownloadSubmissionReportProperty = ORM_HEC_MedicalPractice_UniversalProperty.Query.Search(Connection, Transaction, new ORM_HEC_MedicalPractice_UniversalProperty.Query()
            {
                PropertyName = "Download Report Upon Submission",
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            }).SingleOrDefault();

            if (shouldDownloadSubmissionReportProperty == null)
            {
                shouldDownloadSubmissionReportProperty = new ORM_HEC_MedicalPractice_UniversalProperty();
                shouldDownloadSubmissionReportProperty.Tenant_RefID = securityTicket.TenantID;
                shouldDownloadSubmissionReportProperty.PropertyName = "Download Report Upon Submission";
                shouldDownloadSubmissionReportProperty.IsValue_Boolean = true;
                shouldDownloadSubmissionReportProperty.Modification_Timestamp = DateTime.Now;

                shouldDownloadSubmissionReportProperty.Save(Connection, Transaction);
            }
            var shouldDownloadSubmissionReportProperty2Practice = ORM_HEC_MedicalPractice_2_UniversalProperty.Query.Search(Connection, Transaction, new ORM_HEC_MedicalPractice_2_UniversalProperty.Query()
            {
                HEC_MedicalPractice_RefID = practice_id,
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                HEC_MedicalPractice_UniversalProperty_RefID = shouldDownloadSubmissionReportProperty.HEC_MedicalPractice_UniversalPropertyID
            }).SingleOrDefault();

            if (shouldDownloadSubmissionReportProperty2Practice == null)
            {
                shouldDownloadSubmissionReportProperty2Practice = new ORM_HEC_MedicalPractice_2_UniversalProperty();
                shouldDownloadSubmissionReportProperty2Practice.Tenant_RefID = securityTicket.TenantID;
                shouldDownloadSubmissionReportProperty2Practice.HEC_MedicalPractice_RefID = practice_id;
                shouldDownloadSubmissionReportProperty2Practice.HEC_MedicalPractice_UniversalProperty_RefID = shouldDownloadSubmissionReportProperty.HEC_MedicalPractice_UniversalPropertyID;
            }
            shouldDownloadSubmissionReportProperty2Practice.Value_Boolean = Parameter.ShouldDownloadReportUponSubmission;
            shouldDownloadSubmissionReportProperty2Practice.Modification_Timestamp = DateTime.Now;

            shouldDownloadSubmissionReportProperty2Practice.Save(Connection, Transaction);
            #endregion

            #region Press enter to search property
            var pressEnterToSearchProperty = ORM_HEC_MedicalPractice_UniversalProperty.Query.Search(Connection, Transaction, new ORM_HEC_MedicalPractice_UniversalProperty.Query()
            {
                PropertyName = "Press enter to search",
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            }).SingleOrDefault();

            if (pressEnterToSearchProperty == null)
            {
                pressEnterToSearchProperty = new ORM_HEC_MedicalPractice_UniversalProperty();
                pressEnterToSearchProperty.Tenant_RefID = securityTicket.TenantID;
                pressEnterToSearchProperty.PropertyName = "Press enter to search";
                pressEnterToSearchProperty.IsValue_Boolean = true;
                pressEnterToSearchProperty.Modification_Timestamp = DateTime.Now;

                pressEnterToSearchProperty.Save(Connection, Transaction);
            }
            var pressEnterToSearchProperty2Practice = ORM_HEC_MedicalPractice_2_UniversalProperty.Query.Search(Connection, Transaction, new ORM_HEC_MedicalPractice_2_UniversalProperty.Query()
            {
                HEC_MedicalPractice_RefID = practice_id,
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                HEC_MedicalPractice_UniversalProperty_RefID = pressEnterToSearchProperty.HEC_MedicalPractice_UniversalPropertyID
            }).SingleOrDefault();

            if (pressEnterToSearchProperty2Practice == null)
            {
                pressEnterToSearchProperty2Practice = new ORM_HEC_MedicalPractice_2_UniversalProperty();
                pressEnterToSearchProperty2Practice.Tenant_RefID = securityTicket.TenantID;
                pressEnterToSearchProperty2Practice.HEC_MedicalPractice_RefID = practice_id;
                pressEnterToSearchProperty2Practice.HEC_MedicalPractice_UniversalProperty_RefID = pressEnterToSearchProperty.HEC_MedicalPractice_UniversalPropertyID;
            }

            pressEnterToSearchProperty2Practice.Value_Boolean = Parameter.PressEnterToSearch;
            pressEnterToSearchProperty2Practice.Modification_Timestamp = DateTime.Now;

            pressEnterToSearchProperty2Practice.Save(Connection, Transaction);
            #endregion

            #region Practice has OCT device property
            if (Parameter.PracticeHasOctDevice.HasValue)
            {
                var practiceHasOctDevicePropertyName = "Practice has OCT device";

                var practiceHasOctDeviceProperty = ORM_HEC_MedicalPractice_UniversalProperty.Query.Search(Connection, Transaction, new ORM_HEC_MedicalPractice_UniversalProperty.Query()
                {
                    PropertyName = practiceHasOctDevicePropertyName,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).SingleOrDefault();

                if (practiceHasOctDeviceProperty == null)
                {
                    practiceHasOctDeviceProperty = new ORM_HEC_MedicalPractice_UniversalProperty();
                    practiceHasOctDeviceProperty.Tenant_RefID = securityTicket.TenantID;
                    practiceHasOctDeviceProperty.PropertyName = practiceHasOctDevicePropertyName;
                    practiceHasOctDeviceProperty.IsValue_Boolean = true;
                    practiceHasOctDeviceProperty.Modification_Timestamp = DateTime.Now;

                    practiceHasOctDeviceProperty.Save(Connection, Transaction);
                }

                var practiceHasOctDeviceProperty2Practice = ORM_HEC_MedicalPractice_2_UniversalProperty.Query.Search(Connection, Transaction, new ORM_HEC_MedicalPractice_2_UniversalProperty.Query()
                {
                    HEC_MedicalPractice_RefID = practice_id,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false,
                    HEC_MedicalPractice_UniversalProperty_RefID = practiceHasOctDeviceProperty.HEC_MedicalPractice_UniversalPropertyID
                }).SingleOrDefault();

                if (practiceHasOctDeviceProperty2Practice == null)
                {
                    practiceHasOctDeviceProperty2Practice = new ORM_HEC_MedicalPractice_2_UniversalProperty();
                    practiceHasOctDeviceProperty2Practice.Tenant_RefID = securityTicket.TenantID;
                    practiceHasOctDeviceProperty2Practice.HEC_MedicalPractice_RefID = practice_id;
                    practiceHasOctDeviceProperty2Practice.HEC_MedicalPractice_UniversalProperty_RefID = practiceHasOctDeviceProperty.HEC_MedicalPractice_UniversalPropertyID;
                }

                practiceHasOctDeviceProperty2Practice.Value_Boolean = Parameter.PracticeHasOctDevice.Value;
                practiceHasOctDeviceProperty2Practice.Modification_Timestamp = DateTime.Now;

                practiceHasOctDeviceProperty2Practice.Save(Connection, Transaction);
            }
            #endregion


            #region  Default pharmacy
            if (Parameter.DefaultPharmacy != null)
            {
                var defaultPharmacyProperty = ORM_HEC_MedicalPractice_UniversalProperty.Query.Search(Connection, Transaction, new ORM_HEC_MedicalPractice_UniversalProperty.Query()
                {
                    PropertyName = "Default pharmacy",
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).SingleOrDefault();
                if (defaultPharmacyProperty == null)
                {
                    defaultPharmacyProperty = new ORM_HEC_MedicalPractice_UniversalProperty();
                    defaultPharmacyProperty.Tenant_RefID = securityTicket.TenantID;
                    defaultPharmacyProperty.PropertyName = "Default pharmacy";
                    defaultPharmacyProperty.IsValue_String = true;
                    defaultPharmacyProperty.Modification_Timestamp = DateTime.Now;

                    defaultPharmacyProperty.Save(Connection, Transaction);
                }

                var defaultPharmacyProperty2Practice = ORM_HEC_MedicalPractice_2_UniversalProperty.Query.Search(Connection, Transaction, new ORM_HEC_MedicalPractice_2_UniversalProperty.Query()
                {
                    HEC_MedicalPractice_RefID = practice_id,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false,
                    HEC_MedicalPractice_UniversalProperty_RefID = defaultPharmacyProperty.HEC_MedicalPractice_UniversalPropertyID
                }).SingleOrDefault();
                if (defaultPharmacyProperty2Practice == null)
                {
                    defaultPharmacyProperty2Practice = new ORM_HEC_MedicalPractice_2_UniversalProperty();
                    defaultPharmacyProperty2Practice.Tenant_RefID = securityTicket.TenantID;
                    defaultPharmacyProperty2Practice.HEC_MedicalPractice_RefID = practice_id;
                    defaultPharmacyProperty2Practice.HEC_MedicalPractice_UniversalProperty_RefID = defaultPharmacyProperty.HEC_MedicalPractice_UniversalPropertyID;
                }

                defaultPharmacyProperty2Practice.Value_String = Parameter.DefaultPharmacy;
                defaultPharmacyProperty2Practice.Modification_Timestamp = DateTime.Now;
                defaultPharmacyProperty2Practice.Save(Connection, Transaction);
            }
            #endregion

            #region  Quick order
            var quickOrderProperty = ORM_HEC_MedicalPractice_UniversalProperty.Query.Search(Connection, Transaction, new ORM_HEC_MedicalPractice_UniversalProperty.Query()
            {
                PropertyName = "Quick order",
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            }).SingleOrDefault();
            if (quickOrderProperty == null)
            {
                quickOrderProperty = new ORM_HEC_MedicalPractice_UniversalProperty();
                quickOrderProperty.Tenant_RefID = securityTicket.TenantID;
                quickOrderProperty.PropertyName = "Quick order";
                quickOrderProperty.IsValue_Boolean = true;
                quickOrderProperty.Modification_Timestamp = DateTime.Now;

                quickOrderProperty.Save(Connection, Transaction);
            }

            var quickOrderProperty2Practice = ORM_HEC_MedicalPractice_2_UniversalProperty.Query.Search(Connection, Transaction, new ORM_HEC_MedicalPractice_2_UniversalProperty.Query()
            {
                HEC_MedicalPractice_RefID = practice_id,
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                HEC_MedicalPractice_UniversalProperty_RefID = quickOrderProperty.HEC_MedicalPractice_UniversalPropertyID
            }).SingleOrDefault();
            if (quickOrderProperty2Practice == null)
            {
                quickOrderProperty2Practice = new ORM_HEC_MedicalPractice_2_UniversalProperty();
                quickOrderProperty2Practice.Tenant_RefID = securityTicket.TenantID;
                quickOrderProperty2Practice.HEC_MedicalPractice_RefID = practice_id;
                quickOrderProperty2Practice.HEC_MedicalPractice_UniversalProperty_RefID = quickOrderProperty.HEC_MedicalPractice_UniversalPropertyID;
            }

            quickOrderProperty2Practice.Value_Boolean = Parameter.IsQuickOrderActive;
            quickOrderProperty2Practice.Modification_Timestamp = DateTime.Now;
            quickOrderProperty2Practice.Save(Connection, Transaction);
            #endregion

            #region  Delivery date from
            var deliveryDateFromProperty = ORM_HEC_MedicalPractice_UniversalProperty.Query.Search(Connection, Transaction, new ORM_HEC_MedicalPractice_UniversalProperty.Query()
            {
                PropertyName = "Delivery date from",
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            }).SingleOrDefault();
            if (deliveryDateFromProperty == null)
            {
                deliveryDateFromProperty = new ORM_HEC_MedicalPractice_UniversalProperty();
                deliveryDateFromProperty.Tenant_RefID = securityTicket.TenantID;
                deliveryDateFromProperty.PropertyName = "Delivery date from";
                deliveryDateFromProperty.IsValue_String = true;
                deliveryDateFromProperty.Modification_Timestamp = DateTime.Now;

                deliveryDateFromProperty.Save(Connection, Transaction);
            }

            var deliveryDateFromProperty2Practice = ORM_HEC_MedicalPractice_2_UniversalProperty.Query.Search(Connection, Transaction, new ORM_HEC_MedicalPractice_2_UniversalProperty.Query()
            {
                HEC_MedicalPractice_RefID = practice_id,
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                HEC_MedicalPractice_UniversalProperty_RefID = deliveryDateFromProperty.HEC_MedicalPractice_UniversalPropertyID
            }).SingleOrDefault();
            if (deliveryDateFromProperty2Practice == null)
            {
                deliveryDateFromProperty2Practice = new ORM_HEC_MedicalPractice_2_UniversalProperty();
                deliveryDateFromProperty2Practice.Tenant_RefID = securityTicket.TenantID;
                deliveryDateFromProperty2Practice.HEC_MedicalPractice_RefID = practice_id;
                deliveryDateFromProperty2Practice.HEC_MedicalPractice_UniversalProperty_RefID = deliveryDateFromProperty.HEC_MedicalPractice_UniversalPropertyID;
            }

            deliveryDateFromProperty2Practice.Value_String = Parameter.DeliveryDateFrom;
            deliveryDateFromProperty2Practice.Modification_Timestamp = DateTime.Now;
            deliveryDateFromProperty2Practice.Save(Connection, Transaction);
            #endregion

            #region  Delivery date to
            var deliveryDateToProperty = ORM_HEC_MedicalPractice_UniversalProperty.Query.Search(Connection, Transaction, new ORM_HEC_MedicalPractice_UniversalProperty.Query()
            {
                PropertyName = "Delivery date to",
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            }).SingleOrDefault();
            if (deliveryDateToProperty == null)
            {
                deliveryDateToProperty = new ORM_HEC_MedicalPractice_UniversalProperty();
                deliveryDateToProperty.Tenant_RefID = securityTicket.TenantID;
                deliveryDateToProperty.PropertyName = "Delivery date to";
                deliveryDateToProperty.IsValue_String = true;
                deliveryDateToProperty.Modification_Timestamp = DateTime.Now;

                deliveryDateToProperty.Save(Connection, Transaction);
            }

            var deliveryDateToProperty2Practice = ORM_HEC_MedicalPractice_2_UniversalProperty.Query.Search(Connection, Transaction, new ORM_HEC_MedicalPractice_2_UniversalProperty.Query()
            {
                HEC_MedicalPractice_RefID = practice_id,
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                HEC_MedicalPractice_UniversalProperty_RefID = deliveryDateToProperty.HEC_MedicalPractice_UniversalPropertyID
            }).SingleOrDefault();
            if (deliveryDateToProperty2Practice == null)
            {
                deliveryDateToProperty2Practice = new ORM_HEC_MedicalPractice_2_UniversalProperty();
                deliveryDateToProperty2Practice.Tenant_RefID = securityTicket.TenantID;
                deliveryDateToProperty2Practice.HEC_MedicalPractice_RefID = practice_id;
                deliveryDateToProperty2Practice.HEC_MedicalPractice_UniversalProperty_RefID = deliveryDateToProperty.HEC_MedicalPractice_UniversalPropertyID;
            }

            deliveryDateToProperty2Practice.Value_String = Parameter.DeliveryDateTo;
            deliveryDateToProperty2Practice.Modification_Timestamp = DateTime.Now;
            deliveryDateToProperty2Practice.Save(Connection, Transaction);
            #endregion

            #region  Use grace period
            var gracePeriodProperty = ORM_HEC_MedicalPractice_UniversalProperty.Query.Search(Connection, Transaction, new ORM_HEC_MedicalPractice_UniversalProperty.Query()
            {
                PropertyName = "Grace period",
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            }).SingleOrDefault();
            if (gracePeriodProperty == null)
            {
                gracePeriodProperty = new ORM_HEC_MedicalPractice_UniversalProperty();
                gracePeriodProperty.Tenant_RefID = securityTicket.TenantID;
                gracePeriodProperty.PropertyName = "Grace period";
                gracePeriodProperty.IsValue_Boolean = true;
                gracePeriodProperty.Modification_Timestamp = DateTime.Now;

                gracePeriodProperty.Save(Connection, Transaction);
            }

            var gracePeriodProperty2Practice = ORM_HEC_MedicalPractice_2_UniversalProperty.Query.Search(Connection, Transaction, new ORM_HEC_MedicalPractice_2_UniversalProperty.Query()
            {
                HEC_MedicalPractice_RefID = practice_id,
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                HEC_MedicalPractice_UniversalProperty_RefID = gracePeriodProperty.HEC_MedicalPractice_UniversalPropertyID
            }).SingleOrDefault();
            if (gracePeriodProperty2Practice == null)
            {
                gracePeriodProperty2Practice = new ORM_HEC_MedicalPractice_2_UniversalProperty();
                gracePeriodProperty2Practice.Tenant_RefID = securityTicket.TenantID;
                gracePeriodProperty2Practice.HEC_MedicalPractice_RefID = practice_id;
                gracePeriodProperty2Practice.HEC_MedicalPractice_UniversalProperty_RefID = gracePeriodProperty.HEC_MedicalPractice_UniversalPropertyID;
            }
            var oldGracePeriodData = gracePeriodProperty2Practice.Value_Boolean;
            gracePeriodProperty2Practice.Value_Boolean = Parameter.UseGracePeriod;
            gracePeriodProperty2Practice.Modification_Timestamp = DateTime.Now;
            gracePeriodProperty2Practice.Save(Connection, Transaction);

            if (oldGracePeriodData && !Parameter.UseGracePeriod)
            {
                cls_Reset_Grace_Period_for_Practice.Invoke(Connection, Transaction, new P_DO_RGPfP_1544 { PracticeID = practice_id }, securityTicket);
            }
            #endregion

            Practice_Doctors_Model DPModel = new Practice_Doctors_Model();
            DPModel.account_status = Parameter.Account_Deactivated ? "inaktiv" : "aktiv";
            DPModel.id = practice_id.ToString();
            DPModel.name = Parameter.Practice_Name;
            DPModel.name_untouched = Parameter.Practice_Name;
            DPModel.salutation = "";
            DPModel.type = "Practice";
            DPModel.autocomplete_name = Parameter.Practice_Name;

            DPModel.address = Parameter.Street + " " + Parameter.No;
            DPModel.zip = Parameter.Zip;
            DPModel.city = Parameter.City;


            DPModel.bank_untouched = Parameter.Bank != null ? Parameter.Bank : "";
            DPModel.bank = Parameter.Bank != null ? Parameter.Bank : "";

            if (Parameter.Email != null)
            {
                DPModel.email = Parameter.Main_Email;
            }

            DPModel.phone = Parameter.Main_Phone;
            if (Parameter.IBAN != null)
            {
                DPModel.iban = Parameter.IBAN;
            }
            if (Parameter.BIC != null)
            {
                DPModel.bic = Parameter.BIC;
            }

            DPModel.bsnr_lanr = Parameter.BSNR;
            DPModel.aditional_info = "";
            DPModel.contract = 0;
            DPModel.tenantid = securityTicket.TenantID.ToString();
            DPModel.role = Parameter.Surgery_Practice ? "op" : "ac";
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
		public static FR_Guid Invoke(string ConnectionString,P_DO_SP_1547 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_DO_SP_1547 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_DO_SP_1547 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_DO_SP_1547 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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
		#region SClass P_DO_SP_1547 for attribute P_DO_SP_1547
		[DataContract]
		public class P_DO_SP_1547 
		{
			//Standard type parameters
			[DataMember]
			public Guid PracticeID { get; set; } 
			[DataMember]
			public String Practice_Name { get; set; } 
			[DataMember]
			public String Street { get; set; } 
			[DataMember]
			public String No { get; set; } 
			[DataMember]
			public String Zip { get; set; } 
			[DataMember]
			public String City { get; set; } 
			[DataMember]
			public String BSNR { get; set; } 
			[DataMember]
			public String Main_Email { get; set; } 
			[DataMember]
			public String Main_Phone { get; set; } 
			[DataMember]
			public String Fax { get; set; } 
			[DataMember]
			public String Contact_PersonFirstName { get; set; } 
			[DataMember]
			public String Contact_PersonLastName { get; set; } 
			[DataMember]
			public String Email { get; set; } 
			[DataMember]
			public String Phone { get; set; } 
			[DataMember]
			public bool Surgery_Practice { get; set; } 
			[DataMember]
			public bool Orders_Drugs { get; set; } 
			[DataMember]
			public bool Only_Label_Required { get; set; } 
			[DataMember]
			public String Default_Shipping_Date_Offset { get; set; } 
			[DataMember]
			public bool Waive_Service_Fee { get; set; } 
			[DataMember]
			public String Account_Holder { get; set; } 
			[DataMember]
			public String Practice_NameAccount { get; set; } 
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
			public bool Account_Deactivated { get; set; } 
			[DataMember]
			public bool Change_Doctor_Account_Statuses { get; set; } 
			[DataMember]
			public bool ShouldDownloadReportUponSubmission { get; set; } 
			[DataMember]
			public bool PressEnterToSearch { get; set; } 
			[DataMember]
			public bool? PracticeHasOctDevice { get; set; } 
			[DataMember]
			public String DefaultPharmacy { get; set; } 
			[DataMember]
			public bool IsQuickOrderActive { get; set; } 
			[DataMember]
			public String DeliveryDateFrom { get; set; } 
			[DataMember]
			public String DeliveryDateTo { get; set; } 
			[DataMember]
			public bool UseGracePeriod { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Practice(,P_DO_SP_1547 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Practice.Invoke(connectionString,P_DO_SP_1547 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Doctor.Atomic.Manipulation.P_DO_SP_1547();
parameter.PracticeID = ...;
parameter.Practice_Name = ...;
parameter.Street = ...;
parameter.No = ...;
parameter.Zip = ...;
parameter.City = ...;
parameter.BSNR = ...;
parameter.Main_Email = ...;
parameter.Main_Phone = ...;
parameter.Fax = ...;
parameter.Contact_PersonFirstName = ...;
parameter.Contact_PersonLastName = ...;
parameter.Email = ...;
parameter.Phone = ...;
parameter.Surgery_Practice = ...;
parameter.Orders_Drugs = ...;
parameter.Only_Label_Required = ...;
parameter.Default_Shipping_Date_Offset = ...;
parameter.Waive_Service_Fee = ...;
parameter.Account_Holder = ...;
parameter.Practice_NameAccount = ...;
parameter.IBAN = ...;
parameter.BIC = ...;
parameter.Bank = ...;
parameter.Login_Email = ...;
parameter.Account_Password = ...;
parameter.Account_PasswordForEmail = ...;
parameter.Account_Deactivated = ...;
parameter.Change_Doctor_Account_Statuses = ...;
parameter.ShouldDownloadReportUponSubmission = ...;
parameter.PressEnterToSearch = ...;
parameter.PracticeHasOctDevice = ...;
parameter.DefaultPharmacy = ...;
parameter.IsQuickOrderActive = ...;
parameter.DeliveryDateFrom = ...;
parameter.DeliveryDateTo = ...;
parameter.UseGracePeriod = ...;

*/
