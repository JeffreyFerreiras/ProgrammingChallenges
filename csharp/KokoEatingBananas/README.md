# 875. Koko Eating Bananas (C#)

## Problem
Koko is given an array `piles` where each element represents a stack of bananas. Each hour she chooses exactly one pile and eats up to `k` bananas from it. If the pile contains fewer than `k` bananas she finishes it and waits for the next hour. Return the minimum integer `k` such that Koko can eat every pile within `h` hours. The expected runtime is `O(n log m)` where `m` is the largest pile size.

## Examples
- **Example 1**
  - Input: `piles = [3,6,7,11]`, `h = 8`
  - Output: `4`
- **Example 2**
  - Input: `piles = [30,11,23,4,20]`, `h = 5`
  - Output: `30`
- **Example 3**
  - Input: `piles = [30,11,23,4,20]`, `h = 6`
  - Output: `23`

## Edge Cases and Long Examples
- Single huge pile where `h = 1`, e.g. `piles = [1_000_000_000]` ? `k = 1_000_000_000`.
- Many identical tiny piles with more time than piles, e.g. `piles = [5, ..., 5] (30 times)`, `h = 60` ? `k = 3`.
- Thousands of piles with steadily increasing sizes; the harness creates 5,000 piles with a common difference of five and finishes them in exactly 5,000 hours, forcing `k` to match the maximum pile size (`24,996`).

## Constraints
- `1 <= piles.length <= 10^4`
- `piles[i]` is in `[1, 10^9]`
- `1 <= h <= 10^9`

## Implementation Notes
- Implement `Solution.MinEatingSpeed(int[] piles, int h)` using binary search over the candidate speed.
- `Program.cs` lists several scenarios, measures the execution time (milliseconds with four decimal places), and prints the returned speed next to the expected answer. The solution method currently throws so you can provide the algorithm yourself.
