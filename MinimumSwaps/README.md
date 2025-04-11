# Minimum Swaps

## Problem Description
Calculate the minimum number of swaps required to group all 1's together in a binary array (an array containing only 0s and 1s).

## Examples:
```
Example 1 (Simple case):
Input: [1, 0, 1, 0, 1]
Output: 1
Explanation: We can move one of the 1s to create [1, 1, 1, 0, 0]

Example 2 (Already grouped):
Input: [1, 1, 1, 0, 0]
Output: 0
Explanation: All 1s are already grouped together, so no swaps are needed.

Example 3 (Worst case):
Input: [1, 0, 1, 0, 1, 0]
Output: 2
Explanation: We need 2 swaps to get all 1s together.

Example 4 (All zeros or ones):
Input: [0, 0, 0, 0]
Output: 0
Explanation: No 1s to group, so no swaps needed.

Input: [1, 1, 1, 1]
Output: 0
Explanation: All 1s are already grouped together.
```

## Solution Approach
The solution uses a sliding window technique to find the minimum number of swaps:

1. Count the total number of 1s in the array
2. Use a sliding window of size equal to the count of 1s
3. For each possible position of the window:
   - Count how many 0s are inside the window
   - These 0s need to be swapped with 1s outside the window
   - Track the minimum count of swaps needed across all window positions
4. Return the minimum number of swaps found

This approach:
- Time Complexity: O(n) where n is the length of the array
- Space Complexity: O(1) as it only needs a few variables

The implementation includes:
- Comprehensive test cases covering different scenarios
- Performance measurement using a Stopwatch
- An interactive mode allowing users to enter their own binary arrays for testing

This problem is a good example of using the sliding window technique to optimize an otherwise O(n²) solution to O(n).