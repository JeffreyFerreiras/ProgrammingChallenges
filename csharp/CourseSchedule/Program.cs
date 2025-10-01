using System.Diagnostics;

namespace CourseSchedule;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("207. Course Schedule");
        Console.WriteLine("====================");
        Console.WriteLine();
        Console.WriteLine("Problem: There are numCourses courses labeled from 0 to numCourses - 1.");
        Console.WriteLine("Some courses have prerequisites. For example, if prerequisites[i] = [a_i, b_i],");
        Console.WriteLine("you must take course b_i first before taking a_i.");
        Console.WriteLine("Is it possible to finish all courses?");
        Console.WriteLine();

        // Test cases
        RunTestCase(2, [[1, 0]], true);
        RunTestCase(2, [[1, 0], [0, 1]], false);
        RunTestCase(3, [[1, 0], [2, 1]], true);
        RunTestCase(4, [[1, 0], [2, 1], [3, 2], [0, 3]], false);
        RunTestCase(5, [[1, 0], [2, 1], [3, 2], [4, 3]], true);
    }

    private static void RunTestCase(int numCourses, int[][] prerequisites, bool expected)
    {
        var solution = new Solution();
        var sw = Stopwatch.StartNew();

        bool result = solution.CanFinish(numCourses, prerequisites);

        sw.Stop();

        Console.WriteLine($"CanFinish({numCourses}, {FormatPrerequisites(prerequisites)})");
        Console.WriteLine($"Result: {result} ✓ Expected: {expected}");
        Console.WriteLine($"Time: {sw.ElapsedTicks} ticks ({sw.ElapsedMilliseconds}ms)");
        Console.WriteLine();
    }

    private static string FormatPrerequisites(int[][] prerequisites)
    {
        if (prerequisites == null || prerequisites.Length == 0)
            return "[]";

        var result = "[";
        foreach (var prereq in prerequisites)
        {
            result += $"[{prereq[0]},{prereq[1]}],";
        }
        result = result.TrimEnd(',') + "]";
        return result;
    }
}
