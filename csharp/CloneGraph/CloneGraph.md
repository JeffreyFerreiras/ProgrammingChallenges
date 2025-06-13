# LeetCode 133: Clone Graph

## Problem Description

Given a reference of a node in a connected undirected graph, return a deep copy (clone) of the graph. Each node in the graph contains a value (int) and a list (List[Node]) of its neighbors.

### Node Definition
```csharp
public class Node {
    public int val;
    public IList<Node> neighbors;
    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }
}
```

## Example 1:
![Example 1](https://assets.leetcode.com/uploads/2019/02/25/133_example_1.png)

Input: adjList = [[2,4],[1,3],[2,4],[1,3]]
Output: [[2,4],[1,3],[2,4],[1,3]]
Explanation: There are 4 nodes in the graph.
- Node 1's neighbors are nodes 2 and 4.
- Node 2's neighbors are nodes 1 and 3.
- Node 3's neighbors are nodes 2 and 4.
- Node 4's neighbors are nodes 1 and 3.

## Example 2:
Input: adjList = [[]]
Output: [[]]
Explanation: Note that the input contains one empty list. This represents a graph with a single node and no neighbors.

## Constraints:
- The number of nodes in the graph is in the range [0, 100].
- Node.val is unique for each node.
- There are no repeated edges and no self-loops in the graph.
- The graph is connected and all nodes can be visited starting from the given node.

## Note:
Return the copy of the given node as a reference to the cloned graph.
