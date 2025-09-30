# Binary Tree Level Order Traversal

## Problem Statement
Given the root of a binary tree, return the level order traversal of its nodes' values (i.e., from left to right, level by level).

## Examples

**Example 1**
`
Input: root = [3,9,20,null,null,15,7]
Output: [[3],[9,20],[15,7]]
`

**Example 2**
`
Input: root = [1]
Output: [[1]]
`

**Example 3**
`
Input: root = []
Output: []
`

## Constraints
- The number of nodes in the tree is in the range [0, 2000].
- -1000 <= Node.val <= 1000

## Additional Scenarios
- **Edge Case:** Single node oot = [5] → Traversal is [[5]].
- **Left-heavy Tree:** oot = [1,2,null,3,null,4] → Levels grow deeper on the left only.
- **Right-heavy Tree:** oot = [1,null,2,null,3] → Each level contains a single node.
- **Complete Tree:** oot = [1,2,3,4,5,6,7] → Returns [[1],[2,3],[4,5,6,7]].
- **Large Example:** Depth 6 tree with mixed nulls and values ensures traversal correctly captures sparse levels.
