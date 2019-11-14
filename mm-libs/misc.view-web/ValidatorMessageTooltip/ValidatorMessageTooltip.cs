using System;
using System.ComponentModel;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace ValidatorMessageTooltip
{
    /// <summary>
    /// This control is used as a child element of an ASP validator. It displays a suitable icon depending on Type property (see Type property) which shows a tooltip on hover.
    /// Tooltip contains a message to be displayed to the user (see Text property).
    /// NOTE: This control should be added to am ASP validatior which must contain CssClass property set to "validator-trigger" in order to display the text property.
    ///       Do not set the Text property to the validator, because otherwise it will be displayed over the icon.
    ///       The control loads suitable css for both itself and the parent validator.
    ///       If you need multiple validators performed on one control, put the Display property to "Dynamic" to all but the last one (in order to avoid empty space reserved for each of them while they are invisible).
    /// </summary>
    [DefaultProperty("Text")]
    [ToolboxData("<%--Dont forget to add CssClass='validator-trigger' to the parent validator and remove its Text propery value if exists.--%>\n<{0}:ValidatorMessageTooltip runat=server Text='error' Type='error'/>")]
    public class ValidatorMessageTooltip : WebControl
    {
        /// <summary>
        /// The text which appears in the tooltip baloon. Localizable.
        /// </summary>
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

        /// <summary>
        /// Type of image which shows the tooltip on hover. Localizable.
        /// error - red exclamation mark 
        /// warning - yellow exclamation mark
        /// valida - green check mark
        /// </summary>
        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public string Type
        {
            get
            {
                String s = (String)ViewState["Type"];
                return ((s == null) ? "" : s);
            }

            set
            {
                ViewState["Type"] = value;
            }
        }

        /// <summary>
        /// Attributes of the wrapper
        /// </summary>
        /// <param name="writer"></param>
        protected override void AddAttributesToRender(HtmlTextWriter writer)
        {
            base.AddAttributesToRender(writer);

            writer.AddAttribute(HtmlTextWriterAttribute.Name, this.UniqueID);

            writer.AddAttribute(HtmlTextWriterAttribute.Class, this.CssClass);


        }

        /// <summary>
        /// Rendering of the wrapper and it's child controls
        /// </summary>
        protected override void CreateChildControls()
        {
            Controls.Clear();

            var icon = this.Page.ClientScript.GetWebResourceUrl(this.GetType(), "ValidatorMessageTooltip.Images.val-error.png");

            if (this.Type.ToLower() == "warning")
                icon = this.Page.ClientScript.GetWebResourceUrl(this.GetType(), "ValidatorMessageTooltip.Images.val-warning.png");
            if (this.Type.ToLower() == "valid")
                icon = this.Page.ClientScript.GetWebResourceUrl(this.GetType(), "ValidatorMessageTooltip.Images.val-valid.png");



            Image image = new Image();
            image.AlternateText = "error";
            image.Attributes["style"] = "position: relative; top: 2px;";
            image.ImageUrl = icon;

            Controls.Add(image);

            var imageTextBgArrow = this.Page.ClientScript.GetWebResourceUrl(this.GetType(), "ValidatorMessageTooltip.Images.val-bg-arrow.png");

            //Controls.Add(new LiteralControl("<div class='validator-message-holder' >"));
            Controls.Add(new LiteralControl("<div class='validator-message-holder' style='background: url(" + imageTextBgArrow + ") no-repeat'>"));

            var imageTextBg = this.Page.ClientScript.GetWebResourceUrl(this.GetType(), "ValidatorMessageTooltip.Images.val-bg.png");
            string textBg = "background: url(" + imageTextBg + ");";

            Label text = new Label();
            text.ID = this.UniqueID + "_Label";
            text.CssClass = "validator-message";
            text.Attributes["style"] = textBg;
            text.Text = this.Text;

            Controls.Add(text);

            Controls.Add(new LiteralControl("</div>"));
        }

        /// <summary>
        /// Adds needed stylesheets to the page
        /// </summary>
        private void EnsureStyleSheetRegistration()
        {
            // We need <head runat="server"> for this code to work
            if (this.Page.Header == null)
                throw new NotSupportedException(@"No <head runat=server> control found in page.");


            //main css

            // Get the stylesheet resource URL
            var styleSheetUrl = this.Page.ClientScript.GetWebResourceUrl(
                                this.GetType(), "ValidatorMessageTooltip.Styles.main.css");

            // Check if this stylesheet is already registered
            bool alreadyRegistered = this.Page.Header.Controls.OfType<HtmlLink>().Any(x => x.Href.Equals(styleSheetUrl));
            if (!alreadyRegistered)
            {

                // If not, register it
                var link = new HtmlLink();
                link.Attributes["rel"] = "stylesheet";
                link.Attributes["type"] = "text/css";
                link.Attributes["href"] = styleSheetUrl;
                this.Page.Header.Controls.Add(link);
            }
        }

        /// <summary>
        /// Adds needed JavaScript to the page
        /// </summary>
        private void EnsureJavaScriptRegistration()
        {
            // We need <head runat="server"> for this code to work
            if (this.Page.Header == null)
                throw new NotSupportedException(@"No <head runat=server> control found in page.");

            
            // Check if this stylesheet is already registered
            bool alreadyRegistered = this.Page.Header.Controls.OfType<HtmlLink>().Any(x => x.Href.Equals("validationMessageJS"));
            if (!alreadyRegistered)
            {
             // If not, register it
                string scriptBlock =
                   @"<script type=""text/javascript"">

                        Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(InitialisePosition);

                        function InitialisePosition() {

                            //Positioning of error messages

$('.validator-trigger').hover(function(){
        
            var $this = $(this),
                leftPosition = $this.offset().left,
                messageHolder = $this.find('.validator-message-holder'),
                windowWidth = $(window).width(),
                position = leftPosition + messageHolder.width() + 50;

                if(position > windowWidth) {

                    messageHolder.css({ marginLeft: -550 });

                    var messageWidhtFull = messageHolder.width(),
                        newPoz = messageWidhtFull + 50;

                    messageHolder.css({ marginLeft: -newPoz });
                    messageHolder.addClass('right-message');
                }

        }, function(){
            $(this).find('.validator-message-holder').removeClass('right-message').css({ marginLeft: 'auto' });
        });
                        }
                   </script>";

                Page.ClientScript.RegisterStartupScript(typeof(Page), "validationMessageJS", scriptBlock);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            EnsureStyleSheetRegistration();
            EnsureJavaScriptRegistration();
        }

    }
}
