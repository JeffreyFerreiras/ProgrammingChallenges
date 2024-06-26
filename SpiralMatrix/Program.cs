﻿
using System.Collections.Generic;

/*
 * Given an m x n matrix, return all elements of the matrix in spiral order.
 *
 * Example 1:
 * Input: matrix = [[1, 2, 3], [4, 5, 6], [7, 8, 9]]
 * Output: [1, 2, 3, 6, 9, 8, 7, 4, 5]
 *
 * Example 2:
 * Input: matrix = [[1, 2, 3, 4], [5, 6, 7, 8], [9, 10, 11, 12]]
 * Output: [1, 2, 3, 4, 8, 12, 11, 10, 9, 5, 6, 7]
 *
 * Constraints:
 * - m == matrix.length
 * - n == matrix[i].length
 * - 1 <= m, n <= 10
 * - -100 <= matrix[i][j] <= 100
 */

using System;
using System.Collections.Generic;

var testCases = new List<int[][]> 
{
    new int[][]
    {
        new int[] {1, 2, 3},
        new int[] {4, 5, 6},
        new int[] {7, 8, 9}
    },  
    new int[][]
    {
        new int[] {1, 2, 3, 4},
        new int[] {5, 6, 7, 8},
        new int[] {9, 10, 11, 12}
    }
};

foreach (var testCase in testCases)
{
    var result = SpiralOrder(testCase);
    foreach (var item in result)
    {
        System.Console.Write(item + " ");
    }
    System.Console.WriteLine();
}

IList<int> SpiralOrder(int[][] matrix)
{
    var result = new List<int>();
    int rowStart = 0, rowEnd = matrix.Length - 1;
    int colStart = 0, colEnd = matrix[0].Length - 1;

    while (rowStart <= rowEnd && colStart <= colEnd)
    {
        for (int i = colStart; i <= colEnd; i++)
            result.Add(matrix[rowStart][i]);
        rowStart++;

        for (int i = rowStart; i <= rowEnd; i++)
            result.Add(matrix[i][colEnd]);
        colEnd--;

        if (rowStart <= rowEnd)
        {
            for (int i = colEnd; i >= colStart; i--)
                result.Add(matrix[rowEnd][i]);
            rowEnd--;
        }

        if (colStart <= colEnd)
        {
            for (int i = rowEnd; i >= rowStart; i--)
                result.Add(matrix[i][colStart]);
            colStart++;
        }
    }

    return result;
}