using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BOp.Infrastructure;
using BOp.Infrastructure.Authentication;
using DLMVCTemplates.Utils;
namespace DLMVCTemplates.Templates
{
    public abstract class DLAuthenticationTemplate : ActionFilterAttribute
    {
        #region Properties
        public string LoginURL
        {
            get { return SessionGlobal.Instance.LoginURL as string; }
            set { SessionGlobal.Instance.LoginURL = value; }
        }

        private DLSessionUtil sessionUtil;
        #endregion

        public DLAuthenticationTemplate()
        {

            sessionUtil = new DLSessionUtil();
        }

        #region Session

        public String GetSessionToken()
        {
            return sessionUtil.GetSessionToken();
        }

        #endregion


        #region Authentication
        public SessionTokenInformation Authentication(bool urlSessionEnabled, int timeout)
        {
            SessionTokenInformation retVal = null;
            var bopSession = InfrastructureFactory.CreateSessionManager();
            var session = SessionGlobal.Instance.SessionTokenInfo;
            var lastUrl = GetLastURL(HttpContext.Current.Request.Url.AbsoluteUri);
            string redirect = bopSession.CreateSignInURL(lastUrl, timeout, "EN", urlSessionEnabled);

            if (session != null && session.Session != null && session.Session.SessionToken != null)
            {
                var status = VerifyToken();

                if (status != CASResponseCode.OK)
                {
                    //check if there is new token value in cookie
                    SessionTokenInformation sessionDataResp = bopSession.GetSessionData(HttpContext.Current.Request, urlSessionEnabled);

                    if (sessionDataResp != null && sessionDataResp.Session != null && sessionDataResp.Session.SessionToken != null)
                    {
                        //If session token and token from cookie are different check if one from cookie is valid
                        if (sessionDataResp.Session.SessionToken.Equals(session.Session.SessionToken) == false)
                        {
                            var status2 = VerifyToken(sessionDataResp.Session.SessionToken);
                            if (status2 == CASResponseCode.OK)
                            {
                                retVal = sessionDataResp;
                                SessionGlobal.Instance.SessionTokenInfo = sessionDataResp;

                                var service = BOp.Infrastructure.InfrastructureFactory.CreateAuthenticationService();
                                BOp.Infrastructure.Authentication.AccountCompaniesResult res = service.GetAccountCompanies(SessionGlobal.Instance.SessionTokenInfo.Session.SessionToken);

                                SessionGlobal.Instance.Companies = res.Companies;
                            }
                        }
                    }
                    else
                    {
                        FormsAuthentication.SignOut();
                        HttpContext.Current.Session.Clear();
                        HttpContext.Current.Session.Abandon();
                        string redirectURL = bopSession.CreateSignInURL(HttpContext.Current.Request.Url.ToString(), timeout, "EN", urlSessionEnabled);
                        HttpContext.Current.Response.Redirect(redirectURL, false);
                    }
                }
                else
                {
                    if (LoginURL == null)
                        LoginURL = redirect;

                    if (!CheckSubscription())
                    {
                        string redirectURL = bopSession.CreateSignInURL(HttpContext.Current.Request.Url.ToString(), timeout, "EN", urlSessionEnabled);
                        HttpContext.Current.Response.Redirect(redirectURL, true);
                    }
                }
            }
            else
            {
                SessionTokenInformation sessionDataResp = bopSession.GetSessionData(HttpContext.Current.Request, urlSessionEnabled);
              
                if (sessionDataResp.Status == CASResponseCode.OK)
                {
                    FormsAuthentication.SignOut();
                    SessionGlobal.Instance.SessionTokenInfo = sessionDataResp;

                    var service = BOp.Infrastructure.InfrastructureFactory.CreateAuthenticationService();
                    BOp.Infrastructure.Authentication.AccountCompaniesResult res = service.GetAccountCompanies(SessionGlobal.Instance.SessionTokenInfo.Session.SessionToken);

                    SessionGlobal.Instance.Companies = res.Companies;
                    if (LoginURL == null)
                        LoginURL = redirect;

                    if (!CheckSubscription())
                    {
                        string redirectURL = bopSession.CreateSignInURL(HttpContext.Current.Request.Url.ToString(), timeout, "EN", urlSessionEnabled);
                        return sessionDataResp;// HttpContext.Current.Response.Redirect(redirectURL, true);
                    }
                }
                else
                {

                    string redirectURL = bopSession.CreateSignInURL(HttpContext.Current.Request.Url.ToString(), timeout, "EN", urlSessionEnabled);
                    //HttpContext.Current.Response.Redirect(redirectURL, true);
                    //save login URL into session
                    if (LoginURL == null)
                        LoginURL = redirect;

                    var fullURL = VirtualPathUtility.ToAbsolute("~/UserManagement/LogOutOnExpiredSession?url=");
                    string urlLocal = fullURL + HttpContext.Current.Request.Url.ToString() + "&urlSessionEnabled=" + urlSessionEnabled;
                    HttpContext.Current.Response.Redirect(redirectURL, true);
                }
            }


            return retVal;

        }

        public bool CheckSubscription()
        {
            bool retVal = true;

            if (!HasUserSubscriptionForApplication())
            {
                //save loginUrl
                string loginUrl = LoginURL;
                //clear user data (user doesn't have subscription)
                FormsAuthentication.SignOut();
                HttpContext.Current.Session.Clear();
                HttpContext.Current.Session.Abandon();
                //keep login URL in session
                LoginURL = loginUrl;
                HttpContext.Current.Response.Redirect(loginUrl, true);
                retVal = false;
            }
            else
            {
                //user is loggedin- remove login url.
                LoginURL = null;
            }

            return retVal;
        }

        public string GetLastURL(string lastAbsolutUri)
        {

            var absoluteURL = lastAbsolutUri.Split('?');
            string url = "";
            if (absoluteURL.Count() > 2)
            {
                url = absoluteURL[0];
                for (int i = 1; i < absoluteURL.Count() - 1; i++)
                {
                    url += "?" + absoluteURL[i];

                }
            }
            else
            {
                url = absoluteURL[0];
            }

            return url;
        }
        abstract public CASResponseCode VerifyToken(String SessionToken = "");

        abstract public bool HasUserSubscriptionForApplication();
        #endregion




    }
}
