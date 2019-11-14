using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Logger;

namespace DLAPODemandCommons.Controls
{
    [ToolboxData("<{0}:APOChooseArticlesPopupSearch ID='dlAPOChooseArticlesPopupSearch' runat='server'></{0}:APOChooseArticlesPopupSearch>")]
    public class APOChooseArticlesPopupSearch : UserControl
    {
        private const string VIEW_STATE_KEY_UNITS = "VIEW_STATE_KEY_UNITS";

        #region Public events

        public event EventHandler<APOChoosePopupSearchClickEventArgs> SearchClick;

        #endregion

        #region Public properties

        public String SimpleSearchPlaceholder { get; set; }
        public String DosageFormLabel { get; set; }
        public String UnitLabel { get; set; }
        public String ProducerLabel { get; set; }
        public String IsProductPartOfDefaultStockLabel { get; set; }

        #endregion

        #region Public methods

        public void SetUnits(List<ChoosePopupSearchUnit> units)
        {
            Units = units;
        }

        public void ClearFields()
        {
            _tbSimpleSearch.Text = "";
            _tbProducer.Text = "";
            _cbIsProductPartOfDefaultStock.Checked = false;
        }

        public void RaiseSimpleSearchForParam(String simpleSearchText)
        {
            EnsureChildControls();

            _tbSimpleSearch.Text = simpleSearchText;
            RaiseSimpleSearchClickEvent();
        }
      
        #endregion

        #region Private Properties

        private Panel _pnlSimpleSearch;
        private TextBox _tbSimpleSearch;
        private HtmlGenericControl _iAdvancedSearchTrigger;
        private LinkButton _lbtnSimpleSearch;

        private Panel _pnlAdvancedSearch;
        private TextBox _tbDosageForm;
        private DropDownList _ddlUnit;
        private TextBox _tbProducer;
        private CheckBox _cbIsProductPartOfDefaultStock ;

        private LinkButton _lbtnAdvancedSearch;

        protected List<ChoosePopupSearchUnit> Units
        {
            get
            {
                return ViewState[VIEW_STATE_KEY_UNITS] as List<ChoosePopupSearchUnit>;
            }
            set
            {
                ViewState[VIEW_STATE_KEY_UNITS] = value;
            }
        }

        #endregion

        #region Override

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            EnsureJavascriptRegistration();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            EnsureChildControls();
            ResolveCustomRequests();
            SetUnitsFilter();   
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            if(this.Visible)
                _tbSimpleSearch.Focus();
        }
        protected override void CreateChildControls()
        {
            this.Controls.Clear();

            var mainPanel = new Panel();
            mainPanel.CssClass = "advanced-search";
  
            InitSimpleSearchPanel(mainPanel);
            InitAdvancedSearchPanel(mainPanel);

            this.Controls.Add(mainPanel);
        }

        #endregion

        #region Support Methods

        #region SimpleSearchPanel

        private void InitSimpleSearchPanel(Panel parent)
        {

            if (_pnlSimpleSearch == null)
            {
                _pnlSimpleSearch = new Panel();
                _pnlSimpleSearch.ID = "pnlSimpleSearch";
                _pnlSimpleSearch.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                _pnlSimpleSearch.CssClass = "search-holder";

                InitSimpleSearchTextBox(_pnlSimpleSearch);
                InitArrowAdvancedSearchTrigger(_pnlSimpleSearch);
                InitSimpleSearchLinkButton(_pnlSimpleSearch);

                parent.Controls.Add(_pnlSimpleSearch);
            }
        }

        private void InitSimpleSearchTextBox(Panel parent)
        {

            if (_tbSimpleSearch == null)
            {
                _tbSimpleSearch = new TextBox();
                _tbSimpleSearch.ID = "tbSimpleSearch";
                _tbSimpleSearch.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                _tbSimpleSearch.Attributes["placeholder"] = SimpleSearchPlaceholder;
                _tbSimpleSearch.Attributes["onfocus"] = "SetEnd(this)";
                _tbSimpleSearch.Attributes["onkeydown"] = "return EnterEventAdvancedSearch(this, event, 'custom-requests$searche-simple');";
               
                parent.Controls.Add(_tbSimpleSearch);
            }
        }

        private void InitArrowAdvancedSearchTrigger(Panel parent)
        {
            if (_iAdvancedSearchTrigger == null)
            {
                _iAdvancedSearchTrigger = new HtmlGenericControl("i");

                parent.Controls.Add(_iAdvancedSearchTrigger);
            }
        }

