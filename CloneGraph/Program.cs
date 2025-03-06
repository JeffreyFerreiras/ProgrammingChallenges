using System;
using System.Diagnostics;
using System.Collections.Generic;

// See https://aka.ms/new-console-template for more information

// Minimal graph node definition
public class Node {
    public int val;
    public IList<Node> neighbors;
    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }
    public Node(int _val, IList<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}

class Program {
    static void Main(string[] args) {
        // Test scenario 1: Single node with no neighbors
        // Node test1 = new Node(1);
        // Node expected1 = new Node(1); // Expected deep copy
        
        // RunTest("CloneGraph_SingleNode", test1, expected1);

        // // Test scenario 2: Two connected nodes
        // Node test2a = new Node(1);
        // Node test2b = new Node(2);
        // test2a.neighbors.Add(test2b);
        // test2b.neighbors.Add(test2a);
        // // For testing we assume expected graph structure similar to input.
        // Node expected2 = test2a; 

        // RunTest("CloneGraph_TwoNodes", test2a, expected2);

        // // Test scenario 3: Graph with cycle (4 nodes)
        // Node cycA = new Node(1);
        // Node cycB = new Node(2);
        // Node cycC = new Node(3);
        // Node cycD = new Node(4);
        // cycA.neighbors.Add(cycB);
        // cycB.neighbors.Add(cycC);
        // cycC.neighbors.Add(cycD);
        // cycD.neighbors.Add(cycA);
        // RunTest("CloneGraph_Cycle", cycA, cycA);

        // // Test scenario 4: Graph with self-loop
        // Node selfLoop = new Node(5);
        // selfLoop.neighbors.Add(selfLoop);
        // RunTest("CloneGraph_SelfLoop", selfLoop, selfLoop);

        // // Test scenario 5: Null input
        // RunTest("CloneGraph_NullInput", null, null);

        // Test scenario 6: Adjacency List Matching
        // adjList = [[2,4],[1,3],[2,4],[1,3]]
        Node node1 = new Node(1);
        Node node2 = new Node(2);
        Node node3 = new Node(3);
        Node node4 = new Node(4);
        node1.neighbors.Add(node2);
        node1.neighbors.Add(node4);
        node2.neighbors.Add(node1);
        node2.neighbors.Add(node3);
        node3.neighbors.Add(node2);
        node3.neighbors.Add(node4);
        node4.neighbors.Add(node1);
        node4.neighbors.Add(node3);
        RunTest("CloneGraph_AdjList", node1, node1);
    }
    
    static void RunTest(string testName, Node input, Node expected) {
        Console.WriteLine($"Test: {testName}");        
        Stopwatch sw = Stopwatch.StartNew();
        Node result = Solution.CloneGraph(input);
        sw.Stop();
        long ticks = sw.ElapsedTicks;
        Console.WriteLine($"Method: CloneGraph, Ticks: {ticks}, Result: {result?.val}, Expected: {expected?.val}");
    }
}
