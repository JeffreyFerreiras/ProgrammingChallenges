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
        int goodNodesCount = 0;
        Count(root, int.MinValue);
        return goodNodesCount;

        void Count(TreeNode? node, int prev)
        {
            if (node is null) return;
            if (node.Val >= prev)
            {
                goodNodesCount += 1;
            }

            var nextMax = node.Val > prev ? node.Val : prev;
            Count(node.Left, nextMax);
            Count(node.Right, nextMax);
        }
    }
}
