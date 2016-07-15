using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindElementInSortedRotatedArray
{
    class Program
    {
        /*
        1) Given a rotated sorted array, find the first occurrence of a certain number X with the lowest possible complexity(both time and space).
        */

/*
Notes: Algorithm -

1) Create a method and prep for a recursive bin search.
2) Check if the array[mid] point is equal to the target, if it is, return the mid point.
3) Error Check: that left is not bigger than right...We're doing recursion here! mmmkay.
4) Check if the left side is ordered
	a) if target is between left and mid, recur left to mid-1.
	b) else recur mid+1 to right	
5) Check if the right side is ordered, if it is
	a) if target is between mid+1 to right, recur mid +1 to right.
	b) else recur left to mid-1;
6) Check if left equals mid of arrary values.
	a) if mid does not equal right array value, recur mid+1 to right
	b) else recur left to mid-1 and store result in an integer.
		1) if the result is -1, not found, then recur mid+1 to right.
		2) else return result.
7) Let recursion take care of the rest.
*/
        
        static void Main(string[] args)
        {
            //Test code.
            int[] rotatedArry = { 3,4,5,1,2 };
            int x = 4, left = 0, right = rotatedArry.Length -1;
            // END TEST
            int indexofX = BinarySearch(rotatedArry, left, right, x);
        }
        static int BinarySearch(int[] arry, int leftIndex, int rightIndex, int target)
        {
            //SOLUTION - Lengthy solution, but the requirement stated "lowest possible complexity(both time and space)"
            //This solution is O(log N)

            int mid = (leftIndex + rightIndex)/2;
             
            if(target == arry[mid]) return mid; 
            if(rightIndex < leftIndex) return -1; 
                       
            if(arry[leftIndex] < arry[mid])
            {
                if(target >= arry[leftIndex] && target < arry[mid]) 
                    return BinarySearch(arry, leftIndex, mid - 1, target);
                else
                    return BinarySearch(arry, mid + 1, rightIndex, target);
            }
            else if(arry[leftIndex] > arry[mid])
            {
                if(target > arry[mid] && target < arry[rightIndex])
                    return BinarySearch(arry, mid + 1, rightIndex, target);
                else
                    return BinarySearch(arry, leftIndex, mid - 1, target);
            }
            else if (arry[leftIndex] == arry[mid])
            {
                if(arry[mid] != arry[rightIndex])
                    return BinarySearch(arry, mid + 1, rightIndex, target);
                else
                {
                    int result = BinarySearch(arry, leftIndex, mid -1, target);
                    if(result == -1)
                        return BinarySearch(arry, mid + 1, rightIndex, target); 
                    else
                        return result;
                }
            }
            return -1;
        }
    }
}
