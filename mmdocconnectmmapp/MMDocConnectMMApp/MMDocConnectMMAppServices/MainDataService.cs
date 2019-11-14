using BOp.Exceptions;
using BOp.Providers;
using BOp.Providers.TMS;
using BOp.Providers.TMS.Requests;
using CL1_USR;
using CSV2Core.SessionSecurity;
using DLCore_TokenVerification;
using LogUtils;
using MMDocConnectDBMethods.Case.Atomic.Retrieval;
using MMDocConnectDBMethods.Doctor.Atomic.Retrieval;
using MMDocConnectDBMethods.MainData.Atomic.Manipulation;
using MMDocConnectDBMethods.MainData.Atomic.Retrieval;
using MMDocConnectDBMethods.Order.Atomic.Retrieval;
using MMDocConnectMMApp.Models;
using MMDocConnectMMAppInterfaces;
using MMDocConnectMMAppModels;
using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Script.Serialization;


namespace MMDocConnectMMAppServices
{
    public class MainDataService : BaseVerification, IMainData
    {

        #region RETRIEVAL

        public TileInfo GetNotificationData(string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();

            transaction = new TransactionalInformation();
            transaction.IsAuthenicated = true;
            var userSecurityTicket = VerifySessionToken(sessionTicket);

            var response = new TileInfo();

            try
            {
                var orderData = cls_Get_All_MO1_Orders.Invoke(connectionString, userSecurityTicket).Result;
                if (orderData != null)
                {
                    response.drugOrdersTile.numberOfCases = orderData.number_of_tiles.ToString();
                }

                var doctor_count = cls_Get_Temporary_Doctor_Count_and_Oldest_Date.Invoke(connectionString, userSecurityTicket).Result;
                if (doctor_count != null)
                {
                    response.temporaryDoctorsTile.numberOfCases = doctor_count.numberOfAcDocs.ToString();
                }


                var casesFs = cls_Get_all_Cases_in_FS_statuses.Invoke(connectionString, new P_CAS_GACiFS_1515() { FStatus = new string[] { "3", "5" } }, userSecurityTicket).Result;
                if (casesFs.Length > 0)
                {
                    response.errorCorrectionsTile.numberOfCases = casesFs.GroupBy(gr => new { gr.HeaderID, gr.CodeForType }).Select(grp => grp.ToList()).ToList().Count().ToString();
                }
            }
            catch (Exception ex)
            {
                Logger.LogInfo(new LogEntry(null, null, connectionString, method, userSecurityTicket, ex));

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message + "; Notifications retrieval.";
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }

            return response;
        }
        public MD_GAI_1617 GetUserName(string connectionString, string sessionTicket, string groupID, string MasterRole, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            transaction = new TransactionalInformation();
            transaction.IsAuthenicated = true;
            MD_GAI_1617 data = new MD_GAI_1617();
            var userSecurityTicket = VerifySessionToken(sessionTicket);

            try
            {
                data = cls_Get_Account_Information.Invoke(connectionString, userSecurityTicket).Result;

                if (data.group_id != groupID)
                {
                    if (data.AccountType == 0)
                    {
                        cls_Save_Permisions_to_User.Invoke(connectionString, new P_MD_SPtMU_1433 { GroupName = groupID, Role = MasterRole, AccountID = userSecurityTicket.AccountID }, userSecurityTicket);

                        //Company settings for new Tenant
                        P_MD_SCS_1700 parameter = new P_MD_SCS_1700();
                        parameter.AccountID = userSecurityTicket.AccountID;
                        parameter.Email = WebConfigurationManager.AppSettings["mailFrom"];
                        parameter.OrderInterval = 120;
                        parameter.ImmediateOrderInterval = 120;
                        cls_Save_Company_Settings.Invoke(connectionString, parameter, userSecurityTicket);

                        data.group_id = groupID;
                        data.role = MasterRole;
                    }
                    else
                    {
                        transaction.ReturnMessage = new List<string>();
                        string errorMessage = "Zugriff nicht gestattet.";
                        transaction.ReturnStatus = false;
                        transaction.IsAuthenicated = false;
                        transaction.ReturnMessage.Add(errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, userSecurityTicket, ex));

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message != "The creator of this fault did not specify a Reason." ? ex.Message : "Irgendwas ist schiefgegangen";
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
                transaction.logoutUrl = GlobalProperties.LOGIN_PAGE;
            }

            return data;
        }
        public EmployeeVerificationObject GetEmployeesForRightID(string rightID, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            transaction = new TransactionalInformation();
            var userSecurityTicket = VerifySessionToken(sessionTicket);
            EmployeeVerificationObject response = new EmployeeVerificationObject();

            try
            {
                var employees = cls_Get_Employees_for_RightID.Invoke(connectionString, new P_MD_GEfRID_1738() { RightID = rightID }, userSecurityTicket).Result;
                if (employees.Any())
                {
                    response.employees = employees.Select(e =>
                    {
                        return new Employee
                        {
                            email = e.user_login_email,
                            name = e.user_name
                        };
                    }).ToArray();

                    var logged_in_user = employees.Where(e => e.user_account_id == userSecurityTicket.AccountID).SingleOrDefault();
                    if (logged_in_user != null)
                    {
                        response.logged_in_user_email = logged_in_user.user_login_email;
                    }
                    else
                    {
                        response.logged_in_user_email = employees.First().user_login_email;
                    }
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

            return response;
        }
        #endregion

        #region MANIPULATION
        public bool ChangeAccountPassword(ChangePasswordModel pass, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            transaction = new TransactionalInformation();
            var userSecurityTicket = VerifySessionToken(sessionTicket);

            try
            {
                P_MD_CAP_1503 passParameter = new P_MD_CAP_1503();
                passParameter.PassID = pass.ID;
                passParameter.Password = pass.password;
                passParameter.Type = pass.type;
                cls_Change_Account_Password.Invoke(connectionString, passParameter, userSecurityTicket);

                Logger.LogInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, userSecurityTicket, pass));
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

            return true;
        }
        #endregion

        #region VALIDATION
        public bool VerifyPassword(string email, string password, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            bool password_verified = false;
            transaction = new TransactionalInformation();
            var userSecurityTicket = VerifySessionToken(sessionTicket);

            try
            {
                IAccountServiceProvider accountService;
                var _providerFactory = ProviderFactory.Instance;
                accountService = _providerFactory.CreateAccountServiceProvider();
                ChangePasswordRequest request = new ChangePasswordRequest();
                request.NewPassword = password;
                request.OldPassword = password;
                request.TenantID = userSecurityTicket.TenantID;

                request.Email = email;
                password_verified = accountService.ChangePassword(request).ChangedAccounts.FirstOrDefault() != null;
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

                    return password_verified;
                }
                else
                {
                    Logger.LogInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, userSecurityTicket, ex));

                    transaction.ReturnMessage = new List<string>();
                    string errorMessage = ex.Message;
                    transaction.ReturnStatus = false;
                    transaction.ReturnMessage.Add(errorMessage);
                    transaction.IsAuthenicated = true;
                    transaction.IsException = true;
                }
            }

            return password_verified;
        }
        #endregion

    }
}
