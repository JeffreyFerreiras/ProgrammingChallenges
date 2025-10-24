namespace SameTree;

public class TreeNode(int val, TreeNode? left = null, TreeNode? right = null)
{
    public int Val { get; } = val;
    public TreeNode? Left { get; set; } = left;
    public TreeNode? Right { get; set; } = right;
}

public class Solution
{
    /// <summary>
    /// Determines if two binary trees are structurally identical with matching values.
    /// TODO: Recursively compare corresponding nodes from both trees.
    /// </summary>
    public bool IsSameTree(TreeNode? p, TreeNode? q)
    {
        if (p is null && q is null)
            return true;

        if (p.Val == q?.Val)
        {
            return IsSameTree(p.Left, q.Left) && IsSameTree(p.Right, q.Right);
        }

        return false;
    }
}
