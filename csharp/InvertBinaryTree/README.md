# Invert Binary Tree

## Problem Statement
Given the root of a binary tree, invert the tree, and return its root. Inversion means swapping the left and right child of every node in the tree.

## Examples

**Example 1**
`
Input: root = [4,2,7,1,3,6,9]
Output: [4,7,2,9,6,3,1]
`

**Example 2**
`
Input: root = [2,1,3]
Output: [2,3,1]
`

**Example 3**
`
Input: root = []
Output: []
`

## Constraints
- The number of nodes in the tree is in the range [0, 100].
- -100 <= Node.val <= 100

## Additional Scenarios
- **Edge Case:** Single-node tree oot = [1] → Output is [1] because inversion does not change a single node.
- **Left-leaning Tree:** oot = [5,4,null,3,null,2,null,1] → After inversion, all nodes appear on the right.
- **Perfect Tree:** oot = [1,2,3,4,5,6,7] → Inversion swaps left/right at every level, producing [1,3,2,7,6,5,4].
- **Mixed Values:** oot = [10,-2,15,-3,null,12,20] → Inversion retains node values but mirrored positions.
