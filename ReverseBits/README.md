# 190. Reverse Bits

## Problem Description
Reverse bits of a given 32-bit unsigned integer.

## Examples
**Example 1:**
```
Input: n = 00000010100101000001111010011100 (43261596)
Output: 00111001011110000010100101000000 (964176192)
Explanation: The input binary string 00000010100101000001111010011100 represents the unsigned integer 43261596, so return 964176192 which its binary representation is 00111001011110000010100101000000.
```

**Example 2:**
```
Input: n = 11111111111111111111111111111101 (4294967293)
Output: 10111111111111111111111111111111 (3221225471)
Explanation: The input binary string 11111111111111111111111111111101 represents the unsigned integer 4294967293, so return 3221225471 which its binary representation is 10111111111111111111111111111111.
```

## Constraints
- The input must be a binary string of length 32

## Solution Approach
The solution uses a bit manipulation approach to reverse the bits:
- Iterate through all 32 bits of the input
- For each bit:
  - Left shift the result by 1
  - Extract the least significant bit (LSB) from the input using bitwise AND with 1
  - Add this bit to the result using bitwise OR
  - Right shift the input by 1 to process the next bit
- Time Complexity: O(1) since we always process exactly 32 bits
- Space Complexity: O(1) as we use constant extra space

## Follow-up Question
If this function is called many times, how would you optimize it?

Potential optimizations:
- Use a lookup table to reverse chunks of bits at a time (e.g., reverse 8 bits at once using a 256-entry table)
- Cache previously computed results
- Use bit manipulation tricks like divide and conquer to swap groups of bits