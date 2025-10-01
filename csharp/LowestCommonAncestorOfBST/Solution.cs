namespace LowestCommonAncestorOfBST;

public class TreeNode(int val, TreeNode? left = null, TreeNode? right = null)
{
    public int Val { get; } = val;
    public TreeNode? Left { get; set; } = left;
    public TreeNode? Right { get; set; } = right;
}

public class Solution
{
    /// <summary>
    /// Finds the lowest common ancestor of nodes p and q in the given BST.
    /// TODO: Leverage BST ordering to walk down toward the split point.
    /// </summary>
    public TreeNode? LowestCommonAncestor(TreeNode? root, TreeNode? p, TreeNode? q)
    {
        return root;
    }
}
