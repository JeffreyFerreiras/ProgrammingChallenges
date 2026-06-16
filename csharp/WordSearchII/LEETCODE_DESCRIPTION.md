# Word Search II

You are given an `m x n` board of characters and a list of words. Return all words that are present on the board.

A word can be formed by starting from any cell and moving to adjacent cells in the four cardinal directions: up, down, left, and right. You may not reuse the same cell within a single word.

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
- The board is made of lowercase English letters.
- Words are lowercase strings.
- The solution should avoid inefficient repeated traversal when possible.
