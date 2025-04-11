# 49. Group Anagrams

## Problem Description
Given an array of strings `strs`, group the anagrams together. You can return the answer in any order.

An **Anagram** is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.

## Examples:

Example 1:
Input: strs = ["eat","tea","tan","ate","nat","bat"]
Output: [["bat"],["nat","tan"],["ate","eat","tea"]]

Example 2:
Input: strs = [""]
Output: [[""]]

Example 3:
Input: strs = ["a"]
Output: [["a"]]

## Constraints:
- 1 <= strs.length <= 10^4
- 0 <= strs[i].length <= 100
- strs[i] consists of lowercase English letters

## Solution Approach
To group anagrams efficiently, we need to identify a common representation for all anagrams of the same word. There are several approaches:

1. **Sorted String as Key**:
   - For each string, sort its characters to create a canonical form
   - All anagrams will have the same sorted form
   - Use this sorted form as a key in a dictionary/hash map
   - Group strings with the same key together

2. **Character Count as Key**:
   - Create a frequency count of characters for each string
   - All anagrams will have the same character frequency
   - Use this frequency array or a string representation of it as a key
   - Group strings with the same key together

The solution implements one of these approaches with:
- Time Complexity: O(n * k log k) where n is the number of strings and k is the maximum length of a string (if using sorted string approach)
- Time Complexity: O(n * k) where n is the number of strings and k is the maximum length of a string (if using character count approach)
- Space Complexity: O(n * k) for storing all strings in the result
