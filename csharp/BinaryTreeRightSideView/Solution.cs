using System.Collections.Generic;

namespace BinaryTreeRightSideView;

public class TreeNode(int val, TreeNode? left = null, TreeNode? right = null)
{
    public int Val { get; } = val;
    public TreeNode? Left { get; set; } = left;
    public TreeNode? Right { get; set; } = right;
}

public class Solution
{
    /// <summary>
    /// Returns the values visible from the right side of the tree.
    /// TODO: Traverse level by level keeping the last node encountered per depth.
    /// </summary>
    public IList<int> RightSideView(TreeNode? root)
    {
        List<List<int>> levelOrder = [];

        Traverse(root, 0);

        return levelOrder.Select(level => level.Last()).ToList();

        void Traverse(TreeNode? node, int level)
        {
            if (node == null)
                return;
                
            if (levelOrder.Count <= level)
                levelOrder.Add([]);

            levelOrder[level].Add(node.Val);

            Traverse(node.Left, level + 1);
            Traverse(node.Right, level + 1);
        }
    }
}
