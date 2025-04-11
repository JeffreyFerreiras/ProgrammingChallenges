# 152. Maximum Product Subarray

## Problem Description
Given an integer array `nums`, find a contiguous non-empty subarray within the array that has the largest product, and return the product.

A subarray is a contiguous subsequence of the array.

## Examples:
```
Example 1:
Input: nums = [2,3,-2,4]
Output: 6
Explanation: [2,3] has the largest product 6.

Example 2:
Input: nums = [-2,0,-1]
Output: 0
Explanation: The result cannot be 2, because [-2,-1] is not a subarray.
```

## Constraints:
- 1 <= nums.length <= 2 * 10^4
- -10 <= nums[i] <= 10
- The product of any prefix or suffix of nums is guaranteed to fit in a 32-bit integer.

## Solution Approaches
The solution implements multiple approaches to solve this problem:

1. **Official/Optimal Approach** (`MaxProduct_Official`):
   - Use dynamic programming to track both maximum and minimum products ending at each position
   - We track minimum product because when multiplying by a negative number, the smallest product can become the largest
   - At each step, calculate:
     - max_product = max(current_num, max_product * current_num, min_product * current_num)
     - min_product = min(current_num, max_product * current_num, min_product * current_num)
   - Track the overall maximum product seen
   - Time Complexity: O(n) where n is the length of the array
   - Space Complexity: O(1)

2. **Brute Force Approach** (`MaxProduct_N2`):
   - For each starting position, calculate the product of all subarrays starting at that position
   - Keep track of the maximum product found
   - Time Complexity: O(n^2) where n is the length of the array
   - Space Complexity: O(1)

3. **Custom Approach** (`MaxProduct`):
   - Combines various techniques to handle different scenarios (positive, negative, and zero values)
   - Special handling for negative numbers and isolated sequences
   - Time Complexity: O(n) to O(n^2) depending on the input pattern
   - Space Complexity: O(1)

The implementation includes comprehensive test cases covering various scenarios:
- Arrays with all positive numbers
- Arrays with negative numbers
- Arrays containing zeros
- Arrays with mixed positive and negative numbers