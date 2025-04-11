# String Compression

## Problem Description
Implement a method to perform basic string compression using the counts of repeated characters. For example, the string "aabcccccaaa" would become "2a1b5c3a".

If the "compressed" string would not become smaller than the original string, your method should return the original string.

## Example:
```
Input: "aaccccddddsssa"
Output: "2a4c4d3s1a"
```

## Constraints:
- The string consists of only uppercase and lowercase English letters (a-z, A-Z)
- If the compressed string is not shorter than the original string, return the original string

## Solution Approach
The solution uses a straightforward approach to compress the string:

1. Iterate through the characters of the input string
2. Count consecutive occurrences of each character
3. Append the count followed by the character to a StringBuilder
4. Skip ahead to the next different character
5. Return the compressed string if it's shorter than the original, otherwise return the original string

The implementation uses StringBuilder for efficient string concatenation, and a single pass through the string to achieve O(n) time complexity.

Time Complexity: O(n) where n is the length of the input string
Space Complexity: O(n) in the worst case for the output string