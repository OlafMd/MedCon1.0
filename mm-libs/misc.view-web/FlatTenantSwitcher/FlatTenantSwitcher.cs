using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GlobalComponents
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:ServerControl1 runat=server></{0}:ServerControl1>")]
    public class FlatTenantSwitcher : Panel, IPostBackEventHandler, INamingContainer 
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
        public UserInfo CurrentUser
        {
            get
            {
                var currentUser = (UserInfo)ViewState["CurrentUser"];
                return currentUser;
            }
            set
            {
                ViewState["CurrentUser"] = value;
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
            
            //-- ol

            Controls.Add(new LiteralControl("<ol class='tenants'>"));

            var logoutUrl = ResolveUrl("~/Logout.aspx");

            Controls.Add(new LiteralControl("<li class='user'>"));
            Controls.Add(new LiteralControl("<a href='" + logoutUrl + "'>"));


            if (!String.IsNullOrWhiteSpace(CurrentUser.AvatarUrl))
                Controls.Add(new LiteralControl("<img id='imgAvatar' src=\""+CurrentUser.AvatarUrl+"\"/>"));

            Controls.Add(new LiteralControl("<span id='lblUsername' class='lblUsername'>"+ CurrentUser.Name+"</span>"));
            Controls.Add(new LiteralControl("<span class='logout-hover'></span>"));
            Controls.Add(new LiteralControl("</a>"));
            Controls.Add(new LiteralControl("</li>"));

            foreach (var tenant in Tenants)
            {
                //--li
                Controls.Add(new LiteralControl("<li>"));

                //--a
                string jsStr3 = @csm.GetPostBackEventReference(this, "ChangeTenant$" + tenant.ID);

                if (CurrentTenant.ID == tenant.ID)
                    Controls.Add(new LiteralControl("<a class=\"selected\" href=\"#\">"));
                else
                    Controls.Add(new LiteralControl("<a href=\"javascript:" + jsStr3 + "\">"));

                //--img
                //Controls.Add(new LiteralControl("<img src=\"/Images/avatar.png\" />"));

                Controls.Add(new LiteralControl("<span>" + tenant.Name + "</span>"));

                Controls.Add(new LiteralControl("</a>"));


                //--li end
                Controls.Add(new LiteralControl("</li>"));
            }

            Controls.Add(new LiteralControl("</ol>"));
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

        }

        public void InitCurrentUser(UserInfo user) {
            this.CurrentUser = user; 
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
