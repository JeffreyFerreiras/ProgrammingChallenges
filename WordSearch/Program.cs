/*
 * 79. Word Search
 * 
 * Given an m x n grid of characters board and a string word, return true if word exists in the grid.
 * 
 * The word can be constructed from letters of sequentially adjacent cells, where adjacent cells 
 * are horizontally or vertically neighboring. The same letter cell may not be used more than once.
 * 
 * Example 1:
 * Input: board = [["A","B","C","E"],["S","F","C","S"],["A","D","E","E"]], word = "ABCCED"
 * Output: true
 * 
 * Example 2:
 * Input: board = [["A","B","C","E"],["S","F","C","S"],["A","D","E","E"]], word = "SEE"
 * Output: true
 * 
 * Example 3:
 * Input: board = [["A","B","C","E"],["S","F","C","S"],["A","D","E","E"]], word = "ABCB"
 * Output: false
 * 
 * Constraints:
 * - m == board.length
 * - n = board[i].length
 * - 1 <= m, n <= 6
 * - 1 <= word.length <= 15
 * - board and word consists of only lowercase and uppercase English letters.
 */

using System;
using System.Diagnostics;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("LeetCode 79. Word Search");
        Console.WriteLine("========================");
        
        // Define test cases
        TestCase[] testCases = new TestCase[]
        {
            new TestCase(
                new char[][] {
                    new char[] {'A', 'B', 'C', 'E'},
                    new char[] {'S', 'F', 'C', 'S'},
                    new char[] {'A', 'D', 'E', 'E'}
                },
                "ABCCED",
                true
            ),
            new TestCase(
                new char[][] {
                    new char[] {'A', 'B', 'C', 'E'},
                    new char[] {'S', 'F', 'C', 'S'},
                    new char[] {'A', 'D', 'E', 'E'}
                },
                "SEE",
                true
            ),
            new TestCase(
                new char[][] {
                    new char[] {'A', 'B', 'C', 'E'},
                    new char[] {'S', 'F', 'C', 'S'},
                    new char[] {'A', 'D', 'E', 'E'}
                },
                "ABCB",
                false
            ),
            new TestCase(
                new char[][] {
                    new char[] {'C', 'A', 'A'},
                    new char[] {'A', 'A', 'A'},
                    new char[] {'B', 'C', 'D'}
                },
                "AAB",
                true
            ),
            new TestCase(
                new char[][] {
                    new char[] {'A', 'B', 'C', 'E'},
                    new char[] {'S', 'F', 'E', 'S'},
                    new char[] {'A', 'D', 'E', 'E'}
                },
                "ABCESEEEFS",
                true
            ),
            //[["a","a","a","a"],["a","a","a","a"],["a","a","a","a"]]
            new TestCase(
                new char[][] {
                    new char[] {'a', 'a', 'a', 'a'},
                    new char[] {'a', 'a', 'a', 'a'},
                    new char[] {'a', 'a', 'a', 'a'}
                },
                "aaaaaaaaaaaaa",
                false
            ),
        };

        // Create solution instance
        Solution solution = new Solution();
        
        // Run tests
        foreach (var test in testCases)
        {
            RunTest(solution, test);
        }
    }
    
    static void RunTest(Solution solution, TestCase test)
    {
        Console.WriteLine($"Testing word: \"{test.Word}\" on board = {BoardToString(test.Board)}");
        Console.WriteLine($"Expected: {test.Expected}");
        Console.WriteLine("----------------------------------------------------");
        
        // Test first solution
        Stopwatch stopwatch1 = new Stopwatch();
        stopwatch1.Start();
        bool result1 = solution.Exist(test.Board, test.Word);
        stopwatch1.Stop();
        
        // Create a deep copy of the board for the second solution
        char[][] boardCopy = test.Board.Select(row => row.ToArray()).ToArray();
        
        // Test second solution
        Stopwatch stopwatch2 = new Stopwatch();
        stopwatch2.Start();
        bool result2 = solution.Exist2(boardCopy, test.Word);
        stopwatch2.Stop();
        
        // Check results
        bool isCorrect1 = result1 == test.Expected;
        bool isCorrect2 = result2 == test.Expected;
        string tickMark1 = isCorrect1 ? "✓" : "✗";
        string tickMark2 = isCorrect2 ? "✓" : "✗";
        
        // Print comparative results
        Console.WriteLine($"Method: Exist    | Result: {result1} {tickMark1} | Time: {stopwatch1.ElapsedMilliseconds}ms ({stopwatch1.ElapsedTicks} ticks)");
        Console.WriteLine($"Method: Exist2   | Result: {result2} {tickMark2} | Time: {stopwatch2.ElapsedMilliseconds}ms ({stopwatch2.ElapsedTicks} ticks)");
        
        // Show which solution is faster
        if (stopwatch1.ElapsedTicks < stopwatch2.ElapsedTicks)
            Console.WriteLine("Exist was faster by " + (stopwatch2.ElapsedTicks - stopwatch1.ElapsedTicks) + " ticks");
        else if (stopwatch2.ElapsedTicks < stopwatch1.ElapsedTicks)
            Console.WriteLine("Exist2 was faster by " + (stopwatch1.ElapsedTicks - stopwatch2.ElapsedTicks) + " ticks");
        else
            Console.WriteLine("Both solutions took the same time");
        
        Console.WriteLine("----------------------------------------------------");
        Console.WriteLine();
    }
    
    static string BoardToString(char[][] board)
    {
        return $"[{string.Join(", ", board.Select(row => $"[{string.Join(", ", row.Select(c => $"\"{c}\""))}]"))}]";
    }
}

class TestCase
{
    public char[][] Board { get; }
    public string Word { get; }
    public bool Expected { get; }
    
    public TestCase(char[][] board, string word, bool expected)
    {
        Board = board;
        Word = word;
        Expected = expected;
    }
}
