using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using CSV2Core_MySQL.Dictionaries.MultiTable;
using System.Web.UI.HtmlControls;

namespace DictTextBox
{
    [ValidationProperty("Text")]
    [DefaultProperty("Data")]
    [ToolboxData("<%-- Don't forget to call InitLanguages function in the code behind for content initialization.--%>\n<{0}:DictTextBox runat=server></{0}:DictTextBox>")]
    public class DictTextBox : Panel, IPostBackEventHandler, INamingContainer 
    {

        private static readonly String FLAG_RESOURCE_ROOT = "DictTextBox.Images.flags.{0}.gif";

        //------------JAVASCRIPT CODE ---------------------------------------------------------------------
        private static readonly string CANCEL_BUBBLE = @"if (event.stopPropagation) {event.stopPropagation();} else if (window.event) {window.event.cancelBubble = true;}";
   
        //------------CHILD CONTROLS ----------------------------------------------------------------------
        private TextBox textBox;

        //------------EVENT HANDLER DEFINITIONS ----------------------------------------------------------------------

        private static readonly object EscapeEvent = new object();
        private static readonly object EnterEvent = new object();
        private static readonly object TabEvent = new object();

        /// <summary>
        /// Defines what happens if the ESC key is hit while typing.
        /// </summary>
        public event EventHandler Escape
        {
            add
            {
                Events.AddHandler(EscapeEvent, value);
            }
            remove
            {
                Events.RemoveHandler(EscapeEvent, value);
            }
        }

        /// <summary>
        /// Defines what happens if the ENTER key is hit while typing.
        /// </summary>
        public event EventHandler Enter
        {
            add
            {
                Events.AddHandler(EnterEvent, value);
            }
            remove
            {
                Events.RemoveHandler(EnterEvent, value);
            }
        }

