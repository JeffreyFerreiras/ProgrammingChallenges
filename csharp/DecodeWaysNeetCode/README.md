# Decode Ways

## Problem Statement
A message containing letters from A-Z can be encoded into numbers using the mapping A -> 1, B -> 2, ..., Z -> 26. Given a string s containing only digits, return the number of ways to decode it.

## Examples

**Example 1**
`
Input: s = "12"
Output: 2
Explanation: It can be decoded as "AB" (1 2) or "L" (12).
`

**Example 2**
`
Input: s = "226"
Output: 3
Explanation: "BZ" (2 26), "VF" (22 6), or "BBF" (2 2 6).
`

**Example 3**
`
Input: s = "06"
Output: 0
Explanation: No valid encodings starting with zero.
`

## Constraints
- 1 <= s.length <= 100
- s contains only digits.
- s may contain leading zeroes, which do not map to any letter.

## Additional Scenarios
- **Edge Case:** s = "0" → No decodings possible.
- **Single Digit:** s = "7" → Exactly one decoding.
- **Long String:** s = "1111111111" → Number of decodings follows Fibonacci-like growth.
- **Zeros Inside:** s = "1010" → Must correctly handle zero combinations, result is 1.
