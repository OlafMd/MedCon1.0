using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DLWebFormsTemplates.Controls
{
    

    [DefaultProperty("Value")]
    [ToolboxData("<{0}:DLUpDownControl runat=server></{0}  :DLUpDownControl>")]
    public class DLUpDownControl : WebControl, IPostBackDataHandler, INamingContainer
    {

        protected const string UP_FUNC = "__UpDown_Up";
        protected const string DOWN_FUNC = "__UpDown_Down";
        protected string CHECK_FUNC = "__UpDown_Check";

        private TextBox valueTextBox;
        private LinkButton upButton;
        private LinkButton downButton;

        private bool renderClientScript;
        private static readonly object ValueChangedKey = new object();
        private static readonly object UpButtonClickKey = new object();
        private static readonly object DownButtonClickKey = new object();
        

        public DLUpDownControl()
            : base(HtmlTextWriterTag.Div)
        {
            renderClientScript = false;
            
        }

        public virtual bool EnableClientScript
        {
            get
            {
                EnsureChildControls();
                object script = ViewState["EnableClientScript"];
                if (script == null)
                    return true;
                else
                    return (bool)script;
            }
            set
            {
                EnsureChildControls();
                ViewState["EnableClientScript"] = value;
            }
        }

        public virtual int MinValue
        {
            get
            {
                EnsureChildControls();
                object min = ViewState["MinValue"];
                return (min == null) ? 0 : (int)min;
            }
            set
            {
                EnsureChildControls();
                if (value < MaxValue)
                    ViewState["MinValue"] = value;
                else throw new ArgumentException(
                "MinValue must be less than MaxValue.", "MinValue");
            }
        }

        public virtual int MaxValue
        {
            get
            {
                EnsureChildControls();
                object max = ViewState["MaxValue"];
                return (max == null) ? System.Int32.MaxValue : (int)max;
            }
            set
            {
                EnsureChildControls();
                if (value > MinValue)
                    ViewState["MaxValue"] = value;
                else throw new ArgumentException(
                    "MaxValue must be greater than MinValue.", "MaxValue");
            }
        }

        public int Increment
        {
            get
            {
                EnsureChildControls();
                object inc = ViewState["Increment"];
                return (inc == null) ? 1 : (int)inc;
            }
            set
            {
                EnsureChildControls();
                if (value > 0)
                    ViewState["Increment"] = value;
            }
        }

        public new double Width
        {
            get
            {
                EnsureChildControls();
                object inc = ViewState["Width"];
                return (inc == null) ? 45 : (double)inc;
            }
            set
            {
                EnsureChildControls();
                if (value > 0)
                {
                    ViewState["Width"] = value;
                    valueTextBox.Width = Unit.Pixel((int)value-30); //Unit.Pixel((int)value-20);

                }
            }
        }

        public string CssForTextBox
        {
            get
            {
                EnsureChildControls();
                object inc = ViewState["CssForTextBox"];
                return (string) inc;
            }
            set
            {
                EnsureChildControls();
                ViewState["CssForTextBox"] = value;
                valueTextBox.CssClass = value;
            }
        }

        public string CssForUpButton
        {
            get
            {
                EnsureChildControls();
                object inc = ViewState["CssForUpButton"];
                return (string)inc;
            }
            set
            {
                EnsureChildControls();
                ViewState["CssForUpButton"] = value;
                upButton.CssClass = value;
            }
        }

        public string CssForDownButton
        {
            get
            {
                EnsureChildControls();
                object inc = ViewState["CssForDownButton"];
                return (string)inc;
            }
            set
            {
                EnsureChildControls();
                ViewState["CssForDownButton"] = value;
                downButton.CssClass = value;
            }
        }

        public int Value
        {
            get
            {
                EnsureChildControls();
                object value = ViewState["value"];
                return (value != null) ? (int)value : 0;
            }
            set
            {
                EnsureChildControls();
                if ((value <= MaxValue) && (value >= MinValue))
                {
                    valueTextBox.Text = value.ToString();
                    ViewState["value"] = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Value",
                        "Value must be between MinValue and MaxValue.");
                }
            }
        }

        public bool DefaultBehavior
        {
            get
            {
                EnsureChildControls();
                object defaultBehavior = (bool)ViewState["defaultbehavior"];
                return (defaultBehavior != null) ? (bool)defaultBehavior : true;
            }
            set
            {
                ViewState["defaultbehavior"] = value;
            }
        }

        protected void DetermineRenderClientScript()
        {
            if (EnableClientScript)
            {
                if ((Page != null) && (Page.Request != null))
                {
                    HttpBrowserCapabilities caps = Context.Request.Browser;
                    
                    if (caps.EcmaScriptVersion.Major >= 1 &&
                    caps.W3CDomVersion.Major >= 1)
                    {
                        renderClientScript = true;
                    }
                }
            }
        }

        

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            

            DetermineRenderClientScript();

            string scriptInvoke = "";
            if (renderClientScript)
            {
                scriptInvoke = this.CHECK_FUNC + "('" +
                               valueTextBox.ClientID + "'," + this.MinValue + "," + this.MaxValue + ")";
                valueTextBox.Attributes.Add("onblur", scriptInvoke);

            }

            if (renderClientScript)
            {
                scriptInvoke = UP_FUNC + "('" + valueTextBox.ClientID +
                               "'," + this.MinValue + "," + this.MaxValue + "," + this.Increment
                               + "); return false;";
                upButton.Attributes.Add("onclick", scriptInvoke);
            }

            if (renderClientScript)
            {
                scriptInvoke = DOWN_FUNC + "('" + valueTextBox.ClientID +
                               "'," + this.MinValue + "," + this.MaxValue + "," + this.Increment
                               + "); return false;";
                downButton.Attributes.Add("onclick", scriptInvoke);
            }

            Page.RegisterRequiresPostBack(this);

            
        }

        
        public override ControlCollection Controls
        {
            get
            {
                EnsureChildControls();
                return base.Controls;
            }
        }

        protected override void CreateChildControls()
        {
            Controls.Clear();

            upButton = new LinkButton();
            upButton.ID = "UpButton";
            upButton.Width = Unit.Pixel(15);
            upButton.CssClass = CssForUpButton;
            upButton.Click += new System.EventHandler(__UpButtonClick);
            Controls.Add(upButton);

            valueTextBox = new TextBox();
            valueTextBox.ID = "InputText";
            valueTextBox.Width = Unit.Pixel((int)Width);
            valueTextBox.CssClass = CssForTextBox;
            valueTextBox.ReadOnly = false;
            valueTextBox.AutoPostBack = false;
            

            Controls.Add(valueTextBox);

            
            downButton = new LinkButton();
            downButton.ID = "DownButton";
            downButton.Width = Unit.Pixel(15);
            downButton.CssClass = CssForDownButton; 
            downButton.Click += new System.EventHandler(__DownButtonClick);
            Controls.Add(downButton);


        }

        

        public virtual void SetFocus()
        {
            valueTextBox.Focus();
        }

        public void __UpButtonClick(object source, EventArgs e)
        {

            if (!DefaultBehavior)
            {
                OnUpButtonClick(EventArgs.Empty);
                
            }
            else
            {

                if ((Value <= MaxValue) && (Value >= MinValue))
                {
                    OnUpButtonClick(EventArgs.Empty);
                
                }
            }
        }

        public void __DownButtonClick(object source, EventArgs e)
        {
            if (!DefaultBehavior)
            {
                  OnDownButtonClick(EventArgs.Empty);
                  
            }
            else
            {
                if ((Value <= MaxValue) && (Value >= MinValue))
                {
                    OnDownButtonClick(EventArgs.Empty);
                    
                }
            }
        }
        
        public event EventHandler ValueChanged
        {
            add
            {
                Events.AddHandler(ValueChangedKey, value);
            }
            remove
            {
                Events.RemoveHandler(ValueChangedKey, value);
            }
        }

        public event EventHandler UpButtonClick
        {
            add
            {
                Events.AddHandler(UpButtonClickKey, value);
            }
            remove
            {
                Events.RemoveHandler(UpButtonClickKey, value);
            }
        }

        public event EventHandler DownButtonClick
        {
            add
            {
                Events.AddHandler(DownButtonClickKey, value);
            }
            remove
            {
                Events.RemoveHandler(DownButtonClickKey, value);
            }
        }

        protected virtual void OnValueChanged(EventArgs e)
        {
            EventHandler valueChangedEventDelegate =
                (EventHandler)Events[ValueChangedKey];
            if (valueChangedEventDelegate != null)
            {
                valueChangedEventDelegate(this, e);
            }
        }

        protected virtual void OnUpButtonClick(EventArgs e)
        {
            EventHandler upButtonClickEventDelegate =
                (EventHandler)Events[UpButtonClickKey];
            if (upButtonClickEventDelegate != null)
            {
                upButtonClickEventDelegate(this, e);
            }
        }

        protected virtual void OnDownButtonClick(EventArgs e)
        {
            EventHandler downButtonClickEventDelegate =
                (EventHandler)Events[DownButtonClickKey];
            if (downButtonClickEventDelegate != null)
            {
                downButtonClickEventDelegate(this, e);
            }
        }

        void IPostBackDataHandler.RaisePostDataChangedEvent()
        {
            OnValueChanged(EventArgs.Empty);
        }

        public bool LoadPostData(string postDataKey, System.Collections.Specialized.NameValueCollection postCollection)
        {
            bool changed = false;
            // grab the value posted by the textbox
            string postedValue = postCollection[valueTextBox.UniqueID];
            int postedNumber = 0;
            try
            {
                postedNumber = System.Int32.Parse(postedValue);
                if (!Value.Equals(postedNumber))
                    changed = true;
                Value = postedNumber;
            }
            catch (FormatException fe)
            {
                changed = false;
            }

            

            return changed;
        }
    }
}
