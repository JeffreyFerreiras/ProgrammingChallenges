public class Solution_Iterative
{
    // Returns the number of ways to decode the string
    public int NumDecodings(string encodedString)
    {
        if (string.IsNullOrEmpty(encodedString) || encodedString[0] == '0') return 0;
        int length = encodedString.Length;
        int[] ways = new int[length + 1];
        ways[length] = 1;
        for (int index = length - 1; index >= 0; index--)
        {
            if (encodedString[index] == '0')
            {
                ways[index] = 0;
                continue;
            }
            ways[index] = ways[index + 1];
            if (index + 1 < length)
            {
                int twoDigitValue = (encodedString[index] - '0') * 10 + (encodedString[index + 1] - '0');
                if (twoDigitValue >= 10 && twoDigitValue <= 26)
                    ways[index] += ways[index + 2];
            }
        }
        return ways[0];
    }
}