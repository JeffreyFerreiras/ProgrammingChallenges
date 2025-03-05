# Reverse Linked List

## Problem Statement
Given the head of a singly linked list, reverse the list, and return the reversed list.

## Explanation
Reversing a linked list means changing the direction of the pointers so that every node points to its previous node instead of the next node.  
Aim to achieve the best time complexity O(n) and space complexity O(1).

## Examples

**Example 1:**
- Input: head = [1,2,3,4,5]
- Output: [5,4,3,2,1]

**Example 2:**
- Input: head = []
- Output: []

**Example 3:**
- Input: head = [1]
- Output: [1]

## Discussion
Consider both iterative and recursive solutions. The iterative approach typically uses a loop to adjust pointers in one pass. On the other hand, the recursive approach reverses the list by processing the nodes via recursive calls.

*Note:* The solution file contains stubbed methods that must be implemented.