        private void InitSimpleSearchLinkButton(Panel parent)
        {
            if (_lbtnSimpleSearch == null)
            {
                _lbtnSimpleSearch = new LinkButton();
                _lbtnSimpleSearch.ID = "lbtnSimpleSearch";
                _lbtnSimpleSearch.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                _lbtnSimpleSearch.Click += new EventHandler(_lbtnSimpleSearch_Click);

                parent.Controls.Add(_lbtnSimpleSearch);
            }
        }

        #endregion

        #region AdvancedSearchTriger

        private void InitAdvancedSearchPanel(Panel parent)
        {
            if ( _pnlAdvancedSearch== null)
            {
                _pnlAdvancedSearch = new Panel();
                _pnlAdvancedSearch.ID = "pnlAdvancedSearch";
                _pnlAdvancedSearch.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                _pnlAdvancedSearch.CssClass = "advanced-open";

                var ulControl = new HtmlGenericControl("ul");
                
                InitDosageFormFilter(ulControl);
                InitUnitsFilter(ulControl);
                InitProducerFilter(ulControl);
                InitIProductPartOfDefaultStock(ulControl);
                
                _pnlAdvancedSearch.Controls.Add(ulControl);
                InitAdvancedSearchLinkButton(_pnlAdvancedSearch);
                parent.Controls.Add(_pnlAdvancedSearch);
            }
        }

        private void InitDosageFormFilter(HtmlGenericControl parent)
        {
            if (_tbDosageForm == null)
            {
                var liControl = new HtmlGenericControl("li");

                var _lblDosageForm = new Label();
                _lblDosageForm.ID = "lblDosageForm";
                _lblDosageForm.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                _lblDosageForm.Text = DosageFormLabel;

                _tbDosageForm = new TextBox();
                _tbDosageForm.ID = "tbDosageForm";
                _tbDosageForm.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                _tbDosageForm.Attributes["onfocus"] = "SetEnd(this)";
                _tbDosageForm.Attributes["onkeydown"] = "return EnterEventAdvancedSearch(this, event, 'custom-requests$search-dossage');";

                liControl.Controls.Add(_lblDosageForm);
                liControl.Controls.Add(_tbDosageForm);

                parent.Controls.Add(liControl);
            }
        }

        private void InitUnitsFilter(HtmlGenericControl parent)
        {
            if (_ddlUnit == null)
            {
                var liControl = new HtmlGenericControl("li");

                var _lblUnit = new Label();
                _lblUnit.ID = "lblUnit";
                _lblUnit.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                _lblUnit.Text = UnitLabel;

                _ddlUnit = new DropDownList();
                _ddlUnit.ID = "ddlUnit";
                _ddlUnit.ClientIDMode = System.Web.UI.ClientIDMode.Static;

                liControl.Controls.Add(_lblUnit);
                liControl.Controls.Add(_ddlUnit);

                parent.Controls.Add(liControl);
            }
        }

        private void InitProducerFilter(HtmlGenericControl parent)
        {
            if (_tbProducer == null)
            {
                var liControl = new HtmlGenericControl("li");

                var _lblProducer = new Label();
                _lblProducer.ID = "lblProducer";
                _lblProducer.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                _lblProducer.Text = ProducerLabel;

                _tbProducer = new TextBox();
                _tbProducer.ID = "tbProducer";
                _tbProducer.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                _tbProducer.Attributes["onfocus"] = "SetEnd(this)";
                _tbProducer.Attributes["onkeydown"] = "return EnterEventAdvancedSearch(this, event, 'custom-requests$search-producer');";

                liControl.Controls.Add(_lblProducer);
                liControl.Controls.Add(_tbProducer);

                parent.Controls.Add(liControl);
            }
        }

        private void InitIProductPartOfDefaultStock(HtmlGenericControl parent)
        {
            if (_cbIsProductPartOfDefaultStock == null)
            {
                var liControl = new HtmlGenericControl("li");

                _cbIsProductPartOfDefaultStock = new CheckBox();
                _cbIsProductPartOfDefaultStock.ID = "cbIsProductPartOfDefaultStock";
                _cbIsProductPartOfDefaultStock.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                _cbIsProductPartOfDefaultStock.Text = "Nur Lager";

                liControl.Controls.Add(_cbIsProductPartOfDefaultStock);

                parent.Controls.Add(liControl);
            }
        }

