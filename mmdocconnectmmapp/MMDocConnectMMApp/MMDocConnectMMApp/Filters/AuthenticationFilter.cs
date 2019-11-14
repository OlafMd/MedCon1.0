using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Reflection;
using System.Net.Http;
using System.Web.Http.Filters;
using System.Web.Http.Controllers;
using System.Net;
using MMDocConnectUtils;
using BOp.Providers.RAA;
using log4net;
using BOp.Providers;
using LogUtils;
using MMDocConnectMMApp.Controllers;
using BOp.Providers.TMS;
using MMDocConnectMMApp.Models;
using System.Net.Http.Headers;

namespace MMDocConnectMMApp.Filters
{
    public class AuthenticationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            int timeout = Properties.Settings.Default.CASSession_Timeout;
            var transactionInformation = new TransactionalInformation();
            var httpRequest = HttpContext.Current.Request;
            var sessionProvider = ProviderFactory.Instance.CreateSessionServiceProvider();

            var request = actionContext.Request;

            try
            {
                var cookieData = BOpCookieUtility.GetCookieData(HttpContext.Current.Request);
                var sessionValid = sessionProvider.CheckIfSessionIsValid(cookieData.SessionToken);
                if (!sessionValid) {
                    throw new UnauthorizedAccessException("Session not valid!");
                }
            }
            catch (Exception ex)
            {
                transactionInformation.ReturnMessage.Add(ex.Message);
                transactionInformation.ReturnStatus = false;
                transactionInformation.IsException = true;
                transactionInformation.IsAuthenicated = false;
                transactionInformation.logoutUrl = GlobalProperties.LOGIN_PAGE;
                actionContext.Response = request.CreateResponse<TransactionalInformation>(HttpStatusCode.Unauthorized, transactionInformation);

                CookieHeaderValue cookie = new CookieHeaderValue("bops", "st=0");
                cookie.Expires = DateTime.Now.AddDays(-7d);
                cookie.Domain = actionContext.Request.RequestUri.Host;
                cookie.Path = "/";

                actionContext.Response.Headers.AddCookies(new CookieHeaderValue[] { cookie });
            }
        }
    }
}