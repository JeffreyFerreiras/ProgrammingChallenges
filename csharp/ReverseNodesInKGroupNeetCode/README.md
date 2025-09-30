# 25. Reverse Nodes In K Group (NeetCode)

Reverse nodes in a linked list in groups of size k. If the number of nodes remaining is less than k, leave that tail segment in place. The algorithm typically iterates while there are at least k nodes left, reverses the block, and relinks the boundaries.

## Examples
`	ext
Input: head = [1,2,3,4,5], k = 2
Output: [2,1,4,3,5]

Input: head = [1,2,3,4,5], k = 3
Output: [3,2,1,4,5]
`

## Long Example
`	ext
Input: head = [1,2,3,4,5,6,7,8,9,10,11,12], k = 4
Output: [4,3,2,1,8,7,6,5,12,11,10,9]
`

## Edge Cases
- When k equals 1 the list remains unchanged.
- Partial groups smaller than k stay in their original order.
- Ensure pointer bookkeeping does not lose the next segment during reversal.
- Very long lists require an iterative solution to avoid recursion depth limits.

*Implementation is intentionally left as an exercise in Solution.cs.*
