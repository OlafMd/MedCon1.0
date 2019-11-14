using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Resources;
using Logger;
using DLAPODemandCommons.Controls.Classes;
using System.Web;

namespace DLAPODemandCommons.Controls
{

    [ToolboxData("<{0}:APOArticleSearch ID='dlArticleSearch' runat='server'></{0}:APOArticleSearch>")]
    public class APOArticleSearch : CompositeControl
    {
        #region Public events

        public event EventHandler<ArticlesChosenAndImportedArgs> ArticlesChoosenAndImported;

        #endregion

        #region Private Fields

        private List<String> _selectedArticleITLs;
        AbstractArticleProxy _articleProxy;
        private String _autoCompleteHandlerUrl;


        public APOArticleSearch(AbstractArticleProxy articleProxy) 
        {
            this._articleProxy = articleProxy;
        }

        #endregion

        #region Public properties

        public String AutoCompleteHandlerUrl
        {
            get
            {
                if (String.IsNullOrEmpty(_autoCompleteHandlerUrl))
                    throw new Exception("Property AutoCompleteHandlerUrl is not specified!");

                return Page.ResolveUrl(_autoCompleteHandlerUrl);
            }
            set
            {
                _autoCompleteHandlerUrl = value;
            }
        }
        public String ArticlesWebServiceUrl { get; set; }

        public EChooseArticlesSelectionMode SelectionMode { get; set; }

        public Boolean _setFocusOnPreRender = true;
        public Boolean SetFocusOnPreRender
        {
            get { return _setFocusOnPreRender; }
            set { _setFocusOnPreRender = value; }
        }

        //Need this for metaresource tag
        public String PopUpSearchSimpleSearchPlaceholder { get; set; }
        public String PopUpSearchDosageFormLabel { get; set; }
        public String PopUpSearchUnitLabel { get; set; }
        public String PopUpSearchProducerLabel { get; set; }
        public String PopUpSearchIsProductPartOfDefaultStockLabel { get; set; }

        public String PopUpTitle { get; set; }

        #endregion

        #region Public Methods

        public List<ArticleModelFromChoosePopup> GetSelectedArticlesModel()
        {
            return _articleProxy.GetSelectedArticlesModel(_selectedArticleITLs);
        }

        public Boolean IsPopupOpened() {

            if (_dlArticlesPopUp == null)
                return false;

            return _dlArticlesPopUp.IsPopupOpened();
        }

        public string GetTextFromTextBox()
        {
            return _tbSearch.Text;
        }


        public void SetSelectedITLToNull()
        {
            _selectedArticleITLs = null;
            _hiddenSelectedItemITL.Value = null;
            
        }

        public void SetDefaultProductInTextBox(string pzn, string article)
        {
            if (string.IsNullOrEmpty(pzn)  || string.IsNullOrEmpty(article)) 
            {
                _tbSearch.Text = HttpContext.GetGlobalResourceObject("Global", "NoItemIsSelected" ).ToString();
            }
            else
            _tbSearch.Text = string.Format("PZN: {0}, Artikel: {1}", pzn, article);
            
        }

        #endregion

        #region Controls

        protected Panel _searchPanel;
        protected TextBox _tbSearch;
        protected HiddenField _hiddenSelectedItemITL;
        protected HiddenField _hiddenAutoCompleteHandlerUrl;
        protected LinkButton _lbtnChooseArticle;
        protected LinkButton _lbtnOpenPopup;

        protected APOChooseArticlesPopup _dlArticlesPopUp;

        #endregion

        #region Override 

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            EnsureJavascriptRegistration();            
        }

        protected override void CreateChildControls()
        {
            this.Controls.Clear();

            InitPanels();
            InitSelectedItemITLControl();
            InitAutoCompleteHandlerUrlControl();
            InitSearchControl();
            InitChooseArticleButton();
            InitOpenPopupButton();
            InitArticlesPopUp();
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            _tbSearch.Enabled = this.Enabled;
            _lbtnChooseArticle.Enabled = this.Enabled;
            _dlArticlesPopUp.Enabled = this.Enabled;

            if (!IsPopupOpened() && SetFocusOnPreRender)
            {
                _tbSearch.Focus();
            }
        }

        public override void Focus()
        {
            this.EnsureChildControls();

            _tbSearch.Focus();
        }

        #endregion

        #region Support Methods

        private void InitPanels()
        {
            if (_searchPanel == null)
            {
                _searchPanel = new Panel();
                _searchPanel.ID = "pnlAutocompleteSearch";
                _searchPanel.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                _searchPanel.CssClass = "autocomplete-search";

                this.Controls.Add(_searchPanel);
            }
        }

        private void InitSelectedItemITLControl() {
            
            if (_hiddenSelectedItemITL == null)
            {
                _hiddenSelectedItemITL = new HiddenField();
                _hiddenSelectedItemITL.ID = "hiddenSelectedItemITL";
                _hiddenSelectedItemITL.ClientIDMode = System.Web.UI.ClientIDMode.Static;

                _searchPanel.Controls.Add(_hiddenSelectedItemITL);
            }
        }

        private void InitAutoCompleteHandlerUrlControl()
        {
            if (_hiddenAutoCompleteHandlerUrl == null)
            {
                _hiddenAutoCompleteHandlerUrl = new HiddenField();
                _hiddenAutoCompleteHandlerUrl.ID = "hiddenAutoCompleteHandlerUrl";
                _hiddenAutoCompleteHandlerUrl.ClientIDMode = System.Web.UI.ClientIDMode.Static;


                _hiddenAutoCompleteHandlerUrl.Value = AutoCompleteHandlerUrl;

                _searchPanel.Controls.Add(_hiddenAutoCompleteHandlerUrl);
            }
        }

