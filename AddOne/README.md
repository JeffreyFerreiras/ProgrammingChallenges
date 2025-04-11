# Add One

## Problem Description
Given an array of digits representing a non-negative integer, add one to the number and return the result as an array.

The digits are arranged with the most significant digit at the start of the array (i.e., standard order, not reversed).

## Examples:
```
Input: [1,3,2,4]
Output: [1,3,2,5]
Explanation: 1324 + 1 = 1325

Input: [9,9,9,9]
Output: [1,0,0,0,0]
Explanation: 9999 + 1 = 10000
```

## Constraints:
- The input array can be empty
- Each element in the array is a single digit (0-9)
- The array represents a non-negative integer with the most significant digit at the start

## Solution Approaches
The implementation offers two different approaches:

1. **Iterative Approach**:
   - Process digits from right to left
   - Add carry to the current digit
   - Update carry for the next iteration if needed
   - Handle overflow if necessary

2. **Recursive Approach**:
   - Recursively add one to the rightmost digit
   - If it results in a carry, recursively add one to the digit to the left
   - If needed, prepend a new digit to the array (when there's a carry from the leftmost digit)

The solution handles edge cases such as empty arrays and arrays that result in an additional digit (e.g., 999 + 1 = 1000).