/* 
 * Generated on 03/01/16 17:30:17
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
using BOp.Providers.TMS;
using MMDocConnectDBMethods.Doctor.Atomic.Retrieval;
using MMDocConnectDBMethods.MainData.Atomic.Retrieval;
using BOp.Providers;
using System.Web.Configuration;
using System.Web;
using System.IO;
using Newtonsoft.Json;
using MMDocConnectUtils;

namespace MMDocConnectDBMethods.Doctor.Atomic.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Change_Password.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Change_Password
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Guid Execute(DbConnection Connection, DbTransaction Transaction, P_DO_CP_1724 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_Guid();
            //Put your code here
            var _providerFactory = ProviderFactory.Instance;
            IAccountServiceProvider accountService = _providerFactory.CreateAccountServiceProvider();
            List<String> MailToL = new List<String>();
            string mailToFromCompanySettings = "";
            var accountId = Guid.Empty;
            var accountMail = "";
            var displayName = "";

            if (Parameter.type == "Arzt")
            {
                var account = cls_Get_Doctor_AccountID_for_DoctorID.Invoke(Connection, Transaction, new P_DO_GDAIDfDID_1549() { DoctorID = Parameter.ID }, securityTicket).Result;
                accountId = account.accountID;
                accountMail = account.accountMail;
                MailToL.Add(accountMail);
                displayName = account.DisplayName;
                var doctorDetails = cls_Get_Doctor_Details_for_DoctorID.Invoke(Connection, Transaction, new P_DO_GDDfDID_0823() { DoctorID = Parameter.ID }, securityTicket).Result.Single();
                string maildoc = null;
                if (doctorDetails.DoctorComunication.Where(k => k.Type == "Email").SingleOrDefault() != null)
                    maildoc = doctorDetails.DoctorComunication.Where(k => k.Type == "Email").Single().Content;

                if (maildoc != null && maildoc != accountMail)
                    MailToL.Add(maildoc);
                mailToFromCompanySettings = cls_Get_Company_Settings.Invoke(Connection, Transaction, securityTicket).Result.Email;
                MailToL.Add(mailToFromCompanySettings);

            }
            else if (Parameter.type == "Praxis")
            {
                var account = cls_Get_Practice_AccountID_for_PracticeID.Invoke(Connection, Transaction, new P_DO_GPAIDfPID_1351() { PracticeID = Parameter.ID }, securityTicket).Result;
                accountId = account.accountID;
                accountMail = account.accountMail;
                MailToL.Add(accountMail);
                displayName = account.DisplayName;
                var practiceDetails = cls_Get_Practice_Details_for_PracticeID.Invoke(Connection, Transaction, new P_DO_GPDfPID_1432() { PracticeID = Parameter.ID }, securityTicket).Result;
                string mailPractice = practiceDetails.FirstOrDefault().contact_email;
                if (mailPractice != null && mailPractice != accountMail)
                    MailToL.Add(mailPractice);
                mailToFromCompanySettings = cls_Get_Company_Settings.Invoke(Connection, Transaction, securityTicket).Result.Email;
                MailToL.Add(mailToFromCompanySettings);
            }


            BOp.Providers.TMS.Requests.ResetPasswordRequest request = new BOp.Providers.TMS.Requests.ResetPasswordRequest();
            request.AccountID = accountId;
            request.NewPassword = Parameter.password;
            request.SessionToken = securityTicket.SessionTicket;
            accountService.ResetPassword(request);

            string appName = WebConfigurationManager.AppSettings["mmAppUrl"];
            var prefix = HttpContext.Current.Request.Url.AbsoluteUri.Contains("https") ? "https://" : "http://";
            var imageUrl = HttpContext.Current.Request.Url.AbsoluteUri.Substring(0, HttpContext.Current.Request.Url.AbsoluteUri.IndexOf("api")) + "Content/images/logo.png";
            var email_template = File.ReadAllText(HttpContext.Current.Server.MapPath("~/EmailTemplates/PasswordChangedEmailTemplate.html"));

            var subjectsJson = File.ReadAllText(HttpContext.Current.Server.MapPath("~/EmailTemplates/EmailSubjects.json"));
            dynamic subjects = JsonConvert.DeserializeObject(subjectsJson);
            var subjectMail = subjects["NewPasswordSubject"].ToString();

            email_template = EmailTemplater.SetTemplateData(email_template, new
            {
                name = displayName,
                password = Parameter.password,
                mmapp_dashboard_url = prefix + HttpContext.Current.Request.Url.Authority + "/" + appName,
                medios_connect_logo_url = imageUrl
            }, "{{", "}}");

            try
            {
                // string mailFrom = cls_Get_Company_Settings.Invoke(Connection, Transaction, securityTicket).Result.Email;
                string mailFrom = WebConfigurationManager.AppSettings["mailFrom"];
                var mailsDistinct = MailToL.Distinct().ToList();
                foreach (var mailTo in mailsDistinct)
                {
                    EmailNotificationSenderUtil.SendEmail(mailFrom, mailTo, subjectMail, email_template);
                }

            }
            catch (Exception ex)
            {
                LogUtils.Logger.LogDocAppInfo(new LogUtils.LogEntry(System.Reflection.MethodInfo.GetCurrentMethod(), ex, null, "Change password (doc app): Email sending failed."), "EmailExceptions");
            }
            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_Guid Invoke(string ConnectionString, P_DO_CP_1724 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, P_DO_CP_1724 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, P_DO_CP_1724 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_DO_CP_1724 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

                throw new Exception("Exception occured in method cls_Change_Password", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes
    #region SClass P_DO_CP_1724 for attribute P_DO_CP_1724
    [DataContract]
    public class P_DO_CP_1724
    {
        //Standard type parameters
        [DataMember]
        public Guid ID { get; set; }
        [DataMember]
        public String type { get; set; }
        [DataMember]
        public String password { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Change_Password(,P_DO_CP_1724 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Change_Password.Invoke(connectionString,P_DO_CP_1724 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Doctor.Atomic.Manipulation.P_DO_CP_1724();
parameter.ID = ...;
parameter.type = ...;
parameter.password = ...;

*/
