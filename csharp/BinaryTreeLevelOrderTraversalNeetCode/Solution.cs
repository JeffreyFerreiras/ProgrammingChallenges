using System.Collections.Generic;

namespace BinaryTreeLevelOrderTraversalNeetCode;

public class TreeNode
{
    public int Val { get; }
    public TreeNode? Left { get; set; }
    public TreeNode? Right { get; set; }

    public TreeNode(int val, TreeNode? left = null, TreeNode? right = null)
    {
        Val = val;
        Left = left;
        Right = right;
    }
}

public class Solution
{
    /// <summary>
    /// Returns the level order traversal of the binary tree.
    /// TODO: Perform breadth-first traversal collecting values by depth.
    /// </summary>
    public IList<IList<int>> LevelOrder(TreeNode? root)
    {
        return new List<IList<int>>();
    }
}
