using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace CombinationSum
{
    public class Program
    {
        /*
         * Leetcode 39. Combination Sum
         * 
         * Given an array of distinct integers candidates and a target integer target,
         * return a list of all unique combinations of candidates where the chosen numbers sum to target.
         * You may return the combinations in any order.
         * 
         * The same number may be chosen from candidates an unlimited number of times. 
         * Two combinations are unique if the frequency of at least one of the chosen numbers is different.
         * 
         * It is guaranteed that the number of unique combinations that sum up to target is less than 150 combinations for the given input.
         * 
         * Constraints:
         * 1 <= candidates.length <= 30
         * 1 <= candidates[i] <= 200
         * All elements of candidates are distinct.
         * 1 <= target <= 500
         */
        public static void Main(string[] args)
        {
            Console.WriteLine("Leetcode 39. Combination Sum");
            Console.WriteLine("----------------------------");

            RunTestCase(new int[] { 2, 3, 6, 7 }, 7, new List<IList<int>> 
            { 
                new List<int> { 2, 2, 3 }, 
                new List<int> { 7 } 
            });

            RunTestCase(new int[] { 2, 3, 5 }, 8, new List<IList<int>> 
            { 
                new List<int> { 2, 2, 2, 2 }, 
                new List<int> { 2, 3, 3 }, 
                new List<int> { 3, 5 } 
            });

            RunTestCase(new int[] { 2 }, 1, new List<IList<int>> { });
        }

        private static void RunTestCase(int[] candidates, int target, IList<IList<int>> expected)
        {
            Console.WriteLine($"Test Case: candidates = [{string.Join(", ", candidates)}], target = {target}");
            Console.WriteLine($"Expected: {FormatResult(expected)}");

            var solution = new Solution();
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var result = solution.CombinationSum(candidates, target);
            stopwatch.Stop();

            Console.WriteLine($"Result: {FormatResult(result)}");
            Console.WriteLine($"Time elapsed: {stopwatch.ElapsedMilliseconds} ms ({stopwatch.ElapsedTicks} ticks)");
            Console.WriteLine();
        }

        private static string FormatResult(IList<IList<int>> result)
        {
            if (result.Count == 0) return "[]";

            var formattedCombinations = result
                .Select(combo => $"[{string.Join(", ", combo)}]")
                .ToArray();

            return $"[{string.Join(", ", formattedCombinations)}]";
        }
    }
}
