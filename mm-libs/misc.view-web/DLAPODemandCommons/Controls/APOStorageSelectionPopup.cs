using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using DLAPODemandCommons.Controls.Classes;
using DLAPODemandCommons.Utils;
using DLWebFormsTemplates.Controls.Tree.Support;

namespace DLAPODemandCommons.Controls
{
    [ParseChildren(true, "StorageItemCategories"),
    DefaultProperty("StorageItemCategories"), 
    ToolboxData("<{0}:APOStorageSelectionPopup ID='dlAPOStorageSelectionPopup' runat=server></{0}:APOStorageSelectionPopup>")]
    public class APOStorageSelectionPopup : CompositeControl
    {
        #region EVENTS
        public event EventHandler<StorageTreePopupEventArgs> ConfirmButtonClicked;
        #endregion

        #region PUBLIC PROPERTIES
        public string HeaderText { get; set; }
        public bool IsTriggerButtonVisible { get; set; }
        public string TriggerButtonCss { get; set; }
        [Bindable(true)]
        public string GridViewRowIdentificator 
        {
            get { return ViewState["VS_KEY_GridViewRowIdentificator"] == null ? string.Empty : ViewState["VS_KEY_GridViewRowIdentificator"].ToString(); }
            set { ViewState["VS_KEY_GridViewRowIdentificator"] = value; } 
        }
        public string CurrentlySelectedItemId
        {
            get { return ViewState["VS_KEY_CurrentlySelectedItemId"] == null ? string.Empty : ViewState["VS_KEY_CurrentlySelectedItemId"].ToString(); }
            set { ViewState["VS_KEY_CurrentlySelectedItemId"] = value; } 
        }
        public string BubblePopupWarningMessage { get; set; }
        public string CancelButtonText { get; set; }
        public string ConfirmButtonText { get; set; }
        [PersistenceMode(PersistenceMode.InnerProperty),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public StorageItemCategoryCollection StorageItemCategories
        {
            get
            {
                if (storageItemCategories == null)
                {
                    storageItemCategories = new StorageItemCategoryCollection();
                }
                return storageItemCategories;
            }
        }

        #region InventoryProcessesOverview Specific
        [Bindable(true)]
        public Guid WarehouseId
        {
            get { return ViewState["VS_KEY_ControlWarehouseID"] == null ? Guid.Empty : Guid.Parse(ViewState["VS_KEY_ControlWarehouseID"].ToString()); }
            set { ViewState["VS_KEY_ControlWarehouseID"] = value.ToString(); }
        }
        [Bindable(true)]
        public Guid InvertoryJobId
        {
            get { return ViewState["VS_KEY_ControlInvertoryJobID"] == null ? Guid.Empty : Guid.Parse(ViewState["VS_KEY_ControlInvertoryJobID"].ToString()); }
            set { ViewState["VS_KEY_ControlInvertoryJobID"] = value.ToString(); }
        }
        #endregion
        #endregion

        #region PRIVATE PROPERTIES
        private AbstractStorageProxy storageProxy;
        private StorageItemCategoryCollection storageItemCategories;
        #endregion

        #region CONTROLS
        private Panel panelPopupWrapper;
        private Panel panelPopup;
        private Panel panelTree;
        private Panel panelButtons;
        private LinkButton lbtnShowPopup;
        private LinkButton lbtnConfirm;
        private LinkButton lbtnCancel;
        private APOStorageTree storageTree = new APOStorageTree();
        #endregion

        #region CONSTRUCTORS
        public APOStorageSelectionPopup(AbstractStorageProxy storageProxy)
        {
            this.storageProxy = storageProxy;
        }
        #endregion

        #region PUBLIC METHODS
        public void Show()
        {
            storageProxy.WarehouseId = WarehouseId;
            storageProxy.InvertoryJobId = InvertoryJobId;
            storageTree.StorageItemCategories = storageItemCategories;
            if (storageTree.StorageTreeDataModel == null || storageTree.StorageTreeDataModel.Count <= 0)
            {
                storageTree.StorageTreeDataModel = storageProxy.GetStorageStructureItems();
            }
            if (!string.IsNullOrEmpty(CurrentlySelectedItemId))
            {
                storageTree.SelectedID = Guid.Parse(CurrentlySelectedItemId);
            }
            storageTree.IsAutopostbackEnabled = false;
            storageTree.SelectionChange += new EventHandler<SelectionChangeEventArgs>(this.storageTree_SelectionChange);
            storageTree.RenderStorageTreeControl();
            TogglePopupVisibility();
        }

        public void ReloadStorageTree()
        {
            storageProxy.WarehouseId = WarehouseId;
            storageProxy.InvertoryJobId = InvertoryJobId;
            storageTree.StorageItemCategories = storageItemCategories;
            storageTree.StorageTreeDataModel = storageProxy.GetStorageStructureItems();
            storageTree.IsAutopostbackEnabled = false;
        }
        #endregion

        #region OVERRIDE METHODS
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }

