using BOp.Exceptions;
using BOp.Providers;
using BOp.Providers.TMS.Requests;
using LogUtils;
using MMDocConnectMMApp.Filters;
using MMDocConnectMMApp.Models;
using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using BOp.Utility;
using System.Security.Cryptography;
using System.Text;
using System.Reflection;

namespace MMDocConnectMMApp.Controllers
{
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        [Route("LogIn")]
        [HttpPost]
        public HttpResponseMessage LogIn(LoginApiModel loginObject)
        {
            var sessionProvider = ProviderFactory.Instance.CreateSessionServiceProvider();
            var transaction = new TransactionalInformation();
            transaction.redirectUrl = GlobalProperties.INDEX_PAGE;
            transaction.IsAuthenicated = true;
            var response = Request.CreateResponse(HttpStatusCode.OK, transaction);
            try
            {
                if (String.IsNullOrEmpty(loginObject.password))
                {
                    transaction.IsException = true;
                    transaction.redirectUrl = GlobalProperties.LOGIN_PAGE;
                    transaction.ReturnMessage.Add("Missing password");
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, transaction);
                }

                var sessionToken = sessionProvider.SignIn(new SignInRequest()
                {
                    Email = loginObject.username,
                    Password = CalculateMD5Hash(loginObject.password),
                    SessionDetails = new SessionDetails()
                    {
                        Timeout = GlobalProperties.SESSION_VALIDITY * 3600
                    },
                    UseDefaultTenant = true
                }).SessionToken;

                var cookieValue = String.Format("{1}={2}{0}{3}={4}", GlobalProperties.KEY_SEPARATOR, GlobalProperties.KEY_TOKEN, sessionToken, GlobalProperties.KEY_LANGUAGE, "de");
                CookieHeaderValue cookie = new CookieHeaderValue("bops", cookieValue);
                cookie.Expires = DateTime.MaxValue;
                cookie.Domain = Request.RequestUri.Host;
                cookie.Path = "/";

                response.Headers.AddCookies(new CookieHeaderValue[] { cookie });
            }
            catch (Exception ex)
            {
                var sdkException = ex as SDKServiceException;
                var message = "Irgendwas ist schiefgegangen.";
                if (sdkException != null)
                {
                    // Wenn Server nicht erreichbar, dann Fehler bei Zugriff auf Object "sdkException.ServiceError", da sdkException.ServiceError == null
                    if (sdkException.ServiceError.Code == 70204)
                    {
                        message = "Ihre Konto deaktiviert wurden.";     // Bruder, ich nicht verstehen, bitte erklären das!
                    }
                    else if (sdkException.ServiceError.Code == 70202 || sdkException.ServiceError.Code == 70103)
                    {
                        message = "Falsche Anmeldungsdaten.";
                    }
                    else
                    {
                        Logger.LogInfo(new LogEntry("code: " + sdkException.ServiceError.Code + "; message: " + sdkException.ServiceError.Message));
                        Logger.LogInfo(new LogEntry("stack trace: " + sdkException.StackTrace));
                    }
                }
                else
                {
                    Logger.LogInfo(new LogEntry(ex.Message));
                }

                transaction.IsException = true;
                transaction.redirectUrl = GlobalProperties.LOGIN_PAGE;
                transaction.ReturnMessage.Add(message);
                return Request.CreateResponse(HttpStatusCode.Unauthorized, transaction);
            }

            return response;
        }


        private static string CalculateMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }
}