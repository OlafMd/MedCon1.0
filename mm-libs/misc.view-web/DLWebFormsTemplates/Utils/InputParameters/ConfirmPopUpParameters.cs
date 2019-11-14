using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace DLWebFormsTemplates.Utils.InputParameters
{
    public class ConfirmPopUpParameters
    {

        public string ConfirmString
        {
            get { return _confirmString; }
            set { _confirmString = HttpContext.GetGlobalResourceObject("Global", value).ToString(); }
        }
        public string Title 
        {
            get { return _title; }
            set { _title = HttpContext.GetGlobalResourceObject("Global", value).ToString(); }
        }
        public string[] TextParam { get; set; }
        public string ButtonYes
        {
            get
            {
                return _buttonYes;
            }
            set
            {
                _buttonYes = HttpContext.GetGlobalResourceObject("Global", value).ToString();
            }
        }
        public string ButtonNo
        {
            get
            {
                return _buttonNo;
            }
            set
            {
                _buttonNo = HttpContext.GetGlobalResourceObject("Global", value).ToString();
            }
        }

        public bool CancelEventPropagation { get; set; }
        public bool IsTitleSet
        {
            get { return !string.IsNullOrEmpty(_title); }
        }
        public bool IsFormatStringNeeded
        {
            get { return (ConfirmString.Contains("{0}")) && (TextParam != null); }
        }
        public bool UseDefaultButtons
        {
            get { return (ButtonYes != null && ButtonNo != null); }

        }

        private string _buttonYes;
        private string _buttonNo;
        private string _confirmString;
        private string _title;
    }
}
