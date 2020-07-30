using System;

namespace SetMatrixZeroes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public void SetZeroes(int[][] matrix)
        {
            int x = 0, y = 0;
            int len = matrix.Length;
            var visited = new bool[len, len];

            while (y < len)
            {
                while (x < len)
                {
                    if (matrix[y][x] == 0 && !visited[y, x])
                    {
                        for (int i = 0; i < len; i++)
                        {
                            if (matrix[i][x] != 0)
                            {
                                matrix[i][x] = 0; //verticle
                                visited[i, x] = true;
                            }

                            if (matrix[y][i] != 0)
                            {
                                matrix[y][i] = 0; //horizontal
                                visited[y, i] = true;
                            }
                        }
                    }

                    x++;
                }

                y++;
                x = 0;
            }
        }
    }
}
