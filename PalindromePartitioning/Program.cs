using System.Diagnostics;

/*
 * LeetCode Problem 131 - Palindrome Partitioning
 * 
 * Given a string s, partition s such that every substring of the partition is a palindrome.
 * Return all possible palindrome partitioning of s.
 * 
 * Example 1:
 * Input: s = "aab"
 * Output: [["a","a","b"],["aa","b"]]
 * 
 * Example 2:
 * Input: s = "a"
 * Output: [["a"]]
 */

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Palindrome Partitioning");
        Console.WriteLine("======================");
        
        var solution = new Solution();
        var testCases = new Dictionary<string, IList<IList<string>>>
        {
            { "aab", new List<IList<string>> { new List<string> { "a", "a", "b" }, new List<string> { "aa", "b" } } },
            { "a", new List<IList<string>> { new List<string> { "a" } } },
            { "bb", new List<IList<string>> { new List<string> { "b", "b" }, new List<string> { "bb" } } },
            // Adding a longer test case to better demonstrate the performance difference
            { "aabbbaccccdd", null } // We're only interested in performance for this one
        };
        
        foreach (var testCase in testCases)
        {
            var input = testCase.Key;
            var expected = testCase.Value;
            
            Console.WriteLine($"Input: \"{input}\"");
            
            // Test original method
            Stopwatch stopwatch1 = new();
            stopwatch1.Start();
            var result1 = solution.Partition(input);
            stopwatch1.Stop();
            
            Console.WriteLine($"Original Method:");
            Console.WriteLine($"Time: {stopwatch1.ElapsedTicks} ticks");
            
            // Test optimized method
            Stopwatch stopwatch2 = new();
            stopwatch2.Start();
            var result2 = solution.PartitionOptimized(input);
            stopwatch2.Stop();
            
            Console.WriteLine($"Optimized Method:");
            Console.WriteLine($"Time: {stopwatch2.ElapsedTicks} ticks");
            Console.WriteLine($"Performance improvement: {(stopwatch1.ElapsedTicks / (double)stopwatch2.ElapsedTicks):F2}x");
            
            // For shorter strings, validate the results match
            if (expected != null)
            {
                Console.WriteLine($"Result: {FormatResult(result2)}");
                Console.WriteLine($"Expected: {FormatResult(expected)}");
            }
            else
            {
                Console.WriteLine($"Partitions found: {result2.Count}");
            }
            Console.WriteLine();
        }
    }
    
    private static string FormatResult(IList<IList<string>> result)
    {
        if (result == null) return "null";
        
        var outerList = new List<string>();
        foreach (var innerList in result)
        {
            outerList.Add("[" + string.Join(",", innerList.Select(s => $"\"{s}\"")) + "]");
        }
        
        return "[" + string.Join(",", outerList) + "]";
    }
}
