using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace DLWebFormsTemplates.Utils
{
    class DLListItemsUtil:IDLListItemsUtil
    {

        public DLListItemsUtil() { 
        
        
        }

        private string ConvertSortDirectionToSql(SortDirection sortDireciton)
        {
            string newSortDirection = String.Empty;
            switch (sortDireciton)
            {
                case SortDirection.Ascending:
                    newSortDirection = "ASC";
                    break;
                case SortDirection.Descending:
                    newSortDirection = "DESC";
                    break;
            }
            return newSortDirection;
        }

        public String CreateSortString(String SortExpression, SortDirection sortDireciton)
        {
            return SortExpression + " " + ConvertSortDirectionToSql(sortDireciton);

        }

        public int[] GetPageNumbers(GridView grid)
        {
            if (grid.PageCount <= 5)
                return Enumerable.Range(1, grid.PageCount).ToArray();
            else
            {
                int firstIndex = (grid.PageIndex + 1) - 2;
                firstIndex = (firstIndex < 1) ? 1 : firstIndex;

                firstIndex = (firstIndex + 5 > grid.PageCount + 1) ? (grid.PageCount + 1) - 5 : firstIndex;

                return Enumerable.Range(firstIndex, 5).ToArray();

            }
        }

        public String GetPageButtonClass(GridView grid, int pageIndex)
        {

            if (pageIndex == grid.PageIndex)
                return "active";
            else
                return "";

        }

        public bool IsFristPageVisible(GridView grid)
        {
            if (grid.PageCount <= 5)
                return false;

            if (grid.PageIndex + 1 <= 3)
                return false;

            return true;
        }

        public bool IsLastPageVisible(GridView grid)
        {
            if (grid.PageCount <= 5)
                return false;

            if (grid.PageIndex + 3 >= grid.PageCount)
                return false;

            return true;
        }
    }
}
