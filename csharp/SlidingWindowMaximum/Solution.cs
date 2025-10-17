using System;
using System.Collections.Generic;

namespace SlidingWindowMaximum;

public class Solution
{
    public int[] MaxSlidingWindow(int[] nums, int windowSize)
    {
        int left = 0, right = 0;
        int[] result = new int[nums.Length - windowSize + 1];
        LinkedList<int> deque = new();

        while (right < nums.Length)
        {
            while (deque.Count > 0 && nums[right] > nums[deque.Last.Value])
            {
                deque.RemoveLast();
            }

            deque.AddLast(right);

            if (left > deque.First.Value)
            {
                deque.RemoveFirst();
            }

            if (right + 1 >= windowSize)
            {
                result[left] = nums[deque.First.Value];
                left++;
            }

            right++;
        }

        return result;
    }

    public int[] MaxSlidingWindow_Original(int[] nums, int windowSize)
    {
        int left = 0,
            right = windowSize - 1,
            prevMaxIndex = -1;
        List<int> result = new(nums.Length - windowSize + 1);

        while (right < nums.Length)
        {
            if (left > prevMaxIndex || prevMaxIndex == -1)
            {
                int maxVal = int.MinValue;
                for (int i = left; i <= right; i++)
                {
                    if (nums[i] >= maxVal)
                    {
                        maxVal = nums[i];
                        prevMaxIndex = i;
                    }
                }
            }
            else if (prevMaxIndex >= left && nums[prevMaxIndex] < nums[right])
            {
                prevMaxIndex = right;
            }

            result.Add(nums[prevMaxIndex]);
            left++; right++; // Slide the window
        }

        return [.. result];
    }
}
