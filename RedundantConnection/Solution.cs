using System;

namespace RedundantConnection;

public class Solution
{
    public int[] FindRedundantConnection(int[][] edges)
    {
        List<List<int>> adj = [];
        for (int i = 0; i <= edges.Length; i++) // initialize the adjacency list
        {
            adj.Add([]);
        }

        foreach (var edge in edges)
        {
            adj[edge[0]].Add(edge[1]); 
            adj[edge[1]].Add(edge[0]); 

            var visited = new bool[edges.Length + 1];
            if (HasCycleDfs(edge[0], -1, visited))
            {
                return [edge[0], edge[1]];
            }
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
