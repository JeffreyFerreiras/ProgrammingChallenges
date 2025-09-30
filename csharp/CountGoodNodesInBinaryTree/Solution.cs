namespace CountGoodNodesInBinaryTree;

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
    /// Counts the nodes whose value is at least the maximum observed on the path from the root.
    /// TODO: Perform depth-first traversal tracking the running maximum.
    /// </summary>
    public int GoodNodes(TreeNode? root)
    {
        return 0;
    }
}
