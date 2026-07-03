# LeetCode Standards Inventory

Audit date: 2026-07-03

Scope: C# challenge projects under this repository. Standards applied from the local `leetcode` skill: accepted/simple algorithm, edge-case handling, appropriate complexity for LeetCode-style constraints, no unnecessary abstraction or side effects, and representative runnable verification where a project includes a runner.

Verification performed:
- Used `rg` for repository-wide source scans.
- Split static review across four subagents by project range.
- Ran `dotnet build .\ProgrammingChallenges.sln --no-restore`: build passed with 0 errors and 71 warnings.
- Spot-checked conflicting subagent findings directly before including them.

Update 2026-07-03:
- Fixed 23 critical placeholder/missing primary solution entries.
- Re-ran `dotnet build .\ProgrammingChallenges.sln --no-restore`: build passed with 0 errors and 0 warnings after the first fix pass.

## Critical: incomplete or missing primary solution

These projects have a public primary entry point that is unimplemented, placeholder-only, or missing source.

| Project | Evidence | Issue |
| --- | --- | --- |
| CourseScheduleII | `CourseScheduleII/` | Folder is empty: no project source or runnable example. |
| DesignTwitter | `DesignTwitter/Solution.cs:9` | Solution and core operations throw `NotImplementedException`. |
| JumpGame | `JumpGame/Solution.cs:11` | Placeholder returns `false`. |
| JumpGameII | `JumpGameII/Solution.cs:11` | Placeholder returns `0`. |
| LongestIncreasingSubsequence | `LongestIncreasingSubsequence/Solution.cs:11` | Placeholder returns `0`. |
| ReverseNodesInKGroupNeetCode | `ReverseNodesInKGroupNeetCode/` | Folder contains only generated artifacts, no source project files. |
| WordSearchII | `WordSearchII/Solution.cs:41` | Primary optimized method throws `NotImplementedException`; brute-force fallback is not suitable for LeetCode II constraints. |

## Correctness or edge-case failures

These projects have implemented code, but the inspected primary path can produce wrong answers, exceptions, or invalid behavior.

