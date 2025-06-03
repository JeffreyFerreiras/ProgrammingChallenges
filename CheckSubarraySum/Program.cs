namespace CheckSubarraySum
{
    /// <summary>
    /// LeetCode Problem: Check Subarray Sum
    /// 
    /// Given an integer array nums and an integer k, return true if nums has a continuous subarray of size at least two 
    /// whose elements sum up to a multiple of k, or false otherwise.
    /// 
    /// An integer x is a multiple of k if there exists an integer n such that x = n * k. 0 is always a multiple of k.
    /// 
    /// Examples:
    /// Example 1:
    /// Input: nums = [23, 2, 4, 6, 7], k = 6
    /// Output: true
    /// Explanation: [2, 4] is a continuous subarray of size 2 and sums up to 6.
    ///
    /// Example 2:
    /// Input: nums = [23, 2, 6, 4, 7], k = 6
    /// Output: true
    /// Explanation: [23, 2, 6, 4, 7] is a continuous subarray of size 5 and sums up to 42, which is a multiple of 6.
    ///
    /// Example 3:
    /// Input: nums = [23, 2, 6, 4, 7], k = 13
    /// Output: false
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Check Subarray Sum Problem");

            Solution solution = new();

            int[] nums1 = [23, 2, 4, 6, 7];
            int k1 = 6;
            var watch1 = System.Diagnostics.Stopwatch.StartNew();
            bool result1 = solution.CheckSubarraySum(nums1, k1);
            watch1.Stop();
            Console.WriteLine($"Example 1: {result1} (Expected: true) - Time: {watch1.ElapsedTicks} ticks");

            int[] nums2 = [23, 2, 6, 4, 7];
            int k2 = 6;
            var watch2 = System.Diagnostics.Stopwatch.StartNew();
            bool result2 = solution.CheckSubarraySum(nums2, k2);
            watch2.Stop();
            Console.WriteLine($"Example 2: {result2} (Expected: true) - Time: {watch2.ElapsedTicks} ticks");

            int[] nums3 = [23, 2, 6, 4, 7];
            int k3 = 13;
            var watch3 = System.Diagnostics.Stopwatch.StartNew();
            bool result3 = solution.CheckSubarraySum(nums3, k3);
            watch3.Stop();
            Console.WriteLine($"Example 3: {result3} (Expected: false) - Time: {watch3.ElapsedTicks} ticks");
        }
    }
}

public class Solution
{
    public bool CheckSubarraySum(int[] nums, int k)
    {
        var sumsSet = new HashSet<int>(nums.Length);
        int sum = 0, prevSum;

        for (int i = 0; i < nums.Length; i++)
        {
            prevSum = sum;
            sum = (sum + nums[i]) % k;
            if (sumsSet.Contains(sum))
            {
                return true;
            }
            sumsSet.Add(prevSum);
        }

        return false;
    }

    public bool CheckSubarraySum2(int[] nums, int k)
    {
        Dictionary<int, int> remainderDict = new()
        {
            [0] = -1
        };
        int runningSum = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            runningSum += nums[i];
            int remainder = k == 0 ? runningSum : runningSum % k;

            if (remainderDict.ContainsKey(remainder))
            {
                if (i - remainderDict[remainder] > 1)
                {
                    return true;
                }
            }
            else
            {
                remainderDict[remainder] = i;
            }
        }

        return false;
    }
}
