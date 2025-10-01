using System;
using System.Diagnostics; // Import Stopwatch

namespace FindElementInSortedRotatedArray
{
    class Program
    {
        /*
        1) Given a rotated sorted array, find the first occurrence of a certain number X with the lowest possible complexity(both time and space).
        */

        /*
        Notes: Algorithm -

        1) Create a method and prep for a recursive bin search.
        2) Check if the array[mid] point is equal to the target, if it is, return the mid point.
        3) Error Check: that left is not bigger than right...We're doing recursion here! mmmkay.
        4) Check if the left side is ordered
            a) if target is between left and mid, recur left to mid-1.
            b) else recur mid+1 to right
        5) Check if the right side is ordered, if it is
            a) if target is between mid+1 to right, recur mid +1 to right.
            b) else recur left to mid-1;
        6) Check if left equals mid of arrary values.
            a) if mid does not equal right array value, recur mid+1 to right
            b) else recur left to mid-1 and store result in an integer.
                1) if the result is -1, not found, then recur mid+1 to right.
                2) else return result.
        7) Let recursion take care of the rest.
        */

        static void Main(string[] args)
        {
            RunStandardTests();
            RunComparisonTests();
        }

        // Extracted standard tests for BinarySearchRecursive
        private static void RunStandardTests()
        {
            Stopwatch sw = Stopwatch.StartNew();

            // Test case 1
            int[] rotatedArry = [3, 4, 5, 1, 2];
            int x = 4,
                left = 0,
                right = rotatedArry.Length - 1;
            int expectedIndex = 1;
            int indexofX = BinarySearchRecursive(rotatedArry, left, right, x);
            sw.Stop();
            Console.WriteLine(
                $"Array: [{string.Join(", ", rotatedArry)}], Target: {x}, Index: {indexofX}, Expected: {expectedIndex}, Time: {sw.Elapsed.TotalMilliseconds}ms"
            );

            // Additional test cases
            int[] rotatedArry2 = [4, 5, 6, 7, 0, 1, 2];
            int x2 = 0;
            int expectedIndex2 = 4; // Expected index for x2 = 0
            sw.Restart();
            int indexofX2 = BinarySearchRecursive(rotatedArry2, 0, rotatedArry2.Length - 1, x2);
            sw.Stop();
            bool isCorrect2 = indexofX2 == expectedIndex2;
            Console.WriteLine(
                $"Array: [{string.Join(", ", rotatedArry2)}], Target: {x2}, Index: {indexofX2}, Expected: {expectedIndex2}, Time: {sw.Elapsed.TotalMilliseconds}ms, Correct: {isCorrect2}"
            );

            int[] rotatedArry3 = [1];
            int x3 = 1;
            int expectedIndex3 = 0; // Expected index for x3 = 1
            sw.Restart();
            int indexofX3 = BinarySearchRecursive(rotatedArry3, 0, rotatedArry3.Length - 1, x3);
            sw.Stop();
            bool isCorrect3 = indexofX3 == expectedIndex3;
            Console.WriteLine(
                $"Array: [{string.Join(", ", rotatedArry3)}], Target: {x3}, Index: {indexofX3}, Expected: {expectedIndex3}, Time: {sw.Elapsed.TotalMilliseconds}ms, Correct: {isCorrect3}"
            );

            int[] rotatedArry4 = [1, 3];
            int x4 = 3;
            int expectedIndex4 = 1; // Expected index for x4 = 3
            sw.Restart();
            int indexofX4 = BinarySearchRecursive(rotatedArry4, 0, rotatedArry4.Length - 1, x4);
            sw.Stop();
            bool isCorrect4 = indexofX4 == expectedIndex4;
            Console.WriteLine(
                $"Array: [{string.Join(", ", rotatedArry4)}], Target: {x4}, Index: {indexofX4}, Expected: {expectedIndex4}, Time: {sw.Elapsed.TotalMilliseconds}ms, Correct: {isCorrect4}"
            );

            int[] rotatedArry5 = [5, 1, 3];
            int x5 = 5;
            int expectedIndex5 = 0; // Expected index for x5 = 5
            sw.Restart();
            int indexofX5 = BinarySearchRecursive(rotatedArry5, 0, rotatedArry5.Length - 1, x5);
            sw.Stop();
            bool isCorrect5 = indexofX5 == expectedIndex5;
            Console.WriteLine(
                $"Array: [{string.Join(", ", rotatedArry5)}], Target: {x5}, Index: {indexofX5}, Expected: {expectedIndex5}, Time: {sw.Elapsed.TotalMilliseconds}ms, Correct: {isCorrect5}"
            );
        }

