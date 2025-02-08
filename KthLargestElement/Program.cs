using System;

namespace KthLargestElement
{
    /*
     * Find the kth largest element in an unsorted array. 
     * Note that it is the kth largest element in the sorted order, 
     * not the kth distinct element.
     * 
     * Example 1:
     * Input: [3,2,1,5,6,4] and k = 2
     * Output: 5
     * 
     * Example 2:
     * Input: [3,2,3,1,2,4,5,5,6] and k = 4
     * Output: 4
     * 
     * Constraints:
     * 1 <= k <= array length
     * -104 <= array[i] <= 104
     */
    class Program
    {
        static void Main(string[] args)
        {
            var test1 = new int[] { 3, 2, 1, 5, 6, 4 };
            var k1 = 2;
            Console.WriteLine($"Test 1: {FindKthLargest(test1, k1)} (expected: 5)");

            var test2 = new int[] { 3, 2, 3, 1, 2, 4, 5, 5, 6 };
            var k2 = 4;
            Console.WriteLine($"Test 2: {FindKthLargest(test2, k2)} (expected: 4)");
        }

        public static int FindKthLargest(int[] nums, int k)
        {
            // Using QuickSelect algorithm for O(n) average time complexity
            return QuickSelect(nums, 0, nums.Length - 1, nums.Length - k);
        }

        private static int QuickSelect(int[] nums, int left, int right, int k)
        {
            if (left == right) return nums[left];

            int pivotIndex = Partition(nums, left, right);

            if (k == pivotIndex)
                return nums[k];
            else if (k < pivotIndex)
                return QuickSelect(nums, left, pivotIndex - 1, k);
            else
                return QuickSelect(nums, pivotIndex + 1, right, k);
        }

        private static int Partition(int[] nums, int left, int right)
        {
            int pivot = nums[right];
            int i = left;

            for (int j = left; j < right; j++)
            {
                if (nums[j] <= pivot)
                {
                    Swap(nums, i, j);
                    i++;
                }
            }

            Swap(nums, i, right);
            return i;
        }

        private static void Swap(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }

        // Simple solution using sorting - O(n log n)
        public static int FindKthLargestSimple(int[] nums, int k)
        {
            Array.Sort(nums);
            return nums[nums.Length - k];
        }
    }
}
