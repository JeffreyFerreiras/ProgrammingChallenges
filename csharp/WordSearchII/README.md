# Word Search II

## Problem Statement

Given an `m x n` board of characters and a list of words, return all words that exist in the board.

A word can be formed by starting at any cell and moving to adjacent cells horizontally or vertically. The same cell cannot be used more than once in a single word.

## Example

Input:
- Board:
  - `o a a n`
  - `e t a e`
  - `i h k r`
  - `i f l v`
- Words: `["oath", "pea", "eat", "rain"]

Output:
- `["eat", "oath"]

## Constraints
- The board contains lowercase English letters.
- The number of words is manageable for practice.
- The solution is expected to be efficient enough to avoid exponential behavior for larger inputs.

## Edge Cases
- Empty word list.
- No matching words.
- Words that appear in multiple places.
- Repeated words in the input list.

## Practice Notes
The project includes a brute-force baseline and a runner that discovers and executes each public solution method through reflection.
