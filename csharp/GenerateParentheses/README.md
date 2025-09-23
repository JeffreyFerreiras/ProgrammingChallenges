# Generate Parentheses

## Problem Description

Given n pairs of parentheses, write a function to generate all combinations of well-formed (balanced) parentheses.

Return the list of all possible valid parentheses combinations in any order.

## Examples

Example 1

```text
Input: n = 3
Output: ["((()))","(()())","(())()","()(())","()()()"]
```

Example 2

```text
Input: n = 1
Output: ["()"]
```

## Constraints

- 1 <= n <= 8

## Approach

Use backtracking to build valid sequences incrementally. Maintain two counters: the number of open parentheses used and the number of close parentheses used. At each step:

- You may add an open parenthesis if open < n.
- You may add a close parenthesis if close < open.

When the current sequence length reaches 2 * n, append the sequence to the result list.

## Complexity

- Time: O(C_n) where C_n is the nth Catalan number (roughly O(4^n / (n^(3/2)))) — output-sensitive since we must generate all combinations.
- Space: O(n) recursion stack plus O(C_n * n) output space.

## Notes

- This is a classic combinatorics/backtracking problem commonly found on coding challenge sites.
- Implementations should avoid generating invalid prefixes to remain efficient.
