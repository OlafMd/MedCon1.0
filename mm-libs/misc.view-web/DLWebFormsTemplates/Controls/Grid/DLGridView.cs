
using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using System.Data;
using System.Globalization;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;

namespace DLWebFormsTemplates.Controls
{
    public delegate void FilterCommandEventHandler(object sender, FilterCommandEventArgs e);

    public class FilterCommandEventArgs : EventArgs
    {

    }

    [ToolboxData("<{0}:DLGridView runat=server></{0}:DLGridView>")]
    public class DLGridView : GridView
    {
        public event GridViewCommandEventHandler CustomPageIndexChanged;

        public DataView content;

        #region Pager Properties

        /// <summary>
        ///     Gets or sets a value indicating whether show [Page items {0} of {1}].
        ///     <value> 
        ///         <c>true</c> if [Page items {0} of {1}]; otherwise, <c>false</c> .
        ///     </value>
        /// </summary>
        public bool PagerShowSummary { get; set; }

        /// <summary>
        ///     Gets or sets the page links to show for pagination links.
        /// </summary>
        /// <value> The page links to show. </value>
        public int PageLinksToShow { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether [show first and last].
        /// </summary>
        /// <value>
        ///     <c>true</c> if [show first and last]; otherwise, <c>false</c> .
        /// </value>
        public bool PagerShowFirstAndLast { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether [show next and previous].
        /// </summary>
        /// <value>
        ///     <c>true</c> if [show next and previous]; otherwise, <c>false</c> .
        /// </value>
        public bool PagerShowNextAndPrevious { get; set; }

        /// <summary>
        ///     Gets or sets the page items text.
        /// </summary>
        /// <value> The page items text. </value>
        public string PagerPageItemsText { get; set; }

        /// <summary>
        ///     Gets or sets the of text.
        /// </summary>
        /// <value> The of text</value>
        public string PagerOfText { get; set; }

        public bool DataKeyTypeIsntGuid { get; set; }

        public bool AllowPageSizeButtons { get; set; }

        #endregion

        #region Ctr

        public DLGridView()
        {
            PagerSettings.Position = PagerPosition.TopAndBottom;
        }

        #endregion

        #region Exclude Columns From Selection
        /// <summary>
        /// Get or set column indexes to exclude from selection. 
        /// Value is string with delimiter ',' or ';' for column indexes.
        /// </summary>
        [DefaultValue("")]
        public string ExcludedColumnIndexesFromSelection { get; set; }
        protected void ExcludeSelectionOnColumns()
        {
            if (!string.IsNullOrEmpty(ExcludedColumnIndexesFromSelection))
            {
                List<int> columnIndexes = new List<int>();
                foreach (var i in ExcludedColumnIndexesFromSelection.Split(';', ','))
                {
                    columnIndexes.Add(Convert.ToInt32(i));
                }

                foreach (GridViewRow row in this.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            if (!columnIndexes.Contains(i))
                            {
                                row.Cells[i].Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(this, "Select$" + row.RowIndex);
                            }
                        }
                    }
                }
            }
        }
        #endregion

        public void SetTableContent(DataView content)
        {
            if (EnabledMultipleSelection && !content.Table.Columns.Contains("MultipleSelection"))
            {
                content.Table.Columns.Add("MultipleSelection", typeof(bool));
            }

            this.content = content;
            SortContent();
        }

        public void ContentBind()
        {
            DataSource = this.content;
            DataBindCustom();
        }

        public virtual void SortContent()
        {
            this.content = SortDataTable(true);
        }

        public void FireDeselection()
        {
            this.SelectedIndex = -1;
            OnSelectedIndexChanged(new EventArgs());
        }

        public void SelectKeyValue(Guid id) {

            // find index of current key in grid
            int index = -1;
            DataTable dt = (DataSource as DataView).Table;
            string collumnName = DataKeyNames.FirstOrDefault();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Guid key = (Guid)dt.Rows[i][collumnName];

                if (key == id)
                {
                    index = i;
                }
            }

            // find in which page is current key
            PageIndex = index / PageSize;

            OnPageIndexChanging(new GridViewPageEventArgs(PageIndex));

            for (int i = 0; i < DataKeys.Count; i++)
            {
                if ((Guid)DataKeys[i].Value == id)
                {
                    SelectedIndex = i;
                    break;
                }
            }

            OnSelectedIndexChanged(new EventArgs());
        }

