using System;
using System.Web.UI;
using System.Web;
using DLWebFormsTemplates.Utils.InputParameters;

namespace DLWebFormsTemplates.Utils
{
    public class DLControlUtil : IDLControlUtil
    {
        public static Control FindControlRecursive(Control Root, string Id)
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
            return string.Format("warningPopUp('{0}', '{1}'); {2}",
            HttpContext.GetGlobalResourceObject("Global", WarningString_Resource),
            HttpContext.GetGlobalResourceObject("Global", "Ok"),
            returnFalse ? "return false;" : string.Empty);
        }


        public String GetWarningPopUpStringWithTitle(String Title, String WarningString_Resource, bool returnFalse = true)
        {
            string temp = (!String.IsNullOrEmpty(Title)) ? String.Format("<h1>{0}</h1>", Title) : "";
            return string.Format("warningPopUp('{0}', '{1}'); {2}",
                 temp +=
                 HttpContext.GetGlobalResourceObject("Global", WarningString_Resource),
                 HttpContext.GetGlobalResourceObject("Global", "Ok"),
                 returnFalse ? "return false;" : string.Empty);

        }


        public String GetWarningPopUpStringWithTitleWithoutResource(String Title, String WarningString_Resource,
            bool returnFalse = true)
        {
            string temp = (!String.IsNullOrEmpty(Title)) ? String.Format("<h1>{0}</h1>", Title) : "";
            return string.Format("warningPopUp('{0}', '{1}'); {2}",
                 temp += WarningString_Resource, HttpContext.GetGlobalResourceObject("Global", "Ok"), returnFalse ? "return false;" : string.Empty);
        }

        public String GetConfirmPopUpString(String ConfirmString_Resource, String textParam = "", String[] buttons = null, bool cancelEventPropagation = false)
        {
            string temp = "confirmPopUp(this, '";
            if (((String)HttpContext.GetGlobalResourceObject("Global", ConfirmString_Resource)).Contains("{0}"))
                temp += String.Format((String)HttpContext.GetGlobalResourceObject("Global", ConfirmString_Resource) + "', '", textParam);
            else
                temp += (String)HttpContext.GetGlobalResourceObject("Global", ConfirmString_Resource) + "', '";

            if (buttons != null)
            {
                temp += (String)HttpContext.GetGlobalResourceObject("Global", buttons[0]) + "', '";
                temp += (String)HttpContext.GetGlobalResourceObject("Global", buttons[1]) + String.Format("' ); {0} return false;", cancelEventPropagation ? "event.cancelBubble = true;" : "");
            }
            else
            {
                temp += (String)HttpContext.GetGlobalResourceObject("Global", "Yes") + "', '";
                temp += (String)HttpContext.GetGlobalResourceObject("Global", "No") + String.Format("' ); {0} return false;", cancelEventPropagation ? "event.cancelBubble = true;" : "");
            }
            return temp;
        }

        public String GetConfirmPopUpStringWithTitle(String ConfirmString_Resource, String textParam = "", String[] buttons = null, bool cancelEventPropagation = false, String Title = "")
        {
            string temp = "confirmPopUp(this,'";
            temp += (!String.IsNullOrEmpty(Title)) ? String.Format("<h1>{0}</h1>", Title) : "";

            if (((String)HttpContext.GetGlobalResourceObject("Global", ConfirmString_Resource)).Contains("{0}"))
            {
                temp += String.Format((String)HttpContext.GetGlobalResourceObject("Global", ConfirmString_Resource) + "', ' ", textParam);
            }
            else
            {
                temp += (String)HttpContext.GetGlobalResourceObject("Global", ConfirmString_Resource) + "', ' ";
            }

            if (buttons != null)
            {
                temp += (String)HttpContext.GetGlobalResourceObject("Global", buttons[0]) + "', '";
                temp += (String)HttpContext.GetGlobalResourceObject("Global", buttons[1]) + String.Format("' ); {0} return false;", cancelEventPropagation ? "event.cancelBubble = true;" : "");
            }
            else
            {
                temp += (String)HttpContext.GetGlobalResourceObject("Global", "Yes") + "', '";
                temp += (String)HttpContext.GetGlobalResourceObject("Global", "No") + String.Format("' ); {0} return false;", cancelEventPropagation ? "event.cancelBubble = true;" : "");
            }

            return temp;
        }

        public String GetConfirmPopUp(ConfirmPopUpParameters parameters)
        {
            string retVal = "confirmPopUp(this,'";

            retVal += (parameters.IsTitleSet) ? String.Format("<h1>{0}</h1>", parameters.Title) : "";

            if (parameters.IsFormatStringNeeded)
                retVal += String.Format(parameters.ConfirmString + "', ' ", parameters.TextParam);
            else
                retVal += parameters.ConfirmString + "', ' ";

            if (parameters.UseDefaultButtons == false)
            {
                retVal += (String)HttpContext.GetGlobalResourceObject("Global", "Yes") + "', '";
                retVal += (String)HttpContext.GetGlobalResourceObject("Global", "No") + String.Format("' ); {0} return false;", parameters.CancelEventPropagation ? "event.cancelBubble = true;" : "");
            }
            else
            {
                retVal += parameters.ButtonYes + "', '";
                retVal += parameters.ButtonNo + String.Format("' ); {0} return false;", parameters.CancelEventPropagation ? "event.cancelBubble = true;" : "");
            }
            return retVal;
        }

    }
}
