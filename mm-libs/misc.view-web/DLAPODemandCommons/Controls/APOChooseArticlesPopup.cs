using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Logger;
using System.Web.Script.Serialization;
using DLAPODemandCommons.Controls.Classes;


namespace DLAPODemandCommons.Controls
{
    internal enum WebResourceType { ScriptJavascript, ScriptTextTemplate };

    [ToolboxData("<{0}:APOChooseArticlesPopup ID='dlAPOChooseArticlesPopup' runat='server'></{0}:APOChooseArticlesPopup>")]
    public class APOChooseArticlesPopup : CompositeControl
    {
        #region Public events

        internal    event EventHandler<ArticlesChosenArgs> ArticlesChoosen;                         //This event is used from APOArticleSearch Control because, import article has to be overrided there
        public      event EventHandler<ArticlesChosenAndImportedArgs> ArticlesChoosenAndImported;

        #endregion

        #region Private Fileds

        private List<String> _selectedArticleITLs { get; set; }
        AbstractArticleProxy _articleProxy;
        private String _articlesWebServiceUrl;

        #endregion

        #region Public properties

        public String ArticlesWebServiceUrl
        {
            get
            {
                if (String.IsNullOrEmpty(_articlesWebServiceUrl))
                    throw new Exception("Property ArticlesWebServiceUrl is not specified!");

                return Page.ResolveUrl(_articlesWebServiceUrl);
            }
            set
            {
                _articlesWebServiceUrl = value;
            }
        }

        public Boolean IsTriggerButtonHidden { get; set; }
        public EChooseArticlesSelectionMode SelectionMode { get; set; }

        //Need this for metaresource tag
        public String SearchSimpleSearchPlaceholder { get; set; }
        public String SearchDosageFormLabel { get; set; }
        public String SearchUnitLabel { get; set; }
        public String SearchProducerLabel { get; set; }
        public String SearchIsProductPartOfDefaultStockLabel { get; set; }

        public String Title { get; set; }

        #endregion

        #region Consts

        private const string RELOAD_TABLE_CONTENT_JS = "resetArticlesTable(); registerOnScroll(); ";

        #endregion    

        #region Controls
		
        private HtmlGenericControl _hTitle;

        private LinkButton _lbtnShowPopup;
        private APOChooseArticlesTable _articlesTable;
        private Panel _pnlPopupWrapper;
        private Panel _pnlPopup;
		
        private Panel _pnlButtons;
        private LinkButton _lbtnConfirm;
        private LinkButton _lbtnCancel;

        private APOChooseArticlesPopupSearch _dlChoosePopupSearch;
        private HiddenField _hiddenSelectedProducts;
        private HiddenField _hiddenArticlesWebServiceUrl;

        #endregion

        #region Constructors

        public APOChooseArticlesPopup()
        {
            
        }

        public APOChooseArticlesPopup(AbstractArticleProxy articleProxy)
        {
            this._articleProxy = articleProxy;
        }

        #endregion

        #region Public methods

        public void Show(String searchCondition)
        {
            Show();

            if (!string.IsNullOrEmpty(searchCondition))
                _dlChoosePopupSearch.RaiseSimpleSearchForParam(searchCondition);
            else
                InitBackboneAndRelaodTableContent();
        }

        public List<ArticleModelFromChoosePopup> GetSelectedArticlesModel()
        {
            return _articleProxy.GetSelectedArticlesModel(_selectedArticleITLs);
        }

        #region Public Methods

        public Boolean IsPopupOpened()
        {
            if (_pnlPopupWrapper == null)
                return false;

            return _pnlPopupWrapper.Visible;
        }

        #endregion

        #endregion

        #region Override

        public override void RenderBeginTag(HtmlTextWriter writer)
        {
            writer.Write("<div id='pnlChooseArticleControl'>");
        }

        public override void RenderEndTag(HtmlTextWriter writer)
        {
            writer.Write("</div>");
        }

        protected override void OnInit(EventArgs e)
        {
            EnsureWebResourceRegistration("DLAPODemandCommons.Controls.HtmlTemplates.articlesTemplate.htm", WebResourceType.ScriptTextTemplate, "articlesTemplate.htm");
            EnsureWebResourceRegistration("DLAPODemandCommons.Controls.Scripts.apo-demand-commons.js", WebResourceType.ScriptJavascript, "apo-demand-commons.js");

            base.OnInit(e);
        }
        
