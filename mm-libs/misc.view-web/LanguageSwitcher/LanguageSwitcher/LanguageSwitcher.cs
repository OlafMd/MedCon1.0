using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using DictTextBox;

namespace GlobalComponents
{
    [DefaultProperty("Languages")]
    [ToolboxData("<{0}:ServerControl1 runat=server></{0}:ServerControl1>")]
    public class LanguageSwitcher : Panel, IPostBackEventHandler, INamingContainer 
    {
        private static readonly String FLAG_RESOURCE_ROOT = "LanguageSwitcher.Images.flags.{0}.gif";

        //------------JAVASCRIPT CODE ---------------------------------------------------------------------
        private static readonly string CANCEL_BUBBLE = @"if (event.stopPropagation) {event.stopPropagation();} else if (window.event) {window.event.cancelBubble = true;}";

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
        [Category("Appearance")]
        [DefaultValue(false)]
        public bool LanguagesShown
        {
            get
            {
                var shown = ViewState["LanguagesShown"];
                return ((shown == null) ? false : (bool)shown);
            }

            set
            {

                ViewState["LanguagesShown"] = value;
            }
        }

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public string Text
        {
            get
            {
                String s = (String)ViewState["Text"];
                return ((s == null) ? "[" + this.ID + "]" : s);
            }

            set
            {
                ViewState["Text"] = value;
            }
        }

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        public override string CssClass
        {
            get
            {
                var css = ViewState["CssClass"];
                return ((css == null) ? "" : (string)css);
            }

            set
            {
                ViewState["CssClass"] = value;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue(null)]
        public List<Language> Languages
        {
            get
            {
                List<Language> languages = (List<Language>)ViewState["Languages"];
                return ((languages == null) ? new List<Language>() : languages);
            }
            set
            {
                ViewState["Languages"] = value;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue(null)]
        public Language CurrentLanguage
        {
            get
            {
                Language language = (Language)ViewState["CurrentLanguage"];
                return language;
            }
            set
            {
                ViewState["CurrentLanguage"] = value;
            }
        }

        // ------------------------------ EVENT HANDLERS ---------------------------------------------

        public void RaisePostBackEvent(string eventArgument)
        {

            //change language
            if (eventArgument.StartsWith("ChangeLanguage"))
            {
                string[] parts = eventArgument.Split('$');
                SwitchLanguage(parts[1]);
                OnChange(EventArgs.Empty);
            }

            //toggle languages
            if (eventArgument == "ToggleLanguages")
            {
                ToggleLanguages();
            }

            //refresh children
            CreateChildControls();

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnChange(EventArgs e)
        {
            EventHandler changeEventDelegate = (EventHandler)Events[ChangeEvent];
            if (changeEventDelegate != null)
            {
                changeEventDelegate(this, e);
            }
        }

        // ---------------------------- DISPLAYING ---------------------------------------------

        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        protected override void AddAttributesToRender(HtmlTextWriter writer)
        {
            base.AddAttributesToRender(writer);
            writer.AddAttribute(HtmlTextWriterAttribute.Name, this.UniqueID);

        }

        /// <summary>
        /// 
        /// </summary>
        protected override void CreateChildControls()
        {

            Controls.Clear();

            ClientScriptManager csm = Page.ClientScript;


            //-- dl

            if (LanguagesShown)
                Controls.Add(new LiteralControl("<dl class='showList changeLanguage' >"));
            else
                Controls.Add(new LiteralControl("<dl class='changeLanguage' >"));

            //--------------------current language----------------------------------

            //-- dt
            string jsStr = @csm.GetPostBackEventReference(this, "ToggleLanguages");
            string jsStr2 = @" $('.changeLanguage').toggleClass('showList')";
            
            Controls.Add(new LiteralControl("<dt onclick=\"" + jsStr2 + ";\">"));


            //-- curent flag
            string currentFlagSrc = this.Page.ClientScript.GetWebResourceUrl(this.GetType(), String.Format(FLAG_RESOURCE_ROOT, "noimage"));
            if (CurrentLanguage != null)
                currentFlagSrc = this.Page.ClientScript.GetWebResourceUrl(this.GetType(), String.Format(FLAG_RESOURCE_ROOT, CurrentLanguage.Code.ToLower()));

            Controls.Add(new LiteralControl("<img src=" + currentFlagSrc + ">"));
            Controls.Add(new LiteralControl("</img>"));

            //arrow
            string arrowSrc = this.Page.ClientScript.GetWebResourceUrl(this.GetType(), "LanguageSwitcher.Images.arrow_down.png");
            if (LanguagesShown)
                this.Page.ClientScript.GetWebResourceUrl(this.GetType(), "LanguageSwitcher.Images.arrow_up.png");

            Controls.Add(new LiteralControl("<img class='arrow' src=" + arrowSrc + ">"));
            Controls.Add(new LiteralControl("</img>"));

            //--dt end
            Controls.Add(new LiteralControl("</dt>"));

            //---------------- current language end------------------------------------

            string jsStr3 = null;

            foreach (var language in Languages)
            {
                //--dd
                jsStr3 = @csm.GetPostBackEventReference(this, "ChangeLanguage$" + language.ID);
                Controls.Add(new LiteralControl("<dd onclick=\"" + jsStr3 + "\">"));

                Controls.Add(new LiteralControl("<img src=" + this.Page.ClientScript.GetWebResourceUrl(this.GetType(), String.Format(FLAG_RESOURCE_ROOT, language.Code.ToLower())) + ">"));
                Controls.Add(new LiteralControl("</img>"));

                Controls.Add(new LiteralControl(language.Name));

                //--dd end
                Controls.Add(new LiteralControl("</dd>"));
            }

            Controls.Add(new LiteralControl("</dl>"));

        }



        //------------------------------ MISC METHODS --------------------------------------------

        /// <summary>
        /// Specifies that languages list is shown/hidden. 
        /// </summary>
        public void ToggleLanguages()
        {
            LanguagesShown = !LanguagesShown;
        }

        /// <summary>
        /// Switches to the specified language.
        /// </summary>
        /// <param name="LanguageID"></param>
        public void SwitchLanguage(string LanguageID)
        {
            Guid ID = Guid.Empty;
            if (Guid.TryParse(LanguageID, out ID))
            {
                CurrentLanguage = Languages.FirstOrDefault(l => l.ID == ID);
                LanguagesShown = false;
            }
        }

        //------------------------------- SETUP METHODS ------------------------------------------

        /// <summary>
        /// Adds needed stylesheets to the page
        /// </summary>
        private void EnsureStyleSheetRegistration()
        {
            // We need <head runat="server"> for this code to work
            if (this.Page.Header == null)
                throw new NotSupportedException(@"No <head runat=server> control found in page.");

            // Get the stylesheet resource URL
            var styleSheetUrl = this.Page.ClientScript.GetWebResourceUrl(
                                this.GetType(), "LanguageSwitcher.Styles.main.css");

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


        /// <summary>
        /// 
        /// </summary>
        /// <param name="Languages"></param>
        /// <param name="CurrentLanguage"></param>
        public void InitLanguages(List<Language> Languages, Guid CurrentLanguage)
        {
            if (Languages == null)
            {
                throw new ArgumentNullException("Languages");
            }
            this.Languages = Languages;
            this.CurrentLanguage = Languages.FirstOrDefault(l => l.ID == CurrentLanguage);
        }

        //----------------------------- OVERRIDE METHODS ----------------------------------------------

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            EnsureStyleSheetRegistration();

        }

    }
}
