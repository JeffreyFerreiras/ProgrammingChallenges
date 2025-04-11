# 39. Combination Sum

## Problem Description
Given an array of distinct integers `candidates` and a target integer `target`, return a list of all unique combinations of candidates where the chosen numbers sum to `target`.

You may return the combinations in any order.

The same number may be chosen from candidates an unlimited number of times. Two combinations are unique if the frequency of at least one of the chosen numbers is different.

## Examples:
```
Example 1:
Input: candidates = [2,3,6,7], target = 7
Output: [[2,2,3],[7]]
Explanation:
2 + 2 + 3 = 7
7 = 7

Example 2:
Input: candidates = [2,3,5], target = 8
Output: [[2,2,2,2],[2,3,3],[3,5]]
Explanation:
2 + 2 + 2 + 2 = 8
2 + 3 + 3 = 8
3 + 5 = 8

Example 3:
Input: candidates = [2], target = 1
Output: []
Explanation: There are no valid combinations.
```

## Constraints:
- 1 <= candidates.length <= 30
- 1 <= candidates[i] <= 200
- All elements of candidates are distinct
- 1 <= target <= 500
- It is guaranteed that the number of unique combinations that sum up to target is less than 150 combinations for the given input

## Solution Approach
The solution uses a backtracking approach to find all valid combinations:

1. Sort the candidates array to optimize the backtracking process
2. Use a recursive function to explore all possible combinations
3. For each recursive call:
   - If the current sum equals the target, add the current combination to the result
   - If the current sum exceeds the target, stop exploring this path
   - Otherwise, try adding each candidate (allowing reuse) and continue recursion
4. To avoid duplicate combinations, only consider candidates at or after the current index

Time Complexity: O(N^(T/M)) where:
- N is the number of candidates
- T is the target value
- M is the minimum value among candidates

Space Complexity: O(T/M) for the recursion stack where T/M represents the maximum depth of recursion