using System.Diagnostics;
using System.Reflection;

namespace ValidateBinarySearchTree;

public class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Validate Binary Search Tree");
        Console.WriteLine(new string('=', 30) + "\n");

        var solution = new Solution();

        var scenarios = new[]
        {
            (Name: "Example 1", Values: [2, 1, 3], Expected: true),
            (Name: "Example 2", Values: [5, 1, 4, null, null, 3, 6], Expected: false),
            (Name: "Edge: Empty", Values: Array.Empty<int?>(), Expected: true),
            (Name: "Single Node", Values: [8], Expected: true),
            (Name: "Duplicates", Values: [2, 2, 2], Expected: false),
            (Name: "Deep Violation", Values: [10, 5, 15, null, null, 6, 20], Expected: false),
            (Name: "Right Subtree Violation", Values: [5, 4, 6, null, null, 3, 7], Expected: false),
            (
                Name: "Valid Large",
                Values: [13, 9, 17, 5, 11, 15, 19, 3, 7, 10, 12, 14, 16, 18, 21],
                Expected: true
            ),
        };

        foreach (var scenario in scenarios)
        {
            var root = BuildTree(scenario.Values);

            Console.WriteLine($"Scenario: {scenario.Name}");
            Console.WriteLine($"Tree: {FormatArray(scenario.Values)}");

            var solutionType = typeof(Solution);
            var methods = solutionType
                .GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                .Where(m => !m.IsSpecialName)
                .Where(m =>
                {
                    var ps = m.GetParameters();
                    return ps.Length == 1 && ps[0].ParameterType == typeof(TreeNode);
                })
                .ToArray();

            if (methods.Length == 0)
            {
                Console.WriteLine(
                    "No invocable methods found on Solution matching signature (TreeNode?) -> *."
                );
                Console.WriteLine(new string('-', 60));
                continue;
            }

            foreach (var method in methods)
            {
                var stopwatch = Stopwatch.StartNew();
                var resultObj = method.Invoke(solution, new object?[] { root });
                stopwatch.Stop();

                Console.WriteLine($"Method: {method.Name}");
                if (resultObj is bool b)
                {
                    Console.WriteLine($"Result: {b}, Expected: {scenario.Expected}");
                }
                else
                {
                    Console.WriteLine($"Result: {resultObj}");
                }
                Console.WriteLine($"Elapsed: {stopwatch.Elapsed.TotalMilliseconds:F4} ms");
                Console.WriteLine(new string('-', 60));
            }
        }

        TreeNode? BuildTree(IReadOnlyList<int?> values)
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

        string FormatArray(IReadOnlyList<int?> values)
        {
            if (values.Count == 0)
            {
                return "[]";
            }

            return "[" + string.Join(",", values.Select(v => v?.ToString() ?? "null")) + "]";
        }
    }
}
