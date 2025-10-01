using System.Diagnostics;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Console.WriteLine("Longest Consecutive Sequence Problem");

// Test Scenarios
int[] nums1 = [100, 4, 200, 1, 3, 2];
int expected1 = 4;

int[] nums2 = [0, 3, 7, 2, 5, 8, 4, 6, 0, 1];
int expected2 = 9;

int[] nums3 = [1, 0, 1, 2];
int expected3 = 3;

int[] nums4 = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
int expected4 = 10;

int[] nums5 = [];
int expected5 = 0;

// Solution Instance
Solution solution = new();

// Method to Run and Measure
void RunAndMeasure(string scenarioName, Func<int[], int> method, int[] input, int expected)
{
    Stopwatch stopwatch = Stopwatch.StartNew();
    int result = method(input);
    stopwatch.Stop();

    Console.WriteLine($"Scenario: {scenarioName}");
    Console.WriteLine($"Execution Time: {stopwatch.ElapsedTicks} ticks");
    Console.WriteLine($"Result: {result}");
    Console.WriteLine($"Expected: {expected}");
    Console.WriteLine($"Test Passed: {result == expected}");
    Console.WriteLine();
}

// Run Scenarios
RunAndMeasure("Example 1", solution.LongestConsecutive, nums1, expected1);
RunAndMeasure("Example 2", solution.LongestConsecutive, nums2, expected2);
RunAndMeasure("Example 3", solution.LongestConsecutive, nums3, expected3);
RunAndMeasure("Example 4", solution.LongestConsecutive, nums4, expected4);
RunAndMeasure("Example 5", solution.LongestConsecutive, nums5, expected5);
