# Find Element in Sorted Rotated Array

## Problem Description
Given a rotated sorted array, find the first occurrence of a certain number X with the lowest possible complexity (both time and space).

A rotated sorted array is an array that was initially sorted in ascending order, then rotated around a pivot point. For example, [3, 4, 5, 1, 2] is a rotated version of the sorted array [1, 2, 3, 4, 5].

## Examples:
```
Example 1:
Input: nums = [3, 4, 5, 1, 2], target = 4
Output: 1
Explanation: 4 is found at index 1.

Example 2:
Input: nums = [4, 5, 6, 7, 0, 1, 2], target = 0
Output: 4
Explanation: 0 is found at index 4.

Example 3:
Input: nums = [1], target = 1
Output: 0
Explanation: 1 is found at index 0.
```

## Constraints:
- 1 <= nums.length <= 5000
- -10^4 <= nums[i] <= 10^4
- All values of nums are unique
- nums is guaranteed to be rotated at some pivot
- -10^4 <= target <= 10^4

## Solution Approaches
The solution implements three different approaches to search in a rotated sorted array:

1. **Recursive Binary Search** (`BinarySearchRecursive`):
   - Handles different cases based on which half of the array is sorted
   - Compares target with elements to determine which half to search
   - Recursively searches the appropriate half

2. **Find Pivot Then Search** (`ShiftedBinarySearch`):
   - First finds the pivot (smallest element) using binary search
   - Then performs a modified binary search accounting for the rotation

3. **Find Sorted Half** (`BinarySearchFindsSortedHalf`):
   - First finds the pivot (smallest element)
   - Determines which half of the array contains the target
   - Performs standard binary search on the appropriate half

All approaches achieve:
- Time Complexity: O(log n) where n is the array length
- Space Complexity: O(log n) for recursive approaches due to the call stack, O(1) for iterative approaches

The implementation includes comprehensive testing and benchmarking to compare the performance of all three approaches.