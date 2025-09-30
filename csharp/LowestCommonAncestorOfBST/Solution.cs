namespace LowestCommonAncestorOfBST;

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
    /// Finds the lowest common ancestor of nodes p and q in the given BST.
    /// TODO: Leverage BST ordering to walk down toward the split point.
    /// </summary>
    public TreeNode? LowestCommonAncestor(TreeNode? root, TreeNode? p, TreeNode? q)
    {
        return root;
    }
}
