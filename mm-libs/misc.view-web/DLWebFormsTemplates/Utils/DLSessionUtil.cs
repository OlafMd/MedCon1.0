using System;
using BOp.Infrastructure.Authentication;
using Danulabs.Utils;

namespace DLWebFormsTemplates.Utils
{
    class DLSessionUtil:IDLSessionUtil
    {
        public DLSessionUtil() { 
        
        }

        public String GetSessionToken()
        {
            SessionTokenInformation sessionTokenInfo = SessionGlobal.Instance.SessionTokenInfo;
            return sessionTokenInfo.Session.SessionToken;
        }

        public SessionTokenInformation GetSessionTicket()
        {
            SessionTokenInformation sessionTokenInfo = SessionGlobal.Instance.SessionTokenInfo;
            return sessionTokenInfo;
        }
    }
}
