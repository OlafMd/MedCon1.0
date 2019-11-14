using System;
using System.Linq;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Web.UI;
using PasswordChange;

namespace GlobalComponents
{
    [DefaultEvent("Submit")]
    [DefaultProperty("ButtonText")]
    [ToolboxData("<{0}:PasswordChange runat=server></{0}:PasswordChange>")]

    public class PasswordChange : CompositeControl
    {
        private LinkButton lbtnSubmitButton;

        private Label lblOldPassword;
        private Label lblNewPassword;
        private Label lblRepeatNewPassword;
        private TextBox tbOldPassword;
        private TextBox tbNewPassword;
        private TextBox tbRepeatNewPassword;
        private RequiredFieldValidator rfvOldPassword;
        private CustomValidator cvOldPassword;
        private RequiredFieldValidator rfvNewPassword;
        private RequiredFieldValidator rfvRepeatNewPassword;
        private CompareValidator cvRepeatNewPassword;

        private String validationGroup = "PasswordChangeValidationGroup";
        private String requiredFieldValidatorText = String.Empty;
        private String compareValidatorText = String.Empty;
        private String customValidatorText = String.Empty;

        private static readonly object EventSubmitKey = new object();


        #region PublicMethods

        public void SetOldPasswordStatus(bool status)
        {
            cvOldPassword.IsValid = status;
        }

        public void SetPasswordChangeVisibility(bool show)
        {
            if(show)
                this.Attributes.Add("style", "display:block;");
            else
                this.Attributes.Add("style", "display:none;");
        }

        #endregion

        #region Fields

        [
        Bindable(true),
        Category("Appearance"),
        DefaultValue(""),
        Description("The text to display on the button.")
        ]
        public string ButtonText
        {
            get
            {
                EnsureChildControls();
                return lbtnSubmitButton.Text;
            }
            set
            {
                EnsureChildControls();
                lbtnSubmitButton.Text = value;
            }
        }

        [
        Bindable(true),
        Category("Appearance"),
        DefaultValue(""),
        Description("The text to display as the old password label.")
        ]
        public string LabelOldPassword
        {
            get
            {
                EnsureChildControls();
                return lblOldPassword.Text;
            }
            set
            {
                EnsureChildControls();
                lblOldPassword.Text = value;
            }
        }

        [
        Bindable(true),
        Category("Appearance"),
        DefaultValue(""),
        Description("The text to display as the new password label.")
        ]
        public string LabelNewPassword
        {
            get
            {
                EnsureChildControls();
                return lblNewPassword.Text;
            }
            set
            {
                EnsureChildControls();
                lblNewPassword.Text = value;
            }
        }

        [
        Bindable(true),
        Category("Appearance"),
        DefaultValue(""),
        Description("The text to display as the repeated password label.")
        ]
        public string LabelRepeatedNewPassword
        {
            get
            {
                EnsureChildControls();
                return lblRepeatNewPassword.Text;
            }
            set
            {
                EnsureChildControls();
                lblRepeatNewPassword.Text = value;
            }
        }

        [
        Bindable(true),
        Category("Appearance"),
        DefaultValue("PasswordChangeValidationGroup"),
        Description("Naming of validation group for control.")
        ]
        public string ValidationGroup
        {
            set
            {
                EnsureChildControls();
                validationGroup = value;
                SetValidationGroups(validationGroup);
            }
        }

       

        #endregion

        #region SupportMethods

        private void SetRequiredValidatorMessages(string message)
        {
            foreach (var validator in this.Controls.OfType<RequiredFieldValidator>())
            {               
                validator.Text = message;
            }
        }

