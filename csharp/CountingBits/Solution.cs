namespace CountingBits;

class Solution
{
    public int[] CountBits(int n)
    {
        var result = new int[n + 1];
        for (int i = 0; i <= n; i++)
        {
            result[i] = CountOnes(i);
        }

        return result;
    }

    private int CountOnes(int n)
    {
        var count = 0;
        while (n > 0)
        {
            count += n & 1;
            n >>= 1;
        }

        return count;
    }
}