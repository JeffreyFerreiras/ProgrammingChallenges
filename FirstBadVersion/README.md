# 278. First Bad Version

## Problem Description
You are a product manager and currently leading a team to develop a new product. Unfortunately, the latest version of your product fails the quality check. Since each version is developed based on the previous version, all the versions after a bad version are also bad.

Suppose you have `n` versions `[1, 2, ..., n]` and you want to find out the first bad one, which causes all the following ones to be bad.

You are given an API `bool isBadVersion(version)` which returns whether `version` is bad. Implement a function to find the first bad version. You should minimize the number of calls to the API.

## Example:
```
Input: n = 5, bad = 4
Output: 4
Explanation:
call isBadVersion(3) -> false
call isBadVersion(5) -> true
call isBadVersion(4) -> true
Then 4 is the first bad version.
```

## Constraints:
- 1 <= bad <= n <= 2³¹ - 1

## Solution Approach
The solution implements a binary search algorithm to efficiently find the first bad version:

1. Initialize two pointers: `low` at 1 and `high` at `n`
2. While `low <= high`:
   - Calculate the middle point `mid` using `low + (high - low) / 2` to avoid integer overflow
   - Check if `mid` is a bad version using the API `isBadVersion(mid)`
   - If `mid` is a bad version, search in the left half (`high = mid - 1`)
   - If `mid` is not a bad version, search in the right half (`low = mid + 1`)
3. Return `low` as the first bad version

This binary search approach achieves:
- Time Complexity: O(log n) where n is the number of versions
- Space Complexity: O(1) as it uses constant extra space

The implementation is optimized to minimize the number of calls to the `isBadVersion` API and efficiently handles large version numbers by avoiding integer overflow when calculating the middle point.