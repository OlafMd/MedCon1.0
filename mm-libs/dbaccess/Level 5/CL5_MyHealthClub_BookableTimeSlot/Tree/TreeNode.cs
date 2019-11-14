using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using MHCWidget_Web.Models.Backoffice;

namespace CL5_MyHealtClub_Slot.Utils
{
    class TreeNode : IEnumerable<TreeNode>
    {
        private readonly Dictionary<Guid, TreeNode> _childs = new Dictionary<Guid, TreeNode>();

        public readonly Guid StaffID;
        public readonly Guid StaffReqID;
        public TreeNode Parent { get; private set; }

        public TreeNode(Guid staffID, Guid staffReqID)
        {
            this.StaffID = staffID;
            this.StaffReqID = staffReqID;
        }

        public TreeNode GetChild(Guid staffID)
        {
            return this._childs[StaffID];
        }

        public TreeNode[] GetChilds()
        {
            return this._childs.Values.ToArray();
        }

        public void Add(TreeNode item)
        {
            if (item.Parent != null)
            {
                item.Parent._childs.Remove(item.StaffID);
            }

            item.Parent = this;
            this._childs.Add(item.StaffID, item);
        }

        public IEnumerator<TreeNode> GetEnumerator()
        {
            return this._childs.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public int Count
        {
            get { return this._childs.Count; }
        }
    }


}
