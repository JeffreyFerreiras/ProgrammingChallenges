using System;
using System.Diagnostics;

namespace LinkedList_DeleteMiddleNode;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Delete Middle Node\n");

        // Scenario: delete node with value 6 from [5,6,9]
        var head1 = BuildNode(5, 6, 9);
        var target1 = head1.Find(6)!;
        RunScenario("Delete middle 6 from [5,6,9]", head1, target1, "[5,9]");

        // Scenario: delete node with value 1 from [1,2,3,4,5] (head can't be deleted this way)
        var head2 = BuildNode(1, 2, 3, 4, 5);
        var target2 = head2.Find(3)!;
        RunScenario("Delete middle 3 from [1,2,3,4,5]", head2, target2, "[1,2,4,5]");

        Console.WriteLine();
    }

    private static void RunScenario(string name, Node head, Node nodeToDelete, string expected)
    {
        Console.WriteLine($"\n=== {name} ===");
        var solution = new Solution();
        var sw = Stopwatch.StartNew();
        solution.Delete(nodeToDelete);
        sw.Stop();
        var actual = Format(head);
        Console.WriteLine($"Delete | {sw.Elapsed.TotalMilliseconds:0.0000} ms | {actual} | Expected {expected} | {(actual == expected ? "✅ PASS" : "❌ FAIL")}");
    }

    private static string Format(Node? node)
    {
        var parts = new System.Collections.Generic.List<int>();
        while (node != null) { parts.Add(node.Value); node = node.Next; }
        return "[" + string.Join(",", parts) + "]";
    }

    private static Node BuildNode(params int[] vals)
    {
        var root = new Node(vals[0]);
        for (int i = 1; i < vals.Length; i++) root.Add(vals[i]);
        return root;
    }
}
