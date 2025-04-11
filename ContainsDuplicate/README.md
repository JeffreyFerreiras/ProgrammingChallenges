# 217. Contains Duplicate

## Problem Description
Given an integer array `nums`, return `true` if any value appears at least twice in the array, and return `false` if every element is distinct.

## Examples:
```
Example 1:
Input: nums = [1,2,3,1]
Output: true

Example 2:
Input: nums = [1,2,3,4]
Output: false

Example 3:
Input: nums = [1,1,1,3,3,4,3,2,4,2]
Output: true
```

## Constraints:
- 1 <= nums.length <= 10^5
- -10^9 <= nums[i] <= 10^9

## Solution Approaches
The solution implements six different approaches to check for duplicates:

1. **Built-in Sort** (`ContainsDuplicate_NetSort`):
   - Uses Array.Sort() to sort the array
   - Checks adjacent elements for duplicates

2. **Selection Sort** (`ContainsDuplicate_SelectionSort`):
   - Implements selection sort algorithm
   - Checks for duplicates during the sorting process

3. **Insertion Sort** (`ContainsDuplicate_InsertionSort`):
   - Implements insertion sort algorithm
   - Returns true as soon as a duplicate is found during insertion

4. **Quick Sort** (`ContainsDuplicate_QuickSort`):
   - Implements quick sort algorithm
   - Detects duplicates during the partition step

5. **HashSet Approach 1** (`ContainsDuplicate_HashSet`):
   - Uses HashSet.Add() which returns false if the element already exists
   - Returns true as soon as a duplicate is detected

6. **HashSet Approach 2** (`ContainsDuplicate_HashSet2`):
   - Creates a HashSet from the array
   - Compares the size of the HashSet with the original array

The solution includes benchmarking code to compare the performance of all approaches. Generally, the HashSet approaches are the most efficient for large inputs, with O(n) time complexity, while the sorting approaches have O(n log n) time complexity.