        private void InitAdvancedSearchLinkButton(Panel parent)
        {
            if (_lbtnAdvancedSearch == null)
            {
                _lbtnAdvancedSearch = new LinkButton();
                _lbtnAdvancedSearch.ID = "lbtnAdvancedSearch";
                _lbtnAdvancedSearch.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                _lbtnAdvancedSearch.Click += new EventHandler(lbtnAdvancedSearch_onClick);
                _lbtnAdvancedSearch.CssClass = "lbtnAdvancedSearch";

                parent.Controls.Add(_lbtnAdvancedSearch);
            }
        }


        #endregion

        private void SetUnitsFilter() 
        {
            if (Units != null && _ddlUnit.Items.Count == 0)
            {
                _ddlUnit.Items.Clear();

                // Add empty value as default
                _ddlUnit.Items.Add(new ListItem("&nbsp;", ""));

                var items = Units.Select(i =>
                    new ListItem()
                    {
                        Value = i.UnitID.ToString(),
                        Text = i.UnitName
                    }).ToArray();

                _ddlUnit.Items.AddRange(items);
            }

        }

        private void EnsureJavascriptRegistration()
        {
            // Get the stylesheet resource URL
            var styleSheetUrl = this.Page.ClientScript.GetWebResourceUrl(
                                this.GetType(), "DLAPODemandCommons.Controls.Scripts.apo-demand-commons.js");

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

        private void ResolveCustomRequests()
        {
            var reqArg = Request.Params["__EVENTARGUMENT"];

            if (
                reqArg != null
                && reqArg.Split('$').Length > 1
                && reqArg.Split('$')[0] == "custom-requests")
            {
                switch (Request.Params["__EVENTARGUMENT"].Split('$')[1])
                {
                    case "searche-simple":
                        RaiseSimpleSearchClickEvent();
                        _tbSimpleSearch.Focus();
                        break;
                    case "search-dossage":
                        RaiseAdvancedSearchClickEvent();
                        _tbDosageForm.Focus();
                        break;
                    case "search-producer":
                        RaiseAdvancedSearchClickEvent();
                        _tbProducer.Focus();
                        break;

                    //case "advanced-search-unity":
                    //     RaiseAdvancedSearchClickEvent();
                    //     _ddlUnit.Focus();
                    //     break;
                }
            }
        }

        private void RaiseSimpleSearchClickEvent()
        {
            APOChoosePopupSearchClickEventArgs arg = new APOChoosePopupSearchClickEventArgs();

            arg.Param.MainSearch = _tbSimpleSearch.Text;

            OnSearchClick(arg);
        }

        private void RaiseAdvancedSearchClickEvent()
        {
            APOChoosePopupSearchClickEventArgs arg = new APOChoosePopupSearchClickEventArgs();

            arg.Param.MainSearch = _tbSimpleSearch.Text;
            arg.Param.DossageFormName = _tbDosageForm.Text.Trim();
            arg.Param.Unit = _ddlUnit.SelectedItem !=null ? _ddlUnit.SelectedItem.Text : String.Empty;
            arg.Param.ProducerName = _tbProducer.Text.Trim();
            arg.Param.IsInDefaultStock = _cbIsProductPartOfDefaultStock.Checked;

            OnSearchClick(arg);
        }

        protected void OnSearchClick(APOChoosePopupSearchClickEventArgs e)
        {
            try
            {
                if (SearchClick != null)
                {
                    SearchClick(this, e);
                }
            }
            catch (Exception ex)
            {
                ServerLog.Instance.Error(ex);
            }
        }

        #endregion

        #region Event Handlers

        private void _lbtnSimpleSearch_Click(object source, EventArgs e)
        {
            RaiseSimpleSearchClickEvent();
        }

        private void lbtnAdvancedSearch_onClick(object source, EventArgs e)
        {
            RaiseAdvancedSearchClickEvent();
        }

        #endregion

        public class APOChoosePopupSearchClickEventArgs : EventArgs
        {
            public ChoosePopupSearchParam Param { get; set; }

            public APOChoosePopupSearchClickEventArgs()
            {
                this.Param = new ChoosePopupSearchParam();
            }
        }

        [Serializable]
        public class ChoosePopupSearchUnit 
        {
            public Guid UnitID { get; set; }
            public String UnitName { get; set; }
        }
    }

    public class ChoosePopupSearchParam
    {
        public string MainSearch { get; set; }
        public string ProducerName { get; set; }
        public string DossageFormName { get; set; }
        public string Unit { get; set; }
        public bool IsInDefaultStock { get; set; }
    }
}
