# Find All Anagrams in a String

## Problem Statement
Given two strings s and p, return an array of all the start indices of p's anagrams in s. You may return the answer in any order.

## Examples

**Example 1**
`
Input: s = "cbaebabacd", p = "abc"
Output: [0,6]
Explanation: The substring starting at index 0 is "cba", which is an anagram of "abc". The substring starting at index 6 is "bac", which is also an anagram.
`

**Example 2**
`
Input: s = "abab", p = "ab"
Output: [0,1,2]
`

## Constraints
- 1 <= s.length, p.length <= 3 * 10^4
- s and p consist of lowercase English letters.

## Additional Scenarios
- **Edge Case:** s = "a", p = "b" → Output [] because no anagram exists.
- **Edge Case:** s = "a", p = "a" → Output [0].
- **Repeated Characters:** s = "baa", p = "aa" → Output [1].
- **Long Example:** s = "aaaaaaaaabaaaaaaaaa", p = "aaab" → Output [6, 7, 8, 9] where anagrams begin just before the block containing .
- **No Match:** s = "abcdefg", p = "hij" → Output [].

