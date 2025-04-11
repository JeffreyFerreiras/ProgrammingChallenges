# 2. Add Two Numbers

## Problem Description
You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order, and each of their nodes contains a single digit. Add the two numbers and return the sum as a linked list.

You may assume the two numbers do not contain any leading zero, except the number 0 itself.

## Example 1:
```
Input: l1 = [2,4,3], l2 = [5,6,4]
Output: [7,0,8]
Explanation: 342 + 465 = 807.
```

## Example 2:
```
Input: l1 = [9,9,9,9,9,9,9], l2 = [9,9,9,9]
Output: [8,9,9,9,0,0,0,1]
Explanation: 9999999 + 9999 = 10009998.
```

## Constraints:
- The number of nodes in each linked list is in the range [1, 100].
- 0 <= Node.val <= 9
- It is guaranteed that the list represents a number that does not have leading zeros.

## Solution Approach
The solution uses an iterative approach to:
1. Traverse both linked lists simultaneously
2. Add corresponding digits along with any carry from the previous addition
3. Create a new node in the result linked list for each digit of the sum
4. Handle any remaining carry after both lists are processed

Time Complexity: O(max(n, m)) where n and m are the lengths of the input linked lists
Space Complexity: O(max(n, m)) for the result linked list