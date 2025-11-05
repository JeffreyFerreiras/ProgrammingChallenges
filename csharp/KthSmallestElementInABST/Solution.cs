namespace KthSmallestElementInABST;

public class TreeNode(int val, TreeNode? left = null, TreeNode? right = null)
{
    public int val { get; } = val;
    public TreeNode? left { get; set; } = left;
    public TreeNode? right { get; set; } = right;
}

public class Solution
{
    /// <summary>
    /// Returns the k-th smallest value present in the BST.
    /// TODO: Traverse the tree in-order while counting visited nodes.
    /// </summary>
    public int KthSmallest(TreeNode? root, int k)
    {
        int position = 0;
        int result = int.MinValue;
        InOrder(root);
        return result;

        void InOrder(TreeNode? node) {
            if (node is null) return;
            
            InOrder(node.left);
            position++;
            if (position == k)
            {
                result = node.val;
                return;
            }
            InOrder(node.right);
        }
    }
}
