namespace MaximumSubarray
{
    /*
         *
Given an integer array nums, find the contiguous subarray (containing at least one number) which has the largest sum and return its sum.

A subarray is a contiguous part of an array.

 

Example 1:

Input: nums = [-2,1,-3,4,-1,2,1,-5,4]
Output: 6
Explanation: [4,-1,2,1] has the largest sum = 6.
Example 2:

Input: nums = [1]
Output: 1
Example 3:

Input: nums = [5,4,-1,7,8]
Output: 23
 

Constraints:

1 <= nums.length <= 105
-104 <= nums[i] <= 104
 

Follow up: If you have figured out the O(n) solution, try coding another solution using the divide and conquer approach, which is more subtle.
         *
         */

    internal class Program
    {
        static void Main(string[] args)
        {
            // create test data
            //[-2,1,-3,4,-1,2,1,-5,4]
            var nums = new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            var expected = 6;

            var result = Solution.MaxSubArray(nums);

            Console.WriteLine($"result: {result} expected: {expected}");

            //[1]
            nums = [1];
            expected = 1;
            result = Solution.MaxSubArray(nums);
            Console.WriteLine($"result: {result} expected: {expected}");
        }

    }

    public class Solution
    {
        public static int MaxSubArray(int[] nums)
        {
            int sum = 0;
            int maxSum = nums[0];

            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                if (nums[i] > sum)
                {
                    sum = nums[i];
                }
                if (sum > maxSum)
                {
                    maxSum = sum;
                }
            }
            return maxSum;
        }

        public static int MaxSubArray_Jeffrey(int[] nums)
        {
            //[-2,1,-3,4,-1,2,1,-5,4]
            int maxSum = int.MinValue;
            int sum = 0;
            int start = 0;
            int end = nums.Length - 1;
            int offset = nums.Length - 1;

            while(offset >= 0)
            {
                while (end < nums.Length)
                {
                    sum = MaxSubArraySum(nums, start, end);

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                    }

                    start++;
                    end = start + offset;
                }

                start = 0;
                offset--;
                end = start + offset;
            }
            

            return maxSum;
        }

        public static int MaxSubArray_Brute(int[] nums)
        {
            int maxSum = int.MinValue;
            int currentSum;

            for (int i = 0; i < nums.Length; i++)
            {
                int end = nums.Length - 1;

                while (end >= i)
                {
                    currentSum = MaxSubArraySum(nums, i, end);

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                    }

                    end--;
                }
            }


            return maxSum;
        }

        private static int MaxSubArraySum(int[] nums, int start, int end)
        {
            int currentSum = 0;

            while (start <= end)
            {
                currentSum += nums[start];

                start++;
            }

            return currentSum;
        }
    }
}