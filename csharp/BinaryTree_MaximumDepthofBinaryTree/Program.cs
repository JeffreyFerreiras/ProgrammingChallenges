using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace BinaryTree_MaximumDepthofBinaryTree;

internal class Program
{
    private static void Main(string[] args)
    {
        var scenarios = new[]
        {
            new Scenario("Empty tree",          null,                                                        0),
            new Scenario("Single node",         new TreeNode(1),                                             1),
            new Scenario("Depth 3 [1,2,3,4]",  new TreeNode(1, new TreeNode(2), new TreeNode(3, null, new TreeNode(4))), 3),
            new Scenario("Left skew [1,2,3,4]", new TreeNode(1, new TreeNode(2, new TreeNode(3, new TreeNode(4)))),       4),
            new Scenario("Right skew depth 3",  new TreeNode(1, null, new TreeNode(2, null, new TreeNode(3))),            3),
        };

        foreach (var scenario in scenarios)
            RunScenario(scenario);

        Console.WriteLine();
    }

    private static void RunScenario(Scenario scenario)
    {
        Console.WriteLine($"\n=== {scenario.Name} ===");

        var solution = new Solution();
        var methods = typeof(Solution)
            .GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly)
            .Where(m => !m.IsSpecialName)
            .Where(m => m.GetParameters().Length == 1)
            .Where(m => m.ReturnType == typeof(int))
            .OrderBy(m => m.Name)
            .ToArray();

        foreach (var method in methods)
        {
            var stopwatch = Stopwatch.StartNew();
            object? result = null;
            Exception? exception = null;

            try
            {
                result = method.Invoke(solution, new object?[] { scenario.Root });
            }
            catch (Exception ex) { exception = ex; }
            finally { stopwatch.Stop(); }

            Console.Write($"{method.Name} | {stopwatch.Elapsed.TotalMilliseconds:0.0000} ms | ");

            if (exception != null)
            {
                Console.WriteLine($"ERROR: {exception.GetBaseException().Message}");
                continue;
            }

            var actual   = result!.ToString()!;
            var expected = scenario.Expected.ToString();
            Console.WriteLine($"{actual} | Expected {expected} | {(actual == expected ? "✅ PASS" : "❌ FAIL")}");
        }
    }

    private sealed record Scenario(string Name, TreeNode? Root, int Expected);
}
