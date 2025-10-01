namespace BalancedBinaryTree;

public class TreeNode(int val, TreeNode? left = null, TreeNode? right = null)
{
    public int Val { get; } = val;
    public TreeNode? Left { get; set; } = left;
    public TreeNode? Right { get; set; } = right;
}

public class Solution
{
    /// <summary>
    /// Determines whether the binary tree is height-balanced.
    /// TODO: Compare subtree heights and short-circuit when imbalance exceeds one level.
    /// </summary>
    public bool IsBalanced(TreeNode? root)
    {
        return false;
    }
}
