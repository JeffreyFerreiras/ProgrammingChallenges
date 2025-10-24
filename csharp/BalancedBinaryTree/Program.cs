using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace BalancedBinaryTree;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("Balanced Binary Tree");
        Console.WriteLine(new string('=', 20) + "\n");

        var solution = new Solution();

        var scenarios = new[]
        {
            (Name: "Example 1", Values: [3, 9, 20, null, null, 15, 7], Expected: true),
            (
                Name: "Example 2",
                Values: [1, 2, 2, 3, 3, null, null, 4, 4],
                Expected: false
            ),
            (Name: "Edge: Empty", Values: Array.Empty<int?>(), Expected: true),
            (Name: "Edge: Single Node", Values: [5], Expected: true),
            (Name: "Left Heavy", Values: [1, 2, null, 3, null, 4], Expected: false),
            (Name: "Right Heavy", Values: [1, null, 2, null, 3], Expected: false),
            (
                Name: "Balanced Larger",
                Values: [1, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, 4, 4],
                Expected: true
            ),
            (
                Name: "Custom: [1,2,2,3,null,null,3,4,null,null,4]",
                Values: [1, 2, 2, 3, null, null, 3, 4, null, null, 4],
                Expected: false
            ),
        };

        var passed = 0;
        var failed = 0;
        var failedScenarios = new List<string>();

        foreach (var scenario in scenarios)
        {
            // Print the scenario input and expected value BEFORE running
            var formattedInput = "[" + string.Join(", ", scenario.Values.Select(v => v.HasValue ? v.Value.ToString() : "null")) + "]";
            Console.WriteLine($"Scenario: {scenario.Name}");
            Console.WriteLine($"Input: {formattedInput}");
            Console.WriteLine($"Expected: {scenario.Expected}");

            var root = BuildTree(scenario.Values);

            var stopwatch = Stopwatch.StartNew();
            var result = solution.IsBalanced(root);
            stopwatch.Stop();

            // Add a checkmark when the test passes (result matches expected)
            var passMark = result == scenario.Expected ? " ✓" : string.Empty;
            Console.WriteLine($"Method: {nameof(Solution.IsBalanced)}");
            Console.WriteLine($"Result: {result}, Expected: {scenario.Expected}{passMark}");
            Console.WriteLine($"Elapsed: {stopwatch.Elapsed.TotalMilliseconds:F4} ms");

            if (result == scenario.Expected)
            {
                passed++;
            }
            else
            {
                failed++;
                failedScenarios.Add(scenario.Name ?? "(unnamed)");
                Console.WriteLine($"Mismatch: scenario '{scenario.Name}' expected {scenario.Expected} but got {result}");
            }

            Console.WriteLine(new string('-', 60));
        }

        // Summary
        Console.WriteLine("Test summary:");
        Console.WriteLine($"Passed: {passed}, Failed: {failed}, Total: {scenarios.Length}");
        if (failed > 0)
        {
            Console.WriteLine("Failed scenarios:");
            foreach (var name in failedScenarios)
            {
                Console.WriteLine($" - {name}");
            }
        }
    }

    private static TreeNode? BuildTree(IReadOnlyList<int?> values)
    {
        if (values.Count == 0)
        {
            return null;
        }

        var nodes = new TreeNode?[values.Count];
        for (var i = 0; i < values.Count; i++)
        {
            if (values[i].HasValue)
            {
                nodes[i] = new TreeNode(values[i]!.Value);
            }
        }

        for (var i = 0; i < values.Count; i++)
        {
            var current = nodes[i];
            if (current is null)
            {
                continue;
            }

            var leftIndex = 2 * i + 1;
            var rightIndex = 2 * i + 2;

            if (leftIndex < values.Count)
            {
                current.left = nodes[leftIndex];
            }

            if (rightIndex < values.Count)
            {
                current.right = nodes[rightIndex];
            }
        }

        return nodes[0];
    }
}
