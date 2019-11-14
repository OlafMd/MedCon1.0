using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;
using DLWebFormsTemplates.Controls.Tree.Support;

namespace DLWebFormsTemplates.Controls
{
    public class DLTree : CompositeControl
    {
        #region Events
        public virtual event EventHandler<SelectionChangeEventArgs> SelectionChange;
        protected virtual event EventHandler<SelectionChangeEventArgs> EventHandler;
        #endregion

        #region Public Properties
        public bool HasRootElement { get; set; }
        public String RootElementName { get; set; }
        public List<TreeItemModel> FlatDataModel { get; set; }
        public virtual Guid SelectedID
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

                    DispatchSelectionChangeEvent(value);
                }
            }
        }

        private String _emptyStuctureLabel ;
        public String EmptyStuctureLabel
        {
            set { _emptyStuctureLabel = value; }

            get
            {
                return _emptyStuctureLabel;
            }
        }
        #endregion

        #region Private Properties
        protected HiddenField _hiddenSelectedItemIDs;
        protected HiddenField _hiddenOpenedItemsIDs;
        protected Control _treeContent;
        #endregion

        public DLTree() 
        {
            try
            {
                _emptyStuctureLabel = HttpContext.GetGlobalResourceObject("Global", "NoRecordsFound").ToString();
            }
            catch
            {
                throw new Exception("NoRecordsFound resource object in Global.resx is not defined");
            }
            
        }

        #region Override Methods

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitHiddenFieldsControl();
        }

        protected override void OnDataBinding(EventArgs e)
        {
            base.OnDataBinding(e);
            BindTreeData();
        }

        protected override void CreateChildControls()
        {
            this.Controls.Clear();
            _treeContent = new Control();

            if (_hiddenOpenedItemsIDs == null)
            {
                _hiddenOpenedItemsIDs = new HiddenField();
                _hiddenOpenedItemsIDs.ID = "hidden_OpenedItemsIDs";
            }

            if (_hiddenSelectedItemIDs == null)
            {
                _hiddenSelectedItemIDs = new HiddenField();
                _hiddenSelectedItemIDs.ID = "hidden_SelectedItemID";
            }
        }

        public override void RenderBeginTag(HtmlTextWriter writer)
        {
            writer.Write("");
        }

        public override void RenderEndTag(HtmlTextWriter writer)
        {
            writer.Write("");
        }

        #endregion

        #region Support Methods

        protected virtual void BindTreeData()
        {
            this.EnsureChildControls();

            _treeContent.Controls.Clear();

            #region Create Root element if it's needed

            if (HasRootElement)
            {
                TreeItemModel rootItem = new TreeItemModel();
                rootItem.ID = Guid.Empty;
                rootItem.Name = RootElementName;

                if (FlatDataModel.Where(i => i.ID == Guid.Empty).Count() == 0)
                    FlatDataModel.Add(rootItem);
            }

            #endregion

            var hierarchyDataModel = CreateHierarchyFromFlat(FlatDataModel, HasRootElement);

            #region Create TreeItems

            if (EventHandler == null)
                EventHandler = new EventHandler<SelectionChangeEventArgs>(this.SelectionChangeHandler);

            foreach (var item in hierarchyDataModel)
            {
                DLTreeItem temp = new DLTreeItem(this.ClientID, item);
                temp.SelectionChange += EventHandler;

                _treeContent.Controls.Add(temp);
            }

            #endregion

            this.Controls.Add(new LiteralControl("<ul id='tree'>"));
            this.Controls.Add(_treeContent);
            this.Controls.Add(new LiteralControl("</ul>"));

            if (FlatDataModel == null || !FlatDataModel.Any())
                this.Controls.Add(new LiteralControl("<span>" + _emptyStuctureLabel + "</span>"));
        }

        protected virtual void InitHiddenFieldsControl()
        {
            this.EnsureChildControls();

            this.Controls.Add(new LiteralControl("<div class='hidden_OpenedItemsIDs_Wrap'>"));
            this.Controls.Add(_hiddenOpenedItemsIDs);
            this.Controls.Add(new LiteralControl("</div>"));

            this.Controls.Add(new LiteralControl("<div class='hidden_SelectedItemID_Wrap'>"));
            this.Controls.Add(_hiddenSelectedItemIDs);
            this.Controls.Add(new LiteralControl("</div>"));
        }

        protected virtual void DispatchSelectionChangeEvent(Guid selectedID)
        {
            if (SelectionChange != null)
                SelectionChange(this, new SelectionChangeEventArgs() { SelectedID = selectedID });
        }

        protected List<TreeItemModel> CreateHierarchyFromFlat(List<TreeItemModel> flatDataModel, Boolean hasRoot)
        {
            //create hierarchy model
            foreach (TreeItemModel item in flatDataModel)
            {
                var children = flatDataModel
                    .Where(i => item.ID == i.ParentID && i.ID != Guid.Empty)
                    .ToList();
                item.Children.Clear();
                foreach(var child in children)
                {
                    item.Children.Add(child);
                }
            }

            if (!hasRoot)
                //return items that doesn't have parent (the first level items)
                return flatDataModel.Where(i => i.ParentID == Guid.Empty).ToList();
            else
                //return items that doesn't have parent (the first level items)
                return flatDataModel.Where(i => i.ID == Guid.Empty).ToList();
        }

        protected virtual void SetSelectedItemInHiddenField(Guid selectedID)
        {
            this.EnsureChildControls();

            _hiddenSelectedItemIDs.Value = this.ClientID + "_" + selectedID.ToString();
        }

        #endregion

        #region Event Handlers

        protected virtual void SelectionChangeHandler(object sender, SelectionChangeEventArgs e)
        {
            SelectedID = e.SelectedID;
            DispatchSelectionChangeEvent(e.SelectedID);
        }

        #endregion
    }
}
