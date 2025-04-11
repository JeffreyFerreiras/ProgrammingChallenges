# Reverse String

## Problem Description
Write a function that reverses a string. The input string is given as an array of characters.

## Examples
**Example 1:**
```
Input: "Some string to reverse"
Output: "esrever ot gnirts emoS"
```

## Solution Approach
This project implements and compares several different approaches to reversing a string:

1. **Recursive Approach**: Uses recursion to build the reversed string
2. **Stack Approach**: Uses a Stack data structure to reverse the characters
3. **StringBuilder Approach**: Uses StringBuilder to efficiently build the reversed string
4. **Array Approach**: Converts the string to a character array and uses Array.Reverse
5. **Classic Loop Approach**: Uses a simple for loop to iterate from the end of the string

The implementation includes performance measurements to compare the efficiency of each approach, with the Array.Reverse method being the fastest in the tests.

- Time Complexity: O(n) for all approaches where n is the length of the string
- Space Complexity: O(n) for all approaches to store the reversed string