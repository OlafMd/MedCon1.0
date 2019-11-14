using System;
using CSV2Core.SessionSecurity;
using BOp.Infrastructure.Authentication;

namespace DLCore_TokenVerification
{

    public class SessionTokenInformationUtil
    {
        public static readonly String SessionParamName = "SessionTokenInformation";

        public static String getSessionToken(SessionTokenInformation sessionTokenInfo)
        {
            if (sessionTokenInfo == null)
                throw new SessionTokenInfoException("SessionTokenInfo doesn't exist on Session!");

            return sessionTokenInfo.Session.SessionToken;
        }

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
