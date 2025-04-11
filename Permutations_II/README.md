# 47. Permutations II

## Problem Description
Given a collection of numbers, `nums`, that might contain duplicates, return all possible unique permutations in any order.

## Examples
**Example 1:**
```
Input: nums = [1,1,2]
Output: [[1,1,2], [1,2,1], [2,1,1]]
```

**Example 2:**
```
Input: nums = [1,2,3]
Output: [[1,2,3], [1,3,2], [2,1,3], [2,3,1], [3,1,2], [3,2,1]]
```

## Constraints
- `1 <= nums.length <= 8`
- `-10 <= nums[i] <= 10`

## Solution Approach
The solution uses a backtracking approach with these key techniques:
- A HashSet is used to prevent duplicate permutations by avoiding the use of the same number multiple times at the same recursion level
- A visited array keeps track of which elements have been used in the current permutation
- Two solution implementations are provided, one using a counter dictionary and another using a seen set
- Time Complexity: O(n * n!) where n is the length of the input array
- Space Complexity: O(n) for recursion stack and auxiliary data structures