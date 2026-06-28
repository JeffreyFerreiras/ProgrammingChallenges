using System.Diagnostics;
using System.Reflection;

namespace SingleNumber;

class Program
{
    static readonly (int[] Input, int Expected)[] Scenarios =
    [
        ([2, 2, 1],          1),
        ([4, 1, 2, 1, 2],   4),
        ([1],                1),
        ([2, 2, 1, 1, 3],   3),
        ([-1, -1, -2],      -2),
        ([0, 0, 5],          5),
    ];

    static void Main(string[] args)
    {
        var solution = new Solution();
        var methods = typeof(Solution)
            .GetMethods(BindingFlags.Public | BindingFlags.Instance)
            .Where(m => m.ReturnType == typeof(int)
                     && m.GetParameters() is [{ ParameterType: { } t } p] && t == typeof(int[]))
            .ToArray();

        foreach (var method in methods)
        {
            Console.WriteLine($"\n=== {method.Name} ===");
            bool allPassed = true;

            foreach (var (input, expected) in Scenarios)
            {
                int actual;
                bool skipped = false;

                var sw = Stopwatch.StartNew();
                try
                {
                    actual = (int)method.Invoke(solution, [(int[])input.Clone()])!;
                }
                catch (TargetInvocationException ex) when (ex.InnerException is NotImplementedException)
                {
                    Console.WriteLine($"  [{string.Join(", ", input),-20}]  SKIPPED (not implemented)");
                    skipped = true;
                    actual = 0;
                }
                sw.Stop();

                if (skipped) continue;

                bool passed = actual == expected;
                allPassed &= passed;
                string status = passed ? "✅ PASS" : "❌ FAIL";
                Console.WriteLine($"  [{string.Join(", ", input),-20}]  got={actual,5}  exp={expected,5}  {status}  ({sw.Elapsed.TotalMicroseconds:F1} µs)");
            }

            if (allPassed)
                Console.WriteLine("  All scenarios passed.");
        }
    }
}
