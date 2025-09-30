# Count Good Nodes in Binary Tree

## Problem Statement
Given the root of a binary tree, return the number of nodes where the node's value is greater than or equal to every value on the path from the root to that node. Such nodes are called "good" nodes.

## Examples

**Example 1**
`
Input: root = [3,1,4,3,null,1,5]
Output: 4
`

**Example 2**
`
Input: root = [3,3,null,4,2]
Output: 3
`

**Example 3**
`
Input: root = [1]
Output: 1
`

## Constraints
- The number of nodes in the tree is in the range [1, 10^5].
- -10^4 <= Node.val <= 10^4

## Additional Scenarios
- **Edge Case:** Single node oot = [7] → Count is 1.
- **Strictly Decreasing Path:** oot = [5,4,null,3,null,2,null,1] → Only the root is good, count 1.
- **Strictly Increasing Path:** oot = [1,null,2,null,3,null,4] → Every node is good, count equals node count.
- **Mixed Values:** oot = [2,2,2,1,3,2,5] → Must compare along each path respecting running maximum.
- **Large Balanced Tree:** Balanced tree of height 7 with repeating values demonstrates handling of deep recursion.
