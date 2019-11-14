/* 
 * Generated on 15.9.2015 9:50:31
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
using System.Threading;
using BOp.Providers;
using System.Globalization;
using BOp.Providers.TMS;
using BOp.Providers.TMS.Requests;
using CL1_USR;
using CL1_CMN_BPT;
using CL1_CMN_PER;
using MMDocConnectDBMethods.MainData.Atomic.Manipulation;
using System.Text;
using System.Web.Configuration;
using MMDocConnectUtils;
using MMDocConnectDBMethods.MainData.Atomic.Retrieval;
using System.Web;
using System.IO;

namespace MMDocConnectDBMethods.MainData.Complex.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Add_New_User.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Add_New_User
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Guid Execute(DbConnection Connection, DbTransaction Transaction, P_MD_SAU_1236 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_Guid();
            //Put your code here
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("de-DE");
            IAccountServiceProvider accountService;
            var _providerFactory = ProviderFactory.Instance;
            accountService = _providerFactory.CreateAccountServiceProvider();

            var accId = Guid.NewGuid();
            if (Parameter.UserID == Guid.Empty)
            {
                if (!String.IsNullOrEmpty(Parameter.LoginEmail))
                {
                    string[] stringUser = Parameter.LoginEmail.Split('@');
                    string usernameStr = stringUser[0];

                    Person UserAccount = new Person();
                    UserAccount.FirstName = Parameter.FirstName;
                    UserAccount.LastName = Parameter.LastName;
                    UserAccount.Title = string.IsNullOrEmpty(Parameter.Title) ? "" : Parameter.Title;
                    Account account = new Account();
                    account.Person = UserAccount;
                    account.ID = accId;
                    account.TenantID = securityTicket.TenantID;
                    account.Email = Parameter.LoginEmail;
                    account.PasswordHash = Parameter.inPassword;
                    account.Username = usernameStr;
                    account.AccountType = EAccountType.Standard;
                    account.Verified = true;
                    accountService.CreateAccount(account, securityTicket.SessionTicket);
                    accountService.VerifyAccount(account.ID);
                    
                    try
                    {
                        string emailTo = Parameter.LoginEmail;
                        string appName = WebConfigurationManager.AppSettings["mmAppUrl"];
                        var prefix = HttpContext.Current.Request.Url.AbsoluteUri.Contains("https") ? "https://" : "http://";
                        var imageUrl = HttpContext.Current.Request.Url.AbsoluteUri.Substring(0, HttpContext.Current.Request.Url.AbsoluteUri.IndexOf("api")) + "Content/images/logo.png";

                        var email_template = File.ReadAllText(HttpContext.Current.Server.MapPath("~/EmailTemplates/NewUserTemplate.html"));
                        var subjectsJson = File.ReadAllText(HttpContext.Current.Server.MapPath("~/EmailTemplates/EmailSubjects.json"));
                        dynamic subjects = Newtonsoft.Json.JsonConvert.DeserializeObject(subjectsJson);
                        var subjectMail = subjects["NewUserSubject"].ToString();
                        
                        email_template = EmailTemplater.SetTemplateData(email_template, new
                        {
                            first_name = Parameter.FirstName,
                            salutation = Parameter.Salutation,
                            last_name = Parameter.LastName,
                            title = Parameter.Title,
                            password = Parameter.inPasswordMail,
                            mm_app_url = prefix + HttpContext.Current.Request.Url.Authority + "/" + appName,
                            medios_connect_logo_url = imageUrl
                        }, "{{", "}}");

                        //string mailFrom = cls_Get_Company_Settings.Invoke(Connection, Transaction, securityTicket).Result.Email;
                        string mailFrom = WebConfigurationManager.AppSettings["mailFrom"];
                        EmailNotificationSenderUtil.SendEmail(mailFrom, emailTo, subjectMail, email_template);
                    }
                    catch (Exception ex)
                    {
                        LogUtils.Logger.LogDocAppInfo(new LogUtils.LogEntry(System.Reflection.MethodInfo.GetCurrentMethod(), ex, null, "Add new user: Email sending failed."), "EmailExceptions");
                    }
                    var userAccountInfo = ORM_USR_Account.Query.Search(Connection, Transaction, new ORM_USR_Account.Query()
                    {
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID,
                        USR_AccountID = accId
                    }).Single();


                    var businesParticipant = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, new ORM_CMN_BPT_BusinessParticipant.Query()
                    {
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID,
                        CMN_BPT_BusinessParticipantID = userAccountInfo.BusinessParticipant_RefID

                    }).SingleOrDefault();
                    if (businesParticipant != null)
                    {
                        businesParticipant.DisplayName = Parameter.FirstName + " " + Parameter.LastName;
                        businesParticipant.IfNaturalPerson_CMN_PER_PersonInfo_RefID = Guid.NewGuid();
                        businesParticipant.IsNaturalPerson = true;
                        businesParticipant.Modification_Timestamp = DateTime.Now;
                        businesParticipant.Save(Connection, Transaction);

                        var companyInfoUser = new ORM_CMN_PER_PersonInfo();
                        companyInfoUser.IsDeleted = false;
                        companyInfoUser.Tenant_RefID = securityTicket.TenantID;
                        companyInfoUser.CMN_PER_PersonInfoID = businesParticipant.IfNaturalPerson_CMN_PER_PersonInfo_RefID;
                        companyInfoUser.FirstName = Parameter.FirstName;
                        companyInfoUser.LastName = Parameter.LastName;
                        companyInfoUser.Salutation_General = Parameter.Salutation;
                        companyInfoUser.Title = Parameter.Title;
                        companyInfoUser.Save(Connection, Transaction);

                        var communicationContact = new ORM_CMN_PER_CommunicationContact();
                        communicationContact.IsDeleted = false;
                        communicationContact.Contact_Type = Guid.NewGuid();
                        communicationContact.Tenant_RefID = securityTicket.TenantID;
                        communicationContact.Modification_Timestamp = DateTime.Now;
                        communicationContact.PersonInfo_RefID = businesParticipant.IfNaturalPerson_CMN_PER_PersonInfo_RefID;
                        communicationContact.Content = Parameter.Email;
                        communicationContact.Save(Connection, Transaction);

                        var communicationContactType = new ORM_CMN_PER_CommunicationContact_Type();
                        communicationContactType.IsDeleted = false;
                        communicationContactType.Tenant_RefID = securityTicket.TenantID;
                        communicationContactType.CMN_PER_CommunicationContact_TypeID = communicationContact.Contact_Type;
                        communicationContactType.Type = "Email";
                        communicationContactType.Save(Connection, Transaction);

                        var communicationContactPhone = new ORM_CMN_PER_CommunicationContact();
                        communicationContactPhone.IsDeleted = false;
                        communicationContactPhone.Contact_Type = Guid.NewGuid();
                        communicationContactPhone.Tenant_RefID = securityTicket.TenantID;
                        communicationContactPhone.Modification_Timestamp = DateTime.Now;
                        communicationContactPhone.PersonInfo_RefID = businesParticipant.IfNaturalPerson_CMN_PER_PersonInfo_RefID;
                        communicationContactPhone.Content = Parameter.Phone;
                        communicationContactPhone.Save(Connection, Transaction);

                        var communicationContactTypePhone = new ORM_CMN_PER_CommunicationContact_Type();
                        communicationContactTypePhone.IsDeleted = false;
                        communicationContactTypePhone.Tenant_RefID = securityTicket.TenantID;
                        communicationContactTypePhone.CMN_PER_CommunicationContact_TypeID = communicationContactPhone.Contact_Type;
                        communicationContactTypePhone.Type = "Phone";
                        communicationContactTypePhone.Save(Connection, Transaction);

                        var accountAppSettings = new ORM_USR_Account_ApplicationSetting();
                        accountAppSettings.IsDeleted = false;
                        accountAppSettings.Account_RefID = accId;
                        accountAppSettings.Creation_Timestamp = DateTime.Now;
                        accountAppSettings.Tenant_RefID = securityTicket.TenantID;
                        accountAppSettings.ItemValue = Parameter.ReceiveNotification.ToString();
                        accountAppSettings.ApplicationSetting_Definition_RefID = Guid.NewGuid();
                        accountAppSettings.Save(Connection, Transaction);

                        var accountAppSettingsDefinitions = new ORM_USR_Account_ApplicationSetting_Definition();
                        accountAppSettingsDefinitions.IsDeleted = false;
                        accountAppSettingsDefinitions.Tenant_RefID = securityTicket.TenantID;
                        accountAppSettingsDefinitions.Creation_Timestamp = DateTime.Now;
                        accountAppSettingsDefinitions.USR_Account_ApplicationSetting_DefinitionID = accountAppSettings.ApplicationSetting_Definition_RefID;
                        accountAppSettingsDefinitions.ItemKey = "ReceiveNotification";
                        accountAppSettingsDefinitions.Save(Connection, Transaction);

                    }
                }
            }
            else
            { //Edit existing user
                accId = Parameter.UserID;
                var userAccountInfo = ORM_USR_Account.Query.Search(Connection, Transaction, new ORM_USR_Account.Query()
                 {
                     IsDeleted = false,
                     Tenant_RefID = securityTicket.TenantID,
                     USR_AccountID = Parameter.UserID
                 }).Single();

                var businesParticipant = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, new ORM_CMN_BPT_BusinessParticipant.Query()
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID,
                    CMN_BPT_BusinessParticipantID = userAccountInfo.BusinessParticipant_RefID

                }).SingleOrDefault();
                if (businesParticipant != null)
                {
                    businesParticipant.DisplayName = Parameter.FirstName + " " + Parameter.LastName;
                    businesParticipant.Modification_Timestamp = DateTime.Now;
                    businesParticipant.Save(Connection, Transaction);

                    var personInfo = ORM_CMN_PER_PersonInfo.Query.Search(Connection, Transaction, new ORM_CMN_PER_PersonInfo.Query()
                    {
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID,
                        CMN_PER_PersonInfoID = businesParticipant.IfNaturalPerson_CMN_PER_PersonInfo_RefID

                    }).SingleOrDefault();
                    if (personInfo != null)
                    {

                        personInfo.FirstName = Parameter.FirstName;
                        personInfo.LastName = Parameter.LastName;
                        personInfo.Salutation_General = Parameter.Salutation;
                        personInfo.Title = Parameter.Title;
                        personInfo.Save(Connection, Transaction);


                        var phone = cls_Get_Communication_Contact_Info_for_User_Person_Info.Invoke(Connection, Transaction, new P_MD_GCCIFUPID_1716() { CommunicationType = "Phone", PersonRefID = personInfo.CMN_PER_PersonInfoID }, securityTicket).Result;
                        if (phone != null)
                        {

                            var communicationContact = ORM_CMN_PER_CommunicationContact.Query.Search(Connection, Transaction, new ORM_CMN_PER_CommunicationContact.Query()
                            {
                                IsDeleted = false,
                                Tenant_RefID = securityTicket.TenantID,
                                PersonInfo_RefID = businesParticipant.IfNaturalPerson_CMN_PER_PersonInfo_RefID,
                                CMN_PER_CommunicationContactID = phone.CMN_PER_CommunicationContactID
                            }).SingleOrDefault();
                            communicationContact.Content = Parameter.Phone;
                            communicationContact.Save(Connection, Transaction);
                        }
                        else
                        {
                            var communicationContactPhone = new ORM_CMN_PER_CommunicationContact();
                            communicationContactPhone.IsDeleted = false;
                            communicationContactPhone.Contact_Type = Guid.NewGuid();
                            communicationContactPhone.Tenant_RefID = securityTicket.TenantID;
                            communicationContactPhone.Modification_Timestamp = DateTime.Now;
                            communicationContactPhone.PersonInfo_RefID = businesParticipant.IfNaturalPerson_CMN_PER_PersonInfo_RefID;
                            communicationContactPhone.Content = Parameter.Phone;
                            communicationContactPhone.Save(Connection, Transaction);

                            var communicationContactTypePhone = new ORM_CMN_PER_CommunicationContact_Type();
                            communicationContactTypePhone.IsDeleted = false;
                            communicationContactTypePhone.Tenant_RefID = securityTicket.TenantID;
                            communicationContactTypePhone.CMN_PER_CommunicationContact_TypeID = communicationContactPhone.Contact_Type;
                            communicationContactTypePhone.Type = "Phone";
                            communicationContactTypePhone.Save(Connection, Transaction);

                        }


                        var email = cls_Get_Communication_Contact_Info_for_User_Person_Info.Invoke(Connection, Transaction, new P_MD_GCCIFUPID_1716() { CommunicationType = "Email", PersonRefID = personInfo.CMN_PER_PersonInfoID }, securityTicket).Result;
                        if (email != null)
                        {

                            var communicationContact = ORM_CMN_PER_CommunicationContact.Query.Search(Connection, Transaction, new ORM_CMN_PER_CommunicationContact.Query()
                            {
                                IsDeleted = false,
                                Tenant_RefID = securityTicket.TenantID,
                                PersonInfo_RefID = businesParticipant.IfNaturalPerson_CMN_PER_PersonInfo_RefID,
                                CMN_PER_CommunicationContactID = email.CMN_PER_CommunicationContactID
                            }).SingleOrDefault();
                            communicationContact.Content = Parameter.Email;
                            communicationContact.Save(Connection, Transaction);
                        }
                        else
                        {
                            var communicationContactPhone = new ORM_CMN_PER_CommunicationContact();
                            communicationContactPhone.IsDeleted = false;
                            communicationContactPhone.Contact_Type = Guid.NewGuid();
                            communicationContactPhone.Tenant_RefID = securityTicket.TenantID;
                            communicationContactPhone.Modification_Timestamp = DateTime.Now;
                            communicationContactPhone.PersonInfo_RefID = businesParticipant.IfNaturalPerson_CMN_PER_PersonInfo_RefID;
                            communicationContactPhone.Content = Parameter.Email;
                            communicationContactPhone.Save(Connection, Transaction);

                            var communicationContactTypePhone = new ORM_CMN_PER_CommunicationContact_Type();
                            communicationContactTypePhone.IsDeleted = false;
                            communicationContactTypePhone.Tenant_RefID = securityTicket.TenantID;
                            communicationContactTypePhone.CMN_PER_CommunicationContact_TypeID = communicationContactPhone.Contact_Type;
                            communicationContactTypePhone.Type = "Email";
                            communicationContactTypePhone.Save(Connection, Transaction);

                        }
                    }

                    var appSettings = ORM_USR_Account_ApplicationSetting.Query.Search(Connection, Transaction, new ORM_USR_Account_ApplicationSetting.Query()
                    {
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID,
                        Account_RefID = accId
                    }).SingleOrDefault();

                    if (appSettings == null)
                    {
                        var accountAppSettings = new ORM_USR_Account_ApplicationSetting();
                        accountAppSettings.IsDeleted = false;
                        accountAppSettings.Account_RefID = accId;
                        accountAppSettings.Creation_Timestamp = DateTime.Now;
                        accountAppSettings.Tenant_RefID = securityTicket.TenantID;
                        accountAppSettings.ItemValue = Parameter.ReceiveNotification.ToString();
                        accountAppSettings.ApplicationSetting_Definition_RefID = Guid.NewGuid();
                        accountAppSettings.Save(Connection, Transaction);

                        var accountAppSettingsDefinitions = new ORM_USR_Account_ApplicationSetting_Definition();
                        accountAppSettingsDefinitions.IsDeleted = false;
                        accountAppSettingsDefinitions.Tenant_RefID = securityTicket.TenantID;
                        accountAppSettingsDefinitions.Creation_Timestamp = DateTime.Now;
                        accountAppSettingsDefinitions.USR_Account_ApplicationSetting_DefinitionID = accountAppSettings.ApplicationSetting_Definition_RefID;
                        accountAppSettingsDefinitions.ItemKey = "ReceiveNotification";
                        accountAppSettingsDefinitions.Save(Connection, Transaction);

                    }
                    else
                    {
                        appSettings.ItemValue = Parameter.ReceiveNotification.ToString();
                        appSettings.Save(Connection, Transaction);

                    }

                    var accountStatus = accountService.GetAccountStatusHistory(securityTicket.TenantID, Parameter.UserID).OrderBy(sth => sth.CreationTimestamp).Reverse().FirstOrDefault();
                    if (Parameter.isDeactivated == true)
                    {
                        if (accountStatus.Status != EAccountStatus.BANNED)
                            accountService.BanAccount(Parameter.UserID, "Konto wurde vom Administrator deaktiviert");
                    }
                    else
                    {
                        if (accountStatus.Status == EAccountStatus.BANNED)
                            accountService.UnbanAccount(Parameter.UserID);
                    }
                }
            }
            P_MD_SPtMU_1433 PSaveUserPermisions = new P_MD_SPtMU_1433();
            PSaveUserPermisions.AccountID = accId;
            PSaveUserPermisions.Role = Parameter.isAdmin ? Properties.Settings.Default.MasterAccountMMApp : Properties.Settings.Default.RegularAccountMMApp;
            PSaveUserPermisions.GroupName = Properties.Settings.Default.MMAppGroup;
            cls_Save_Permisions_to_User.Invoke(Connection, Transaction, PSaveUserPermisions, securityTicket);
            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_Guid Invoke(string ConnectionString, P_MD_SAU_1236 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, P_MD_SAU_1236 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, P_MD_SAU_1236 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_MD_SAU_1236 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

                throw new Exception("Exception occured in method cls_Add_New_User", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes
    #region SClass P_MD_SAU_1236 for attribute P_MD_SAU_1236
    [DataContract]
    public class P_MD_SAU_1236
    {
        //Standard type parameters
        [DataMember]
        public Guid UserID { get; set; }
        [DataMember]
        public string Salutation { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public bool isAdmin { get; set; }
        [DataMember]
        public bool isDeactivated { get; set; }
        [DataMember]
        public string LoginEmail { get; set; }
        [DataMember]
        public string inPasswordMail { get; set; }
        [DataMember]
        public string inPassword { get; set; }
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public bool ReceiveNotification { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Add_New_User(,P_MD_SAU_1236 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Add_New_User.Invoke(connectionString,P_MD_SAU_1236 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.MainData.Complex.Manipulation.P_MD_SAU_1236();
parameter.UserID = ...;
parameter.Salutation = ...;
parameter.Title = ...;
parameter.FirstName = ...;
parameter.LastName = ...;
parameter.Email = ...;
parameter.isAdmin = ...;
parameter.isDeactivated = ...;
parameter.LoginEmail = ...;
parameter.inPasswordMail = ...;
parameter.inPassword = ...;
parameter.Phone  = ...;
parameter.ReceiveNotification = ...;

*/
