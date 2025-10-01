public static class Solution
{
    public static Node CloneGraph(Node node)
    {
        if (node == null) return null!;
        Queue<Node> queue = [];
        Dictionary<Node, Node> seen = [];
        var root = new Node(node.val, []);

        seen.Add(node, root);
        queue.Enqueue(node);

        while (queue.Count > 0)
        {
            var curr = queue.Dequeue();
            foreach (var neighbor in curr.neighbors)
            {
                if (!seen.ContainsKey(neighbor))
                {
                    seen.Add(neighbor, new Node(neighbor.val));
                    queue.Enqueue(neighbor);
                }

                var temp = new Node(neighbor.val);
                seen[curr].neighbors.Add(seen[neighbor]);
            }
        }

        return root;
    }
}
