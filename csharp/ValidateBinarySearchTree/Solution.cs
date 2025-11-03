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
        return IsValidBST(root, long.MinValue, long.MaxValue);
    }

    private bool IsValidBST(TreeNode? node, long minValue, long maxValue)
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
        return IsValidBST(node.Left, minValue, node.Val)
            && IsValidBST(node.Right, node.Val, maxValue);
    }

    public bool IsValidBST_2(TreeNode? root)
    {
        if (root is null)
        {
            return true;
        }

        var stack = new Stack<TreeNode>();
        stack.Push(root);
        while (stack.Count > 0)
        {
            var node = stack.Pop();

            if (node.Left is not null)
            {
                if (node.Left.Val > node.Val)
                {
                    return false;
                }

                stack.Push(node.Left);
            }

            if (node.Right is not null)
            {
                if (node.Right.Val < node.Val)
                {
                    return false;
                }

                stack.Push(node.Right);
            }
        }

        return true;
    }
}
