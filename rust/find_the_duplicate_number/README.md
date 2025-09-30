# 287. Find The Duplicate Number (NeetCode, Rust)

Given an array of length 
 + 1 containing integers in the range [1, n], find the single repeated number without modifying the array and using only constant extra space. The classic approach treats the array as a linked list and applies Floyd’s cycle detection.

## Examples
`	ext
Input: nums = [1,3,4,2,2]
Output: 2

Input: nums = [3,1,3,4,2]
Output: 3
`

## Long Example
`	ext
Input: nums = [1,2,3,...,100,73]
Output: 73
`

## Edge Cases
- The duplicate can appear more than twice.
- The duplicate may be the smallest or largest value in the range.
- Arrays are guaranteed to have exactly one repeating value; do not rely on sorting.
- Solutions must run in O(n) time with O(1) extra space.

*Implementation is intentionally left as a 	odo!() in src/solution.rs.*
