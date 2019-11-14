using System;
using System.Collections.Generic;
using System.Linq;
using DLWebFormsTemplates.Controls;
using System.Web.UI.WebControls;
using DLAPODemandCommons.Templates.Articles;

namespace DLAPODemandCommons.Templates
{
    /// <summary>
    /// Template for ABDA articls view.
    /// </summary>
    public abstract class APOAbdaComponentTemplate : APOArticleCommonTemplate, IAPOArticleTemplate
    {
        #region MEMBERS
        protected global::DLWebFormsTemplates.Controls.LargeDLGridView grid;
        protected int _vic;
        private bool _isMultipleSelectionActived;
        #endregion

        #region CONSTANCES
        private const string VIEW_STATE_KEY_ALL_PRODUCT_ORDERS = "VIEW_STATE_KEY_PRODUCT_ORDERS";
        private const string VIEW_STATE_KEY_SELECTED_PRODUCTS = "VIEW_STATE_KEY_SELECTED_PRODUCTS";
        private const string VIEW_STATE_KEY_SEARCH_CONDITION = "VIEW_STATE_KEY_SEARCH_CONDITION";
        #endregion

        #region EVENTS

        #endregion

        #region PROPERTIES
        public bool IsExtern { get { return true; } }
        public int SelectedIndex
        {
            get { return grid.SelectedIndex; }
            set { grid.SelectedIndex = value; }
        }
        public int VirtualPageIndex
        {
            get { return grid.VirtualPageIndex; }
            set { grid.VirtualPageIndex = value; }
        }
        public string SelectedProductITL
        {
            get
            {
                return grid.DataKeys[grid.SelectedIndex].Value.ToString();
            }
        }
        public override List<Product> SelectedProducts
        {
            get
            {
                if (EnabledMultipleSelection)
                {
                    if (ViewState[VIEW_STATE_KEY_SELECTED_PRODUCTS + ID] == null)
                        ViewState[VIEW_STATE_KEY_SELECTED_PRODUCTS + ID] = new List<Product>();
                    return ViewState[VIEW_STATE_KEY_SELECTED_PRODUCTS + ID] as List<Product>;
                }
                else
                {
                    if (grid.SelectedIndex == -1)
                    {
                        return new List<Product>();
                    }

                    return new List<Product>() { Products.Single(x => x.ProductITL == SelectedProductITL) };

                }
            }
        }
        public List<SearchCondition> SearchConditions
        {
            get
            {
                if (ViewState[VIEW_STATE_KEY_SEARCH_CONDITION + ID] == null)
                    ViewState[VIEW_STATE_KEY_SEARCH_CONDITION + ID] = new List<SearchCondition>();
                return ViewState[VIEW_STATE_KEY_SEARCH_CONDITION + ID] as List<SearchCondition>;
            }
            set { ViewState[VIEW_STATE_KEY_SEARCH_CONDITION + ID] = value; }
        }
        public override List<Product> Products
        {
            get
            {
                return ViewState[VIEW_STATE_KEY_ALL_PRODUCT_ORDERS + ID] as List<Product>;
            }
            set
            {
                ViewState[VIEW_STATE_KEY_ALL_PRODUCT_ORDERS + ID] = value;
            }
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
            #region Multiple Selection
            SaveSelectedProducts();
            #endregion

            #region DataBind
            BindData();
            #endregion

            base.OnLoad(e);
        }

