# 153. Find Minimum in Rotated Sorted Array

## Problem Description
Suppose an array of length n sorted in ascending order is rotated between 1 and n times. For example, the array nums = [0,1,2,4,5,6,7] might become:
- [4,5,6,7,0,1,2] if it was rotated 4 times.
- [0,1,2,4,5,6,7] if it was rotated 7 times.

Notice that rotating an array [a[0], a[1], a[2], ..., a[n-1]] 1 time results in the array [a[n-1], a[0], a[1], a[2], ..., a[n-2]].

Given the sorted rotated array nums of unique elements, return the minimum element of this array.

You must write an algorithm that runs in O(log n) time.

## Examples:
```
Example 1:
Input: nums = [3,4,5,1,2]
Output: 1
Explanation: The original array was [1,2,3,4,5] rotated 3 times.

Example 2:
Input: nums = [4,5,6,7,0,1,2]
Output: 0
Explanation: The original array was [0,1,2,4,5,6,7] and it was rotated 4 times.

Example 3:
Input: nums = [11,13,15,17]
Output: 11
Explanation: The original array was [11,13,15,17] and it was rotated 4 times (which is equivalent to not rotating at all).
```

## Constraints:
- n == nums.length
- 1 <= n <= 5000
- -5000 <= nums[i] <= 5000
- All the integers of nums are unique
- nums is sorted and rotated between 1 and n times

## Solution Approach
The solution implements a modified binary search algorithm to find the minimum element:

1. Initialize pointers `left` at the beginning and `right` at the end of the array
2. While `left` <= `right`:
   - Find the middle element `mid`
   - Check if the array from `left` to `right` is already sorted (nums[left] <= nums[right])
     - If it is, then nums[left] is the minimum
   - Otherwise:
     - If nums[mid] > nums[right], the minimum is in the right half, so set left = mid + 1
     - If nums[mid] < nums[right], the minimum is in the left half (including mid), so set right = mid

This binary search approach achieves:
- Time Complexity: O(log n) where n is the array length
- Space Complexity: O(1) as it uses constant extra space

The implementation includes comprehensive test cases including edge cases like arrays of length 1, arrays with negative numbers, and arrays rotated n times (which is equivalent to no rotation).