        protected virtual DataView SortDataTable(bool changeSortDirection) 
        {
            if (content != null)
            {
                if (GridViewSortExpression != string.Empty)
                {
                    if (changeSortDirection)
                    {
                        content.Sort = string.Format("{0} {1}", GridViewSortExpression, GridViewSortDirection);
                    }
                    else
                    {
                        content.Sort = string.Format("{0} {1}", GridViewSortExpression, GetSortDirection());
                    }
                }
                return content;
            }
            else
            {

                return new DataView();
            }
        }

        //Gets or Sets the GridView SortDirection Property
        private int GridViewPageSize
        {
            get
            {
                return ViewState["PageSize"] != null ? (int)ViewState["PageSize"] : this.PageSize;
            }
            set
            {
                ViewState["PageSize"] = value;
            }
        }

        public Boolean GenerateTableHead { get; set; }

        //Gets or Sets the GridView SortDirection Property
        private String GridViewSelectedKey
        {
            get
            {
                return ViewState["SelectedKey"] as String;
            }
            set
            {
                ViewState["SelectedKey"] = value;
            }
        }

        //Gets or Sets the GridView SortDirection Property
        protected string GridViewSortDirection
        {
            get
            {
                return ViewState["SortDirection"] as string ?? "DESC";
            }
            set
            {
                ViewState["SortDirection"] = value;
            }
        }
        
        //Gets or Sets the GridView SortExpression Property
        protected string GridViewSortExpression
        {
            get
            {
                return ViewState["SortExpression"] as string ?? string.Empty;
            }
            set
            {
                ViewState["SortExpression"] = value;
            }
        }

        #region Virtual Methods

        protected virtual void InitializeBottomPager(GridViewRow row, int columnSpan, PagedDataSource pagedDataSource)
        {
            row.CssClass = "pager";
            int min = Math.Min(Math.Max(0, this.PageIndex - (PageLinksToShow / 2)),
                               Math.Max(0, this.PageCount - PageLinksToShow + 1));
            int max = Math.Min(this.PageCount, min + PageLinksToShow);

            TableCell wrapperCell = new TableCell();
            wrapperCell.ColumnSpan = columnSpan;

            HtmlGenericControl myOrderedList = new HtmlGenericControl("ol");
            wrapperCell.Controls.Add(myOrderedList);

            int currentIndex = this.PageIndex * this.PageSize + 1;

            if (AllowPageSizeButtons)
            {
                HtmlGenericControl pageSizeOrderedList = new HtmlGenericControl("ol");
                pageSizeOrderedList.Attributes.Add("class", "page-size-control");
                wrapperCell.Controls.Add(pageSizeOrderedList);

                AddPageSizeLink("10", "size-10", this.PageSize != 10, "size-10", pageSizeOrderedList);
                pageSizeOrderedList.Controls.Add(CreateSimpleSlashLiteralListItem(" / "));
                AddPageSizeLink("25", "size-25", this.PageSize != 25, "size-25", pageSizeOrderedList);
                pageSizeOrderedList.Controls.Add(CreateSimpleSlashLiteralListItem(" / "));
                AddPageSizeLink("50", "size-50", this.PageSize != 50, "size-50", pageSizeOrderedList);
                pageSizeOrderedList.Controls.Add(CreateSimpleSlashLiteralListItem(" / "));
                AddPageSizeLink("100", "size-100", this.PageSize != 100, "size-100", pageSizeOrderedList);
                pageSizeOrderedList.Controls.Add(CreateSimpleSlashLiteralListItem(" / "));
                AddPageSizeLink("All", "size-all", this.PageSize != GetTotalRowsCount(), "size-all", pageSizeOrderedList);
                pageSizeOrderedList.Controls.Add(CreateSimpleSlashLiteralListItem("out of " + GetTotalRowsCount()));
            }

            if (ShowPageNavigation)
            {
                if (PagerShowSummary)
                {
                    row.Controls.Add(new Literal { Text = string.Format("{0} {1} {2} {3}", PagerPageItemsText ?? "Page items", currentIndex, PagerOfText ?? "of", GetTotalRowsCount()) });
                }

                if (PagerShowFirstAndLast)
                {
                    AddPageLink(PagerSettings.FirstPageText ?? "First", "pager-first", this.PageIndex > 0, "First", myOrderedList);
                }

                if (PagerShowNextAndPrevious)
                {
                    AddPageLink(PagerSettings.PreviousPageText ?? "Previous", "pager-prev", this.PageIndex > 0, "Prev", myOrderedList);
                }

                for (int i = min; i < max; i++)
                {
                    AddPageLink((i + 1).ToString(CultureInfo.InvariantCulture), "", this.PageIndex != i, (i).ToString(CultureInfo.InvariantCulture), myOrderedList);
                }

                if (PagerShowNextAndPrevious)
                {
                    AddPageLink(PagerSettings.NextPageText ?? "Next", "pager-next", this.PageIndex < this.PageCount - 1, "Next", myOrderedList);
                }
                if (PagerShowFirstAndLast)
                {
                    AddPageLink(PagerSettings.LastPageText ?? "Last", "pager-last", this.PageIndex < this.PageCount - 1, "Last", myOrderedList);
                }
            }

            row.Controls.Add(wrapperCell);          
        }

