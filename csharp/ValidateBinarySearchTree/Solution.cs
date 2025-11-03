namespace ValidateBinarySearchTree;

public class TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
{
    public int val = val;
    public TreeNode? left = left;
    public TreeNode? right = right;
}

public class Solution
{
    public bool IsValidBST(TreeNode? root)
    {
        return IsValidBST(root, long.MinValue, long.MaxValue);
    }

    private bool IsValidBST(TreeNode? node, long minValue, long maxValue)
    {
        if (node is null)
        {
            return true;
        }

        // Current node's value must be within the valid range
        if (node.val <= minValue || node.val >= maxValue)
        {
            return false;
        }

        // Recursively validate left subtree (values must be less than current node)
        // and right subtree (values must be greater than current node)
        return IsValidBST(node.left, minValue, node.val)
            && IsValidBST(node.right, node.val, maxValue);
    }

    public bool IsValidBST_2(TreeNode? root)
    {
        // Iterative in-order traversal: values must be strictly increasing for a valid BST
        var stack = new Stack<TreeNode>();
        var current = root;
        long prev = long.MinValue;

        while (current is not null || stack.Count > 0)
        {
            // Go left as far as possible
            while (current is not null)
            {
                stack.Push(current);
                current = current.left;
            }

            var node = stack.Pop();
            // In-order sequence must be strictly increasing (no duplicates allowed)
            if (node.val <= prev)
            {
                return false;
            }
            prev = node.val;

            // Visit right subtree
            current = node.right;
        }

        return true;
    }
}
