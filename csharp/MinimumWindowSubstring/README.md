# Minimum Window Substring

## Problem Statement
Given two strings s and 	 of lengths m and 
 respectively, return the minimum window substring of s such that every character in 	 (including duplicates) is included in the window. If there is no such substring, return an empty string "".

## Examples

**Example 1**
`
Input: s = "ADOBECODEBANC", t = "ABC"
Output: "BANC"
Explanation: The minimum window substring "BANC" includes 'A', 'B', and 'C'.
`

**Example 2**
`
Input: s = "a", t = "a"
Output: "a"
`

**Example 3**
`
Input: s = "a", t = "aa"
Output: ""
Explanation: Since both 'a's are not present in the window, return an empty string.
`

## Constraints
- m == s.length
- 
 == t.length
- 1 <= m, n <= 10^5
- s and 	 consist of uppercase and lowercase English letters.

## Additional Scenarios
- **Edge Case:** s = "aa", t = "aa" → Result is "aa" because both required characters must be included.
- **Impossible Case:** s = "a", t = "b" → Result is "" since s lacks 'b'.
- **Repeated Characters:** s = "bbaa", t = "aba" → Minimum window is "baa".
- **Long Example:** s = "NNNNNABCOOOABCNNNN", t = "ABC" → Minimum window is "ABC".
- **Another Example:** s = "abcdebdde", t = "bde" → Minimum window is "bdde".

