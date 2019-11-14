using System;
using BOp.Infrastructure.Authentication;
using CSV2Core.SessionSecurity;

namespace Core_ClassLibrarySupport.CoreAPISupport
{
    public class SessionTokenInformationUtil
    {
        public static readonly String SessionParamName = "SessionTokenInformation";

        [Obsolete("SessionTokenInformationUtil is deprecated, please use DLWebFormsTemplates (\"C:\\SourceCode\\libs\\misc.view-web\\DLWebFormsTemplates\") ")]
        public static String getSessionToken(SessionTokenInformation sessionTokenInfo)
        {
            if (sessionTokenInfo == null)
                throw new SessionTokenInfoException("SessionTokenInfo doesn't exist on Session!");

            return sessionTokenInfo.Session.SessionToken;
        }

        [Obsolete("SessionTokenInformationUtil is deprecated, please use DLWebFormsTemplates (\"C:\\SourceCode\\libs\\misc.view-web\\DLWebFormsTemplates\") ")]
        public static SessionSecurityTicket getSessionSecurityTicket(SessionTokenInformation sessionTokenInfo)
        {
            if (sessionTokenInfo == null)
                throw new SessionTokenInfoException("SessionTokenInfo doesn't exist on Session!");

            SessionSecurityTicket ticket = new SessionSecurityTicket();
            ticket.AccountID = sessionTokenInfo.Account.AccountID;
            ticket.TenantID = sessionTokenInfo.Account.TenantID;
            ticket.SessionTicket = sessionTokenInfo.Session.SessionToken;

            return ticket;
        }

    }

    class SessionTokenInfoException : Exception
    {
        public SessionTokenInfoException(string message)
            : base(message)
        {

        }
    }

    public class CASMobileResponse { 
    
        public CASResponseCode Status {get; set;}
        public SessionSecurityTicket SecurityTicket { get; set; }
        public AccountCompaniesResult Companies { get; set; }
    
    }
}
