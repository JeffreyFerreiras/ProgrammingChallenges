namespace SearchA2DMatrix;

public static class Solution
{
    public static bool SearchMatrix(int[][] matrix, int target)
    {
        if (matrix.Length == 0 || matrix[0].Length == 0)
        {
            return false;
        }

        int rows = matrix.Length;
        int columns = matrix[0].Length;
        int left = 0;
        int right = rows * columns - 1;

        while (left <= right)
        {
            int middle = left + (right - left) / 2;
            int value = matrix[middle / columns][middle % columns];

            if (value == target)
            {
                return true;
            }

            if (value < target)
            {
                left = middle + 1;
            }
            else
            {
                right = middle - 1;
            }
        }

        return false;
    }
}
