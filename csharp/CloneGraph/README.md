# 133. Clone Graph

## Problem Description
Given a reference of a node in a connected undirected graph, return a deep copy (clone) of the graph. Each node in the graph contains a value (`val`) and a list of its neighbors (`neighbors`).

The graph is represented as an adjacency list where each node contains its value and a list of references to other nodes.

## Examples:
```
Example 1:
Input: adjList = [[2,4],[1,3],[2,4],[1,3]]
Output: [[2,4],[1,3],[2,4],[1,3]]
Explanation: The graph has four nodes:
1. Node 1's value is 1, and it has two neighbors: Node 2 and 4.
2. Node 2's value is 2, and it has two neighbors: Node 1 and 3.
3. Node 3's value is 3, and it has two neighbors: Node 2 and 4.
4. Node 4's value is 4, and it has two neighbors: Node 1 and 3.
```

## Constraints:
- The number of nodes in the graph is in the range `[0, 100]`.
- `1 <= Node.val <= 100`
- `Node.val` is unique for each node.
- There are no repeated edges and no self-loops in the graph.
- The Graph is connected and all nodes can be visited from the given node.

## Solution Approach
The solution implements a depth-first search (DFS) approach to clone the graph:

1. Use a dictionary to map original nodes to their cloned counterparts
2. Start DFS from the input node
3. For each node:
   - Create a clone if it doesn't exist in the map
   - Recursively clone all neighbors
   - Connect the cloned node to its cloned neighbors

Special cases handled:
- Null input returns null
- Single nodes with no neighbors
- Graphs with cycles (using the dictionary to prevent infinite recursion)

Time Complexity: O(N+E) where N is the number of nodes and E is the number of edges
Space Complexity: O(N) for the dictionary and recursion stack