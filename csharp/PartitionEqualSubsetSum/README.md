# Partition Equal Subset Sum

## Problem Statement
Given a non-empty array 
ums containing only positive integers, determine if the array can be partitioned into two subsets such that the sum of elements in both subsets is equal.

## Examples

**Example 1**
`
Input: nums = [1,5,11,5]
Output: true
Explanation: The array can be partitioned as [1,5,5] and [11].
`

**Example 2**
`
Input: nums = [1,2,3,5]
Output: false
Explanation: Cannot partition into equal sum subsets.
`

## Constraints
- 1 <= nums.length <= 200
- 1 <= nums[i] <= 100

## Additional Scenarios
- **Edge Case:** 
ums = [2,2] → True, each subset sums to 2.
- **Odd Total Sum:** 
ums = [1,1,3] → False since total sum is odd.
- **Large Input:** 
ums length 200 with mid-range values tests time/memory optimization.
- **Many Small Numbers:** 
ums = [1]*20 → True when sum is even; false otherwise.
