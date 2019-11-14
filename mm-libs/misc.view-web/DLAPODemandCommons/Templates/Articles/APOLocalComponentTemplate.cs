using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using DLWebFormsTemplates.Controls;

namespace DLAPODemandCommons.Templates.Articles
{
    /// <summary>
    /// Template for Local articles view.
    /// </summary>
    public abstract class APOLocalComponentTemplate : APOArticleCommonTemplate, IAPOArticleTemplate
    {
        #region CONSTANCES
        private const string VIEW_STATE_KEY_SEARCH_CONDITION = "VIEW_STATE_KEY_SEARCH_CONDITION";
        #endregion

        #region MEMBERS
        protected global::DLWebFormsTemplates.Controls.DLGridView grid;
        #endregion

        #region PROPERTIES
        public bool IsExtern { get { return false; } }
        public override List<Product> SelectedProducts
        {
            get
            {
                if (EnabledMultipleSelection)
                {
                    return Products.Where(x => grid.SelectedValues.Contains(x.ProductITL.ToString())).ToList();
                }
                else
                {
                    if (grid.SelectedIndex == -1)
                        return new List<Product>();

                    return new List<Product>() { Products.Single(x => x.ProductITL == grid.DataKeys[grid.SelectedIndex].Value.ToString()) };

                }
            }
        }
        public List<SearchCondition> SearchConditions
        {
            get
            {
                if (ViewState[VIEW_STATE_KEY_SEARCH_CONDITION + this.ID] == null)
                    ViewState[VIEW_STATE_KEY_SEARCH_CONDITION + this.ID] = new List<SearchCondition>();
                return ViewState[VIEW_STATE_KEY_SEARCH_CONDITION + this.ID] as List<SearchCondition>;
            }
            set { ViewState[VIEW_STATE_KEY_SEARCH_CONDITION + this.ID] = value; }
        }
        public int SelectedIndex
        {
            get { return grid.SelectedIndex; }
            set { grid.SelectedIndex = value; }
        }
        public int VirtualPageIndex
        {
            get { return grid.PageIndex; }
            set { grid.PageIndex = value; }
        }
        public bool EnabledMultipleSelection
        {
            get
            {
                return grid.EnabledMultipleSelection;
            }
            set
            {
                grid.AutoGenerateSelectButton = !value;
                grid.EnabledMultipleSelection = value;
                grid.MultipleSelectionOnRowClick = value;
            }
        }
        protected override DLGridView Grid
        {
            get
            {
                return grid;
            }
        }
        #endregion

        protected override void OnLoad(EventArgs e)
        {
            BindData();

            base.OnLoad(e);
        }

        //###########################DATA_ACCESS METHODS#############################//
        #region DATA_ACCESS METHODS
        protected abstract void GetArticlesFromDb();
        #endregion

        //#############################PUBLIC METHODS################################//
        #region PUBLIC METHODS
        public void Show()
        {
            this.Visible = true;
        }
        public void Hide()
        {
            this.SelectedIndex = -1;
            this.Visible = false;
        }
        public override void BindData()
        {
            FillGridView();
            base.BindData();
        }
        public void GetArticlesFromBegin()
        {
            grid.SelectedValues.Clear();
            grid.PageIndex = 0;
            GetArticles();
        }
        public void GetArticles()
        {
            GetArticlesFromDb();
            BindData();
            grid.ContentBind();
        }
        public void ClearSearchConditions()
        {
            this.SearchConditions.Clear();
        }
        public void AddSearchConditions(SearchCondition condition)
        {
            var cond = SearchConditions.SingleOrDefault(x => x.field == condition.field);
            if (cond != null)
            {
                SearchConditions.Remove(cond);
            }
            SearchConditions.Add(condition);
        }
        public void SelectItemByID(String id)
        {
            foreach (GridViewRow row in grid.Rows)
            {
                var rowId = grid.DataKeys[row.RowIndex].Value.ToString();
                if (id == rowId)
                {
                    grid.SelectedIndex = row.RowIndex;
                    break;
                }
            }
        }
        public void SelectItemsByIDs(List<String> ids)
        {
            //throw new NotImplementedException();
        }

        public void ClearSelectedValues()
        {
            grid.SelectedValues.Clear();
        }
        public Guid ImportSelectedProduct()
        {
            throw new NotImplementedException();
        }
        public List<Product> ImportSelectedProducts()
        {
            throw new NotImplementedException();
        }

        protected string GetSearchConditionValue(ProductField field)
        {
            var cond = SearchConditions.FirstOrDefault(x => x.field == field);
            if (cond == null)
                return string.Empty;
            return cond.query;
        }

        #endregion

        //##############################LIST_CONTROLS EVENTS#########################//
        #region LIST_CONTROLS EVENTS
        #endregion

        //##############################SUPPORT METHODS#########################//
        #region SUPPORT METHODS
        protected override Product GetProductByID(String id)
        {
            return Products.Single(x => x.ProductITL == id);
        }
        #endregion
    }
}
