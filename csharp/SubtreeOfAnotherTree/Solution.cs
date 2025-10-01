namespace SubtreeOfAnotherTree;

public class TreeNode(int val, TreeNode? left = null, TreeNode? right = null)
{
    public int Val { get; } = val;
    public TreeNode? Left { get; set; } = left;
    public TreeNode? Right { get; set; } = right;
}

public class Solution
{
    /// <summary>
    /// Determines whether <paramref name="subRoot"/> is a subtree of <paramref name="root"/>.
    /// TODO: Compare rooted subtrees either via serialization or recursive matching.
    /// </summary>
    public bool IsSubtree(TreeNode? root, TreeNode? subRoot)
    {
        return false;
    }
}
