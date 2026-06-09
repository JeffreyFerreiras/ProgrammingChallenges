using System;
using System.Collections.Generic;

namespace _2Sum;

public class Solution
{
    public int[] TwoSum(int[] arr, int target)
    {
        int left = 0;
        int right = arr.Length - 1;

        Array.Sort(arr);

        while (left < right)
        {
            int leftValue = arr[left];
            int rightValue = arr[right];

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

        throw new ArgumentOutOfRangeException(nameof(target), "Input must have exactly one solution");
    }

    public int[] TwoSumMemoized(int[] arr, int target)
    {
        var lookup = new Dictionary<int, int>();

        for (int i = 0; i < arr.Length; i++)
        {
            lookup[arr[i]] = i;
        }

        for (int i = 0; i < arr.Length; i++)
        {
            int requiredNumber = target - arr[i];

            if (lookup.TryGetValue(requiredNumber, out int matchIndex) && i != matchIndex)
            {
                return [i, matchIndex];
            }
        }

        throw new ArgumentOutOfRangeException(nameof(target), "Input must have exactly one solution");
    }

    public int[] TwoSumBinarySearch(int[] nums, int target)
    {
        var sorted = new List<int>(nums);
        sorted.Sort();

        for (int i = 0; i < nums.Length; i++)
        {
            int delta = target - nums[i];
            int deltaIndex = sorted.BinarySearch(delta);

            if (deltaIndex >= 0)
            {
                int matchIndex = Array.IndexOf(nums, delta);
                if (matchIndex != i)
                {
                    return [i, matchIndex];
                }
            }
        }

        throw new InvalidOperationException("No two sum solution");
    }
}