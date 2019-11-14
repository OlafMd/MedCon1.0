using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using DLAPODemandCommons.Controls.Classes;
using DLWebFormsTemplates.Controls;
using DLWebFormsTemplates.Controls.Tree.Support;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Web.UI.HtmlControls;
using System.Web.Script.Serialization;

namespace DLAPODemandCommons.Controls
{
    [ParseChildren(true, "StorageItemCategories"),
    DefaultProperty("StorageItemCategories"),
    ToolboxData("<{0}:APOStorageSelectionTree ID='dlAPOStorageSelectionTree' runat='server'></{0}:APOStorageSelectionTree>")]
    public class APOStorageTree : DLTree
    {
        #region EVENTS
        public override event EventHandler<SelectionChangeEventArgs> SelectionChange;
        protected override event EventHandler<SelectionChangeEventArgs> EventHandler;
        #endregion

        #region PUBLIC PROPERTIES
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
            set { storageItemCategories = value; }
        }
        public List<StorageTreeItemModel> StorageTreeDataModel
        {
            get
            {
                return ViewState["VS_KEY_StorageTreeDataModel"] == null 
                    ? new List<StorageTreeItemModel>()
                    : (List<StorageTreeItemModel>)ViewState["VS_KEY_StorageTreeDataModel"];
            }
            set
            {
                var model = GenerateStorageStructureFlatModel(value);
                ViewState["VS_KEY_StorageTreeDataModel"] = model;
            }
        }
        public bool IsAutopostbackEnabled 
        {
            set { isAutoPostbackEnabled = value; }
            get { return isAutoPostbackEnabled; }
        }
        public HiddenField HiddenFieldSelectedStorageIDs 
        {
            get
            {
                return _hiddenSelectedItemIDs; 
            }
            set
            {
                _hiddenSelectedItemIDs = value;
                _hiddenOpenedItemsIDs = _hiddenSelectedItemIDs;
            }
        }
        public override Guid SelectedID
        {
            get
            {
                object value = ViewState[this.ID + "SelectedID"];
                return (value == null) ? Guid.Empty : (Guid)value;
            }
            set
            {
                if (SelectedID != value)
                {
                    ViewState[this.ID + "SelectedID"] = value;
                    SetSelectedItemInHiddenField(value);
                }
            }
        }
        #endregion

        #region PRIVATE PROPERTIES
        private string rootElementId = "c1e296c2-96e8-4c2e-8437-b0ab0f51dbb2";
        private StorageItemCategoryCollection storageItemCategories;
        private bool isAutoPostbackEnabled;
        #endregion

        #region PUBLIC METHODS
        public void RenderStorageTreeControl()
        {
            this.DataBind();
        }

        public void RenderStorageTreeControl(AbstractStorageProxy proxy)
        {
            if (this.StorageTreeDataModel == null || this.StorageTreeDataModel.Count <= 0)
            {
                this.StorageTreeDataModel = proxy.GetStorageStructureItems();
            }
            RenderStorageTreeControl();
        }

        public List<StorageTreeItemModel> GetSelectedStorageItems()
        {
            var selectedItemsIDs = GetSelectedStorageItemsFromHiddenField(HiddenFieldSelectedStorageIDs);
            return StorageTreeDataModel.Where(x => selectedItemsIDs.Contains(x.ID)).ToList();
        }
        #endregion

