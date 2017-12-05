using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradingStudents
{
    class Program
    {
        static int[] solve(int[] grades)
        {
            // Complete this function

            for (int i = 0; i < grades.Length; i++)
            {
                if (grades[i] % 5 != 0)
                {
                    int nearest = grades[i] % 5;
                    
                    if (nearest >= 3 && grades[i] > 35)
                    {
                        grades[i] = (grades[i] - nearest) + 5;
                    }
                }
            }

            return grades;
        }

        static void Main(string[] args)
        {
            int[] grades =
            {
                73,
                67,
                38,
                33
            };
            
            int[] result = solve(grades);
            Console.WriteLine(String.Join("\n", result));


            result = solve(new int[]{59, 80, 98, 76 });
            Console.WriteLine(String.Join("\n", result));
        }
    }
}
