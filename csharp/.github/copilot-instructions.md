# AI Coding Agent Instructions for ProgrammingChallenges (C#)

These guidelines help AI agents work productively in this repo.

## Big Picture
- Focus: Individual algorithm/problem solutions, each in its own folder. Most are self-contained console apps or small libraries.
- Structure: A top-level `ProgrammingChallenges.sln` references many per-problem projects under subfolders (e.g., `TwoSum/`, `ReverseLinkedList/`, `SerializeAndDeserializeBinaryTree/`). "NeetCode" variants and duplicates exist; treat them as separate implementations.
- Pattern: Each project typically contains `Program.cs` with a minimal runner, plus problem-specific classes (e.g., `ListNode`, `TreeNode`). Shared code is rare; prefer local types per project.

## Developer Workflows
- Build all projects:
  - VS Code task: `build` (runs `dotnet build ProgrammingChallenges.sln`).
  - Terminal: `dotnet build "c:\dev\GitHub\ProgrammingChallenges\csharp\ProgrammingChallenges.sln"`.
- Publish all (optional): VS Code task `publish`.
- Run a specific problem:
  - Use `dotnet run --project <project_dir>` from the repo root.
  - Example: `dotnet run --project "c:\dev\GitHub\ProgrammingChallenges\csharp\SerializeAndDeserializeBinaryTree"`.
- Watch (solution-level runner): VS Code task `watch` runs `dotnet watch run --project ProgrammingChallenges.sln`. Note: not all projects have runnable `Program.cs`; prefer running a specific project.

## Project Conventions
- Entry point: `Program.cs` demonstrates the algorithm with sample inputs; adjust locally per project if you need custom tests.
- Data types:
  - Linked list problems define `ListNode` in-project.
  - Binary tree problems define `TreeNode` and may include helpers for building trees from arrays.
- Naming:
  - Problem folders use readable names (`BestTimeToBuyAndSellStock/`, `ReverseNodesInkGroup/`). Variants: `/NeetCode`, `/II`, etc.
  - Some folders include spaces (e.g., `Birthday Cake Candles/`, `Palindrome Permutations/`); use quoted paths in commands.
- Isolation: Do not cross-reference types between projects. Implement utilities per project.
 - Solution file rule: Put the actual problem implementation in `solution.cs` within the target project folder. Use `Program.cs` only as a thin runner to drive `solution.cs` with sample inputs.
 - Collaboration rule: Do not fully solve the problem on behalf of the user. Provide scaffolding, patterns, and incremental hints; leave final algorithmic completion decisions to the user.

## Patterns and Examples
- Binary Tree problems: Projects like `BinaryTreeMaximumPathSum/`, `SerializeAndDeserializeBinaryTree/` include `TreeNode` and traversal logic (DFS/BFS). Serialization uses delimiter and null markers; match local conventions in-project.
- Linked List problems: `ReverseLinkedList/`, `LinkedList_Palindrome/`, `RemoveNthNodeFromEndNeetCode/` use iterative pointer manipulation with `ListNode`.
- Array/DP problems: `HouseRobber/`, `ProductOfArrayExceptSelf/`, `KokoEatingBananas/` focus on classic DP/binary search patterns. Implement within the project scope.

## How to Add a New Solution
- Create a new project folder under the repo root (C# console app):
  - `dotnet new console -n <ProjectName> -o "c:\dev\GitHub\ProgrammingChallenges\csharp\<ProjectName>"`
  - Add the project to `ProgrammingChallenges.sln`: `dotnet sln "c:\dev\GitHub\ProgrammingChallenges\csharp\ProgrammingChallenges.sln" add "c:\dev\GitHub\ProgrammingChallenges\csharp\<ProjectName>\<ProjectName>.csproj"`
- Include `Program.cs` with a minimal runner and any local data types.
- Keep code self-contained; do not introduce shared packages unless necessary.

## Debugging Tips
- Run from the specific project directory to avoid solution non-runnable projects.
- Quote paths for folders with spaces when using PowerShell.
- If `dotnet run` fails at solution level, switch to `--project` targeting the specific folder.
 - Scenario validation: When providing sample runs or scaffolding, verify outputs against expected scenarios and clearly mark passing checks with a checkmark (✅). Keep failures explicit with the expected vs actual values to help iterate.

## External Dependencies
- This repo primarily uses .NET SDK; no external NuGet packages are standard. Prefer pure C# implementations.

## VS Code Tasks (predefined)
- `build`: Builds the entire solution.
- `publish`: Publishes the entire solution.
- `watch`: Watches and runs the solution; may not execute a specific target. Use `--project` for a chosen problem.

## When Modifying Existing Projects
- Preserve existing `TreeNode`/`ListNode` structures and input conventions used in that project.
- Keep algorithms iterative/efficient where current patterns are iterative.
- Avoid refactors across project boundaries; changes should be local to the target folder.

## Quick Commands (PowerShell)
```
# Build solution
dotnet build "c:\dev\GitHub\ProgrammingChallenges\csharp\ProgrammingChallenges.sln"

# Run a specific problem project
dotnet run --project "c:\dev\GitHub\ProgrammingChallenges\csharp\ReverseNodesInkGroup"

dotnet run --project "c:\dev\GitHub\ProgrammingChallenges\csharp\SerializeAndDeserializeBinaryTree"
```

If any section is unclear or you need deeper examples for a specific problem folder, let me know which project and I’ll refine this doc accordingly.