using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using CSV2Core_MySQL.Dictionaries.MultiTable;
using System.Web.UI.WebControls;
using BOp.Infrastructure.Authentication;
using DLWebFormsTemplates.Utils;
using System.Web.UI;
using BOp.Infrastructure;
using Danulabs.Utils;
using System.Web.Security;
using System.Web;
using System.Text.RegularExpressions;
using DLCore_DBCommons.DanuTask;
using DLCore_DBCommons.Utils;
namespace DLWebFormsTemplates
{
    public abstract class DLMasterPageTemplate : System.Web.UI.MasterPage, IDLDateTimeUtil, IDLDictUtil, IDLListItemsUtil, IDLPrimaryTypesUtil, IDLSessionUtil, IDLCssUtil, IDLControlUtil
    {

        private DLDictUtil dictUtil;
        private DLDateTimeUtil dateTimeUtil;
        private DLPrimaryTypesUtil primaryTypesUtil;
        private DLSessionUtil sessionUtil;
        private DLListItemsUtil listItemsUtil;
        private DLCssUtil cssUtil;
        private DLControlUtil controlUtil;

        public DLMasterPageTemplate()
        {
            dictUtil = new DLDictUtil();
            dateTimeUtil = new DLDateTimeUtil();
            primaryTypesUtil = new DLPrimaryTypesUtil();
            sessionUtil = new DLSessionUtil();
            listItemsUtil = new DLListItemsUtil();
            cssUtil = new DLCssUtil();
            controlUtil = new DLControlUtil();
        }

        #region Dict Manipulation

        public String GetCurrentLanguageContent(Dict dict)
        {
            return dictUtil.GetCurrentLanguageContent(dict);
        }

        public String GetCurrentLanguageContent(object dict)
        {
            return dictUtil.GetCurrentLanguageContent(dict);
        }

        #endregion

        #region DateTime Manipulation

        public String GetFormatedDateString(DateTime date)
        {
            return dateTimeUtil.GetFormatedDateString(date);
        }

        public String GetFormatedDateString(object date)
        {
            return dateTimeUtil.GetFormatedDateString(date);
        }

        public String GetFormatedDateStringOrDefault(DateTime date, String defaultString = "")
        {
            return dateTimeUtil.GetFormatedDateStringOrDefault(date, defaultString);
        }

        public String GetFormatedDateStringOrEmpty(object date)
        {
            return dateTimeUtil.GetFormatedDateStringOrEmpty(date);
        }

        public DateTime GetDateTimeFromString(String dateString)
        {
            return dateTimeUtil.GetDateTimeFromString(dateString);
        }

        public DateTime GetDateTimeFromStringOrDefault(String dateString)
        {
            return dateTimeUtil.GetDateTimeFromStringOrDefault(dateString);

        }

        public String GetTimeString(DateTime date)
        {
            return dateTimeUtil.GetTimeString(date);
        }

        public String GetTwoDigitsPriceString(object data, String format = "0.00")
        {
            return primaryTypesUtil.GetTwoDigitsPriceString(data, format);
        }

        #endregion

        #region Priamry Types

        public double GetDoubleFromString(String doubleString)
        {
            return primaryTypesUtil.GetDoubleFromString(doubleString);
        }

        public double GetDoubleFromStringOrDefault(String doubleString)
        {
            return primaryTypesUtil.GetDoubleFromStringOrDefault(doubleString);
        }

        #endregion

        #region Session

        public String GetSessionToken()
        {
            return sessionUtil.GetSessionToken();
        }

        #endregion

        #region GridView Manipulation

        public String CreateSortString(String SortExpression, SortDirection sortDireciton)
        {
            return listItemsUtil.CreateSortString(SortExpression, sortDireciton);
        }

        public int[] GetPageNumbers(GridView grid)
        {
            return listItemsUtil.GetPageNumbers(grid);
        }

        public String GetPageButtonClass(GridView grid, int pageIndex)
        {
            return listItemsUtil.GetPageButtonClass(grid, pageIndex);
        }

        public bool IsFristPageVisible(GridView grid)
        {
            return listItemsUtil.IsFristPageVisible(grid);
        }

        public bool IsLastPageVisible(GridView grid)
        {
            return listItemsUtil.IsLastPageVisible(grid);
        }

        #endregion

        #region Css

        public void ToggleCssClass(WebControl Control, string ClassName)
        {
            cssUtil.ToggleCssClass(Control, ClassName);
        }

        public void RemoveCssClass(WebControl Control, string ClassName)
        {
            cssUtil.RemoveCssClass(Control, ClassName);
        }

        public bool HasCssClass(WebControl Control, string ClassName)
        {
            return cssUtil.HasCssClass(Control, ClassName);
        }

        public void SetCssClass(WebControl Control, string ClassName, bool Direction = true)
        {
            cssUtil.SetCssClass(Control, ClassName);
        }

        public bool isControlContainsCssClass(WebControl Control, string ClassName)
        {
            return cssUtil.isControlContainsCssClass(Control, ClassName);
        }

        public void SetExactCssClass(WebControl Control, string ClassName)
        {
            cssUtil.SetExactCssClass(Control, ClassName);
        }

