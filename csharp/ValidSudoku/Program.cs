using System;

namespace ValidSudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("LeetCode 36: Valid Sudoku");
            Console.WriteLine("========================");

            var solution = new Solution();

            // Test Case 1: Valid Sudoku board
            char[][] validBoard =
            [
                ['5', '3', '.', '.', '7', '.', '.', '.', '.'],
                ['6', '.', '.', '1', '9', '5', '.', '.', '.'],
                ['.', '9', '8', '.', '.', '.', '.', '6', '.'],
                ['8', '.', '.', '.', '6', '.', '.', '.', '3'],
                ['4', '.', '.', '8', '.', '3', '.', '.', '1'],
                ['7', '.', '.', '.', '2', '.', '.', '.', '6'],
                ['.', '6', '.', '.', '.', '.', '2', '8', '.'],
                ['.', '.', '.', '4', '1', '9', '.', '.', '5'],
                ['.', '.', '.', '.', '8', '.', '.', '7', '9'],
            ];

            // Test Case 2: Invalid Sudoku board (duplicate 8 in top-left 3x3 box)
            char[][] invalidBoard =
            [
                ['8', '3', '.', '.', '7', '.', '.', '.', '.'],
                ['6', '.', '.', '1', '9', '5', '.', '.', '.'],
                ['.', '9', '8', '.', '.', '.', '.', '6', '.'],
                ['8', '.', '.', '.', '6', '.', '.', '.', '3'],
                ['4', '.', '.', '8', '.', '3', '.', '.', '1'],
                ['7', '.', '.', '.', '2', '.', '.', '.', '6'],
                ['.', '6', '.', '.', '.', '.', '2', '8', '.'],
                ['.', '.', '.', '4', '1', '9', '.', '.', '5'],
                ['.', '.', '.', '.', '8', '.', '.', '7', '9'],
            ];

            // Test Case 3: Invalid board with duplicate in row
            char[][] invalidRowBoard =
            [
                ['5', '3', '5', '.', '7', '.', '.', '.', '.'],
                ['6', '.', '.', '1', '9', '5', '.', '.', '.'],
                ['.', '9', '8', '.', '.', '.', '.', '6', '.'],
                ['8', '.', '.', '.', '6', '.', '.', '.', '3'],
                ['4', '.', '.', '8', '.', '3', '.', '.', '1'],
                ['7', '.', '.', '.', '2', '.', '.', '.', '6'],
                ['.', '6', '.', '.', '.', '.', '2', '8', '.'],
                ['.', '.', '.', '4', '1', '9', '.', '.', '5'],
                ['.', '.', '.', '.', '8', '.', '.', '7', '9'],
            ];

            // Test Case 4: Invalid board with duplicate in column
            char[][] invalidColumnBoard =
            [
                ['5', '3', '.', '.', '7', '.', '.', '.', '.'],
                ['6', '.', '.', '1', '9', '5', '.', '.', '.'],
                ['.', '9', '8', '.', '.', '.', '.', '6', '.'],
                ['8', '.', '.', '.', '6', '.', '.', '.', '3'],
                ['4', '.', '.', '8', '.', '3', '.', '.', '1'],
                ['7', '.', '.', '.', '2', '.', '.', '.', '6'],
                ['.', '6', '.', '.', '.', '.', '2', '8', '.'],
                ['.', '.', '.', '4', '1', '9', '.', '.', '5'],
                ['5', '.', '.', '.', '8', '.', '.', '7', '9'],
            ];

            try
            {
                Console.WriteLine("\nRunning test cases...");

                Console.Write("Test Case 1 (Valid board): ");
                bool result1 = solution.IsValidSudoku(validBoard);
                Console.WriteLine($"Expected: True, Got: {result1}");

                Console.Write("Test Case 2 (Invalid - duplicate in 3x3 box): ");
                bool result2 = solution.IsValidSudoku(invalidBoard);
                Console.WriteLine($"Expected: False, Got: {result2}");

                Console.Write("Test Case 3 (Invalid - duplicate in row): ");
                bool result3 = solution.IsValidSudoku(invalidRowBoard);
                Console.WriteLine($"Expected: False, Got: {result3}");

                Console.Write("Test Case 4 (Invalid - duplicate in column): ");
                bool result4 = solution.IsValidSudoku(invalidColumnBoard);
                Console.WriteLine($"Expected: False, Got: {result4}");

                Console.WriteLine("\nAll test cases completed!");
            }
            catch (NotImplementedException)
            {
                Console.WriteLine(
                    "\nSolution not implemented yet. Please implement the IsValidSudoku method."
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError occurred: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
