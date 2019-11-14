using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MMDocConnectUtils
{
    public static class GlobalProperties
    {
        public static string LOGIN_PAGE = HttpContext.Current.Request.Url.OriginalString.Split(new string[] { "api" }, StringSplitOptions.None).First() + "login.html";
        public static string INDEX_PAGE = "index.html";
        public static int SESSION_VALIDITY = 12;
        public static char KEY_SEPARATOR = '#';
        public static string KEY_TOKEN = "st";
        public static string KEY_LANGUAGE = "ln";
    }
}
