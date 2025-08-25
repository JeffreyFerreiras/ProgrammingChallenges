# 3 Sum

This crate contains a small Rust solution for the classic "3 Sum" problem (LeetCode 15).

## Problem

Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that:

- i, j, and k are distinct indices
- nums[i] + nums[j] + nums[k] == 0

The solution must not contain duplicate triplets. Triplets in the output may appear in any order.

## Contract

- Input: a vector of integers (`Vec<i32>`)
- Output: a vector of triplets (`Vec<Vec<i32>>`) where each inner vector has length 3 and sums to zero
- Error modes: none (function returns an empty vector when no triplets exist)
- Success: returns all unique triplets that sum to zero

## Complexity

- Time: O(n^2) expected (sorting + two-pointer scan)
- Space: O(1) extra (ignoring output storage)

## Examples (matching `src/main.rs` scenarios)

1) nums = [-1, 0, 1, 2, -1, -4]
   - Expected output (order may differ): [[-1, -1, 2], [-1, 0, 1]]

2) nums = [0, 0, 0]
   - Expected output: [[0, 0, 0]]

3) nums = []
   - Expected output: []

4) nums = [1, 2, -2, -1]
   - Expected output: []

## How to run

From the `_3_sum` directory run:

```powershell
cargo run
```

The `src/main.rs` includes a few scenarios and compares the function output with expected results, printing a check mark (✓) for passing scenarios or an X (✗) for failing ones.

## Notes

- The implementation in `src/solution.rs` uses sorting and the two-pointer technique to find unique triplets efficiently.
- If you want to add more test cases, update `src/main.rs` or write unit tests in `tests/`.

---

File created: `README.md` — describes the challenge and how to run the project.
