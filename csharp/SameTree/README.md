# Same Tree

## Problem Statement
Given the roots of two binary trees p and q, write a function to check if they are the same or not. Two binary trees are considered the same if they are structurally identical and the nodes have the same value.

## Examples

**Example 1**
`
Input: p = [1,2,3], q = [1,2,3]
Output: true
`

**Example 2**
`
Input: p = [1,2], q = [1,null,2]
Output: false
`

**Example 3**
`
Input: p = [1,2,1], q = [1,1,2]
Output: false
`

## Constraints
- The number of nodes in both trees is in the range [0, 100].
- -10^4 <= Node.val <= 10^4

## Additional Scenarios
- **Edge Case:** Both trees empty p = [], q = [] → Result is 	rue.
- **Single Node Difference:** p = [1], q = [2] → Result is alse.
- **Different Structure:** p = [1,2,3,null,4], q = [1,2,3,4] → Result is alse due to level mismatch.
- **Large Identical Trees:** Matching complete binary trees of height 5 remain 	rue.
- **Value Mismatch Late in Tree:** p = [5,5,5,5,6], q = [5,5,5,5,7] → Result is alse because of a subtle leaf difference.
