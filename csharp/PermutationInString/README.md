# Permutation in String

## Problem Statement
Given two strings s1 and s2, return 	rue if s2 contains a permutation of s1, or alse otherwise. In other words, return 	rue if one of s1's permutations is the substring of s2.

## Examples

**Example 1**
`
Input: s1 = "ab", s2 = "eidbaooo"
Output: true
Explanation: s2 contains one permutation of s1 ("ba").
`

**Example 2**
`
Input: s1 = "ab", s2 = "eidboaoo"
Output: false
Explanation: s2 does not contain any permutation of s1.
`

## Constraints
- 1 <= s1.length, s2.length <= 10^4
- s1 and s2 consist of lowercase English letters.

## Additional Scenarios
- **Edge Case:** s1 = "a", s2 = "a" → Result is 	rue.
- **Edge Case:** s1 = "abcd", s2 = "abc" → Result is alse because s2 is shorter than s1.
- **Repeated Characters:** s1 = "aabc", s2 = "bbacaabca" → Result is 	rue.
- **Long Example:** s1 = "xyz", s2 = "abcdefghijklmnopqrxyz" → Result is 	rue (permutation at the end).
- **No Match:** s1 = "abc", s2 = "defghi" → Result is alse.

