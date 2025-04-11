using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        // Define scenarios: tuple of input and expected result.
        var testCases = new List<(string input, int expected)>
        {
            ("12", 2),    // e.g., "12" -> "AB", "L"
            ("226", 3),   // e.g., "2-2-6", "22-6", "2-26"
            ("06", 0)
        };

        // Create instance for memoization solution.
        var memoSolution = new Solution_Memoization();

        foreach (var test in testCases)
        {
            Console.WriteLine($"Test case: \"{test.input}\", Expected: {test.expected}");

            // Measure Solution_Memoization
            var swMemo = Stopwatch.StartNew();
            int resultMemo = memoSolution.NumDecodings(test.input);
            swMemo.Stop();
            Console.WriteLine($"Solution_Memoization: {swMemo.ElapsedTicks} ticks, Result: {resultMemo}, Expected: {test.expected}");

            // Measure Solution_Iterative
            var swIter = Stopwatch.StartNew();
            Solution_Iterative solution = new Solution_Iterative();
            int resultIter = solution.NumDecodings(test.input);
            swIter.Stop();
            Console.WriteLine($"Solution_Iterative: {swIter.ElapsedTicks} ticks, Result: {resultIter}, Expected: {test.expected}");
            Console.WriteLine();
        }
    }
}