        protected virtual void InitializeHeaderRow(GridViewRow row, DataControlField[] fields)
        {
            //AddGlyph(this, row);
        }

        protected virtual void HandlePageCommand(GridViewCommandEventArgs e)
        {
            int tempPageIndex = PageIndex;

            string command = e.CommandArgument.ToString();
            if (command == "Next" && PageIndex < PageCount - 1)
            {
                tempPageIndex += 1;
            }
            else if (command == "Prev" && PageIndex > 0)
            {
                tempPageIndex -= 1;
            }
            else if (command == "First" && PageIndex != 0)
            {
                tempPageIndex = 0;
            }
            else if (command == "Last" && PageIndex != PageCount - 1)
            {
                tempPageIndex = PageCount - 1;
            }
            else
            {
                tempPageIndex = int.Parse(command);
            }

            // Raise page index changing event.
            if (CustomPageIndexChanged != null)
                CustomPageIndexChanged(this, new GridViewCommandEventArgs(this, new CommandEventArgs("PageChanging", tempPageIndex)));

            PageIndex = tempPageIndex;

            DataBindCustom();
        }

        public void InitPageSizeButtons()
        {

        }
       
        #endregion

        protected void DataBindCustom()
        {
            DataBind();
            ExcludeSelectionOnColumns();
        }

        #region Override Methods

        protected override ICollection CreateColumns(PagedDataSource dataSource, bool useDataSource)
        {
            if (EnabledMultipleSelection)
            {
                AddMultipleSelection();
            }
            return base.CreateColumns(dataSource, useDataSource);
        }

        protected override void InitializePager(GridViewRow row, int columnSpan, PagedDataSource pagedDataSource)
        {
            if (this.Controls[0].Controls.Count == 0 && (this.PagerSettings.Position == PagerPosition.Top || this.PagerSettings.Position == PagerPosition.TopAndBottom))
            {
                //InitializeTopPager(row, columnSpan, pagedDataSource);
            }
            else
            {
                InitializeBottomPager(row, columnSpan, pagedDataSource);
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            if (AllowPageSizeButtons && GetTotalRowsCount() > 10) this.BottomPagerRow.Visible = true;

            EmptyDataRowStyle.CssClass = "empty-data";

            if (EnabledMultipleSelection && !this.CssClass.Contains("multiple_selection_table")) {
                this.CssClass += " multiple_selection_table";
                }

            if(GenerateTableHead)
            {
                if (Rows.Count > 0)
                {
                    //This replaces <td> with <th> and adds the scope attribute
                    UseAccessibleHeader = true;

                    //This will add the <thead> and <tbody> elements
                    HeaderRow.TableSection = TableRowSection.TableHeader;

                    //This adds the <tfoot> element. 
                    FooterRow.TableSection = TableRowSection.TableFooter;
                }
                else if (HeaderRow != null)
                {
                    UseAccessibleHeader = true;
                    HeaderRow.TableSection = TableRowSection.TableHeader;
                }


                if (TopPagerRow != null)
                {
                    TopPagerRow.TableSection = TableRowSection.TableHeader;
                }
                if (BottomPagerRow != null)
                {
                    BottomPagerRow.TableSection = TableRowSection.TableFooter;
                }
            }
        }

        protected override void OnPagePreLoad(object sender, EventArgs e)
        {
            SaveMultipleSelection();
            base.OnPagePreLoad(sender, e);
        }

        protected override void OnRowCommand(GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Page":
                    SaveMultipleSelection();
                    HandlePageCommand(e);
                    break;
                case "PageSize":
                    SetPageSize(e.CommandArgument.ToString());
                    break;
                default:
                    base.OnRowCommand(e);
                    break;
            }
        }

