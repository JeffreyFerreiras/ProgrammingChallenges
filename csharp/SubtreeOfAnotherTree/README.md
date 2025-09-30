# Subtree of Another Tree

## Problem Statement
Given the roots of two binary trees oot and subRoot, return 	rue if there is a subtree of oot with the same structure and node values as subRoot. Otherwise, return alse.

## Examples

**Example 1**
`
Input: root = [3,4,5,1,2], subRoot = [4,1,2]
Output: true
`

**Example 2**
`
Input: root = [3,4,5,1,2,null,null,null,null,0], subRoot = [4,1,2]
Output: false
`

## Constraints
- The number of nodes in the trees is in the range [1, 2000].
- -10^4 <= Node.val <= 10^4

## Additional Scenarios
- **Edge Case:** oot and subRoot are single identical nodes → Result is 	rue.
- **Non-Matching Single Nodes:** oot = [1], subRoot = [2] → Result is alse.
- **Subtree at Leaf:** oot = [1,2,3,null,null,4,5], subRoot = [4,5] → Result is alse due to structure mismatch.
- **Matches Deep in Tree:** oot = [1,2,3,4,5,6,7,8,9,10], subRoot = [5,10] → Result is alse because missing right subtree.
- **Large Match:** oot containing a repeated pattern identical to subRoot higher in the tree should produce 	rue.