| Project | Evidence | Issue |
| --- | --- | --- |
| 2Sum | `2Sum/Solution.cs:10`, `2Sum/Solution.cs:27` | Sorts and mutates input, then returns sorted-array indices instead of original indices. |
| AlmostPalindrome | `AlmostPalindrome/Program.cs:53`, `AlmostPalindrome/Program.cs:39` | Greedy mismatch handling can allow multiple deletions and does not test both remaining substrings; runner blocks on `ReadLine`. |
| AmazonAssessment | `AmazonAssessment/Program.cs:31`, `AmazonAssessment/Solution.cs:35` | Runnable path calls `maximumQuality`; median math is wrong due missing parentheses. |
| AnagramSubstring | `AnagramSubstring/Program.cs:31`, `AnagramSubstring/Program.cs:65` | Methods check character availability, not a contiguous anagram window. |
| BinTreeAsArrayFindLargestBranch | `BinTreeAsArrayFindLargestBranch/Program.cs:7`, `BinTreeAsArrayFindLargestBranch/Program.cs:23` | Runner is `Hello World`; algorithm alternates array indices instead of traversing branches/subtrees. |
| CheckIfStringContainsAllBinaryCodeOfSize | `CheckIfStringContainsAllBinaryCodeOfSize/Solution.cs:20`, `CheckIfStringContainsAllBinaryCodeOfSize/Program.cs:7` | Uses `k^2` instead of `2^k`; runner is `Hello World`. |
| CheckPermutations | `CheckPermutations/Program.cs:34` | Character table length is 25, so `z` can throw; no asserted output. |
| CheckSubarraySum | `CheckSubarraySum/Solution.cs:13`, `CheckSubarraySum/Program.cs:37` | Primary method divides by `k` without handling `k == 0`; runner calls that method. |
| ContainsDuplicate | `ContainsDuplicate/Program.cs:42`, `ContainsDuplicate/Solution.cs:110` | Benchmark-only harness blocks on `ReadKey`; public quicksort variant is unreliable. |
| DecodeWays | `DecodeWays/Program.cs:16`, `DecodeWays/Solution_Memoization.cs:4` | Memoization cache is shared across input strings, so the multi-case runner can return stale results. |
| DesignAddAndSearchWordsDataStructure | `DesignAddAndSearchWordsDataStructure/Solution.cs:43` | Wildcard search can return true for too-short patterns because final `.` only checks for any child, not word ending. |
| EncodeDecodeString | `EncodeDecodeString/Solution.cs:19`, `EncodeDecodeString/Solution.cs:34`, `EncodeDecodeString/Program.cs:2` | Encode joins with one delimiter and decode splits on another; encode also mutates input strings; runner is `Hello World`. |
| FindSmallestRange | `FindSmallestRange/Program.cs:24`, `FindSmallestRange/Program.cs:27` | Hard-coded to exactly three lists instead of k lists; sample result is not printed or validated. |
| IslandTreasure | `IslandTreasure/Solution.cs:15` | Iterates columns with `c < rows`, so rectangular grids are missed or indexed incorrectly; uses repeated DFS instead of standard multi-source BFS. |
| MarbleTest | `MarbleTest/Marbles.cs:67`, `MarbleTest/Marbles.cs:95` | Rounded random bucket counts have edge-case risk; all-zero ratios divide by zero; lacks deterministic validation. |
| MaximumRepeatedNumbers | `MaximumRepeatedNumbers/Program.cs:14`, `MaximumRepeatedNumbers/Program.cs:61` | `FindMissing2` misses the missing-zero edge case; runner discards computed results. |
| MinimalTree | `MinimalTree/Program.cs:20` | `Main` always throws due deliberate division by zero before example can run. |
| Palindrome Permutations | `Palindrome Permutations/Program.cs:49`, `Palindrome Permutations/Program.cs:53` | Character table length is 25 and non-letter characters map to `-1`, causing invalid indexing for `z` or punctuation. |
| PangramAlphabetChallenge | `PangramAlphabetChallenge/Program.cs:46` | Prompt says ignore non-US-ASCII, but `char.IsLetter` can accept non-ASCII and then index outside the 26-letter table. |
| PolygonMaking | `PolygonMaking/Program.cs:23`, `PolygonMaking/Program.cs:32` | Runner discards result; algorithm depends on input order and repeated `Sum()`/integer division, producing wrong cases. |
| ProductOfArrayExceptSelf | `ProductOfArrayExceptSelf/Solution.cs:5`, `ProductOfArrayExceptSelf/Solution.cs:12` | Primary method uses division and fails zero cases; accepted variant exists but is not the likely LeetCode entry point. |
| RansomNote | `RansomNote/Program.cs:34` | Missing ransom words are ignored, so absent-word cases can return `"Yes"`. |
| ReverseLinkedList | `ReverseLinkedList/Solution.cs:12` | Public .NET `LinkedList<T>` method is stubbed; iterative node reversal creates a self-cycle. |
| ReverseNodesInkGroup | `ReverseNodesInkGroup/Solution.cs:31` | Returns `null` when `k > length`; repeated tail scans make stitching inefficient. |
| SameTree | `SameTree/Solution.cs:21` | `p` can be null while `q` is non-null, causing a null dereference. |
| SetMatrixZeroes | `SetMatrixZeroes/Program.cs:12` | Primary method assumes square matrices and mishandles first row/column markers; no meaningful harness. |
| ShortestPathOfMaze | `ShortestPathOfMaze/Program.cs:54` | Uses DFS/first-found path, not guaranteed shortest path; boundary checks exclude index `0` moves. |
| StockPrices | `StockPrices/Program.cs:102` | `MaxProfit` skips the final day, so `[1,2]` returns `0` instead of `1`. |
| SumNumbersInArray | `SumNumbersInArray/Program.cs:39` | Methods contradict negative-number requirements; sorted path can underflow `high`, unsorted path skips values greater than target. |
| SumNumbersOneToN | `SumNumbersOneToN/Program.cs:26` | Iterative solution excludes `n` despite inclusive requirement. |
| Time_Complexity_Primality | `Time_Complexity_Primality/Program.cs:70` | Returns false for `3` because only `2` is special-cased before `% 3`. |
| WordSearch | `WordSearch/Solution.cs:17` | Primary `Exist` does not backtrack `chars`, so the path state is not correct; `Exist2` appears acceptable. |

## Complexity, API, or side-effect mismatches

