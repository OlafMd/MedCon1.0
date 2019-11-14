using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Threading;
using System.Web.UI;

namespace InputValidationWrapper
{
	/// <summary>
	/// This control is a wrapper for other input controls which checks their validity according to specified backend checks.
	/// ControlToValidateID proprty MUST be specify for the validation wrapper to work! The child control can be TextBox or a DropDOwnList.
	/// 
	/// Backend checks are performed by invoking one of the validation functions in Validations.cs file (mandatory, integer, etc.) 
	/// Backend checks are performed if the names of validation functions are specified as semicollon separated values in the BackendValidationRules property of the wrapper.
	/// All functions by default except one parameter, which is the value of the validated input control. If a function excepts additional parameters, they should be stated next to the validation 
	/// function name separated with '|'.
    /// The first validation function which returns a false will set the component into the triggered state.
    /// 
    /// The user may use external validation functions in the same way as predefined functions by implementing an event hadler for OnExternalBackendValidation event. User must specify the behavior,
    /// i.e. what happens if the value is illegal.
    /// Built-in checks (if any) are always performed before the custom ones.
    /// 
    /// Available built-in functions and their format:
    /// --- for TEXT BOX child control 
    /// 1. mandatory - value must be specified
    /// 2. isinteger - value must be an integer
    /// 3. isdouble - value must be a double
    /// 4. ispositive - value must be a positive number
    /// 5. isnegative - value must be a negative number
    /// 6. decimals|numOfDecimals - value must be a double with numOfDecimals number if decimal digits
    /// 7. isinrange|minInclusive|maxExclusive - value must be a number between minInclusive and maxExclusive
    /// 8. isnotinrange|minInclusive|maxExclusive - value must be a number NOT between minInclusive and maxExclusive
    /// 9. isdate|dateFormat(optional)|culture(optional) - value must be a valid date in dateFormat (or current culture's format if not specified) for culture (or current culture if not specified) 
    /// 10. isdateinrange|minInclusive|maxExclusive|dateFormat(optional)|culture(optional)
    /// 11. isdatenotinrange|minInclusive|maxExclusive|dateFormat(optional)|culture(optional)
    /// 12. isvalidemail - value must be a valid email address
	/// 
	/// </summary>
	[DefaultProperty("Text")]
	[ToolboxData("<{0}:InputValidationWrapper Text='error' runat=server ControlToValidateID='' MessageType='error'><ContentTemplate></ContentTemplate></{0}:InputValidationWrapper>")]
	[ParseChildren(true)]
	public class InputValidationWrapper : Panel, INamingContainer, IPostBackEventHandler
	{
		//------------JAVASCRIPT CODE ---------------------------------------------------------------------
		private static readonly string CANCEL_BUBBLE = @"if (event.stopPropagation) {event.stopPropagation();} else if (window.event) {window.event.cancelBubble = true;}";

		//------------------------PRIVATE ATTRIBUTES ------------------------------------------

		private ITemplate contentTemplate;
		private Control componentHolder;


		//private HiddenField stateHolder;
		//------------------------PUBLIC PROPERTIES -------------------------------------------

		public Control ComponentHolder
		{
			get
			{
				return componentHolder;
			}
		}

		[TemplateContainer(typeof(ComponentHolder))]
		public ITemplate ContentTemplate
		{
			get
			{
				return contentTemplate;
			}
			set
			{
				contentTemplate = value;
			}
		}

		/// <summary>
		/// Error or warning text to be displayed if an error or a warning has occured.
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
		/// error - error sign will appear if the validated child control value doesn't satify conditions
		/// warning - error sign will appear if the validated child control value doesn't satify conditions
		/// </summary>
		[Bindable(true)]
		[Category("Behavior")]
		[DefaultValue("error")]
		public string MessageType
		{
			get
			{
				var s = ViewState["MessageType"];
				return ((s == null) ? "" : (string)s);
			}

			set
			{
				ViewState["MessageType"] = value;
			}
		}

