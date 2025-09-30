# Binary Tree Maximum Path Sum

## Problem Statement
Given the root of a non-empty binary tree, return the maximum path sum. A path is defined as any sequence of nodes from some starting node to any node in the tree along the parent-child connections. The path must contain at least one node and does not need to go through the root.

## Examples

**Example 1**
`
Input: root = [1,2,3]
Output: 6
`

**Example 2**
`
Input: root = [-10,9,20,null,null,15,7]
Output: 42
`

## Constraints
- The number of nodes in the tree is in the range [1, 3 * 10^4].
- -1000 <= Node.val <= 1000

## Additional Scenarios
- **Edge Case:** Single node oot = [-3] → Maximum path sum is the node value itself.
- **All Negative:** oot = [-2,-1] → Maximum path uses the least negative node.
- **Mixed Values:** oot = [5,4,8,11,null,13,4,7,2,null,null,5,1] → Maximum path crosses multiple levels.
- **Skewed Tree:** Long single path where maximum sum equals the sum over the skew.
- **Balanced Deep Tree:** Combination of positives and negatives ensures algorithm handles branching decisions.
