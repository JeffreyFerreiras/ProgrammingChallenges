# Big Sorting

## Problem Description
Consider an array of numeric strings, where each string is a positive number with anywhere from 0 to N digits. Sort the array's elements in non-decreasing (i.e., ascending) order of their real-world integer values and print each element of the sorted array on a new line.

The challenge is to properly sort very large integer values that might exceed the capacity of standard integer data types.

## Examples:
```
Input:
[
  "6",
  "31415926535897932384626433832795",
  "1",
  "3",
  "10",
  "3",
  "5"
]

Output (sorted):
[
  "1",
  "3",
  "3",
  "5",
  "6",
  "10",
  "31415926535897932384626433832795"
]
```

## Constraints:
- Each string is guaranteed to represent a positive integer
- There may be numbers with leading zeros
- Array elements can include very large integers that cannot be stored in regular integer data types
- The array may contain null or empty strings that need to be handled

## Solution Approach
The solution implements a custom quicksort algorithm to sort the strings:

1. **Custom Comparison Logic**:
   - Compare strings first by length (shorter strings are smaller numbers)
   - For equal-length strings, compare character by character
   - Handle null or empty strings properly

2. **Quicksort Implementation**:
   - Use a recursive divide-and-conquer approach
   - Partition the array around a pivot element
   - Sort each partition independently

This approach avoids integer overflow issues that would occur when parsing very large numeric strings into integer types, making it suitable for sorting arrays containing extremely large numbers.