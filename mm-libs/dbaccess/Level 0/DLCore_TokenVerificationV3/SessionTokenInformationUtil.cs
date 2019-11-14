using System;
using CSV2Core.SessionSecurity;
using BOp.Providers.TMS;
using BOp.Providers.TMS.Requests;

namespace DLCore_TokenVerification
{

    public class SessionTokenInformationUtil
    {
        public static readonly String SessionParamName = "SessionTokenInformation";

        public static String getSessionToken(Session session)
        {
            if (session == null)
                throw new SessionTokenInfoException("SessionTokenInfo doesn't exist on Session!");

            return session.SessionToken;
        }

        public static SessionSecurityTicket getSessionSecurityTicket(Session session)
        {
            if (session == null)
                throw new SessionTokenInfoException("SessionTokenInfo doesn't exist on Session!");

            SessionSecurityTicket ticket = new SessionSecurityTicket();
            ticket.AccountID = session.AccountID;
            ticket.TenantID = session.TenantID;
            ticket.SessionTicket = session.SessionToken;

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
    
        public bool Status {get; set;}
        public SessionSecurityTicket SecurityTicket { get; set; }
        public Tenant Company { get; set; }
    
    }
}
