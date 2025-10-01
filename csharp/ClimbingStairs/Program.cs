

/**
You are climbing a staircase. It takes n steps to reach the top.

Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?

 

Example 1:

Input: n = 2
Output: 2
Explanation: There are two ways to climb to the top.
1. 1 step + 1 step
2. 2 steps
Example 2:

Input: n = 3
Output: 3
Explanation: There are three ways to climb to the top.
1. 1 step + 1 step + 1 step
2. 1 step + 2 steps
3. 2 steps + 1 step
 

Constraints:

1 <= n <= 45
*/
public class Program
{
    static Dictionary<int, int> cache = new Dictionary<int, int>();

    public static void Main()
    {
        var n = 0;
        var expected = 0;
        var result = 0;

        Print(ClimbStairsLinear);
        Print(ClimbStairsCopilot);
        Print(ClimbStairs);

        void Print(Func<int, int> func)
        {
            //print method name
            Console.WriteLine(func.Method.Name + ": " + Environment.NewLine);

            //start timer
            var watch = System.Diagnostics.Stopwatch.StartNew();

            n = 2;
            expected = 2;
            result = func(n);
            Console.WriteLine($"Result: {result} Expected: {expected}");

            n = 3;
            expected = 3;
            result = func(n);
            Console.WriteLine($"Result: {result} Expected: {expected}");

            n = 4;
            expected = 5;
            result = func(n);
            Console.WriteLine($"Result: {result} Expected: {expected}");

            n = 45;
            expected = 1836311903;
            result = func(n);
            Console.WriteLine($"Result: {result} Expected: {expected}");

            //stop timer and print
            watch.Stop();
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms" + Environment.NewLine);

        }
    }

    static int ClimbStairs(int n)
    {
        if (n == 1)
        {
            return 1;
        }
        if (n == 2)
        {
            return 2;
        }

        if (cache.ContainsKey(n))
        {
            return cache[n];
        }

        var result = ClimbStairs(n - 1) + ClimbStairs(n - 2);

        cache.Add(n, result);

        return result;
    }

    static int ClimbStairsCopilot(int n)
    {
        if (n == 1)
        {
            return 1;
        }
        if (n == 2)
        {
            return 2;
        }
        int[] cache = new int[n + 1];
        cache[1] = 1;
        cache[2] = 2;
        for (int i = 3; i <= n; i++)
        {
            cache[i] = cache[i - 1] + cache[i - 2];
        }
        return cache[n];
    }

    static int ClimbStairsLinear(int n)
    {
        if (n <= 2) return n;

        int fib = 1;
        int last = 1;

        for (int i = 2; i <= n; i++)
        {
            int temp = fib;
            fib += last;
            last = temp;
        }

        return fib;
    }
}