        #region OVERRIDE METHODS
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            EnsureWebResourceRegistration("DLAPODemandCommons.Controls.Scripts.apo-demand-commons.js", WebResourceType.ScriptJavascript);
        }

        protected override void CreateChildControls()
        {
            this.Controls.Clear();
            _treeContent = new Control();
            if (_hiddenSelectedItemIDs == null)
            {
                _hiddenSelectedItemIDs = new HiddenField();
                _hiddenSelectedItemIDs.ID = "hiddenSelectedStorageItemIDs";
            }
            if (_hiddenOpenedItemsIDs == null)
            {
                _hiddenOpenedItemsIDs = new HiddenField();
                _hiddenOpenedItemsIDs.ID = "hidden_OpenedItemsIDs";
            }
        }

        protected override void BindTreeData()
        {
            this.EnsureChildControls();
            AddTreeItemControls();
            this.Controls.Add(new LiteralControl("<ul id='storage-tree-control'>"));
            this.Controls.Add(_treeContent);
            this.Controls.Add(new LiteralControl("</ul>"));
        }

        private void AddTreeItemControls()
        {
            _treeContent.Controls.Clear();
            if (EventHandler == null)
            {
                EventHandler = new EventHandler<SelectionChangeEventArgs>(this.SelectionChangeHandler);
            }
            var hierarchyDataModel = CreateHierarchyFromFlat(StorageTreeDataModel);
            foreach (var item in hierarchyDataModel)
            {
                var treeItem = new APOStorageTreeItem(this.ClientID, item);
                treeItem.IsAutoPostbackEnabled = isAutoPostbackEnabled;
                treeItem.SelectionChange += EventHandler;
                _treeContent.Controls.Add(treeItem);
            }
        }

        protected override void InitHiddenFieldsControl() 
        {
            this.EnsureChildControls();
            this.Controls.Add(new LiteralControl("<div class='hidden_OpenedItemsIDs_Wrap'>"));
            this.Controls.Add(_hiddenOpenedItemsIDs);
            this.Controls.Add(new LiteralControl("</div>"));
            this.Controls.Add(new LiteralControl("<div class='wrapperSelectedItemIDsHiddenFields'>"));
            this.Controls.Add(_hiddenSelectedItemIDs);
            this.Controls.Add(new LiteralControl("</div>"));
        }

        protected override void SelectionChangeHandler(object sender, SelectionChangeEventArgs e)
        {
            if (e.SelectedID != Guid.Empty)
            {
                HiddenFieldSelectedStorageIDs.Value = _hiddenSelectedItemIDs.Value = string.Format("[\"{0}\"]", this.ClientID + "_" + e.SelectedID.ToString());
            }
            DispatchSelectionChangeEvent(e.SelectedID);
        }

        protected override void DispatchSelectionChangeEvent(Guid selectedID)
        {
            if (SelectionChange != null)
            {
                SelectionChange(this, new SelectionChangeEventArgs() { SelectedID = selectedID });
            }
        }

        protected override void SetSelectedItemInHiddenField(Guid selectedID)
        {
            _hiddenSelectedItemIDs.Value = string.Format("[\"{0}\"]", this.ClientID + "_" + selectedID.ToString());
        }
        #endregion

        #region SUPPORT METHODS
        private List<StorageTreeItemModel> GenerateStorageStructureFlatModel(List<StorageTreeItemModel> storageModel)
        {
            var storageStructureModel = new List<StorageTreeItemModel>();
            foreach (StorageTypeEnum storageType in (StorageTypeEnum[])Enum.GetValues(typeof(StorageTypeEnum)))
            {
                if (storageType != StorageTypeEnum.ROOT)
                {
                    storageStructureModel.AddRange(ExtractStorageItemsByType(storageModel, storageType));
                }
            }
            if (!IsStorageTypeHidden(StorageTypeEnum.ROOT, null))
            {
                SetRootElement(storageStructureModel);
            }
            return RemoveHiddenStorageModelElements(storageStructureModel);
        }

        private List<StorageTreeItemModel> ExtractStorageItemsByType(List<StorageTreeItemModel> storageItems, StorageTypeEnum storageType)
        {
            var temp = storageItems
                .Select(si => new StorageTreeItemModel()
                {
                    ID = si.GetStorageItemIdByStorageType(storageType),
                    ParentID = si.GetStorageItemIdByStorageType(storageType - 1),
                    Name = si.GetStorageItemNameByType(storageType),
                    StorageItemType = storageType,
                    IsHidden = IsStorageTypeHidden(storageType, si), 
                    IsCheckBoxEnabled = IsStorageTypeMultipleSelectionEnabled(storageType),
                    IsEnabled = IsStorageTypeEnabled(storageType, si),
                    IsSelectable = IsStorageTypeSelectable(storageType),
                    IsAutoPostbackEnabled = isAutoPostbackEnabled,
                    StorageItemDatabaseModel = si.StorageItemDatabaseModel
                })
                .Where(si => si.ID != Guid.Empty)
                .Distinct(new StorageItemComparer())
                .ToList<StorageTreeItemModel>();
            return temp;
        }

        private void SetRootElement(List<StorageTreeItemModel> storageModel)
        {
            var root = new StorageTreeItemModel()
            {
                ID = Guid.Parse(rootElementId),
                ParentID = Guid.Empty,
                Name = GetStorageCategoryByStorageType(StorageTypeEnum.ROOT).RootElementName,
                StorageItemType = StorageTypeEnum.ROOT,
                IsHidden = IsStorageTypeHidden(StorageTypeEnum.ROOT, null),
                IsCheckBoxEnabled = IsStorageTypeMultipleSelectionEnabled(StorageTypeEnum.ROOT),
                IsEnabled = IsStorageTypeEnabled(StorageTypeEnum.ROOT, null),
                IsSelectable = IsStorageTypeSelectable(StorageTypeEnum.ROOT),
                IsAutoPostbackEnabled = isAutoPostbackEnabled,
                StorageItemDatabaseModel = null
            };
            var itemsWithoutParents =
                storageModel.Where(sm => sm.ParentID == Guid.Empty).ToList();
            foreach (var item in itemsWithoutParents)
            {
                item.ParentID = root.ID;
            }
            storageModel.Add(root);
        }

        private List<StorageTreeItemModel> RemoveHiddenStorageModelElements(List<StorageTreeItemModel> storageModel)
        {
            foreach (var storgaeModelElement in storageModel)
            {
                if (storgaeModelElement.IsHidden)
                {
                    var elementChildren =
                        storageModel.Where(sm => sm.ParentID == storgaeModelElement.ID).ToList();
                    foreach (var child in elementChildren)
                    {
                        child.ParentID = storgaeModelElement.ParentID;
                    }
                }
            }
            return storageModel.Where(sm => sm.IsHidden == false).ToList();
        }

        protected List<StorageTreeItemModel> CreateHierarchyFromFlat(List<StorageTreeItemModel> flatDataModel)
        {
            var resultModel = new List<StorageTreeItemModel>();
            if (flatDataModel == null)
            {
                return new List<StorageTreeItemModel>();
            }
            foreach (StorageTreeItemModel item in flatDataModel)
            {
                var itemChildren = flatDataModel
                    .Where(fdm => fdm.ParentID == item.ID && fdm.ID != Guid.Empty)
                    .ToList();
                item.Children.Clear();
                foreach (var child in itemChildren)
                {
                    item.Children.Add(child);
                }
                resultModel.Add(item);
            }
            return resultModel
                    .Where(i => i.ParentID == Guid.Empty)
                    .ToList<StorageTreeItemModel>();
        }

        private bool IsStorageTypeHidden(StorageTypeEnum storageType, StorageTreeItemModel storageItem)
        {
            var storageTypeConfiguration = storageItemCategories.GetCategoryByType(storageType);
            if (storageTypeConfiguration != null && storageTypeConfiguration.IsHidden != null) 
            {
                return (bool)storageTypeConfiguration.IsHidden;
            }
            else if (storageItem != null)
            {
                return storageItem.GetStorageItemIsHiddenByType(storageType);
            }
            else
            {
                if (storageType == StorageTypeEnum.ROOT || storageType == StorageTypeEnum.WAREHOUSE_GROUP)
                {
                    return true;
                }
                return false;
            }
        }

        private bool IsStorageTypeMultipleSelectionEnabled(StorageTypeEnum storageType)
        {
            if (storageItemCategories != null && storageItemCategories.Count > 0)
            {
                foreach (StorageItemCategory storageCategory in storageItemCategories)
                {
                    if (storageCategory.CategoryType == storageType)
                    {
                        return storageCategory.IsMultipleSelectionEnabled;
                    }
                }
            }
            return false;
        }

        private bool IsStorageTypeEnabled(StorageTypeEnum storageType, StorageTreeItemModel storageItem)
        {
            var storageTypeConfiguration = storageItemCategories.GetCategoryByType(storageType);
            if (storageTypeConfiguration != null && storageTypeConfiguration.IsEnabled != null)
            {
                return (bool)storageTypeConfiguration.IsEnabled;
            }
            else if (storageItem != null)
            {
                return storageItem.IsEnabled;
            }
            return true;
        }

        private bool IsStorageTypeSelectable(StorageTypeEnum storageType)
        {
            if (storageItemCategories != null && storageItemCategories.Count > 0)
            {
                foreach (StorageItemCategory storageCategory in storageItemCategories)
                {
                    if (storageCategory.CategoryType == storageType)
                    {
                        return storageCategory.IsSelectable;
                    }
                }
            }
            return false;
        }

        private StorageItemCategory GetStorageCategoryByStorageType(StorageTypeEnum storageType)
        {
            if (storageItemCategories != null && storageItemCategories.Count > 0)
            {
                foreach (StorageItemCategory storageCategory in storageItemCategories)
                {
                    if (storageCategory.CategoryType == storageType)
                    {
                        return storageCategory;
                    }
                }
            }
            return null;
        }

        private void EnsureWebResourceRegistration(string path, WebResourceType wrType)
        {
            var wrUrl = this.Page.ClientScript.GetWebResourceUrl(this.GetType(), path);
            var alreadyRegistered = this.Page.Header.Controls.OfType<HtmlGenericControl>().Any(x => x.InnerText == "apo-demand-commons.js");
            if (!alreadyRegistered && wrType == WebResourceType.ScriptJavascript)
            {
                HtmlGenericControl include = new HtmlGenericControl("script");
                include.Attributes.Add("src", wrUrl);
                include.InnerText = "apo-demand-commons.js";                    
                include.Attributes.Add("type", "text/javascript");
                this.Page.Header.Controls.Add(include);
            }
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
        #endregion
    }

    #region HELPER CLASSES
    public class StorageItemComparer : IEqualityComparer<StorageTreeItemModel>
    {
        public bool Equals(StorageTreeItemModel x, StorageTreeItemModel y)
        {
            return x.ID == y.ID;
        }

        public int GetHashCode(StorageTreeItemModel ws)
        {
            if (Object.ReferenceEquals(ws, null)) return 0;
            int hashID = ws.ID == Guid.Empty ? 0 : ws.ID.GetHashCode();
            return hashID;
        }
    }
    #endregion
}
