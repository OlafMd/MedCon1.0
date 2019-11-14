using System.Collections.Generic;
using System.Web;
using DLCore_DBCommons.APODemand;



namespace DLAPODemandCommons.Session
{
    public class SessionAPODemand
    {
        // private constructor
        private SessionAPODemand()
        {

        }

        // Gets the current session.
        public static SessionAPODemand Instance
        {
            get
            {
                SessionAPODemand session = (SessionAPODemand)HttpContext.Current.Session["SessionAPODemand"];
                if (session == null)
                {
                    session = new SessionAPODemand();
                    HttpContext.Current.Session["SessionAPODemand"] = session;
                }

                return session;
            }
        }

        public List<EAccountFunctionLevelRight> AccountFunctionLevelRights { get; set; }
    }
}

    