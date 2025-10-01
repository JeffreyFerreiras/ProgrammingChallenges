namespace BinaryTreeMaximumPathSum;

public class TreeNode(int val, TreeNode? left = null, TreeNode? right = null)
{
    public int Val { get; } = val;
    public TreeNode? Left { get; set; } = left;
    public TreeNode? Right { get; set; } = right;
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
