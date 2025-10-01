using System.Diagnostics;

namespace TopKFrequentElements
{
    class Program
    {
        /*
         * 347. Top K Frequent Elements
         * 
         * Given an integer array nums and an integer k, return the k most frequent elements. 
         * You may return the answer in any order.
         * 
         * Example 1:
         * Input: nums = [1,1,1,2,2,3], k = 2
         * Output: [1,2]
         * 
         * Example 2:
         * Input: nums = [1], k = 1
         * Output: [1]
         * 
         * Constraints:
         * 1 <= nums.length <= 10^5
         * -10^4 <= nums[i] <= 10^4
         * k is in the range [1, the number of unique elements in the array].
         * It is guaranteed that the answer is unique.
         * 
         * Follow up: Your algorithm's time complexity must be better than O(n log n), where n is the array's size.
         */

        static void Main(string[] args)
        {
            Console.WriteLine("347. Top K Frequent Elements");
            Console.WriteLine("============================");

            // Test cases
            RunTest([1, 1, 1, 2, 2, 3], 2, [1, 2]);
            RunTest([1], 1, [1]);
            RunTest([4, 1, 1, 1, 2, 2, 3, 4, 4, 4, 4], 2, [4, 1]);

            Console.ReadLine();
        }

        static void RunTest(int[] nums, int k, int[] expected)
        {
            Console.WriteLine($"Input: nums = [{string.Join(",", nums)}], k = {k}");
            Console.WriteLine($"Expected: [{string.Join(",", expected)}]");

            Solution solution = new();

            Stopwatch stopwatch = new();
            stopwatch.Start();
            int[] result = solution.TopKFrequent(nums, k);
            stopwatch.Stop();

            Console.WriteLine($"Method: TopKFrequent");
            Console.WriteLine($"Time: {stopwatch.ElapsedTicks} ticks");
            Console.WriteLine($"Result: `[{string.Join(",", result)}]`");
            Console.WriteLine($"Expected: `[{string.Join(",", expected)}]`");
            Console.WriteLine();
        }
    }
}
