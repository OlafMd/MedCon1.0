using System;
using System.Web.UI;
using System.Web;
using System.Web.UI.WebControls;

namespace DLAPODemandCommons.Controls
{
    public enum EAPOChooseArticlesTableSortBy { ProductNumber, ProductName, Producer, DosageForm, Unit, ABDAPrice, FreeQuantity }
    public enum EChooseArticlesSelectionMode { Multiple, Single }

    [ToolboxData("<{0}:APOChooseArticlesTable ID='dlAPOChooseArticlesTable' runat='server'></{0}:APOChooseArticlesTable>")]
    public class APOChooseArticlesTable : Control
    {
        #region Consts

        private const string ArticleGrid_PAGEINDEX = "ArticleGrid_PageIndex";
        private const string ArticleGrid_SORTDIRECTION = "ArticleGrid_SortDirection";
        private const string ArticleGrid_SORTEXPRESSION = "ArticleGrid_SortExpression";
        private const string ArticleGrid_SEARCHPARAM = "ArticleGrid_SearchParam";

        #endregion

        #region Static Session properties

        public static int PageIndex
        {
            get
            {
                if (HttpContext.Current.Session[ArticleGrid_PAGEINDEX] == null)
                {
                    HttpContext.Current.Session[ArticleGrid_PAGEINDEX] = 0;
                }
                return (HttpContext.Current.Session[ArticleGrid_PAGEINDEX] as int?).Value;
            }
            set
            {
                HttpContext.Current.Session[ArticleGrid_PAGEINDEX] = value;
            }
        }

        public static SortDirection SortDirection
        {
            get
            {
                if (HttpContext.Current.Session[ArticleGrid_SORTDIRECTION] == null)
                    return SortDirection.Ascending;
                else
                    return (SortDirection)HttpContext.Current.Session[ArticleGrid_SORTDIRECTION];
            }
            set
            {
                HttpContext.Current.Session[ArticleGrid_SORTDIRECTION] = value;
            }
        }

        public static EAPOChooseArticlesTableSortBy SortExpression
        {
            get
            {
                if (HttpContext.Current.Session[ArticleGrid_SORTEXPRESSION] == null)
                    return EAPOChooseArticlesTableSortBy.ProductName;
                else
                    return (EAPOChooseArticlesTableSortBy)HttpContext.Current.Session[ArticleGrid_SORTEXPRESSION];
            }
            set
            {
                HttpContext.Current.Session[ArticleGrid_SORTEXPRESSION] = value;
            }
        }

        public static ChoosePopupSearchParam SearchParam
        {
            get
            {
                return HttpContext.Current.Session[ArticleGrid_SEARCHPARAM] as ChoosePopupSearchParam ?? new ChoosePopupSearchParam();
            }
            set
            {
                HttpContext.Current.Session[ArticleGrid_SEARCHPARAM] = value;
            }
        }

        #endregion

        #region Public properties

        public EChooseArticlesSelectionMode SelectionMode { get; set; }

        #endregion

        #region Public methods

        public static void UpdateSortSession(int pageIndex, string sortBy)
        {
            //this means that this service is triggered by scroller not change sort
            if (pageIndex != 1 || sortBy == String.Empty)
                return;

            EAPOChooseArticlesTableSortBy orderBy = EAPOChooseArticlesTableSortBy.ProductName;

            if (sortBy != String.Empty)
            {
                orderBy = (EAPOChooseArticlesTableSortBy)Enum.Parse(typeof(EAPOChooseArticlesTableSortBy), sortBy);

                if (APOChooseArticlesTable.SortExpression == orderBy)
                    APOChooseArticlesTable.SortDirection = APOChooseArticlesTable.SortDirection == SortDirection.Ascending
                              ? SortDirection.Descending : SortDirection.Ascending;
                else
                    APOChooseArticlesTable.SortDirection = SortDirection.Ascending;
            }
            else
                APOChooseArticlesTable.SortDirection = SortDirection.Ascending;

            APOChooseArticlesTable.SortExpression = orderBy;
        }

        public static void ClearSession()
        {
            HttpContext.Current.Session[ArticleGrid_PAGEINDEX] = null;
            HttpContext.Current.Session[ArticleGrid_SORTDIRECTION] = null;
            HttpContext.Current.Session[ArticleGrid_SORTEXPRESSION] = null;
            HttpContext.Current.Session[ArticleGrid_SEARCHPARAM] = null;
        }

        #endregion

        #region Override methods

        protected override void Render(HtmlTextWriter writer)
        {

            string ths = String.Format(
                "<th class='sort_asc_dsc cell-width-10' scope='col'></th>" +
                "<th id='{0}' class='sort_asc_dsc cell-width-40' scope='col'><a href='javascript:void(0)' onclick='sortChange(this, \"{0}\")' > Artikel<a/></th>" +
                "<th id='{1}' class='sort_asc_dsc cell-width-10' scope='col'><a href='javascript:void(0)' onclick='sortChange(this, \"{1}\")' > PZN<a/></th>" +
                "<th id='{2}' class='sort_asc_dsc cell-width-10' scope='col'><a href='javascript:void(0)' onclick='sortChange(this, \"{2}\")' > Dar.<a/></th>" +
                "<th id='{3}' class='sort_asc_dsc cell-width-10' scope='col'><a href='javascript:void(0)' onclick='sortChange(this, \"{3}\")' > Einheit<a/></th>" +
                "<th id='{4}' class='sort_asc_dsc cell-width-10' scope='col'>AEK</th>" +
                "<th id='{5}' class='sort_asc_dsc cell-width-10' scope='col'>Freie Menge</th>",
                EAPOChooseArticlesTableSortBy.ProductName, EAPOChooseArticlesTableSortBy.ProductNumber, EAPOChooseArticlesTableSortBy.DosageForm, 
                EAPOChooseArticlesTableSortBy.Unit, EAPOChooseArticlesTableSortBy.ABDAPrice, EAPOChooseArticlesTableSortBy.FreeQuantity);

            string toRender = String.Format(@"
                <div id='divChooseArticlePopUp' class='table-scrollable-holder table-height-500'>
                    <table id='tblChooseArticle' class='table-with-theme-color table-scrollable'>
                        <thead>
                            <tr>
                                {0}
                            </tr>
                        </thead>
                        <tbody></tbody>
                    </table>
                    <input type='hidden' value='{1}' id='hiddenSelectionMode'>
                </div>", ths, SelectionMode.ToString());

            writer.Write(toRender);
        }

        #endregion

        #region Initialize controls

        #endregion

    }
}