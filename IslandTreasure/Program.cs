using System.Diagnostics;

namespace IslandTreasure;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Island Treasure Problem");
        Console.WriteLine("======================\n");
        
        // Print problem statement
        Console.WriteLine("Given a grid with treasures (0), water (-1), and land (INF/2147483647),");
        Console.WriteLine("fill each land cell with the distance to its nearest treasure chest.");
        Console.WriteLine("If a land cell cannot reach a treasure chest, it remains INF.\n");
        
        Console.WriteLine("Running test cases...");
        
        // Test cases from the problem description
        var testCases = new List<(int[][] grid, int[][] expected)>
        {
            (new int[][] { 
                new int[] {2147483647, -1, 0, 2147483647},
                new int[] {2147483647, 2147483647, 2147483647, -1},
                new int[] {2147483647, -1, 2147483647, -1},
                new int[] {0, -1, 2147483647, 2147483647}
            }, 
            new int[][] { 
                new int[] {3, -1, 0, 1},
                new int[] {2, 2, 1, -1},
                new int[] {1, -1, 2, -1},
                new int[] {0, -1, 3, 4}
            }),
            
            (new int[][] { 
                new int[] {0, -1},
                new int[] {2147483647, 2147483647}
            }, 
            new int[][] { 
                new int[] {0, -1},
                new int[] {1, 2}
            })
        };
        
        // Create solution instance
        var solution = new Solution();
        
        // Run and time each test case
        for (int i = 0; i < testCases.Count; i++)
        {
            Console.WriteLine($"\n{"=".PadRight(50, '=')}");
            Console.WriteLine($"TEST CASE {i + 1}");
            Console.WriteLine($"{"=".PadRight(50, '=')}\n");
            
            RunTestCase(solution, testCases[i].grid, testCases[i].expected);
        }
    }
    
    static void RunTestCase(Solution solution, int[][] grid, int[][] expected)
    {
        // Create deep copy of grid for display purposes
        int[][] originalGrid = grid.Select(row => row.ToArray()).ToArray();
        
        // Display the grid
        Console.WriteLine("📋 Input Grid:");
        PrintGrid(originalGrid);
        Console.WriteLine();
        
        // Create a stopwatch to measure execution time
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        
        // Call the solution method
        solution.IslandsAndTreasure(grid);
        
        // Stop timing
        stopwatch.Stop();
        
        // Print results
        Console.WriteLine("⏱️ Performance:");
        Console.WriteLine($"  Method: IslandsAndTreasure");
        Console.WriteLine($"  Time: {stopwatch.ElapsedTicks} ticks ({stopwatch.ElapsedMilliseconds} ms)\n");
        
        Console.WriteLine("🔄 Result Grid:");
        PrintGrid(grid);
        Console.WriteLine();
        
        Console.WriteLine("🎯 Expected Grid:");
        PrintGrid(expected);
        Console.WriteLine();
        
        // Compare grids
        bool match = CompareGrids(grid, expected);
        
        // Print result with color
        Console.Write("Status: ");
        
        ConsoleColor originalColor = Console.ForegroundColor;
        if (match) {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("✓ CORRECT");
        } else {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("❌ INCORRECT");
        }
        Console.ForegroundColor = originalColor;
    }
    
    static void PrintGrid(int[][] grid)
    {
        int maxWidth = 0;
        
        // Find the maximum width needed for any number in the grid
        foreach (var row in grid)
        {
            foreach (var cell in row)
            {
                int width = cell.ToString().Length;
                if (width > maxWidth) maxWidth = width;
            }
        }
        
        // Print each row with proper alignment
        foreach (var row in grid)
        {
            Console.Write("  [");
            for (int i = 0; i < row.Length; i++)
            {
                string cellStr = row[i].ToString().PadLeft(maxWidth);
                Console.Write(cellStr);
                
                if (i < row.Length - 1)
                    Console.Write(", ");
            }
            Console.WriteLine("]");
        }
    }
    
    static bool CompareGrids(int[][] grid1, int[][] grid2)
    {
        if (grid1.Length != grid2.Length) return false;
        
        for (int i = 0; i < grid1.Length; i++)
        {
            if (grid1[i].Length != grid2[i].Length) return false;
            
            for (int j = 0; j < grid1[i].Length; j++)
            {
                if (grid1[i][j] != grid2[i][j]) return false;
            }
        }
        
        return true;
    }
}
