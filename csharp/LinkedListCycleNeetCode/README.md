# 141. Linked List Cycle (NeetCode)

Determine whether a singly linked list contains a cycle by detecting if any node is revisited while following 
ext pointers. Floyd’s tortoise and hare algorithm is the standard O(1) space solution.

## Examples
`	ext
Input: head = [3,2,0,-4], pos = 1
Output: true

Input: head = [1], pos = -1
Output: false
`

## Long Example
`	ext
Input: head = [1,2,...,100], pos = 50
Output: true
`

## Edge Cases
- Empty lists have no cycle.
- Single-node lists may or may not form a self-loop.
- Large lists should terminate quickly when no cycle exists.
- Implement guards to avoid infinite traversal during debugging output.

*Implementation is intentionally left as an exercise in Solution.cs.*
