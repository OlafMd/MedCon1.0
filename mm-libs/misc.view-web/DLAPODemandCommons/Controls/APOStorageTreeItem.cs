using System;
using System.Linq;
using DLWebFormsTemplates.Controls;
using DLAPODemandCommons.Controls.Classes;
using System.Web.UI;
using System.Web.UI.WebControls;
using DLWebFormsTemplates.Controls.Tree.Support;

namespace DLAPODemandCommons.Controls
{
    [ToolboxData("<{0}:APOStorageSelectionTreeItem ID='dlAPOStorageSelectionTreeItem' runat='server'></{0}:APOStorageSelectionTreeItem>")]
    class APOStorageTreeItem : DLTreeItem
    {
        #region EVENTS
        public override event EventHandler<SelectionChangeEventArgs> SelectionChange;
        #endregion

        #region PUBLIC PROPERTIES
        public bool IsAutoPostbackEnabled 
        {
            get { return _isAutoPostbackEnabled; }
            set { _isAutoPostbackEnabled = value; }
        }
        #endregion

        #region PRIVATE PROPERTIES
        private bool _isAutoPostbackEnabled;
        #endregion

        #region CONSTRUCTORS
        public APOStorageTreeItem() { }

        public APOStorageTreeItem(string prefix, StorageTreeItemModel item)
        {
            this._prefix = prefix;
            this._item = item;
        }
        #endregion

        #region OVERRIDE METHODS
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }

        protected override void CreateChildControls()
        {
            this.Controls.Clear();
            this.ID = "ti_" + _item.ID.ToString();
            this.Controls.Add(new LiteralControl("<li>"));
            this.Controls.Add(new LiteralControl("<i></i>")); // onclick=\'expandSubTree(this); return false;\'></i>"));
            if (((StorageTreeItemModel)_item).IsCheckBoxEnabled)
            {
                this.Controls.Add(InitCheckBox());
            }
            this.Controls.Add(_lbtnItemName);
            AddChildrenControl();
            this.Controls.Add(new LiteralControl("</li>"));
        }

        protected override void InitItemNameControl()
        {
            _lbtnItemName = new LinkButton();
            _lbtnItemName.ID = _prefix + "_" + _item.ID.ToString();
            _lbtnItemName.Text = _item.Name + String.Format(" ({0})", _item.Children.Count());
            _lbtnItemName.ClientIDMode = System.Web.UI.ClientIDMode.Static;
            if (_isAutoPostbackEnabled)
            {
                _lbtnItemName.CommandArgument = _item.ID.ToString();
                _lbtnItemName.Command += new CommandEventHandler(lbtnItemName_Command);
                _lbtnItemName.OnClientClick = "expandSubTree(this);" + 
                    (((StorageTreeItemModel)_item).IsSelectable
                    ? string.Empty
                    : " return false;");
            }
            else
            {
                _lbtnItemName.OnClientClick = ((StorageTreeItemModel)_item).IsSelectable
                    ? "saveSelectedStorageID(this, '" + _lbtnItemName.ID + "'); return false;"
                    : "expandSubTree(this); return false;";
            }
            if (!((StorageTreeItemModel)_item).IsEnabled)
            {
                _lbtnItemName.CssClass += " tree-item-disabled";
                _lbtnItemName.OnClientClick = "return false;";
            }
        }

        protected override void InitChildrenControl()
        {
            _children = new Control();
            _children.Controls.Clear();
            foreach (var child in _item.Children)
            {
                var treeItem = new APOStorageTreeItem(_prefix, (StorageTreeItemModel)child);
                treeItem.IsAutoPostbackEnabled = _isAutoPostbackEnabled;
                treeItem.SelectionChange += this.SelectionChange;
                _children.Controls.Add(treeItem);
            }
        }

        protected override void lbtnItemName_Command(object sender, CommandEventArgs e)
        {
            var selectedID = Guid.Parse(e.CommandArgument.ToString());
            if (SelectionChange != null)
            {
                SelectionChange(this, new SelectionChangeEventArgs() { SelectedID = selectedID });
            }
        }
        #endregion

        #region SUPPORT METHODS
        private LiteralControl InitCheckBox()
        {
            var cssClass = ((StorageTreeItemModel)_item).IsSelectable
                ? "storage-item-checkbox-selectable" 
                : "storage-item-checkbox";
            cssClass += ((StorageTreeItemModel)_item).IsEnabled
                ? " tree-item-disabled" : "";
            return new LiteralControl(
                "<input type='checkbox' onchange='selectChildStorages(this)'" +
                "class='" + cssClass + "'  />");
        }
        #endregion
    }
}
