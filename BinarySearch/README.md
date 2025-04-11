# Binary Search

## Problem Description
Given a sorted array of integers `nums` and an integer `target`, find the index of `target` in the array. If `target` is not present in the array, return -1.

## Example:
```
Input: nums = [-1,0,3,5,9,12], target = 9
Output: 4
Explanation: 9 exists in nums and its index is 4
```

## Constraints:
- The array is sorted in ascending order
- All elements in the array are unique
- The array may contain negative numbers

## Solution Approach
The solution implements the classic binary search algorithm:

1. Initialize two pointers, `low` at the beginning of the array and `high` at the end
2. While `low` is less than or equal to `high`:
   - Calculate the middle index `mid` as the average of `low` and `high`
   - If the value at `mid` is equal to the target, return `mid`
   - If the value at `mid` is greater than the target, search the left half by setting `high = mid - 1`
   - If the value at `mid` is less than the target, search the right half by setting `low = mid + 1`
3. If the target is not found after the loop, return -1

This binary search implementation has:
- Time Complexity: O(log n) where n is the length of the array
- Space Complexity: O(1) as it uses a constant amount of extra space