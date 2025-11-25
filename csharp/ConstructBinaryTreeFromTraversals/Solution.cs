namespace ConstructBinaryTreeFromTraversals;

public class TreeNode(int val, TreeNode? left = null, TreeNode? right = null)
{
    public int val { get; } = val;
    public TreeNode? left { get; set; } = left;
    public TreeNode? right { get; set; } = right;
}

/// <summary>
/// Provides methods to construct binary trees from preorder and inorder traversal arrays.
/// </summary>
public class Solution
{
    public TreeNode? BuildTree(int[] preorder, int[] inorder)
    {
        if (preorder.Length == 0 || inorder.Length == 0)
        {
            return null;
        }

        if (preorder.Length == 1)
        {
            return new TreeNode(preorder[0]);
        }

        TreeNode root = new(preorder[0]); 
        int inorderTreeRootIndex = inorder.Index().First(x => x.Item == preorder[0]).Index;
        root.left = BuildTree(preorder[1..(inorderTreeRootIndex + 1)], inorder[0..inorderTreeRootIndex]);
        root.right = BuildTree(preorder[(inorderTreeRootIndex + 1)..], inorder[(inorderTreeRootIndex + 1)..]);
        return root;
    }

    public TreeNode? BuildTree_Dictionary(int[] preorder, int[] inorder)
    {
        int preOrderIndex = 0;
        Dictionary<int, int> inorderIndexMap = [];

        for (int i = 0; i < inorder.Length; i++)
        {
            inorderIndexMap[inorder[i]] = i;
        }

        return Dfs(preorder, 0, inorder.Length - 1);

        TreeNode? Dfs(int[] preorder, int leftInorderIndex, int rightInorderIndex)
        {
            if (leftInorderIndex > rightInorderIndex) return null;

            int rootValue = preorder[preOrderIndex++]; // Get root value and increment preorder index
            TreeNode root = new (rootValue);
            int inorderTreeRootIndex = inorderIndexMap[rootValue];
            
            root.left = Dfs(preorder, leftInorderIndex, inorderTreeRootIndex - 1);
            root.right = Dfs(preorder, inorderTreeRootIndex + 1, rightInorderIndex);

            return root;
        }
    }
}
