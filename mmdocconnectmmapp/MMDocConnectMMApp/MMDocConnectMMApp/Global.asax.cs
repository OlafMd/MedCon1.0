using log4net;
using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace MMDocConnectMMApp
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown
        }


        protected void Session_Start(Object sender, EventArgs e)
        {

        }

        protected void Session_End(Object sender, EventArgs e)
        {
            //Singletons.Instance.MessageQueues.Remove(Session.SessionID);
            //  SessionApp.Instance.startTime = DateTime.MinValue;
        }

        protected void Application_PostAuthorizeRequest()
        {
            System.Web.HttpContext.Current.SetSessionStateBehavior(System.Web.SessionState.SessionStateBehavior.Required);
        }

        void Application_PostAcquireRequestState(object sender, EventArgs e)
        {
            var Cookie = Request.Cookies["LanguageInfo"];

            if (HttpContext.Current.Session != null)
            {
            }
        }

    }
}
