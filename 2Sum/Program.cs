using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace _2Sum
{
    class Program
    {
        private static void Main(string[] args)
        {
            var input = "[2,7,11,15]";
            int[] arr = ParseLeetCodeInput(input);
            int target = 9;

            Console.WriteLine(input);
            Console.WriteLine($@"{nameof(TwoSum)}	{JsonSerializer.Serialize(TwoSum(arr, target))}");
            Console.WriteLine($@"{nameof(TwoSumMemoized)}	{JsonSerializer.Serialize(TwoSumMemoized(arr, target))}");
            Console.WriteLine($@"{nameof(TwoSumPractice)}	{JsonSerializer.Serialize(TwoSumPractice(arr, target))}");
        }

        static int[] ParseLeetCodeInput(string testData)
        {
            return testData.Trim('[').Trim(']').Split(',').Select(x => int.Parse(x)).ToArray();
        }

        /**
         * Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
         * You may assume that each input would have exactly one solution, and you may not use the same element twice.
         * You can return the answer in any order.
         */

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
                    return new int[] { left, right };
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
                lookUp.Add(arr[i], i);
            }

            for (int i = 0; i < arr.Length; i++)
            {
                int requiredNum = target - arr[i];

                if (lookUp.ContainsKey(requiredNum) && i != lookUp[requiredNum])
                {
                    return new int[] { lookUp[requiredNum], i };
                }
            }

            throw new ArgumentOutOfRangeException("Input must have exactly one solution");
        }

        // speed: O(n^2) space: O(1)
        private static int[] TwoSumPractice(int[] arr, int target)
        {
            var dict = new Dictionary<int, int>();
            for(int i=0; i<arr.Length;i++){
                int diff = target - arr[i];
                
                if(dict.ContainsKey(diff)){
                    return new int[]{i,dict[diff]};
                }
                
                dict[arr[i]] = i;
            }

            return new int[]{-1,-1};
        }
    }
}