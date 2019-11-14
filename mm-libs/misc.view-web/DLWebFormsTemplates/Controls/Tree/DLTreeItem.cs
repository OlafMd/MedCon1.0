using System;
using System.Linq;
using System.Web.UI.WebControls;
using System.Web.UI;
using DLWebFormsTemplates.Controls.Tree.Support;

namespace DLWebFormsTemplates.Controls
{
    public class DLTreeItem : CompositeControl
    {
        #region Events
        public virtual event EventHandler<SelectionChangeEventArgs> SelectionChange;
        #endregion

        #region Controls
        protected LinkButton _lbtnItemName;
        protected Control _children;
        #endregion

        #region Private Properties
        protected string _prefix { get; set; }
        protected AbstractTreeItemModel _item { get; set; }
        #endregion

        #region Constructors
        public DLTreeItem() { }

        public DLTreeItem(String prefix, AbstractTreeItemModel item)
        {
            this._prefix = prefix;
            this._item = item;
        }
        #endregion

        #region Override Methods
        protected override void OnInit(EventArgs e)
        {
            InitControls();
            base.OnInit(e);
        }

        protected override void CreateChildControls()
        {
            this.Controls.Clear();

            this.Controls.Add(new LiteralControl("<li>"));
            this.Controls.Add(new LiteralControl("<i></i>"));

            this.Controls.Add(_lbtnItemName);

            AddChildrenControl();

            this.Controls.Add(new LiteralControl("</li>"));

            base.CreateChildControls();
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
        protected virtual void InitControls()
        {
            InitItemNameControl();
            InitChildrenControl();
        }

        protected virtual void InitItemNameControl() 
        {
            this.ID = "ti_" + _item.ID.ToString();
            _lbtnItemName = new LinkButton();
            _lbtnItemName.ID = _prefix + "_" + _item.ID.ToString();
            _lbtnItemName.Text = _item.Name + String.Format(" ({0})", _item.Children.Count());
            _lbtnItemName.ClientIDMode = System.Web.UI.ClientIDMode.Static;
            _lbtnItemName.CommandArgument = _item.ID.ToString();
            _lbtnItemName.Command += new CommandEventHandler(lbtnItemName_Command);

            if (((TreeItemModel)_item).IsEnabled == false)
            {
                _lbtnItemName.Enabled = false;
                _lbtnItemName.CssClass += "tree-item-disabled";
            }
        }

        protected virtual void InitChildrenControl()
        {
            this._children = new Control();

            _children.Controls.Clear();
            foreach (var child in _item.Children)
            {
                var temp = new DLTreeItem(_prefix, child);
                temp.SelectionChange += this.SelectionChange;
                _children.Controls.Add(temp);
            }
        }

        protected virtual void AddChildrenControl()
        {
            if (_item.Children.Count() != 0)
            {
                this.Controls.Add(new LiteralControl("<ul id='children'>"));
                this.Controls.Add(_children);
                this.Controls.Add(new LiteralControl("</ul>"));
            }
        }

        protected virtual void lbtnItemName_Command(object sender, CommandEventArgs e)
        {
            var selectedID = Guid.Parse(e.CommandArgument.ToString());

            if (SelectionChange != null)
                SelectionChange(this, new SelectionChangeEventArgs() { SelectedID = selectedID });
        }
        #endregion
    }
}