        private void InitSearchControl()
        {
            if (_tbSearch == null)
            {
                _tbSearch = new TextBox();
                _tbSearch.ID = "tbSearch";
                _tbSearch.CssClass = "js_autocomplete";

                _searchPanel.Controls.Add(_tbSearch);
            }
        }

        private void InitChooseArticleButton()
        {
            if (_lbtnChooseArticle == null)
            {
                _lbtnChooseArticle = new LinkButton();
                _lbtnChooseArticle.ID = "lbtnChooseArticle";
                _lbtnChooseArticle.CssClass = "js_choose_article";
                _lbtnChooseArticle.Text = "Choose article";
                _lbtnChooseArticle.Attributes["style"] = "display:none;";
                _lbtnChooseArticle.Click += new EventHandler(_lbtnChooseArticle_Click);

                _searchPanel.Controls.Add(_lbtnChooseArticle);
            }
        }

        private void InitOpenPopupButton()
        {
            if (_lbtnOpenPopup == null)
            {
                _lbtnOpenPopup = new LinkButton();
                _lbtnOpenPopup.ID = "lbtnOpenPopup";
                _lbtnOpenPopup.CssClass = "js_open_popup";
                _lbtnOpenPopup.Text = "Open Popup";
                _lbtnOpenPopup.Attributes["style"] = "display:none;";

                _lbtnOpenPopup.Click += new EventHandler(_lbtnOpenPopup_Click);

                _searchPanel.Controls.Add(_lbtnOpenPopup);
            }
        }

        private void InitArticlesPopUp()
        {
            if (_dlArticlesPopUp == null)
            {
                _dlArticlesPopUp = new APOChooseArticlesPopup();
                _dlArticlesPopUp.ID = "dlArticlesPopUp";
                _dlArticlesPopUp.SearchUnitLabel = PopUpSearchUnitLabel;
                _dlArticlesPopUp.SearchSimpleSearchPlaceholder = PopUpSearchSimpleSearchPlaceholder;
                _dlArticlesPopUp.SearchDosageFormLabel = PopUpSearchDosageFormLabel;
                _dlArticlesPopUp.SearchUnitLabel = PopUpSearchUnitLabel;
                _dlArticlesPopUp.SearchProducerLabel= PopUpSearchProducerLabel;
                _dlArticlesPopUp.SearchIsProductPartOfDefaultStockLabel = PopUpSearchIsProductPartOfDefaultStockLabel;
                _dlArticlesPopUp.Title = PopUpTitle;
                _dlArticlesPopUp.SelectionMode = SelectionMode;
                _dlArticlesPopUp.ArticlesWebServiceUrl = ArticlesWebServiceUrl;

                _dlArticlesPopUp.ArticlesChoosen += new EventHandler<ArticlesChosenArgs>(_dlArticlesPopUp_ArticlesChoosen);

                this.Controls.Add(_dlArticlesPopUp);
            }
        }

        private void EnsureJavascriptRegistration()
        {
            // Get the stylesheet resource URL
            var styleSheetUrl = this.Page.ClientScript.GetWebResourceUrl(
                                this.GetType().BaseType, "DLAPODemandCommons.Controls.Scripts.apo-demand-commons.js");

            // Check if this stylesheet is already registered
            var alreadyRegistered = this.Page.Header.Controls.OfType<HtmlGenericControl>().Any(x => x.InnerText == "apo-demand-commons.js");
            if (alreadyRegistered)

                return; // no work here

            // If not, register it
            HtmlGenericControl Include = new HtmlGenericControl("script");
            Include.Attributes.Add("src", styleSheetUrl);
            Include.Attributes.Add("type", "text/javascript");
            Include.InnerText = "apo-demand-commons.js";
            this.Page.Header.Controls.Add(Include);
        }

        #endregion

        #region Event Handlers

        protected void _lbtnOpenPopup_Click(object source, EventArgs e)
        {
            try
            {

                var searchCondition = _tbSearch.Text;
                _dlArticlesPopUp.Show(searchCondition);

            }
            catch (Exception ex)
            {
                ServerLog.Instance.Error(ex);
            }
        }

        protected void _lbtnChooseArticle_Click(object source, EventArgs e)
        {
            try
            {
                _selectedArticleITLs = new List<String>()
                    {_hiddenSelectedItemITL.Value};

                DispatchArticleChoosenAndImportedEvent(_selectedArticleITLs);
                
            }
            catch (Exception ex) 
            {
                ServerLog.Instance.Error(ex);
            }
        }

        protected void _dlArticlesPopUp_ArticlesChoosen(object source, ArticlesChosenArgs e)
        {
            try
            {
                _selectedArticleITLs = e.SelectedITLList;

                DispatchArticleChoosenAndImportedEvent(_selectedArticleITLs);
            }
            catch (Exception ex)
            {
                ServerLog.Instance.Error(ex);
            }
        }

        private void DispatchArticleChoosenAndImportedEvent(List<String> selectedITLs)
        {
            if (ArticlesChoosenAndImported != null)
            {
                var arg = new ArticlesChosenAndImportedArgs()
                {
                    ImportedItlIdPairs = _articleProxy.ImportSelectedArticlesAndGetResult(selectedITLs)
                };

                ArticlesChoosenAndImported(null, arg);
            }
        }

        #endregion

    }
}

