using System;
using System.Collections.Generic;

namespace ShortestPathOfMaze
{
    /*
Return the Shortest Path of the Maze

Inputs
entrance -> 0 0 1 0 0 0 0
            0 0 1 1 1 1 0
            0 0 1 0 0 0 0
            0 0 0 0 1 0 1
            1 1 1 0 0 0 0 -> exit

Solution
entrance -> + + + + + + +
            0 0 1 1 1 1 +
            0 0 1 + + + +
            0 0 1 + 1 0 1
            1 1 1 + + + + -> exit

entrance -> + + + + + + +
            0 0 1 1 1 1 +
            0 0 1 0 0 + +
            0 0 1 0 1 + 1
            1 1 1 0 0 + + -> exit
This is shortest! return 13
*/

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        //private static int GetShortestPathSteps(int[][] matrix)
        //{
        //    /// 1 ; i
        //    int j = 0;

        //    var visited = new Dictionary<int, int>();

        //    for (int i = 0; i < matrix.Length; i++)
        //    {
        //        int left = (i - 1) > 0 ? i - 1 : -1;
        //        int right = (i + 1) < matrix.Length ? (i + 1) : -1;
                

        //        while (matrix[i][j + 1] == 0)
        //        {
        //            j++;
        //        }
        //    }

        //    return 0;
        //}
    }
}