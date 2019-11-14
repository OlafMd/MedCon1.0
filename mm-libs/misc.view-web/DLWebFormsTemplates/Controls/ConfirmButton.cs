using System;
using System.Web.UI.WebControls;
using System.Web;

namespace DLWebFormsTemplates.Controls
{
    public class ConfirmButton : LinkButton
    {
        public string ConfirmMessageResource { get; set; }
        public string CurrentItem { get; set; }
        private string yesMessage;
        public string YesMessage
        {
            get
            {
                return yesMessage as string ?? "Yes";
            }
            set
            {
                yesMessage = value;
            }
        }
        private string noMessage;
        public string NoMessage 
        {
            get
            {
                return noMessage as string ?? "No";
            }
            set
            {
                noMessage = value;
            }
        }
        

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            String[] mess = {YesMessage, NoMessage};
            Execute(ConfirmMessageResource, CurrentItem, mess);
        }

        protected void Execute(String ConfirmMessageResource, String textParam = "", String[] buttons = null)
        {
            string temp = "confirmPopUp(this,'";
           if (((String)HttpContext.GetGlobalResourceObject("Global", ConfirmMessageResource)).Contains("{0}"))
                temp += String.Format((String)HttpContext.GetGlobalResourceObject("Global", ConfirmMessageResource) + "', ' ", textParam);
            else    
                temp += (String)HttpContext.GetGlobalResourceObject("Global", ConfirmMessageResource) + "', ' ";
                temp += (String)HttpContext.GetGlobalResourceObject("Global", buttons[0]) + "', '";
                temp += (String)HttpContext.GetGlobalResourceObject("Global", buttons[1]) + "' );return false;";
            
            this.OnClientClick = temp;
        }
    }
}
