using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPermutations
{
    /*
    QuickSort algorithm implementation for sorting characters.
    */
    class QuickSort
    {
        public static string QuickSorter(string str)
        {
            char[] sorterArry = str.ToArray();
            QuickSorter(sorterArry, 0, sorterArry.Length - 1);
            return new string(sorterArry);
        }
        private static void QuickSorter(char[] sorterArry, int leftIndex, int rightIndex)
        {
            int pivotIndex = GetPivotPoint(sorterArry, leftIndex, rightIndex);

            if(leftIndex < pivotIndex -1)
                QuickSorter(sorterArry, leftIndex, pivotIndex - 1);

            if(pivotIndex < rightIndex)
                QuickSorter(sorterArry, pivotIndex, rightIndex);
        }
        private static int GetPivotPoint(char[] sorterArry, int leftIndex, int rightIndex)
        {
            char pivot = sorterArry[(leftIndex + rightIndex) / 2];

            while(leftIndex <= rightIndex)
            {
                while(sorterArry[leftIndex] < pivot)
                    leftIndex++;
                while(sorterArry[rightIndex] > pivot)
                    rightIndex--;      

                if(leftIndex <= rightIndex)
                {
                    //swap values
                    char temp = sorterArry[leftIndex];
                    sorterArry[leftIndex] = sorterArry[rightIndex];
                    sorterArry[rightIndex] = temp;

                    leftIndex++;
                    rightIndex--;
                }
            }
            return leftIndex;
        }
    }
}
