using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsUniqueString
{
    class Program
    {
        /*
        Write a program to determine if a string contains all unique characters.
        */
        static void Main(string[] args)
        {
            //TEST CODE
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            bool first = IsUniqueString("xyzabc");
            stopwatch.Stop(); //6276 ticks - This shows the shorter answer isn't always best for performance.

            System.Diagnostics.Stopwatch stopwatch2 = new System.Diagnostics.Stopwatch();
            stopwatch2.Start();
            bool second = IsUniqueStringWithoutIEnumerable("xyzabc");
            stopwatch2.Stop(); //539 ticks
            //END TEST CODE 
        }
        static bool IsUniqueString(string str)
        {
            //SOLUTION - one liner.
            return str.Length > 128 ? false : str.Length == str.Distinct().Count();
        }
        static bool IsUniqueStringWithoutIEnumerable(string str)
        {
            //SOLUTION with better time and space complexity. 
            if( !string.IsNullOrEmpty(str) && str.Length > 128)
                return false;

            while(str.Length > 0)
            {
                var character = str[0];
                str = str.Substring(1);
                if(str.Contains(character))
                    return false;
            }
            return true;
        }
    }
}