		[Bindable(true)]
		[Category("Behavior")]
		[DefaultValue("")]
		public string ControlToValidateID
		{
			get
			{
				var s = ViewState["ControlToValidateID"];
				return ((s == null) ? "" : (string)s);
			}

			set
			{
				ViewState["ControlToValidateID"] = value;
			}
		}

		/// <summary>
		/// Backend checks to be performed when validated child control looses focus.
		/// </summary>
		[Bindable(true)]
		[Category("Behavior")]
		[DefaultValue("")]
		public string BackendValidationRules
		{
			get
			{
				var s = ViewState["BackendValidationRules"];
				return ((s == null) ? "" : (string)s);
			}

			set
			{
				ViewState["BackendValidationRules"] = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[Bindable(true)]
		[Category("Behavior")]
		[DefaultValue("")]
		public string TriggeredState
		{
			get
			{
				var s = ViewState["TriggeredState"];
				return ((s == null) ? "" : (string)s);
			}

			set
			{
				ViewState["TriggeredState"] = value;
			}
		}


		//------------EVENT HANDLER DEFINITIONS ----------------------------------------------------------------------

		private static readonly object ExternalBackendValidationEvent = new object();

		/// <summary>
		/// Defines what happens on child control focus is lost.
		/// </summary>
		public event EventHandler ExternalBackendValidation
		{
			add
			{
				Events.AddHandler(ExternalBackendValidationEvent, value);
			}
			remove
			{
				Events.RemoveHandler(ExternalBackendValidationEvent, value);
			}
		}

		// ------------------------------ EVENT HANDLERS ---------------------------------------------

        

		/// <summary>
		/// Handle postbacks
		/// </summary>
		/// <param name="eventArgument"></param>
		public void RaisePostBackEvent(string eventArgument)
		{

            if (eventArgument == "RunValidation")
			{
				
                //internal validations for a text box
				if (GetChildControl() is TextBox) {
                    string value = "";
					TextBox tb = GetChildControl() as TextBox;
					value = tb.Text;

                    string[] rules = BackendValidationRules.Split(';');
                    foreach (string rule in rules)
                    {
                        if (!String.IsNullOrEmpty(rule))
                        {
                            string[] fragments = rule.Split('|');
                            if (fragments.Length > 0)
                            {
                                string method = fragments[0].ToLower();
                                if (method == "mandatory")
                                {
                                    if (!Validations.Mandatory(value)) { SetState(); return; }
                                    else { RemoveState(); }                        
                                }
                                else if (method == "isinteger")
                                {
                                    if (!Validations.IsInteger(value)) { SetState(); return; }
                                    else { RemoveState(); }      
                                }
                                else if (method == "isdouble")
                                {
                                    if (!Validations.IsDouble(value)) { SetState(); return; }
                                    else { RemoveState(); }      
                                }
                                else if (method == "ispositive")
                                {
                                    if (!Validations.IsPositive(value)) { SetState(); return; }
                                    else { RemoveState(); }      
                                }
                                else if (method == "isnegative")
                                {
                                    if (!Validations.IsNegative(value)) { SetState(); return; }
                                    else { RemoveState(); }      
                                }
                                else if (method == "decimals")
                                {
                                    try
                                    {
                                        if (!Validations.Decimals(value, Int32.Parse(fragments[1]))) { SetState(); return; }
                                        else { RemoveState(); }      
                                    }
                                    catch
                                    {
                                        throw new FormatException("Illegal validation method format: " + method);
                                    }
                                }
                                else if (method == "isinrange")
                                {
                                    try
                                    {
                                        if (!Validations.IsInRange(value, Double.Parse(fragments[1]), Double.Parse(fragments[2]))) { SetState(); return; }
                                        else { RemoveState(); }
                                    }
                                    catch
                                    {
                                        throw new FormatException("Illegal validation method format: " + method);
                                    }
                                }
                                else if (method == "isnotinrange")
                                {
                                    try
                                    {
                                        if (!Validations.IsNotInRange(value, Double.Parse(fragments[1]), Double.Parse(fragments[2]))) { SetState(); return; }
                                        else { RemoveState(); }
                                    }
                                    catch
                                    {
                                        throw new FormatException("Illegal validation method format: " + method);
                                    }
                                }
                                else if (method == "isdate")
                                {
                                    try
                                    {
                                        if (!Validations.IsDate(value, (fragments.Length<2 ? null : fragments[1]), (fragments.Length<3? null : fragments[2]))) 
                                        { SetState(); return; }
                                        else { RemoveState(); }
                                    }
                                    catch
                                    {
                                        throw new FormatException("Illegal validation method format: " + method);
                                    }
                                }
                                else if (method == "isdateinrange")
                                {
                                    try
                                    {
                                        DateTime minInclusive = DateTime.Parse(fragments[1], Thread.CurrentThread.CurrentCulture);
                                        DateTime maxExclusive = DateTime.Parse(fragments[2], Thread.CurrentThread.CurrentCulture);
                                        if (!Validations.IsDateInRange(value, minInclusive, maxExclusive, (fragments.Length < 4 ? null : fragments[3]), (fragments.Length < 5 ? null : fragments[4])))
                                        { SetState(); return; }
                                        else { RemoveState(); }
                                    }
                                    catch
                                    {
                                        throw new FormatException("Illegal validation method format: " + method);
                                    }
                                }
                                else if (method == "isdatenotinrange")
                                {
                                    try
                                    {
                                        DateTime minInclusive = DateTime.Parse(fragments[1], Thread.CurrentThread.CurrentCulture);
                                        DateTime maxExclusive = DateTime.Parse(fragments[2], Thread.CurrentThread.CurrentCulture);
                                        if (!Validations.IsDateNotInRange(value, minInclusive, maxExclusive, (fragments.Length < 4 ? null : fragments[3]), (fragments.Length < 5 ? null : fragments[4])))
                                        { SetState(); return; }
                                        else { RemoveState(); }
                                    }
                                    catch
                                    {
                                        throw new FormatException("Illegal validation method format: " + method);
                                    }
                                }
                                else if (method == "isvalidemail")
                                {
                                    if (!Validations.IsValidEmail(value)) { SetState(); return; }
                                    else { RemoveState(); }
                                }
                                else
                                {
                                    throw new ArgumentException("Not supported validation method: " + method);
                                }
                            }
                            else {
                                throw new FormatException("Illegal validation rule format: " + rule);
                            }
                        }
                     }
				    
                }
                //internal validations for a dropdown list
                else if (GetChildControl() is DropDownList)
                {
                    DropDownList ddl = GetChildControl() as DropDownList;
                    int index = ddl.SelectedIndex;
                    string[] rules = BackendValidationRules.Split(';');
                    foreach (string rule in rules)
                    {
                        if (!String.IsNullOrEmpty(rule))
                        {
                            string[] fragments = rule.Split('|');
                            if (fragments.Length > 0)
                            {
                                string method = fragments[0].ToLower();
                                if (method == "isselectedindex")
                                {
                                    try
                                    {
                                        if (!Validations.IsSelectedIndex(index, Int32.Parse(fragments[1]))) { SetState(); return; }
                                        else { RemoveState(); }

                                    }
                                    catch
                                    {
                                        throw new FormatException("Illegal validation method format: " + method);
                                    }
                                }
                                else
                                {
                                    throw new ArgumentException("Not supported validation method: " + method);
                                }
                            }
                        }
                    }
                }
                else
                {
                    throw new ArgumentException("Not supported child control: " + GetChildControl().GetType());
                }

                //External validation if any
                OnExternalBackendValidation(EventArgs.Empty);
			}
			

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="e"></param>
		protected virtual void OnExternalBackendValidation(EventArgs e)
		{
			EventHandler externalBackendValidationEventDelegate = (EventHandler)Events[ExternalBackendValidationEvent];
			if (externalBackendValidationEventDelegate != null)
			{
				externalBackendValidationEventDelegate(this, e);
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
		protected override void OnInit(EventArgs e)
		{
            this.ClientIDMode = System.Web.UI.ClientIDMode.AutoID;
			CssClass += " validate";
            EnsureHiddenFields();
			EnsureStyleSheetRegistration();
			EnsureJavascriptRegistration();
			base.OnInit(e);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="e"></param>
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="e"></param>
		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);

		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        protected override void Render(HtmlTextWriter writer)
        {
            base.Render(writer);
        }


		//------------------- DISPLAYING --------------------------------------------------------------

		/// <summary>
		/// Attributes of the wrapper
		/// </summary>
		/// <param name="writer"></param>
		protected override void AddAttributesToRender(HtmlTextWriter writer)
		{
			base.AddAttributesToRender(writer);

			writer.AddAttribute(HtmlTextWriterAttribute.Name, this.UniqueID);

			writer.AddAttribute(HtmlTextWriterAttribute.Class, this.CssClass);
			writer.AddAttribute("TriggeredState", this.TriggeredState);



		}

		/// <summary>
		/// Rendering of the wrapper and it's child controls
		/// </summary>
		protected override void CreateChildControls()
		{

			Controls.Clear();

			if (ContentTemplate != null)
			{

				componentHolder = new ComponentHolder(this);
				ContentTemplate.InstantiateIn(componentHolder);
				
				//field to validate
				Controls.Add(componentHolder);

				foreach (Control control in componentHolder.Controls)
				{
					control.EnableViewState = true;
				}

				//triger image
				var imageUrl = this.Page.ClientScript.GetWebResourceUrl(this.GetType(), "InputValidationWrapper.Images." + (String.IsNullOrEmpty(this.MessageType) ? "error" : this.MessageType) + ".png");
                var imageTextBg = this.Page.ClientScript.GetWebResourceUrl(this.GetType(), "InputValidationWrapper.Images.bg.png");
                var imageTextBgArrow = this.Page.ClientScript.GetWebResourceUrl(this.GetType(), "InputValidationWrapper.Images.bg-arrow.png");
				string style = " style='background: url(" + imageUrl + ") no-repeat center center;'";
                string textBg = " style='background: url(" + imageTextBg + ");'";
                string textBgArrow = " style='background: url(" + imageTextBgArrow + ");'";
				
				Controls.Add(new LiteralControl("<i" + style + ">trigger</i>"));

				Controls.Add(new LiteralControl("<p" + textBg + "><label " +textBgArrow+ " class='bottom_arrow'></label>" + this.Text + "</p>"));

                ClientScriptManager csm = Page.ClientScript;

                WebControl Child = ComponentHolder.FindControl(this.ControlToValidateID) as WebControl;


                if (!(Child is TextBox))
                {
                    throw new NotSupportedException("Wrapper can validate only TextBox currently.");
                }

                //!!!the validation invoker is there purely to bypass asp's problem with posting back on 'onblur' event when the control is inside of an update panel
                //Controls.Add(new LiteralControl("<a id=\"" + this.ClientID + "_Invoker\" href=\"javascript:" + @csm.GetPostBackEventReference(this, "RunValidation") + "\">Run</a>"));
			}
			else
			{
				Controls.Add(new LiteralControl(this.ID));
			}
		}

		//------------------------------- SETUP METHODS ------------------------------------------

        /// <summary>
        /// 
        /// </summary>
        private void EnsureHiddenFields()
        {
            Page.ClientScript.RegisterHiddenField("CurrentValidationWrapper", "");
            Page.ClientScript.RegisterHiddenField("CurrentFocusedElement", "");
            Page.ClientScript.RegisterHiddenField("PendingValidationWrappers", "");
        }

		/// <summary>
		/// Adds needed stylesheets to the page
		/// </summary>
		private void EnsureStyleSheetRegistration()
		{
			// We need <head runat="server"> for this code to work
			if (this.Page.Header == null)
				throw new NotSupportedException(@"No <head runat=server> control found in page.");

			//reset css

			// Get the stylesheet resource URL
			var styleSheetUrl = this.Page.ClientScript.GetWebResourceUrl(
								this.GetType(), "InputValidationWrapper.Styles.reset.css");

			// Check if this stylesheet is already registered
			var alreadyRegistered = this.Page.Header.Controls.OfType<HtmlLink>().Any(x => x.Href.Equals(styleSheetUrl));
			if (!alreadyRegistered)
			{

				// If not, register it
				var link = new HtmlLink();
				link.Attributes["rel"] = "stylesheet";
				link.Attributes["type"] = "text/css";
				link.Attributes["href"] = styleSheetUrl;
				this.Page.Header.Controls.Add(link);
			}

			//main css

			// Get the stylesheet resource URL
			styleSheetUrl = this.Page.ClientScript.GetWebResourceUrl(
								this.GetType(), "InputValidationWrapper.Styles.main.css");

			// Check if this stylesheet is already registered
			alreadyRegistered = this.Page.Header.Controls.OfType<HtmlLink>().Any(x => x.Href.Equals(styleSheetUrl));
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
		/// Adds needed scripts to the page
		/// </summary>
		private void EnsureJavascriptRegistration()
		{

			// We need <head runat="server"> for this code to work
			if (this.Page.Header == null)
				throw new NotSupportedException(@"No <head runat=server> control found in page.");


			// Check if this js is already registered
			var alreadyRegistered = Page.ClientScript.IsStartupScriptRegistered("jsForInputValidationWrapper");
			if (!alreadyRegistered)
			{
				// If not, register it
				string scriptBlock =
				   @"<script type=""text/javascript"">

						var manager = Sys.WebForms.PageRequestManager;

						if (manager == null) {
							$(document).ready(InitialiseSettings());
						}
						else {
							Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(InitialiseSettings);


						}     

						function InitialiseSettings() {
							$('.validate').find('i').hover(
								function () {
									$(this).next('p').addClass('show');
								},
								function () {
									$(this).next('p').removeClass('show');
								});
						}          
				   </script>";

				Page.ClientScript.RegisterStartupScript(typeof(Page), "jsForInputValidationWrapper", scriptBlock);
			}

			// Get the js resource URL
			var scriptUrl = this.Page.ClientScript.GetWebResourceUrl(
								this.GetType(), "InputValidationWrapper.Scripts.Settings.js");

            alreadyRegistered = Page.ClientScript.IsStartupScriptRegistered("jsSettings");
			if (!alreadyRegistered)
			{
                string scriptBlock = @"<script type=""text/javascript"" src=""" + scriptUrl + @""" ></script>";
                Page.ClientScript.RegisterStartupScript(typeof(Page), "jsSettings", scriptBlock);

			}

			// Get the js resource URL
			scriptUrl = this.Page.ClientScript.GetWebResourceUrl(
								this.GetType(), "InputValidationWrapper.Scripts.Validations.js");

			alreadyRegistered = Page.ClientScript.IsClientScriptIncludeRegistered("jsValidations");
			if (!alreadyRegistered)
			{
				Page.ClientScript.RegisterClientScriptInclude(typeof(Page), "jsValidations", scriptUrl);
				
			}
		}

		//------------------------------ MISC METHODS --------------------------------------------
		
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public WebControl GetChildControl()
		{
			return ComponentHolder.FindControl(this.ControlToValidateID) as WebControl;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public bool IsTriggerOn()
		{
			return !String.IsNullOrEmpty(TriggeredState);
		}


		/// <summary>
		/// Adds the suitable error/warning state class to the warpper
		/// </summary>
		public void SetState()
		{
			string message = "";
			if (MessageType == "error") message = "jsError";
			if (MessageType == "warning") message = "jsWarning";
			TriggeredState = message;


            if (!this.CssClass.Contains("showTrigger"))
            {
                this.CssClass += " showTrigger";
            }
				
		}

		/// <summary>
		/// Removes the suitable error/warning state class from the warpper
		/// </summary>
		public void RemoveState()
		{
			TriggeredState = "";
            this.CssClass = this.CssClass.Replace("showTrigger", "");
		}

	}
}
