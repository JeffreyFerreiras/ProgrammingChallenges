using System.Diagnostics;

namespace FindDuplicateNumberNeetCode;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("287. Find The Duplicate Number");
        Console.WriteLine("====================================================================");

        RunScenario(
            "Example: [1,3,4,2,2]",
            () => Solution.FindDuplicate(new[] { 1, 3, 4, 2, 2 }),
            2
        );

        RunScenario(
            "Edge: minimal length",
            () => Solution.FindDuplicate(new[] { 1, 1 }),
            1
        );

        RunScenario(
            "Long: duplicate in middle of range",
            () =>
            {
                var input = Enumerable.Range(1, 100).Concat(new[] { 73 }).ToArray();
                return Solution.FindDuplicate(input);
            },
            73
        );
    }

    private static void RunScenario(string name, Func<int> action, int expected)
    {
        var stopwatch = Stopwatch.StartNew();
        try
        {
            int result = action();
            stopwatch.Stop();
            Console.WriteLine($"Scenario: {name}");
            Console.WriteLine($"  Time: {stopwatch.Elapsed.TotalMilliseconds:F4} ms");
            Console.WriteLine($"  Result: {result}");
            Console.WriteLine($"  Expected: {expected}");
        }
        catch (NotImplementedException)
        {
            stopwatch.Stop();
            Console.WriteLine($"Scenario: {name}");
            Console.WriteLine($"  Status: NOT IMPLEMENTED [{stopwatch.Elapsed.TotalMilliseconds:F4} ms]");
            Console.WriteLine($"  Expected: {expected}");
        }
        catch (Exception ex)
        {
            stopwatch.Stop();
            Console.WriteLine($"Scenario: {name}");
            Console.WriteLine($"  Status: ERROR [{stopwatch.Elapsed.TotalMilliseconds:F4} ms]");
            Console.WriteLine($"  Message: {ex.Message}");
        }
    }
}
