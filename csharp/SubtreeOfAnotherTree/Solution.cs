namespace SubtreeOfAnotherTree;

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
    /// Determines whether <paramref name="subRoot"/> is a subtree of <paramref name="root"/>.
    /// TODO: Compare rooted subtrees either via serialization or recursive matching.
    /// </summary>
    public bool IsSubtree(TreeNode? root, TreeNode? subRoot)
    {
        return false;
    }
}
