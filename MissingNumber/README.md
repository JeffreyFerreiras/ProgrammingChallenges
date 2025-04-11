# 268. Missing Number

## Problem Description
Given an array `nums` containing `n` distinct numbers in the range [0, n], return the only number in the range that is missing from the array.

## Examples:
```
Example 1:
Input: nums = [3,0,1]
Output: 2
Explanation: n = 3 since there are 3 numbers, so all numbers are in the range [0,3]. 2 is the missing number in the range since it does not appear in nums.

Example 2:
Input: nums = [0,1]
Output: 2
Explanation: n = 2 since there are 2 numbers, so all numbers are in the range [0,2]. 2 is the missing number in the range since it does not appear in nums.

Example 3:
Input: nums = [9,6,4,2,3,5,7,0,1]
Output: 8
Explanation: n = 9 since there are 9 numbers, so all numbers are in the range [0,9]. 8 is the missing number in the range since it does not appear in nums.
```

## Constraints:
- n == nums.length
- 1 <= n <= 10^4
- 0 <= nums[i] <= n
- All the numbers of nums are unique.

## Solution Approaches
The solution implements two mathematical approaches to find the missing number:

1. **Sum of Natural Numbers Formula** (`MissingNumber_`):
   - Calculate the sum of all numbers from 0 to n using the formula `n * (n + 1) / 2`
   - Subtract the actual sum of the array
   - The difference is the missing number
   - Time Complexity: O(n)
   - Space Complexity: O(1)

2. **Using LINQ Range** (`MissingNumber`):
   - Generate a sequence from 1 to n using LINQ's `Enumerable.Range`
   - Sum this sequence
   - Subtract the actual sum of the array
   - The difference is the missing number
   - Time Complexity: O(n)
   - Space Complexity: O(n) due to LINQ's intermediate sequence creation

Both approaches fulfill the problem's follow-up requirement of using O(n) runtime complexity, with the first approach also achieving O(1) space complexity.

Note: There are other possible solutions not implemented here, such as:
- Using XOR operations
- Using a hash set to track missing values
- Sorting the array and finding the gap