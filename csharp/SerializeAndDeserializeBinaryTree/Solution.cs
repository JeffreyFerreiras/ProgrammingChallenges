namespace SerializeAndDeserializeBinaryTree;

public class TreeNode(int val, TreeNode? left = null, TreeNode? right = null)
{
    public int Val { get; } = val;
    public TreeNode? Left { get; set; } = left;
    public TreeNode? Right { get; set; } = right;
}

public class Solution
{
    /// <summary>
    /// Serializes a binary tree to a string representation.
    /// TODO: Encode the tree (e.g., BFS with null markers).
    /// </summary>
    public string Serialize(TreeNode? root)
    {
        return "[]";
    }

    /// <summary>
    /// Deserializes the string representation back into the original binary tree.
    /// TODO: Parse the data string and rebuild the tree structure.
    /// </summary>
    public TreeNode? Deserialize(string data)
    {
        return null;
    }
}
