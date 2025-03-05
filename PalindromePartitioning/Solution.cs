public class Solution
{
    public IList<IList<string>> Partition(string s)
    {
        List<IList<string>> result = [];
        Par([], s);
        return result;

        void Par(List<string> parts, string val)
        {
            if (val == string.Empty)
            {
                result.Add([.. parts]);
                return;
            }

            for (int i = 0; i < val.Length; i++)
            {
                var par = val[..(i + 1)];
                if (!IsPalim(par))
                {
                    continue;
                }
                parts.Add(par);
                Par(parts, val[(i + 1)..]);
                parts.RemoveAt(parts.Count - 1);
            }
        }
    }

    private static bool IsPalim(string s)
    {
        int low = 0, high = s.Length - 1;
        while (low < high)
        {
            if (s[low++] != s[high--])
            {
                return false;
            }
        }
        return true;
    }
}