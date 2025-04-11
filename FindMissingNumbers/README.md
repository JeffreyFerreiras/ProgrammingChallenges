# Find Missing Numbers

## Problem Description
You are given an array with all the numbers from one to N appearing exactly once, except for one number that is missing. Find the missing number in O(n) time and O(1) space.

Follow-Up: What if there are two numbers missing?

## Examples:
```
Example 1 (One Missing Number):
Input: numbers = [1, 2, 0, 4, 5], N = 5
Output: 3
Explanation: The array should contain numbers 1 through 5, and 3 is missing.

Example 2 (Two Missing Numbers):
Input: numbers = [1, 2, 0, 4, 0], N = 5
Output: [3, 5]
Explanation: The array should contain numbers 1 through 5, and both 3 and 5 are missing.
```

## Constraints:
- The array contains integers from 1 to N with one or two numbers missing
- For the first problem, exactly one number is missing
- For the follow-up problem, exactly two numbers are missing
- Zero may be used as a placeholder in the array

## Solution Approaches

### Finding One Missing Number
The solution uses a mathematical approach:
1. Calculate the expected sum of numbers from 1 to N using the formula: `N * (N + 1) / 2`
2. Calculate the actual sum of the array
3. The difference between the expected and actual sum is the missing number

This approach achieves:
- Time Complexity: O(n) for calculating the sum
- Space Complexity: O(1) as it uses only a constant amount of extra space

### Finding Two Missing Numbers
The solution implements a sequential scanning approach:
1. Start with the first number in the array
2. Check if each subsequent number follows the expected sequence
3. If a number is missing in the sequence, add it to the result
4. Continue until both missing numbers are found

Alternative approach:
- The solution also includes a variation that doesn't rely on placeholders
- It assumes the array length is less than N and handles missing numbers at the end

Both approaches for the follow-up problem maintain:
- Time Complexity: O(n)
- Space Complexity: O(1) excluding the output array