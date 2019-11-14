using System;
using System.Collections.Generic;
using DLWebFormsTemplates.Templates;
using System.Web.UI.WebControls;

namespace DLAPODemandCommons.Templates.Articles
{
    /// <summary>
    /// Template for ABDA and Local articles manager.
    /// </summary>
    public abstract class APOArticleSourceTemplate : DLComponentTemplate
    {
        public enum ArticleSource
        {
            ABDA,
            LOCAL
        }

        #region MEMBERS
        protected global::System.Web.UI.WebControls.RadioButtonList rblstArticleSource;
        #endregion

        #region CONSTANCES
        private const string VS_KEY_CurrentArticleSource = "CurrentArticleSource";
        #endregion

        #region EVENTS
        public event EventHandler ArticleSelectedChanged;
        public event EventHandler<CommandEventArgs> ArticleRowCommand;
        #endregion

        #region PROPERTIES
        protected abstract IAPOArticleTemplate CurrentArticleTemplate { get; }
        public bool HasSelectedRow
        {
            get
            {
                if (EnabledMultipleSelection)
                {
                    return SelectedProducts.Count > 0;
                }
                else
                {
                    return CurrentArticleTemplate.SelectedIndex > -1;
                }

            }
        }
        public bool IsExternCatalog
        {
            get { return CurrentArticleTemplate.IsExtern; }
        }
        public bool ReloadByCurrentParameter { get; set; }
        public ArticleSource CurrentArticleSource
        {
            get
            {
                if (ViewState[VS_KEY_CurrentArticleSource] == null)
                {
                    ChangeArticleSource();
                }
                return (ArticleSource)ViewState[VS_KEY_CurrentArticleSource];
            }
            protected set
            {
                ViewState[VS_KEY_CurrentArticleSource] = value;
                switch (value)
                {
                    case ArticleSource.ABDA:
                        rblstArticleSource.SelectedValue = "0";
                        break;
                    case ArticleSource.LOCAL:
                        rblstArticleSource.SelectedValue = "1";
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        public List<Product> SelectedProducts
        {
            get { return CurrentArticleTemplate.SelectedProducts; }
        }
        public Product SelectedProduct
        {
            get { return CurrentArticleTemplate.SelectedProduct; }
        }
        public List<Product> Products
        {
            get { return CurrentArticleTemplate.Products; }
        }
        // Enable or Disable multiple selection for items.
        public virtual bool EnabledMultipleSelection
        {
            get
            {
                return CurrentArticleTemplate.EnabledMultipleSelection;
            }
            set
            {
                CurrentArticleTemplate.EnabledMultipleSelection = value;
            }
        }
        public int VirtualPageIndex
        {
            get { return CurrentArticleTemplate.VirtualPageIndex;  }
            set { CurrentArticleTemplate.VirtualPageIndex = value; }
        }
        public List<SearchCondition> SearchConditions
        {
            get
            {
                return CurrentArticleTemplate.SearchConditions;
            }
            set
            {
                CurrentArticleTemplate.SearchConditions = value;
            }
        }
        #endregion

        //#############################PUBLIC METHODS################################//
        #region PUBLIC METHODS
        public void ImportSelectedProducts()
        {
            CurrentArticleTemplate.ImportSelectedProducts();
        }
        public void AddSearchCondition(SearchParameter parameter)
        {
            parameter = parameter ?? new SearchParameter();

            CurrentArticleTemplate.ClearSearchConditions();

            if (!string.IsNullOrEmpty(parameter.MainSearch))
                CurrentArticleTemplate.AddSearchConditions(new SearchCondition { field = ProductField.NAME, query = parameter.MainSearch });

            if (!string.IsNullOrEmpty(parameter.Unit))
                CurrentArticleTemplate.AddSearchConditions(new SearchCondition { field = ProductField.UNIT, query = parameter.Unit });

            if (!string.IsNullOrEmpty(parameter.DossageFormName))
                CurrentArticleTemplate.AddSearchConditions(new SearchCondition { field = ProductField.DOSAGE_FORM, query = parameter.DossageFormName });

            if (!string.IsNullOrEmpty(parameter.ProductNumber))
                CurrentArticleTemplate.AddSearchConditions(new SearchCondition { field = ProductField.CODE, query = parameter.ProductNumber });

            if (!string.IsNullOrEmpty(parameter.ProducerName))
                CurrentArticleTemplate.AddSearchConditions(new SearchCondition { field = ProductField.PRODUCER, query = parameter.ProducerName });

            CurrentArticleTemplate.AddSearchConditions(new SearchCondition { field = ProductField.IS_PART_OF_DEFAULT_STOCK, query = parameter.InDefaultStock.ToString().ToLower() });
        }
        public virtual void ReloadArticleSource()
        {
            CurrentArticleTemplate.Show();
            if (!ReloadByCurrentParameter)
            {
                CurrentArticleTemplate.GetArticlesFromBegin();
            }
            else
            {
                CurrentArticleTemplate.GetArticles();
            }
            CurrentArticleTemplate.BindData();
        }
        public void BindData()
        {
            CurrentArticleTemplate.BindData();
        }
        public void SelectItemByID(String productITL)
        {
            CurrentArticleTemplate.SelectItemByID(productITL);
        }
        public void SelectItemsByIDs(List<String> productITLs)
        {
            CurrentArticleTemplate.SelectItemsByIDs(productITLs);
        }

        public void CustomChangeArticleSource(ArticleSource articleSource)
        {
            CurrentArticleTemplate.Hide();
            CurrentArticleSource = articleSource;
        }
        #endregion

        //##################################EVENTS###################################//
        #region EVENTS
        #endregion

        //##############################LIST_CONTROLS EVENTS#########################//
        #region LIST_CONTROLS EVENTS
        protected void rblstArticleSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnArticleSourceChanged();
        }
        protected void ArticleControl_SelectionChanged(object sender, EventArgs e)
        {
            OnArticleSelectionChanged();
        }
        protected void ArticleControl_CustomRowCommand(object sender, GridViewCommandEventArgs e)
        {
            OnArticleRowCommand(e);
        }
        #endregion

        //############################SUPPORT METHODS################################//
        #region SUPPORT METHODS
        protected virtual void OnArticleSelectionChanged()
        {
            if (ArticleSelectedChanged != null)
            {
                ArticleSelectedChanged(this, EventArgs.Empty);
            }
        }
        protected virtual void OnArticleRowCommand(GridViewCommandEventArgs e)
        {
            if (ArticleRowCommand != null)
            {
                CommandEventArgs args = new CommandEventArgs(e.CommandName, e.CommandArgument);
                ArticleRowCommand(this, args);
            }
        }
        protected void ChangeArticleSource()
        {
            switch (rblstArticleSource.SelectedValue)
            {
                case "0":
                    CurrentArticleSource = ArticleSource.ABDA;
                    break;
                case "1":
                    CurrentArticleSource = ArticleSource.LOCAL;
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
        protected virtual void OnArticleSourceChanged()
        {
            CurrentArticleTemplate.Hide();
            ChangeArticleSource();
            ReloadArticleSource();
        }
        #endregion
    }
}
