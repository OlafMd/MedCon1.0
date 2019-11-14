using System;
using System.Web.UI;
using System.Web;
using BOp.Infrastructure;
using System.Web.Security;
using System.IO;

namespace DLWebFormsTemplates.Templates
{
    public abstract class DLLogoutTemplate: Page
    {
                /// <summary>
        /// Method for logging out
        /// Removes the cookie from the session
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.Abandon();

            var bopSession = InfrastructureFactory.CreateSessionManager();
            var singInURL = bopSession.CreateSignInURL(FilterPreviousUrl(), CASSession_Timeout());

            String urlSession = String.Empty;
#if DEBUG
            urlSession = "&urlSession=true";
#endif

            string logoutUrL = bopSession.CreateSignoutURL(singInURL + urlSession);
            Response.Redirect(logoutUrL, false);
        }

        private string FilterPreviousUrl()
        {
            try
            {
                string urlRefererPath = Request.UrlReferrer.AbsoluteUri;

                if (urlRefererPath.Contains("403.aspx") || urlRefererPath.Contains("ErrorPage.aspx"))
                {
                    return HttpContext.Current.Request.Url.AbsoluteUri.Split(new string[] { "Logout" }, StringSplitOptions.None)[0] + "Pages";
                }
                else if (Request.Url.Query != String.Empty)
                {
                    return Server.UrlDecode(Request.Url.Query.Split('=')[1]);
                }
                else
                {
                    return urlRefererPath.Split('?')[0];
                }
            }
            catch
            {
                return GetDefaultPage();
            }
        }

        private string GetDefaultPage() 
        {
            var currentUrl = HttpContext.Current.Request.Url.AbsoluteUri;
            var loguoutPageName = Path.GetFileName(Request.Path);

            return currentUrl.Split(new string[] { loguoutPageName }, StringSplitOptions.None)[0];
        }

        protected abstract int CASSession_Timeout();
    }
}

