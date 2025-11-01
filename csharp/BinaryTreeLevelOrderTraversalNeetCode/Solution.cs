using System.Collections.Generic;

namespace BinaryTreeLevelOrderTraversalNeetCode;

public class TreeNode(int val, TreeNode? left = null, TreeNode? right = null)
{
    public int Val { get; } = val;
    public TreeNode? Left { get; set; } = left;
    public TreeNode? Right { get; set; } = right;
}

public class Solution
{
    /// <summary>
    /// Returns the level order traversal of the binary tree.
    /// TODO: Perform breadth-first traversal collecting values by depth.
    /// </summary>
    public IList<IList<int>> LevelOrder(TreeNode? root)
    {
        var result = new List<IList<int>>();

        LO(root, 0);

        return result;

        void LO(TreeNode? node, int level)
        {
            if (node is null)
                return;

            if (result.Count <= level)
                result.Add([node.Val]);
            else
                result[level].Add(node.Val);

            LO(node.Left, level + 1);
            LO(node.Right, level + 1);
        }
    }
}
