using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximumRepeatedNumbers
{
    class Program
    {
        /*
         * Suppose array has series of numbers, if user wants to find maximum repeated number in an array.
         */
        static void Main(string[] args)
        {
            int[] arr = new int[] { 10, 20, 100, 100, 100, 10, 30, 20, 40, 50, 12, 14 };
            
            Console.WriteLine(FindMaxRepeat(arr));
            Console.WriteLine(FindMaxRepeat_SaveSpace(arr));
            Console.Read();
        }

        private static int FindMaxRepeat(int[] arr) //O(n) time, O(n) space
        {
            int max = -1;

            HashSet<int> seen = new HashSet<int>();

            foreach(var num in arr)
            {
                if (seen.Contains(num))
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

        //Assuming small result set.
        private static int FindMaxRepeat_SaveSpace(int[] arr) //O(n^2) time, O(1) space
        {
            InsertionSort(arr);

            for(int i = arr.Length - 1; 0 < i; i--)
            {
                if (arr[i] == arr[i - 1]) return arr[i];
            }

            return -1; //no repeating numbers;
        }

        static void InsertionSort(int [] arr) //Insertion sort is faster than QuickSort with smaller sets.
        {
            for (int i = 1; i < arr.Length; i++)
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
