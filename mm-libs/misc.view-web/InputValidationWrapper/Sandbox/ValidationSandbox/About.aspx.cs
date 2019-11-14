using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ValidationSandbox
{
    public partial class About : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void MySpecialValidation(object sender, EventArgs e)
        {
            InputValidationWrapper.InputValidationWrapper wrapper = sender as InputValidationWrapper.InputValidationWrapper;
            wrapper.Text = "Value must be mjau";
            TextBox Child = ((TextBox)wrapper.GetChildControl());
            var text = Child.Text;

            if (text != "mjau")
            {
                wrapper.SetState();
                
            }
            else
            {
                wrapper.RemoveState();
            }
        }

        protected override void Render(HtmlTextWriter writer)
        {
            //Page.ClientScript.RegisterForEventValidation(InputValidationWrapper1.UniqueID, "RunValidation");
            //Page.ClientScript.RegisterForEventValidation(InputValidationWrapper2.UniqueID, "RunValidation");
            //Page.ClientScript.RegisterForEventValidation(InputValidationWrapper3.UniqueID, "RunValidation");
            //Page.ClientScript.RegisterForEventValidation(InputValidationWrapper4.UniqueID, "RunValidation");
            //Page.ClientScript.RegisterForEventValidation(InputValidationWrapper5.UniqueID, "RunValidation");
            //Page.ClientScript.RegisterForEventValidation(InputValidationWrapper6.UniqueID, "RunValidation");
            //Page.ClientScript.RegisterForEventValidation(InputValidationWrapper7.UniqueID, "RunValidation");
            //Page.ClientScript.RegisterForEventValidation(InputValidationWrapper8.UniqueID, "RunValidation");
            //Page.ClientScript.RegisterForEventValidation(InputValidationWrapper9.UniqueID, "RunValidation");
            //Page.ClientScript.RegisterForEventValidation(InputValidationWrapper10.UniqueID, "RunValidation");
            //Page.ClientScript.RegisterForEventValidation(InputValidationWrapper11.UniqueID, "RunValidation");
            //Page.ClientScript.RegisterForEventValidation(InputValidationWrapper12.UniqueID, "RunValidation");
            //Page.ClientScript.RegisterForEventValidation(InputValidationWrapper13.UniqueID, "RunValidation");
            //Page.ClientScript.RegisterForEventValidation(InputValidationWrapper14.UniqueID, "RunValidation");
            base.Render(writer);

        }

    }
}
