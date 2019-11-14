using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DLWebFormsTemplates;
using DLCore_DBCommons.APODemand;
using DLAPODemandCommons.Session;
using DLCore_DBCommons.Utils;
using System.Web.Security;
using BOp.Infrastructure.Authentication;

namespace DLAPODemandCommons.Templates
{
    public abstract class APOMasterPageTemplate : DLMasterPageTemplate
    {
        private static List<EAccountFunctionLevelRight> AccountFunctionLevelRights
        {
            get { return SessionAPODemand.Instance.AccountFunctionLevelRights; }
        }

        #region PageAuthorization
       
        /// <summary>
        /// Method check can the requested page be displayed to user.
        /// If user doesn't have rights to see the requested page it redirects to page 403.
        /// </summary>
        public static void CheckPriviligesForThisPage(EAccountFunctionLevelRight currentLevelRights)
        {
            try
            {
                CheckByLevelRight(currentLevelRights);
            }
            catch (Exception)
            {
                RedirectToDontHaveAccess();
            }
        }

        /// <summary>
        ///  Method check does current account have access to requested page.
        /// </summary>
        private static void CheckByLevelRight(EAccountFunctionLevelRight currentLevelRights)
        {
            // Check does user have access to pages
            if (!AccountFunctionLevelRights.Contains(currentLevelRights))
            {
                // Throw exception is user doesn't have rights to access.
                throw new NotImplementedException();
            }
        }
 
        /// <summary>
        /// Redirection to page 403.
        /// </summary>
        private static void RedirectToDontHaveAccess()
        {
            if (!HttpContext.Current.Response.IsRequestBeingRedirected)
                HttpContext.Current.Response.Redirect("~/403.aspx", true);
        }

        public void DoAuth(bool urlSessionEnabled, int timeout)
        {
            Authentication(urlSessionEnabled, timeout);

            FormsAuthenticationCases();
        }

        public void FormsAuthenticationCases()
        {
            var tokenVerification = VerifyToken();
            if (!HttpContext.Current.User.Identity.IsAuthenticated
                && tokenVerification == CASResponseCode.OK)
            {
                // User authentication
                FormsAuthentication.RedirectFromLoginPage(string.Empty, true);
            }

            // if Authentication method for CAS working, this branching will never happen 
            else if (HttpContext.Current.User.Identity.IsAuthenticated
                    && tokenVerification != CASResponseCode.OK)
            {
                FormsAuthentication.SignOut();
                Session.Clear();
                Session.Abandon();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        public void SetRoles()
        {
            String[] rights = GetFunctionalLevelRightForAccount();

            // Set default level
            SessionAPODemand.Instance.AccountFunctionLevelRights = new List<EAccountFunctionLevelRight>();

            // Find level from database value
            var possibleRights = Enum.GetValues(typeof(EAccountFunctionLevelRight));
            foreach (EAccountFunctionLevelRight possibleRight in possibleRights)
            {
                var right = rights.SingleOrDefault(x => x == EnumUtils.GetEnumDescription(possibleRight));
                if (right != null)
                {
                    SessionAPODemand.Instance.AccountFunctionLevelRights.Add(possibleRight);
                }
            }
        }

        abstract public String[] GetFunctionalLevelRightForAccount();
        
        #endregion

    }

}
