using System;
using System.Web;
using System.Web.UI;
using DLUtils_Common.StringUtils;

namespace DLAPODemandCommons.Utils
{
    public class BubbleNotificationUtil
    {
        public static void BubbleNotify(Control control, string description, bool addCloseButton)
        {
            description = HtmlFilter.StipTags(description);
            
            // add close button
            if (addCloseButton)
            {
                description = string.Format("{0} <a href = \"\">X</a>", description);
            }

            ScriptManager.RegisterStartupScript(control, typeof(string), "bubbleNotification", 
                string.Format("bubbleNotify('{0}');", description), true);
        }

        public static void BubbleSavePopUp(Control control, String SavedName)
        {
            SavedName = HtmlFilter.StipTags(SavedName);

            SavedName += (String)HttpContext.GetGlobalResourceObject("Global", "BubbleAddedString_Resource") + " " + "<a href = \"\"> X</a>";
            ScriptManager.RegisterStartupScript(control, typeof(string), "SaveBubblePopup", String.Format("bubbleNotify('{0}');", SavedName), true);

        }
        public static void BubbleDeletedPopUp(Control control, String DeletedName)
        {
            DeletedName = HtmlFilter.StipTags(DeletedName);

            DeletedName += (String)HttpContext.GetGlobalResourceObject("Global", "BubbleDeletedString_Resource") + " " + "<a href = \"\"> X</a>";
            ScriptManager.RegisterStartupScript(control, typeof(string), "DeleteBubblePopup", String.Format("bubbleNotify('{0}');", DeletedName), true);

        }

        public static void BubbleSavePopUp(Control control, String SavedName, int delayTime, int fadeOutTime)
        {
            SavedName = HtmlFilter.StipTags(SavedName);

            SavedName += (String)HttpContext.GetGlobalResourceObject("Global", "BubbleAddedString_Resource") + " " + "<a href = \"\"> X</a>";
            ScriptManager.RegisterStartupScript(control, typeof(string), "SaveBubblePopup", String.Format("bubbleNotifyCustomDelay('{0}', {1}, {2});", SavedName, delayTime, fadeOutTime), true);
        }
    }
}
