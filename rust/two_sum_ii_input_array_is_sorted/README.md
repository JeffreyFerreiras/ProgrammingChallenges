# Two Sum II - Input Array Is Sorted

## Problem Description

Given a **1-indexed** array of integers `numbers` that is already **sorted in non-decreasing order**, find two numbers such that they add up to a specific `target` number. Let these two numbers be `numbers[index1]` and `numbers[index2]` where `1 <= index1 < index2 <= numbers.length`.

Return *the indices of the two numbers*, `index1` and `index2`, **added by one** as an integer array `[index1, index2]` of length 2.

The tests are generated such that there is **exactly one solution**. You **may not** use the same element twice.

Your solution must use only constant extra space.

## Examples

### Example 1

```
Input: numbers = [2,7,11,15], target = 9
Output: [1,2]
Explanation: The sum of 2 and 7 is 9. Therefore, index1 = 1, index2 = 2. We return [1, 2].
```

### Example 2

```
Input: numbers = [2,3,4], target = 6
Output: [1,3]
Explanation: The sum of 2 and 4 is 6. Therefore index1 = 1, index2 = 3. We return [1, 3].
```

### Example 3

```
Input: numbers = [-1,0], target = -1
Output: [1,2]
Explanation: The sum of -1 and 0 is -1. Therefore index1 = 1, index2 = 2. We return [1, 2].
```

## Constraints

- `2 <= numbers.length <= 3 * 10^4`
- `-1000 <= numbers[i] <= 1000`
- `numbers` is sorted in **non-decreasing** order
- `-1000 <= target <= 1000`
- The tests are generated such that there is **exactly one solution**

## Key Points

- Array is **1-indexed** for the return values
- Array is already **sorted**
- Exactly **one solution** exists
- Must use **constant extra space**
- Cannot use the same element twice

## Solution Approach

Use the two-pointer technique with optimization:

1. Find optimal starting position for high pointer using binary search
2. Use two pointers: left starts at 0, right starts at optimized position
3. If sum equals target, return the indices (1-based)
4. If sum is less than target, move left pointer right
5. If sum is greater than target, move right pointer left

**Time Complexity:** O(log n + n) - Binary search for initial position + two-pointer traversal  
**Space Complexity:** O(1) - Only using constant extra space

## Running the Code

```bash
cargo build
cargo run
```

The program will run all test cases and display the results.
