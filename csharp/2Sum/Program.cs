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

using System;
using System.Collections.Generic;
using System.Text.Json;

namespace _2Sum;

class Program
{
    private static void Main(string[] args)
    {
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
            ExecuteTwoSumBenchmark(input.Key, input.Value);
            //new line
            Console.WriteLine();
        }
    }

    private static void ExecuteTwoSumBenchmark(int target, int[] arr)
    {
        var funcTwoSum = (int[] arr, int target) =>
        {
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            var result = TwoSum(arr, target);
            stopwatch.Stop();
            Console.WriteLine($@"{nameof(TwoSum)}	{stopwatch.ElapsedTicks} ticks");
            return result;
        };

        var funcTwoSumMemoized = (int[] arr, int target) =>
        {
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            var result = TwoSumMemoized(arr, target);
            stopwatch.Stop();
            Console.WriteLine($@"{nameof(TwoSumMemoized)}	{stopwatch.ElapsedTicks} ticks");
            return result;
        };

        var funcTwoSumBinarySearch = (int[] arr, int target) =>
        {
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            var result = TwoSumBinarySearch(arr, target);
            stopwatch.Stop();
            Console.WriteLine($@"{nameof(TwoSumBinarySearch)}	{stopwatch.ElapsedTicks} ticks");
            return result;
        };

        Console.WriteLine($@"{nameof(TwoSum)}	{JsonSerializer.Serialize(funcTwoSum(arr, target))}");
        Console.WriteLine($@"{nameof(TwoSumMemoized)}	{JsonSerializer.Serialize(funcTwoSumMemoized(arr, target))}");
        Console.WriteLine($@"{nameof(TwoSumBinarySearch)}	{JsonSerializer.Serialize(funcTwoSumBinarySearch(arr, target))}");
    }

    /***
     * Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
     * You may assume that each input would have exactly one solution, and you may not use the same element twice.
     * You can return the answer in any order.
     * 
     * Example 1: Input: nums = [2,7,11,15], target = 9 Output: [0,1] Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].
     **/

    // speed: O(n log n) space: O(log n) 
    private static int[] TwoSum(int[] arr, int target)
    {
        int left = 0, right = arr.Length - 1;

        Array.Sort(arr);

        while (left < right)
        {
            var leftValue = arr[left];
            var rightValue = arr[right];

            if (leftValue + rightValue > target)
            {
                right--;
            }
            else if (leftValue + rightValue < target)
            {
                left++;
            }
            else
            {
                return [left, right];
            }
        }

        throw new ArgumentOutOfRangeException("Input must have exactly one solution");
    }

    // speed: O(n) space: O(n)
    private static int[] TwoSumMemoized(int[] arr, int target)
    {
        var lookUp = new Dictionary<int, int>();

        for (int i = 0; i < arr.Length; i++)
        {
            lookUp[arr[i]] = i;
        }

        for (int i = 0; i < arr.Length; i++)
        {
            int requiredNum = target - arr[i];

            if (lookUp.TryGetValue(requiredNum, out int value) && i != value)
            {
                return [i, value];
            }
        }

        throw new ArgumentOutOfRangeException("Input must have exactly one solution");
    }

    // speed: O(n log n) space: O(log n))        
    private static int[] TwoSumBinarySearch(int[] nums, int target)
    {
        var sorted = new List<int>(nums);
        sorted.Sort();

        for (int i = 0; i < nums.Length; i++)
        {
            var delta = target - nums[i];
            var deltaIndex = sorted.BinarySearch(delta);

            if (deltaIndex >= 0)
            {
                int j = Array.IndexOf(nums, delta);
                if (j != i)
                {
                    return [i, j];
                }
            }
        }

        throw new InvalidOperationException("No two sum solution");
    }
}