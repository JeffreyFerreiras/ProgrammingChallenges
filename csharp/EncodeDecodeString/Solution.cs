namespace EncodeDecodeString;

public class Solution
{
    public string Encode(IList<string> strs)
    {
        // if empty, return empty string
        if (strs.Count == 0) return string.Empty;

        // empty string should still be retained, replace it with a special character
        for (int i = 0; i < strs.Count; i++)
        {
            if (strs[i] == string.Empty)
            {
                strs[i] = "┼";
            }
        }

        return string.Join("╤", strs);
    }

    public List<string> Decode(string s)
    {
        // if empty, return empty list
        if (s == string.Empty) return new List<string>();
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '┼')
            {
                s = s.Remove(i, 1).Insert(i, string.Empty);
            }
        }
        
        return s.Split("-").ToList();
    }
}
