using System;
using System.Web.UI.WebControls;

namespace DLWebFormsTemplates.Utils
{
    interface IDLCssUtil
    {
        void ToggleCssClass(WebControl Control, string ClassName);

        void RemoveCssClass(WebControl Control, string ClassName); 

        bool HasCssClass(WebControl Control, string ClassName);

        void SetCssClass(WebControl Control, string ClassName, bool Direction = true);

        bool isControlContainsCssClass(WebControl Control, string ClassName);     

        void SetExactCssClass(WebControl Control, string ClassName);

        void ToggleIDOnSession(Guid DataID);

        bool IsIDOnSession(Guid DataID);
    }
}