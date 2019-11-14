using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOp.Infrastructure.Authentication;

namespace DLMVCTemplates.Utils
{
    class DLSessionUtil : IDLSessionUtil
    {
        public DLSessionUtil()
        {

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
