namespace BinaryTreeMaximumPathSum;

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
    /// Calculates the maximum path sum across any path in the binary tree.
    /// TODO: Combine local gains while tracking the best global sum during traversal.
    /// </summary>
    public int MaxPathSum(TreeNode? root)
    {
        return 0;
    }
}
