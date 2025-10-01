namespace KthSmallestElementInABST;

public class TreeNode(int val, TreeNode? left = null, TreeNode? right = null)
{
    public int Val { get; } = val;
    public TreeNode? Left { get; set; } = left;
    public TreeNode? Right { get; set; } = right;
}

public class Solution
{
    /// <summary>
    /// Returns the k-th smallest value present in the BST.
    /// TODO: Traverse the tree in-order while counting visited nodes.
    /// </summary>
    public int KthSmallest(TreeNode? root, int k)
    {
        return 0;
    }
}
