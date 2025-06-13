# Meta Interview Preparation - March 2025

## Problem Description
This project contains coding solutions for common Meta (Facebook) interview questions, focusing on:

1. **Find the kth Largest Element in an Array**: 
   Given an unsorted array and a value k, find the kth largest element in the array.

## Example:
```
Example for kth Largest Element:
Input: array = [-1,1,3,4,-2], k = 1
Output: 4
Explanation: The 1st largest element is 4

Input: array = [-1,1,3,4,-2], k = 4
Output: -1
Explanation: The 4th largest element is -1
```

## Solution Approaches

### Finding kth Largest Element:

1. **Sorting Approach**:
   - Sort the array in ascending order
   - Return the element at index (array.length - 1 - k)
   - Time Complexity: O(n log n) where n is the array length
   - Space Complexity: O(1) as it sorts in-place

2. **Priority Queue (Min-Heap) Approach**:
   - Maintain a min-heap of size k
   - For each element in the array:
     - If the heap size is less than k, add the element
     - If the element is greater than the smallest element in the heap, replace the smallest element
   - The smallest element in the heap after processing the array is the kth largest element
   - Time Complexity: O(n log k) where n is the array length
   - Space Complexity: O(k) for the heap

### Additional Utility Functions:
The project also includes a utility method for deep cloning a dictionary of arrays, which can be useful for graph-related problems:
- `Clone(Dictionary<int, int[]> input)`: Creates a deep copy of a dictionary containing arrays

This project represents preparation for technical interviews at Meta, focusing on common algorithmic challenges and data structure manipulations.