        // Extracted comparison tests for all search methods
        private static void RunComparisonTests()
        {
            Stopwatch sw = Stopwatch.StartNew();
            int[] comparisonArray = [4, 5, 6, 7, 0, 1, 2];
            int target = 0;

            // Test BinarySearchRecursive
            sw.Restart();
            int binarySearchResult = BinarySearchRecursive(
                comparisonArray,
                0,
                comparisonArray.Length - 1,
                target
            );
            sw.Stop();
            double binarySearchTime = sw.Elapsed.TotalMilliseconds;

            // Test ShiftedBinarySearch
            sw.Restart();
            int shiftedSearchResult = ShiftedBinarySearch(comparisonArray, target);
            sw.Stop();
            double shiftedSearchTime = sw.Elapsed.TotalMilliseconds;

            // Test BinarySearchFindsSortedHalf
            sw.Restart();
            int findsSortedHalfResult = BinarySearchFindsSortedHalf(comparisonArray, target);
            sw.Stop();
            double findsSortedHalfTime = sw.Elapsed.TotalMilliseconds;

            Console.WriteLine("\nComparison Test:");
            Console.WriteLine($"Array: [{string.Join(", ", comparisonArray)}], Target: {target}");
            Console.WriteLine(
                $"BinarySearch - Index: {binarySearchResult}, Time: {binarySearchTime}ms"
            );
            Console.WriteLine(
                $"ShiftedBinarySearch - Index: {shiftedSearchResult}, Time: {shiftedSearchTime}ms"
            );
            Console.WriteLine(
                $"BinarySearchFindsSortedHalf - Index: {findsSortedHalfResult}, Time: {findsSortedHalfTime}ms"
            );
            Console.WriteLine(
                $"Both BinarySearch and ShiftedBinarySearch correct: {binarySearchResult == shiftedSearchResult}"
            );
        }

        static int BinarySearchFindsSortedHalf(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
                return -1;

            int left = 0,
                right = nums.Length - 1;

            //find the index of the smallest element
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] > nums[right])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }

            int start = left;
            left = 0;
            right = nums.Length - 1;

            // if the target is in the right sorted half look there
            if (target >= nums[start] && target <= nums[right])
            {
                left = start;
            }
            else // if the target is in the left sorted half look there
            {
                right = start;
            }

            // regular binary search
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] == target)
                    return mid;
                if (nums[mid] < target)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return -1;
        }

        static int BinarySearchRecursive(int[] arry, int leftIndex, int rightIndex, int target)
        {
            //SOLUTION - Lengthy solution, but the requirement stated "lowest possible complexity(both time and space)"
            //This solution is O(log N)

            int mid = (leftIndex + rightIndex) / 2;

            if (target == arry[mid])
                return mid;
            if (rightIndex < leftIndex)
                return -1;

            if (arry[leftIndex] < arry[mid])
            {
                if (target >= arry[leftIndex] && target < arry[mid])
                    return BinarySearchRecursive(arry, leftIndex, mid - 1, target);
                else
                    return BinarySearchRecursive(arry, mid + 1, rightIndex, target);
            }
            else if (arry[leftIndex] > arry[mid])
            {
                if (target > arry[mid] && target < arry[rightIndex])
                    return BinarySearchRecursive(arry, mid + 1, rightIndex, target);
                else
                    return BinarySearchRecursive(arry, leftIndex, mid - 1, target);
            }
            else if (arry[leftIndex] == arry[mid])
            {
                if (arry[mid] != arry[rightIndex])
                    return BinarySearchRecursive(arry, mid + 1, rightIndex, target);
                else
                {
                    int result = BinarySearchRecursive(arry, leftIndex, mid - 1, target);
                    if (result == -1)
                        return BinarySearchRecursive(arry, mid + 1, rightIndex, target);
                    else
                        return result;
                }
            }
            return -1;
        }

        static int ShiftedBinarySearch(int[] nums, int target)
        {
            int n = nums.Length,
                left = 0,
                right = n - 1;

            while (left <= right) // find the index of the smallest element. It is the pivot and assigned to the left.
            {
                int mid = (left + right) / 2;

                if (nums[mid] > nums[n - 1])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return ShiftedBinarySearch(nums, left, target);
        }

        private static int ShiftedBinarySearch(int[] nums, int pivot, int target)
        {
            // The pivot is the index of the smallest element.
            int n = nums.Length,
                shift = n - pivot, // the amount of shift away from index 0.
                left = (pivot + shift) % n, // the index of the smallest element.
                right = (pivot - 1 + shift) % n; // the middle index.

            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (nums[(mid - shift + n) % n] == target) // check the shifted mid index.
                {
                    return (mid - shift + n) % n; // return the shifted mid index.
                }
                else if (nums[(mid - shift + n) % n] > target) // check if the shifted mid index is greater than the target.
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return -1;
        }
    }
}
