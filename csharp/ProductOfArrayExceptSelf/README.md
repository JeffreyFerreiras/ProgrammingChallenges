# ProductOfArrayExceptSelf

This project solves the classic LeetCode problem: **Product of Array Except Self**.

## Problem
Given an integer array `nums`, return an array `answer` such that:

- `answer[i]` is the product of all the elements in `nums` except `nums[i]`.
- The solution must run in $O(n)$ time and use $O(1)$ extra space (excluding the output array).

## Approach
The implementation in `Solution.cs` uses a prefix/suffix product strategy:

1. Build the product of all elements to the left of each index.
2. Build the product of all elements to the right of each index.
3. Multiply the two sides to get the final result.

This avoids division and keeps the solution efficient for large inputs.

## Project Files
- `Program.cs` — sample runner and test cases
- `Solution.cs` — challenge solutions and variations
- `ProductOfArrayExceptSelf.csproj` — .NET project file

## Run
From the repository root:

```powershell
dotnet run --project "c:\dev\GitHub\ProgrammingChallenges\csharp\ProductOfArrayExceptSelf"
```

## Example
Input:

```text
[1, 2, 3, 4]
```

Output:

```text
[24, 12, 8, 6]
```