These may pass small samples, but they miss the intended LeetCode pattern, required complexity, or clean API expectations.

| Project | Evidence | Issue |
| --- | --- | --- |
| BinaryTreeLevelOrderTraversal | `BinaryTreeLevelOrderTraversal/Solution.cs:54` | Traversal method writes to console as a side effect. |
| CountingBits | `CountingBits/Solution.cs:10`, `CountingBits/Program.cs:49` | Uses per-number bit counting instead of expected linear DP; harness blocks and does not assert results. |
| LongestSubstringWithoutRepeatingCharacters | `LongestSubstringWithoutRepeatingCharacters/Solution.cs:5`, `LongestSubstringWithoutRepeatingCharacters/Solution.cs:25` | Canonical method clears the window on duplicates rather than maintaining the expected O(n) sliding window; optimized variant exists but is not primary. |
| LowestCommonAncestorOfBST | `LowestCommonAncestorOfBST/Solution.cs:19` | Solves generic binary-tree LCA with full subtree recursion instead of using BST ordering, so complexity is `O(n)` rather than `O(h)`. |
| MedianOfTwoSortedArrays | `MedianOfTwoSortedArrays/README.md:4`, `MedianOfTwoSortedArrays/Solution.cs:53` | README calls for binary-search `O(log(m+n))`, but primary implementation linearly walks to the median. |
| MinStack | `MinStack/Solution.cs:18` | `Pop` recomputes minimum with `_stack.Min()`, so operations are not all `O(1)`. |
| PacificAtlanticWaterFlow | `PacificAtlanticWaterFlow/Solution.cs:17`, `PacificAtlanticWaterFlow/README.md:53` | Runs BFS from every cell, documented as `O(m^2 n^2)`; expected accepted approach is reverse traversal from both oceans in `O(mn)`. |
| PermutationInString | `PermutationInString/Solution.cs:9`, `PermutationInString/Solution.cs:31` | Primary method rebuilds substring and dictionary for every window; optimized variant exists but is not primary. |
| ShuffleDeckOfCards | `ShuffleDeckOfCards/Deck.cs:52` | Shuffle is biased repeated random swapping, not Fisher-Yates; no validation. |
| SurroundedRegions | `SurroundedRegions/Solution.cs:59` | Recursive DFS can overflow stack at the stated 200x200 constraint on a large border-connected region. |

## Weak or non-verifying runners

These projects appear to have plausible core logic, but the runnable example does not assert expected results, only prints/demoes, blocks on stdin, or does not exercise the algorithm. That falls short of the skill's verification expectation.

| Project | Evidence | Issue |
| --- | --- | --- |
| AddOne | `AddOne/Program.cs:22` | Edge cases are executed but not checked or printed. |
| AddTwoNumbers | `AddTwoNumbers/Program.cs:7` | Examples compute results but never print or verify them. |
| BigSorting | `BigSorting/Program.cs:46` | Harness prints output with no expected checks and includes invalid null/empty sample data. |
| Birthday Cake Candles | `Birthday Cake Candles/Program.cs:34` | Stdin-only harness has no self-contained runnable examples. |
| CloneGraph | `CloneGraph/Program.cs:30`, `CloneGraph/Program.cs:85` | Active harness only checks root value; structural/deep-copy cases are commented out. |
| CompressedString | `CompressedString/Program.cs:13` | Single demo has no expected result or edge coverage. |
| OneWay | `OneWay/Program.cs:13` | Runner only assigns booleans and provides no output/assertion. |
| Palindrome | `Palindrome/Program.cs:10` | Runner only assigns booleans and provides no output/assertion. |
| ProductOfHighest3Ints | `ProductOfHighest3Ints/Program.cs:13` | Runner computes one value without output/assertion. |
| ProductOfInts | `ProductOfInts/Program.cs:12`, `ProductOfInts/Program.cs:15` | Runner does not output/assert results; second expected comment is wrong for the input. |
| SearchInsert | `SearchInsert/Program.cs:1` | Algorithm function is never called; runner only prints `Hello, World!`. |

## Summary Counts

- Critical incomplete or missing primary solution: 7 projects.
- Correctness or edge-case failures: 32 projects.
- Complexity/API/side-effect mismatches: 10 projects.
- Weak or non-verifying runners: 11 projects.
- Total unique projects flagged: 60.
