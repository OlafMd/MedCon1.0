using BOp.Config;
using BOp.Providers.TMS;
using BOp.RAA.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BOp.Providers.RAA
{
    public class BOpCookieUtility
    {
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
                string bopSession = request[GetCookieName()];

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
