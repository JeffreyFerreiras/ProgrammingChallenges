using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staircase
{
    class Program
    {
        /* Example
             #
            ##
           ###
          ####
         #####
        ######

        Input Format

        A single integer, , denoting the size of the staircase.

        Output Format

        Print a staircase of size  using # symbols and spaces.

        Note: The last line must have  spaces in it.
                */

        static void Main(String[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            //SOLUTION.
            StringBuilder floor = new StringBuilder(n*n);
            for(int i = 1; i < n + 1; i++)
            {
                floor.Append(' ', n - i);
                floor.Append('#', i);
                if(n != i) floor.Append(Environment.NewLine);
            }
            Console.WriteLine(floor);
            Console.ReadLine();
        }
    }
}
