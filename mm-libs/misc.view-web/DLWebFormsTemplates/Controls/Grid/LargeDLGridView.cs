using System.Web.UI;
using System.Web.UI.WebControls;

namespace DLWebFormsTemplates.Controls
{
    [ToolboxData("<{0}:LargeDLGridView runat=server></{0}:LargeDLGridView>")]
    public class LargeDLGridView : DLGridView
    {
        public event GridViewSortEventHandler CustomSorting;

        #region Constances
        private const string VS_KEY_VirtualItemCount = "LargeDLGridView_VirtualItemCount";
        private const string VS_KEY_VirtualPageIndex = "LargeDLGridView_VirtualPageIndex";
        private const string VS_KEY_SortDirection = "LargeDLGridView_SortDirection";
        private const string VS_KEY_LastSortExpression = "LargeDLGridView_LastSortExpression";
        #endregion

        #region Properties
        public int VirtualItemCount {
            get
            {
                if (ViewState[VS_KEY_VirtualItemCount] == null)
                    ViewState[VS_KEY_VirtualItemCount] = 0;
                return (int)ViewState[VS_KEY_VirtualItemCount];
            }
            set
            {
                ViewState[VS_KEY_VirtualItemCount] = value;
            }
        }
        public int VirtualPageIndex
        {
            get
            {
                if (ViewState[VS_KEY_VirtualPageIndex] == null)
                    ViewState[VS_KEY_VirtualPageIndex] = 0;
                return (int)ViewState[VS_KEY_VirtualPageIndex];
            }
            set
            {
                ViewState[VS_KEY_VirtualPageIndex] = value;
            }
        }
        public override int PageCount
        {
            get
            {
                int numberOfPages = VirtualItemCount / PageSize;
                numberOfPages += (VirtualItemCount % PageSize) > 0 ? 1 : 0;
                return numberOfPages;
            }
        }
        public SortDirection SortDirectionForCurrentColumn
        {
            get
            {
                if (ViewState[VS_KEY_SortDirection + LastSortExpression] == null)
                    ViewState[VS_KEY_SortDirection + LastSortExpression] = SortDirection.Descending;
                return (SortDirection)ViewState[VS_KEY_SortDirection + LastSortExpression];
            }
            set
            {
                ViewState[VS_KEY_SortDirection + LastSortExpression] = value;
            }
        }
        public string LastSortExpression
        {
            get
            {
                return (string)ViewState[VS_KEY_LastSortExpression];
            }
            set
            {
                ViewState[VS_KEY_LastSortExpression] = value;
            }
        }
        #endregion

        #region Ctr
        public LargeDLGridView() : base(){}
        #endregion

        #region Protected Methods
        protected override void InitializeBottomPager(System.Web.UI.WebControls.GridViewRow row, int columnSpan, System.Web.UI.WebControls.PagedDataSource pagedDataSource)
        {
            if (this.PageIndex != this.VirtualPageIndex)
                this.PageIndex = this.VirtualPageIndex;
            base.InitializeBottomPager(row, columnSpan, pagedDataSource);
        }
        protected override void OnSorting(GridViewSortEventArgs e)
        {
            LastSortExpression = e.SortExpression;

            // Change sort direction
            SortDirectionForCurrentColumn = (SortDirectionForCurrentColumn == SortDirection.Ascending ? SortDirection.Descending : SortDirection.Ascending);

            if (CustomSorting != null) CustomSorting(this, e);

            foreach (DataControlField column in Columns)
            {
                if (column.HeaderStyle.CssClass == "hidden")
                    continue;

                column.HeaderStyle.CssClass = "sort_asc_dsc";
                column.ItemStyle.CssClass = "";

                if (column.SortExpression == LastSortExpression)
                {
                    column.ItemStyle.CssClass = "sorted";

                    if (SortDirectionForCurrentColumn == SortDirection.Ascending)
                    {
                        column.HeaderStyle.CssClass = "sorted_asc";
                    }
                    else if (SortDirectionForCurrentColumn == SortDirection.Descending)
                    {
                        column.HeaderStyle.CssClass = "sorted_dsc";
                    }
                }
            }
        }
        #endregion
    }
}
