namespace LowestCommonAncestorOfBST;

public class TreeNode(int val, TreeNode? left = null, TreeNode? right = null)
{
    public int val { get; } = val;
    public TreeNode? left { get; set; } = left;
    public TreeNode? right { get; set; } = right;
}

public class Solution
{
    /// <summary>
    /// Finds the lowest common ancestor of nodes p and q in the given BST.
    /// TODO: Leverage BST ordering to walk down toward the split point.
    /// </summary>
    public TreeNode? LowestCommonAncestor(TreeNode? root, TreeNode? p, TreeNode? q)
    {
        if (root is null || p is null || q is null)
        {
            return root ?? p ?? q;
        }

        var currentMin = root;
        var leftMin = Min(root, p, currentMin);
        var rightMin = Min(root, q, currentMin);
        
        return leftMin.val > rightMin.val ? rightMin : leftMin;
    }

    private TreeNode? Min(TreeNode? current, TreeNode target, TreeNode currentMin)
    {
        if (current is null)
        {
            return currentMin;
        }

        if (current != currentMin && current.val < currentMin?.val)
        {
            currentMin = current;
        }

        if (current == target)
        {
            // Found target, return current minimum or target if it's the smallest
            return currentMin?.val < current.val ? currentMin : current;
        }

        var left = Min(current.left, target, currentMin);
        var right = Min(current.right, target, currentMin);

        return left ?? right;
    }
}
