using System;
using System.Collections.Generic;

public class Solution
{
    public int[] FindOrder(int numCourses, int[][] prerequisites)
    {
        List<int> result = [];
        Dictionary<int, List<int>> adj = [];
        HashSet<int> visited = [];
        HashSet<int> cycle = [];

        //build adjacency list
        foreach (var pair in prerequisites)
        {
            if (!adj.TryAdd(pair[0], [pair[1]]))
            {
                adj[pair[0]] = [pair[1]];
            }
        }

        //DFS each course
        for (int i = 0; i < numCourses; i++)
        {
            if (!Dfs(i))
            {
                return [];
            }
        }

        return result.ToArray();

        bool Dfs(int course)
        {
            if (cycle.Contains(course)) return false;
            if (visited.Contains(course)) return true;

            cycle.Add(course);

            if (adj.ContainsKey(course))
            {
                foreach (int pre in adj[course])
                {
                    if (!Dfs(pre))
                    {
                        return false;
                    }
                }
            }

            cycle.Remove(course);
            visited.Add(course);
            result.Add(course);

            return true;
        }
    }

    // DFS-based topological sort approach
    public int[] FindOrderDFS(int numCourses, int[][] prerequisites)
    {
        // Build adjacency list
        List<int>[] adj = new List<int>[numCourses];
        for (int i = 0; i < numCourses; i++)
        {
            adj[i] = new List<int>();
        }
        
        foreach (var prereq in prerequisites)
        {
            adj[prereq[1]].Add(prereq[0]); // prereq[1] -> prereq[0]
        }
        
        // 0 = not visited, 1 = visiting (in current path), 2 = visited
        int[] visited = new int[numCourses];
        List<int> result = new List<int>();
        
        for (int i = 0; i < numCourses; i++)
        {
            if (visited[i] == 0)
            {
                if (HasCycleDFS(i, adj, visited, result))
                {
                    return new int[0]; // Cycle found, impossible to finish
                }
            }
        }
        
        result.Reverse(); // Reverse to get correct order
        return result.ToArray();
    }
    
    private bool HasCycleDFS(int node, List<int>[] adj, int[] visited, List<int> result)
    {
        visited[node] = 1; // Mark as visiting
        
        foreach (var neighbor in adj[node])
        {
            if (visited[neighbor] == 1) return true; // Cycle detected
            
            if (visited[neighbor] == 0)
            {
                if (HasCycleDFS(neighbor, adj, visited, result))
                {
                    return true;
                }
            }
        }
        
        visited[node] = 2; // Mark as visited
        result.Add(node);
        return false;
    }
    
    // BFS-based topological sort approach (Kahn's algorithm)
    public int[] FindOrderBFS(int numCourses, int[][] prerequisites)
    {
        // Build adjacency list and indegree array
        List<int>[] adj = new List<int>[numCourses];
        int[] indegree = new int[numCourses];
        
        for (int i = 0; i < numCourses; i++)
        {
            adj[i] = new List<int>();
        }
        
        foreach (var prereq in prerequisites)
        {
            adj[prereq[1]].Add(prereq[0]);
            indegree[prereq[0]]++;
        }
        
        // Add all nodes with indegree 0 to queue
        Queue<int> queue = new Queue<int>();
        for (int i = 0; i < numCourses; i++)
        {
            if (indegree[i] == 0)
            {
                queue.Enqueue(i);
            }
        }
        
        int[] result = new int[numCourses];
        int index = 0;
        
        // Process queue
        while (queue.Count > 0)
        {
            int current = queue.Dequeue();
            result[index++] = current;
            
            foreach (var neighbor in adj[current])
            {
                indegree[neighbor]--;
                if (indegree[neighbor] == 0)
                {
                    queue.Enqueue(neighbor);
                }
            }
        }
        
        // If we couldn't include all courses, there must be a cycle
        if (index == numCourses)
            return result;
        
        return new int[0];
    }
}
