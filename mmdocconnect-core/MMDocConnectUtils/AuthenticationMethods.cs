using BOp.Config;
using BOp.Providers;
using BOp.Providers.RAA;
using BOp.Providers.TMS;
using BOp.RAA.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectUtils
{
    public class AuthenticationMethods
    {
        public static string GetLastURL(string lastAbsolutUri)
        {
            var absoluteURL = lastAbsolutUri.Split('?');
            string url = "";
            if (absoluteURL.Count() > 2)
            {
                url = absoluteURL[0];
                for (int i = 1; i < absoluteURL.Count() - 1; i++)
                    url += "?" + absoluteURL[i];
            }
            else
                url = absoluteURL[0];

            return url;
        }

        private static string _cookieName;

        public static string GetCookieName()
        {
            if (_cookieName == null)
            {
                _cookieName = new BOpConfiguration().BOpCookieName;
            }
            return _cookieName;
        }

        public static bool IsCookiePresent(System.Web.HttpRequest request)
        {
            return IsCookiePresent(request, GetCookieName());
        }

        private static bool IsCookiePresent(System.Web.HttpRequest request, string cookieName)
        {
            return request.Cookies.AllKeys.Contains(cookieName);
        }

        public static CookieInfo GetCookieData(System.Web.HttpRequest request, bool checkURL = false)
        {
            CookieInfo result = null;
            if (checkURL == true)
            {
                string bopSession = null;

                if (request.UrlReferrer.AbsoluteUri.Contains("="))
                    bopSession = request.UrlReferrer.AbsoluteUri.Substring(request.UrlReferrer.AbsoluteUri.IndexOf('=') + 1);
                //string bopSession = request[GetCookieName()];

                if (bopSession != null)
                {
                    result = GetCookieData(bopSession);
                }
                else
                {
                    result = null;
                }
            }
            else
            {
                Boolean isCookiePresent = IsCookiePresent(request, GetCookieName());
                if (isCookiePresent == true)
                {
                    var cookie = request.Cookies.Get(GetCookieName());
                    result = GetCookieData(cookie);
                }
                else
                {
                    result = null;
                }
            }
            return result;
        }

        public static CookieInfo GetCookieData(System.Web.HttpCookie cookie)
        {
            if (cookie == null)
            {
                return null;
            }
            else
            {
                return GetCookieData(cookie.Value);
            }
        }

        public static CookieInfo GetCookieData(string data)
        {
            string decodedData = System.Web.HttpUtility.UrlDecode(data);
            return new CookieInfo(decodedData);
        }

        public static Session GetSessionData(System.Web.HttpRequest request, bool checkURL = false)
        {
            var cookieInfo = GetCookieData(request, checkURL);
            return GetSessionData(cookieInfo);
        }

        public static Session GetSessionData(CookieInfo cookieInfo)
        {
            if (cookieInfo != null)
            {
                return GetSessionData(cookieInfo.SessionToken);
            }
            else
            {
                return null;
            }
        }

        public static Session GetSessionData(string sessionToken)
        {
            ProviderFactory _providerFactory = ProviderFactory.Instance;
            var service = _providerFactory.CreateSessionServiceProvider();

            return service.GetSessionInformation(sessionToken);
        }

        public static string RemoveSessionTicketParameterFromURL(string url)
        {
            Uri uri = new Uri(url);
            return uri.RemoveQueryParameter(GetCookieName()).ToString();
        }
    }
}
