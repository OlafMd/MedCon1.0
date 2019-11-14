using System;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DLWebFormsTemplates.Controls
{
    [ToolboxData("<{0}:DeleteButton ID=dlbDelete runat=server></{0}:DeleteButton>")]
    public class DeleteButton : LinkButton
    {
        public enum ModeType { Standard, Inline };
        private DLGridView grid;

        [Bindable(true)]
        public string Question { get; set; }


        private string yesMessage;
        public string YesMessage
        {
            get
            {
                return yesMessage ?? "Yes";
            }
            set
            {
                yesMessage = value;
            }
        }

        private string noMessage;
        public string NoMessage
        {
            get
            {
                return noMessage ?? "No";
            }
            set
            {
                noMessage = value;
            }
        }

        private ModeType _mode = ModeType.Inline;
        public ModeType Mode
        {
            get { return _mode; }
            set { _mode = value; }
        }

        [Bindable(true)]
        public string Label
        {
            get { return (string)ViewState["Label"]; }
            set { ViewState["Label"] = value; }
        }

        [Bindable(true)]
        public string BindLabelFromColumn
        {
            get { return (string)ViewState["BindLabelFromColumn"]; }
            set { ViewState["BindLabelFromColumn"] = value; }
        }


        public string DependsOnGrid { get; set; }

        protected override void AddAttributesToRender(HtmlTextWriter writer)
        {
            if (string.IsNullOrEmpty(Question)) throw new Exception("Property Question must be filled!");

            String[] mess = { YesMessage, NoMessage };

            if (Mode == ModeType.Inline)
            {
                if (Label == null) throw new Exception("Property Label must be filled!");
                grid = GetParentGrid(this);
                ConfirmScript(writer, Label, mess, true);
            }
            else
            {
                if (string.IsNullOrEmpty(DependsOnGrid)) 
                    throw new Exception("Property DependsOnGrid must be filled!");
                if (string.IsNullOrEmpty(BindLabelFromColumn)) 
                    throw new Exception("Property BindLabelFromColumn must be filled!");

                //if (string.IsNullOrEmpty(Label)) throw new Exception("Property Label must be filled!");
                grid = (DLGridView)(Page as DLPageTemplate).FindControlRecursive(Page, DependsOnGrid);
                if ((grid.SelectedDataKey != null) && ( (grid.EnabledMultipleSelection == null && grid.SelectedValue != null) || (grid.EnabledMultipleSelection == true && grid.SelectedValues.Count > 0)) )
                //if (grid.SelectedRow != null)
                {

                    if (grid.content != null)
                    {
                        var contentTable = grid.content.ToTable();
                        var selectedRowIndex = grid.SelectedRow.DataItemIndex;
                        var columnIndex = contentTable.Columns.IndexOf(BindLabelFromColumn);
                        var lab = contentTable.Rows[selectedRowIndex][columnIndex].ToString();

                        ConfirmScript(writer, lab, mess, true);
                    }
                }
                else
                {
                    
                    writer.AddStyleAttribute(HtmlTextWriterStyle.Display, "none");
                }

            }

            base.AddAttributesToRender(writer);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!CssClass.Contains("icons-delete"))
                CssClass += " icons-delete";
        }

        private static DLGridView GetParentGrid(Control ctrl)
        {
            while (!(ctrl is DLGridView))
            {
                ctrl = ctrl.Parent;
            }
            return (DLGridView)ctrl;
        }

        static int GetColumnIndexByName(GridViewRow row, string columnName)
        {
            int columnIndex = 0;
            foreach (DataControlFieldCell cell in row.Cells)
            {
                if (cell.ContainingField is TemplateField)
                    if (cell.ContainingField.HeaderText.Equals(columnName))
                        break;
                columnIndex++;
            }
            return columnIndex;
        }

        private void ConfirmScript(HtmlTextWriter writer, String textParam = "", String[] buttons = null, bool cancelEventPropagation = false)
        {
            if (DesignMode) return;
            if (HttpContext.Current.Request.Browser.EcmaScriptVersion.Major < 1 || Question == null) return;
            var script = GetScript(textParam, buttons, cancelEventPropagation);
            writer.AddAttribute(HtmlTextWriterAttribute.Onclick,
                script.ToString());
        }

        private StringBuilder GetScript(String textParam, String[] buttons, bool cancelEventPropagation)
        {
            var script = new StringBuilder();
            script.Append("javascript:confirmPopUp(this,'");
            if (Question.Contains("{0}"))
                script.Append(String.Format(Question + "', ' ", textParam));
            else
                script.Append(Question + "', ' ");
            script.Append((String)HttpContext.GetGlobalResourceObject("Global", buttons[0]) + "', '");
            script.Append((String)HttpContext.GetGlobalResourceObject("Global", buttons[1]) + String.Format("' ); {0} return false;", cancelEventPropagation ? "event.cancelBubble = true;" : ""));
            return script;
        }




        // under construction
        //private string InsertValueToGlobalResources(string text)
        //{
        //    string result;
        //    if (!string.IsNullOrEmpty(text))
        //    {


        //        var globalResourceObject = HttpContext.GetGlobalResourceObject("Global", text);
        //        if (globalResourceObject != null)
        //            result = globalResourceObject.ToString();
        //        else
        //        {
        //            var filename = Page.Server.MapPath("../App_GlobalResources/Global.resx");
        //            ResourceUtility ru = new ResourceUtility(filename);
        //            ru.insertElement(text, text + " [DE]");

        //            result = text + " [DE]";
        //        }
        //        return result;
        //    }
        //    return "";
        //}

    }
}
