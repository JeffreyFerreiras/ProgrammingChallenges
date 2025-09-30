namespace MaximumDepthOfBinaryTree;

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
    /// Calculates the maximum depth of the binary tree rooted at <paramref name="root"/>.
    /// TODO: Traverse the tree keeping track of the longest path from root to leaf.
    /// </summary>
    public int MaxDepth(TreeNode? root)
    {
        return 0;
    }
}
