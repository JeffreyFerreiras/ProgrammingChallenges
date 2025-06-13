# 141. Linked List Cycle

## Problem Description
Given the head of a linked list, determine if the linked list has a cycle in it.

A linked list is said to contain a cycle if any node is visited more than once while traversing the list. In other words, there is some node in the list that can be reached again by continuously following the next pointer.

## Examples:
```
Example 1:
Input: head = [3,2,0,-4], where -4 links back to 2
Output: true
Explanation: There is a cycle in the linked list, where the tail connects to the 1st node (0-indexed).

Example 2:
Input: head = [1,2], where 2 links back to 1
Output: true
Explanation: There is a cycle in the linked list, where the tail connects to the 0th node.

Example 3:
Input: head = [1], no cycle
Output: false
Explanation: There is no cycle in the linked list.
```

## Constraints:
- The number of nodes in the list is in the range [0, 10^4]
- -10^5 <= Node.val <= 10^5
- pos is -1 or a valid index in the linked-list

## Solution Approaches
The solution implements two different approaches to detect cycles in a linked list:

1. **Hash Set Approach** (`HasCycle`):
   - Use a HashSet to store references to nodes that have been visited
   - Traverse the linked list, adding each node to the HashSet
   - If a node is encountered that is already in the HashSet, there is a cycle
   - If the end of the list is reached (null), there is no cycle
   - Time Complexity: O(n) where n is the number of nodes
   - Space Complexity: O(n) for the HashSet

2. **Floyd's Tortoise and Hare Algorithm** (`HasCycle2`):
   - Use two pointers, a slow pointer (tortoise) and a fast pointer (hare)
   - The tortoise moves one step at a time, and the hare moves two steps
   - If there is a cycle, the hare will eventually catch up to the tortoise
   - If the hare reaches the end of the list (null), there is no cycle
   - Time Complexity: O(n) where n is the number of nodes
   - Space Complexity: O(1) as it uses only two pointers

The implementation also includes a helper method to create cycled linked lists for testing purposes. This method:
- Creates a linked list of a specified size with random values
- Randomly selects a node to be the cycle point
- Connects the last node to the selected node, forming a cycle