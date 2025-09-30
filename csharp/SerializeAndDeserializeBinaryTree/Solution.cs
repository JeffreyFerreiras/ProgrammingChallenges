namespace SerializeAndDeserializeBinaryTree;

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
