# Maximum Product Subarray

## Problem Statement
Given an integer array 
ums, find a contiguous non-empty subarray within the array that has the largest product, and return the product.

## Examples

**Example 1**
`
Input: nums = [2,3,-2,4]
Output: 6
Explanation: Subarray [2,3] has the largest product.
`

**Example 2**
`
Input: nums = [-2,0,-1]
Output: 0
Explanation: The result cannot be 2 because [-2,-1] is not a contiguous subarray.
`

## Constraints
- 1 <= nums.length <= 2 * 10^4
- -10 <= nums[i] <= 10
- The product of any prefix or suffix of 
ums is guaranteed to fit in a 32-bit integer.

## Additional Scenarios
- **Single Element:** 
ums = [-3] → Product is -3.
- **All Negative:** 
ums = [-2,-3,-4] → Product is -2 * -3 * -4 = -24, but best subarray is [-2,-3] = 6.
- **Contains Zeroes:** 
ums = [0,2,0,3,4] → Must reset around zero.
- **Large Mix:** Alternating positives/negatives ensures tracking both min and max products.
