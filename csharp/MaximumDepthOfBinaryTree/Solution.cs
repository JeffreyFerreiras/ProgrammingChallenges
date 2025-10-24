namespace MaximumDepthOfBinaryTree;

public class TreeNode(int val, TreeNode? left = null, TreeNode? right = null)
{
    public int val { get; } = val;
    public TreeNode? left { get; set; } = left;
    public TreeNode? right { get; set; } = right;
}

public class Solution
{
    /// <summary>
    /// Calculates the maximum depth of the binary tree rooted at <paramref name="root"/>.
    /// TODO: Traverse the tree keeping track of the longest path from root to leaf.
    /// </summary>
    public int MaxDepth(TreeNode? root)
    {
        if (root is null)
            return 0;

        var leftDepth = MaxDepth(root.left);
        var rightDepth = MaxDepth(root.right);

        return Math.Max(leftDepth, rightDepth) + 1;
    }
}