        protected override void CreateChildControls()
        {
            InitShowPopupButton();

            InitPanelPopup();

            InitTitle();
            InitSearchControl();
            InitArticlesTable();
            InitButtons();
            InitHiddenSelectedProducts();
            InitAutoCompleteHandlerUrlControl();

            ToggleViewTable(false);
        }

        #endregion

        #region Initialize components

        private void InitTitle()
        {
            if (_hTitle == null) {
                _hTitle = new HtmlGenericControl("h1");
                _hTitle.InnerHtml = Title;

                _pnlPopup.Controls.Add(_hTitle);
            }
        }
        
        private void InitButtons()
        {
            if (_pnlButtons == null) {
                _pnlButtons = new Panel
                {
                    CssClass = "buttons"
                };

                _pnlPopup.Controls.Add(_pnlButtons);
            }

            _lbtnCancel = new LinkButton
            {
                ID = "lbtnCancel",
                CssClass = "cancel",
                Text = "Cancel"
            };
            _lbtnCancel.Click += _lbtnCancel_Click;
            _pnlButtons.Controls.Add(_lbtnCancel);

            if (_lbtnConfirm == null)
            {
                _lbtnConfirm = new LinkButton
                {
                    ID = "lbtnConfirm",
                    CssClass = "button",
                    Text = "Confirm",
                    OnClientClick = "saveSelectedIDs(this);"
                };
            }
            _lbtnConfirm.Click += _lbtnConfirm_Click;
            _pnlButtons.Controls.Add(_lbtnConfirm);
        }

        private void InitShowPopupButton()
        {
            _lbtnShowPopup = new LinkButton
            {
                ID = "lbtnShowPopup",
                CssClass = "icons-add"
            };

            if(IsTriggerButtonHidden)
                _lbtnShowPopup.Attributes["style"] = "display:none";

            _lbtnShowPopup.Click += new EventHandler(_lbtnShowPopup_Click);
            this.Controls.Add(_lbtnShowPopup);
        }

        private void InitArticlesTable()
        {
            _articlesTable = new APOChooseArticlesTable
            {
                ID = "articlesTable",
                ClientIDMode =  System.Web.UI.ClientIDMode.Static,
                SelectionMode = this.SelectionMode
            };
            _pnlPopup.Controls.Add(_articlesTable);
        }

        private void InitSearchControl()
        {
            _dlChoosePopupSearch = new APOChooseArticlesPopupSearch
            {
                ID = "dlChoosePopupSearch",
                ClientIDMode = System.Web.UI.ClientIDMode.Static,
                SimpleSearchPlaceholder = SearchSimpleSearchPlaceholder,
                DosageFormLabel = SearchDosageFormLabel,
                UnitLabel = SearchUnitLabel,
                ProducerLabel = SearchProducerLabel,
                IsProductPartOfDefaultStockLabel = SearchIsProductPartOfDefaultStockLabel
            };

            _dlChoosePopupSearch.SearchClick += dlChoosePopupSearch_OnSearchClick;

            _pnlPopup.Controls.Add(_dlChoosePopupSearch);
        }

        private void InitHiddenSelectedProducts()
        {
            _hiddenSelectedProducts = new HiddenField
            {
                ID = "hiddenSelectedArticlesInChoosePopupTable",
                ClientIDMode = System.Web.UI.ClientIDMode.Static
            };

            _pnlPopup.Controls.Add(_hiddenSelectedProducts);
        }

        private void InitAutoCompleteHandlerUrlControl()
        {
            if (_hiddenArticlesWebServiceUrl == null)
            {
                _hiddenArticlesWebServiceUrl = new HiddenField();
                _hiddenArticlesWebServiceUrl.ID = "hiddenArticlesWebServiceUrl";
                _hiddenArticlesWebServiceUrl.ClientIDMode = System.Web.UI.ClientIDMode.Static;

                _hiddenArticlesWebServiceUrl.Value = ArticlesWebServiceUrl;

                _pnlPopup.Controls.Add(_hiddenArticlesWebServiceUrl);
            }
        }

