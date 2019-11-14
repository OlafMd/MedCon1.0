using BOp.Providers.RAA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace MMDocConnectDocApp.Controllers
{
    public class BaseApiController : ApiController
    {
        public string SessionToken
        {
            get
            {
                return BOpCookieUtility.GetSessionData(HttpContext.Current.Request).SessionToken;
            }
        }
    }
}
