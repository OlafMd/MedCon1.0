using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using CSV2Core_MySQL.Dictionaries.MultiTable;
using DLMVCTemplates.Utils;

namespace DLMVCTemplates.Templates
{
    public class DLControllerTemplate : Controller
    {
        private DLDictUtil dictUtil;
        private IDLSessionUtil sessionUtil;
        private IDLDateTimeUtil dateTimeUtil;

        public DLControllerTemplate(IDLSessionUtil sessionUtil)
        {
            this.sessionUtil = sessionUtil;
            this.dictUtil = new DLDictUtil();
            this.dateTimeUtil = new DLDateTimeUtil();
        }

        public DLControllerTemplate()
        {
            sessionUtil = new DLSessionUtil();
            dictUtil = new DLDictUtil();
            dateTimeUtil = new DLDateTimeUtil();
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

        #region Session

        public String GetSessionToken()
        {
            return sessionUtil.GetSessionToken();
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

        #region PartialView Manipulation
        public string RenderPartialViewToString(string viewName, object model)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = ControllerContext.RouteData.GetRequiredString("action");

            ViewData.Model = model;

            using (StringWriter sw = new StringWriter())
            {
                ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                ViewContext viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);
                return sw.GetStringBuilder().ToString();
            }
        } 
        #endregion

    }
}
