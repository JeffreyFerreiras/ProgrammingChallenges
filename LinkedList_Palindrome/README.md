# 234. Palindrome Linked List

## Problem Description
Given the head of a singly linked list, determine if it is a palindrome.

A palindrome is a sequence that reads the same forward and backward. For a linked list, this means the values from the first node to the last node should match the values from the last node to the first node.

## Examples:
```
Example 1:
Input: head = [1,2,2,1]
Output: true
Explanation: Reading from left to right: 1->2->2->1
Reading from right to left: 1->2->2->1
The sequence is the same in both directions, so it's a palindrome.

Example 2:
Input: head = [1,2]
Output: false
Explanation: Reading from left to right: 1->2
Reading from right to left: 2->1
The sequence is different, so it's not a palindrome.
```

## Constraints:
- The number of nodes in the list is in the range [1, 10^5]
- 0 <= Node.val <= 9

## Solution Approach
While the specific implementation details aren't fully visible, palindrome checking in a linked list typically uses one of these approaches:

1. **Convert to Array**:
   - Traverse the linked list and store each node's value in an array
   - Check if the array is a palindrome using two pointers
   - Time Complexity: O(n)
   - Space Complexity: O(n)

2. **Reverse Second Half**:
   - Find the middle of the linked list using a slow and fast pointer
   - Reverse the second half of the linked list
   - Compare the first half with the reversed second half
   - Time Complexity: O(n)
   - Space Complexity: O(1)

3. **Recursive Approach**:
   - Use recursion to reach the end of the list
   - Compare nodes starting from both ends moving inward
   - Time Complexity: O(n)
   - Space Complexity: O(n) for the recursion stack

The implementation includes test cases for both palindrome and non-palindrome inputs, demonstrating the solution's capability to correctly identify each case.