# 328. Odd Even Linked List

## Problem Description
Given the head of a singly linked list, group all the nodes with odd indices together followed by the nodes with even indices, and return the reordered list.

The first node is considered odd, the second node is even, and so on.

Note that the relative order inside both the even and odd groups should remain as it was in the input.

## Examples:
```
Example 1:
Input: head = [1,2,3,4,5]
Output: [1,3,5,2,4]
Explanation: The first node (1) is odd, the second (2) is even, etc.
All odd-indexed nodes [1,3,5] come before all even-indexed nodes [2,4].

Example 2:
Input: head = [2,1,3,5,6,4,7]
Output: [2,3,6,7,1,5,4]
Explanation: The odd indices are 1, 3, 5, and the even indices are 0, 2, 4, 6.
```

## Constraints:
- n == number of nodes in the linked list
- 0 <= n <= 10^4
- -10^6 <= Node.val <= 10^6

## Solution Approaches
The solution implements two different approaches to reorder the linked list:

1. **Two-Pass Approach** (`OddEvenList`):
   - Find the last node of the list
   - Traverse the list, moving even-indexed nodes to the end
   - For each even node, create a new node at the end of the list
   - Skip the even node in the original position
   - Continue until reaching the original last node
   - Time Complexity: O(n) where n is the number of nodes
   - Space Complexity: O(n) for creating new nodes

2. **Two-Pointer Approach** (`OddEvenList2`):
   - Maintain two separate lists: one for odd-indexed nodes and one for even-indexed nodes
   - Traverse the original list, assigning nodes to the appropriate list
   - Connect the end of the odd list to the start of the even list
   - Return the head of the rearranged list
   - Time Complexity: O(n) where n is the number of nodes
   - Space Complexity: O(n) for creating new nodes for the even list

Both approaches preserve the relative order of nodes within each group (odd and even) while rearranging them according to the problem requirements.