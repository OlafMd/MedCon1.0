using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web;

namespace DLWebFormsTemplates.Controls
{
    [ToolboxData("<{0}:DLSaveButton ID='lbtnSave' runat='server'></{0}:DLSaveButton>")]
    public class DLSaveButton : LinkButton
    {
        public DLSaveButton() {
            
            CssClass = "button";

            OnClientClick = "if(Page_IsValid) { if(this.disabled) return false; this.disabled = true; }";

            try
            {
                Text = HttpContext.GetGlobalResourceObject("Global", "Save").ToString();
            }
            catch(Exception)
            {
                Text = "Save";
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if (ValidationGroup != String.Empty)
                OnClientClick = String.Format("AddRemoveErrorClassOnParent('{0}'); {1}", ValidationGroup, OnClientClick);
        }

    }
}

