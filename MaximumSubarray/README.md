# 53. Maximum Subarray

## Problem Description
Given an integer array `nums`, find the contiguous subarray (containing at least one number) which has the largest sum and return its sum.

A subarray is a contiguous part of an array.

## Examples:
```
Example 1:
Input: nums = [-2,1,-3,4,-1,2,1,-5,4]
Output: 6
Explanation: [4,-1,2,1] has the largest sum = 6.

Example 2:
Input: nums = [1]
Output: 1
Explanation: The array has only one element, so the maximum subarray sum is 1.

Example 3:
Input: nums = [5,4,-1,7,8]
Output: 23
Explanation: The entire array [5,4,-1,7,8] has the largest sum = 23.
```

## Constraints:
- 1 <= nums.length <= 10^5
- -10^4 <= nums[i] <= 10^4

## Solution Approaches
The solution implements multiple approaches to find the maximum subarray sum:

1. **Kadane's Algorithm** (`MaxSubArray`):
   - Use dynamic programming to find the maximum subarray ending at each position
   - Keep track of the current sum and reset it if it becomes negative
   - Time Complexity: O(n) where n is the length of the array
   - Space Complexity: O(1)

2. **Custom Sliding Window Approach** (`MaxSubArray_Jeffrey`):
   - Use a window of decreasing size to find all possible subarrays
   - Calculate the sum of each subarray and track the maximum
   - Time Complexity: O(n^2) where n is the length of the array
   - Space Complexity: O(1)

3. **Brute Force Approach** (`MaxSubArray_Brute`):
   - Consider all possible subarrays and calculate their sums
   - Keep track of the maximum sum found
   - Time Complexity: O(n^3) where n is the length of the array
   - Space Complexity: O(1)

The optimal solution is Kadane's Algorithm, which efficiently solves the problem in linear time. The code includes test cases to verify the correctness of the implementations.

**Follow-up**: The problem also suggests implementing a divide-and-conquer solution, which would have O(n log n) time complexity.