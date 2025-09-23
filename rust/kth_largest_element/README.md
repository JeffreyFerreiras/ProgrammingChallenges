# K-th Largest Element

This project solves the classic interview-style problem: given an unsorted list of integers, determine the k-th largest element.

## Problem Statement

Given a slice of integers `nums` and an integer `k`, return the k-th largest value within `nums`. If `k` is zero or larger than the length of the input, no answer exists.

## Approach

The solution maintains a min-heap containing the `k` largest elements seen so far. Each new value is pushed onto the heap; whenever the heap grows beyond `k`, the smallest element is removed. After the full iteration the heap's top is the k-th largest element. This strategy runs in `O(n log k)` time and uses `O(k)` additional space.

## Project Layout

- `src/solution.rs` exposes `kth_largest`, the reusable implementation.
- `src/main.rs` demonstrates the function by computing the 2nd largest element of a sample list.
- Unit tests for the algorithm live next to the implementation in `src/solution.rs`.

## Usage

```bash
cargo run
```

## Testing

```bash
cargo test
```
