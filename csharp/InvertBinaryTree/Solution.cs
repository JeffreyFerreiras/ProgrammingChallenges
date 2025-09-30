namespace InvertBinaryTree;

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
    /// Returns the root of the inverted binary tree.
    /// TODO: Implement a recursive or iterative swap of every node's children.
    /// </summary>
    public TreeNode? InvertTree(TreeNode? root)
    {
        return root;
    }
}
