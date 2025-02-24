using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LetterCombinationsofAPhoneNumber;

public class Solution
{
    private Dictionary<char, string> phone = new Dictionary<char, string>
    {
        {'2', "abc"},
        {'3', "def"},
        {'4', "ghi"},
        {'5', "jkl"},
        {'6', "mno"},
        {'7', "pqrs"},
        {'8', "tuv"},
        {'9', "wxyz"}
    };

    public IList<string> LetterCombinations(string digits)
    {
        if (string.IsNullOrEmpty(digits)) return new List<string>();
        List<string> result = new();

        Backtrack(new StringBuilder(digits.Length), 0);

        return result.ToList();

        void Backtrack(StringBuilder prefix, int index)
        {
            if (digits.Length == prefix.Length)
            {
                result.Add(prefix.ToString());
            }
            else
            {
                var letters = phone[digits[index]];
                foreach (var letter in letters)
                {
                    prefix.Append(letter);
                    Backtrack(prefix, index + 1);
                    prefix.Length--; //remove last element in string builder
                }
            }
        }
    }
}