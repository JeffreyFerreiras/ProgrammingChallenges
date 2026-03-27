# 211. Design Add and Search Words Data Structure

## Problem Statement
Design a data structure that supports adding new words and searching for strings.

Implement the `WordDictionary` class:
- `WordDictionary()` initializes the object.
- `AddWord(string word)` adds `word` to the data structure.
- `Search(string word)` returns `true` if there is any string in the data structure that matches `word`, where `.` can match any single letter.

## Example 1
```
Input:
["WordDictionary", "addWord", "addWord", "addWord", "search", "search", "search", "search"]
[[ ], ["bad"], ["dad"], ["mad"], ["pad"], ["bad"], [".ad"], ["b.."]]

Output:
[null, null, null, null, false, true, true, true]
```

## Constraints
- `1 <= word.length <= 25`
- `word` in `addWord` consists of lowercase English letters.
- `word` in `search` consists of `.` or lowercase English letters.
- There will be at most `10^4` calls to `addWord` and `search`.

## Notes
- `Solution.cs` is intentionally scaffolded only.
- `Program.cs` runs the standard example and reports `Not Implemented` until the solution is filled in.