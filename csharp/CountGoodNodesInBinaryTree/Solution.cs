namespace CountGoodNodesInBinaryTree;

public class TreeNode(int val, TreeNode? left = null, TreeNode? right = null)
{
    public int Val { get; } = val;
    public TreeNode? Left { get; set; } = left;
    public TreeNode? Right { get; set; } = right;
}

public class Solution
{
    /// <summary>
    /// Counts the nodes whose value is at least the maximum observed on the path from the root.
    /// TODO: Perform depth-first traversal tracking the running maximum.
    /// </summary>
    public int GoodNodes(TreeNode? root)
    {
        return 0;
    }
}
