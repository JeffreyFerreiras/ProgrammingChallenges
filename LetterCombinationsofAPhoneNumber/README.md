# 17. Letter Combinations of a Phone Number

## Problem Description
Given a string containing digits from 2-9 inclusive, return all possible letter combinations that the number could represent. A mapping of digit to letters (just like on the telephone buttons) is given below. Note that 1 does not map to any letters.

```
2: "abc"
3: "def"
4: "ghi"
5: "jkl"
6: "mno"
7: "pqrs"
8: "tuv"
9: "wxyz"
```

## Examples:
```
Example 1:
Input: digits = "23"
Output: ["ad","ae","af","bd","be","bf","cd","ce","cf"]
Explanation: Digit 2 maps to "abc" and digit 3 maps to "def". The combinations are all possible pairs.

Example 2:
Input: digits = ""
Output: []
Explanation: No combinations are possible with an empty string.

Example 3:
Input: digits = "2"
Output: ["a","b","c"]
Explanation: Digit 2 maps to "abc", so we return all three letters.
```

## Constraints:
- 0 <= digits.length <= 4
- digits[i] is a digit in the range ['2', '9']

## Solution Approach
The solution likely uses a recursive backtracking approach or iterative approach to generate all possible combinations:

1. **Backtracking Approach**:
   - Create a mapping of digits to their corresponding letters
   - Use recursion to explore all possible combinations
   - Build the combinations one character at a time
   - Add each complete combination to the result list
   - Time Complexity: O(4^n) where n is the number of digits (since a digit can map to at most 4 letters)
   - Space Complexity: O(n) for the recursion stack and storing the current combination

2. **Iterative Approach**:
   - Initialize the result list with an empty string
   - For each digit, generate all possible combinations with the current results and the letters mapped to that digit
   - Time Complexity: O(4^n) where n is the number of digits
   - Space Complexity: O(4^n) for storing all combinations

The implementation includes test scenarios to validate the solution, along with performance metrics using a Stopwatch to measure execution time.