using System;
using System.Collections.Generic;

namespace DLWebFormsTemplates.Controls.Tree.Support
{
    [Serializable]
    public class TreeItemModel : AbstractTreeItemModel
    {
        //used for tree item with checkbox
        public bool Checked { get; set; }

        public TreeItemModel()
        {
            IsEnabled = true;
            this.Children = new List<AbstractTreeItemModel>();
        }

        public TreeItemModel(Guid id, String name, Guid parentID, bool enabled)
        {
            this.ID = id;
            this.Name = name;
            this.ParentID = parentID;
            this.IsEnabled = enabled;
            this.Children = new List<AbstractTreeItemModel>();
        }
    }
}
