using System;
using System.Numerics;

namespace BigSorting
{
    class Program
    {
        //NOTE: Did it manually for good training, but it could be easily done using Array.Sort with a customized comparer.
        /*
         * Consider an array of numeric strings, , where each string is a positive number with anywhere from  to  digits. Sort the array's elements in non-decreasing (i.e., ascending) order of their real-world integer values and print each element of the sorted array on a new line.

Input Format

The first line contains an integer, , denoting the number of strings in . 
Each of the  subsequent lines contains a string of integers describing an element of the array.
         */
        static void Main(string[] args)
        {
            string[] input =
            {
                "6",
                "31415926535897932384626433832795",
                "1",
                "3",
                "10",
                "3",
                "5"
            };

            Sort(input);

            foreach (string n in input)
            {
                Console.WriteLine(n);
            }


            string[] input2 =
            {
                "200000",
                "42969"
            };

            Sort(input2);

            foreach (string n in input2)
            {
                Console.WriteLine(n);
            }
        }

        static void Sort(string[] arr)
        {
            Sort(arr, 0, arr.Length - 1);
        }

        static void Sort(string[] arr, int left, int right)
        {
            if (left < right)
            {
                int index = Partition(arr, left, right);

                Sort(arr, left, index - 1);
                Sort(arr, index, right);
            }
        }

        private static int Partition(string[] arr, int left, int right)
        {
            string pivot = arr[(left + right) / 2];

            while(left <= right)
            {
                while (IsBigger(pivot, arr[left] ?? "0")) left++;
                while (IsBigger(arr[right] ?? "0", pivot)) right--;

                if (left <= right)
                {
                    //swap
                    string temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;

                    left++;
                    right--;
                }
            }

            return left;
        }

        private static bool IsBigger(string left, string right)
        {
            left = left.Trim();
            right = right.Trim();

            if (left.Length > right.Length) return true;
            if (right.Length > left.Length) return false;
            
            for (int i = 0; i < left.Length; i++) //equal length
            {
                if (left[i] > right[i]) return true;
                if (right[i] > left[i]) return false;
            }

            return false; //They're equal
        }
    }
}
