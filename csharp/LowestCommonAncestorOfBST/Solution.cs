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
    /// <param name="p">The first node.</param>
    /// <param name="q">The second node.</param>
    /// <returns>The lowest common ancestor node, or null if not found.</returns>
    public TreeNode? LowestCommonAncestor(TreeNode? root, TreeNode? p, TreeNode? q)
    {
        if (root is null)
        {
            return null;
        }

        if (root == p || root == q)
        {
            return root;
        }

        var leftLCA = LowestCommonAncestor(root.left, p, q);
        var rightLCA = LowestCommonAncestor(root.right, p, q);

        if (leftLCA is not null && rightLCA is not null)
        {
            return root;
        }

        return leftLCA ?? rightLCA;
    }
}
