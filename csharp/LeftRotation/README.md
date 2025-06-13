# Left Rotation

## Problem Description
A left rotation operation on an array shifts each element of the array to the left by a certain number of positions. Given an array of integers and a number of left rotations, perform the rotation operation on the array.

## Examples:
```
Example 1:
Input: arr = [1, 2, 3, 4, 5], rotations = 1
Output: [2, 3, 4, 5, 1]
Explanation: After 1 rotation, the first element becomes the last.

Example 2:
Input: arr = [1, 2, 3, 4, 5], rotations = 2
Output: [3, 4, 5, 1, 2]
Explanation: After 2 rotations, the first 2 elements become the last 2.
```

## Constraints:
- 1 <= n <= 10^5 (where n is the array length)
- 1 <= d <= n (where d is the number of rotations)
- The elements of the array are integers

## Solution Approaches
The solution implements two different approaches for left rotation:

1. **Reverse-Based Approach** (`RotateLeft`):
   - First reverse the entire array
   - Then reverse the first (n-shift) elements
   - Finally reverse the last 'shift' elements
   - Time Complexity: O(n) where n is the array length
   - Space Complexity: O(1) as it rotates the array in-place

2. **Copy-Based Approach** (`ShiftLeft`):
   - Copy the first 'shift' elements to a temporary array
   - Shift the remaining elements to the left
   - Append the temporary array to the end
   - Time Complexity: O(n) where n is the array length
   - Space Complexity: O(shift) for the temporary array

Both approaches handle the case where the number of rotations exceeds the array length by using the modulo operation to find the effective number of rotations.