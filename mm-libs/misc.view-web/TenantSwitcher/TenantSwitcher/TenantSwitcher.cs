using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace GlobalComponents
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:ServerControl1 runat=server></{0}:ServerControl1>")]
    public class TenantSwitcher : Panel, IPostBackEventHandler, INamingContainer 
    {

        //------------EVENT HANDLER DEFINITIONS ----------------------------------------------------------------------

        private static readonly object ChangeEvent = new object();

        public event EventHandler Change
        {
            add
            {
                Events.AddHandler(ChangeEvent, value);
            }
            remove
            {
                Events.RemoveHandler(ChangeEvent, value);
            }
        }

        //------------ PUBLIC PROPERTIES ----------------------------------------------------------------- 

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue(null)]
        public List<Tenant> Tenants
        {
            get
            {
                List<Tenant> tenants = (List<Tenant>)ViewState["Tenants"];
                return ((tenants == null) ? new List<Tenant>() : tenants);
            }
            set
            {
                ViewState["Tenants"] = value;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue(null)]
        public Tenant CurrentTenant
        {
            get
            {
                Tenant tenant = (Tenant)ViewState["CurrentTenant"];
                return tenant;
            }
            set
            {
                ViewState["CurrentTenant"] = value;
            }
        }

        // ------------------------------ EVENT HANDLERS ---------------------------------------------

        public void RaisePostBackEvent(string eventArgument)
        {

            //change tenant
            if (eventArgument.StartsWith("ChangeTenant"))
            {
                string[] parts = eventArgument.Split('$');
                SwitchTenant(parts[1]);
                OnChange(EventArgs.Empty);
            }

            //refresh children
            CreateChildControls();
        }

        protected virtual void OnChange(EventArgs e)
        {
            EventHandler changeEventDelegate = (EventHandler)Events[ChangeEvent];
            if (changeEventDelegate != null)
            {
                changeEventDelegate(this, e);
            }
        } 

        // ---------------------------- DISPLAYING ---------------------------------------------

        protected override void AddAttributesToRender(HtmlTextWriter writer)
        {
            base.AddAttributesToRender(writer);
            writer.AddAttribute(HtmlTextWriterAttribute.Name, this.UniqueID);

        }

        protected override void CreateChildControls()
        {

            Controls.Clear();

            ClientScriptManager csm = Page.ClientScript;


            //-- dl

            Controls.Add(new LiteralControl("<dl class='changeTenant' >"));

            //--------------------current tenant----------------------------------

            //-- dt
            string jsStr2 = @" $('.changeTenant').toggleClass('showList')";

            Controls.Add(new LiteralControl("<dt onclick=\"" + jsStr2 + ";\">"));

            if (CurrentTenant != null)
                Controls.Add(new LiteralControl(CurrentTenant.Name));

            if (Tenants.Count > 1) {
                //arrow
                string arrowSrc = this.Page.ClientScript.GetWebResourceUrl(this.GetType(), "TenantSwitcher.Images.arrow_down.png");

                Controls.Add(new LiteralControl("<img class='arrow' src=" + arrowSrc + ">"));
                Controls.Add(new LiteralControl("</img>"));
            }

            //--dt end
            Controls.Add(new LiteralControl("</dt>"));

            //---------------- current tenant end------------------------------------

            if (Tenants.Count > 1) { 

                foreach (var tenant in Tenants)
                {

                    if (CurrentTenant.ID == tenant.ID)
                        continue;

                    //--dd
                    string jsStr3 = @csm.GetPostBackEventReference(this, "ChangeTenant$" + tenant.ID);
                    Controls.Add(new LiteralControl("<dd onclick=\"" + jsStr3 + "\">"));

                    Controls.Add(new LiteralControl(tenant.Name));

                    //--dd end
                    Controls.Add(new LiteralControl("</dd>"));
                }

            }
            Controls.Add(new LiteralControl("</dl>"));

        }



        //------------------------------ MISC METHODS --------------------------------------------

        public void SwitchTenant(string TenantID)
        {
            Guid ID = Guid.Empty;
            if (Guid.TryParse(TenantID, out ID))
            {
                CurrentTenant = Tenants.FirstOrDefault(l => l.ID == ID);
            }
        }

        //------------------------------- SETUP METHODS ------------------------------------------

        private void EnsureStyleSheetRegistration()
        {
            // We need <head runat="server"> for this code to work
            if (this.Page.Header == null)
                throw new NotSupportedException(@"No <head runat=server> control found in page.");

            // Get the stylesheet resource URL
            var styleSheetUrl = this.Page.ClientScript.GetWebResourceUrl(
                                this.GetType(), "TenantSwitcher.Styles.main.css");

            // Check if this stylesheet is already registered
            var alreadyRegistered = this.Page.Header.Controls.OfType<HtmlLink>().Any(x => x.Href.Equals(styleSheetUrl));
            if (alreadyRegistered) return; // no work here

            // If not, register it
            var link = new HtmlLink();
            link.Attributes["rel"] = "stylesheet";
            link.Attributes["type"] = "text/css";
            link.Attributes["href"] = styleSheetUrl;
            this.Page.Header.Controls.Add(link);
        }

        public void InitTenants(List<Tenant> Tenants, Guid CurrentTenant)
        {
            if (Tenants == null)
            {
                throw new ArgumentNullException("Tenants");
            }
            this.Tenants = Tenants;
            this.CurrentTenant = Tenants.FirstOrDefault(t => t.ID == CurrentTenant);
        }

        //----------------------------- OVERRIDE METHODS ----------------------------------------------

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            EnsureStyleSheetRegistration();

        }

    }
}
