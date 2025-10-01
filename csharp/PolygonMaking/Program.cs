using System;
using System.Linq;

namespace PolygonMaking
{
    class Program
    {
        /*
         *  A polygon is a closed shape with three or more sides.
         *  For example, triangles are polygons.
         *  A polygon is non-degenerate if it has no overlapping sides (and no sides of zero length).
         *  You have n sticks with positive integer lengths.
         *  You want to create a polygon using all n sticks. Because this is not always possible,
         *  you can cut one or more sticks into two smaller sticks
         *  (they do not necessarily need to be of integer length)
         *  and repeat the process of trying to create a polygon using all the sticks.
         *  Given the lengths of all  sticks,
         *  find and print the minimum number of cuts necessary to make a non-degenerate polygon.
         */
        static void Main(string[] args)
        {
            int sides = Convert.ToInt32(Console.ReadLine());
            string[] a_temp = Console.ReadLine().Split(' ');
            int[] sideLengths = Array.ConvertAll(a_temp, Int32.Parse);

            MinimumCuts(sideLengths);
        }

        private static int MinimumCuts(int[] sideLengths)
        {
            int cuts = 0;

            for (int i = 1; i < sideLengths.Length; i++)
            {
                if (sideLengths[i] >= sideLengths.Sum() / 2) cuts++;
            }

            return cuts;
        }
    }
}
