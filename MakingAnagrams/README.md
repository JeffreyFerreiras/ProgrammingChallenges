# Making Anagrams

## Problem Description
Given two strings, `a` and `b`, that may or may not be of the same length, determine the minimum number of character deletions required to make `a` and `b` anagrams. Any characters can be deleted from either of the strings.

An anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.

## Examples:
```
Example 1:
Input: a = "abc", b = "cde"
Output: 4
Explanation: 
- Delete 'a' and 'b' from string a
- Delete 'd' and 'e' from string b
- The remaining strings "c" and "c" are anagrams

Example 2:
Input: a = "cde", b = "abc"
Output: 4
Explanation: Same as above, just with different strings.
```

## Constraints:
- 1 <= a.length, b.length <= 10^4
- The strings a and b consist of lowercase English letters

## Solution Approach
The solution uses character frequency counting:

1. Count the frequency of each character in both strings using a 26-element array (for lowercase letters)
2. For each letter (a to z), calculate the absolute difference between its frequency in string a and string b
3. Sum up all these differences to get the total number of characters that need to be deleted

This approach works because:
- Characters that appear with the same frequency in both strings don't need to be deleted
- For characters with different frequencies, we need to delete the excess occurrences
- The absolute difference gives us exactly how many instances to remove

The implementation:
- Time Complexity: O(n + m) where n and m are the lengths of the two strings
- Space Complexity: O(1) as the character array size is fixed (26 for lowercase letters)