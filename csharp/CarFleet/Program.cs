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
        MethodInfo[] methodsInfo =
        [
            .. typeof(Solution)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(m =>
                    m.ReturnType == typeof(int)
                    && m.GetParameters().Length == 3
                    && m.GetParameters()[0].ParameterType == typeof(int)
                    && m.GetParameters()[1].ParameterType == typeof(int[])
                    && m.GetParameters()[2].ParameterType == typeof(int[])
                ),
        ];

        string[] methodNames = [.. methodsInfo.Select(m => m.Name)];
        SolutionMethod[] methods =
        [
            .. methodsInfo.Select(m =>
                (SolutionMethod)Delegate.CreateDelegate(typeof(SolutionMethod), m)
            ),
        ];

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
        Run("Example 1", 12, [10, 8, 0, 5, 3], [2, 4, 1, 1, 3], 3);
        Run("Example 2", 10, [3], [3], 1);
        Run("Example 3", 100, [0, 2, 4], [4, 2, 1], 1);

        // Edge cases
        Run("Single car", 10, [5], [2], 1);
        Run("Two cars same fleet", 10, [8, 6], [1, 2], 1);
        Run("Two cars separate fleets", 10, [8, 6], [2, 1], 2);
        Run("All same speed", 100, [10, 20, 30], [5, 5, 5], 3);

        // Longer scenarios with 10+ cars
        Run("Large convoy - all merge to one fleet",
            1000,
            [900, 800, 700, 600, 500, 400, 300, 200, 100, 50, 10],
            [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11],
            1);

        Run("Multiple fleets - complex scenario",
            100,
            [90, 85, 80, 70, 60, 50, 40, 30, 20, 10, 5],
            [1, 3, 2, 5, 4, 8, 6, 10, 9, 15, 12],
            1);

        Run("Highway traffic simulation",
            500,
            [450, 400, 350, 300, 250, 200, 150, 100, 80, 60, 40, 20, 10],
            [2, 4, 3, 6, 5, 8, 7, 10, 12, 15, 18, 20, 25],
            2);

        Run("Rush hour - slow and fast lanes",
            200,
            [180, 170, 160, 150, 140, 130, 120, 110, 100, 90, 80, 70, 60, 50],
            [1, 10, 2, 9, 3, 8, 4, 7, 5, 6, 11, 12, 13, 14],
            1);

        Run("Racing scenario - varying speeds",
            1000,
            [950, 900, 850, 800, 750, 700, 650, 600, 550, 500, 450, 400, 350, 300, 250],
            [5, 10, 15, 20, 25, 30, 35, 40, 45, 50, 55, 60, 65, 70, 75],
            1);

        Run("Complex merge patterns",
            300,
            [290, 280, 270, 250, 240, 220, 210, 200, 180, 170, 150, 140, 120, 100, 80, 60],
            [2, 1, 4, 3, 6, 5, 8, 7, 10, 9, 12, 11, 14, 13, 16, 15],
            2);

        Run("Large scale test - 20 cars",
            1000,
            [950, 900, 850, 800, 750, 700, 650, 600, 550, 500, 450, 400, 350, 300, 250, 200, 150, 100, 50, 25],
            [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20],
            1);

        Run("Alternating fast-slow pattern",
            400,
            [390, 380, 370, 360, 350, 340, 330, 320, 310, 300, 290, 280],
            [1, 20, 2, 19, 3, 18, 4, 17, 5, 16, 6, 15],
            6);

        Console.WriteLine("Done.");
    }
}
