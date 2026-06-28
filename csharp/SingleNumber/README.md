# Single Number

## Problem Statement

Given a non-empty array of integers `nums`, every element appears **exactly twice** except for one. Find that single one.

You must implement a solution with linear runtime complexity and ideally use only constant extra space.

---

## Examples

**Example 1:**
```
Input:  nums = [2, 2, 1]
Output: 1
```

**Example 2:**
```
Input:  nums = [4, 1, 2, 1, 2]
Output: 4
```

**Example 3:**
```
Input:  nums = [1]
Output: 1
```

**Example 4:**
```
Input:  nums = [2, 2, 1, 1, 3]
Output: 3
```

---

## Constraints

- `1 <= nums.length <= 3 * 10^4`
- `-3 * 10^4 <= nums[i] <= 3 * 10^4`
- Each element in `nums` appears **exactly twice** except for one element which appears **exactly once**.

---

## Edge Cases

| Input | Output | Notes |
|-------|--------|-------|
| `[1]` | `1` | Single element array |
| `[-1, -1, -2]` | `-2` | Negative numbers |
| `[0, 0, 5]` | `5` | Zero in array |
| `[3, 1, 3]` | `1` | Single appears between duplicates |
| `[1, 2, 1]` | `2` | Single in the middle |

---

## Approaches

### 1. Brute Force — O(n²) time, O(1) space
For each element, scan the rest of the array to see if a duplicate exists.

### 2. Hash Map — O(n) time, O(n) space
Count occurrences of each element. Return the one with count == 1.

### 3. XOR Trick — O(n) time, O(1) space ⭐
XOR of a number with itself is 0. XOR of a number with 0 is itself.
XOR-ing all elements cancels out duplicates, leaving only the single number.

```
a ^ a = 0
a ^ 0 = a
a ^ b ^ a = b
```

---

## Practice Example (Walk-Through)

**Input:** `[4, 1, 2, 1, 2]`

**XOR Approach:**
```
Start:  result = 0
Step 1: result = 0 ^ 4 = 4       (binary: 100)
Step 2: result = 4 ^ 1 = 5       (binary: 101)
Step 3: result = 5 ^ 2 = 7       (binary: 111)
Step 4: result = 7 ^ 1 = 6       (binary: 110)
Step 5: result = 6 ^ 2 = 4       (binary: 100)
Output: 4
```

The duplicates cancel each other out via XOR, leaving only `4`.

---

## Related Problems

- LeetCode 260 — Single Number III (two non-repeating elements)
- LeetCode 137 — Single Number II (elements appear 3 times except one)
