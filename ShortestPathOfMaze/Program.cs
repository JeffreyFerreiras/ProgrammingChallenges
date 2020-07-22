using System;
using System.Collections.Generic;
using System.Linq;

namespace ShortestPathOfMaze
{
    //LEVEL medium/hard
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
            var matrix = new int[5][];
            //17
            matrix[0] = new int[] { 0, 0, 0, 0, 0, 0, 0 };
            matrix[1] = new int[] { 0, 0, 1, 1, 1, 1, 0 };
            matrix[2] = new int[] { 0, 0, 1, 0, 0, 0, 0 };
            matrix[3] = new int[] { 0, 0, 1, 0, 1, 0, 1 };
            matrix[4] = new int[] { 1, 1, 1, 0, 0, 0, 0 };

            var result = GetShortestPathSteps(matrix);

            Console.WriteLine(result);
            Console.ReadLine();
        }

        private static int GetShortestPathSteps(int[][] matrix)
        {
            int y = 0;
            int x = 0;
            int shortestPathCount = 0;

            var seen = new bool[matrix.Length, matrix[0].Length];
            var queue = new Queue<Tuple<int, int, int>>();

            queue.Enqueue(new Tuple<int, int, int>(y, x, 0));

            while (queue.Any())
            {
                int count;
                (y, x, count) = queue.Dequeue();
                
                seen[y, x] = true;
                
                Console.WriteLine($"{y} {x}");

                int up = (y - 1) > 0 && matrix[y - 1][x] == 0 ? y - 1 : -1;
                int down = (y + 1) < matrix.Length && matrix[y + 1][x] == 0 ? (y + 1) : -1;

                int left = (x - 1) > 0 && matrix[y][x - 1] == 0 ? x - 1 : -1;
                int right = (x + 1) < matrix[y].Length && matrix[y][x + 1] == 0 ? x + 1 : -1;

                if (down > -1 && !seen[down, x])
                {
                    seen[down, x] = true;
                    queue.Enqueue(new Tuple<int, int, int>(down, x, count + 1));
                }
                
                if (up > -1 && !seen[up, x])
                {
                    seen[up, x] = true;
                    queue.Enqueue(new Tuple<int, int, int>(up, x, count + 1));
                }

                if (left > -1 && !seen[y, left])
                {
                    seen[y, left] = true;
                    queue.Enqueue(new Tuple<int, int, int>(y, left, count + 1));
                }
                
                if (right > -1 && !seen[y, right])
                {
                    seen[y, right] = true;
                    queue.Enqueue(new Tuple<int, int, int>(y, right, count + 1));
                }

                if (y == matrix.Length - 1 && x == matrix[0].Length - 1)
                {
                    shortestPathCount = count + 1;
                    break;
                }
            }

            return shortestPathCount;
        }
    }
}