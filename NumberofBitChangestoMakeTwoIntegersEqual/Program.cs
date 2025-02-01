/*You are given two positive integers n and k.

You can choose any bit in the binary representation of n that is equal to 1 and change it to 0.

Return the number of changes needed to make n equal to k. If it is impossible, return -1.

 

Example 1:

Input: n = 13, k = 4

Output: 2

Explanation:
Initially, the binary representations of n and k are n = (1101)2 and k = (0100)2.
We can change the first and fourth bits of n. The resulting integer is n = (0100)2 = k.

Example 2:

Input: n = 21, k = 21

Output: 0

Explanation:
n and k are already equal, so no changes are needed.

Example 3:

Input: n = 14, k = 13

Output: -1

Explanation:
It is not possible to make n equal to k.

 

Constraints:

1 <= n, k <= 106
    */

using System.Diagnostics;

namespace NumberofBitChangestoMakeTwoIntegersEqual;

public class Program
{
    private static Stopwatch s_stopwatch = new();

    static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");

        TestMinChanges(13, 4, 2);
        TestMinChanges(21, 21, 0);
        TestMinChanges(14, 13, -1);
        TestMinChanges(8, 0, 1); // Additional test case
        TestMinChanges(15, 7, 1); // Additional test case
        TestMinChanges(1024, 512, 1); // Additional test case
        TestMinChanges(255, 128, 1); // Additional test case
        TestMinChanges(1000000, 999999, -1); // Additional test case
    }

    private static void TestMinChanges(int n, int k, int expected)
    {
        s_stopwatch.Reset();
        s_stopwatch.Start();

        int result = MinChanges(n, k);

        s_stopwatch.Stop();

        Console.WriteLine($"Method: MinChanges, Input: (n={n}, k={k}), Result: {result}, Expected: {expected}, Time: {s_stopwatch.ElapsedTicks} ticks");
    }

    public static int MinChanges(int n, int k)
    {
        int count = 0;

        if (n == k) return 0;
        if (n < k) return -1;

        //while n not 0
        while (n > 0)
        {

            //pop last bit
            var nBit = n & 1;
            var kBit = k & 1;

            //increment the count
            if (nBit != kBit)
            {
                if (nBit == 0 && kBit == 1)
                {
                    return -1; //only nbit can be changed and only if its 1 flip to 0
                }
                count++;
            }

            //shift bits right
            n >>= 1;
            k >>= 1;
        }

        return count;
    }
}
