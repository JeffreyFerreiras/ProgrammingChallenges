using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        int[][] matrix = [
            [3, 0, 1, 4, 2],
            [5, 6, 3, 2, 1],
            [1, 2, 0, 1, 5],
            [4, 1, 0, 1, 7],
            [1, 0, 3, 0, 5]
        ];
        var numMatrix = new NumMatrix(matrix);

        TestSumRegion(numMatrix, 2, 1, 4, 3, 8);
        TestSumRegion(numMatrix, 1, 1, 2, 2, 11);
        TestSumRegion(numMatrix, 1, 2, 2, 4, 12);
    }

    static void TestSumRegion(NumMatrix numMatrix, int row1, int col1, int row2, int col2, int expected)
    {
        Stopwatch sw = Stopwatch.StartNew();
        int result = numMatrix.SumRegion(row1, col1, row2, col2);
        sw.Stop();

        Console.WriteLine($"Method: SumRegion({row1}, {col1}, {row2}, {col2})");
        Console.WriteLine($"Result: {result} ticks");
        Console.WriteLine($"Expected: {expected} ticks");
        Console.WriteLine($"Time: {sw.ElapsedTicks} ticks");
        Console.WriteLine();
    }
}

public class NumMatrix
{
    // holds the sum of all elements from the top-left corner of the matrix to the current element
    private int[,] matrixSum;
    
    public NumMatrix(int[][] matrix)
    {
        if (matrix == null || matrix.Length == 0) return; // edge case

        // add an extra row and column for the sum of the first row and column,
        // so we don't have to check for edge cases
        matrixSum = new int[matrix.Length + 1, matrix[0].Length + 1]; 

        // fill the matrixSum array
        // iterate over the matrix and calculate the sum of all elements
        //  from the top-left corner to the current element
        for (int row = 0; row < matrix.Length; row++)
        {
            for (int col = 0; col < matrix[0].Length; col++)
            {
                matrixSum[row + 1, col + 1] = matrixSum[row + 1, col] + matrixSum[row, col + 1] - matrixSum[row, col] + matrix[row][col];
            }
        }
    }
    
    public int SumRegion(int row1, int col1, int row2, int col2)
    {
        return matrixSum[row2 + 1, col2 + 1] - matrixSum[row1, col2 + 1] - matrixSum[row2 + 1, col1] + matrixSum[row1, col1];
    }
}
