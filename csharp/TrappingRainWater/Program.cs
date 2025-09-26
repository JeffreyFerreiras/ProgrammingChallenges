using System.Diagnostics;
using System.Reflection;
using TrappingRainWater;

class Program
{
    delegate int SolutionMethod(int[] height);

    static void Main()
    {
        Console.WriteLine("42. Trapping Rain Water");
        Console.WriteLine("========================\n");

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

        void Run(string name, int[] height, int expected)
        {
            Console.WriteLine($"Test: {name}");
            Console.WriteLine($"  Input: height=[{string.Join(",", height)}]");
            foreach (var (method, idx) in methods.Select((m, i) => (m, i)))
            {
                var sw = Stopwatch.StartNew();
                try
                {
                    int result = method(height);
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
        Run("Example 1", [0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1], 6);
        Run("Example 2", [4, 2, 0, 3, 2, 5], 9);
        Run("No water", [1, 2, 3], 0);
        Run("Flat", [3, 3, 3], 0);
        Run("Edge case", [1], 0);
        Run("Two bars", [4, 2], 0);
        Run("Simple basin", [3, 0, 2, 0, 4], 7);
    }
}