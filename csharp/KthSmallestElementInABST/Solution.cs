namespace KthSmallestElementInABST;

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
    /// Returns the k-th smallest value present in the BST.
    /// TODO: Traverse the tree in-order while counting visited nodes.
    /// </summary>
    public int KthSmallest(TreeNode? root, int k)
    {
        return 0;
    }
}
