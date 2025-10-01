namespace ValidateBinarySearchTree;

public class TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
{
    public int Val = val;
    public TreeNode? Left = left;
    public TreeNode? Right = right;
}

public class Solution
{
    public bool IsValidBST(TreeNode? root)
    {
        return IsValidBSTHelper(root, long.MinValue, long.MaxValue);
    }

    private bool IsValidBSTHelper(TreeNode? node, long minValue, long maxValue)
    {
        if (node is null)
        {
            return true;
        }

        // Current node's value must be within the valid range
        if (node.Val <= minValue || node.Val >= maxValue)
        {
            return false;
        }

        // Recursively validate left subtree (values must be less than current node)
        // and right subtree (values must be greater than current node)
        return IsValidBSTHelper(node.Left, minValue, node.Val)
            && IsValidBSTHelper(node.Right, node.Val, maxValue);
    }
}
