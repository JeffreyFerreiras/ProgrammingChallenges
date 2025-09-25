using System.Diagnostics;
using System.Reflection;
using AsteroidCollision;

class Program
{
    delegate int[] SolutionMethod(int[] asteroids);

    static void Main()
    {
        Console.WriteLine("735. Asteroid Collision");
        Console.WriteLine("========================\n");

        // Discover public static methods returning int[] and taking (int[])
        MethodInfo[] methodsInfo =
        [
            .. typeof(Solution)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(m =>
                    m.ReturnType == typeof(int[])
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

        void Run(string name, int[] asteroids, int[] expected)
        {
            Console.WriteLine($"Test: {name}");
            Console.WriteLine($"  Input: asteroids=[{string.Join(",", asteroids)}]");
            foreach (var (method, idx) in methods.Select((m, i) => (m, i)))
            {
                var sw = Stopwatch.StartNew();
                try
                {
                    int[] result = method(asteroids);
                    sw.Stop();
                    bool ok = result.SequenceEqual(expected);
                    string status = ok ? "✓ PASSED" : "✗ FAILED";
                    Console.WriteLine(
                        $"  {methodNames[idx]}: {status} [{sw.Elapsed.TotalMilliseconds:F4} ms]"
                    );
                    Console.WriteLine($"    Result: [{string.Join(",", result)}], Expected: [{string.Join(",", expected)}]");
                }
                catch (NotImplementedException)
                {
                    sw.Stop();
                    Console.WriteLine(
                        $"  {methodNames[idx]}: ⚠ NOT IMPLEMENTED [{sw.Elapsed.TotalMilliseconds:F4} ms]"
                    );
                    Console.WriteLine($"    Expected: [{string.Join(",", expected)}]");
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
        Run("Example 1", [5, 10, -5], [5, 10]);
        Run("Example 2", [8, -8], []);
        Run("No collision", [10, 2, 5], [10, 2, 5]);
        Run("All left", [-1, -2, -3], [-1, -2, -3]);
        Run("Chain reaction", [10, -5, -8], [-8]);
        Run("Equal destruction", [5, -5], []);
        Run("Complex", [1, -2, 3, -4], [-2, -4]);
    }
}