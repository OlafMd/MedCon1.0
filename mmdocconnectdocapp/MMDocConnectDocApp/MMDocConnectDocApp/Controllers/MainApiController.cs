using BOp.Providers;
using BOp.Providers.RAA;
using BOp.Providers.TMS;
using BOp.Providers.TMS.Requests;
using BOp.Providers.TMS.Responses;
using MediosConnectSignalR;
using Microsoft.AspNet.SignalR;
using MMDocConnectDBMethods.MainData.Atomic.Retrieval;
using MMDocConnectDBMethods.MainData.Complex.Retrieval;
using MMDocConnectDocApp.Filters;
using MMDocConnectDocApp.Models;
using MMDocConnectDocApp.Properties;
using MMDocConnectDocAppInterfaces;
using MMDocConnectDocAppModels;
using MMDocConnectDocAppServices;
using MMDocConnectElasticSearchMethods.Doctor.Retrieval;
using MMDocConnectElasticSearchMethods.Models;
using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Security;

namespace MMDocConnectDocApp.Controllers
{
    [RoutePrefix("api/main")]
    public class MainApiController : BaseApiController
    {

        IMainData mainDataservice;
        IPatientDataService patientDataService;
        string connectionString;
        private string userLoginEmail;
        private Timer sessionTimer;
        private object state;

        public MainApiController()
        {
            patientDataService = new PatientDataService();
            mainDataservice = new MainDataService();
            this.connectionString = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["activeConnection"]].ConnectionString;
        }

        #region GET

        [Route("InitializeApplication")]
        [HttpGet]
        [AuthenticationFilter]
        public HttpResponseMessage InitializeApplication()
        {
            TransactionalInformation transaction = new TransactionalInformation();
            UserApiModel userApiModel = new UserApiModel();
            try
            {
                var data = mainDataservice.GetUserName(connectionString, SessionToken, Properties.Settings.Default.DocAppGroup, out transaction);
                if (string.IsNullOrWhiteSpace(data.AccountInformation.name))
                {
                    userApiModel.name = data.AccountInformation.email;
                }
                else
                {
                    userApiModel.name = data.AccountInformation.name;
                    if (!String.IsNullOrEmpty(data.AccountInformation.Title))
                    {
                        userApiModel.name = String.Format("{0} {1}", data.AccountInformation.Title, userApiModel.name);
                    }
                }
                if (data.AccountInformation.role == Properties.Settings.Default.ACDocAccountDocApp || data.AccountInformation.role == Properties.Settings.Default.ACPracticeAccountDocApp)
                    userApiModel.isOpRole = false;
                else if (data.AccountInformation.role == Properties.Settings.Default.OPDocAccountDocApp || data.AccountInformation.role == Properties.Settings.Default.OPPracticeAccountDocApp)
                    userApiModel.isOpRole = true;

                userApiModel.canAddPreexaminations = mainDataservice.CanAddPreexaminations(data.PracticeID, connectionString, SessionToken, out transaction);

                userApiModel.ReturnMessage.Add("Application has been initialized.");
                userApiModel.ReturnMessage = transaction.ReturnMessage;
                userApiModel.ReturnStatus = transaction.ReturnStatus;
                userApiModel.IsAuthenicated = transaction.IsAuthenicated;
                userApiModel.IsException = transaction.IsException;
                userApiModel.isDoctor = data.AccountInformation.role == Properties.Settings.Default.OPDocAccountDocApp || data.AccountInformation.role == Properties.Settings.Default.ACDocAccountDocApp;
                userApiModel.id = userApiModel.isDoctor ? data.DoctorID : data.PracticeID;
                userApiModel.loginEmail = userLoginEmail = data.AccountInformation.email;
            }
            catch (Exception ex)
            {
                transaction.ReturnMessage.Add(ex.Message);
                transaction.logoutUrl = GlobalProperties.LOGIN_PAGE;
                transaction.ReturnStatus = false;
            }

            var sessionToken = SessionToken;
            if (!SignalRNotifier.Instance.userSessionTokens.Any(t => t == sessionToken))
            {
                SignalRNotifier.Instance.userSessionTokens.Add(sessionToken);
            }

            var timeout = 5000;

            try
            {
                timeout = Convert.ToInt32(ConfigurationManager.AppSettings["notificationTimeoutInMiliseconds"]);
            }
            catch
            {
                timeout = 5000;
            }

            if (!SignalRNotifier.Instance.usersThatAreAlreadyReceievingNotifications.Contains(userLoginEmail))
            {
                SignalRNotifier.Instance.usersThatAreAlreadyReceievingNotifications.Add(userLoginEmail);
                sessionTimer = new Timer(new TimerCallback(verifySessionAndUpdateNotifications), state, 0, timeout);
            }

            if (transaction.ReturnStatus)
                return Request.CreateResponse<UserApiModel>(HttpStatusCode.OK, userApiModel);

            return Request.CreateResponse(HttpStatusCode.Unauthorized, transaction);
        }

