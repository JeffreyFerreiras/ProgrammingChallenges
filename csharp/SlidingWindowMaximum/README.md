# Sliding Window Maximum

## Problem Statement
You are given an array of integers 
ums, and there is a sliding window of size k which moves from the very left of the array to the very right. You can only see the k numbers in the window. Each time the sliding window moves right by one position. Return an array of the maximum values in each window.

## Examples

**Example 1**
`
Input: nums = [1,3,-1,-3,5,3,6,7], k = 3
Output: [3,3,5,5,6,7]
Explanation: Window positions are [1,3,-1], [3,-1,-3], [-1,-3,5], [-3,5,3], [5,3,6], [3,6,7].
`

**Example 2**
`
Input: nums = [1], k = 1
Output: [1]
`

## Constraints
- 1 <= nums.length <= 10^5
- -10^4 <= nums[i] <= 10^4
- 1 <= k <= nums.length

## Additional Scenarios
- **Edge Case:** 
ums = [9, 8, 7, 6, 5], k = 5 → Output [9] as the window spans the entire array.
- **Edge Case:** 
ums = [4, 4, 4, 4], k = 2 → Output [4, 4, 4] because all values are the same.
- **Long Example:** 
ums = [10, 6, 9, 8, 7, 5, 4, 3, 2, 1, 0, 12, 11, 13, 15], k = 4 → Output [10, 9, 9, 8, 7, 5, 4, 3, 12, 12, 13, 15].
- **Increasing Sequence:** 
ums = [1, 2, 3, 4, 5], k = 2 → Output [2, 3, 4, 5].

