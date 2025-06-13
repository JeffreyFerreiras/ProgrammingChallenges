# 523. Check Subarray Sum

## Problem Description
Given an integer array `nums` and an integer `k`, return `true` if `nums` has a continuous subarray of size at least two whose elements sum up to a multiple of `k`, or `false` otherwise.

An integer `x` is a multiple of `k` if there exists an integer `n` such that `x = n * k`. 0 is always a multiple of `k`.

## Examples:
```
Example 1:
Input: nums = [23, 2, 4, 6, 7], k = 6
Output: true
Explanation: [2, 4] is a continuous subarray of size 2 and sums up to 6.

Example 2:
Input: nums = [23, 2, 6, 4, 7], k = 6
Output: true
Explanation: [23, 2, 6, 4, 7] is a continuous subarray of size 5 and sums up to 42, which is a multiple of 6.

Example 3:
Input: nums = [23, 2, 6, 4, 7], k = 13
Output: false
```

## Constraints:
- 1 <= nums.length <= 10^5
- 0 <= nums[i] <= 10^9
- 0 <= sum(nums[i]) <= 2^31 - 1
- 1 <= k <= 2^31 - 1

## Solution Approaches
The solution offers two different approaches:

1. **HashSet Approach**:
   - Calculate the running sum modulo `k` as we iterate through the array
   - For each position, check if we've seen the current remainder before
   - If we have, it means the sum of elements between these positions is divisible by `k`
   - Use a HashSet to store previously seen remainders

2. **Dictionary Approach**:
   - Similar to the HashSet approach but with additional tracking of positions
   - Store each remainder along with its position in a Dictionary
   - When we find a repeated remainder, check if the subarray size is at least 2
   - Initialize the Dictionary with {0: -1} to handle cases where the subarray starts from index 0

Both approaches have:
- Time Complexity: O(n) where n is the length of the array
- Space Complexity: O(min(n, k)) as we store at most k different remainders