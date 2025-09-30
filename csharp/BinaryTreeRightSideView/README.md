# Binary Tree Right Side View

## Problem Statement
Given the root of a binary tree, imagine yourself standing on the right side of it. Return the values of the nodes you can see ordered from top to bottom.

## Examples

**Example 1**
`
Input: root = [1,2,3,null,5,null,4]
Output: [1,3,4]
`

**Example 2**
`
Input: root = [1,null,3]
Output: [1,3]
`

**Example 3**
`
Input: root = []
Output: []
`

## Constraints
- The number of nodes in the tree is in the range [0, 2000].
- -100 <= Node.val <= 100

## Additional Scenarios
- **Edge Case:** Single node oot = [7] → Right side view is [7].
- **Left-heavy Tree:** oot = [1,2,null,3,null,4,null,5] → Right side view is [1,2,3,4,5] because each level only has left child.
- **Full Tree:** oot = [1,2,3,4,5,6,7] → Right side view is [1,3,7].
- **Sparse Tree:** oot = [1,2,3,null,5,null,null,null,null,4] → Right side view is [1,3,4].
- **Wide Level:** oot containing mixed nulls at lower levels ensures the algorithm correctly picks the visible node per level.
