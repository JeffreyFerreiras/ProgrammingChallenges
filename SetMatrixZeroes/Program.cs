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
    }
}
