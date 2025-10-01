// See https://aka.ms/new-console-template for more information
public class NumMatrix2
{
    private readonly int[][] _matrix;
    private readonly Dictionary<string, int> _memo = [];

    public NumMatrix2(int[][] matrix)
    {
        _matrix = matrix;

        BuildMemo(0, 0, matrix.Length - 1, matrix[0].Length - 1);
    }

    public void BuildMemo(int row1, int col1, int row2, int col2)
    {
        if (row2 < row1 || col2 < col1) //overlap detected, exit
        {
            return;
        }

        var key = $"{row1},{col1},{row2},{col2}";

        var sum = 0;
        for (int i = row1; i <= row2; i++)
        { //row
            for (int j = col1; j <= col2; j++)
            { //col
                sum += _matrix[i][j];
            }
        }

        _memo[key] = sum;

        //BFS each direction
        BuildMemo(row1 + 1, col1, row2, col2);
        BuildMemo(row1, col1 + 1, row2, col2);
        BuildMemo(row1, col1, row2 - 1, col2);
        BuildMemo(row1, col1, row2, col2 - 1);
    }

    public int SumRegion(int row1, int col1, int row2, int col2)
    {
        return _memo[$"{row1},{col1},{row2},{col2}"];
    }
}

/**
 * Your NumMatrix object will be instantiated and called as such:
 * NumMatrix obj = new NumMatrix(matrix);
 * int param_1 = obj.SumRegion(row1,col1,row2,col2);
 */