        private void InitPanelPopup()
        {
            _pnlPopupWrapper = new Panel
            {
                ID = "pnlPopupWrapper",
                CssClass = "popup-wraper",
                ClientIDMode = System.Web.UI.ClientIDMode.Static,
                Visible = false
            };

            _pnlPopup = new Panel() {
                ID = "pnlPopup",
                ClientIDMode = System.Web.UI.ClientIDMode.Static,
                CssClass = "popup big js-ignore-draggable"
            };

            _pnlPopupWrapper.Controls.Add(_pnlPopup);
            this.Controls.Add(_pnlPopupWrapper);
        }

        #endregion

        #region Support methods

        private void Show()
        {
            APOChooseArticlesTable.ClearSession();
            ToggleViewTable(true); 
        }

        private void InitBackboneAndRelaodTableContent()
        {
            ScriptManager.RegisterClientScriptBlock(this._lbtnShowPopup, this.Page.GetType(), "Key", RELOAD_TABLE_CONTENT_JS, true);
        }

        private void ToggleViewTable(bool isVisible)
        {
            _pnlPopupWrapper.Visible = isVisible;
        }

        private void EnsureWebResourceRegistration(string path, WebResourceType wrType, string resourceName)
        {
            var wrUrl = this.Page.ClientScript.GetWebResourceUrl(this.GetType().BaseType, path);
            // Check if it script is already registered
            var alreadyRegistered = this.Page.Header.Controls.OfType<HtmlGenericControl>().Any(x => x.InnerText == resourceName);
            if (!alreadyRegistered)
            {
                switch (wrType)
                {
                    case WebResourceType.ScriptJavascript:
                        EnsureJavascriptRegistration(wrUrl, resourceName);
                        break;
                    case WebResourceType.ScriptTextTemplate:
                        EnsureHtmlTextTemplateRegistration(path);
                        break;
                }

            }
        }

        private void EnsureJavascriptRegistration(string wrUrl, string resourceName)
        {           
            HtmlGenericControl include = new HtmlGenericControl("script");
            include.Attributes.Add("src", wrUrl);
            include.Attributes.Add("type", "text/javascript");
            include.InnerText = resourceName;
            this.Page.Header.Controls.Add(include);
        }

        private void EnsureHtmlTextTemplateRegistration(string path)
        {
            HtmlGenericControl include = new HtmlGenericControl();
            include.InnerHtml = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(path)).ReadToEnd();
            include.Attributes.Add("type", "text/template");
            this.Page.Header.Controls.Add(include);
        }

        private List<string> GetITLsFromHiddenField(HiddenField _hiddenSelectedProducts)
        {
            List<string> selectedITLs = new JavaScriptSerializer().Deserialize<List<String>>(_hiddenSelectedProducts.Value);
            return selectedITLs;
        }

        private void DispatchArticleChoosenEvent(List<String> selectedITLs)
        {
            if (ArticlesChoosen != null)
            {
                var arg = new ArticlesChosenArgs
                {
                    SelectedITLList = selectedITLs
                };

                ArticlesChoosen(null, arg);
            }
        }

        private void DispatchArticleChoosenAndImportedEvent(List<String> selectedITLs)
        {
            if (ArticlesChoosenAndImported != null)
            {
                var arg = new ArticlesChosenAndImportedArgs
                {
                    ImportedItlIdPairs = _articleProxy.ImportSelectedArticlesAndGetResult(selectedITLs)
                };

                ArticlesChoosenAndImported(null, arg);
            }
        }

        #endregion

        #region Event Handlers

        protected void _lbtnConfirm_Click(object source, EventArgs e)
        {
            try
            {
                _selectedArticleITLs = GetITLsFromHiddenField(_hiddenSelectedProducts);

                DispatchArticleChoosenEvent(_selectedArticleITLs);
                DispatchArticleChoosenAndImportedEvent(_selectedArticleITLs);

                ToggleViewTable(false);
            }
            catch (Exception ex)
            {
                ServerLog.Instance.Error(ex);
            }
        }

        protected void _lbtnCancel_Click(object source, EventArgs e)
        {
            ToggleViewTable(false);
        }

        protected void _lbtnShowPopup_Click(object sender, EventArgs e)
        {
            Show();
            InitBackboneAndRelaodTableContent();
        }

        protected void dlChoosePopupSearch_OnSearchClick(object sender, DLAPODemandCommons.Controls.APOChooseArticlesPopupSearch.APOChoosePopupSearchClickEventArgs e)
        {
            APOChooseArticlesTable.SearchParam = e.Param;
            InitBackboneAndRelaodTableContent();
        }

        #endregion
    }
}
