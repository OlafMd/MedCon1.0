using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BOp.Providers.RAA
{
    public class RedirectionUrlUtility
    {
        private static string PAGE_SIGN_IN = "/sign-in";
        private static string PAGE_SIGN_OUT = "/sign-out";
        private static string PAGE_SWITCH_COMPANY = "/switch-company";
        
        private RedirectionUrlUtility() { }
        public static string CreateSignInURL()
        {
            return CreateSignInURL(null);
        }
        public static string CreateSignInURL(string continueToPage, bool urlSession = false)
        {
            return CreateSignInURL(continueToPage, 0, null, urlSession);
        }
        public static string CreateSignInURL(string continueToPage, int sessionLifetime, string languageISO = "EN", bool urlSession = false)
        {
            languageISO = (languageISO == null ? "en" : languageISO.ToLower());

            Uri uri = CreateURLOnAuthRootWithPath(PAGE_SIGN_IN);

            if (string.IsNullOrWhiteSpace(continueToPage) == false) uri = uri.AddQueryParameter("continueTo", System.Web.HttpUtility.UrlEncode(continueToPage));
            if (urlSession == true) uri = uri.AddQueryParameter("urlSession", "true");
            if (sessionLifetime > 0) uri = uri.AddQueryParameter("sessionTimeout", sessionLifetime.ToString());
            if (languageISO != "en") uri = uri.AddQueryParameter("language", languageISO);
            return uri.ToString();
        }
        public static string CreateSignoutURL()
        {
            return CreateSignoutURL(null);
        }
        public static string CreateSignoutURL(string continueToPage)
        {
            Uri uri = CreateURLOnAuthRootWithPath(PAGE_SIGN_OUT);
            if (string.IsNullOrWhiteSpace(continueToPage) == false) uri = uri.AddQueryParameter("continueTo", System.Web.HttpUtility.UrlEncode(continueToPage));
            return uri.ToString();
        }

        public static string CreateSwitchCompanyURL(string continueToPage, string hashedComapnyID, bool urlSession = false)
        {
            Uri uri = CreateURLOnAuthRootWithPath(PAGE_SWITCH_COMPANY);
            if (urlSession == true) uri = uri.AddQueryParameter("urlSession", "true");
            if (string.IsNullOrWhiteSpace(continueToPage) == false) uri = uri.AddQueryParameter("continueTo", System.Web.HttpUtility.UrlEncode(continueToPage));
            if (string.IsNullOrWhiteSpace(hashedComapnyID) == false) uri = uri.AddQueryParameter("company", System.Web.HttpUtility.UrlEncode(hashedComapnyID));
            return uri.ToString();
        }


        private static Uri CreateURLOnAuthRootWithPath(string path)
        {
            var configurationService = new BOp.Config.BOpConfiguration();
            Configuration config = configurationService.GetProviderConfiguration(ProviderType.RealmApplicationAccess);
            var raaRootURL = config.BaseUrl.ToString();
            Uri domain = new Uri(AppendProtocolIfRequired(raaRootURL));
            UriBuilder uriBuilder = new UriBuilder(domain.Scheme, domain.Host, domain.Port, domain.AbsolutePath.TrimEnd('/') + path);
            return uriBuilder.Uri;
        }
        private static string AppendProtocolIfRequired(string urlString)
        {
            if (urlString.StartsWith("http://") || urlString.StartsWith("https://"))
            {
                return urlString;
            }
            else
            {
                return String.Format("http://{0}", urlString);
            }
        }
    }


    public static class HttpExtensions
    {
        public static Uri AddQueryParameter(this Uri uri, string name, string value)
        {
            var ub = new UriBuilder(uri);
            var queryString = System.Web.HttpUtility.ParseQueryString(uri.Query);

            queryString.Add(name, value);

            ub.Query = queryString.ToString();

            return ub.Uri;
        }

        public static Uri RemoveQueryParameter(this Uri uri, string name)
        {
            var ub = new UriBuilder(uri);
            var queryString = System.Web.HttpUtility.ParseQueryString(uri.Query);

            queryString.Remove(name);

            ub.Query = queryString.ToString();

            return ub.Uri;
        }
    }
}
