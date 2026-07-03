using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("133. Clone Graph\n");

        // Build test graph: 1-2-3-4-1 cycle
        var n1 = new Node(1); var n2 = new Node(2); var n3 = new Node(3); var n4 = new Node(4);
        n1.neighbors = new List<Node> { n2, n4 };
        n2.neighbors = new List<Node> { n1, n3 };
        n3.neighbors = new List<Node> { n2, n4 };
        n4.neighbors = new List<Node> { n1, n3 };

        var scenarios = new[]
        {
            ("4-node cycle", n1),
            ("Single node", new Node(1)),
            ("Null", (Node?)null),
        };

        foreach (var (name, input) in scenarios)
        {
            Console.WriteLine($"\n=== {name} ===");
            var sw = Stopwatch.StartNew();
            Node? result = null;
            Exception? exception = null;

            try { result = Solution.CloneGraph(input!); }
            catch (Exception ex) { exception = ex; }
            finally { sw.Stop(); }

            Console.Write($"CloneGraph | {sw.Elapsed.TotalMilliseconds:0.0000} ms | ");

            if (exception != null) { Console.WriteLine($"ERROR: {exception.GetBaseException().Message}"); continue; }

            var originalStr = FormatGraph(input);
            var cloneStr    = FormatGraph(result);
            var notSameRef  = !ReferenceEquals(input, result);
            Console.WriteLine($"Original: {originalStr} | Clone: {cloneStr} | Different ref: {notSameRef} | {(originalStr == cloneStr && notSameRef ? "✅ PASS" : "❌ FAIL")}");
        }

        Console.WriteLine();
    }

    private static string FormatGraph(Node? node)
    {
        if (node is null) return "null";
        var visited = new HashSet<int>();
        var parts = new List<string>();
        var queue = new Queue<Node>();
        queue.Enqueue(node);
        visited.Add(node.val);
        while (queue.Count > 0)
        {
            var curr = queue.Dequeue();
            var neighborVals = string.Join(",", curr.neighbors.Select(n => n.val));
            parts.Add($"{curr.val}:[{neighborVals}]");
            foreach (var nb in curr.neighbors)
                if (!visited.Contains(nb.val)) { visited.Add(nb.val); queue.Enqueue(nb); }
        }
        parts.Sort();
        return "{" + string.Join(";", parts) + "}";
    }
}
