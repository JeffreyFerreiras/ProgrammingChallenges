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
            matrix[0] = [0, 0, 0, 0, 0, 0, 0];
            matrix[1] = [0, 0, 1, 1, 1, 1, 0];
            matrix[2] = [0, 0, 1, 0, 0, 0, 0];
            matrix[3] = [0, 0, 1, 0, 1, 0, 1];
            matrix[4] = [1, 1, 1, 0, 0, 0, 0];
            var seen = new int[5][];
            for (int i = 0; i < seen.Length; i++)
            {
                seen[i] = new int[5];
            }

            //var result = GetShortestPathSteps(matrix);
            //var result2 = GetShortestPathSteps2022(matrix, 0, 0, 0, seen);
            var result2 = GetShortestPathSteps_2022(matrix);

            //Console.WriteLine(result);
            Console.ReadLine();
        }
        
        private static int GetShortestPathSteps_2022(int[][] matrix)
        {
            var seen = new int[matrix.Length, matrix[0].Length];
            return Recur(0, 0, 0);

            int Recur(int y, int x, int step){
                System.Console.WriteLine($"{y} {x} step:{step}");
                if(y == matrix.Length -1 && x == matrix[0].Length -1)
                {
                    return step + 1;
                }

                int left = x -1,
                right = x + 1,
                down = y - 1,
                up = y + 1;

                if(IsWithinXRange(left) && matrix[y][left] == 0 && seen[y, left] == 0)
                {
                    seen[y, left] = 1;
                    step = Recur(y, left, step + 1);
                    if (step > -1)
                    {
                        return step;
                    }
                }
                if(IsWithinXRange(right) && matrix[y][right]==0 && seen[y, right] == 0){
                    seen[y, right] = 1;
                    step = Recur(y, right, step +1);
                    if (step > -1)
                    {
                        return step;
                    }
                }
                if(IsWithinYRange(up) && matrix[up][x] == 0 && seen[up, x] == 0)
                {
                    seen[up, x] = 1;
                    step = Recur(up, x, step + 1);
                    if (step > -1)
                    {
                        return step;
                    }
                }
                if(IsWithinYRange(down) && matrix[down][x] == 0 && seen[down, x] == 0){
                    seen[down, x] = 1;
                    step = Recur(down, x, step + 1);
                    if (step > -1)
                    {
                        return step;
                    }
                }
                
                return -1;
            }

            bool IsWithinXRange(int targetIndex){
                return targetIndex > 0 && targetIndex < matrix[0].Length;
            }
            bool IsWithinYRange(int targetIndex)
            {
                return targetIndex > 0 && targetIndex < matrix.Length;
            }
        }
        private static int GetShortestPathSteps2022(int[][] matrix, int i, int j, int step, int[][] seen)
        {
            if(j == (matrix.Length - 1) || i == (matrix.Length - 1) || seen[i][j] == 1)
            {
                return step;
            }

            if(matrix[i][j] == 0)
            {
                Console.WriteLine($"{i} {j}");
                seen[i][j] = 1;
                
                step = GetShortestPathSteps2022(matrix, i, j + 1, step, seen);
                step = GetShortestPathSteps2022(matrix, i + 1, j, step, seen);
                if(i - 1 > 0 && seen[i - 1][j] != 1){
                    step = GetShortestPathSteps2022(matrix, i - 1, j, step, seen);
                }
                if(j - 1 > 0 && seen[i][j - 1] != 1){
                    step = GetShortestPathSteps2022(matrix, i, j - 1, step, seen);
                }
                return step + 1;
            }
            else
            {
                return 0;
            }
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