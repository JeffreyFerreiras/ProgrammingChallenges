namespace RedundantConnection;

public class Solution
{
    /*
    Given a graph represented as an undirected graph with n nodes and m edges, where n is the number of nodes and m is the number of edges, find the redundant connection in the graph. A redundant connection is an edge that can be removed without disconnecting the graph.
    The graph is represented as a list of edges, where each edge is represented as a list of two integers [u, v], indicating an edge between nodes u and v.

    edges:
    [
        [1, 2],
        [1, 3],
        [2, 3]
    ]
    Output: [2, 3]
    Explanation: The edge [2, 3] is redundant because removing it will not disconnect the graph. The graph will still be connected with the edges [1, 2] and [1, 3].

    Real world example: 
    1. In a social network, if there are multiple connections between two users, one of those connections can be considered redundant. For example, if user A is friends with user B and also has a mutual friend C who is also friends with user B, the connection between A and B can be considered redundant.
    2. In a transportation network, if there are multiple routes between two cities, one of those routes can be considered redundant. For example, if there are two highways connecting city A and city B, one of those highways can be considered redundant.
    */

    public int[] FindRedundantConnection(int[][] edges) 
    {
        List<List<int>> adj = new (edges.Length);
        // Initialize adjacency list
        for (int i = 0; i <= edges.Length; i++) adj.Add([]);
        
        foreach (var edge in edges) {
            adj[edge[0]].Add(edge[1]);
            adj[edge[1]].Add(edge[0]); 

            var visited = new bool[edges.Length + 1];
            if (HasCycleDfs(edge[0], -1, visited))
                return [edge[0], edge[1]];
        }

        return [];

        bool HasCycleDfs(int node, int parent, bool[] visited)
        {
            if (visited[node]) return true;
            visited[node] = true;

            foreach (int nei in adj[node])
            {
                if (nei == parent) continue;
                if (HasCycleDfs(nei, node, visited)) return true;
            }
            return false;
        }
    }
}