        /// <summary>
        /// Defines what happens if the TAB key is hit while typing.
        /// </summary>
        public event EventHandler Tab
        {
            add
            {
                Events.AddHandler(TabEvent, value);
            }
            remove
            {
                Events.RemoveHandler(TabEvent, value);
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
        [DefaultValue(false)]
        public bool IsLarge
        {
            get
            {
                var isLarge = ViewState["IsLarge"];
                return ((isLarge == null) ? false : (bool)isLarge);
            }

            set
            {
                ViewState["IsLarge"] = value;
            }
        }


        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue(true)]
        public bool IsTextBoxFocused
        {
            get
            {
                var isFocused = ViewState["IsTextBoxFocused"];
                return ((isFocused == null) ? false : (bool)isFocused);
            }

            set
            {
                ViewState["IsTextBoxFocused"] = value;
            }
        }

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        public string Text
        {
            get
            {
                if (Content != null && CurrentLanguage != null)
                {
                    var entry = Content.Contents.FirstOrDefault(e => e.LanguageID == CurrentLanguage.ID);
                    if (entry != null) return System.Web.HttpUtility.HtmlDecode(entry.Content);
                }

                return "";
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
        [Category("Behavior")]
        [DefaultValue("")]
        public string TextBoxCssClass
        {
            get
            {
                var css = ViewState["TextBoxCssClass"];
                return ((css == null) ? "" : (string)css);
            }

            set
            {
                ViewState["TextBoxCssClass"] = value;
            }
        }

        /// <summary>
        /// If this property is set to true, no postback will be performed on pressing enter key.
        /// </summary>
        [Bindable(true)]
        [Category("Behavior")]
        [DefaultValue(false)]
        public bool IgnoreEnterForPostback
        {
            get
            {
                var ignore = ViewState["IgnoreEnterForPostback"];
                return ((ignore == null) ? false : (bool)ignore);
            }

            set
            {
                ViewState["IgnoreEnterForPostback"] = value;
            }
        }

        /// <summary>
        /// If this property is set to true, no postback will be performed on pressing tab key.
        /// </summary>
        [Bindable(true)]
        [Category("Behavior")]
        [DefaultValue(false)]
        public bool IgnoreTabForPostback
        {
            get
            {
                var ignore = ViewState["IgnoreTabForPostback"];
                return ((ignore == null) ? false : (bool)ignore);
            }

            set
            {
                ViewState["IgnoreTabForPostback"] = value;
            }
        }

        /// <summary>
        /// If this property is set to true, no postback will be performed on pressing cancel key.
        /// </summary>
        [Bindable(true)]
        [Category("Behavior")]
        [DefaultValue(false)]
        public bool IgnoreCancelForPostback
        {
            get
            {
                var ignore = ViewState["IgnoreCancelForPostback"];
                return ((ignore == null) ? false : (bool)ignore);
            }

            set
            {
                ViewState["IgnoreCancelForPostback"] = value;
            }
        }

        [DefaultValue(null)]
        public Dict Data
        {
            get
            {
                UpdateContent();
                Dict dict = (Dict)ViewState["Content"];
                return dict;
            }
            set
            {
                ViewState["Content"] = value;
            }
        }

        public string StringData
        {
            get
            {
                List<string> map = new List<string>();
                foreach (var v in Data.Contents)
                {
                    map.Add(v.LanguageID.ToString() + "@=@" + v.Content);
                }
                return String.Join("@|@", map);
            }
            set
            {
                ViewState["StringData"] = value;
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

        // ------------------------------ PRIVATE PROPERTIES -----------------------------------------

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue(null)]
        private Dict Content
        {
            get
            {
                Dict dict = (Dict)ViewState["Content"];
                return dict;
            }
            set
            {
                ViewState["Content"] = value;
            }
        }

        // ------------------------------ EVENT HANDLERS ---------------------------------------------

        /// <summary>
        /// Handle postbacks
        /// </summary>
        /// <param name="eventArgument"></param>
        public void RaisePostBackEvent(string eventArgument)
        {
            //toggle languages
            if (eventArgument == "ToggleLanguages")
            {
                UpdateContent();
                ToggleLanguages();
                IsTextBoxFocused = false;
            }
            //switch language
            else if (eventArgument.StartsWith("SwitchLanguage"))
            {
                string[] parts = eventArgument.Split('$');
                SwitchLanguage(parts[1]);
                IsTextBoxFocused = true;
            }
            //update content
            else if (eventArgument.StartsWith("ConfirmChanges"))
            {
                UpdateContent();
                IsTextBoxFocused = false;
                OnEnter(EventArgs.Empty);
            }
            //cancel changes
            else if (eventArgument.StartsWith("CancelChanges"))
            {
                IsTextBoxFocused = false;
                OnEscape(EventArgs.Empty);
            }
            //process tab
            else if (eventArgument.StartsWith("ProcessTab"))
            {
                UpdateContent();
                IsTextBoxFocused = false;
                OnTab(EventArgs.Empty);
            }

            //refresh children
            CreateChildControls();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnEnter(EventArgs e)
        {
            EventHandler enterEventDelegate = (EventHandler)Events[EnterEvent];
            if (enterEventDelegate != null)
            {
                enterEventDelegate(this, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnEscape(EventArgs e)
        {
            EventHandler escapeEventDelegate = (EventHandler)Events[EscapeEvent];
            if (escapeEventDelegate != null)
            {
                escapeEventDelegate(this, e);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnTab(EventArgs e)
        {
            EventHandler tabEventDelegate = (EventHandler)Events[TabEvent];
            if (tabEventDelegate != null)
            {
                tabEventDelegate(this, e);
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
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "language_holder " + this.CssClass);

        }

        /// <summary>
        /// 
        /// </summary>
        protected override void CreateChildControls()
        {
            Controls.Clear();


            ClientScriptManager csm = Page.ClientScript;

            //--------------------current language----------------------------------

            //--dl
            if (IsLarge)
            {
                Controls.Add(new LiteralControl("<dl class='language lang_primar lang_description'>"));
            }
            else
            {
                Controls.Add(new LiteralControl("<dl class='language lang_primar lang_name_class'>"));
            }

            //--dt
            string jsStr = CANCEL_BUBBLE + @csm.GetPostBackEventReference(this, "ToggleLanguages");
            Controls.Add(new LiteralControl("<dt onclick=\"" + jsStr + ";\">"));

            //current flag
            string currentFlagSrc = this.Page.ClientScript.GetWebResourceUrl(this.GetType(), String.Format(FLAG_RESOURCE_ROOT, "noimage"));
            if (CurrentLanguage != null)
                currentFlagSrc = this.Page.ClientScript.GetWebResourceUrl(this.GetType(), String.Format(FLAG_RESOURCE_ROOT, CurrentLanguage.Code.ToLower()));

            Controls.Add(new LiteralControl("<img src=" + currentFlagSrc + ">"));
            Controls.Add(new LiteralControl("</img>"));

            //arrow
            string arrowSrc = this.Page.ClientScript.GetWebResourceUrl(this.GetType(), "DictTextBox.Images.arrow_down.png");
            if (LanguagesShown)
                this.Page.ClientScript.GetWebResourceUrl(this.GetType(), "DictTextBox.Images.arrow_up.png");

            Controls.Add(new LiteralControl("<img src=" + arrowSrc + ">"));
            Controls.Add(new LiteralControl("</img>"));

            //--dd
            Controls.Add(new LiteralControl("<dd>"));

            //textbox

            textBox = new TextBox();
            textBox.ID = "TextBox";
            textBox.Text = this.Text;
            if (CurrentLanguage != null)
            textBox.Attributes["CurrentLanguageID"] = CurrentLanguage.ID.ToString();
            textBox.Attributes["onfocus"] = "focusOnDictTextBox(this);";

            //js events
            string keyEvent = "";
            if (!this.IgnoreEnterForPostback)
            {
                keyEvent += @"if (event.keyCode==13 && !event.shiftKey) {"
                            + csm.GetPostBackEventReference(this, "ConfirmChanges") +
                          @"}";
            }
            if (!this.IgnoreTabForPostback)
            {
                keyEvent += @"if (event.keyCode == 9 && !event.shiftKey){"
                            + csm.GetPostBackEventReference(this, "ProcessTab") +
                          @"}";
            }
            if (!this.IgnoreCancelForPostback)
            {
                keyEvent += @"if (event.keyCode == 27){" 
                            + csm.GetPostBackEventReference(this, "CancelChanges") + 
                          @"}";
            }

            if (keyEvent != "")
            {
                textBox.Attributes["onkeydown"] = CANCEL_BUBBLE + keyEvent;

            }

            //textBox.Attributes["onkeydown"] = CANCEL_BUBBLE + @"if (event.keyCode==13 && !event.shiftKey) {" + csm.GetPostBackEventReference(this, "ConfirmChanges") + @"} if (event.keyCode == 9 && !event.shiftKey){" + csm.GetPostBackEventReference(this, "ProcessTab") + @"} if (event.keyCode == 27){" + csm.GetPostBackEventReference(this, "CancelChanges") + "}";

            if (IsLarge)
            {               
                textBox.TextMode = TextBoxMode.MultiLine;             
            }
            else
            {
                textBox.CssClass = "inline-edit-input";
                textBox.TextMode = TextBoxMode.SingleLine;
            }
            textBox.CssClass += " " + this.TextBoxCssClass;
            
            Controls.Add(textBox);

            //--dd end
            Controls.Add(new LiteralControl("</dd>"));
            //--dt end
            Controls.Add(new LiteralControl("</dt>"));
            //--dl end
            Controls.Add(new LiteralControl("</dl>"));

            //---------------- current language end------------------------------------

            //---------------- all languages ------------------------------------------

            string languagesStyleAttr = "style='display:block;'";
            if (!LanguagesShown)
                languagesStyleAttr = "style='display:none;'";

            string languagesClassAttr = "class='language lagn_choices'";
            if (IsLarge)
                languagesClassAttr = "class='language lagn_desc_choices'";

            //-- ul
            Controls.Add(new LiteralControl("<ul "+ languagesClassAttr + " " + languagesStyleAttr +">"));


                foreach (var language in Languages)
                {
                    //--li
                    jsStr = CANCEL_BUBBLE + @csm.GetPostBackEventReference(this, "SwitchLanguage$" + language.ID);
                    Controls.Add(new LiteralControl("<li onclick=\"" + jsStr + "\">"));

                    //--dl
                    Controls.Add(new LiteralControl("<dl>"));
                    //--dt
                    Controls.Add(new LiteralControl("<dt>"));

                    DictEntry entry = null;
                    if (Content != null && Content.Contents != null)
                        entry = Content.Contents.FirstOrDefault(e => e.LanguageID == language.ID);


                    Controls.Add(new LiteralControl("<img src=" + this.Page.ClientScript.GetWebResourceUrl(this.GetType(), String.Format(FLAG_RESOURCE_ROOT, language.Code.ToLower())) + ">"));
                    Controls.Add(new LiteralControl("</img>"));

                    Controls.Add(new LiteralControl("<span>" + language.Name + "</span>"));
                    /*.Attributes["CurrentLanguageID"] = CurrentLanguage.ID.ToString();*/
                    Controls.Add(new LiteralControl("<dd languageID=\""+language.ID+"\">"));
                    if (entry != null)
                        Controls.Add(new LiteralControl(entry.Content));
                    Controls.Add(new LiteralControl("</dd>"));

                    //--dt end
                    Controls.Add(new LiteralControl("</dt>"));
                    //--dl end
                    Controls.Add(new LiteralControl("</dl>"));
                    //--li end
                    Controls.Add(new LiteralControl("</li>"));
                }

            //--ul end
            Controls.Add(new LiteralControl("</ul>"));

            if (IsTextBoxFocused) Page.SetFocus(textBox);

        }

        //------------------------------ MISC METHODS --------------------------------------------

        /// <summary>
        /// Rerenders child controls
        /// </summary>
        public void RenderChildren()
        {
            CreateChildControls();
        }

        /// <summary>
        /// Sets focus to textbox of this component
        /// </summary>
        public override void Focus()
        {
            base.Focus();
            IsTextBoxFocused = true;
        }

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
            Guid ID;
            if (Guid.TryParse(LanguageID, out ID))
            {
                CurrentLanguage = Languages.FirstOrDefault(l => l.ID == ID);
                LanguagesShown = false;
            }
        }

        /// <summary>
        /// Updates the dict content. If the dict content was not initialized, nothing will happen
        /// </summary>
        public void UpdateContent()
        {

            if (Content == null) return;

            string text = textBox.Text;

            DictEntry entry = Content.Contents.FirstOrDefault(e => e.LanguageID == CurrentLanguage.ID);
            //if there is a dict entry for the current language, update it
            if (entry != null)
            {
                entry.Content = System.Web.HttpUtility.HtmlEncode(text);
            }
            //if not, make a new one
            else
            {
                Content.AddEntry(CurrentLanguage.ID, System.Web.HttpUtility.HtmlEncode(text));
            }
        }

        //------------------------------- SETUP METHODS ------------------------------------------

        /// <summary>
        /// Adds needed stylesheets to the page
        /// </summary>
        private void EnsureStyleSheetRegistration() {
            // We need <head runat="server"> for this code to work
            if (this.Page.Header == null)
                throw new NotSupportedException(@"No <head runat=server> control found in page.");

            // Get the stylesheet resource URL
            var styleSheetUrl = this.Page.ClientScript.GetWebResourceUrl(
                                this.GetType(), "DictTextBox.Styles.main.css");

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
        /// <param name="Content"></param>
        /// <param name="Languages"></param>
        /// <param name="CurrentLanguage"></param>
        public void InitLanguages(Dict Content, List<Language> Languages, Guid CurrentLanguage)
        {
            if (Content == null)
            {
                throw new ArgumentNullException("Content");
            }
            this.Content = Content;
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
