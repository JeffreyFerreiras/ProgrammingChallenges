namespace MaximumDepthOfBinaryTree;

public class TreeNode(int val, TreeNode? left = null, TreeNode? right = null)
{
    public int Val { get; } = val;
    public TreeNode? Left { get; set; } = left;
    public TreeNode? Right { get; set; } = right;
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
