using System;

namespace SortArrays
{
    class Program
    {
        /*
         * Write a function to sort 2 arrays of numbers (without using existing libraries).
         * Assume arrays are sorted.
         */
        static readonly Random _rand = new();
        static readonly object _lock = new();

        static void Main(string[] args)
        {
            var generatedArray = GetRandomArray();
            var generatedArray2 = GetRandomArray();

            Array.Sort(generatedArray);
            Array.Sort(generatedArray2);

            var m = Merge(generatedArray, generatedArray2);

            Print(generatedArray);
            Print(generatedArray2);
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

        static int[] GetRandomArray(int count = 10)
        {
            var arr = new int[count];

            for (int i = 0; i < arr.Length; i++)
            {
                lock (_lock)
                {
                    arr[i] = _rand.Next(0, 1500);
                }
            }

            return arr;
        }

        //Merge two sorted arrays
        private static int[] Merge(int[] firstArray, int[] secondArray)
        {
            var mergedArray = new int[firstArray.Length + secondArray.Length];
            int mergedIndex = 0, firstIndex = 0, secondIndex = 0;

            while (mergedIndex < mergedArray.Length && firstIndex < firstArray.Length && secondIndex < secondArray.Length)
            {
                if (firstArray[firstIndex] < secondArray[secondIndex])
                {
                    mergedArray[mergedIndex] = firstArray[firstIndex++];
                }
                else
                {
                    mergedArray[mergedIndex] = secondArray[secondIndex++];
                }

                mergedIndex++;
            }

            int bigArrayIndex = Math.Min(firstIndex, secondIndex);
            int[] remainingArray = firstIndex > secondIndex ? secondArray : firstArray;
            
            for (int i = mergedIndex; i < mergedArray.Length && bigArrayIndex < remainingArray.Length; i++, bigArrayIndex++)
            {
                mergedArray[i] = remainingArray[bigArrayIndex];
            }

            return mergedArray;
        }
    }
}
