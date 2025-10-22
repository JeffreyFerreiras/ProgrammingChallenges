using System;
using System.Collections.Generic;

namespace SlidingWindowMaximum;

public class Solution
{
    public int[] MaxSlidingWindow(int[] nums, int windowSize)
    {
        // Initialize left and right pointers for the sliding window
        int left = 0,
            right = 0;

        // Create result array to store maximum of each window
        // Size = total elements - window size + 1
        int[] result = new int[nums.Length - windowSize + 1];

        // Deque stores indices of array elements in decreasing order of their values
        // The front of deque always contains the index of the maximum element in current window
        LinkedList<int> deque = new();

        // Expand the window by moving right pointer
        while (right < nums.Length)
        {
            // Remove indices from back of deque while current element is larger
            // This maintains decreasing order in deque (largest to smallest)
            while (deque.Count > 0 && deque.Last != null && nums[right] > nums[deque.Last.Value])
            {
                deque.RemoveLast();
            }

            // Add current element's index to back of deque
            deque.AddLast(right);

            // Remove indices that are outside the current window
            // If the front index is before the left boundary, remove it
            if (deque.First != null && left > deque.First.Value)
            {
                deque.RemoveFirst();
            }

            // When window reaches desired size, record the maximum and slide window
            if (right + 1 >= windowSize)
            {
                // The front of deque contains index of maximum element in current window
                // We know deque.First is not null because we just added an element
                result[left] = nums[deque.First!.Value];

                // Move left pointer to slide the window forward
                left++;
            }

            // Always move right pointer to expand/slide the window
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
            left++;
            right++; // Slide the window
        }

        return [.. result];
    }
}
