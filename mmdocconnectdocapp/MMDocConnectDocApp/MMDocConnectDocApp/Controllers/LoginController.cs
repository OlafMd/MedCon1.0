using BOp.Exceptions;
using BOp.Providers;
using BOp.Providers.RAA;
using BOp.Providers.TMS;
using BOp.Providers.TMS.Requests;
using BOp.Providers.TMS.Responses;
using LogUtils;
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
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Security;

namespace MMDocConnectDocApp.Controllers
{
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        private string AttemptLogin(LoginApiModel loginObject)
        {
            var sessionProvider = ProviderFactory.Instance.CreateSessionServiceProvider();
            var sessionValidityInSeconds = 43200;
            try
            {
                sessionValidityInSeconds = Int32.Parse(WebConfigurationManager.AppSettings["session-valididity-in-seconds"]);
            }
            catch { }

            return sessionProvider.SignIn(new SignInRequest()
            {
                Email = loginObject.username,
                Password = GenericUtils.CalculateMD5Hash(loginObject.password),
                SessionDetails = new SessionDetails()
                {
                    Timeout = sessionValidityInSeconds
                },
                UseDefaultTenant = true
            }).SessionToken;
        }

        [Route("LogIn")]
        [HttpPost]
        public HttpResponseMessage LogIn(LoginApiModel loginObject)
        {
            var transaction = new TransactionalInformation();
            transaction.redirectUrl = GlobalProperties.INDEX_PAGE;
            var response = Request.CreateResponse(HttpStatusCode.OK, transaction);
            try
            {
                if(String.IsNullOrEmpty(loginObject.password)){
                    transaction.IsException = true;
                    transaction.redirectUrl = GlobalProperties.LOGIN_PAGE;
                    transaction.ReturnMessage.Add("Missing password");
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, transaction);
                }

                var sessionToken = String.Empty;
                try
                {
                    sessionToken = AttemptLogin(loginObject);
                }
                catch
                {
                    loginObject.username = loginObject.username.ToLower();
                    sessionToken = AttemptLogin(loginObject);
                }

                transaction.IsAuthenicated = true;

                var cookieValue = String.Format("{1}={2}{0}{3}={4}", GlobalProperties.KEY_SEPARATOR, GlobalProperties.KEY_TOKEN, sessionToken, GlobalProperties.KEY_LANGUAGE, "de");
                CookieHeaderValue cookie = new CookieHeaderValue("bops", cookieValue);
                cookie.Expires = DateTime.MaxValue;
                cookie.Domain = Request.RequestUri.Host;
                cookie.Path = "/";

                response.Headers.AddCookies(new CookieHeaderValue[] { cookie });
            }
            catch (Exception ex)
            {
                var request = HttpContext.Current.Request;
                var method = MethodInfo.GetCurrentMethod();
                var ipInfo = Util.GetIPInfo(request);

                var sdkException = ex as SDKServiceException;
                var message = "Irgendwas ist schiefgegangen.";
                if (sdkException != null)
                {
                    if (sdkException.ServiceError.Code == 70204)
                    {
                        message = "Ihre Konto deaktiviert wurden.";
                    }
                    else if (sdkException.ServiceError.Code == 70202 || sdkException.ServiceError.Code == 70103)
                    {
                        message = "Falsche Anmeldungsdaten.";
                        Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, MethodBase.GetCurrentMethod(), loginObject), "DocAppLoginExceptions");
                    }
                    else
                    {
                        Logger.LogDocAppInfo(new LogEntry("code: " + sdkException.ServiceError.Code + "; message: " + sdkException.ServiceError.Message), "DocAppLoginExceptions");
                    }
                }
                else
                {
                    Logger.LogDocAppInfo(new LogEntry(ex.Message), "DocAppLoginExceptions");
                }

                transaction.IsException = true;
                transaction.redirectUrl = GlobalProperties.LOGIN_PAGE;
                transaction.ReturnMessage.Add(message);
                return Request.CreateResponse(HttpStatusCode.Unauthorized, transaction);
            }

            return response;
        }
    }
}
