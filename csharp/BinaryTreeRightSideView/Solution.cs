using System.Collections.Generic;

namespace BinaryTreeRightSideView;

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
    /// Returns the values visible from the right side of the tree.
    /// TODO: Traverse level by level keeping the last node encountered per depth.
    /// </summary>
    public IList<int> RightSideView(TreeNode? root)
    {
        return new List<int>();
    }
}
