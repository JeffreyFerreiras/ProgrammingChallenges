namespace ConstructBinaryTreeFromTraversals;

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
    /// Reconstructs a binary tree from its preorder and inorder traversals.
    /// TODO: Use recursion with index tracking or iterative stack technique.
    /// </summary>
    public TreeNode? BuildTree(int[] preorder, int[] inorder)
    {
        return null;
    }
}
