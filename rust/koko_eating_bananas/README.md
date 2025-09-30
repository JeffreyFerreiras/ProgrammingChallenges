# 875. Koko Eating Bananas (Rust)

## Problem
Koko receives an array `piles` in which each element denotes the number of bananas in a stack. Every hour she chooses one pile and eats up to `k` bananas from it. If the pile contains fewer bananas she finishes it and waits for the next hour. Return the minimum integer `k` such that Koko can finish all piles within `h` hours.

## Examples
- **Example 1**: `piles = [3,6,7,11]`, `h = 8` ? `4`
- **Example 2**: `piles = [30,11,23,4,20]`, `h = 5` ? `30`
- **Example 3**: `piles = [30,11,23,4,20]`, `h = 6` ? `23`

## Edge Cases and Long Examples
- Single huge pile with a one-hour deadline (`[1_000_000_000]`, `h = 1` ? `1_000_000_000`).
- Many identical small piles and plenty of time (`[5; 30]`, `h = 60` ? `3`).
- Thousands of piles with steadily increasing sizes tested by the harness (5,000 piles with step 5, `h = 5,000`, expected speed `24,996`).

## Constraints
- `1 <= piles.len() <= 10^4`
- `1 <= piles[i] <= 10^9`
- `1 <= h <= 10^9`

## Implementation Notes
- Implement `Solution::min_eating_speed` with a binary search on the speed and a helper that counts hours for a proposed speed.
- `src/main.rs` lists representative scenarios, measures execution time in milliseconds (four decimal digits), and prints the computed speed versus the expected value. The solution function currently calls `todo!()` so you can implement it.