        protected override void OnSorting(GridViewSortEventArgs e)
        {
            var sortDirection = GridViewSortDirection;

            foreach (DataControlField column in Columns)
            {
                if (column.HeaderStyle.CssClass == "hidden")
                    continue;

                SetHeaderStyle(column.HeaderStyle, "sort_asc_dsc");
                column.ItemStyle.CssClass.Replace(" sorted", "");

                if (column.SortExpression == e.SortExpression)
                {
                    column.ItemStyle.CssClass += " sorted";

                    if (sortDirection == "ASC")
                    {
                        SetHeaderStyle(column.HeaderStyle,  "sorted_asc");
                    }
                    else if (sortDirection == "DESC")
                    {
                        SetHeaderStyle(column.HeaderStyle, "sorted_dsc");
                    }
                }
            }
            GridViewSortExpression = e.SortExpression;

            //Gets the Pageindex of the GridView.

            String prevSelectedKey = GridViewSelectedKey as String;

            int pageIndex = PageIndex;
            DataSource = SortDataTable(false);
            DataBindCustom();
            PageIndex = pageIndex;

            if (prevSelectedKey != null)
            {
                foreach (GridViewRow row in Rows)
                {
                    if (prevSelectedKey ==this.DataKeys[row.RowIndex].Value.ToString())
                    {
                        this.SelectedIndex = row.RowIndex;
                        return;
                    }
                }
                GridViewSelectedKey = null;
                FireDeselection();
            }

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.PageSize = GridViewPageSize;
            ExcludeSelectionOnColumns();
        }

        protected override void OnPageIndexChanging(GridViewPageEventArgs e)
        {
            //base.OnPageIndexChanging(e);
            FireDeselection();
            DataSource = SortDataTable(true);
            DataBindCustom();
        }

        protected override void OnRowDataBound(GridViewRowEventArgs e)
        {
            base.OnRowDataBound(e);

            SetMultipleSelection(e.Row);

            if (AutoGenerateSelectButton)
            {
                foreach (GridViewRow row in Rows)
                {
                    try
                    {
                        row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(this, "Select$" + row.RowIndex);
                    }
                    catch (Exception)
                    {
                    }
                }
                //hide all select rows except last (pager)
                if (e.Row.Cells.Count > 0 && e.Row.Cells[0] is DataControlFieldCell)
                    e.Row.Cells[0].Style["display"] = "none";
            }
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            if (this.SelectedIndex > -1 && this.DataKeys.Count > 0)
            {
                GridViewSelectedKey = this.DataKeys[this.SelectedIndex].Value.ToString();
            }
            else
            {
                GridViewSelectedKey = null;
            }
            base.OnSelectedIndexChanged(e);
        }

        protected override void InitializeRow(GridViewRow row, DataControlField[] fields)
        {
            
            base.InitializeRow(row, fields);
            if (row.RowType == DataControlRowType.Header)
            {
                InitializeHeaderRow(row, fields);
            }
        }

        
        #endregion



        //Toggles between the Direction of the Sorting
        protected string GetSortDirection()
        {
            switch (GridViewSortDirection)
            {
                case "ASC":
                    GridViewSortDirection = "DESC";
                    break;
                case "DESC":
                    GridViewSortDirection = "ASC";
                    break;
            }
            return GridViewSortDirection;
        }

        #region Pager Methods
        public String GetPageButtonClass(int pageIndex)
        {
            if (pageIndex == PageIndex)
                return "active";
            else
                return "";
        }

        private int GetTotalRowsCount()
        {
            int result = 0;
            if (this.DataSource is ICollection)
                result = ((ICollection)this.DataSource).Count;
            else if (this.DataSource is IListSource)
                result = ((IListSource)this.DataSource).GetList().Count;
            return result;
        }

        private void AddPageSizeLink(String text, String cssClass, bool addAsLink, string commandArgument, Control control)
        {
            HtmlGenericControl listItem = new HtmlGenericControl("li");
            if (addAsLink)
            {
                LinkButton button = new LinkButton
                {
                    ID = "PageSize" + text,
                    CommandName = "PageSize",
                    CommandArgument = commandArgument,
                    Text = text,
                    CssClass = cssClass
                };

                listItem.Controls.Add(button);
            }
            else
            {
                //Controls.Add(new Label { Text = text, CssClass = cssClass });
                listItem.Controls.Add(new Label { Text = text, CssClass = cssClass });
            }
            control.Controls.Add(listItem);

        }

