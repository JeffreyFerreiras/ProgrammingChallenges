using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneWay
{
    class Program
    {
        /*
         * There are 3 types of edits that can be performed on strings.
         * insert a character, remove a character or replace a character.
         * given two strings, write a function to check if they are one (or 0) edits away.
         */

        static void Main(string[] args)
        {
            bool oneWay = IsMaxOneEditAway(null, "");
            oneWay = IsMaxOneEditAway("", "");
            oneWay = IsMaxOneEditAway("pale", "ple"); //true
            oneWay = IsMaxOneEditAway("pale", "bale"); //true
        }

        static bool IsMaxOneEditAway(string source, string target)
        {
            if (source == null || target == null) return false;
            if (source == target) return true;

            if (source.Length == target.Length)
                return OneEditReplace(source, target);
            else if (source.Length == target.Length + 1)
                return OneEditInsertOrRemove(source, target);
            else if (source.Length == target.Length - 1)
                return OneEditInsertOrRemove(source, target);

            return false;
        }

        private static bool OneEditInsertOrRemove(string source, string target)
        {
            bool foundDiff = false;

            int longerIndex=0, shorterIndex=0;

            string longer = source.Length > target.Length ? source : target;
            string shorter = source.Length > target.Length ? target : source;

            while (longerIndex < longer.Length && shorterIndex < shorter.Length)
            {
                if(longer[longerIndex] != shorter[shorterIndex])
                {
                    if (foundDiff)
                        return false;

                    foundDiff = true;

                    longerIndex++;
                }
                else
                {
                    shorterIndex++;
                    longerIndex++;
                }
            }

            return true;
        }

        private static bool OneEditReplace(string source, string target)
        {
            bool foundDiff = false;

            for (int i = 0; i < source.Length; i++)
            {
                if(source[i] != target[i])
                {
                    if (foundDiff)
                        return false;

                    foundDiff = true;
                }
            }

            return true;
        }
    }
}
