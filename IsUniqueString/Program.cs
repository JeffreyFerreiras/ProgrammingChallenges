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
            bool b = IsUniqueString("xyzabc");
        }
        static bool IsUniqueString(string str)
        { 
            //SOLUTION
            if(str.Length > 128)
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