        protected override void CreateChildControls()
        {
            InitPanels();
            InitShowPopupButton();
            InitCommandButtons();
        }
        #endregion

        #region INITIALIZE COMPONENTS
        private void InitPanels()
        {
            panelPopupWrapper = new Panel()
            {
                ID = "popupPanelWrapper",
                CssClass = "popup-wraper choose-storage-popup-fix visibility-fix",
                Visible = false
            };
            panelPopup = new Panel()
            {
                ID = "panelPopup",
                CssClass = "popup popup-smaller "
            };
            panelTree = new Panel()
            {
                ID = "panelTree",
                CssClass = "tree popup-tree-display"
            };
            panelButtons = new Panel()
            {
                ID = "panelButtons",
                CssClass = "buttons"
            };
            panelTree.Controls.Add(storageTree);
            panelPopup.Controls.Add(new LiteralControl("<h1>" + HeaderText + "</h1>"));
            panelPopup.Controls.Add(panelTree);
            panelPopup.Controls.Add(panelButtons);
            panelPopupWrapper.Controls.Add(panelPopup);
            this.Controls.Add(panelPopupWrapper);
        }

        private void InitShowPopupButton()
        {
            lbtnShowPopup = new LinkButton()
            {
                ID = "lbtnShowPopup",
                CssClass = TriggerButtonCss,
                Text = "show popup"
            };

            if (!IsTriggerButtonVisible)
            {
                lbtnShowPopup.Attributes["style"] = "display:none";
            }

            lbtnShowPopup.Click += new EventHandler(lbtnShowPopup_Click);
            this.Controls.Add(lbtnShowPopup);
        }

        private void InitCommandButtons()
        {
            lbtnCancel = new LinkButton()
            {
                ID = "lbtnCancel",
                CssClass = "cancel",
                Text = CancelButtonText
            };
            lbtnCancel.Click += new EventHandler(lbtnCancel_Click);
            panelButtons.Controls.Add(lbtnCancel);
            if (lbtnConfirm != null)
            {
                return;
            }
            lbtnConfirm = new LinkButton()
            {
                ID = "lbtnConfirm",
                CssClass = "button",
                Text = ConfirmButtonText,
                OnClientClick = "saveSelectedStorageIDs(this);"
            };
            lbtnConfirm.Click += new EventHandler(lbtnConfirm_Click);
            panelButtons.Controls.Add(lbtnConfirm);
        }
        #endregion

        #region SUPPORT METHODS
        private void TogglePopupVisibility()
        {
            panelPopupWrapper.Visible = !panelPopupWrapper.Visible;
        }

        private List<Guid> GetSelectedStorageItemsFromHiddenField(HiddenField hiddenField)
        {
            var selectedStorageIds =
                new JavaScriptSerializer().Deserialize<List<String>>(hiddenField.Value);
            var resultList = new List<Guid>();
            if (selectedStorageIds != null)
            {
                foreach (var id in selectedStorageIds)
                {
                    var idParts = id.Split('_');
                    resultList.Add(new Guid(idParts[idParts.Length - 1]));
                }
            }
            return resultList;
        }

        public void OnConfirmButtonClicked(StorageTreePopupEventArgs args)
        {
            if (ConfirmButtonClicked != null)
            {
                ConfirmButtonClicked(this, args);
            }
        }

        private void RaiseConfirmButtonClicked(List<Guid> selectedIDs)
        {
            OnConfirmButtonClicked(new StorageTreePopupEventArgs()
            {
                SelectedIDs = selectedIDs,
                GridViewRowIdentificator = this.GridViewRowIdentificator
            });
        }
        #endregion

        #region EVENT HEANDLER
        protected void lbtnConfirm_Click(object source, EventArgs e)
        {
            var selectedStorageIds = GetSelectedStorageItemsFromHiddenField(storageTree.HiddenFieldSelectedStorageIDs);
            if (selectedStorageIds.Count <= 0)
            {
                BubbleNotificationUtil.BubbleNotify(this, BubblePopupWarningMessage, true);
                storageTree.RenderStorageTreeControl();
            }
            else
            {
                RaiseConfirmButtonClicked(selectedStorageIds);
                TogglePopupVisibility();
            }
        }

        protected void lbtnCancel_Click(object source, EventArgs e)
        {
            TogglePopupVisibility();
        }

        protected void lbtnShowPopup_Click(object sender, EventArgs e)
        {
            Show();
        }

        protected void storageTree_SelectionChange(object sender, SelectionChangeEventArgs e)
        {
            if (e.SelectedID == Guid.Empty)
            {
                storageTree.RenderStorageTreeControl();
            }
            else
            {
                RaiseConfirmButtonClicked(new List<Guid> { e.SelectedID });
                TogglePopupVisibility();
            }
        }
        #endregion
    }

    #region HELPER CLASSES
    public class StorageTreePopupEventArgs : EventArgs
    {
        public List<Guid> SelectedIDs { get; set; }
        public string GridViewRowIdentificator { get; set; }
    }
    #endregion
}
