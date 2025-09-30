# 704. Binary Search (Rust)

## Problem
Given a strictly ascending array `nums` and an integer `target`, return the index where `target` is stored or `-1` if the element is absent. The algorithm must run in logarithmic time, so a classical binary search approach is required.

## Examples
- **Example 1**: `nums = [-1,0,3,5,9,12]`, `target = 9` ? `4`
- **Example 2**: `nums = [-1,0,3,5,9,12]`, `target = 2` ? `-1`

## Edge Cases and Long Examples
- Single-element arrays with and without matches (`[5]` ? `0`, `[5]` with `target = -5` ? `-1`).
- Arrays containing negative values, e.g. `[-15,-9,-4,0,12,18,27]` with `target = -4` ? `2`.
- Large monotonic sequences with hundreds of thousands of entries to exercise the logarithmic behaviour. The harness builds 200,001 integers from `-100,000` to `100,000` and searches for `54,321`.

## Constraints
- `1 <= nums.len() <= 10^4`
- `-10^4 <= nums[i], target <= 10^4`
- `nums` is strictly increasing.

## Implementation Notes
- Implement `Solution::search` with a binary search loop or recursion.
- `src/main.rs` enumerates several scenarios, measures execution time using `Instant`, and prints the method name, elapsed milliseconds (four decimal places), the returned value (or panic message), and the expected result. The solution currently calls `todo!()` so you can complete the logic.