        private void verifySessionAndUpdateNotifications(object state)
        {
            try
            {
                var sessionProvider = ProviderFactory.Instance.CreateSessionServiceProvider();

                if (SignalRNotifier.Instance.usersThatAreAlreadyReceievingNotifications.Contains(userLoginEmail))
                {
                    foreach (var sessionToken in SignalRNotifier.Instance.userSessionTokens)
                    {
                        try
                        {
                            var session = AuthenticationMethods.GetSessionData(sessionToken);
                            if (session == null || !sessionProvider.CheckIfSessionIsValid(sessionToken) || !sessionProvider.CheckIfSessionExists(sessionToken))
                            {
                                SignalRNotifier.Instance.lastSentNotificationData.Remove(sessionToken);
                                GlobalHost.ConnectionManager.GetHubContext<SessionHub>().Clients.Group(sessionToken).sessionExpired(new { redirectTo = GlobalProperties.LOGIN_PAGE });
                                SignalRNotifier.Instance.usersThatAreAlreadyReceievingNotifications.Remove(userLoginEmail);
                                sessionTimer.Dispose();
                            }

                            var transaction = new TransactionalInformation();
                            var response = mainDataservice.GetNotificationData(connectionString, sessionToken, out transaction);

                            if (transaction.ReturnStatus)
                            {
                                if (!SignalRNotifier.Instance.lastSentNotificationData.ContainsKey(sessionToken) || SignalRNotifier.Instance.lastSentNotificationData[sessionToken].AnyTileDataChanged(response))
                                {
                                    if (!SignalRNotifier.Instance.lastSentNotificationData.ContainsKey(sessionToken))
                                        SignalRNotifier.Instance.lastSentNotificationData.Add(sessionToken, response);
                                    else
                                        SignalRNotifier.Instance.lastSentNotificationData[sessionToken] = response;

                                    GlobalHost.ConnectionManager.GetHubContext<SessionHub>().Clients.Group(userLoginEmail).updateNotifications(response);
                                }
                            }
                        }
                        catch
                        {
                            SignalRNotifier.Instance.lastSentNotificationData.Remove(sessionToken);
                            if (userLoginEmail != null)
                            {
                                GlobalHost.ConnectionManager.GetHubContext<SessionHub>().Clients.Group(sessionToken).sessionExpired(new { redirectTo = GlobalProperties.LOGIN_PAGE });
                                SignalRNotifier.Instance.usersThatAreAlreadyReceievingNotifications.Remove(userLoginEmail);
                            }
                            sessionTimer.Dispose();
                        }
                    }
                }
                else
                {
                    sessionTimer.Change(Timeout.Infinite, Timeout.Infinite);
                    sessionTimer.Dispose();
                }
            }
            catch
            {

            }
        }

