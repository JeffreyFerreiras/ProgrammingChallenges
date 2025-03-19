using System.Diagnostics;

namespace CourseSchedule2;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("210. Course Schedule II - LeetCode Problem");
        Console.WriteLine(@"
There are a total of numCourses courses you have to take, labeled from 0 to numCourses - 1. You are given an array prerequisites where prerequisites[i] = [ai, bi] indicates that you must take course bi first if you want to take course ai.

For example, the pair [0, 1], indicates that to take course 0 you have to first take course 1.
Return the ordering of courses you should take to finish all courses. If there are many valid answers, return any of them. If it is impossible to finish all courses, return an empty array.

Example 1:
Input: numCourses = 2, prerequisites = [[1,0]]
Output: [0,1]
Explanation: There are a total of 2 courses to take. To take course 1 you should have finished course 0. So the correct course order is [0,1].

Example 2:
Input: numCourses = 4, prerequisites = [[1,0],[2,0],[3,1],[3,2]]
Output: [0,2,1,3] or [0,1,2,3]
Explanation: There are a total of 4 courses to take. To take course 3 you should have finished both courses 1 and 2. Both courses 1 and 2 should be taken after you finished course 0.
So one correct course order is [0,1,2,3]. Another correct ordering is [0,2,1,3].

Example 3:
Input: numCourses = 1, prerequisites = []
Output: [0]

Example 4:
Input: numCourses = 2, prerequisites = [[1,0],[0,1]]
Output: []
Explanation: It is impossible to finish all courses.
");

        Solution solution = new Solution();

        // Test cases
        RunTestCase(solution, 2, [[1, 0]], [0, 1]);
        RunTestCase(solution, 4, [[1, 0], [2, 0], [3, 1], [3, 2]], [0, 2, 1, 3]);
        RunTestCase(solution, 1, [], [0]);
        RunTestCase(solution, 2, [[1, 0], [0, 1]], []);
        RunTestCase(solution, 3, [[1, 0], [2, 1]], [0, 1, 2]);
    }

    static void RunTestCase(Solution solution, int numCourses, int[][] prerequisites, int[] expected)
    {
        Console.WriteLine($"Test Case: numCourses = {numCourses}, prerequisites = {GetPrerequisitesString(prerequisites)} => Expected: {GetArrayString(expected)}");
        
        // Run DFS algorithm and report results
        RunAlgorithm(
            "DFS", 
            () => solution.FindOrderTopologicalDFS(numCourses, prerequisites), 
            expected
        );
        
        // Run BFS algorithm and report results
        RunAlgorithm(
            "BFS (Kahn's algorithm)", 
            () => solution.FindOrderTopologicalBFS(numCourses, prerequisites), 
            expected
        );

        // Run Adj algorithm and report results
        RunAlgorithm(
            "Adj List",
            () => solution.FindOrderAdjDfs(numCourses, prerequisites),
            expected
        );
        
        Console.WriteLine(new string('-', 50));
    }
    
    static void RunAlgorithm(string algorithmName, Func<int[]> algorithmFunction, int[] expected)
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        int[] result = algorithmFunction();
        sw.Stop();
        
        Console.WriteLine($"Find Order {algorithmName}: {sw.ElapsedTicks} ticks");
        Console.WriteLine($"Result: `{GetArrayString(result)}`");
        Console.WriteLine($"Expected: `{GetArrayString(expected)}`");
        Console.WriteLine();
    }

    static string GetArrayString(int[] array)
    {
        return "[" + string.Join(",", array) + "]";
    }

    static string GetPrerequisitesString(int[][] prerequisites)
    {
        if (prerequisites.Length == 0)
            return "[]";
            
        List<string> pairs = new List<string>();
        foreach (var pair in prerequisites)
        {
            pairs.Add($"[{pair[0]},{pair[1]}]");
        }
        
        return "[" + string.Join(",", pairs) + "]";
    }
}
