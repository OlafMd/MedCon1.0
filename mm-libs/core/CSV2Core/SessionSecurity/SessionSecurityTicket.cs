using System;

namespace CSV2Core.SessionSecurity
{
    public class SessionSecurityTicket
    {
        public static readonly string TICKET_COOKIE_NAME = "dlcas_st";
        public static readonly string TICKET_URL_PARAMETER = "sessionTicket";
        public static readonly int VERIFICATION_RECHECK_TIME = 60; // In seconds
       

        public SessionSecurityTicket()
        {
            VerificationRecheckTime = DateTime.Now;
        }


        private DateTime VerificationRecheckTime { get; set; }
        public String SessionTicket { get; set; }
        public Guid TenantID { get; set; }
        public Guid AccountID { get; set; }

        public bool HasVerificationExpired()
        {
            return false;
            //return DateTime.Now.CompareTo(VerificationRecheckTime) < 0;
        }

        public void UpdateVerificationRecheckTime()
        {
            VerificationRecheckTime.AddSeconds(VERIFICATION_RECHECK_TIME);
        }
    }
}
