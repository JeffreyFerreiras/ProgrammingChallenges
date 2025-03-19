namespace CourseSchedule2;

public class Solution
{
    public int[] FindOrderAdjDfs(int numCourses, int[][] prerequisites)
    {
        List<int> result = [];
        Dictionary<int, List<int>> adj = [];
        HashSet<int> visited = [];
        HashSet<int> cycle = [];

        //build adjacency list
        for (int i = 0; i < numCourses; i++)
        {
            adj[i] = [];
        }

        foreach (var pair in prerequisites)
        {
            adj[pair[0]].Add(pair[1]);
        }

        //DFS each course
        for (int i = 0; i < numCourses; i++)
        {
            if (!Dfs(i))
            {
                return [];
            }
        }

        return [.. result];

        bool Dfs(int course)
        {
            if (cycle.Contains(course)) return false;
            if (visited.Contains(course)) return true;

            cycle.Add(course);

            foreach (int pre in adj[course])
            {
                if (!Dfs(pre))
                {
                    return false;
                }
            }

            cycle.Remove(course);
            visited.Add(course);
            result.Add(course);

            return true;
        }
    }

    // DFS-based topological sort approach
    public int[] FindOrderTopologicalDFS(int numCourses, int[][] prerequisites)
    {
        List<int> output = [];          // List to store the topological order
        List<List<int>> adj = [];       // Adjacency list to represent the graph
        for (int i = 0; i < numCourses; i++)
        {
            adj.Add([]);                // Initialize the adjacency list for each course
        }
        var indegree = new int[numCourses]; // Array to store the in-degree of each course
        foreach (var pre in prerequisites)
        {
            indegree[pre[0]]++;         // Increment the in-degree of the course that has a prerequisite
            adj[pre[1]].Add(pre[0]);    // Add the prerequisite to the adjacency list of the course
        }

        for (int i = 0; i < numCourses; i++)
        {
            if (indegree[i] == 0)
            {
                Dfs(i);                 // Start DFS from courses with in-degree 0
            }
        }

        if (output.Count != numCourses) return [];  // If not all courses are visited, there is a cycle
        return [.. output];                         // Return the topological order

        // DFS function to traverse the graph
        void Dfs(int node)
        {
            output.Add(node);               // Add the current node to the topological order
            indegree[node]--;               // Decrement the in-degree of the current node
            foreach (var nei in adj[node])
            {
                indegree[nei]--;            // Decrement the in-degree of the neighbor
                if (indegree[nei] == 0)
                {
                    Dfs(nei);               // Recursively call DFS on the neighbor if its in-degree becomes 0
                }
            }
        }
    }

    // BFS-based topological sort approach (Kahn's algorithm)
    public int[] FindOrderTopologicalBFS(int numCourses, int[][] prerequisites)
    {
        List<List<int>> adj = [];               // Create an adjacency list to represent the graph
        for (int i = 0; i < numCourses; i++){
            adj.Add([]);                        // Initialize each course with an empty list of prerequisites
        }

        // Create an array to store the in-degrees of each course
        int[] indegrees = new int[numCourses];

        // Populate the adjacency list and in-degree array based on the prerequisites
        foreach (var pre in prerequisites) {
            indegrees[pre[1]]++;                // Increment the in-degree of the course that has a prerequisite
            adj[pre[0]].Add(pre[1]);            // Add the prerequisite to the adjacency list of the course
        }

        // Create a queue to store courses with in-degree of 0
        Queue<int> queue = [];
        for (int i = 0; i < numCourses; i++) {
            if(indegrees[i] == 0) {
                queue.Enqueue(i);               // Add courses with no prerequisites to the queue
            }
        }

        // Initialize variables for tracking the number of finished courses and the result array
        int finish = 0;
        int [] result = new int[numCourses];

        // Process courses in the queue until it's empty
        while(queue.Count > 0) {
            var node = queue.Dequeue(); // Dequeue a course from the queue
            result[numCourses - finish - 1] = node; // Add the course to the result array
            finish++; // Increment the number of finished courses
            // Iterate through the neighbors (prerequisites) of the current course
            foreach(var neighbor in adj[node]){
                indegrees[neighbor]--; // Decrement the in-degree of the neighbor
                if(indegrees[neighbor] == 0) {
                    queue.Enqueue(neighbor); // If the in-degree becomes 0, add it to the queue
                }
            }
        }
        
        // If not all courses have been finished, there is a cycle, so return an empty array
        if(finish != numCourses) {
            return [];
        }
        // Return the topological order of the courses
        return result;
    }
}
