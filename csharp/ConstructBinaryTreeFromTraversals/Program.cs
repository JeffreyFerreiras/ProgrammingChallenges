using System.Diagnostics;

namespace ConstructBinaryTreeFromTraversals;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("Construct Binary Tree from Traversals");
        Console.WriteLine(new string('=', 41) + "\n");

        var solution = new Solution();

        var scenarios = new[]
        {
            (Name: "Example 1",     Preorder: new[] { 3, 9, 20, 15, 7 }, Inorder: new[] { 9, 3, 15, 20, 7 }, Expected: new int?[] { 3, 9, 20, null, null, 15, 7 }),
            (Name: "Example 2",     Preorder: [-1], Inorder: [-1], Expected: [-1]),
            (Name: "Left Skewed",   Preorder: [4, 3, 2, 1], Inorder: [1, 2, 3, 4], Expected: [4, 3, null, 2, null, 1]),
            (Name: "Right Skewed",  Preorder: [1, 2, 3, 4], Inorder: [1, 2, 3, 4], Expected: [1, null, 2, null, 3, null, 4]),
            (Name: "Balanced",      Preorder: [8, 4, 2, 6, 12, 10, 14], Inorder: [2, 4, 6, 8, 10, 12, 14], Expected: [8, 4, 12, 2, 6, 10, 14]),
            (Name: "Large",         Preorder: [10, 5, 2, 7, 15, 12, 20, 17], Inorder: [2, 5, 7, 10, 12, 15, 17, 20], Expected: [10, 5, 15, 2, 7, 12, 20, null, null, null, null, null, null, 17]),
            (Name: "Perfect Height 2", Preorder: [1, 2, 4, 5, 3, 6, 7], Inorder: [4, 2, 5, 1, 6, 3, 7], Expected: [1, 2, 3, 4, 5, 6, 7]),
            (Name: "Root Right With Left Child", Preorder: [1, 2, 3, 4], Inorder: [2, 1, 4, 3], Expected: [1, 2, 3, null, null, 4]),
            (Name: "ZigZag Right-Left", Preorder: [1, 2, 3, 4], Inorder: [1, 3, 4, 2], Expected: [1, null, 2, 3, null, null, 4]),
            (Name: "Missing One Leaf",  Preorder: [5, 3, 2, 8, 7, 9], Inorder: [2, 3, 5, 7, 8, 9], Expected: [5, 3, 8, 2, null, 7, 9])
        };

        foreach (var (Name, Preorder, Inorder, Expected) in scenarios)
        {
            var methods = solution.GetType().GetMethods().Where(m => m.DeclaringType == typeof(Solution) && m.IsPublic);
            foreach (var method in methods)
            {
                var stopwatch = Stopwatch.StartNew();
                var result = method.Invoke(solution, [Preorder, Inorder]) as TreeNode;
                stopwatch.Stop();

                Console.WriteLine($"Scenario: {Name}");
                Console.WriteLine($"Method: {method.Name}");
                Console.WriteLine($"Preorder: {FormatArray(Preorder)}");
                Console.WriteLine($"Inorder: {FormatArray(Inorder)}");
                Console.WriteLine($"Result: {FormatTree(result)}");
                Console.WriteLine($"Expected: {FormatArray(Expected)}");
                Console.WriteLine($"Elapsed: {stopwatch.Elapsed.TotalMilliseconds:F4} ms");
                Console.WriteLine($"Passed: {((FormatTree(result) == FormatArray(Expected)) ? "✔️" : "❌")}");

                Console.WriteLine(new string('-', 60));
            }
        }
    }

    private static string FormatArray(IEnumerable<int> values)
    {
        return "[" + string.Join(",", values) + "]";
    }

    private static string FormatArray(IEnumerable<int?> values)
    {
        return "[" + string.Join(",", values.Select(v => v?.ToString() ?? "null")) + "]";
    }

    private static string FormatTree(TreeNode? root)
    {
        if (root is null)
        {
            return "[]";
        }

        var queue = new Queue<TreeNode?>();
        var values = new List<string>();
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

        for (var i = values.Count - 1; i >= 0; i--)
        {
            if (values[i] != "null")
            {
                break;
            }
            values.RemoveAt(i);
        }

        return "[" + string.Join(",", values) + "]";
    }
}
