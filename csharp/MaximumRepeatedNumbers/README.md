# Maximum Repeated Numbers and Missing Numbers

## Problem Description
This project implements two main algorithmic challenges:

1. **Maximum Repeated Number**: Find the maximum value that appears more than once in an array of integers.
2. **Missing Number**: Find the missing number in a sequence of integers from 0 to n.

## Examples:
```
Example 1 (Maximum Repeated Number):
Input: [10, 20, 100, 100, 100, 10, 30, 20, 40, 50, 12, 14]
Output: 100
Explanation: The numbers that repeat are 10, 20, and 100. The maximum of these is 100.

Example 2 (Missing Number):
Input: [5, 4, 3, 1, 0]
Output: 2
Explanation: The sequence should contain all numbers from 0 to 5, but 2 is missing.
```

## Solution Approaches

### Maximum Repeated Number:

1. **HashSet Approach** (`FindMaxRepeat`):
   - Use a HashSet to track seen numbers
   - If a number is encountered again, check if it's the maximum repeated number so far
   - Time Complexity: O(n) where n is the length of the array
   - Space Complexity: O(n) for the HashSet

2. **Sorting Approach** (`FindMaxRepeat_SaveSpace`):
   - Sort the array (using Insertion Sort for small arrays)
   - Scan the sorted array for adjacent duplicate elements
   - Return the maximum duplicate found
   - Time Complexity: O(n²) for Insertion Sort, O(n log n) if using a more efficient sorting algorithm
   - Space Complexity: O(1) as it sorts in-place

### Missing Number:

1. **Sum Approach** (`FindMissing`):
   - Calculate the expected sum of a complete sequence using the formula n(n+1)/2
   - Calculate the actual sum of the array
   - The difference is the missing number
   - Time Complexity: O(n)
   - Space Complexity: O(1)

2. **Sorting Approach** (`FindMissing2`):
   - Sort the array
   - Scan for a gap in the sequence
   - Time Complexity: O(n log n) for sorting
   - Space Complexity: O(1) as it sorts in-place

The implementation includes some additional optimizations, like using Insertion Sort for small arrays which can be faster than QuickSort in such cases.