# Redundant Connection

## Problem Description

You are given a connected undirected graph with n nodes labeled from 1 to n. Initially, it contained no cycles and consisted of n-1 edges.

We have now added one additional edge to the graph. The edge has two different vertices chosen from 1 to n, and was not an edge that previously existed in the graph.

The graph is represented as an array edges of length n where edges[i] = [ai, bi] represents an edge between nodes ai and bi in the graph.

Return an edge that can be removed so that the graph is still a connected non-cyclical graph. If there are multiple answers, return the edge that appears last in the input edges.

## Examples

### Example 1:
```
Input: edges = [[1,2],[1,3],[2,3]]
Output: [2,3]
```

### Example 2:
```
Input: edges = [[1,2],[2,3],[3,4],[1,4],[1,5]]
Output: [1,4]
```

## Constraints:
- n == edges.length
- 3 <= n <= 1000
- edges[i].length == 2
- 1 <= ai < bi <= edges.length
- ai != bi
- There are no repeated edges.
- The given graph is connected.

## Approach
This problem can be solved using Union-Find or DFS. The idea is to detect a cycle in the graph, and the edge that completes the cycle is the redundant connection.

In this implementation, a DFS approach is used to identify the redundant connection in the graph.