        public void ToggleIDOnSession(Guid DataID)
        {
            cssUtil.ToggleIDOnSession(DataID);
        }

        public bool IsIDOnSession(Guid DataID)
        {
            return cssUtil.IsIDOnSession(DataID);
        }

        #endregion

        #region Control

        public Control FindControlRecursive(Control Root, string Id)
        {
            if (Root.ID == Id)
                return Root;

            foreach (Control Ctl in Root.Controls)
            {
                Control FoundCtl = FindControlRecursive(Ctl, Id);
                if (FoundCtl != null)
                    return FoundCtl;
            }

            return null;
        }

        public String GetWarningPopUpString(String WarningString_Resource, bool returnFalse = true)
        {
            return controlUtil.GetWarningPopUpString(WarningString_Resource, returnFalse);
        }

        public String GetConfirmPopUpString(String ConfirmString_Resource, String textParam = "", String[] buttons = null, bool cancelEventPropagation = false)
        {
            return controlUtil.GetConfirmPopUpString(ConfirmString_Resource, textParam, buttons, cancelEventPropagation);
        }

        #endregion

        #region Authentication

        public SessionTokenInformation Authentication(bool urlSessionEnabled, int timeout)
        {
            SessionTokenInformation retVal = null;

            var bopSession = InfrastructureFactory.CreateSessionManager();
            var session = SessionGlobal.Instance.SessionTokenInfo; 

            if (session != null && session.Session != null && session.Session.SessionToken != null)
            {
                var status = VerifyToken();

                if (status != CASResponseCode.OK)
                {
                    //check if there is new token value in cookie
                    SessionTokenInformation sessionDataResp = bopSession.GetSessionData(HttpContext.Current.Request, urlSessionEnabled);

                    if (sessionDataResp != null && sessionDataResp.Session != null && sessionDataResp.Session.SessionToken != null)
                    {
                        //If session token and token from cookie are different check if one from cookie is valid
                        if (sessionDataResp.Session.SessionToken.Equals(session.Session.SessionToken) == false)
                        {
                            var status2 = VerifyToken(sessionDataResp.Session.SessionToken);
                            if (status2 == CASResponseCode.OK)
                            {
                                retVal = sessionDataResp;
                                SessionGlobal.Instance.SessionTokenInfo = sessionDataResp;

                                var service = BOp.Infrastructure.InfrastructureFactory.CreateAuthenticationService();
                                BOp.Infrastructure.Authentication.AccountCompaniesResult res = service.GetAccountCompanies(SessionGlobal.Instance.SessionTokenInfo.Session.SessionToken);
                                
                                SessionGlobal.Instance.Companies = res.Companies;
                            }
                        }
                    }
                    else
                    {
                        FormsAuthentication.SignOut();
                        HttpContext.Current.Session.Clear();
                        HttpContext.Current.Session.Abandon();
                        string redirectURL = bopSession.CreateSignInURL(HttpContext.Current.Request.Url.ToString(), timeout, "EN", urlSessionEnabled);
                        HttpContext.Current.Response.Redirect(redirectURL, true);
                    }
                }
                else
                {
                    CheckSubscription();
                }
            }
            else
            {
                FormsAuthentication.SignOut();
                SessionTokenInformation sessionDataResp = bopSession.GetSessionData(HttpContext.Current.Request, urlSessionEnabled);
                if (sessionDataResp.Status == CASResponseCode.OK)
                {
                    SessionGlobal.Instance.SessionTokenInfo = sessionDataResp;

                    var service = BOp.Infrastructure.InfrastructureFactory.CreateAuthenticationService();
                    BOp.Infrastructure.Authentication.AccountCompaniesResult res = service.GetAccountCompanies(SessionGlobal.Instance.SessionTokenInfo.Session.SessionToken);

                    SessionGlobal.Instance.Companies = res.Companies;

                    CheckSubscription();
                }
                else
                {
                    string redirectURL = bopSession.CreateSignInURL(HttpContext.Current.Request.Url.ToString(), timeout, "EN", urlSessionEnabled);
                    HttpContext.Current.Response.Redirect(redirectURL, true);
                }
            }

            return retVal;
        }

        public bool CheckSubscription()
        {
            bool retVal = true;

            if (!HasUserSubscriptionForApplication())
            {
                //Get Absoulute Url
                String LoginToToUrl = HttpContext.Current.Request.Url.ToString();

                //Remove all url parameters after aspx...
                if (HttpContext.Current.Request.Url.ToString().IndexOf("aspx") != -1)
                {
                    LoginToToUrl = HttpContext.Current.Request.Url.ToString().Substring(0, HttpContext.Current.Request.Url.ToString().IndexOf("aspx") + 4);
                }

                //set encoded param to url
                LoginToToUrl = "?LoginToToUrl=" + HttpContext.Current.Server.UrlEncode(LoginToToUrl);

                HttpContext.Current.Response.Redirect(ResolveUrl("Logout.aspx") + LoginToToUrl, false);

                retVal = false;
            }

            return retVal;
        }

        abstract public CASResponseCode VerifyToken(String SessionToken = "");

        abstract public bool HasUserSubscriptionForApplication();

        #endregion
        #region Support
       
        #endregion

    }


}
