/*
 * Author: Milovan Regodic 
 * Email: milovan.regodic@danulabs.com
 * Date: November 2013
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.ComponentModel;
using System.Web.UI.Design;
using System.Collections.ObjectModel;
using System.Web.UI.HtmlControls;
using System.Data;

namespace DLWebFormsTemplates.Controls
{
    public class DLAddNewTag : CompositeDataBoundControl, IPostBackEventHandler
    {
        #region Members
        private Collection<DLTagCloudItem> _items = new Collection<DLTagCloudItem>();
        private TextBox _tbSearch;
        private DLGridView _grid;
        #endregion

        #region Properties
        /// <summary>
        /// Collection of DLTagCloudItems. <see cref="DLTagCloudItem"/> 
        /// </summary>
        [Themeable(false), PersistenceMode(PersistenceMode.InnerProperty), MergableProperty(false)]
        public Collection<DLTagCloudItem> Items
        {
            get { return _items; }
        }
        #endregion

        #region Design Properties

        /// <summary>
        ///     Gets or sets the empty data text.
        /// </summary>
        /// <value> The empty data text. </value>
        [Category("Appearance")]
        public string EmptyDataText { get; set; }

        /// <summary>
        ///     Gets or sets the header text.
        /// </summary>
        /// <value> The header text. </value>
        [Category("Appearance")]
        public string HeaderText { get; set; }

        /// <summary>
        ///     Gets or sets the tag list header text.
        /// </summary>
        /// <value> The tag list header text. </value>
        [Category("Appearance")]
        public string TagListHeaderText { get; set; }

        /// <summary>
        /// Gets or sets the text search button.
        /// </summary>
        [Category("Appearance")]
        public string SearchButtonText { get; set; }

        /// <summary>
        /// Gets or sets the text confirm button.
        /// </summary>
        [Category("Appearance")]
        public string ConfirmButtonText { get; set; }

        /// <summary>
        /// Gets or sets the text calcel button.
        /// </summary>
        [Category("Appearance")]
        public string CancelButtonText { get; set; }

        /// <summary>
        /// Gets or sets the css for popup wrapper panel.
        /// </summary>
        [Category("Appearance")]
        public string PopupWrapperCssClass { get; set; }

        /// <summary>
        /// Gets or sets the css for popup div.
        /// </summary>
        [Category("Appearance")]
        public string PopupDivCssClass { get; set; }

        /// <summary>
        /// Gets or sets the css for button confirm.
        /// </summary>
        [Category("Appearance")]
        public string ButtonConfirmCssClass { get; set; }

        /// <summary>
        /// Gets or sets the css for button cancel.
        /// </summary>
        [Category("Appearance")]
        public string ButtonCancelCssClass { get; set; }

        /// <summary>
        /// Gets or sets the css for confirm buttons.
        /// </summary>
        [Category("Appearance")]
        public string CommandButtonsCssClass { get; set; }

        /// <summary>
        /// Gets or sets the css for the search panel
        /// </summary>
        [Category("Appearance")]
        public string SearchPanelCssClass { get; set; }


        /// <summary>
        /// Gets or sets the css of the grid
        /// </summary>
        [Category("Appearance")]
        public string GridCssClass { get; set; }


        /// <summary>
        /// Gets or sets the name of the data field that is bound to the Text property of an item.
        /// </summary>
        [Category("Data")]
        [TypeConverter(typeof(DataFieldConverter))]
        public string DataTextField
        {
            get
            {
                string val = ViewState[this.ID + "DataTextField"] as string;

                if (val != null)
                {
                    return val;
                }

                return String.Empty;
            }
            set
            {
                ViewState[this.ID + "DataTextField"] = value;

                if (this.Initialized)
                {
                    this.RequiresDataBinding = true;
                }
            }
        }

        /// <summary>
        /// Gets or sets the format string for the Text property.
        /// </summary>
        [Category("Data")]
        public string DataTextFormatString
        {
            get
            {
                string val = ViewState[this.ID + "DataTextFormatString"] as string;

                if (val != null)
                {
                    return val;
                }

                return String.Empty;
            }
            set
            {
                ViewState[this.ID + "DataTextFormatString"] = value;

                if (this.Initialized)
                {
                    this.RequiresDataBinding = true;
                }
            }
        }

        /// <summary>
        /// Gets or sets the data field which is bound to the Value property of an item.
        /// </summary>
        [Category("Data")]
        [TypeConverter(typeof(DataFieldConverter))]
        public string DataValueField
        {
            get
            {
                string val = ViewState[this.ID + "DataValueField"] as string;

                if (val != null)
                {
                    return val;
                }

                return String.Empty;
            }
            set
            {
                ViewState[this.ID + "DataValueField"] = value;

                if (this.Initialized)
                {
                    this.RequiresDataBinding = true;
                }
            }
        }

        /// <summary>
        /// Gets or sets the data field which is bound to the Title property of an item.
        /// </summary>
        [Category("Data")]
        [TypeConverter(typeof(DataFieldConverter))]
        public string DataTitleField
        {
            get
            {
                string val = ViewState[this.ID + "DataTitleField"] as string;

                if (val != null)
                {
                    return val;
                }

                return String.Empty;
            }
            set
            {
                ViewState[this.ID + "DataTitleField"] = value;

                if (this.Initialized)
                {
                    this.RequiresDataBinding = true;
                }
            }
        }

        /// <summary>
        /// The format string for the title(tooltip) of an item. {0} in this string is replaced with the
        /// value of the field specified as the DataTitleField.
        /// </summary>
        [Category("Data")]
        public string DataTitleFormatString
        {
            get
            {
                string val = ViewState[this.ID + "DataTitleFormatString"] as string;

                if (val != null)
                {
                    return val;
                }

                return String.Empty;
            }
            set
            {
                ViewState[this.ID + "DataTitleFormatString"] = value;

                if (this.Initialized)
                {
                    this.RequiresDataBinding = true;
                }
            }
        }

        /// <summary>
        /// The search text.
        /// </summary>
        [Category("Data")]
        public string SearchText
        {
            get
            {
                string val = ViewState[this.ID + "SearchText"] as string;

                if (val != null)
                {
                    return val;
                }

                return String.Empty;
            }
            set
            {
                ViewState[this.ID + "SearchText"] = value;

                if (this.Initialized)
                {
                    this.RequiresDataBinding = true;
                }
            }
        }

        [Browsable(false)]
        public List<String> SelectedValues
        {
            get
            {
                return ViewState[this.ID + "SelectedValues"] as List<String>;
            }
            set
            {
                ViewState[this.ID + "SelectedValues"] = value;
            }
        }
        #endregion

        #region Override Methods
        protected override int CreateChildControls(System.Collections.IEnumerable dataSource, bool dataBinding)
        {
            if (!this.DesignMode && dataBinding)
            {
                var parent = AddParentContainer();
                AddHeaderField(parent);
                AddSearchField(parent);
                CreateItemsFromData(dataSource);
                AddItemsField(parent);
                AddCommandButtons(parent);
            }
            return Items.Count;
        }
        protected override void Render(HtmlTextWriter writer)
        {
            base.Render(writer);
        }
        protected override HtmlTextWriterTag TagKey
        {
            get
            {
                return HtmlTextWriterTag.Div;
            }
        }
        #endregion

        #region Private Methods
        private HtmlGenericControl AddParentContainer()
        {
            Panel panel = new Panel();
            panel.ID = "panel";
            if (!String.IsNullOrEmpty(PopupWrapperCssClass))
            {
                panel.CssClass = PopupWrapperCssClass;
            }
            this.Controls.Add(panel);

            HtmlGenericControl div = new HtmlGenericControl("div");
            div.ID = "parent";
            if (!String.IsNullOrEmpty(PopupDivCssClass))
            {
                div.Attributes.Add("class", PopupDivCssClass);
            }
            panel.Controls.Add(div);

            return div;
        }
        private void AddHeaderField(Control parent)
        {
            // Add header text
            parent.Controls.Add(new Literal { Text = string.Format("<h2>{0}</h2>", HeaderText) });
        }
        private void AddSearchField(Control parent)
        {
            // Add search field
            HtmlGenericControl searchField = new HtmlGenericControl("div");
            if (!String.IsNullOrEmpty(SearchPanelCssClass))
            {
                searchField.Attributes.Add("class", SearchPanelCssClass);
            }
            if (_tbSearch == null)
            {
                _tbSearch = new TextBox() { Text = SearchText };
                _tbSearch.TextChanged += new EventHandler(tbSearch_TextChanged);
            }
            searchField.Controls.Add(_tbSearch);
            HtmlAnchor a = new HtmlAnchor();
            a.InnerText = SearchButtonText;
            a.HRef = this.Page.ClientScript.GetPostBackClientHyperlink(this, "Search");
            searchField.Controls.Add(a);
            parent.Controls.Add(searchField);
        }
        private void AddItemsField(Control parent)
        {
            // Add grid view on page
            if (this.Items != null && this.Items.Count > 0)
            {
                if (_grid == null) {
                    _grid = new DLGridView();
                    _grid.AutoGenerateColumns = false;
                    _grid.DataKeyNames = new string[] { "Value" };
                    _grid.AllowPaging = true;
                    _grid.PagerShowFirstAndLast = true;
                    _grid.PagerShowNextAndPrevious = true;
                    _grid.PagerSettings.Position = PagerPosition.TopAndBottom;
                    _grid.PageLinksToShow = 9;
                    _grid.PageSize = 5;
                    _grid.EnabledMultipleSelection = true;
                    _grid.MultipleSelectionUseLiteral = true;
                    _grid.ID = "grid";
                    _grid.CssClass = GridCssClass;
                    _grid.SelectedValues = this.SelectedValues;
                    _grid.DataBound += new EventHandler(_grid_DataBound);
                    _grid.Columns.Add(new BoundField() {ShowHeader = false, HeaderText = string.Empty });
                }

                if(!parent.Controls.Contains(_grid))
                    parent.Controls.Add(_grid);
                
                // Set data table to grid view.
                _grid.SetTableContent(GetDataTable().DefaultView);
                _grid.ContentBind();
            }

            if (Items == null || Items.Count == 0)
            {
                var messageControl = parent.FindControl("messageNoItems");
                if (messageControl == null)
                parent.Controls.Add(new Literal { ID = "messageNoItems", Text = EmptyDataText });
            }
        }
        private void AddCommandButtons(Control parent)
        {
            // command buttons container
            HtmlGenericControl div = new HtmlGenericControl("div");
            div.ID = "commandbuttons";
            if (!String.IsNullOrEmpty(CommandButtonsCssClass))
            {
                div.Attributes["class"] = CommandButtonsCssClass;
            }
            parent.Controls.Add(div);           

            // cancel button
            HtmlAnchor btnCancel = new HtmlAnchor() { InnerText = CancelButtonText };
            if (!String.IsNullOrEmpty(ButtonCancelCssClass))
            {
                btnCancel.Attributes["class"] = ButtonCancelCssClass;
            }
            btnCancel.HRef = this.Page.ClientScript.GetPostBackClientHyperlink(this, "Cancel");
            div.Controls.Add(btnCancel);

            // confirm button
            HtmlAnchor btnConfirm = new HtmlAnchor() { InnerText = ConfirmButtonText };
            if (!String.IsNullOrEmpty(ButtonConfirmCssClass))
            {
                btnConfirm.Attributes["class"] = ButtonConfirmCssClass;
            }
            btnConfirm.HRef = this.Page.ClientScript.GetPostBackClientHyperlink(this, "Confirm");
            div.Controls.Add(btnConfirm);
        }
        private DataTable GetDataTable()
        {
            // Create data table for grid view.
            DataTable dt = new DataTable();
            dt.Columns.Add("Value", typeof(Guid));
            dt.Columns.Add("MultipleSelection", typeof(string));

            var filteredItems = this.Items.ToList();

            if (!String.IsNullOrEmpty(SearchText))
            {
                filteredItems = filteredItems.Where(x => x.Text.ToUpper().Contains(SearchText.ToUpper())).ToList();
            }

            // Fill data table with data.
            foreach (var item in filteredItems)
            {
                var row = dt.NewRow();
                row["Value"] = item.Value;
                row["MultipleSelection"] = item.Text;
                dt.Rows.Add(row);
            }
            return dt;
        }
        private void CreateItemsFromData(System.Collections.IEnumerable dataSource)
        {
            _items = new Collection<DLTagCloudItem>();
            foreach (object data in dataSource)
            {
                DLTagCloudItem item = new DLTagCloudItem();

                if (!String.IsNullOrEmpty(this.DataValueField))
                {
                    item.Value = DataBinder.GetPropertyValue(data, this.DataValueField).ToString();
                }

                if (!String.IsNullOrEmpty(this.DataTextField))
                {
                    item.Text = DataBinder.Eval(data, this.DataTextField, this.DataTextFormatString);
                }

                if (!String.IsNullOrEmpty(this.DataTitleField))
                {
                    item.Title = DataBinder.Eval(data, this.DataTitleField, this.DataTitleFormatString);
                }

                this.Items.Add(item);
            }
        }
        private void _grid_DataBound(object sender, EventArgs e)
        {
            _grid.SaveMultipleSelection();
            // saving multiple selected items, because grid is created on every post back and selected multiple items is losing then..
            SelectedValues = _grid.SelectedValues;
        }
        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            SearchText = (sender as TextBox).Text;
        }
        #endregion

        #region Public
        public event EventHandler Confirm;
        public void Show()
        {
            this.Visible = true;
        }
        public void Hide()
        {
            this.Visible = false;
        }
        #endregion

        #region IPostBackEventHandler Members
        public void RaisePostBackEvent(string eventArgument)
        {
            if (eventArgument == "Search")
            {
                SelectedValues = null;
                AddItemsField(FindControl("parent"));
            }

            if (eventArgument == "Cancel")
            {
                SelectedValues = null;
                Hide();
            }

            if (eventArgument == "Confirm")
            {
                _grid.SaveMultipleSelection();
                if (Confirm != null) Confirm(this, EventArgs.Empty);
                SelectedValues = null;
                Hide();
            }
        }
        #endregion
    }
}
