using ProductOfArrayExceptSelf;
using System.Diagnostics;
using System.Reflection;

class Program
{
    delegate int[] SolutionMethod(int[] nums);

    static void Main()
    {
        // Create a stopwatch to measure total execution time
        Stopwatch totalStopwatch = Stopwatch.StartNew();

        Console.WriteLine("Starting ProductOfArrayExceptSelf tests...");
        Console.WriteLine("-------------------------------------------");

        // Define delegate for solution methods

        // Dynamically discover solution methods
        MethodInfo[] solutionMethods = typeof(Solution).GetMethods(BindingFlags.Public | BindingFlags.Static)
            .Where(m => m.ReturnType == typeof(int[]) && m.GetParameters().Length == 1 && m.GetParameters()[0].ParameterType == typeof(int[]))
            .ToArray();

        // Update methodNames and methods based on discovered methods
        string[] methodNames = solutionMethods.Select(m => m.Name).ToArray();
        SolutionMethod[] methods = solutionMethods.Select(m => (SolutionMethod)Delegate.CreateDelegate(typeof(SolutionMethod), m)).ToArray();

        // Helper function to run a test case with all methods
        void RunTestCase(int testNumber, string testName, int[] input, int[] expected)
        {
            Console.WriteLine($"Test {testNumber} - {testName}:");
            
            foreach (var (method, index) in methods.Select((m, i) => (m, i)))
            {
                Stopwatch methodStopwatch = Stopwatch.StartNew();
                try
                {
                    var result = method(input);
                    methodStopwatch.Stop();
                    bool isCorrect = result != null && result.Length == expected.Length && 
                                     result.Zip(expected, (r, e) => r == e).All(x => x);
                    
                    Console.WriteLine($"  {methodNames[index]}: " + 
                                     (isCorrect ? "PASSED" : "FAILED") + 
                                     $" [{methodStopwatch.ElapsedMilliseconds} ms]");
                    Console.WriteLine($"    Result: {string.Join(",", result.Take(Math.Min(5, result.Length)))}{(result.Length > 5 ? "..." : "")}");
                }
                catch (Exception ex)
                {
                    methodStopwatch.Stop();
                    Console.WriteLine($"  {methodNames[index]}: FAILED (Error) [{methodStopwatch.ElapsedMilliseconds} ms]");
                    Console.WriteLine($"    Error: {ex.Message}");
                }
            }
            Console.WriteLine();
        }

        // Test case 1
        var input1 = new int[] { 1, 2, 3, 4 };
        var expected1 = new int[] { 24, 12, 8, 6 };
        RunTestCase(1, "Small array", input1, expected1);

        // Test case 2
        var input2 = new int[] { 1, -1 };
        var expected2 = new int[] { -1, 1 };
        RunTestCase(2, "Negative values", input2, expected2);

        // Test case 3
        var input3 = new int[] { -1, 1, 0, -3, 3 };
        var expected3 = new int[] { 0, 0, 9, 0, 0 };
        RunTestCase(3, "With zeros", input3, expected3);

        // Test case 4 - Empty array
        var input4 = Array.Empty<int>();
        var expected4 = Array.Empty<int>();
        RunTestCase(4, "Empty array", input4, expected4);

        // Test case 5 - All ones
        var input5 = new int[] { 1, 1, 1, 1, 1 };
        var expected5 = new int[] { 1, 1, 1, 1, 1 };
        RunTestCase(5, "All ones", input5, expected5);

        // Test case 6 - Larger array for performance testing
        var input6 = Enumerable.Range(1, 20).ToArray();
        // Calculate expected result for larger array
        var expected6 = new int[input6.Length];
        long product = 1;
        foreach (var num in input6) product *= num;
        for (int i = 0; i < input6.Length; i++) {
            expected6[i] = (int)(product / input6[i]);
        }
        RunTestCase(6, "Large array (1-20)", input6, expected6);

        // Test case 7 - Array with multiple zeros
        var input7 = new int[] { 0, 0, 0, 4, 0 };
        var expected7 = new int[] { 0, 0, 0, 0, 0 };
        RunTestCase(7, "Multiple zeros", input7, expected7);

        totalStopwatch.Stop();
        Console.WriteLine("-------------------------------------------");
        Console.WriteLine($"Total execution time: {totalStopwatch.ElapsedMilliseconds} ms");
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}