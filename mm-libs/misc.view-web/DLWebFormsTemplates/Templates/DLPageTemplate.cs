using System;
using CSV2Core_MySQL.Dictionaries.MultiTable;
using System.Web.UI.WebControls;
using DLWebFormsTemplates.Utils;
using System.Web.UI;
using System.Web;

namespace DLWebFormsTemplates
{
    public class DLPageTemplate : System.Web.UI.Page, IDLDateTimeUtil, IDLDictUtil, IDLListItemsUtil, IDLPrimaryTypesUtil, IDLSessionUtil, IDLCssUtil, IDLControlUtil
    {

        private DLDictUtil dictUtil;
        private DLDateTimeUtil dateTimeUtil;
        private DLPrimaryTypesUtil primaryTypesUtil;
        private DLSessionUtil sessionUtil;
        private DLListItemsUtil listItemsUtil;
        private DLCssUtil cssUtil;
        private DLControlUtil controlUtil;

        public DLPageTemplate()
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
            if (dict != null)
                return dictUtil.GetCurrentLanguageContent(dict);
            else
                return string.Empty;            
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

        public DateTime? GetDateTimeFromStringOrNull(String dateString) 
        {
            return dateTimeUtil.GetDateTimeFromStringOrNull(dateString);
        }

        public DateTime GetMonthYearFromString(String dateString)
        {
            return dateTimeUtil.GetMonthYearFromString(dateString);
        }

        public String GetMonthYearString(DateTime date)
        {
            return dateTimeUtil.GetMonthYearString(date);
        }

        public String GetTimeString(DateTime date)
        {
            return dateTimeUtil.GetTimeString(date);
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

        public string GetStringFromDouble(object number)
        {
            if (number is double)
            {
                return primaryTypesUtil.GetStringFromDouble((double)number);
            }
            return number.ToString();
        }

        public String GetTwoDigitsPriceString(object data, String format = "0.00")
        {
            return primaryTypesUtil.GetTwoDigitsPriceString(data, format);
        }

        #endregion

        #region Session

        public String GetSessionToken()
        {
            return sessionUtil.GetSessionToken();
        }

        #endregion

        #region Request

        /// <summary>
        /// Gets GUID value from query string 
        /// </summary>
        /// <param name="Name">Parameter name</param>
        /// <returns>Query string value</returns>
        public static Guid? QueryStringGUID(string Name)
        {
            string resultStr = QueryString(Name).ToUpperInvariant();
            Guid? result = null;
            try
            {
                result = new Guid(resultStr);
            }
            catch
            {
            }
            return result;
        }

        /// <summary>
        /// Gets query string value by name
        /// </summary>
        /// <param name="Name">Parameter name</param>
        /// <returns>Query string value</returns>
        public static string QueryString(string Name)
        {
            return HttpContext.Current.Request.QueryString[Name.ToUpperInvariant()] ?? String.Empty;
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

        public string GetWarningPopUpStringWithTitle(String Title, String WarningString_Resource, bool returnFalse = true)
        {
            return controlUtil.GetWarningPopUpStringWithTitle(Title, WarningString_Resource, returnFalse);
        }

        public string GetWarningPopUpStringWithTitleWithoutResource(String Title, String WarningString_Resource, bool returnFalse = true)
        {
            return controlUtil.GetWarningPopUpStringWithTitleWithoutResource(Title, WarningString_Resource, returnFalse);
        }

        public String GetConfirmPopUpString(String ConfirmString_Resource, String textParam = "", String[] buttons = null, bool cancelEvenetPropagation = false)
        {
            return controlUtil.GetConfirmPopUpString(ConfirmString_Resource, textParam, buttons, cancelEvenetPropagation);
        }

        #endregion

        #region DynamicViewState
        public void SetViewStateObject(String key, Object value)
        {
            ViewState[key] = value;
        }
        public object GetViewStateObject(String key)
        {
            return ViewState[key];
        }
        #endregion

    }


}