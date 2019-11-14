using System;
using System.Collections.Generic;

namespace DLWebFormsTemplates.Controls.Tree.Support
{
    [Serializable]
    public abstract class AbstractTreeItemModel
    {
        public Guid ID { get; set; }
        public String Name { get; set; }
        public Guid ParentID { get; set; }
        public bool IsEnabled { get; set; }
        public List<AbstractTreeItemModel> Children { get; set; }
    }
}
