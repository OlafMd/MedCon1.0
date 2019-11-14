using BOp.Providers;
using BOp.Providers.RAA;
using BOp.Providers.TMS;
using DLCore_TokenVerification;
using LogUtils;
using MediosConnectSignalR;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.AspNet.SignalR.Infrastructure;
using MMDocConnectDBMethods.MainData.Atomic.Retrieval;
using MMDocConnectMMApp.Filters;
using MMDocConnectMMApp.Models;
using MMDocConnectMMApp.Properties;
using MMDocConnectMMAppInterfaces;
using MMDocConnectMMAppServices;
using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Security;

namespace MMDocConnectMMApp.Controllers
{
    [RoutePrefix("api/main")]
    public class MainApiController : BaseApiController
    {

        IMainData mainDataservice;
        string connectionString;
        private string sessionToken;
        private string userLoginEmail;
        private object state;
        private Timer notificationTimer;

        public MainApiController()
        {
            mainDataservice = new MainDataService();
            this.connectionString = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["activeConnection"]].ConnectionString;
        }

        #region GET
        [Route("InitializeApplication")]
        [HttpGet]
        [AuthenticationFilter]
        public HttpResponseMessage InitializeApplication()
        {
            var transaction = new TransactionalInformation();
            var userApiModel = new UserApiModel();

            try
            {
                var data = mainDataservice.GetUserName(connectionString, SessionToken, Properties.Settings.Default.MMAppGroup, Properties.Settings.Default.MasterAccountMMApp, out transaction);

                if (string.IsNullOrWhiteSpace(data.name))
                    userApiModel.name = data.email;
                else
                    userApiModel.name = data.name + ", MM";

                userApiModel.isMaster = data.role == Properties.Settings.Default.MasterAccountMMApp ? true : false;
                userApiModel.ReturnMessage = transaction.ReturnMessage;
                userApiModel.ReturnStatus = transaction.ReturnStatus;
                userApiModel.IsAuthenicated = transaction.IsAuthenicated;
                userApiModel.IsException = transaction.IsException;
                userLoginEmail = userApiModel.loginEmail = data.email;
            }
            catch (Exception ex)
            {
                transaction.ReturnStatus = false;
                transaction.IsException = true;
                transaction.IsAuthenicated = false;
                transaction.ReturnMessage.Add(ex.Message);
                transaction.logoutUrl = GlobalProperties.LOGIN_PAGE;
            }

            sessionToken = SessionToken;
            var timeout = 5000;

            try
            {
                timeout = Convert.ToInt32(ConfigurationManager.AppSettings["notificationTimeoutInMiliseconds"]);
            }
            catch (Exception ex)
            {
                timeout = 5000;
            }

            if (!SignalRNotifier.Instance.usersThatAreAlreadyReceievingNotifications.Contains(userLoginEmail))
            {
                SignalRNotifier.Instance.usersThatAreAlreadyReceievingNotifications.Add(userLoginEmail);
                notificationTimer = new Timer(new TimerCallback(update), state, 0, timeout);
            }
            if (transaction.ReturnStatus)
                return Request.CreateResponse<UserApiModel>(HttpStatusCode.OK, userApiModel);

            return Request.CreateResponse(HttpStatusCode.BadRequest, transaction);
        }

        private void update(object state)
        {
            var sessionProvider = ProviderFactory.Instance.CreateSessionServiceProvider();

            if (SignalRNotifier.Instance.usersThatAreAlreadyReceievingNotifications.Contains(userLoginEmail))
            {
                try
                {
                    var session = AuthenticationMethods.GetSessionData(sessionToken);
                    if (session == null || !sessionProvider.CheckIfSessionIsValid(sessionToken) || sessionProvider.GetSessionInformation(sessionToken) == null || !sessionProvider.CheckIfSessionExists(sessionToken))
                    {
                        GlobalHost.ConnectionManager.GetHubContext<NotificationsHub>().Clients.Group(userLoginEmail).sessionExpired(new { redirectTo = GlobalProperties.LOGIN_PAGE });
                        SignalRNotifier.Instance.usersThatAreAlreadyReceievingNotifications.Remove(userLoginEmail);
                        SignalRNotifier.Instance.usersThatAreAlreadyReceievingNewDashboardData.Remove(userLoginEmail);
                        notificationTimer.Dispose();
                    }
                    /*
                    var notificationsTransaction = new TransactionalInformation();
                    var response = mainDataservice.GetNotificationData(connectionString, sessionToken, out notificationsTransaction);

                    if (notificationsTransaction.ReturnStatus)
                    {
                        if (!SignalRNotifier.Instance.lastSentNotificationData.ContainsKey(sessionToken) || SignalRNotifier.Instance.lastSentNotificationData[sessionToken].AnyTileDataChanged(response))
                        {
                            
                            if (!SignalRNotifier.Instance.lastSentNotificationData.ContainsKey(sessionToken))
                                SignalRNotifier.Instance.lastSentNotificationData.Add(sessionToken, response);
                            else
                                SignalRNotifier.Instance.lastSentNotificationData[sessionToken] = response;

                            GlobalHost.ConnectionManager.GetHubContext<NotificationsHub>().Clients.Group(userLoginEmail).updateNotifications(response);
                             
                        }
                    }
                    */
                }
                catch (Exception ex)
                {
                    GlobalHost.ConnectionManager.GetHubContext<NotificationsHub>().Clients.Group(userLoginEmail).sessionExpired(new { redirectTo = GlobalProperties.LOGIN_PAGE });
                    SignalRNotifier.Instance.usersThatAreAlreadyReceievingNotifications.Remove(userLoginEmail);
                    SignalRNotifier.Instance.usersThatAreAlreadyReceievingNewDashboardData.Remove(userLoginEmail);
                    notificationTimer.Dispose();
                }
            }
            else
            {
                SignalRNotifier.Instance.usersThatAreAlreadyReceievingNewDashboardData.Remove(userLoginEmail);
                notificationTimer.Dispose();
            }
        }

