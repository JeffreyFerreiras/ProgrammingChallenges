# Find Duplicate - Space Edition

## Problem Description
We have a list of integers, where:
1. The integers are in the range 1..n
2. The list has a length of n + 1

It follows that our list has at least one integer which appears at least twice. But it may have several duplicates, and each duplicate may appear more than twice.

Write a function which finds an integer that appears more than once in our list. (If there are multiple duplicates, you only need to find one of them.)

The challenge is to optimize for space complexity, as if running on a device with limited memory.

## Example:
```
Input: [9, 8, 7, 1, 6, 15, 8]
Output: 8 (the duplicate value)
```

## Constraints:
- The integers in the array are in the range 1..n
- The array has a length of n + 1
- There is at least one duplicate in the array
- Must optimize for space complexity

## Solution Approach
The solution uses a binary search strategy on the range of possible values (not on the array itself):

1. Start with the range of possible values from 1 to n
2. Find the midpoint of the range
3. Count how many numbers in the array fall within the lower half of the range
4. If the count exceeds the number of distinct possible values in that range, there must be a duplicate in that half
5. Otherwise, there must be a duplicate in the upper half
6. Repeat the process on the half that contains a duplicate until the range is narrowed down to a single number

This approach has:
- Time Complexity: O(n log n) where n is the length of the array
- Space Complexity: O(1) as it uses only a constant amount of extra space

The solution is optimal for scenarios with memory constraints since it doesn't require additional data structures like HashSets or sorting the array.