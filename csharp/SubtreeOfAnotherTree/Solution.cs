namespace SubtreeOfAnotherTree;

public class TreeNode(int val, TreeNode? left = null, TreeNode? right = null)
{
    public int val { get; } = val;
    public TreeNode? left { get; set; } = left;
    public TreeNode? right { get; set; } = right;
}

public class Solution
{
    /// <summary>
    /// Determines whether <paramref name="subRoot"/> is a subtree of <paramref name="root"/>.
    /// TODO: Compare rooted subtrees either via serialization or recursive matching.
    /// </summary>
    public bool IsSubtree(TreeNode? root, TreeNode? subRoot)
    {
        if (root is null && subRoot is null)
            return true;

        if (root is null || subRoot is null)
            return false;

        if (
            subRoot.left is null
            && subRoot.right is null
            && root.left is null
            && root.right is null
        ) //subRoot is a leaf and root is a leaf
        {
            return root.val == subRoot.val;
        }

        if (root.val != subRoot.val) //not a match at this node, search children
        {
            return IsSubtree(root.left, subRoot) || IsSubtree(root.right, subRoot);
        }

        // Values match, check children
        return IsSameTree(root, subRoot)
            || IsSubtree(root.left, subRoot)
            || IsSubtree(root.right, subRoot);
    }

    private bool IsSameTree(TreeNode? p, TreeNode? q)
    {
        if (p is null && q is null)
            return true;
        if (p is null || q is null)
            return false;

        return p.val == q.val && IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
    }
}
