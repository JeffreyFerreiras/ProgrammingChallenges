using System;

namespace SetMatrixZeroes
{
    class Program
    {
        //[[1,1,1],[1,0,1],[1,1,1]]
        //[[0,1,2,0],[3,4,5,2],[1,3,1,5]]
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public void SetZeroes(int[][] matrix)
        {
            int len = matrix.Length;
            bool isColZero = false;

            for (int i = 1; i < len; i++)
            {
                if (matrix[i][0] == 0)
                {
                    isColZero = true;
                }

                for (int j = 1; j < len; j++)
                {
                    if(matrix[i][j] == 0)
                    {
                        matrix[0][j] = 0;
                        matrix[i][0] = 0;
                    }
                }
            }

            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    if (matrix[0][j] == 0 || matrix[i][j] == 0)
                    {
                        matrix[i][j] = 0;
                    }
                }
            }

            if(matrix[0][0] == 0)
            {
                for (int i = 0; i < len; i++)
                {
                    matrix[0][i] = 0;
                }
            }

            if (isColZero)
            {
                for (int i = 0; i < len; i++)
                {
                    matrix[i][0] = 0;
                }
            }
        }
        public void SetZeroes_5_16_2024(int[][] matrix)
        {
            bool[][] tozero = new bool[matrix.Length][];
            for (int i = 0; i < matrix.Length; i++)
            {
                tozero[i] = new bool[matrix[i].Length];
            }

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    var value = tozero[i][j];

                    if (value)
                    {
                        matrix[i][j] = 0;

                        for (int k = 0; k < matrix.Length; k++)
                        {
                            matrix[k][j] = 0;
                        }

                        for (int r = 0; r < matrix[i].Length; r++)
                        {
                            matrix[i][r] = 0;
                        }
                    }
                }
            }
        }

        public void SetZeroes_DFS(int[][] matrix)
        {
            int m = matrix.Length;
            if(m == 0) return;
            int n = matrix[0].Length;

            bool[,] visited = new bool[m, n];

            // Start DFS from every cell that is initially zero
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if(matrix[i][j] == 0 && !visited[i, j])
                    {
                        DFS(matrix, i, j, visited);
                    }
                }
            }
        }

        private void DFS(int[][] matrix, int i, int j, bool[,] visited)
        {
            if (visited[i, j])
                return;
            visited[i, j] = true;

            int m = matrix.Length;
            int n = matrix[0].Length;

            // Propagate left along the row
            for (int col = j - 1; col >= 0; col--)
            {
                if (matrix[i][col] != 0)
                {
                    matrix[i][col] = 0;
                }
                DFS(matrix, i, col, visited);
            }

            // Propagate right along the row
            for (int col = j + 1; col < n; col++)
            {
                if (matrix[i][col] != 0)
                {
                    matrix[i][col] = 0;
                }
                DFS(matrix, i, col, visited);
            }

            // Propagate upward along the column
            for (int row = i - 1; row >= 0; row--)
            {
                if (matrix[row][j] != 0)
                {
                    matrix[row][j] = 0;
                }
                DFS(matrix, row, j, visited);
            }

            // Propagate downward along the column
            for (int row = i + 1; row < m; row++)
            {
                if (matrix[row][j] != 0)
                {
                    matrix[row][j] = 0;
                }
                DFS(matrix, row, j, visited);
            }
        }
    }
}
