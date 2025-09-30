# 981. Time Based Key-Value Store (Rust)

## Problem
Design a key-value store that can set a value with a timestamp and retrieve the latest value at or before a query timestamp. Operations:
- `set(key, value, timestamp)` saves the value under the key at the given timestamp. Timestamps for each key are strictly increasing.
- `get(key, timestamp)` returns the value mapped to the key with the greatest timestamp not exceeding the query. If none exists, return an empty string.

The expected complexity per operation is `O(log n)` with respect to the number of updates for the key.

## Examples
- **Example 1**
  - Calls: `["TimeMap","set","get","get","set","get","get"]`
  - Arguments: `[[],["foo","bar",1],["foo",1],["foo",3],["foo","bar2",4],["foo",4],["foo",5]]`
  - Output: `[null,null,"bar","bar",null,"bar2","bar2"]`
- **Example 2**
  - Querying before anything is set should produce an empty string.

## Edge Cases and Long Examples
- Interleaving updates on several keys with queries that hit different historical values.
- Requests for timestamps earlier than the first update for a key (expected empty string).
- Dense timelines with dozens of successive timestamps for the same key to validate logarithmic lookups. The harness creates 20 timestamps and queries at the exact time and the next second.

## Constraints
- `1 <= key.len(), value.len() <= 100`
- `1 <= timestamp <= 10^7`
- Timestamps for each key strictly increase.
- Up to `2 * 10^5` operations overall.

## Implementation Notes
- Implement `Solution::create_time_map` so it returns a `TimeMap` that stores per-key sorted timestamp/value pairs. Complete `TimeMap::set` and `TimeMap::get` with a binary search.
- `src/main.rs` defines operation sequences, uses `Instant` to time them (milliseconds with four decimal places), and prints the resulting list of responses beside the expected outputs. The solution currently calls `todo!()` in each method.