        //###########################DATA_ACCESS METHODS#############################//
        #region DATA_ACCESS METHODS
        protected abstract List<Product> GetArticlesFromWebService(int index, int pageSize);
        protected abstract Dictionary<string, Guid> ImportAbdaProductIndb(string[] arrayOfProductItl);
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
            grid.ContentBind();
            base.BindData();
        }
        public void GetArticlesFromBegin()
        {
            // ClearSelectedValues();
            grid.VirtualPageIndex = 0;
            GetArticles();
        }
        public void GetArticles()
        {
            GetData();
        }
        /// <summary>
        /// Import ABDA article to HOUSE article.
        /// </summary>
        /// <returns>return HOUSE Product ID</returns>
        public Guid ImportSelectedProduct()
        {
            return ImportAbdaProductIndb(new string[] { SelectedProductITL }).Single().Value;
        }
        public List<Product> ImportSelectedProducts()
        {
            SaveSelectedProducts();

            var arrayOfProductItsl = SelectedProducts.Select(x => x.ProductITL).ToArray();

            var dict = ImportAbdaProductIndb(arrayOfProductItsl);

            // Set product id
            foreach (var product in SelectedProducts)
            {
                product.ProductId = dict.Single(x => x.Key == product.ProductITL).Value;
            }

            return SelectedProducts;
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
            condition.query = condition.query.Replace("/", @"\/");
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
            ClearSelectedValues();

            foreach (var productITL in ids)
            {
                var product = Products.Single(x => x.ProductITL == productITL);
                SelectedProducts.Add(product);
            }
            SetSelectedProducts();
        }

        #region Multiple Selection
        public void ClearSelectedValues()
        {
            SelectedProducts.Clear();
            grid.SelectedValues.Clear();
        }
        #endregion
        #endregion

        //##############################LIST_CONTROLS EVENTS#########################//
        #region LIST_CONTROLS EVENTS
        protected void grid_CustomPageIndexChanged(object sender, GridViewCommandEventArgs e)
        {
            SaveSelectedProducts();
            grid.VirtualPageIndex = Convert.ToInt32(e.CommandArgument);
            GetData();
        }
        protected void grid_CustomSorting(object sender, GridViewSortEventArgs e)
        {
            GetData();
        }
        #endregion

        //##############################SUPPORT METHODS#########################//
        #region SUPPORT METHODS
        protected override void OnSelectionChanged()
        {
            #region Multiple Selection
            if (grid.EnabledMultipleSelection && grid.MultipleSelectionOnRowClick)
            {
                if (!_isMultipleSelectionActived)
                {
                    SaveSelectedProducts();
                }
            }
            #endregion

            base.OnSelectionChanged();
        }
        protected override Product GetProductByID(String id)
        {
            return Products.Single(x => x.ProductITL == id);
        }
        private void GetData()
        {
            var products = GetArticlesFromWebService(grid.VirtualPageIndex, grid.PageSize);
            this.Products = products;
            this.SetPageCount(_vic);
            this.SelectedIndex = -1;
            this.BindData();
            SetSelectedProducts();
        }
        private void SetPageCount(int num)
        {
            grid.VirtualItemCount = num;
        }
        
        #region Multiple Selection
        private void SaveSelectedProducts()
        {
            if (grid.EnabledMultipleSelection)
            {
                foreach (GridViewRow r in grid.Rows)
                {
                    string ProductITL = grid.DataKeys[r.RowIndex].Value.ToString();
                    var product = Products.Single(x => x.ProductITL == ProductITL);
                    CheckBox cb = r.FindControl("cbSelect") as CheckBox;
                    if (cb.Checked)
                    {
                        // Add product
                        if (!SelectedProducts.Any(x => x.ProductITL == product.ProductITL))
                        {
                            SelectedProducts.Add(product);
                            _isMultipleSelectionActived = true;
                        }
                    }
                    else
                    {
                        // Remove product
                        if (SelectedProducts.Any(x => x.ProductITL == product.ProductITL))
                        {
                            SelectedProducts.RemoveAll(x => x.ProductITL == product.ProductITL);
                            _isMultipleSelectionActived = true;
                        }
                    }
                }
            }
        }
        private void SetSelectedProducts()
        {
            if (grid.EnabledMultipleSelection)
            {
                foreach (GridViewRow r in grid.Rows)
                {
                    string ProductITL = grid.DataKeys[r.RowIndex].Value.ToString();
                    var product = Products.Single(x => x.ProductITL == ProductITL);
                    CheckBox cb = r.FindControl("cbSelect") as CheckBox;

                    cb.Checked = SelectedProducts.Any(x => x.ProductITL == product.ProductITL);
                }
            }
        }
        #endregion
        #endregion
    }
}
