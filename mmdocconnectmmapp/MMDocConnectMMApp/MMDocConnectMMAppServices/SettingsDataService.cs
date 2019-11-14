using BOp.Exceptions;
using BOp.Providers;
using BOp.Providers.TMS;
using BOp.Providers.TMS.Requests;
using CSV2Core.SessionSecurity;
using DLCore_TokenVerification;
using LogUtils;
using MMDocConnectDBMethods.MainData.Atomic.Manipulation;
using MMDocConnectDBMethods.MainData.Atomic.Retrieval;
using MMDocConnectDBMethods.MainData.Complex.Manipulation;
using MMDocConnectDocAppModels;
using MMDocConnectElasticSearchMethods.Models;
using MMDocConnectMMApp.Models;
using MMDocConnectMMAppInterfaces;
using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;

namespace MMDocConnectMMAppServices
{
    public class SettingsDataService : BaseVerification, ISettingsService
    {
        #region RETRIEVAL
        /// <summary>
        /// Get all users/Employees for user list
        /// </summary>
        /// <param name="sort_parameter"></param>
        /// <param name="connectionString"></param>
        /// <param name="sessionTicket"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public Employee_Model[] GetEmployees(ElasticParameterObject sort_parameter, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            transaction = new TransactionalInformation();
            var userSecurityTicket = VerifySessionToken(sessionTicket);

