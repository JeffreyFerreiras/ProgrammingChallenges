using System;

namespace KthLargestElement
{
    /*
     * This class finds the kth largest element in an unsorted array.
     * It demonstrates two approaches:
     * 1. Using QuickSelect for O(n) average time complexity.
     * 2. A simple sort-based approach with O(n log n) time complexity.
     */
    class Program
    {
        static void Main(string[] args)
        {
            // Test case 1: Should output 5
            var testArray1 = new int[] { 3, 2, 1, 5, 6, 4 };
            int k1 = 2;
            Console.WriteLine($"Test 1: {FindKthLargest(testArray1, k1)} (expected: 5)");

            // Test case 2: Should output 4
            var testArray2 = new int[] { 3, 2, 3, 1, 2, 4, 5, 5, 6 };
            int k2 = 4;
            Console.WriteLine($"Test 2: {FindKthLargest(testArray2, k2)} (expected: 4)");
            
            // Test case 3: Edge case - k=1, should return the largest element
            var testArray3 = new int[] { 3, 2, 1, 5, 6, 4 };
            int k3 = 1;
            Console.WriteLine($"Test 3: {FindKthLargest(testArray3, k3)} (expected: 6)");
            
            // Test case 4: Edge case - k=array.length, should return the smallest element
            var testArray4 = new int[] { 3, 2, 1, 5, 6, 4 };
            int k4 = testArray4.Length;
            Console.WriteLine($"Test 4: {FindKthLargest(testArray4, k4)} (expected: 1)");
            
            // Test case 5: Array with many duplicates
            var testArray5 = new int[] { 5, 5, 5, 5, 5 };
            int k5 = 1;
            Console.WriteLine($"Test 5: {FindKthLargest(testArray5, k5)} (expected: 5)");
            
            // Test case 6: Single element array
            var testArray6 = new int[] { 42 };
            int k6 = 1;
            Console.WriteLine($"Test 6: {FindKthLargest(testArray6, k6)} (expected: 42)");
            
            // Test case 7: Negative numbers
            var testArray7 = new int[] { -1, -2, -3, -4, -5 };
            int k7 = 2;
            Console.WriteLine($"Test 7: {FindKthLargest(testArray7, k7)} (expected: -2)");
        }

        public static int FindKthLargest(int[] nums, int k)
        {
            //return FindKthLargestPriorityQueue(nums, k);
            return FindKthLargestBySort(nums, k);
        }

        // n log (k)
        public static int FindKthLargestPriorityQueue(int[] nums, int k)
        {
            var priorityQueue = new PriorityQueue<int, int>();

            for (var i = 0; i < nums.Length; i++)
            {
                priorityQueue.Enqueue(nums[i], nums[i]);

                if (priorityQueue.Count > k)
                {
                    priorityQueue.Dequeue();
                }
            }

            return priorityQueue.Peek();
        }

        // Finds the kth largest element using the QuickSelect algorithm.
        // Converts kth largest to finding the (n-k)th smallest element.
        public static int FindKthLargestQuickSelect(int[] numbers, int k)
        {
            // Convert kth largest to target index for kth smallest.
            int targetIndex = numbers.Length - k;
            // Use QuickSelect to find the kth smallest element.
            return QuickSelect(numbers, 0, numbers.Length - 1, targetIndex);
        }

        // QuickSelect recursively selects a pivot and partitions the array.
        // It continues the search on one side of the pivot until the target element is found.
        private static int QuickSelect(int[] numbers, int startIndex, int endIndex, int targetIndex)
        {
            // If the list contains only one element, return it.
            if (startIndex == endIndex) return numbers[startIndex];

            // Partition returns the final index of the pivot.
            int pivotFinalIndex = Partition(numbers, startIndex, endIndex);

            // If the pivot is at the target index, we found our kth smallest (or kth largest) element.
            if (targetIndex == pivotFinalIndex)
                return numbers[targetIndex];
            // If the target is in the left sub-array, search there.
            else if (targetIndex < pivotFinalIndex)
                return QuickSelect(numbers, startIndex, pivotFinalIndex - 1, targetIndex);
            // Otherwise, search in the right sub-array.
            else
                return QuickSelect(numbers, pivotFinalIndex + 1, endIndex, targetIndex);
        }

        // Partition reorders the array by placing values less than or equal to the pivot to its left,
        // and values greater than the pivot to its right.
        private static int Partition(int[] numbers, int start, int end)
        {
            // Choose the rightmost element as the pivot.
            int pivotValue = numbers[end];
            // Index at which to store the next element that is less than or equal to pivot.
            int storeIndex = start;

            // Compare each element with the pivot.
            for (int j = start; j < end; j++)
            {
                // If the current element is less than or equal to the pivot, swap it.
                if (numbers[j] <= pivotValue)
                {
                    SwapElements(numbers, storeIndex, j);
                    storeIndex++;
                }
            }

            // Place the pivot element in its correct sorted position.
            SwapElements(numbers, storeIndex, end);
            return storeIndex;
        }

        // SwapElements exchanges the values of two elements in the array.
        private static void SwapElements(int[] numbers, int index1, int index2)
        {
            int temp = numbers[index1];
            numbers[index1] = numbers[index2];
            numbers[index2] = temp;
        }

        // n log (n)
        // A simple solution using sorting.
        // It sorts the array and then returns the kth largest element.
        public static int FindKthLargestBySort(int[] numbers, int k)
        {
            Array.Sort(numbers);
            return numbers[numbers.Length - k];
        }

        // A solution using a stack to keep track of the k largest elements.
        // It iterates through the array and maintains a stack of the k largest elements.
        public int FindKthLargestStack(int[] nums, int k)
        {
            //declare ranks
            var ranks = new Stack<int>();

            // loop through nums
            for (int i = 0; i < nums.Length; i++)
            {
                int current = nums[i];

                //for each num, find rank
                if (ranks.Count > 0)
                {
                    var temp = new Stack<int>();

                    while (ranks.Count > 0 && current > ranks.Peek())
                    {
                        temp.Push(ranks.Pop());
                    }

                    if (ranks.Count < k)
                    {
                        ranks.Push(current);
                    }

                    while (temp.Count > 0 && ranks.Count < k)
                    {
                        ranks.Push(temp.Pop());
                    }
                }
                else
                {
                    ranks.Push(current);
                }
            }

            //return kth item which is the lowest rank.
            return ranks.Peek();
        }
    }
}
