/*
 * MinimumSwaps Program
 * 
 * This program calculates the minimum number of swaps required to group all 1's together
 * in a binary array. The input is a sequence of 0s and 1s separated by spaces.
 * 
 * Examples:
 * 1. Simple case:
 *    Input:  1 0 1 0 1
 *    Output: 1 (result: 1 1 1 0 0)
 * 
 * 2. Already grouped:
 *    Input:  1 1 1 0 0
 *    Output: 0 (no swaps needed)
 * 
 * 3. Worst case:
 *    Input:  1 0 1 0 1 0
 *    Output: 2 (result: 1 1 1 0 0 0)
 * 
 * 4. All zeros or ones:
 *    Input:  0 0 0 0
 *    Output: 0 (no swaps needed)
 *    Input:  1 1 1 1
 *    Output: 0 (no swaps needed)
 */

using System;

namespace MinimumSwaps
{
    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();
            var stopwatch = new System.Diagnostics.Stopwatch();

            // Test scenarios
            var testCases = new[]
            {
                new { Name = "Sample 1", Input = new[] { 1, 0, 1, 0, 1 }, Expected = 1 },
                new { Name = "Sample 2", Input = new[] { 0, 0, 0, 1, 0 }, Expected = 0 },
                new { Name = "Sample 3", Input = new[] { 1, 0, 1, 0, 1, 0, 0, 1, 1, 0, 1 }, Expected = 3 },
                new { Name = "Already grouped", Input = new[] { 1, 1, 1, 0, 0 }, Expected = 0 },
                new { Name = "All zeros", Input = new[] { 0, 0, 0, 0 }, Expected = 0 },
                new { Name = "All ones", Input = new[] { 1, 1, 1, 1 }, Expected = 0 }
            };

            Console.WriteLine("Running test scenarios...\n");

            foreach (var test in testCases)
            {
                stopwatch.Restart();
                var result = solution.MinSwaps(test.Input);
                stopwatch.Stop();

                Console.WriteLine($"Test: {test.Name}");
                Console.WriteLine($"Input: {string.Join(" ", test.Input)}");
                Console.WriteLine($"Expected: {test.Expected} ✓");
                Console.WriteLine($"Result: {result} {(result == test.Expected ? "✓" : "✗")}");
                Console.WriteLine($"Time: {stopwatch.ElapsedTicks:N0} ticks ({stopwatch.ElapsedMilliseconds}ms)");
                Console.WriteLine(new string('-', 50) + "\n");
            }

            // Interactive mode
            Console.WriteLine("\nEnter your own test case:");
            Console.WriteLine("Enter the binary array (0s and 1s) separated by spaces:");
            string input = Console.ReadLine();
            int[] binaryArray = Array.ConvertAll(input.Split(' '), int.Parse);

            stopwatch.Restart();
            int minimumSwaps = solution.MinSwaps(binaryArray);
            stopwatch.Stop();

            Console.WriteLine($"\nResult: {minimumSwaps}");
            Console.WriteLine($"Time: {stopwatch.ElapsedTicks:N0} ticks ({stopwatch.ElapsedMilliseconds}ms)");
        }
    }
}