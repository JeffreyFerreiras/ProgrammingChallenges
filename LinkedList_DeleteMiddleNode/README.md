# Delete Middle Node from a Linked List

## Problem Description
Write a function to delete a node in the middle (i.e., any node but the first and last node) of a singly linked list, given only access to that node.

The solution should copy the data from the next node to the current node and then delete the next node, effectively removing the current node from the list.

## Example:
```
Input: The node with value 6 in the linked list [5 -> 6 -> 9]
Output: Resulting linked list [5 -> 9]
Explanation: Since we only have access to the node with value 6, we copy the value of the next node (9) to the current node and then remove the next node.
```

## Constraints:
- The node to be deleted is not the tail of the list (it is guaranteed to have a next node)
- The node to be deleted is available as a function parameter (we don't have access to the head of the list)
- The linked list has at least two nodes

## Solution Approach
The solution uses a clever approach to delete a node from a linked list when only given that node:

1. Copy the value from the next node to the current node
2. Set the current node's next pointer to the next node's next pointer
3. This effectively makes the current node "become" the next node, and the original next node is skipped

This approach works because:
- We're essentially replacing the current node's value with the next node's value
- Then we're removing the next node from the list
- From the perspective of the list, it looks like the current node was deleted

Time Complexity: O(1) - The operation is constant time as it only involves reassigning pointers
Space Complexity: O(1) - No extra space is used

The implementation includes a simple Node class with methods to:
- Add nodes to the list
- Find a node by value
- Print the list contents