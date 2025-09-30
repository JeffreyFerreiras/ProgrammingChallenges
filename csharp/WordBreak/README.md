# Word Break

## Problem Statement
Given a string s and a dictionary of strings wordDict, return 	rue if s can be segmented into a space-separated sequence of one or more dictionary words.

## Examples

**Example 1**
`
Input: s = "leetcode", wordDict = ["leet","code"]
Output: true
`

**Example 2**
`
Input: s = "applepenapple", wordDict = ["apple","pen"]
Output: true
`

**Example 3**
`
Input: s = "catsandog", wordDict = ["cats","dog","sand","and","cat"]
Output: false
`

## Constraints
- 1 <= s.length <= 300
- 1 <= wordDict.length <= 1000
- 1 <= wordDict[i].length <= 20
- s and wordDict[i] consist of only lowercase English letters.
- All words in wordDict are unique.

## Additional Scenarios
- **Edge Case:** s = "a", wordDict = ["a"] → Returns 	rue.
- **Single Character Dictionary:** s = "aaaaab", wordDict = ["a","aa","aaa"] → Returns alse.
- **Long String:** s length 300 with repeated patterns to ensure DP caching is necessary.
- **Large Dictionary:** Many short words ensures algorithm handles numerous lookups efficiently.
