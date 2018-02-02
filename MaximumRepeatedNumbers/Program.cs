using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumRepeatedNumbers
{
    internal class Program
    {
        /*
         * Suppose array has series of numbers, if user wants to find maximum repeated number in an array.
         */

        private static void Main(string[] args)
        {
            int missing = FindMissing(new int[] { 5, 4, 3, 1, 0 });
            int missing2 = FindMissing(new int[] { 5, 4, 2, 1, 0 });

            int missing3 = FindMissing2(new int[] { 5, 4, 3, 1, 0 });
            int missing4 = FindMissing2(new int[] { 5, 4, 2, 1, 0 });

            Console.WriteLine();


            //int[] arr = new int[] { 10, 20, 100, 100, 100, 10, 30, 20, 40, 50, 12, 14 };

            //Console.WriteLine(FindMaxRepeat(arr));
            //Console.WriteLine(FindMaxRepeat_SaveSpace(arr));
            //Console.Read();

            //Console.WriteLine(FindMissing(new int[] { 5, 4, 3, 1, 0 }));
        }

        private static int FindMaxRepeat(int[] arr) //O(n) time, O(n) space
        {
            int max = -1;

            HashSet<int> seen = new HashSet<int>();

            foreach(var num in arr)
            {
                if(seen.Contains(num))
                {
                    if(max < num)
                    {
                        max = num;
                    }
                }

                seen.Add(num);
            }

            return max;
        }

        private static int FindMissing(int[] arr) //O(n) time, O(n) space
        {
            int sum = arr.Sum();

            int total = (arr.Length+1) * arr.Length / 2;
            int result = total - sum;

            return result;
        }

        private static int FindMissing2(int[] arr) //O(n) time, O(n) space
        {
            Array.Sort(arr);
            int last=arr[0];

            foreach(int num in arr)
            {
                if(num == arr[0]) continue;

                if(num != last+1)
                {
                    return last + 1;
                }

                last = num;
            }

            return -1;
        }

        //Assuming small result set.
        private static int FindMaxRepeat_SaveSpace(int[] arr) //O(n^2) time, O(1) space
        {
            InsertionSort(arr);

            for(int i = arr.Length - 1; 0 < i; i--)
            {
                if(arr[i] == arr[i - 1]) return arr[i];
            }

            return -1; //no repeating numbers;
        }

        private static void InsertionSort(int[] arr) //Insertion sort is faster than QuickSort with smaller sets.
        {
            for(int i = 1; i < arr.Length; i++)
            {
                int inner = i;
                int value = arr[inner];

                while(inner > 0 && arr[inner - 1] > value)
                {
                    arr[inner] = arr[inner - 1];
                    arr[inner - 1] = value;

                    inner--;
                }

                arr[inner] = value;
            }
        }
    }
}