        private void AddPageLink(String text, String cssClass, bool addAsLink, string commandArgument, Control control)
        {
            HtmlGenericControl listItem = new HtmlGenericControl("li");
            if (addAsLink)
            {
                LinkButton button = new LinkButton
                {
                    ID = "Page" + text,
                    CommandName = "Page",
                    CommandArgument = commandArgument,
                    Text = text,
                    CssClass = cssClass
                };

                listItem.Controls.Add(button);
            }
            else
            {
                //Controls.Add(new Label { Text = text, CssClass = cssClass });
                listItem.Controls.Add(new Label { Text = text, CssClass = cssClass });
            }
            control.Controls.Add(listItem);

        }

        public HtmlGenericControl CreateSimpleSlashLiteralListItem(string text)
        {
            HtmlGenericControl listItem = new HtmlGenericControl("li");
            listItem.Controls.Add(new Literal { Text = text });
            return listItem;
        }
        #endregion

        #region Multiple Selection

        public bool SelectCheckBoxOnRowClick { get; set; }
        public bool EnabledMultipleSelection
        {
            get
            {
                if (ViewState["EnabledMultipleSelection"] == null)
                    ViewState["EnabledMultipleSelection"] = false;
                return (bool)ViewState["EnabledMultipleSelection"];
            }
            set
            {
                ViewState["EnabledMultipleSelection"] = value;
                // Multiple selection on row click is in javascipt
                if (value && MultipleSelectionOnRowClick) this.AutoGenerateSelectButton = false;
            }
        }
        public bool CheckBoxInHeader
        {
            get
            {
                if (ViewState["CheckBoxInHeader"] == null)
                    ViewState["CheckBoxInHeader"] = false;
                return (bool)ViewState["CheckBoxInHeader"];
            }
            set
            {
                ViewState["CheckBoxInHeader"] = value;
                // Multiple selection on row click is in javascipt
                if (value && MultipleSelectionOnRowClick) this.AutoGenerateSelectButton = false;
            }
        }

        private bool ShowPageNavigation
        {
            get
            {
                if (ViewState["ShowPageNavigation"] == null)
                    ViewState["ShowPageNavigation"] = true;
                return (bool)ViewState["ShowPageNavigation"];
            }
            set
            {
                ViewState["ShowPageNavigation"] = value;
            }
        }

        public string MultipleSelectionHeaderText
        {
            get
            {
                if (ViewState["MultipleSelectionHeaderText"] == null)
                    ViewState["MultipleSelectionHeaderText"] = "";
                return (string)ViewState["MultipleSelectionHeaderText"];
            }
            set
            {
                ViewState["MultipleSelectionHeaderText"] = value;
            }
        }

        public bool MultipleSelectionOnRowClick { get; set; }
        public bool MultipleSelectionUseFlexibleColumn { get; set; }
        public int MultipleSelectionColumnIndex { get; set; }
        public bool MultipleSelectionUseLiteral { get; set; }
        public const string MULTIPLE_SELECTION_TITLE_COLUMN_NAME = "MultipleSelection";

        [Browsable(false)]
        public List<string> SelectedValues
        {
            get
            {
                if (ViewState[this.ID + "SelectedValues"] == null)
                    ViewState[this.ID + "SelectedValues"] = new List<String>();
                return ViewState[this.ID + "SelectedValues"] as List<String>;
            }
            set
            {
                ViewState[this.ID + "SelectedValues"] = value;
                foreach (GridViewRow row in this.Rows)
                    SetMultipleSelection(row);
            }
        }

        protected virtual void AddMultipleSelection()
        {
            //Declare the bound field and allocate memory for the bound field.
            var bfield = new MultipleSelectionTemplateField();
            bool isNew = true;

            // If exist, not add another same column
            foreach (var c in Columns)
            {
                if (c is MultipleSelectionTemplateField)
                {
                    bfield = c as MultipleSelectionTemplateField;
                    isNew = false;
                }
            }

            //Initalize the DataField value.
            bfield.HeaderTemplate = new DLSelectTagGridViewTemplate(ListItemType.Header, string.Empty, false, MultipleSelectionHeaderText, CheckBoxInHeader);
            //Initialize the HeaderText field value.
            bfield.ItemTemplate = new DLSelectTagGridViewTemplate(ListItemType.Item, MULTIPLE_SELECTION_TITLE_COLUMN_NAME, MultipleSelectionUseLiteral, string.Empty);

            bfield.HeaderStyle.CssClass = "cell-width-01";
            bfield.ItemStyle.CssClass = "cell-width-01";

            if (isNew && !MultipleSelectionUseFlexibleColumn) this.Columns.Add(bfield);
            else if (isNew && MultipleSelectionUseFlexibleColumn) this.Columns.Insert(MultipleSelectionColumnIndex, bfield);
        }