        private void SetValidationGroups(string valGroup)
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).ValidationGroup = valGroup;
                }
                if (control is RequiredFieldValidator)
                {
                    ((RequiredFieldValidator)control).ValidationGroup = valGroup;
                }
                if (control is CompareValidator)
                {
                    ((CompareValidator)control).ValidationGroup = valGroup;
                }
                if (control is LinkButton)
                {
                    ((LinkButton)control).ValidationGroup = valGroup;
                }
            }
        }

        #endregion

        #region Validators

        [
        Bindable(true),
        Category("Appearance"),
        DefaultValue(""),
        Description("The text to display on required validator.")
        ]
        public string RequiredFieldValidatorText
        {
            get
            {
                EnsureChildControls();
                return requiredFieldValidatorText;
            }
            set
            {
                EnsureChildControls();
                requiredFieldValidatorText = value;
                SetRequiredValidatorMessages(requiredFieldValidatorText);                       
            }
        }        

        [
        Bindable(true),
        Category("Appearance"),
        DefaultValue(""),
        Description("The text to display on compare validator.")
        ]
        public string CompareValidatorText
        {
            get
            {
                EnsureChildControls();
                return compareValidatorText;               
            }
            set
            {
                EnsureChildControls();
                compareValidatorText = value;
                cvRepeatNewPassword.Text = compareValidatorText;
            }
        }

        [
        Bindable(true),
        Category("Appearance"),
        DefaultValue(""),
        Description("The text to display on custom validator.")
        ]
        public string CustomValidatorText
        {
            get
            {
                EnsureChildControls();
                return customValidatorText;
            }
            set
            {
                EnsureChildControls();
                customValidatorText = value;
                cvOldPassword.Text = customValidatorText;
            }
        }

        #endregion

        #region EventsAndActions

        [
        Category("Action"),
        Description("Raised when the user clicks the button.")
        ]
        public event EventHandler<PasswordChangeEventArgs> Submit
        {
            add
            {
                Events.AddHandler(EventSubmitKey, value);
            }
            remove
            {
                Events.RemoveHandler(EventSubmitKey, value);
            }
        }

        // The method that raises the Submit event.
        protected virtual void OnSubmit(PasswordChangeEventArgs e)
        {
            EventHandler<PasswordChangeEventArgs> SubmitHandler =
                (EventHandler<PasswordChangeEventArgs>)Events[EventSubmitKey];
            if (SubmitHandler != null)
            {
                SubmitHandler(this, e);
            }
        }

        // Handles the Click event of the Button and raises
        // the Submit event.
        private void lbtnSubmitButton_Click(object source, EventArgs e)
        {
            PasswordChangeEventArgs args = new PasswordChangeEventArgs();
            args.OldPassword = tbOldPassword.Text;
            args.NewPassword = tbNewPassword.Text;
            OnSubmit(args);
        }

        #endregion        

        #region Rendering

        protected override void RecreateChildControls()
        {
            EnsureChildControls();
        }

        protected override void CreateChildControls()
        {
            Controls.Clear();

            lblOldPassword = new Label();
            lblNewPassword = new Label();
            lblRepeatNewPassword = new Label();

            tbNewPassword = new TextBox();
            tbNewPassword.ID = "tbNewPassword";
            tbNewPassword.ValidationGroup = validationGroup;
            tbNewPassword.ClientIDMode = ClientIDMode.Static;
            tbNewPassword.TextMode = TextBoxMode.Password;

            tbOldPassword = new TextBox();
            tbOldPassword.ID = "tbOldPassword";
            tbOldPassword.ValidationGroup = validationGroup;
            tbOldPassword.ClientIDMode = ClientIDMode.Static;
            tbOldPassword.TextMode = TextBoxMode.Password;

            tbRepeatNewPassword = new TextBox();
            tbRepeatNewPassword.ID = "tbRepeatNewPassword";
            tbRepeatNewPassword.ValidationGroup = validationGroup;
            tbRepeatNewPassword.ClientIDMode = ClientIDMode.Static;
            tbRepeatNewPassword.TextMode = TextBoxMode.Password;

            rfvOldPassword = new RequiredFieldValidator();
            rfvOldPassword.ControlToValidate = tbOldPassword.ID;
            rfvOldPassword.ValidationGroup = validationGroup;
            rfvOldPassword.Display = ValidatorDisplay.Dynamic;
           
            rfvNewPassword = new RequiredFieldValidator();
            rfvNewPassword.ControlToValidate = tbNewPassword.ID;
            rfvNewPassword.ValidationGroup = validationGroup;
            rfvNewPassword.Display = ValidatorDisplay.Dynamic;

            rfvRepeatNewPassword = new RequiredFieldValidator();
            rfvRepeatNewPassword.ControlToValidate = tbRepeatNewPassword.ID;
            rfvRepeatNewPassword.ValidationGroup = validationGroup;
            rfvRepeatNewPassword.Display = ValidatorDisplay.Dynamic;

            cvRepeatNewPassword = new CompareValidator();
            cvRepeatNewPassword.ControlToValidate = tbRepeatNewPassword.ID;
            cvRepeatNewPassword.ControlToCompare = tbNewPassword.ID;
            cvRepeatNewPassword.ValidationGroup = validationGroup;
            cvRepeatNewPassword.Display = ValidatorDisplay.Dynamic;

            cvOldPassword = new CustomValidator();
            cvOldPassword.ControlToValidate = tbOldPassword.ID;
            cvOldPassword.ValidationGroup = validationGroup;
            cvOldPassword.Display = ValidatorDisplay.Dynamic;

            lbtnSubmitButton = new LinkButton();
            lbtnSubmitButton.ID = "lbtnPasswordChange";
            lbtnSubmitButton.Click += new EventHandler(lbtnSubmitButton_Click);
            lbtnSubmitButton.ValidationGroup = validationGroup;

            this.Controls.Add(lblOldPassword);
            this.Controls.Add(tbOldPassword);
            this.Controls.Add(rfvOldPassword);
            this.Controls.Add(cvOldPassword);
            this.Controls.Add(lblNewPassword);
            this.Controls.Add(tbNewPassword);
            this.Controls.Add(rfvNewPassword);
            this.Controls.Add(lblRepeatNewPassword);
            this.Controls.Add(tbRepeatNewPassword);
            this.Controls.Add(rfvRepeatNewPassword);
            this.Controls.Add(cvRepeatNewPassword);
            this.Controls.Add(lbtnSubmitButton);
        }

        protected override void Render(HtmlTextWriter writer)
        {
            AddAttributesToRender(writer);

            writer.RenderBeginTag(HtmlTextWriterTag.Div);

            lblOldPassword.RenderControl(writer);
            tbOldPassword.RenderControl(writer);
            rfvOldPassword.RenderControl(writer);
            cvOldPassword.RenderControl(writer);

            lblNewPassword.RenderControl(writer);
            tbNewPassword.RenderControl(writer);
            rfvNewPassword.RenderControl(writer);

            lblRepeatNewPassword.RenderControl(writer);
            tbRepeatNewPassword.RenderControl(writer);
            rfvRepeatNewPassword.RenderControl(writer);
            cvRepeatNewPassword.RenderControl(writer);

            lbtnSubmitButton.Attributes.Add("class", "password-change-button cancel");
            lbtnSubmitButton.RenderControl(writer);

            writer.RenderEndTag();
        }

        #endregion       
       
    }
}
