# 1461. Check If a String Contains All Binary Codes of Size K

## Problem Description
Given a string `s` of 0's and 1's and an integer `k`, return `true` if every binary code of length `k` is a substring of `s`, otherwise return `false`.

A binary code of length `k` is a string of `k` bits (characters '0' and '1'). There are a total of 2^k distinct binary codes of length `k`.

## Examples:
```
Example 1:
Input: s = "00110110", k = 2
Output: true
Explanation: The binary codes of length 2 are "00", "01", "10", "11". They can all be found as substrings of s.

Example 2:
Input: s = "0110", k = 1
Output: true
Explanation: The binary codes of length 1 are "0" and "1". They can both be found as substrings of s.

Example 3:
Input: s = "0110", k = 2
Output: false
Explanation: The binary code "00" is not a substring of s.
```

## Constraints:
- 1 <= s.length <= 5 * 10^5
- s consists of 0's and 1's only
- 1 <= k <= 20

## Solution Approaches
The solution offers two different approaches:

1. **HashSet Approach** (Preferred):
   - Create a HashSet to store all substrings of length `k`
   - Iterate through the string and add each substring of length `k` to the HashSet
   - Check if the size of the HashSet equals 2^k (all possible binary codes)
   - Special case for k=1 is handled separately

2. **Iteration Approach**:
   - Generate all possible binary codes of length `k` (from 0 to 2^k-1)
   - For each binary code, check if it's a substring of `s`
   - If any code is not found, return false

The HashSet approach is more efficient with O(n*k) time complexity, where n is the length of the string and k is the code length.