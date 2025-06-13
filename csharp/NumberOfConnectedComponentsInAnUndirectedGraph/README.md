# 323. Number of Connected Components in an Undirected Graph

## Problem Description
You have a graph of n nodes. You are given an integer n and an array edges where edges[i] = [ai, bi] indicates that there is an edge between ai and bi in the graph.

Return the number of connected components in the graph.

## Examples:
```
Example 1:
Input: n = 3, edges = [[0,1],[0,2]]
Output: 1
Explanation: All nodes are connected to each other, forming one component.

Example 2:
Input: n = 6, edges = [[0,1],[1,2],[2,3],[4,5]]
Output: 2
Explanation: There are two connected components: [0,1,2,3] and [4,5].

Example 3:
Input: n = 1, edges = []
Output: 1
Explanation: There's only one node, so it forms its own component.

Example 4:
Input: n = 5, edges = []
Output: 5
Explanation: With no edges, each node forms its own component.
```

## Constraints:
- 1 <= n <= 2000
- 1 <= edges.length <= 5000
- edges[i].length == 2
- 0 <= ai <= bi < n
- All the given edges are unique.

## Solution Approach
The solution uses a Depth-First Search (DFS) algorithm to find connected components:

1. Create an adjacency list representation of the graph
2. Maintain a boolean array to track visited nodes
3. For each unvisited node:
   - Perform DFS to mark all reachable nodes in the same component
   - Increment the component counter

The DFS traversal:
- Marks the current node as visited
- Recursively visits all unvisited neighbors
- Ensures that all nodes in a connected component are marked as visited

This approach:
- Time Complexity: O(V + E) where V is the number of vertices and E is the number of edges
- Space Complexity: O(V + E) for the adjacency list and visited array

The implementation includes comprehensive test cases covering various scenarios:
- Single node graphs
- Disconnected graphs with no edges
- Fully connected components
- Multiple small components
- Graphs with cycles
- Complex graphs with multiple components

Each test case is benchmarked using a Stopwatch to measure performance in ticks.
