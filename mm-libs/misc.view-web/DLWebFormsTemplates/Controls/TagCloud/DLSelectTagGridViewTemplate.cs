/*
 * Author: Milovan Regodic 
 * Email: milovan.regodic@danulabs.com
 * Date: November 2013
 */
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DLWebFormsTemplates.Controls
{

    public class MultipleSelectionTemplateField : TemplateField
    {
        public MultipleSelectionTemplateField() : base(){}
    }

    // A customized class for displaying the Template Column
    public class DLSelectTagGridViewTemplate : ITemplate
    {
        // A variable to hold the type of ListItemType.
        ListItemType _templateType;

        // A variable to hold the column name.
        string _columnName;

        string _columnHeaderLabel;

        bool _useLiteral;

        bool _checkBoxInHeader;

        // Constructor where we define the template type and column name.
        public DLSelectTagGridViewTemplate(ListItemType type, string colname, bool userLiteral, string columnHeaderLabel, bool checkBoxInHeader = false)
        {
            // Stores the template type.
            _templateType = type;

            // Stores the column name.
            _columnName = colname;

            _columnHeaderLabel = columnHeaderLabel;

            // Show or hide checkbox title
            _useLiteral = userLiteral;

            // Show check box in header
            _checkBoxInHeader = checkBoxInHeader;
        }

        void ITemplate.InstantiateIn(System.Web.UI.Control container)
        {
            switch (_templateType)
            {
                case ListItemType.Header:
                    if (_checkBoxInHeader)
                    {
                        CheckBox cbAll = new CheckBox();
                        cbAll.AutoPostBack = true;
                        cbAll.ID = "cbSelectAll";
                        container.Controls.Add(cbAll);

                        if (_useLiteral)
                        {
                            Literal litTitle = new Literal();
                            litTitle.ID = "litSelectAll";
                            litTitle.DataBinding += new EventHandler(litTitle_DataBinding);
                            container.Controls.Add(litTitle);
                        }
                    }
                    if (!String.IsNullOrEmpty(_columnHeaderLabel))
                    {
                        Literal litTitle = new Literal();
                        litTitle.ID = "litMultipleSelectionTitle";
                        litTitle.Text = _columnHeaderLabel;
                        container.Controls.Add(litTitle);
                    }
                    break;

                case ListItemType.Item:
                    // Creates a new text box control and add it to the container.
                    CheckBox cb = new CheckBox();
                    cb.ID = "cbSelect";
                    container.Controls.Add(cb);

                    if (_useLiteral)
                    {
                        Literal litTitle = new Literal();
                        litTitle.ID = "litSelect";
                        litTitle.DataBinding += new EventHandler(litTitle_DataBinding);
                        container.Controls.Add(litTitle);
                    }

                    break;

                case ListItemType.EditItem:
                    break;

                case ListItemType.Footer:
                    break;
            }
        }

        /// <summary>
        /// This is the event, which will be raised when the binding happens.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>  
        protected void litTitle_DataBinding(object sender, EventArgs e)
        {
            Literal lit = sender as Literal;
            GridViewRow container = (GridViewRow)lit.NamingContainer;
            object dataValue = DataBinder.Eval(container.DataItem, _columnName);
            if (dataValue != null && dataValue != DBNull.Value)
            {
                lit.Text = dataValue.ToString();
            }
        }
    }
}
