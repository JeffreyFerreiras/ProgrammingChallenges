# 15. 3Sum

## Problem Description
Given an integer array `nums`, return all the triplets `[nums[i], nums[j], nums[k]]` such that `i != j`, `i != k`, and `j != k`, and `nums[i] + nums[j] + nums[k] == 0`.

Notice that the solution set must not contain duplicate triplets.

## Example 1:
```
Input: nums = [-1,0,1,2,-1,-4]
Output: [[-1,-1,2],[-1,0,1]]
```

## Example 2:
```
Input: nums = []
Output: []
```

## Example 3:
```
Input: nums = [0]
Output: []
```

## Constraints:
- 0 <= nums.length <= 3000
- -10^5 <= nums[i] <= 10^5

## Solution Approaches
The solution implements two different approaches to find all unique triplets in the array that sum to zero. The challenge lies in avoiding duplicate triplets while ensuring the indices are distinct. The implementation handles edge cases such as empty arrays and arrays with many identical elements (like arrays containing many zeros).

Key techniques used:
- Sorting the array to facilitate finding the triplets
- Using two-pointer technique to find pairs that sum to the desired value
- Implementing logic to skip duplicate values to avoid duplicate triplets