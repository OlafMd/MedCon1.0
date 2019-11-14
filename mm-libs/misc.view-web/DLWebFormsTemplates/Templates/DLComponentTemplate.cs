using System;
using DLWebFormsTemplates.Utils;
using CSV2Core_MySQL.Dictionaries.MultiTable;
using System.Web.UI.WebControls;
using System.Web.UI;
using BOp.Infrastructure.Authentication;
using DLWebFormsTemplates.Utils.InputParameters;

namespace DLWebFormsTemplates.Templates
{
    public class DLComponentTemplate : System.Web.UI.UserControl, IDLDateTimeUtil, IDLDictUtil, IDLListItemsUtil, IDLPrimaryTypesUtil, IDLSessionUtil, IDLCssUtil, IDLControlUtil
    {
        private DLDictUtil dictUtil;
        private DLDateTimeUtil dateTimeUtil;
        private DLPrimaryTypesUtil primaryTypesUtil;
        private DLSessionUtil sessionUtil;
        private DLListItemsUtil listItemsUtil;
        private DLCssUtil cssUtil;
        private DLControlUtil controlUtil;

        public DLComponentTemplate()
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

        public DateTime? GetDateTimeFromStringOrNull(String dateString)
        {
            return dateTimeUtil.GetDateTimeFromStringOrNull(dateString);

        }

        public String GetTimeString(DateTime date)
        {
            return dateTimeUtil.GetTimeString(date);
        }

        public DateTime GetMonthYearFromString(String dateString)
        {
            return dateTimeUtil.GetMonthYearFromString(dateString);
        }

        public DateTime GetMonthYearWithTwoDigitFromString(String dateString)
        {
            return dateTimeUtil.GetMonthYearWithTwoDigitFromString(dateString);
        }

        public String GetMonthYearString(DateTime date)
        {
            return dateTimeUtil.GetMonthYearString(date);
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

        public String GetTwoDigitsPriceString(object data, String format = "0.00") { 
            return primaryTypesUtil.GetTwoDigitsPriceString(data, format);
        }

        #endregion

        #region Session

        public String GetSessionToken()
        {
            return sessionUtil.GetSessionToken();
        }

        public SessionTokenInformation GetSessionTicket()
        {
            return sessionUtil.GetSessionTicket();
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

        public String GetWarningPopUpStringWithTitleWithoutResource(String Title, String WarningString_Resource,
            bool returnFalse = true)
        {
            return controlUtil.GetWarningPopUpStringWithTitleWithoutResource(Title, WarningString_Resource, returnFalse);
        }

        [Obsolete("GetConfirmPopUpString is deprecated, please use GetConfirmPopUp instead.")]
        public String GetConfirmPopUpString(String ConfirmString_Resource, String textParam = "", String[] buttons = null, bool cancelEventPropagation = false)
        {
            return controlUtil.GetConfirmPopUpString(ConfirmString_Resource, textParam, buttons, cancelEventPropagation);
        }

        [Obsolete("GetConfirmPopUpString is deprecated, please use GetConfirmPopUp instead.")]
        public String GetConfirmPopUpStringWithTitle(String ConfirmString_Resource, String textParam = "", String[] buttons = null, bool cancelEventPropagation = false, String Title = "")
        {
            return controlUtil.GetConfirmPopUpStringWithTitle(ConfirmString_Resource, textParam, buttons, cancelEventPropagation, Title);
        }

        public String GetConfirmPopUp(ConfirmPopUpParameters parameters)
        {
            return controlUtil.GetConfirmPopUp(parameters);
        }


        #endregion

    }
}