        [Route("GetNumberOfOCTsPerYear")]
        [HttpGet]
        [AuthenticationFilter]
        public HttpResponseMessage GetNotifications([FromUri] string contractName)
        {
            var transaction = new TransactionalInformation();
            var response = mainDataservice.GetNumberOfOCTsPerYear(contractName, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, response);

            return Request.CreateResponse(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("GetNotifications")]
        [HttpGet]
        [AuthenticationFilter]
        public HttpResponseMessage GetNotifications()
        {
            var transaction = new TransactionalInformation();
            var response = mainDataservice.GetNotificationData(connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, response);

            return Request.CreateResponse(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("GetPracticeAddressAndBacisInfo")]
        [HttpGet]
        [AuthenticationFilter]
        public HttpResponseMessage GetPracticeAddressAndBacisInfo()
        {
            var transaction = new TransactionalInformation();
            var response = mainDataservice.GetPracticeAddressAndBacisInfo(connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, response);

            return Request.CreateResponse(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("RedirectToHelp")]
        [HttpGet]
        [AuthenticationFilter]
        public HttpResponseMessage RedirectToHelp()
        {
            var response = "";
            var transaction = new TransactionalInformation();
            var userInfo = mainDataservice.GetUserName(connectionString, SessionToken, Properties.Settings.Default.DocAppGroup, out transaction);

            if (transaction.ReturnStatus)
            {
                if (userInfo.AccountInformation.role == Properties.Settings.Default.OPDocAccountDocApp || userInfo.AccountInformation.role == Properties.Settings.Default.OPPracticeAccountDocApp)
                    response = ConfigurationManager.AppSettings["helpUrlOP"];
                else
                    response = ConfigurationManager.AppSettings["helpUrlAC"];

                return Request.CreateResponse(HttpStatusCode.OK, response);
            }

            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }

        [Route("AuthenicateUser")]
        [HttpGet]
        [AuthenticationFilter]
        public HttpResponseMessage AuthenicateUser([FromUri] string route)
        {
            TransactionalInformation transaction = new TransactionalInformation();
            transaction.logoutUrl = GlobalProperties.LOGIN_PAGE;
            try
            {
                var account_role = mainDataservice.GetAccountRole(connectionString, SessionToken, out transaction);

                if (transaction.ReturnStatus)
                {
                    if (account_role.group_id == Properties.Settings.Default.DocAppGroup)
                    {
                        var status = HttpStatusCode.OK;
                        try
                        {
                            if (!String.IsNullOrEmpty(route))
                            {
                                switch (account_role.role)
                                {
                                    case "mm.docconect.doc.app.ac.doctor":
                                        if (route.Contains("planning"))
                                            status = HttpStatusCode.Forbidden;
                                        break;
                                    case "mm.docconect.doc.app.ac.practice":
                                        if (route.Contains("planning") || route.Contains("my_account") || route.Contains("receipt"))
                                            status = HttpStatusCode.Forbidden;
                                        break;
                                    case "mm.docconect.doc.app.op.practice":
                                        if (route.Contains("my_account") || route.Contains("receipt"))
                                            status = HttpStatusCode.Forbidden;

                                        transaction.IsOpRole = true;
                                        break;
                                    case "mm.docconect.doc.app.op.doctor":
                                        transaction.IsOpRole = true;
                                        break;
                                }

                                if (route.Contains("patient_detail"))
                                {
                                    var id = route.Split('/').Last();
                                    var patient_id = Guid.Empty;
                                    if (Guid.TryParse(id, out patient_id))
                                    {
                                        var patient_details_accessible = patientDataService.PatientDetailsAccessible(patient_id, connectionString, SessionToken, out transaction);
                                        transaction.IsOpRole = account_role.role.Contains("op");
                                        if (!patient_details_accessible)
                                        {
                                            status = HttpStatusCode.Forbidden;
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            status = HttpStatusCode.Unauthorized;
                            transaction.ReturnMessage.Add(ex.Message);
                            transaction.IsAuthenicated = false;
                        }

                        return Request.CreateResponse(status, transaction);
                    }

                    transaction.IsAuthenicated = false;
                    transaction.logoutUrl = GlobalProperties.LOGIN_PAGE;
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, transaction);
                }

                transaction.logoutUrl = GlobalProperties.LOGIN_PAGE;
                return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.Unauthorized, transaction);
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
            TransactionalInformation transaction = new TransactionalInformation();
            transaction.logoutUrl = GlobalProperties.LOGIN_PAGE;
            transaction.IsAuthenicated = false;
            var response = Request.CreateResponse<TransactionalInformation>(HttpStatusCode.OK, transaction);

            try
            {
                var sessionToken = SessionToken;
                if (SignalRNotifier.Instance.userSessionTokens.Any(t => t == sessionToken))
                {
                    SignalRNotifier.Instance.userSessionTokens.Remove(sessionToken);
                }

                var userInfo = mainDataservice.GetUserName(connectionString, SessionToken, Properties.Settings.Default.DocAppGroup, out transaction);
                if (transaction.ReturnStatus)
                {
                    SignalRNotifier.Instance.usersThatAreAlreadyReceievingNotifications.Remove(userInfo.AccountInformation.email);
                    ProviderFactory.Instance.CreateSessionServiceProvider().SignOut(sessionToken);

                    if (sessionToken != null)
                    {
                        SignalRNotifier.Instance.lastSentNotificationData.Remove(sessionToken);
                        CookieHeaderValue cookie = new CookieHeaderValue("bops", "st=" + sessionToken);
                        cookie.Expires = DateTime.Now.AddDays(-1d);
                        cookie.Domain = Request.RequestUri.Host;
                        cookie.Path = "/";
                        response.Headers.AddCookies(new CookieHeaderValue[] { cookie });
                    }
                }
            }
            catch
            {

            }

            return response;
        }

        [Route("GetDoctorsForDropdown")]
        [HttpGet]
        [AuthenticationFilter]
        public HttpResponseMessage GetDoctorsForDropdown()
        {
            var transaction = new TransactionalInformation();
            var data = mainDataservice.GetUserName(connectionString, SessionToken, Properties.Settings.Default.DocAppGroup, out transaction);
            var response = new PasswordVerificationDoctors();
            Guid id = Guid.Empty;

            var doctors = mainDataservice.GetDoctorsForDropdown(connectionString, data.PracticeID, response.is_practice, SessionToken, out transaction);

            if (transaction.ReturnStatus)
            {
                response.doctors = doctors;
                return Request.CreateResponse<PasswordVerificationDoctors>(HttpStatusCode.OK, response);
            }

            return Request.CreateResponse(HttpStatusCode.NotFound);
        }
        #endregion

        #region POST
        [Route("VerifyDoctorPassword")]
        [HttpPost]
        public HttpResponseMessage VerifyDoctorPassword(PasswordVerificationParameter parameter)
        {
            bool password_verified = false;
            var transaction = new TransactionalInformation();

            password_verified = mainDataservice.VerifyDoctorPassword(connectionString, parameter.password, parameter.doctor.id, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse<bool>(HttpStatusCode.OK, password_verified);

            return Request.CreateResponse(HttpStatusCode.Forbidden);
        }

        [Route("ChangeAccountPassword")]
        [HttpPost]
        public HttpResponseMessage ChangeAccountPassword(ChangePasswordModel pass)
        {
            var transaction = new TransactionalInformation();

            var passwordChanged = mainDataservice.ChangeAccountPassword(pass, connectionString, SessionToken, out transaction);
            var response = Request.CreateResponse<TransactionalInformation>(HttpStatusCode.OK, transaction);
            return response;
        }

        #endregion

        #region DELETE

        #endregion
    }
}
