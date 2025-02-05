namespace BinaryTreeLevelOrderTraversal;

/**
* Definition for a binary tree node.
* public class TreeNode {
*     public int val;
*     public TreeNode left;
*     public TreeNode right;
*     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
*         this.val = val;
*         this.left = left;
*         this.right = right;
*     }
* }
*/
public class TreeNode
{
    public int val;
    public TreeNode? left;
    public TreeNode? right;
    public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class Solution
{
    public IList<IList<int>> LevelOrder(TreeNode? root)
    {
        if (root == null) return [];
        IList<IList<int>> result = [];

        //assign current level
        result.Add([root.val]);

        Traverse(root?.left, result, 1);
        Traverse(root?.right, result, 1);

        //add the list to the result
        return result;
    }

    void Traverse(TreeNode? node, IList<IList<int>> result, int level)
    {
        if (node == null) return;

        //make sure result has that index
        if (result.Count - 1 < level)
        {
            result.Add([]);
        }

        result[level] ??= new List<int>(); //create a list for each level
        result[level].Add(node.val);
        Console.WriteLine(node.val);
        Traverse(node.left, result, level + 1);
        Traverse(node.right, result, level + 1);
    }
}
