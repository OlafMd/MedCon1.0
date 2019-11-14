using System;
using System.Collections.Generic;
using System.Web.SessionState;
using System.Web;
using System.Web.Script.Serialization;
using BOp.Infrastructure.Authentication;
using Danulabs.Utils;

namespace DLAPODemandCommons.Controls.Classes
{
    public abstract class ArticleSearchAutocompleteAbstractHandler : IHttpHandler, IReadOnlySessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            string prefix = context.Request.QueryString["prefix"];
            context.Response.ContentType = "application/json";

            var articles = GetArticlesFromWebService(prefix);

            JavaScriptSerializer jss = new JavaScriptSerializer();
            string data = jss.Serialize(articles);
            context.Response.Write(data);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        protected String GetSessionToken()
        {
            SessionTokenInformation sessionTokenInfo = SessionGlobal.Instance.SessionTokenInfo;
            return sessionTokenInfo.Session.SessionToken;
        }

        protected abstract List<NameValue> GetArticlesFromWebService(String prefix);
    }


    public class NameValue
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}