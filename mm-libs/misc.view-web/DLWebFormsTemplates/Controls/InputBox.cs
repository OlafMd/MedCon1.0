using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DLWebFormsTemplates.Controls
{

    /// <summary>
    /// Under Construction !!!
    /// </summary>
    public enum AlignType { Left, Top };
    public enum InputType { None, String, Integer, Decimal, Float, Double, Date }

    [DefaultProperty("Text")]
    [ToolboxData("<{0}:InputBox runat=server></{0}:InputBox>")]
    public class InputBox : CompositeControl
    {
        private Literal captionLiteral;
        private TextBox inputTextBox;
        private RequiredFieldValidator reqValidator;
        private RegularExpressionValidator regValidator;

        private AlignType _captionAlign = AlignType.Left;
        public AlignType CaptionAlign
        {
            get
            {
                EnsureChildControls();
                return _captionAlign;
            }
            set
            {
                EnsureChildControls();
                _captionAlign = value;
            }
        }

        private InputType _inputType;
        public InputType DataType
        {
            get
            {
                EnsureChildControls();
                return _inputType;
            }
            set
            {

                _inputType = value;
                EnsureChildControls();
            }
        }

        [
        Bindable(true),
        Category("Appearance"),
        DefaultValue(""),
        Description("The text to display on the InputTextBox.")
        ]
        public string InputText
        {
            get
            {
                EnsureChildControls();
                return inputTextBox.Text;
            }
            set
            {
                EnsureChildControls();
                inputTextBox.Text = value;
            }
        }

        [
        Bindable(true),
        Category("Default"),
        DefaultValue(""),
        Description("Caption for InputTextBox.")
        ]
        public string Caption
        {
            get
            {
                EnsureChildControls();
                return captionLiteral.Text;
            }
            set
            {
                EnsureChildControls();
                captionLiteral.Text = value;
            }
        }

        private string _reqToolTip;
        [
        Bindable(true),
        Category("Appearance"),
        DefaultValue(""),
        Description(
            "Error message for the e-mail validator.")
        ]
        public string ReqToolTip
        {
            get
            {
                EnsureChildControls();
                return _reqToolTip;
            }
            set
            {
                EnsureChildControls();
                _reqToolTip = value;
            }
        }


        private string _regToolTip;
        [
        Bindable(true),
        Category("Appearance"),
        DefaultValue(""),
        Description(
            "Error message for the e-mail validator.")
        ]
        public string RegToolTip
        {
            get
            {
                EnsureChildControls();
                return _regToolTip;
            }
            set
            {
                EnsureChildControls();
                _regToolTip = value;
            }
        }

        private string _validationGroup;
        public string ValidationGroup
        {
            get
            {
                EnsureChildControls();
                return this.inputTextBox.ValidationGroup;
            }
            set
            {
                EnsureChildControls();
                this.inputTextBox.ValidationGroup = value;
                EnsureChildControls();
            }
        }




        protected override void RecreateChildControls()
        {
            EnsureChildControls();
        }

        protected override void CreateChildControls()
        {
            Controls.Clear();

            captionLiteral = new Literal();

            inputTextBox = new TextBox();
            inputTextBox.ID = "inputTextBox";

            //inputTextBox.ValidationGroup = ValidationGroup;

            reqValidator = new RequiredFieldValidator();
            reqValidator.ID = "valReq" + inputTextBox.ID;
            reqValidator.ControlToValidate = inputTextBox.ID;
            reqValidator.ToolTip = ReqToolTip;
            reqValidator.Display = ValidatorDisplay.Dynamic;
            reqValidator.SetFocusOnError = true;
            //reqValidator.ValidationGroup = ValidationGroup;
            reqValidator.CssClass = "validator-trigger";



            regValidator = new RegularExpressionValidator();
            regValidator.ID = "valReg" + inputTextBox.ID;
            regValidator.ControlToValidate = inputTextBox.ID;
            regValidator.ToolTip = RegToolTip;
            regValidator.Display = ValidatorDisplay.Dynamic;
            regValidator.SetFocusOnError = true;
            //regValidator.ValidationGroup = ValidationGroup;
            regValidator.CssClass = "validator-trigger";
            regValidator.ValidationExpression = @"^(((0[1-9]|[12][0-9]|3[01])([\.])(0[13578]|10|12)([\.])((19[0-9][0-9])|(2[0-9][0-9][0-9])))|(([0][1-9]|[12][0-9]|30)([\.])(0[469]|11)([\.])((19[0-9][0-9])|(2[0-9][0-9][0-9])))|((0[1-9]|1[0-9]|2[0-8])([\.])(02)([\.])((19[0-9][0-9])|(2[0-9][0-9][0-9])))|((29)([\.])(02)([\.])([02468][048]00))|((29)([\.])(02)([\.])([13579][26]00))|((29)([\.])(02)([\.])([0-9][0-9][0][48]))|((29)([\.])(02)([\.])([0-9][0-9][2468][048]))|((29)([\.])(02)([\.])([0-9][0-9][13579][26])))$";

            if (DataType != InputType.None)
            {
                inputTextBox.CausesValidation = true;
                
            }

            if (DataType == InputType.Date)
            {

                inputTextBox.CssClass = "datepicker";
                

            }

            this.Controls.Add(captionLiteral);
            this.Controls.Add(inputTextBox);

            //if (DataType != InputType.None)
                this.Controls.Add(reqValidator);
            //if (DataType == InputType.Date)
                this.Controls.Add(regValidator);

            //ClearChildViewState();
        }

        protected override void Render(HtmlTextWriter writer)
        {
            AddAttributesToRender(writer);
            if (CaptionAlign == AlignType.Top)
            {
                writer.Write("<span id=" + inputTextBox.ClientID + ">");
                captionLiteral.RenderControl(writer);
                writer.WriteBreak();
                if (DataType != InputType.None)
                {
                    inputTextBox.CausesValidation = true;

                }

                if (DataType == InputType.Date)
                {

                    inputTextBox.CssClass = "datepicker";


                }
                inputTextBox.RenderControl(writer);
                EnsureChildControls();
                if (DataType != InputType.None)
                {
                    reqValidator.ValidationGroup = inputTextBox.ValidationGroup;
                    reqValidator.RenderControl(writer);
                }
                if (DataType == InputType.Date)
                {
                    
                    regValidator.ValidationGroup = inputTextBox.ValidationGroup;
                    regValidator.RenderControl(writer);
                }
                writer.Write("</span>");

            }
            else
            {
                writer.Write("<span id=" + inputTextBox.ClientID + ">");
                captionLiteral.RenderControl(writer);
                writer.Write("&nbsp;");
                inputTextBox.RenderControl(writer);
                if (DataType != InputType.None)
                {
                    reqValidator.ValidationGroup = inputTextBox.ValidationGroup;
                    reqValidator.RenderControl(writer);
                }
                if (DataType == InputType.Date)
                {
                    inputTextBox.CssClass = "datepicker";
                    regValidator.ValidationGroup = inputTextBox.ValidationGroup;
                    regValidator.RenderControl(writer);
                }
                writer.Write("</span>");

            }
        }
    }
}
