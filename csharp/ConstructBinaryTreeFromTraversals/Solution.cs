namespace ConstructBinaryTreeFromTraversals;

public class TreeNode(int val, TreeNode? left = null, TreeNode? right = null)
{
    public int Val { get; } = val;
    public TreeNode? Left { get; set; } = left;
    public TreeNode? Right { get; set; } = right;
}

public class Solution
{
    /// <summary>
    /// Reconstructs a binary tree from its preorder and inorder traversals.
    /// TODO: Use recursion with index tracking or iterative stack technique.
    /// </summary>
    public TreeNode? BuildTree(int[] preorder, int[] inorder)
    {
        return null;
    }
}
