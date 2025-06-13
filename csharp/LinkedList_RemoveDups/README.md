# Remove Duplicates from an Unsorted Linked List

## Problem Description
Write code to remove duplicates from an unsorted linked list.

**Follow up**: How would you solve this problem if a temporary buffer is not allowed?

## Examples:
```
Example 1:
Input: [9 -> 6 -> 6 -> 4 -> 6 -> 5 -> 8]
Output: [9 -> 6 -> 4 -> 5 -> 8]
Explanation: Removed all duplicate occurrences of 6.
```

## Constraints:
- The linked list can contain any number of elements
- The elements can be any integer values
- The linked list is unsorted

## Solution Approaches

1. **HashSet Approach** (Implemented):
   - Use a HashSet to track values that have been seen
   - Traverse the linked list, adding each value to the HashSet
   - If a node's value is already in the HashSet, remove that node
   - Time Complexity: O(n) where n is the number of nodes
   - Space Complexity: O(n) for the HashSet in the worst case

2. **No Temporary Buffer Approach** (Follow-up Challenge):
   - Use two pointers: a current pointer and a runner pointer
   - For each node (current), check all subsequent nodes (runner)
   - If any subsequent node has the same value, remove it
   - Time Complexity: O(n²) where n is the number of nodes
   - Space Complexity: O(1) as no additional data structures are used

The implementation in this project uses the first approach with a HashSet, providing an efficient O(n) solution at the cost of O(n) extra space.