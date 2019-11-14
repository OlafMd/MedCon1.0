using System;
using System.Web.UI.WebControls;

namespace DLWebFormsTemplates.Templates
{
    public abstract class DLGridViewTemplate : DLComponentTemplate
    {

        abstract public GridView getGrid();
        abstract public void SetTableContent();
        
        #region LIST_CONTROLS EVENTS

        public void Grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            
            getGrid().PageIndex = e.NewPageIndex;

            SetTableContent();
        }

        public SortDirection Grid_Sorting(object sender, GridViewSortEventArgs e , SortDirection sortDirectionSession )
        {
            #region SetSorting

            SortDirection sortDirection = e.SortDirection;


            if (e.SortDirection == sortDirectionSession)
                sortDirection = e.SortDirection == SortDirection.Ascending ? SortDirection.Descending : SortDirection.Ascending;

            //SessionEvaluation.Instance.EvalutaionPatientsSortDirection = sortDirection;
            //SessionEvaluation.Instance.EvalutaionPatientsSortExpression = e.SortExpression;

            foreach (DataControlField column in getGrid().Columns)
            {
                if (column.HeaderStyle.CssClass == "hidden")
                    continue;

                column.HeaderStyle.CssClass = "sort_asc_dsc";
                column.ItemStyle.CssClass = "";

                if (column.SortExpression == e.SortExpression)
                {
                    column.ItemStyle.CssClass = "sorted";

                    if (sortDirection == SortDirection.Ascending)
                    {
                        column.HeaderStyle.CssClass = "sorted_asc";
                    }
                    else if (sortDirection == SortDirection.Descending)
                    {
                        column.HeaderStyle.CssClass = "sorted_dsc";
                    }
                }
            }
            SetTableContent();
            return sortDirection;

            #endregion
            
        }

        public void Grid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            GridViewRow row = e.Row as GridViewRow;
            try
            {
                LinkButton SelectButton = row.Cells[row.Cells.Count - 1].Controls[0] as LinkButton;
                row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(getGrid(), "Select$" + row.RowIndex);
            }
            catch (Exception)
            {
            }

            //hide all select rows except last (pager)
            if (e.Row.Cells[0] is DataControlFieldCell)
                e.Row.Cells[0].Style["display"] = "none";
        }

        //Pager
        public void Grid_PagerLink_Click(object sender, EventArgs e)
        {
            LinkButton Sender = sender as LinkButton;
            if (String.IsNullOrEmpty(Sender.CommandArgument)) return;
            int PageIndex = 0;
            if (Int32.TryParse(Sender.CommandArgument, out PageIndex))
            {
                GridViewPageEventArgs Params = new GridViewPageEventArgs(PageIndex);
                Grid_PageIndexChanging(Sender, Params);
            }
        }

        #endregion
    }
}