        [Route("AuthenicateUser")]
        [HttpGet]
        [AuthenticationFilter]
        public HttpResponseMessage AuthenicateUser([FromUri] string route)
        {

            var transaction = new TransactionalInformation();
            var status = HttpStatusCode.OK;
            try
            {
                var userInfo = mainDataservice.GetUserName(connectionString, SessionToken, Properties.Settings.Default.MMAppGroup, Properties.Settings.Default.MasterAccountMMApp, out transaction);
                if (transaction.ReturnStatus)
                {
                    if (userInfo.group_id == Properties.Settings.Default.MMAppGroup)
                    {
                        if (userInfo.role != Properties.Settings.Default.MasterAccountMMApp)
                        {
                            if (route.Contains("app_settings") || route.Contains("employee"))
                            {
                                status = HttpStatusCode.Forbidden;
                            }
                        }
                    }
                    else
                    {
                        transaction.IsAuthenicated = false;
                    }

                    transaction.logoutUrl = GlobalProperties.LOGIN_PAGE;
                    return Request.CreateResponse<TransactionalInformation>(status, transaction);
                }

                transaction.logoutUrl = GlobalProperties.LOGIN_PAGE;
                return Request.CreateResponse(HttpStatusCode.Forbidden, transaction);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }

        [Route("Logout")]
        [HttpGet]
        public HttpResponseMessage Logout()
        {
            var transaction = new TransactionalInformation();
            var userInfo = mainDataservice.GetUserName(connectionString, SessionToken, Properties.Settings.Default.MMAppGroup, Properties.Settings.Default.MasterAccountMMApp, out transaction);
            if (transaction.ReturnStatus)
            {
                SignalRNotifier.Instance.usersThatAreAlreadyReceievingNotifications.Remove(userInfo.email);
                SignalRNotifier.Instance.usersThatAreAlreadyReceievingNewDashboardData.Remove(userInfo.email);
            }

            var sessionToken = SessionToken;

            ProviderFactory.Instance.CreateSessionServiceProvider().SignOut(sessionToken);

            transaction.logoutUrl = GlobalProperties.LOGIN_PAGE;
            transaction.IsAuthenicated = false;

            var response = Request.CreateResponse<TransactionalInformation>(HttpStatusCode.OK, transaction);
            if (sessionToken != null)
            {
                var cookie = new CookieHeaderValue("bops", "st=" + sessionToken);
                cookie.Expires = DateTime.Now.AddDays(-1d);
                cookie.Domain = Request.RequestUri.Host;
                cookie.Path = "/";
                SignalRNotifier.Instance.lastSentDashboardData.Remove(sessionToken);
                SignalRNotifier.Instance.lastSentNotificationData.Remove(sessionToken);
                response.Headers.AddCookies(new CookieHeaderValue[] { cookie });
            }

            return response;
        }

        [Route("GetEmployeesForRightID")]
        [HttpGet]
        [AuthenticationFilter]
        public HttpResponseMessage GetEmployeesForRightID([FromUri]bool isMaster)
        {
            var transaction = new TransactionalInformation();
            var right_id = isMaster ? Properties.Settings.Default.MasterAccountMMApp : Properties.Settings.Default.RegularAccountMMApp;
            var employees = mainDataservice.GetEmployeesForRightID(right_id, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, employees);

            return Request.CreateResponse(HttpStatusCode.BadRequest);

        }

        [Route("GetNotifications")]
        [HttpGet]
        [AuthenticationFilter]
        public HttpResponseMessage GetNotifications()
        {
            TransactionalInformation transaction = new TransactionalInformation();
            var response = mainDataservice.GetNotificationData(connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, response);

            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
        #endregion

        #region POST
        [Route("ChangeAccountPassword")]
        [HttpPost]
        [AuthenticationFilter]
        public HttpResponseMessage ChangeAccountPassword(ChangePasswordModel pass)
        {
            var transaction = new TransactionalInformation();

            var passwordChanged = mainDataservice.ChangeAccountPassword(pass, connectionString, SessionToken, out transaction);
            var response = Request.CreateResponse<TransactionalInformation>(HttpStatusCode.OK, transaction);
            return response;
        }

        [Route("VerifyPassword")]
        [HttpPost]
        [AuthenticationFilter]
        public HttpResponseMessage VerifyPassword(PasswordVerificationParameter parameter)
        {
            bool password_verified = false;
            var transaction = new TransactionalInformation();

            password_verified = mainDataservice.VerifyPassword(parameter.user_login_email, parameter.password, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse<bool>(HttpStatusCode.OK, password_verified);

            return Request.CreateResponse(HttpStatusCode.Forbidden);
        }
        #endregion
    }
}
