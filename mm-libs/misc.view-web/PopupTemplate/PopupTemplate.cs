using System;
using System.ComponentModel;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace PopupTemplate
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:PopupTemplate runat=server Visible=false><ContentDivTemplate></ContentDivTemplate></{0}:PopupTemplate>")]
    [ParseChildren(true)]
    public class PopupTemplate : Panel, INamingContainer, IPostBackEventHandler
    {
        //------------JAVASCRIPT CODE ---------------------------------------------------------------------
        private static readonly string CANCEL_BUBBLE = @"if (event.stopPropagation) {event.stopPropagation();} else if (window.event) {window.event.cancelBubble = true;}";

        //------------------------PRIVATE ATTRIBUTES ------------------------------------------

        private ITemplate contentDivTemplate;
        private Control contentDivTemplateContainer;

        //------------------------PUBLIC PROPERTIES -------------------------------------------

        public Control ContentDivTemplateContainer
        {
            get
            {
                return contentDivTemplateContainer;
            }
        }

        [TemplateContainer(typeof(ContentDivTemplateContainer))]
        public ITemplate ContentDivTemplate
        {
            get
            {
                return contentDivTemplate;
            }
            set
            {
                contentDivTemplate = value;
            }
        }

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("No title")]
        [Localizable(true)]
        public string Title
        {
            get
            {
                String s = (String)ViewState["Title"];
                return ((s == null) ? "No title" : s);
            }

            set
            {
                ViewState["Title"] = value;
            }
        }

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("Ok")]
        [Localizable(true)]
        public string OkButtonText
        {
            get
            {
                String s = (String)ViewState["OkButtonText"];
                return ((s == null) ? "Ok" : s);
            }

            set
            {
                ViewState["OkButtonText"] = value;
            }
        }

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue(true)]
        public bool OkButtonVisible
        {
            get
            {
                var s = ViewState["OkButtonVisible"];
                return (s == null) ? true : (bool)s;
            }

            set
            {
                ViewState["OkButtonVisible"] = value;
            }
        }

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("Cancel")]
        [Localizable(true)]
        public string CancelButtonText
        {
            get
            {
                String s = (String)ViewState["CancelButtonText"];
                return ((s == null) ? "Cancel" : s);
            }

            set
            {
                ViewState["CancelButtonText"] = value;
            }
        }

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue(true)]
        public bool CancelButtonVisible
        {
            get
            {
                var s = ViewState["CancelButtonVisible"];
                return (s == null) ? true : (bool)s;
            }

            set
            {
                ViewState["CancelButtonVisible"] = value;
            }
        }

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public string ContentDivCssClass
        {
            get
            {
                String s = (String)ViewState["ContentDivCssClass"];
                return s;
            }

            set
            {
                ViewState["ContentDivCssClass"] = value;
            }
        }

        //------------EVENT HANDLER DEFINITIONS ----------------------------------------------------------------------

        private static readonly object CancelEvent = new object();
        private static readonly object ConfirmEvent = new object();
        private static readonly object PreShowEvent = new object();
        private static readonly object PostShowEvent = new object();
        private static readonly object PreHideEvent = new object();
        private static readonly object PostHideEvent = new object();
        private static readonly object InternalHandlersEvent = new object();

        /// <summary>
        /// Defines what happens if the Cancel button is clicked.
        /// </summary>
        public event EventHandler Cancel
        {
            add
            {
                Events.AddHandler(CancelEvent, value);
            }
            remove
            {
                Events.RemoveHandler(CancelEvent, value);
            }
        }

        /// <summary>
        /// Defines what happens if the Confirm button is clicked.
        /// </summary>
        public event EventHandler Confirm
        {
            add
            {
                Events.AddHandler(ConfirmEvent, value);
            }
            remove
            {
                Events.RemoveHandler(ConfirmEvent, value);
            }
        }

        /// <summary>
        /// This event is fired right before the popup becomes visible. Use it for instantiation
        /// of controls inside the popup and similar actions.
        /// </summary>
        public event EventHandler PreShow
        {
            add
            {
                Events.AddHandler(PreShowEvent, value);
            }
            remove
            {
                Events.RemoveHandler(PreShowEvent, value);
            }
        }

        /// <summary>
        /// This event is fired right after the popup becomes visible.
        /// </summary>
        public event EventHandler PostShow
        {
            add
            {
                Events.AddHandler(PostShowEvent, value);
            }
            remove
            {
                Events.RemoveHandler(PostShowEvent, value);
            }
        }

        /// <summary>
        /// This event is fired right before the popup is hidden. Use it for cleanup
        /// of controls inside the popup and similar actions.
        /// </summary>
        public event EventHandler PreHide
        {
            add
            {
                Events.AddHandler(PreHideEvent, value);
            }
            remove
            {
                Events.RemoveHandler(PreHideEvent, value);
            }
        }

        /// <summary>
        /// This event is fired right after the popup is hidden.
        /// </summary>
        public event EventHandler PostHide
        {
            add
            {
                Events.AddHandler(PostHideEvent, value);
            }
            remove
            {
                Events.RemoveHandler(PostHideEvent, value);
            }
        }

        /// <summary>
        /// This event is before rendering the control. Use this event handler to set event handlers of the 
        /// controls inside of the template.
        /// </summary>
        public event EventHandler InternalHandlers
        {
            add
            {
                Events.AddHandler(InternalHandlersEvent, value);
            }
            remove
            {
                Events.RemoveHandler(InternalHandlersEvent, value);
            }
        }

        /// <summary>
        /// This method returns control from ContentDivTemplateContainer by ControlName
        /// </summary>
        public Control FindControllFromContentDiv(String controlName)
        {
            return this.ContentDivTemplateContainer.FindControl(controlName);
        }

        // ------------------------------ EVENT HANDLERS ---------------------------------------------

        /// <summary>
        /// Handle postbacks
        /// </summary>
        /// <param name="eventArgument"></param>
        public void RaisePostBackEvent(string eventArgument)
        {
            //Confirm
            if (eventArgument == "ConfirmClicked")
            {
                OnConfirm(EventArgs.Empty);
            }
            else if (eventArgument == "CancelClicked")
            {
                OnCancel(EventArgs.Empty);
            }


            //refresh children
            CreateChildControls();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnConfirm(EventArgs e)
        {
            EventHandler confirmEventDelegate = (EventHandler)Events[ConfirmEvent];
            if (confirmEventDelegate != null)
            {
                confirmEventDelegate(this, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnCancel(EventArgs e)
        {
            EventHandler cancelEventDelegate = (EventHandler)Events[CancelEvent];
            if (cancelEventDelegate != null)
            {
                cancelEventDelegate(this, e);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnPreShow(EventArgs e)
        {
            EventHandler preShowEventDelegate = (EventHandler)Events[PreShowEvent];
            if (preShowEventDelegate != null)
            {
                preShowEventDelegate(this, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnPostShow(EventArgs e)
        {
            EventHandler postShowEventDelegate = (EventHandler)Events[PostShowEvent];
            if (postShowEventDelegate != null)
            {
                postShowEventDelegate(this, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnPreHide(EventArgs e)
        {
            EventHandler preHideEventDelegate = (EventHandler)Events[PreHideEvent];
            if (preHideEventDelegate != null)
            {
                preHideEventDelegate(this, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnPostHide(EventArgs e)
        {
            EventHandler postHideEventDelegate = (EventHandler)Events[PostHideEvent];
            if (postHideEventDelegate != null)
            {
                postHideEventDelegate(this, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnInternalHandlers(EventArgs e)
        {
            EventHandler internalHandlersEventDelegate = (EventHandler)Events[InternalHandlersEvent];
            if (internalHandlersEventDelegate != null)
            {
                internalHandlersEventDelegate(this, e);
            }
        }

        //------------------- OVERRIDDEN METHODS -----------------------------------------------------

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnDataBinding(EventArgs e)
        {
            EnsureChildControls();
            base.OnDataBinding(e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            EnsureJavascriptRegistration();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            EnsureStyleSheetRegistration();
            CreateChildControls();
        }

        //------------------- DISPLAYING --------------------------------------------------------------

        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        protected override void AddAttributesToRender(HtmlTextWriter writer)
        {
            base.AddAttributesToRender(writer);
            writer.AddAttribute(HtmlTextWriterAttribute.Name, this.UniqueID);

            writer.AddAttribute(HtmlTextWriterAttribute.Class, "popup popup-small" + this.CssClass);

        }

        /// <summary>
        /// 
        /// </summary>
        protected void CreateChildControls()
        {

            Controls.Clear();

            ClientScriptManager csm = Page.ClientScript;

            if (ContentDivTemplate != null)
            {
                contentDivTemplateContainer = new ContentDivTemplateContainer(this);
                ContentDivTemplate.InstantiateIn(contentDivTemplateContainer);
                string cssClass = (String.IsNullOrEmpty(this.ContentDivCssClass) ? "" : " class='" + this.ContentDivCssClass + "'");

                //-- title
                Controls.Add(new LiteralControl("<h1>" + this.Title + "</h1>"));

                Controls.Add(new LiteralControl("<div" + cssClass + ">"));
                Controls.Add(contentDivTemplateContainer);
                Controls.Add(new LiteralControl("</div>"));

                //-- buttons
                Controls.Add(new LiteralControl("<div class='buttons'>"));

                string jsStr = "";

                if (OkButtonVisible)
                {
                    jsStr = CANCEL_BUBBLE + @csm.GetPostBackEventReference(this, "ConfirmClicked");
                    Controls.Add(new LiteralControl("<a class='button-confirm' onclick=\"" + jsStr + "\">" + this.OkButtonText + "</a>"));
                }

                if (CancelButtonVisible)
                {
                    jsStr = CANCEL_BUBBLE + @csm.GetPostBackEventReference(this, "CancelClicked");
                    Controls.Add(new LiteralControl("<a class='button-confirm' onclick=\"" + jsStr + "\">" + this.CancelButtonText + "</a>"));
                }

                Controls.Add(new LiteralControl("</div>"));

                //--corners
                //Controls.Add(new LiteralControl("<i class='lt'></i>"));
                //Controls.Add(new LiteralControl("<i class='lb'></i>"));
                //Controls.Add(new LiteralControl("<i class='rt'></i>"));
                //Controls.Add(new LiteralControl("<i class='rb'></i>"));
            }
            else
            {
                Controls.Add(new LiteralControl(this.ID));
            }

            OnInternalHandlers(EventArgs.Empty);
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
        /// Invokes preshow, sets the visibility of the whole component to true and invokes postshow.
        /// </summary>
        public void Show()
        {
           
            OnPreShow(EventArgs.Empty);
            this.Visible = true;
            OnPostShow(EventArgs.Empty);
        }

        /// <summary>
        /// Invokes prehide, sets the visibility of the whole component to false and invokes posthide.
        /// </summary>
        public void Hide()
        {
            EnsureChildControls();
            OnPreHide(EventArgs.Empty);
            this.Visible = false;
            OnPostHide(EventArgs.Empty);
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
                                this.GetType(), "PopupTemplate.Styles.main.css");

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
        /// Adds needed scripts to the page
        /// </summary>
        private void EnsureJavascriptRegistration()
        {

            // We need <head runat="server"> for this code to work
            if (this.Page.Header == null)
                throw new NotSupportedException(@"No <head runat=server> control found in page.");


            // Get the js resource URL
            var scriptUrl = this.Page.ClientScript.GetWebResourceUrl(
                                this.GetType(), "PopupTemplate.Scripts.PopupTemplate.js");

            // Check if this stylesheet is already registered
            var alreadyRegistered = Page.ClientScript.IsStartupScriptRegistered("jsForPopupTemplate");
            if (!alreadyRegistered)
            {
                // If not, register it
                string scriptBlock =
                   @"<script type=""text/javascript"">

                        Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(InitialiseSettings);

                        function InitialiseSettings() {

                            var $popup = $('.popup'),
                                $popupHeight = $popup.height(),
                                $winHeight = $(window).height();
                            $centerPopUp = $winHeight / 2 - $popupHeight / 2;

                            $popup.wrap('<div class=""popup-wrapper""></div>');
                            $popup.css('top', $centerPopUp + 'px');
                        }
                   </script>";

                Page.ClientScript.RegisterStartupScript(typeof(Page), "jsForPopupTemplate", scriptBlock);
            }
        }
    }
}
