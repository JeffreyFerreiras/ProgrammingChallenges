namespace CourseSchedule;

/*
 * 207. Course Schedule
 * ====================
 *
 * There are a total of numCourses courses you have to take, labeled from 0 to numCourses-1.
 * Some courses may have prerequisites, for example to take course 0 you have to first take course 1,
 * which is expressed as a pair: [0,1].
 *
 * Given the total number of courses and a list of prerequisite pairs, is it possible for you to finish all courses?
 *
 * Example 1:
 * Input: numCourses = 2, prerequisites = [[1,0]] 
 * Output: true
 * Explanation: There are a total of 2 courses to take. 
 *              To take course 1 you should have finished course 0. So it is possible.
 *
 * Example 2:
 * Input: numCourses = 2, prerequisites = [[1,0],[0,1]]
 * Output: false
 * Explanation: There are a total of 2 courses to take. 
 *              To take course 1 you should have finished course 0, and to take course 0 you should
 *              also have finished course 1. So it is impossible.
 *
 * Constraints:
 * - The input prerequisites is a graph represented by a list of edges, not adjacency matrices.
 * - You may assume that there are no duplicate edges in the input prerequisites.
 * - 1 <= numCourses <= 10^5
 */

public class Solution
{
    public bool CanFinish(int numCourses, int[][] prerequisites)
    {
        Dictionary<int, List<int>> adj = new(numCourses);
        HashSet<int> visited = new(prerequisites.Length);

        for (int i = 0; i < numCourses; i++)
            adj.Add(i, []);

        foreach (int[] courses in prerequisites)
            adj[courses[0]].Add(courses[1]);

        foreach (int crs in adj.Keys)
        {
            if (!Dfs(crs))
                return false;
        }

        return true;

        bool Dfs(int course)
        {
            if (visited.Contains(course)) return false;
            if (adj[course].Count == 0) return true;

            visited.Add(course);

            foreach (int n in adj[course])
            {
                if (!Dfs(n))
                    return false;
            }

            visited.Remove(course);
            adj[course].Clear();

            return true;
        }
    }
}
