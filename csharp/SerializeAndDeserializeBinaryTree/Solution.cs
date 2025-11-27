namespace SerializeAndDeserializeBinaryTree;

public class TreeNode(int val, TreeNode? left = null, TreeNode? right = null)
{
    public int val { get; } = val;
    public TreeNode? left { get; set; } = left;
    public TreeNode? right { get; set; } = right;
}

public class Solution
{
    /// <summary>
    /// Serializes a binary tree to a string representation.
    /// TODO: Encode the tree (e.g., BFS with null markers).
    /// </summary>
    public string Serialize(TreeNode? root)
    {
        if (root is null)
        {
            return "[]";
        }

        List<string> values = [];
        Queue<TreeNode?> queue = new ();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            if (node is null)
            {
                values.Add("null");
                continue;
            }

            values.Add(node.val.ToString());
            
            queue.Enqueue(node.left);
            queue.Enqueue(node.right);
        }

        // Remove trailing "null" values for a cleaner representation
        int lasNonNullIndex = values.FindLastIndex(value => value != "null");
        values = values[..(lasNonNullIndex + 1)];
        return "[" + string.Join(",", values) + "]";
    }

    /// <summary>
    /// Deserializes the string representation back into the original binary tree.
    /// TODO: Parse the data string and rebuild the tree structure.
    /// </summary>
    public TreeNode? Deserialize(string data)
    {
        List<TreeNode?> values = [.. data.Trim('[', ']')
            .Split(',', StringSplitOptions.RemoveEmptyEntries)
            .Select(s => s == "null" ? null : new TreeNode(int.Parse(s)))
            ];

        if (values.Count == 0) return null;
        
        var queue = new Queue<TreeNode>();
        queue.Enqueue(values[0]!);

        var i = 1;
        while (i < values.Count && queue.Count > 0)
        {
            var current = queue.Dequeue();

            if (i < values.Count)
            {
                if (values[i] is not null)
                {
                    current.left = values[i];
                    queue.Enqueue(current.left!);
                }
                i++;
            }

            if (i < values.Count)
            {
                if (values[i] is not null)
                {
                    current.right = values[i];
                    queue.Enqueue(current.right!);
                }
                i++;
            }
        }

        return values[0];
    }
}
