using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.ComponentModel;
using System.Web;
using System.Windows;

namespace AutoCompleteTextBox
{

    /// <summary>
    /// AutoCompleteTextBox web control
    /// </summary>
    [DefaultProperty("Text")]
    [ValidationPropertyAttribute("SelectedItem")]
    [ToolboxData("<{0}:AutoCompleteTextBox runat=\"server\" ></{0}:AutoCompleteTextBox>")]
    public class AutoCompleteTextBox : TextBox
    {        
        public DropDownList _ddl; //this is used to keep AutoCompleteTextBox items in HTML


        protected override void OnInit(EventArgs e)
        {
            Page.RegisterRequiresControlState(this);
            base.OnInit(e);
        }

        protected override object SaveControlState()
        {


            object obj = base.SaveControlState();

            if (SelectedIndex != null)
            {
                if (obj != null)
                {
                    return new Pair(obj, SelectedIndex);
                }
                else
                {
                    return (SelectedIndex);
                }
            }
            else
            {
                return obj;
            }
        }

        protected override void LoadControlState(object state)
        {
            base.LoadControlState(state);
            if (state != null)
            {
                Pair p = state as Pair;
                if (p != null)
                {
                    base.LoadControlState(p.First);
                    SelectedIndex = (int)p.Second;
                }
                else
                {
                    if (state is int)
                    {
                        SelectedIndex = (int)state;
                    }
                    else
                    {
                        base.LoadControlState(state);
                    }
                }
            }
        }


        /// <summary>
        /// DataTextField
        /// </summary>
        [Category("Data")]
        public string SelectedValue
        {
            get
            {
                EnsureChildControls();
                return _ddl.SelectedValue;
            }
            set
            {
                EnsureChildControls();
                _ddl.SelectedValue = value;
            }
        }


        /// <summary>
        /// DataTextField
        /// </summary>
        [Category("Data")]
        public ListItem SelectedItem
        {
            get
            {
                EnsureChildControls();
                return _ddl.SelectedItem;
            }

        }

        /// <summary>
        /// DataTextField
        /// </summary>
        [Category("Data")]
        [DefaultValue(-1)]
        public int SelectedIndex
        {
            get
            {
                EnsureChildControls();
                if (this.Text != null && this.Text != "" && _ddl.SelectedItem != null && _ddl.SelectedItem.Text.StartsWith(this.Text) == true)
                {
                    return _ddl.SelectedIndex;
                }
                else
                { return -1; }
            }
            set
            {
                EnsureChildControls();

                _ddl.SelectedIndex = value;

            }
        }

        /// <summary>
        /// DataSource
        /// </summary>
        [Category("Data")]
        public object DataSource
        {
            get
            {
                EnsureChildControls();
                return _ddl.DataSource;
            }
            set
            {
                EnsureChildControls();
                _ddl.DataSource = value;
            }
        }

        /// <summary>
        /// DataSource ID
        /// </summary>
        [Category("Data")]
        public string DataSourceID
        {
            get
            {
                EnsureChildControls();
                return _ddl.DataSourceID;
            }
            set
            {
                EnsureChildControls();
                _ddl.DataSourceID = value;
            }
        }

        /// <summary>
        /// DataMember
        /// </summary>
        [Category("Data")]
        public string DataMember
        {
            get
            {
                EnsureChildControls();
                return _ddl.DataMember;
            }
            set
            {
                EnsureChildControls();
                _ddl.DataMember = value;
            }
        }

        /// <summary>
        /// DataTextField
        /// </summary>
        [Category("Data")]
        public string DataTextField
        {
            get
            {
                EnsureChildControls();
                return _ddl.DataTextField;
            }
            set
            {
                EnsureChildControls();
                _ddl.DataTextField = value;
            }
        }


        /// <summary>
        /// DataTextField
        /// </summary>
        [Category("Data")]
        public bool isSearchBox
        {
            get;
            set;
        }

        /// <summary>
        /// DataTextField
        /// </summary>
        [Category("Data")]
        public string DataValueField
        {
            get
            {
                EnsureChildControls();
                return _ddl.DataValueField;
            }
            set
            {
                EnsureChildControls();
                _ddl.DataValueField = value;
            }
        }

        /// <summary>
        /// Items
        /// </summary>
        [
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
        PersistenceMode(PersistenceMode.InnerDefaultProperty)
        ]
        public ListItemCollection Items
        {
            get
            {
                EnsureChildControls();
                return _ddl.Items;
            }
        }

        /// <summary>
        /// data bind
        /// </summary>
        public override void DataBind()
        {

            _ddl.DataBind();
        }



        /// <summary>
        /// create child controls
        /// </summary>
        protected override void CreateChildControls()
        {

            _ddl = new DropDownList();
            _ddl.TabIndex = -1;
            _ddl.AppendDataBoundItems = true;
            _ddl.Style.Add("display", "none"); //DropDownList is hidden and used as datasource in HTML markup of AutoCompleteTextBox
            Controls.Add(_ddl);
            base.CreateChildControls();



        }

        /// <summary>
        /// On Pre Render
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            //this could be included in component but there is problem with ajax reloading (this script will not be initialized on postback
            //Page.ClientScript.RegisterClientScriptResource(typeof(AutoCompleteTextBox), "AutoCompleteTextBox.Scripts.AutoCompleteTextBox.js");
        }

        /// <summary>
        /// Render
        /// </summary>
        /// <param name="writer"></param>
        protected override void Render(HtmlTextWriter writer)
        {
            EnsureChildControls();


            writer.Write("<span style=\"position:relative;\" AutoCompleteTextBox=\"1\"  >");
            base.Render(writer);
            if (this.isSearchBox == false)
                writer.Write("<span style=\"display:none\">");
            writer.Write("<img style=\"position: relative;left: -15px; \" class=\"" + base.ID + "\"  src=\"https://cdn1.iconfinder.com/data/icons/tiny-icons/search.png\" />");
            writer.Write("<img style=\"position: relative;left: -15px; \" hidden=\"true\" class=\"" + base.ID + "\" onClick=\"javascript:clearAutocomplet(this)\" src=\"http://www.feedbooks.com/images/actions/delete.png\" />");
            if (this.isSearchBox == false)
                writer.Write("</span>");
            _ddl.RenderControl(writer);
            writer.Write("<div style=\"visibility:hidden; background-color:white\"></div>");
            writer.Write("</span>");

        }


    }
}
