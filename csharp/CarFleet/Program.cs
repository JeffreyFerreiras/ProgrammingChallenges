using System.Diagnostics;
using System.Reflection;
using CarFleet;

class Program
{
    delegate int SolutionMethod(int target, int[] position, int[] speed);

    static void Main()
    {
        Console.WriteLine("853. Car Fleet");
        Console.WriteLine("===============\n");

        // Discover public static methods returning int and taking (int, int[], int[])
        MethodInfo[] methodsInfo = typeof(Solution)
            .GetMethods(BindingFlags.Public | BindingFlags.Static)
            .Where(m =>
                m.ReturnType == typeof(int)
                && m.GetParameters().Length == 3
                && m.GetParameters()[0].ParameterType == typeof(int)
                && m.GetParameters()[1].ParameterType == typeof(int[])
                && m.GetParameters()[2].ParameterType == typeof(int[])
            )
            .ToArray();

        string[] methodNames = methodsInfo.Select(m => m.Name).ToArray();
        SolutionMethod[] methods = methodsInfo
            .Select(m => (SolutionMethod)Delegate.CreateDelegate(typeof(SolutionMethod), m))
            .ToArray();

        void Run(string name, int target, int[] position, int[] speed, int expected)
        {
            Console.WriteLine($"Test: {name}");
            Console.WriteLine(
                $"  Input: target={target}, position=[{string.Join(",", position)}], speed=[{string.Join(",", speed)}]"
            );
            foreach (var (method, idx) in methods.Select((m, i) => (m, i)))
            {
                var sw = Stopwatch.StartNew();
                try
                {
                    int result = method(target, position, speed);
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

        // Example test cases
        Run("Example 1", 12, new[] { 10, 8, 0, 5, 3 }, new[] { 2, 4, 1, 1, 3 }, 3);
        Run("Example 2", 10, new[] { 3 }, new[] { 3 }, 1);
        Run("Example 3", 100, new[] { 0, 2, 4 }, new[] { 4, 2, 1 }, 1);

        // Edge cases
        Run("Single car", 10, new[] { 5 }, new[] { 2 }, 1);
        Run("Two cars same fleet", 10, new[] { 8, 6 }, new[] { 1, 2 }, 1);
        Run("Two cars separate fleets", 10, new[] { 8, 6 }, new[] { 2, 1 }, 2);
        Run("All same speed", 100, new[] { 10, 20, 30 }, new[] { 5, 5, 5 }, 3);

        Console.WriteLine("Done.");
    }
}
