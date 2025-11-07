namespace LowestCommonAncestorOfBST;

public class TreeNode(int val, TreeNode? left = null, TreeNode? right = null)
{
    public int val { get; } = val;
    public TreeNode? left { get; set; } = left;
    public TreeNode? right { get; set; } = right;
}

public class Solution
{
    /// <summary>
    /// Finds the lowest common ancestor of two nodes in a binary tree.
    /// </summary>
    /// <param name="root">The root of the binary tree.</param>
    /// <param name="nodeA">The first node.</param>
    /// <param name="nodeB">The second node.</param>
    /// <returns>The lowest common ancestor node, or null if not found.</returns>
    public TreeNode? LowestCommonAncestor(TreeNode? root, TreeNode? nodeA, TreeNode? nodeB)
    {
        if (root is null)
        {
            return null;
        }

        if (root == nodeA || root == nodeB)
        {
            return root;
        }

        var leftLCA = LowestCommonAncestor(root.left, nodeA, nodeB);
        var rightLCA = LowestCommonAncestor(root.right, nodeA, nodeB);

        if (leftLCA is not null && rightLCA is not null)
        {
            return root;
        }

        return leftLCA ?? rightLCA;
    }
}
