using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Meta March 2025\n");

        var solution = new RefinedSolution();

        var scenarios = new[]
        {
            new Scenario("[-1,1,3,4,-2] k=1", new[] { -1,1,3,4,-2 }, 1, 4),
            new Scenario("[-1,1,3,4,-2] k=2", new[] { -1,1,3,4,-2 }, 2, 3),
            new Scenario("[5,10,15,20,25] k=2", new[] { 5,10,15,20,25 }, 2, 20),
            new Scenario("[100,50,25,75] k=2",   new[] { 100,50,25,75 }, 2, 75),
        };

        var methods = typeof(RefinedSolution)
            .GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly)
            .Where(m => !m.IsSpecialName)
            .Where(m => m.GetParameters().Length == 2)
            .Where(m => m.GetParameters()[0].ParameterType == typeof(int[]))
            .Where(m => m.GetParameters()[1].ParameterType == typeof(int))
            .Where(m => m.ReturnType == typeof(int))
            .OrderBy(m => m.Name)
            .ToArray();

        foreach (var scenario in scenarios)
        {
            Console.WriteLine($"\n=== {scenario.Name} ===");

            foreach (var method in methods)
            {
                var sw = Stopwatch.StartNew();
                object? result = null;
                Exception? exception = null;

                try { result = method.Invoke(solution, new object?[] { (int[])scenario.Nums.Clone(), scenario.K }); }
                catch (Exception ex) { exception = ex; }
                finally { sw.Stop(); }

                Console.Write($"{method.Name} | {sw.Elapsed.TotalMilliseconds:0.0000} ms | ");

                if (exception != null) { Console.WriteLine($"ERROR: {exception.GetBaseException().Message}"); continue; }

                var actual = result!.ToString()!;
                var expected = scenario.Expected.ToString();
                Console.WriteLine($"{actual} | Expected {expected} | {(actual == expected ? "✅ PASS" : "❌ FAIL")}");
            }
        }

        Console.WriteLine();
    }

    private sealed record Scenario(string Name, int[] Nums, int K, int Expected);
}
