# Is Unique String

## Problem Description
Write a program to determine if a string contains all unique characters. In other words, check if no character appears more than once in the given string.

## Examples:
```
Example 1:
Input: "xyzabc"
Output: true
Explanation: All characters appear exactly once.

Example 2:
Input: "hello"
Output: false
Explanation: The character 'l' appears twice.
```

## Constraints:
- The string may contain any ASCII characters
- If the string is longer than 128 characters, it must contain duplicates (since ASCII has only 128 characters)

## Solution Approaches
The solution implements three different approaches:

1. **LINQ Approach** (`IsUniqueString`):
   - Uses LINQ's Distinct() method to remove duplicates
   - Compares the count of distinct characters with the original string length
   - A one-liner solution: `return str.Length > 128 ? false : str.Length == str.Distinct().Count()`
   - Time Complexity: O(n) where n is the length of the string
   - Space Complexity: O(min(n, 128)) for storing the distinct characters

2. **HashSet Approach** (`IsUniqueStringHash`):
   - Creates a HashSet from the string characters
   - Compares the size of the HashSet with the original string length
   - Time Complexity: O(n) where n is the length of the string
   - Space Complexity: O(min(n, 128)) for the HashSet

3. **Iterative Approach** (`IsUniqueStringWithoutIEnumerable`):
   - Processes the string character by character
   - For each character, checks if it appears in the remaining substring
   - Time Complexity: O(n²) where n is the length of the string
   - Space Complexity: O(n) due to the substring operations

Despite having a higher time complexity in terms of Big O notation, the iterative approach was measured to be significantly faster for small inputs (539 ticks vs. 6276 ticks for the LINQ approach), demonstrating that algorithmic complexity doesn't always directly translate to real-world performance for all input sizes.