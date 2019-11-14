using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Mvc.Ajax;
using System.Web;
namespace DLMVCTemplates.Controls
{
    [Obsolete]
    public static class DeletePopWindow
    {
        public static MvcHtmlString DeletePopupWindow(this HtmlHelper helper, string action, string controller, string area, string deleteMessage, string itemName, string confirmButtonText, string cancelButtonText, string updateDiv, Guid? id, string ajaxOnSuccess)
        {
            string divOpen = "<div id=\"deletePopup\" class=\"popup-wrapper\"><div id=\"popup_container\" class=\"popup small\">";
            UrlHelper urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
            var actionLink = urlHelper.Action(action, controller, new { area = area, id = id }).ToString();
            string ajaxBeginForm = "<form action=\"" + actionLink + "\" data-ajax=\"true\" data-ajax-method=\"POST\" data-ajax-mode=\"replace\" data-ajax-success=\"" + ajaxOnSuccess + "\" data-ajax-update=\"#" + updateDiv + "\" id=" + id + "method=\"post\" novalidate=\"novalidate\"> ";
            string basicDialogOpen = "<div id=\"dialog\" title=\"Basic dialog\"><center>";
            string title = "<h1>" + deleteMessage + "</h1>";
            string item = "<p class=\"margin-bottom-40\">" + itemName + "</p>";
            string buttonsOpen = "<div class=\"buttons\">";
            string cancelButton = "<input type=\"button\" onclick=\"$('div').remove('#deletePopup')\" class = \"button-cancel\"  value=\"" + cancelButtonText + "\">";
            string confirmButton = "<button type=\"submit\" class=\"button\">" + confirmButtonText + "</button>";
            string closedTags = "</div></center></div></form></div></div>";
            string popoupWindow = ajaxBeginForm + divOpen + basicDialogOpen + title + item + buttonsOpen + cancelButton + confirmButton + closedTags;
            return new MvcHtmlString(popoupWindow);

        }
    }
}
