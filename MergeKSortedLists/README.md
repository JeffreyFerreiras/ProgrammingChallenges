# 23. Merge k Sorted Lists

## Problem Description
Given an array of `k` linked-list heads, where each linked list is sorted in ascending order, merge all the linked lists into one sorted linked list and return its head.

## Examples:
```
Example 1:
Input: lists = [[1,4,5],[1,3,4],[2,6]]
Output: [1,1,2,3,4,4,5,6]
Explanation: The linked-lists are:
[
  1->4->5,
  1->3->4,
  2->6
]
Merging them into one sorted list:
1->1->2->3->4->4->5->6

Example 2:
Input: lists = []
Output: []
Explanation: The input contains an empty list of linked lists.

Example 3:
Input: lists = [[]]
Output: []
Explanation: The input contains a single empty linked list.
```

## Constraints:
- k == lists.length
- 0 <= k <= 10^4
- 0 <= lists[i].length <= 500
- -10^4 <= lists[i][j] <= 10^4
- lists[i] is sorted in ascending order
- The sum of lists[i].length won't exceed 10^4

## Solution Approach
The solution uses a priority queue (min-heap) approach:

1. Create a priority queue to store nodes from all linked lists
2. Use a BFS approach to traverse all linked lists
3. Enqueue each node into the priority queue using its value as both the element and the priority
4. Dequeue nodes from the priority queue (smallest first) to build the merged sorted list
5. Time Complexity: O(N log k) where N is the total number of nodes and k is the number of linked lists
   - Each insertion and extraction from the priority queue takes O(log k) time
   - We process all N nodes once
6. Space Complexity: O(N) for storing all nodes in the priority queue

The implementation includes comprehensive test cases to verify correctness:
- Empty array of lists
- Array with one empty list
- Single non-empty list
- Multiple non-empty lists
- Edge case with an array containing an empty list

Performance is measured using a Stopwatch to track execution time for each test case.