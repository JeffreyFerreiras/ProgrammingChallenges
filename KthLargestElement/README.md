# 215. Kth Largest Element in an Array

## Problem Description
Given an integer array `nums` and an integer `k`, return the kth largest element in the array.

Note that it is the kth largest element in the sorted order, not the kth distinct element.

## Examples:
```
Example 1:
Input: nums = [3,2,1,5,6,4], k = 2
Output: 5

Example 2:
Input: nums = [3,2,3,1,2,4,5,5,6], k = 4
Output: 4
```

## Constraints:
- 1 <= k <= nums.length <= 10^5
- -10^4 <= nums[i] <= 10^4

## Solution Approaches
The solution implements multiple approaches to find the kth largest element:

1. **Sorting Approach** (`FindKthLargestBySort`):
   - Sort the array in ascending order
   - Return the element at index (n-k) where n is the array length
   - Time Complexity: O(n log n) for sorting
   - Space Complexity: O(1) if using in-place sorting

2. **Priority Queue Approach** (`FindKthLargestPriorityQueue`):
   - Use a min-heap (priority queue) to maintain the k largest elements
   - Iterate through the array, adding each element to the heap
   - If the heap size exceeds k, remove the smallest element
   - After processing all elements, the root of the heap is the kth largest element
   - Time Complexity: O(n log k)
   - Space Complexity: O(k)

3. **QuickSelect Approach** (`FindKthLargestQuickSelect`):
   - Based on the partition scheme from QuickSort
   - Choose a pivot and partition the array
   - Recursively search only one side of the partition
   - Time Complexity: O(n) average case, O(n²) worst case
   - Space Complexity: O(1) for the iterative implementation

4. **Stack-based Approach** (`FindKthLargestStack`):
   - Use a stack to maintain the k largest elements seen so far
   - Process each element and update the stack accordingly
   - Time Complexity: O(n*k) in the worst case
   - Space Complexity: O(k)

The implementation includes comprehensive test cases covering various scenarios, including edge cases like arrays with duplicates, single-element arrays, and arrays with negative numbers.