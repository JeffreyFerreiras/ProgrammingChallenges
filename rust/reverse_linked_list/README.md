# 206. Reverse Linked List (NeetCode, Rust)

Reverse the pointers of a singly linked list so that the head becomes the tail. Iterate through the nodes, flipping each 
ext pointer so the list reads in reverse while preserving all node values.

## Examples
`	ext
Input: head = [1,2,3,4,5]
Output: [5,4,3,2,1]

Input: head = []
Output: []
`

## Long Example
`	ext
Input: head = [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15]
Output: [15,14,13,12,11,10,9,8,7,6,5,4,3,2,1]
`

## Edge Cases
- Empty list should return None immediately.
- Single node list must still be handled without altering the node value.
- Lists containing duplicate values or negative integers remain valid.
- Extremely long lists require an O(1) auxiliary space solution to avoid stack overflow.

*Implementation is intentionally left as a 	odo!() in src/solution.rs.*
