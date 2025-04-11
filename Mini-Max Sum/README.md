# Mini-Max Sum

## Problem Description
Given five positive integers, find the minimum and maximum values that can be calculated by summing exactly four of the five integers. Then print the respective minimum and maximum values as a single line of two space-separated long integers.

## Examples:
```
Example 1:
Input: [1, 2, 3, 4, 5]
Output: 10 14
Explanation: 
- The minimum sum is 1+2+3+4 = 10
- The maximum sum is 2+3+4+5 = 14

Example 2:
Input: [4, 4, 3, 8, 5]
Output: 16 21
Explanation: 
- The minimum sum is 4+4+3+5 = 16
- The maximum sum is 4+4+5+8 = 21
```

## Constraints:
- The array contains exactly 5 positive integers
- 1 <= arr[i] <= 10^9

## Solution Approach
The solution uses a specialized approach with a configurable comparator function:

1. Reuse the same algorithm for both minimum and maximum calculations by passing different comparison functions
2. For each calculation:
   - Maintain a list of 4 elements (cache)
   - For each element in the input array, decide whether to include it in the cache based on the comparison function
   - Sum the final 4 elements in the cache

The implementation uses:
- Higher-order functions (`Func<long, long, bool>`) to configure whether to find minimum or maximum
- A helper method `GetMinMax` that implements the main algorithm
- A helper method `ReplaceMinMax` to handle element replacement logic

This approach:
- Time Complexity: O(n) where n is the size of the input array (which is 5 in this case)
- Space Complexity: O(1) as it maintains a fixed-size cache of 4 elements

The solution generalizes well and could be extended to handle arrays of any size with a parameter for how many elements to sum.