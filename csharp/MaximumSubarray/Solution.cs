namespace MaximumSubarray
{
    public class Solution
    {
        public int MaxSubArray(int[] nums)
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

        public int MaxSubArray_Jeffrey(int[] nums)
        {
            int maxSum = int.MinValue;
            int sum = 0;
            int start = 0;
            int end = nums.Length - 1;
            int offset = nums.Length - 1;

            while (offset >= 0)
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

        public int MaxSubArray_Brute(int[] nums)
        {
            int maxSum = int.MinValue;

            for (int i = 0; i < nums.Length; i++)
            {
                int end = nums.Length - 1;

                while (end >= i)
                {
                    int currentSum = MaxSubArraySum(nums, i, end);

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