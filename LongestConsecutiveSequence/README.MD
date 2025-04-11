# 128. Longest Consecutive Sequence

## Problem Description
Given an unsorted array of integers `nums`, return the length of the longest consecutive elements sequence.

You must write an algorithm that runs in O(n) time.

## Examples:
```
Example 1:
Input: nums = [100,4,200,1,3,2]
Output: 4
Explanation: The longest consecutive elements sequence is [1,2,3,4]. Therefore its length is 4.

Example 2:
Input: nums = [0,3,7,2,5,8,4,6,0,1]
Output: 9
Explanation: The longest consecutive elements sequence is [0,1,2,3,4,5,6,7,8]. Therefore its length is 9.
```

## Constraints:
- 0 <= nums.length <= 10^5
- -10^9 <= nums[i] <= 10^9

## Solution Approach
To achieve O(n) time complexity, the optimal approach uses a HashSet:

1. Convert the input array to a HashSet for O(1) lookups
2. Iterate through each number in the HashSet
3. For each number, check if it's the start of a sequence (i.e., if num-1 is not in the HashSet)
4. If it is a start, count the consecutive sequence (num+1, num+2, etc.)
5. Track the longest sequence found

This approach ensures:
- Each number is processed only once
- Time Complexity: O(n) where n is the length of the array
- Space Complexity: O(n) for the HashSet

The implementation includes comprehensive test cases covering various scenarios:
- Mixed sequences with gaps
- Complete consecutive sequences
- Sequences with duplicates
- Edge cases like empty arrays

Performance is measured using a Stopwatch to track execution time for each test case.
