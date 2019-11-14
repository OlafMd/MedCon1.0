using System;
using System.Collections.Generic;
using System.Web;
using BOp.Infrastructure.Authentication;

namespace DLMVCTemplates
{
    
        public class SessionGlobal
        {

            private static string sessionKey = "SessionGlobal";


            // private constructor
            private SessionGlobal()
            {
            }

            // Gets the current session.
            public static SessionGlobal Instance
            {
                get
                {
                    SessionGlobal session = (SessionGlobal)HttpContext.Current.Session[sessionKey];
                    if (session == null)
                    {
                        session = new SessionGlobal();
                        HttpContext.Current.Session[sessionKey] = session;
                    }

                    return session;
                }

            }

            public String GetSessionKey()
            {
                return sessionKey;
            }

            public Guid LanguageID { get; set; }
            public Guid CurrencyID { get; set; }
            public String CurrencyName { get; set; }
            public string LoginURL { get; set; }
            public String LanguageCode { get; set; }
            public String DateTimeFormat { get; set; }
            public String DateFormat { get; set; }
            public AccountInfo Account { get; set; }
            public List<Company> Companies { get; set; }
            public SessionTokenInformation SessionTokenInfo { get; set; }
        }

        public class AccountInfo
        {

            public Guid AccountID { get; set; }
            public String Username { get; set; }
            public String AccountSignInEmailAddress { get; set; }
            public String FirstName { get; set; }
            public String LastName { get; set; }
            public Guid LanguageID { get; set; }
            public String AvatarURL { get; set; }
            public bool IsCompany { get; set; }
            public String SessionToken { get; set; }

        }

    
}
