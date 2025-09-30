namespace SameTree;

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
    /// Determines if two binary trees are structurally identical with matching values.
    /// TODO: Recursively compare corresponding nodes from both trees.
    /// </summary>
    public bool IsSameTree(TreeNode? p, TreeNode? q)
    {
        return false;
    }
}
