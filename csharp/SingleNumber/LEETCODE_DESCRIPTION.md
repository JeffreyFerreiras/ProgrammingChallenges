# 136. Single Number

**Difficulty:** Easy  
**Topics:** Array, Bit Manipulation  
**Companies:** Amazon, Google, Apple, Microsoft

---

## Description

Given a **non-empty** array of integers `nums`, every element appears **twice** except for one. Find that single one.

You must implement a solution with linear runtime complexity and use only constant extra space.

---

## Examples

**Example 1:**
```
Input: nums = [2,2,1]
Output: 1
```

**Example 2:**
```
Input: nums = [4,1,2,1,2]
Output: 4
```

**Example 3:**
```
Input: nums = [1]
Output: 1
```

---

## Constraints

- `1 <= nums.length <= 3 * 10^4`
- `-3 * 10^4 <= nums[i] <= 3 * 10^4`
- Each element in the array appears twice except for one element which appears only once.

---

## Hints

<details>
<summary>Hint 1</summary>
Think about the properties of XOR. What happens when you XOR a number with itself? What about XOR with 0?
</details>

<details>
<summary>Hint 2</summary>
If you XOR all numbers in the array, the duplicates cancel out (a ^ a = 0) and you are left with the unique number.
</details>
