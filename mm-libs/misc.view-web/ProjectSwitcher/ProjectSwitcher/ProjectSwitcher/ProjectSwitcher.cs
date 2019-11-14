using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace ProjectSwitcher
{
    [DefaultProperty("CurrentProject")]
    [ToolboxData("<{0}:ServerControl1 runat=server></{0}:ServerControl1>")]
    public class ProjectSwitcher : Panel, IPostBackEventHandler, INamingContainer 
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
        public List<Project> Projects
        {
            get
            {
                List<Project> projects = (List<Project>)ViewState["Projects"];
                return ((projects == null) ? new List<Project>() : projects);
            }
            set
            {
                ViewState["Projects"] = value;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue(null)]
        public Project CurrentProject
        {
            get
            {
                Project project = (Project)ViewState["CurrentProject"];
                return project;
            }
            set
            {
                ViewState["CurrentProject"] = value;
            }
        }

        // ------------------------------ EVENT HANDLERS ---------------------------------------------

        public void RaisePostBackEvent(string eventArgument)
        {

            //change tenant
            if (eventArgument.StartsWith("ChangeProject"))
            {
                string[] parts = eventArgument.Split('$');
                SwitchProject(parts[1]);
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

            // Link button
            Controls.Clear();

            ClientScriptManager csm = Page.ClientScript;

            string jsStr2 = @" $(this).next().toggle()";
            string arrowSrc = this.Page.ClientScript.GetWebResourceUrl(this.GetType(), "ProjectSwitcher.Images.arrow_down.png");

            Controls.Add(new LiteralControl("<a id=\"currentProject\" class=\"projectLink\" onClick=\""+jsStr2+";\">"));
            if (Projects.Count == 0)
            {
                // nothing
                //Controls.Add(new LiteralControl(""));
            }
            else if (CurrentProject == null)
            {
                SwitchProject(Projects.First().ID.ToString());
                OnChange(null);
                Controls.Add(new LiteralControl("<label style=\"background-color: rgb(230,230,230); background-image:url('" + arrowSrc + "');background-repeat:no-repeat; background-position:right center; display:block; text-decoration:none; padding-left: 2px;\">" + CurrentProject.Name + "</label>"));
            }
            else
            {
                Controls.Add(new LiteralControl("<label style=\"background-color: rgb(230,230,230); background-image:url('" + arrowSrc + "'); background-repeat:no-repeat; background-position:right center; display:block; text-decoration:none; padding-left: 2px;\">" + CurrentProject.Name + "</label>"));
            }
            
            //img
            Controls.Add(new LiteralControl("</a>"));
            
            //ul
            Controls.Add(new LiteralControl("<ul style=\"display: none;\" class=\"changeProject sorting-items-projectSwitcher dropdown-popup\">"));

            string jsStr3 = "";
            string bechange = "";
            //li li li li...
            foreach (var item in Projects)
            {
                if (item.ID == CurrentProject.ID)
                    continue;

                jsStr3 = @csm.GetPostBackEventReference(this, "ChangeProject$" + item.ID);
                bechange = String.Format("beChangeHash('type=Project&id={0}&activetab={1}'); return false;", item.ID.ToString(), "Detail");

                Controls.Add(new LiteralControl("<li>"));

                Controls.Add(new LiteralControl("<a id=\"li"+ item.ID +"\" class=\"dropDownItem projectLinkItems\" onClick=\"" + bechange + ";\">"+item.Name+"</a>"));

                Controls.Add(new LiteralControl("</li>"));
            }

            Controls.Add(new LiteralControl("</ul>"));

        }


        //------------------------------ MISC METHODS --------------------------------------------

        public void SwitchProject(string ProjectID)
        {
            Guid ID = Guid.Empty;
            if (Guid.TryParse(ProjectID, out ID))
            {
                CurrentProject = Projects.FirstOrDefault(l => l.ID == ID);
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
                                this.GetType(), "ProjectSwitcher.Styles.main.css");

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

        public void InitProjects(List<Project> Projects, Guid CurrentProject)
        {
            if (Projects == null)
            {
                throw new ArgumentNullException("Projects");
            }
            this.Projects = Projects;
            this.CurrentProject = Projects.FirstOrDefault(t => t.ID == CurrentProject);
        }

        //----------------------------- OVERRIDE METHODS ----------------------------------------------

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            EnsureStyleSheetRegistration();

        }


    }
}
