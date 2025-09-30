# 19. Remove Nth Node From End of List (NeetCode)

Remove the node that sits 
 positions from the end of a singly linked list and return the new head. The typical solution uses two pointers separated by 
 steps so the front pointer lands on the node to delete.

## Examples
`	ext
Input: head = [1,2,3,4,5], n = 2
Output: [1,2,3,5]

Input: head = [1], n = 1
Output: []
`

## Long Example
`	ext
Input: head = [1,2,3,4,5,6,7,8,9,10], n = 10
Output: [2,3,4,5,6,7,8,9,10]
`

## Edge Cases
- Removing the head requires carefully updating the return pointer.
- 
 may equal the list length or be one.
- Lists with duplicate values should only drop the correct positional node.
- Validate input to avoid undefined behavior when 
 is out of range.

*Implementation is intentionally left as an exercise in Solution.cs.*
