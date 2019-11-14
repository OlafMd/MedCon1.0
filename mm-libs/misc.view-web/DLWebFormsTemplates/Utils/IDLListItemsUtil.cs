using System;
using System.Web.UI.WebControls;

namespace DLWebFormsTemplates.Utils
{
    interface IDLListItemsUtil
    {
        String CreateSortString(String SortExpression, SortDirection sortDireciton);

        int[] GetPageNumbers(GridView grid);

        String GetPageButtonClass(GridView grid, int pageIndex);

        bool IsFristPageVisible(GridView grid);

        bool IsLastPageVisible(GridView grid);

    }
}
