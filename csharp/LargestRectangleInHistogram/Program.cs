using System.Diagnostics;
using System.Reflection;
using LargestRectangleInHistogram;

class Program
{
    delegate int SolutionMethod(int[] heights);

    static void Main()
    {
        Console.WriteLine("84. Largest Rectangle in Histogram");
        Console.WriteLine("===================================\n");

        // Discover public static methods returning int and taking (int[])
        MethodInfo[] methodsInfo =
        [
            .. typeof(Solution)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(m =>
                    m.ReturnType == typeof(int)
                    && m.GetParameters().Length == 1
                    && m.GetParameters()[0].ParameterType == typeof(int[])
                ),
        ];

        string[] methodNames = [.. methodsInfo.Select(m => m.Name)];
        SolutionMethod[] methods =
        [
            .. methodsInfo.Select(m =>
                (SolutionMethod)Delegate.CreateDelegate(typeof(SolutionMethod), m)
            ),
        ];

        void Run(string name, int[] heights, int expected)
        {
            Console.WriteLine($"Test: {name}");
            Console.WriteLine($"  Input: heights=[{string.Join(",", heights)}]");
            foreach (var (method, idx) in methods.Select((m, i) => (m, i)))
            {
                var sw = Stopwatch.StartNew();
                try
                {
                    int result = method(heights);
                    sw.Stop();
                    bool ok = result == expected;
                    string status = ok ? "✓ PASSED" : "✗ FAILED";
                    Console.WriteLine(
                        $"  {methodNames[idx]}: {status} [{sw.Elapsed.TotalMilliseconds:F4} ms]"
                    );
                    Console.WriteLine($"    Result: {result}, Expected: {expected}");
                }
                catch (NotImplementedException)
                {
                    sw.Stop();
                    Console.WriteLine(
                        $"  {methodNames[idx]}: ⚠ NOT IMPLEMENTED [{sw.Elapsed.TotalMilliseconds:F4} ms]"
                    );
                    Console.WriteLine($"    Expected: {expected}");
                }
                catch (Exception ex)
                {
                    sw.Stop();
                    Console.WriteLine(
                        $"  {methodNames[idx]}: ✗ ERROR [{sw.Elapsed.TotalMilliseconds:F4} ms]"
                    );
                    Console.WriteLine($"    Error: {ex.Message}");
                }
            }
            Console.WriteLine();
        }

        // Test cases
        Run("Example 1", [2, 1, 5, 6, 2, 3], 10);
        Run("Example 2", [2, 4], 4);
        Run("Single bar", [5], 5);
        Run("Increasing", [1, 2, 3, 4, 5], 9);
        Run("Decreasing", [5, 4, 3, 2, 1], 9);
        Run("With zeros", [0, 1, 0, 1], 1);
        Run("All zeros", [0, 0, 0], 0);
    }
}
