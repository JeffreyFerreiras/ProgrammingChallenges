namespace BinaryTreeMaximumPathSum;

public class TreeNode(int val, TreeNode? left = null, TreeNode? right = null)
{
    public int val { get; } = val;
    public TreeNode? left { get; set; } = left;
    public TreeNode? right { get; set; } = right;
}

public class Solution
{
    /// <summary>
    /// Calculates the maximum path sum across any path in the binary tree.
    /// TODO: Combine local gains while tracking the best global sum during traversal.
    /// </summary>
    public int MaxPathSum(TreeNode? root, int sum = 0)
    {
        int globalMax = int.MinValue; // Initialize global maximum path sum to keep track of the best sum found
        _ = Dfs(root, ref globalMax); // Start DFS traversal from the root
        return globalMax; // Return the best path sum found during traversal
    }

    private int Dfs(TreeNode? node, ref int globalMax)
    {
        if (node is null)
        {
            return 0; // Base case: null nodes contribute 0 to the path sum
        }

        int leftGain = Math.Max(Dfs(node.left, ref globalMax), 0); // Calculate left tree gain or zero if negative or null
        int rightGain = Math.Max(Dfs(node.right, ref globalMax), 0); // Calculate right tree gain or zero if negative or null

        int currentPathSum = node.val + leftGain + rightGain; // Current path sum including both left and right gains
        globalMax = Math.Max(globalMax, currentPathSum); // Update global maximum if current path sum is greater

        return node.val + Math.Max(leftGain, rightGain); // Return the maximum gain from this node to its parent
    }
}
