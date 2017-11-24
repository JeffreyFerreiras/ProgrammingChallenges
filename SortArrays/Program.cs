using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortArrays
{
    class Program
    {
        /*
         * Write a function to sort 2 arrays of numbers (without using existing libraries).
         * Assume arrays are sorted.
         */
        static readonly Random _rand = new Random();
        static readonly object _lock = new object();

        static void Main(string[] args)
        {
            var arr1 = GetRandomArray();
            var arr2 = GetRandomArray();

            Array.Sort(arr1);
            Array.Sort(arr2);

            var m = Merge(arr1, arr2);

            Print(arr1);
            Print(arr2);
            Print(m);

            Console.Read();
        }

        static void Print(int[] arr)
        {
            foreach (var n in arr)
            {
                Console.WriteLine(n);
            }

            Console.WriteLine();
        }

        private static int[] Merge(int[] arrFirst, int[] arrSecond)
        {
            var merged = new int[arrFirst.Length + arrSecond.Length];
            int iMerged = 0, iFirst = 0, iSecond = 0;
            
            while (iMerged < merged.Length && iFirst < arrFirst.Length && iSecond < arrSecond.Length)
            {
                if(arrFirst[iFirst] < arrSecond[iSecond])
                {
                    merged[iMerged] = arrFirst[iFirst++];
                }
                else
                {
                    merged[iMerged] = arrSecond[iSecond++];
                }

                iMerged++;
            }

            //tail
            
            CopyTail(merged, iFirst > iSecond ? arrSecond : arrFirst, iMerged, iFirst > iSecond ? iSecond : iFirst);

            return merged;
        }

        static void CopyTail(int[]combined, int[]arr, int current, int bigArrIndex)
        {
            for (int i = current; i < combined.Length && bigArrIndex < arr.Length; i++, bigArrIndex++)
            {
                combined[i] = arr[bigArrIndex];
            }
        }
        

        static int[] GetRandomArray(int count = 10)
        {
            var arr = new int[count];

            for (int i = 0; i < arr.Length; i++)
            {
                lock (_lock)
                {
                    arr[i] = _rand.Next(0, 101);
                }
            }

            return arr;
        }
    }

    
}