        public virtual void SetPageSize(string eSize)
        {
            switch (eSize)
            {
                case "size-25":
                    this.PageSize = 25;
                    break;
                case "size-50":
                    this.PageSize = 50;
                    break;
                case "size-100":
                    this.PageSize = 100;
                    break;
                case "size-all":
                    this.PageSize = GetTotalRowsCount();
                    break;
                default:
                    this.PageSize = 10;
                    break;
            }

            ShowPageNavigation = GetTotalRowsCount() > this.PageSize;

            GridViewPageSize = this.PageSize;
            this.DataBind();
        }

        public virtual void SaveMultipleSelection()
        {
            if (EnabledMultipleSelection)
            {
                for (int i = 0; i < this.Rows.Count; i++ )
                {
                    GridViewRow row = this.Rows[i];
                    if (row.RowType != DataControlRowType.DataRow) continue;

                    CheckBox cb = (CheckBox)row.FindControl("cbSelect");
                    if (cb != null)
                    {
                        var id = this.DataKeys[row.RowIndex].Value.ToString();
                        if (cb.Checked)
                        {
                            if (!SelectedValues.Contains(id))
                            {
                                SelectedValues.Add(id);
                            }
                        }
                        else
                        {
                            if (SelectedValues.Contains(id))
                            {
                                SelectedValues.Remove(id);
                            }
                        }
                    }
                }
            }
        }
        protected virtual void SetMultipleSelection(GridViewRow row)
        {
            if (EnabledMultipleSelection && row.RowType == DataControlRowType.DataRow)
            {
                CheckBox cbSelect = (CheckBox)row.FindControl("cbSelect");

                if (cbSelect != null)
                {
                    // Set event on click on check box
                    var id = this.DataKeys[row.RowIndex].Value.ToString();
                    cbSelect.Checked = SelectedValues.Contains(id);

                    // check/uncheck checkbox on cell click
                    int multColIndex = MultipleSelectionUseFlexibleColumn ? MultipleSelectionColumnIndex : row.Cells.Count - 1;
                    string script = string.Format(
@"var cb = document.getElementById('{0}');
cb.checked = !cb.checked;
$(cb).parent().toggleClass('checked', cb.checked);", cbSelect.ClientID);
                    if (SelectCheckBoxOnRowClick)
                    {
                        DLGridView.SetScriptForCellOnRowClick(row, script, multColIndex);
                    }
                }
            }
        }
        #endregion

        #region Utils
        /// <summary>
        /// Method adding script parameter for execution when is clicked on a row cell.
        /// </summary>
        /// <param name="row">Row that contains cells</param>
        /// <param name="script">Script that will execute on cell click</param>
        /// <param name="cellIndex">Cell index that is excluded</param>
        public static void SetScriptForCellOnRowClick(GridViewRow row, string script, int cellIndex)
        {
            foreach (TableCell cell in row.Cells)
            {
                // find a cell index
                int curCellIndex;
                string strCellIndex = Regex.Match(cell.ClientID, @"_ctl(?<num>\d+)_").Groups["num"].Value;
                curCellIndex = Convert.ToInt32(strCellIndex);

                // if cell is not quantity input then set click event for a cell
                if (curCellIndex != cellIndex)
                {
                    cell.Attributes["onclick"] = script;
                }
            }
        }
        #endregion

        #region Css

        private void SetHeaderStyle(TableItemStyle headerStyle, string ClassName)
        {
            if (headerStyle.CssClass.IndexOf("sort_asc_dsc") != -1)
            {
                headerStyle.CssClass = headerStyle.CssClass.Replace("sort_asc_dsc", "");
            }
            else if (headerStyle.CssClass.IndexOf("sorted_asc") != -1)
            {
                headerStyle.CssClass = headerStyle.CssClass.Replace("sorted_asc", "");
            }
            else if (headerStyle.CssClass.IndexOf("sorted_dsc") != -1)
            {
                headerStyle.CssClass = headerStyle.CssClass.Replace("sorted_dsc", "");
            }

            headerStyle.CssClass += " " + ClassName;
            headerStyle.CssClass = headerStyle.CssClass.Trim();
        }

        #endregion
    }
}
