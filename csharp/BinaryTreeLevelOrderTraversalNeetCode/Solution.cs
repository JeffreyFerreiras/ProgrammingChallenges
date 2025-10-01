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
        return new List<IList<int>>();
    }
}
