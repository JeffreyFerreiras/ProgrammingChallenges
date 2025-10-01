using System;
using System.Collections.Generic;
using System.Linq;

namespace Permutations
{
    class Program
    {
        /**
         * 
         *      Input: [1,2,3]
                Output:
                [
                  [1,2,3],
                  [1,3,2],
                  [2,1,3],
                  [2,3,1],
                  [3,1,2],
                  [3,2,1]
                ]
         * 
         */

        static void Main(string[] args)
        {
            foreach (var p in Permute([1, 2, 3]))
            {
                Console.WriteLine(string.Join(',', p));
            }

            Console.ReadLine();
        }

        public static IList<IList<int>> Permute(int[] nums)
        {
            var collector = new List<IList<int>>();

            Permute([], [.. nums], collector);

            return collector;
        }

        public static void Permute(IList<int> prefix, IList<int> remaining, IList<IList<int>> collector)
        {
            if (!remaining.Any())
            {
                collector.Add([.. prefix]);
            }
            else
            {
                for (int i = 0; i < remaining.Count(); i++)
                {
                    var num = remaining[i];

                    remaining.RemoveAt(i);

                    prefix.Add(num);

                    Permute(prefix, remaining, collector);

                    prefix.Remove(num);
                    remaining.Insert(i, num);
                }
            }
        }
    }
}
