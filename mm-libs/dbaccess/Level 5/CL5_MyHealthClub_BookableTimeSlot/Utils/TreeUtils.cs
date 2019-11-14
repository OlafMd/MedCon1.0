using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CL5_MyHealtClub_Slot.Utils
{
    class TreeUtils
    {
        public static List<TreeNode> GetLeafs(TreeNode node)
        {
            var retVal = new List<TreeNode>();

            if (node.GetChilds().Length == 0)
                retVal.Add(node);
            else
                foreach (var child in node.GetChilds())
                    retVal.AddRange(GetLeafs(child));

            return retVal;
        }

        public static List<TreeNode> GetAncestors(TreeNode node)
        {
            var retVal = new List<TreeNode>();

            if (node.Parent != null)
            {
                retVal.Add(node);
                retVal.AddRange(GetAncestors(node.Parent));
            }

            return retVal;
        }

        public static int GetNodeDepth(TreeNode node)
        {
            int depth = 0;
            if (node.Parent != null)
                depth += 1 + GetNodeDepth(node.Parent);

            return depth;
        }

        public static bool IsAncestorsContainsID(TreeNode node, Guid staffID)
        {
            var ancestors = GetAncestors(node);
            return ancestors.FirstOrDefault(a => a.StaffID == staffID) != null;
        }

        public static int GetMaxBranchDepth(TreeNode root)
        {
            var leafs = GetLeafs(root);
            int maxDepth = 0;
            foreach (var leaf in leafs)
            {
                var tempDepth = GetNodeDepth(leaf);
                if (maxDepth < tempDepth) maxDepth = tempDepth;
            }
            return maxDepth;
        }

        public static List<List<TreeNode>> GetBranchesCurrentSize(TreeNode root, int size)
        {
            var retVal = new List<List<TreeNode>>();
            var leafs = GetLeafs(root);
            foreach (var leaf in leafs)
            {
                if (GetNodeDepth(leaf) == size)
                    retVal.Add(GetAncestors(leaf).ToList());            
            }
            return retVal;
        }
    }
}
