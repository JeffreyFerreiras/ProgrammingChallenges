using System;
using System.Diagnostics;

namespace DecodeWaysNeetCode;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("Decode Ways");
        Console.WriteLine(new string('=', 11) + "\n");

        var solution = new Solution();

        var scenarios = new[]
        {
            (Name: "Example 1", S: "12", Expected: 2),
            (Name: "Example 2", S: "226", Expected: 3),
            (Name: "Example 3", S: "06", Expected: 0),
            (Name: "Edge: Zero", S: "0", Expected: 0),
            (Name: "Single Digit", S: "7", Expected: 1),
            (Name: "Long String", S: new string('1', 10), Expected: 89),
            (Name: "Zeros Inside", S: "1010", Expected: 1)
        };

        foreach (var scenario in scenarios)
        {
            var stopwatch = Stopwatch.StartNew();
            var result = solution.NumDecodings(scenario.S);
            stopwatch.Stop();

            Console.WriteLine($"Scenario: {scenario.Name}");
            Console.WriteLine($"Method: {nameof(Solution.NumDecodings)}");
            Console.WriteLine($"Input: s = \"{scenario.S}\"");
            Console.WriteLine($"Result: {result}, Expected: {scenario.Expected}");
            Console.WriteLine($"Elapsed: {stopwatch.Elapsed.TotalMilliseconds:F4} ms");
            Console.WriteLine(new string('-', 60));
        }
    }
}
