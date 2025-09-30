using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace TaskScheduler;

internal record TestScenario(string Name, char[] Tasks, int Cooldown, int Expected);

internal static class Program
{
    public static void Main()
    {
        var solution = new Solution();
        var methodName = nameof(Solution.LeastInterval);

        TestScenario[] scenarios =
        [
            new(
                "Example 1",
                new[] { 'A', 'A', 'A', 'B', 'B', 'B' },
                2,
                8
            ),
            new(
                "Example 2",
                new[] { 'A', 'A', 'A', 'B', 'B', 'B' },
                0,
                6
            ),
            new(
                "Mixed Letters",
                new[] { 'A', 'A', 'A', 'B', 'C', 'C', 'D', 'D', 'D', 'E' },
                2,
                10
            ),
            new(
                "Large Alphabet",
                GenerateAlphabetWorkload(5),
                3,
                130
            ),
            new(
                "Single Task",
                new[] { 'Z' },
                5,
                1
            ),
        ];

        foreach (TestScenario scenario in scenarios)
        {
            RunScenario(solution, methodName, scenario);
        }
    }

    private static char[] GenerateAlphabetWorkload(int repeats)
    {
        List<char> tasks = new(26 * repeats);
        for (int i = 0; i < repeats; i++)
        {
            for (char c = 'A'; c <= 'Z'; c++)
            {
                tasks.Add(c);
            }
        }
        return tasks.ToArray();
    }

    private static void RunScenario(Solution solution, string methodName, TestScenario scenario)
    {
        Console.WriteLine($"Scenario: {scenario.Name}");
        Console.WriteLine($"Method: {methodName}");
        Console.WriteLine($"Cooldown: {scenario.Cooldown}");
        Console.WriteLine($"Task Count: {scenario.Tasks.Length}");
        Console.WriteLine($"Expected: {scenario.Expected}");
        Console.WriteLine($"Tasks Preview: {FormatTasks(scenario.Tasks)}");

        Stopwatch stopwatch = Stopwatch.StartNew();
        string resultDisplay;

        try
        {
            int result = solution.LeastInterval((char[])scenario.Tasks.Clone(), scenario.Cooldown);
            stopwatch.Stop();
            resultDisplay = result.ToString();
        }
        catch (NotImplementedException ex)
        {
            stopwatch.Stop();
            resultDisplay = $"Not Implemented ({ex.Message})";
        }
        catch (Exception ex)
        {
            stopwatch.Stop();
            resultDisplay = $"Error ({ex.GetType().Name}: {ex.Message})";
        }

        Console.WriteLine($"Elapsed: {stopwatch.Elapsed.TotalMilliseconds:F4} ms");
        Console.WriteLine($"Result: {resultDisplay}");
        Console.WriteLine();
    }

    private static string FormatTasks(char[] tasks)
    {
        const int previewCount = 16;
        if (tasks.Length <= previewCount)
        {
            return $"[{string.Join(",", tasks)}]";
        }

        string prefix = string.Join(",", tasks.Take(previewCount));
        return $"[{prefix}, ... x{tasks.Length - previewCount} more]";
    }
}
