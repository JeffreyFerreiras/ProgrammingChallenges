/*
1. Two Sum
Easy
Topics
Companies
Hint
Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
You may assume that each input would have exactly one solution, and you may not use the same element twice.
You can return the answer in any order.

Example 1:

Input: nums = [2,7,11,15], target = 9
Output: [0,1]
Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].
Example 2:

Input: nums = [3,2,4], target = 6
Output: [1,2]
Example 3:

Input: nums = [3,3], target = 6
Output: [0,1]
 

Constraints:

2 <= nums.length <= 104
-109 <= nums[i] <= 109
-109 <= target <= 109
Only one valid answer exists.
*/

using System.Text.Json;

namespace _2Sum;

class Program
{
    private static void Main(string[] args)
    {
        var solution = new Solution();
        var inputs = new List<KeyValuePair<int, int[]>>
        {
            new(9, [2, 7, 11, 15]),
            new(6, [3, 2, 4]),
            new(6, [3, 3])
        };

        foreach (var input in inputs)
        {
            //print the input
            Console.WriteLine($@"{nameof(input)}	{JsonSerializer.Serialize(input)}");
            ExecuteTwoSumBenchmark(solution, input.Key, input.Value);
            //new line
            Console.WriteLine();
        }
    }

    private static void ExecuteTwoSumBenchmark(Solution solution, int target, int[] arr)
    {
        var funcTwoSum = (int[] arr, int target) =>
        {
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            var result = solution.TwoSum(arr, target);
            stopwatch.Stop();
            Console.WriteLine($@"{nameof(Solution.TwoSum)}	{stopwatch.ElapsedTicks} ticks");
            return result;
        };

        var funcTwoSumMemoized = (int[] arr, int target) =>
        {
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            var result = solution.TwoSumMemoized(arr, target);
            stopwatch.Stop();
            Console.WriteLine($@"{nameof(Solution.TwoSumMemoized)}	{stopwatch.ElapsedTicks} ticks");
            return result;
        };

        var funcTwoSumBinarySearch = (int[] arr, int target) =>
        {
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            var result = solution.TwoSumBinarySearch(arr, target);
            stopwatch.Stop();
            Console.WriteLine($@"{nameof(Solution.TwoSumBinarySearch)}	{stopwatch.ElapsedTicks} ticks");
            return result;
        };

        Console.WriteLine($@"{nameof(Solution.TwoSum)}	{JsonSerializer.Serialize(funcTwoSum(arr, target))}");
        Console.WriteLine($@"{nameof(Solution.TwoSumMemoized)}	{JsonSerializer.Serialize(funcTwoSumMemoized(arr, target))}");
        Console.WriteLine($@"{nameof(Solution.TwoSumBinarySearch)}	{JsonSerializer.Serialize(funcTwoSumBinarySearch(arr, target))}");
    }
}