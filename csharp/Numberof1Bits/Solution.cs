
public class Solution
{
    public int HammingWeight(uint n)
    {
        int count = 0;
        while (n > 0)
        {
            if ((n & 1) == 1)
            {
                count++;
            }
            n = n >> 1;
        }
        return count;
    }
}