            try
            {
                var employees = cls_Get_Employees.Invoke(connectionString, userSecurityTicket).Result;
                if (employees.Length != 0)
                {
                    var response = employees.Select(emp =>
                    {
                        var email_contact = emp.Contact == null ? null : emp.Contact.Where(c => c.Type == "Email").SingleOrDefault();
                        var phone_contact = emp.Contact == null ? null : emp.Contact.Where(c => c.Type == "Phone").SingleOrDefault();

                        Employee_Model employee = new Employee_Model()
                        {
                            id = emp.employee_id,
                            name = emp.employee_name,
                            email = email_contact == null ? "" : email_contact.Content,
                            phone = phone_contact == null ? "" : phone_contact.Content,
                            is_admin = emp.employee_rights == "mm.docconect.mm.app.master",
                            group_name = String.IsNullOrEmpty(emp.employee_name) ? "" : emp.employee_name.Substring(0, 1).ToUpper()
                        };

                        return employee;
                    }).ToArray();

                    if (!sort_parameter.isAsc)
                        response = response.Reverse().ToArray();

                    return response;
                }
            }
            catch (Exception ex)
            {
                Logger.LogInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, userSecurityTicket, ex));

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }

            return new Employee_Model[] { };
        }

        /// <summary>
        /// Get all user with admin right
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="sessionTicket"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public List<Employee_Model> GetUsers(string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            List<Employee_Model> usersM = new List<Employee_Model>();
            transaction = new TransactionalInformation();
            var userSecurityTicket = VerifySessionToken(sessionTicket);

            try
            {
                var users = cls_Get_Employees.Invoke(connectionString, userSecurityTicket).Result.Where(st => st.employee_rights == "mm.docconect.mm.app.master").OrderBy(nm => nm.employee_name);
                foreach (var user in users)
                {
                    Employee_Model userM = new Employee_Model();
                    userM.id = user.employee_id;
                    userM.name = user.employee_name;
                    usersM.Add(userM);
                }
            }
            catch (Exception ex)
            {
                Logger.LogInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, userSecurityTicket, ex));

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }

            return usersM;
        }


        /// <summary>
        /// Get company settings such as default email , order notification interval ad immediate order notification interval
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="sessionTicket"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public AppSettings GetCompanySettings(string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            AppSettings settings = new AppSettings();
            transaction = new TransactionalInformation();
            var userSecurityTicket = VerifySessionToken(sessionTicket);

            try
            {
                var data = cls_Get_Company_Settings.Invoke(connectionString, userSecurityTicket).Result;
                settings.AdminUser = data.AccountID;
                settings.Email = data.Email;
                settings.ImmediateOrderInterval = data.ImmediateOrderInterval;
                settings.OrderInterval = data.OrderInterval;

            }
            catch (Exception ex)
            {
                Logger.LogInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, userSecurityTicket, ex));

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }
            return settings;
        }
        /// <summary>
        /// Get user information for accountID this data is used when editing user
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="connectionString"></param>
        /// <param name="sessionTicket"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public User GetUserForAccountID(Guid UserID, string connectionString, string sessionTicket, out TransactionalInformation transaction, HttpRequest request = null)
        {
            var method = MethodInfo.GetCurrentMethod();
            IPInfo ipInfo = request == null ? Util.GetIPInfo(HttpContext.Current.Request) : Util.GetIPInfo(request);

            User user = new User();
            transaction = new TransactionalInformation();
            var userSecurityTicket = VerifySessionToken(sessionTicket);

            try
            {
                var data = cls_Get_Account_Information_for_AccountID.Invoke(connectionString, new P_MD_GAIfAID_1436() { UserAccountID = UserID }, userSecurityTicket).Result;
                user.id = UserID;
                user.FirstName = data.FirstName;
                user.LastName = data.LastName;
                user.LoginEmail = data.LoginMail;
                user.Email = data.Contact.Length != 0 ? data.Contact.Where(usr => usr.Type == "Email").SingleOrDefault() != null ? data.Contact.Where(usr => usr.Type == "Email").SingleOrDefault().Content : null : null;
                user.Phone = data.Contact.Length != 0 ? data.Contact.Where(usr => usr.Type == "Phone").SingleOrDefault() != null ? data.Contact.Where(usr => usr.Type == "Phone").SingleOrDefault().Content : null : null;
                user.isAdmin = data.Rights == "mm.docconect.mm.app.master" ? true : false;
                user.ReceiveNotification = Convert.ToBoolean(data.ReceiveNotification);
                IAccountServiceProvider accountService;
                var _providerFactory = ProviderFactory.Instance;
                accountService = _providerFactory.CreateAccountServiceProvider();
                var accountStatus = accountService.GetAccountStatusHistory(userSecurityTicket.TenantID, UserID).OrderBy(sth => sth.CreationTimestamp).Reverse().FirstOrDefault();
                user.isDeactivated = accountStatus.Status != EAccountStatus.BANNED ? false : true;

                user.Title = data.Title;
                user.Salutation = data.Salutation;
            }
            catch (Exception ex)
            {
                Logger.LogInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, userSecurityTicket, ex));

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }

            return user;
        }

        /// <summary>
        /// Retrieves data about currently logged user this data is used for my account form in MMapp settings page
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="sessionTicket"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public User GetUserForMyAccount(string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            User user = new User();
            transaction = new TransactionalInformation();
            var userSecurityTicket = VerifySessionToken(sessionTicket);

            try
            {
                Guid UserID = userSecurityTicket.AccountID;
                var data = cls_Get_Account_Information_for_AccountID.Invoke(connectionString, new P_MD_GAIfAID_1436() { UserAccountID = UserID }, userSecurityTicket).Result;
                user.id = UserID;
                user.FirstName = data.FirstName;
                user.LastName = data.LastName;
                user.LoginEmail = data.LoginMail;
                user.Email = data.Contact.Length != 0 ? data.Contact.Where(usr => usr.Type == "Email").SingleOrDefault() != null ? data.Contact.Where(usr => usr.Type == "Email").SingleOrDefault().Content : null : null;
                user.Phone = data.Contact.Length != 0 ? data.Contact.Where(usr => usr.Type == "Phone").SingleOrDefault() != null ? data.Contact.Where(usr => usr.Type == "Phone").SingleOrDefault().Content : null : null;
                user.isAdmin = data.Rights == "mm.docconect.mm.app.master" ? true : false;
                user.ReceiveNotification = Convert.ToBoolean(data.ReceiveNotification);
                IAccountServiceProvider accountService;
                var _providerFactory = ProviderFactory.Instance;
                accountService = _providerFactory.CreateAccountServiceProvider();
                var accountStatus = accountService.GetAccountStatusHistory(userSecurityTicket.TenantID, UserID).OrderBy(sth => sth.CreationTimestamp).Reverse().FirstOrDefault();
                user.isDeactivated = accountStatus.Status != EAccountStatus.BANNED ? false : true;

                user.Title = data.Title;
                user.Salutation = data.Salutation;

            }
            catch (Exception ex)
            {
                Logger.LogInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, userSecurityTicket, ex));

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }
            return user;
        }
        #endregion

        #region MANIPULATION
        /// <summary>
        /// add new user to mm app it can be regular or admin user
        /// </summary>
        /// <param name="user"></param>
        /// <param name="connectionString"></param>
        /// <param name="sessionTicket"></param>
        /// <param name="transaction"></param>
        public string AddUser(User user, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var request = HttpContext.Current.Request;
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(request);

            transaction = new TransactionalInformation();
            var infoMessage = "";
            var userSecurityTicket = VerifySessionToken(sessionTicket);

            try
            {
                IAccountServiceProvider accountService;
                var _providerFactory = ProviderFactory.Instance;
                accountService = _providerFactory.CreateAccountServiceProvider();
                var accountStatus = accountService.GetAccountStatusHistory(userSecurityTicket.TenantID, user.id).OrderBy(sth => sth.CreationTimestamp).Reverse().FirstOrDefault();
                P_MD_SAU_1236 UserParameter = new P_MD_SAU_1236();
                UserParameter.UserID = user.id;
                UserParameter.isAdmin = user.isAdmin;
                UserParameter.Salutation = user.Salutation;
                UserParameter.Title = user.Title;
                UserParameter.FirstName = user.FirstName;
                UserParameter.LastName = user.LastName;
                UserParameter.Email = user.Email;
                UserParameter.LoginEmail = user.LoginEmail;
                UserParameter.inPassword = Util.CalculateMD5Hash(user.inPassword);
                UserParameter.inPasswordMail = user.inPassword;
                UserParameter.Phone = user.Phone;
                UserParameter.isDeactivated = user.isDeactivated;
                UserParameter.ReceiveNotification = user.ReceiveNotification;

                var users = cls_Get_Employees.Invoke(connectionString, userSecurityTicket).Result.ToList();
                var usersAdmins = cls_Get_Employees.Invoke(connectionString, userSecurityTicket).Result.Where(frd => frd.employee_rights == "mm.docconect.mm.app.master").ToList();
                List<Boolean> activeUsers = new List<Boolean>();
                List<Boolean> activeAdminUsers = new List<Boolean>();
                foreach (var accountsStatuses in users)
                {
                    var accountStatusUser = accountService.GetAccountStatusHistory(userSecurityTicket.TenantID, accountsStatuses.employee_id).OrderBy(sth => sth.CreationTimestamp).Reverse().FirstOrDefault();
                    activeUsers.Add(accountStatusUser.Status != EAccountStatus.BANNED ? true : false);
                }
                foreach (var accountsStatuses in usersAdmins)
                {
                    var accountStatusUser = accountService.GetAccountStatusHistory(userSecurityTicket.TenantID, accountsStatuses.employee_id).OrderBy(sth => sth.CreationTimestamp).Reverse().FirstOrDefault();
                    activeAdminUsers.Add(accountStatusUser.Status != EAccountStatus.BANNED ? true : false);
                }
                int activeUsersInt = activeUsers.Count(st => st == true);
                int activeAdminUsersInt = activeAdminUsers.Count(st => st == true);
                if (!user.isAdmin && activeAdminUsers.Count() == 1 && activeAdminUsersInt == 1 && usersAdmins.FirstOrDefault().employee_id == user.id)
                {
                    infoMessage = "LABEL_ADMIN_USER_INFO";
                }
                else if (user.isDeactivated && (usersAdmins.Count() == 1 && usersAdmins.Any(usid => usid.employee_id == user.id)) && activeAdminUsersInt == 1)
                {
                    infoMessage = "LABEL_ADMIN_USER_INFO";
                }
                else
                {
                    User previous_state = null;
                    if (user.id != Guid.Empty)
                    {

                        Thread detailsThread = new Thread(() => GetUsersPreviousDetails(out previous_state, user.id, connectionString, sessionTicket, request));
                        detailsThread.Start();
                    }

                    infoMessage = UserParameter.UserID != Guid.Empty ? "LABEL_USER_EDITED" : "LABEL_USER_ADDED";
                    cls_Add_New_User.Invoke(connectionString, UserParameter, userSecurityTicket);
                    Logger.LogInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, userSecurityTicket, user, previous_state));
                }
            }
            catch (Exception ex)
            {
                Logger.LogInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, userSecurityTicket, ex));

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }
            return infoMessage;
        }

        /// <summary>
        /// Save new settings for MM user/tenant
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="connectionString"></param>
        /// <param name="sessionTicket"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public string SaveAppSettings(AppSettings settings, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            bool password_verified = false;
            transaction = new TransactionalInformation();
            var userSecurityTicket = VerifySessionToken(sessionTicket);

            try
            {
                //check credentials
                try
                {
                    IAccountServiceProvider accountService;
                    var _providerFactory = ProviderFactory.Instance;
                    accountService = _providerFactory.CreateAccountServiceProvider();
                    ChangePasswordRequest request = new ChangePasswordRequest();
                    request.NewPassword = settings.Password;
                    request.OldPassword = settings.Password;
                    request.TenantID = userSecurityTicket.TenantID;

                    var account = accountService.GetAllAccountsForTenant(userSecurityTicket.TenantID).Where(acc => acc.ID == settings.AdminUser).FirstOrDefault();

                    if (account != null)
                    {
                        request.Email = account.Email;
                        password_verified = accountService.ChangePassword(request).ChangedAccounts.FirstOrDefault() != null;
                    }
                }
                catch (Exception ex)
                {
                    if (ex is SDKServiceException)
                    {
                        transaction.ReturnMessage = new List<string>();
                        ServiceErrror errorMessage = (ServiceErrror)new JavaScriptSerializer().Deserialize(ex.Message, typeof(ServiceErrror));

                        if (errorMessage.Code == 70211)
                        {
                            transaction.ReturnStatus = true;
                            password_verified = true;
                        }
                        else
                        {
                            transaction.ReturnStatus = false;
                            transaction.ReturnMessage.Add(errorMessage.DeveloperMessage);
                            transaction.IsAuthenicated = true;
                            transaction.IsException = true;
                            password_verified = false;
                        }
                    }
                    else
                    {
                        Logger.LogInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, userSecurityTicket, ex));
                        throw new Exception("Something went wrong", ex);
                    }
                }

                if (password_verified)
                {
                    //save settings
                    P_MD_SCS_1700 parameter = new P_MD_SCS_1700();
                    parameter.AccountID = settings.AdminUser;
                    parameter.Email = settings.Email;
                    parameter.OrderInterval = settings.OrderInterval;
                    parameter.ImmediateOrderInterval = settings.ImmediateOrderInterval;

                    AppSettings previous_state = null;

                    Thread detailsThread = new Thread(() => GetCompanySettingsPreviousDetails(out previous_state, connectionString, userSecurityTicket));
                    detailsThread.Start();

                    cls_Save_Company_Settings.Invoke(connectionString, parameter, userSecurityTicket);

                    Logger.LogInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, userSecurityTicket, settings, previous_state));
                }
                else
                {
                    return "password invalid";
                }

            }
            catch (Exception ex)
            {
                Logger.LogInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, userSecurityTicket, ex));

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }

            return "ok";
        }
        #endregion

        #region UTIL
        private static void GetUsersPreviousDetails(out User previous_state, Guid id, string connectionString, string sessionTicket, HttpRequest request)
        {
            var transaction = new TransactionalInformation();
            var sd = new SettingsDataService();

            previous_state = sd.GetUserForAccountID(id, connectionString, sessionTicket, out transaction, request);
        }
        private static void GetCompanySettingsPreviousDetails(out AppSettings previous_state, string connectionString, SessionSecurityTicket userSecurityTicket)
        {
            var transaction = new TransactionalInformation();
            var data = cls_Get_Company_Settings.Invoke(connectionString, userSecurityTicket).Result;
            if (data != null)
            {
                previous_state = new AppSettings();
                previous_state.AdminUser = data.AccountID;
                previous_state.Email = data.Email;
                previous_state.ImmediateOrderInterval = data.ImmediateOrderInterval;
                previous_state.OrderInterval = data.OrderInterval;
            }
            else
            {
                previous_state = null;
            }
        }
        #endregion
    }
}
