# 283. Move Zeroes

## Problem Description
Given an integer array `nums`, move all 0's to the end of it while maintaining the relative order of the non-zero elements.

Note that you must do this in-place without making a copy of the array.

## Examples:
```
Example 1:
Input: nums = [0,1,0,3,12]
Output: [1,3,12,0,0]
Explanation: All non-zero elements maintain their order while zeros are moved to the end.

Example 2:
Input: nums = [0]
Output: [0]
Explanation: There is only one element, so no change is needed.
```

## Constraints:
- 1 <= nums.length <= 10^4
- -2^31 <= nums[i] <= 2^31 - 1

## Solution Approach
The solution uses a two-pointer technique to efficiently move zeros to the end:

1. Use two pointers:
   - `i`: points to the position where the next non-zero element should be placed
   - `j`: traverses the array to find non-zero elements
   
2. Algorithm:
   - Traverse the array with pointer `j`
   - When a non-zero element is found at position `j`, copy it to position `i` and increment `i`
   - After all elements are traversed, fill the remaining positions (from `i` to the end) with zeros

This approach:
- Time Complexity: O(n) where n is the length of the array
- Space Complexity: O(1) as it modifies the array in-place without using additional space

The implementation is concise and optimal, using only a single pass through the array to achieve the desired result.