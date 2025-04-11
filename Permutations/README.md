# Permutations

## Problem Description
This program solves LeetCode problem #46, which requires generating all possible permutations of a given array of distinct integers.

## Implementation
The solution implements a backtracking algorithm to generate all permutations:

1. A recursive function `Permute` is used to build permutations step by step
2. For each recursion level, we:
   - Select an element from the remaining numbers
   - Remove it from the remaining elements
   - Add it to the current permutation prefix
   - Recursively generate permutations for the remaining elements
   - Backtrack by removing the element from the prefix and adding it back to the remaining elements

### Key Components
- `Permute(int[] nums)`: The main function that initiates the permutation generation
- `Permute(IList<int> prefix, IList<int> remaining, IList<IList<int>> collector)`: The recursive helper function
- The algorithm uses a "prefix" list to build the current permutation
- The "remaining" list keeps track of available elements
- The "collector" stores all generated permutations

### Time and Space Complexity
- Time Complexity: O(n!), where n is the number of elements in the array
- Space Complexity: O(n!) to store all permutations

## Example
```
Input: [1,2,3]
Output:
[
  [1,2,3],
  [1,3,2],
  [2,1,3],
  [2,3,1],
  [3,1,2],
  [3,2,1]
]
```

## Notes
- The solution handles arrays of distinct integers
- The approach preserves the original order of elements in the array
- This is a classic application of the backtracking algorithm pattern