namespace BalancedBinaryTree;

public class TreeNode(int val, TreeNode? left = null, TreeNode? right = null)
{
    public int val { get; } = val;
    public TreeNode? left { get; set; } = left;
    public TreeNode? right { get; set; } = right;
}

public class Solution
{
    /// <summary>
    /// Determines whether the binary tree is height-balanced.
    /// Uses an O(n) post-order traversal that returns -1 for any unbalanced subtree.
    /// </summary>
    public bool IsBalanced(TreeNode? root)
    {
        // If CheckHeight returns -1, a subtree was unbalanced
        return CheckHeight(root) != -1;
    }

    /// <summary>
    /// Returns the height of the subtree, or -1 if the subtree is unbalanced.
    /// </summary>
    private int CheckHeight(TreeNode? node)
    {
        if (node is null)
            return 0;

        int leftHeight = CheckHeight(node.left);
        if (leftHeight == -1)
            return -1; // left subtree unbalanced

        int rightHeight = CheckHeight(node.right);
        if (rightHeight == -1)
            return -1; // right subtree unbalanced

        if (Math.Abs(leftHeight - rightHeight) > 1)
            return -1; // current node unbalanced

        return Math.Max(leftHeight, rightHeight) + 1;
    }
}
