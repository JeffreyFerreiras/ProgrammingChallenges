namespace DiameterOfBinaryTree;

public class TreeNode(int val, TreeNode? left = null, TreeNode? right = null)
{
    public int val { get; } = val;
    public TreeNode? left { get; set; } = left;
    public TreeNode? right { get; set; } = right;
}

public class Solution
{
    private int maxDiameter = 0;

    /// <summary>
    /// Computes the diameter (maximum edge count between any two nodes) of the tree.
    /// TODO: Evaluate longest path using depth-first traversal tracking left and right depths.
    /// </summary>
    public int DiameterOfBinaryTree(TreeNode? root)
    {
        maxDiameter = 0;
        GetHeight(root);
        return maxDiameter;
    }

    private int GetHeight(TreeNode? node)
    {
        if (node is null)
            return 0;

        var leftHeight = GetHeight(node.left);
        var rightHeight = GetHeight(node.right);

        // Update the maximum diameter seen so far
        // The diameter through this node is leftHeight + rightHeight
        maxDiameter = Math.Max(maxDiameter, leftHeight + rightHeight);

        // Return the height of this subtree
        return Math.Max(leftHeight, rightHeight) + 1;
    }
}
