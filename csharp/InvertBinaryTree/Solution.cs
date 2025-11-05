namespace InvertBinaryTree;

public class TreeNode(int val, TreeNode? left = null, TreeNode? right = null)
{
    public int Val { get; } = val;
    public TreeNode? Left { get; set; } = left;
    public TreeNode? Right { get; set; } = right;
}

public class Solution
{
    /// <summary>
    /// Returns the root of the inverted binary tree.
    /// TODO: Implement a recursive or iterative swap of every node's children.
    /// </summary>
    public TreeNode? InvertTree(TreeNode? root)
    {
        if (root is null)
            return null;

        var right = root.Right;
        var left = root.Left;
        root.Right = InvertTree(left);
        root.Left = InvertTree(right);

        return root;
    }
}
