namespace BalancedBinaryTree;

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
    /// Determines whether the binary tree is height-balanced.
    /// TODO: Compare subtree heights and short-circuit when imbalance exceeds one level.
    /// </summary>
    public bool IsBalanced(TreeNode? root)
    {
        return false;
    }
}
