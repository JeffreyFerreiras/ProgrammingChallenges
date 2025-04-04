public static class Solution
{
    public static int NumberOfConnectedComponents(int n, int[][] edges)
    {
        //Union-Find (DSU) algorithm to add the given edges
        List<List<int>> adj = [];
        var visited = new bool[n];

        int componentCount = 0;

        for (int i = 0; i < n; i++)
        {
            adj.Add([]);
        }

        foreach(var edge in edges) {
            adj[edge[0]].Add(edge[1]);
            adj[edge[1]].Add(edge[0]);
        }

        for(int node = 0; node < n; node++) {
            if(!visited[node]) {
                Dfs(node);
                componentCount += 1;
            }
        }

        return componentCount;

        void Dfs(int node) {
            visited[node] = true;
            foreach(var neighbor in adj[node]) {
                if(!visited[neighbor]) {
                    Dfs(neighbor);
                }
            }
        }
    }
}
