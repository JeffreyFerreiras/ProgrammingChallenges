using System.Collections.Generic;
using System.Linq;

namespace GraphValidTree
{
    public class Solution
    {
        /// <summary>
        /// Determines if the given edges form a valid tree with n nodes.
        /// </summary>
        /// <param name="n">Number of nodes (0 to n-1)</param>
        /// <param name="edges">Array of edges, where each edge is a pair of nodes</param>
        /// <returns>True if edges form a valid tree, otherwise false</returns>
        public bool ValidTree(int n, int[][] edges)
        {
            if (edges.Length != n - 1) return false;
            // convert to adjacency list
            Dictionary<int, List<int>> adj = new(n);
            for (int i = 0; i < n; i++)
            {
                adj[i] = [];
            }
            foreach (var pair in edges)
            {
                adj[pair[0]].Add(pair[1]);
                adj[pair[1]].Add(pair[0]);
            }

            // detect a cycle with bfs
            Queue<int> seen = [];
            HashSet<int> visited = [];

            seen.Enqueue(adj.Keys.First());
            visited.Add(adj.Keys.First());

            while (seen.Count > 0)
            {
                int current = seen.Dequeue();
                foreach (int value in adj[current])
                {
                    if (visited.Contains(value)) continue;
                    seen.Enqueue(value);
                    visited.Add(value);
                }
            }

            return visited.Count == n;
        }
    }
}
