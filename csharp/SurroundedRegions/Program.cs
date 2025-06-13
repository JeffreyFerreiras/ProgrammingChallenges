using System.Diagnostics;
using System.Text;

namespace SurroundedRegions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("130. Surrounded Regions");
            Console.WriteLine("------------------------");
            Console.WriteLine("Given an m x n matrix board containing 'X' and 'O', capture all regions surrounded by 'X'.");
            Console.WriteLine("A region is captured by flipping all 'O's into 'X's in that surrounded region.");
            Console.WriteLine();

            RunTestCase1();
            RunTestCase2();
            RunTestCase3();
            RunTestCase4();
            RunTestCase5();

            Console.ReadKey();
        }

        static void RunTestCase1()
        {
            // Test case 1 from LeetCode example 1
            char[][] board =
            [
                ['X', 'X', 'X', 'X'],
                ['X', 'O', 'O', 'X'],
                ['X', 'X', 'O', 'X'],
                ['X', 'O', 'X', 'X']
            ];

            char[][] expected =
            [
                ['X', 'X', 'X', 'X'],
                ['X', 'X', 'X', 'X'],
                ['X', 'X', 'X', 'X'],
                ['X', 'O', 'X', 'X']
            ];

            RunTest("Test Case 1", board, expected);
        }

        static void RunTestCase2()
        {
            // Test case 2 from LeetCode example 2
            char[][] board =
            [
                ['X']
            ];

            char[][] expected =
            [
                ['X']
            ];

            RunTest("Test Case 2", board, expected);
        }

        static void RunTestCase3()
        {
            // Test case 3 - Larger board with multiple regions
            char[][] board =
            [
                ['X', 'X', 'X', 'X', 'X', 'X'],
                ['X', 'O', 'O', 'O', 'X', 'X'],
                ['X', 'X', 'O', 'O', 'O', 'X'],
                ['X', 'O', 'X', 'O', 'X', 'X'],
                ['X', 'O', 'O', 'X', 'O', 'X'],
                ['X', 'X', 'X', 'X', 'X', 'X']
            ];

            char[][] expected =
            [
                ['X', 'X', 'X', 'X', 'X', 'X'],
                ['X', 'X', 'X', 'X', 'X', 'X'],
                ['X', 'X', 'X', 'X', 'X', 'X'],
                ['X', 'O', 'X', 'X', 'X', 'X'],
                ['X', 'O', 'O', 'X', 'O', 'X'],
                ['X', 'X', 'X', 'X', 'X', 'X']
            ];

            RunTest("Test Case 3", board, expected);
        }

        static void RunTestCase4()
        {
            // Test case 4 - Empty board
            char[][] board = [];
            char[][] expected = [];

            RunTest("Test Case 4", board, expected);
        }

        static void RunTestCase5()
        {
            // Test case 5 - Board with no 'O's
            char[][] board =
            [
                ['X', 'X', 'X'],
                ['X', 'X', 'X'],
                ['X', 'X', 'X']
            ];

            char[][] expected =
            [
                ['X', 'X', 'X'],
                ['X', 'X', 'X'],
                ['X', 'X', 'X']
            ];

            RunTest("Test Case 5", board, expected);
        }

        static void RunTest(string testName, char[][] board, char[][] expected)
        {
            var solution = new Solution();
            
            // Create a deep copy of the input board for testing
            char[][] boardCopy = DeepCopyBoard(board);
            
            // Start timing
            var stopwatch = Stopwatch.StartNew();
            
            // Call the solution
            solution.Solve(boardCopy);
            
            // Stop timing
            stopwatch.Stop();
            
            // Validate results
            bool isCorrect = ValidateResult(boardCopy, expected);
            
            // Print results
            Console.WriteLine($"{testName} - {(isCorrect ? "✓" : "✗")}");
            Console.WriteLine($"Time: {stopwatch.ElapsedTicks} ticks");
            Console.WriteLine($"Input: ");
            PrintBoard(board);
            Console.WriteLine($"Result: ");
            PrintBoard(boardCopy);
            Console.WriteLine($"Expected: ");
            PrintBoard(expected);
            Console.WriteLine();
        }

        static char[][] DeepCopyBoard(char[][] board)
        {
            if (board == null || board.Length == 0)
                return [];

            char[][] copy = new char[board.Length][];
            for (int i = 0; i < board.Length; i++)
            {
                copy[i] = new char[board[i].Length];
                Array.Copy(board[i], copy[i], board[i].Length);
            }
            return copy;
        }

        static bool ValidateResult(char[][] result, char[][] expected)
        {
            if (result.Length != expected.Length)
                return false;

            for (int i = 0; i < result.Length; i++)
            {
                if (result[i].Length != expected[i].Length)
                    return false;

                for (int j = 0; j < result[i].Length; j++)
                {
                    if (result[i][j] != expected[i][j])
                        return false;
                }
            }
            return true;
        }

        static void PrintBoard(char[][] board)
        {
            if (board == null || board.Length == 0)
            {
                Console.WriteLine("[]");
                return;
            }

            StringBuilder sb = new();
            sb.Append("[\n");
            
            foreach (var row in board)
            {
                sb.Append("  [");
                sb.Append(string.Join(", ", row.Select(c => $"'{c}'")));
                sb.Append("]\n");
            }
            
            sb.Append("]");
            Console.WriteLine(sb.ToString());
        }
    }
}
