# Implement Trie (Prefix Tree)

## Problem Statement
Implement a prefix tree, also known as a trie, to efficiently store and query strings.

Create a `PrefixTree` class that supports the following operations:
- `PrefixTree()` initializes the trie.
- `Insert(string word)` inserts a word into the trie.
- `Search(string word)` returns `true` if the exact word was inserted before.
- `StartsWith(string prefix)` returns `true` if any inserted word starts with the given prefix.

## Examples

**Example 1**
```
Input:
["Trie", "insert", "dog", "search", "dog", "search", "do", "startsWith", "do", "insert", "do", "search", "do"]

Output:
[null, null, true, false, true, null, true]
```

## Constraints
- `1 <= word.length, prefix.length <= 1000`
- `word` and `prefix` consist only of lowercase English letters.

## Notes
- This project currently contains only the class scaffold in `Solution.cs`.
- `Program.cs` is a minimal runner confirming the scaffold builds correctly.
- The trie methods intentionally throw `NotImplementedException` so the algorithm can be filled in later.