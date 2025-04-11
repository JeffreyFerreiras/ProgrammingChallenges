# Number of Bit Changes to Make Two Integers Equal

## Problem Description
You are given two positive integers n and k.

You can choose any bit in the binary representation of n that is equal to 1 and change it to 0.

Return the number of changes needed to make n equal to k. If it is impossible, return -1.

## Examples:
```
Example 1:
Input: n = 13, k = 4
Output: 2
Explanation:
Initially, the binary representations of n and k are n = (1101)₂ and k = (0100)₂.
We can change the first and fourth bits of n. The resulting integer is n = (0100)₂ = k.

Example 2:
Input: n = 21, k = 21
Output: 0
Explanation:
n and k are already equal, so no changes are needed.

Example 3:
Input: n = 14, k = 13
Output: -1
Explanation:
It is not possible to make n equal to k.
```

## Constraints:
- 1 <= n, k <= 10^6

## Solution Approach
The solution uses bit manipulation to compare the binary representations of the two integers:

1. Handle special cases:
   - If n equals k, return 0 (no changes needed)
   - If n is less than k, return -1 (impossible since we can only change 1's to 0's)

2. Compare each bit position of both numbers:
   - Extract the least significant bit (LSB) of both numbers
   - If n's bit is 0 and k's bit is 1, return -1 (impossible to change 0 to 1)
   - If n's bit is 1 and k's bit is 0, increment the counter
   - Shift both numbers right by 1 bit
   - Repeat until n becomes 0

3. Return the final count of required changes

This approach:
- Time Complexity: O(log max(n, k)) as we examine each bit position
- Space Complexity: O(1)

The implementation includes several test cases to verify correctness:
- Basic cases from the problem statement
- Additional edge cases like powers of 2
- Boundary cases within the constraint range

Performance is measured using a Stopwatch to track execution time for each test case.