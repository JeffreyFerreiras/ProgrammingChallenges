# 261. Graph Valid Tree

## Problem Description
Given `n` nodes labeled from 0 to n-1 and a list of undirected edges (each edge is a pair of nodes), write a function to check whether these edges make up a valid tree.

A valid tree has the following properties:
1. It is connected (there is a path between every pair of nodes)
2. It has no cycles (it doesn't contain any loops)

## Examples:
```
Example 1:
Input: n = 5, edges = [[0,1], [0,2], [0,3], [1,4]]
Output: true
Explanation: This forms a tree with node 0 as the root.

Example 2:
Input: n = 5, edges = [[0,1], [1,2], [2,3], [1,3], [1,4]]
Output: false
Explanation: This cannot be a tree because there is a cycle between nodes 1, 2, and 3.
```

## Constraints:
- 1 <= n <= 2000
- 0 <= edges.length <= 5000
- edges[i].length == 2
- 0 <= ai, bi < n
- ai != bi
- There are no self-loops or repeated edges

## Solution Approach
To determine if a graph is a valid tree, we need to check two conditions:
1. The graph must be connected (all nodes can be visited)
2. The graph must have no cycles

There are several approaches to solve this problem:

1. **Union-Find (Disjoint Set)**: 
   - Keep track of connected components
   - For each edge, check if it creates a cycle
   - Verify all nodes are in the same component

2. **Depth-First Search (DFS)**:
   - Build an adjacency list representation of the graph
   - Perform DFS from any node
   - Track visited nodes to detect cycles
   - Check if all nodes were visited

3. **Graph Property Check**:
   - A tree with n nodes must have exactly n-1 edges
   - The graph must be connected

The solution implements one or more of these approaches with:
- Time Complexity: O(V + E) where V is the number of vertices and E is the number of edges
- Space Complexity: O(V + E) for storing the graph representation
