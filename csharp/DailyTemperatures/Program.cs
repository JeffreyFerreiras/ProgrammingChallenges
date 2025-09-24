using System.Diagnostics;
using System.Reflection;
using DailyTemperatures;

class Program
{
    delegate int[] SolutionMethod(int[] nums);

    static void Main()
    {
        Console.WriteLine("739. Daily Temperatures");
        Console.WriteLine("========================\n");

        // Discover public static methods returning int[] and taking int[]
        MethodInfo[] methodsInfo = typeof(Solution)
            .GetMethods(BindingFlags.Public | BindingFlags.Static)
            .Where(m =>
                m.ReturnType == typeof(int[])
                && m.GetParameters().Length == 1
                && m.GetParameters()[0].ParameterType == typeof(int[])
            )
            .ToArray();

        string[] methodNames = methodsInfo.Select(m => m.Name).ToArray();
        SolutionMethod[] methods = methodsInfo
            .Select(m => (SolutionMethod)Delegate.CreateDelegate(typeof(SolutionMethod), m))
            .ToArray();

        void Run(string name, int[] input, int[] expected)
        {
            Console.WriteLine($"Test: {name}");
            foreach (var (method, idx) in methods.Select((m, i) => (m, i)))
            {
                var sw = Stopwatch.StartNew();
                int[] result = method(input);
                sw.Stop();
                bool ok =
                    result.Length == expected.Length
                    && result.Zip(expected, (a, b) => a == b).All(x => x);
                Console.WriteLine(
                    $"  {methodNames[idx]}: {(ok ? "PASSED" : "FAILED")} [{sw.Elapsed.TotalMilliseconds:F4} ms]"
                );
                Console.WriteLine($"    Result: [{string.Join(",", result)}]");
            }
            Console.WriteLine();
        }

        Run(
            "Example 1",
            new[] { 73, 74, 75, 71, 69, 72, 76, 73 },
            new[] { 1, 1, 4, 2, 1, 1, 0, 0 }
        );
        Run("Example 2", new[] { 30, 40, 50, 60 }, new[] { 1, 1, 1, 0 });
        Run("Example 3", new[] { 30, 60, 90 }, new[] { 1, 1, 0 });
        Run("Single", new[] { 100 }, new[] { 0 });
        Run("All equal", new[] { 50, 50, 50 }, new[] { 0, 0, 0 });
        Run("Descending", new[] { 80, 70, 60, 50 }, new[] { 0, 0, 0, 0 });

        Console.WriteLine("Done.");
    }
}
