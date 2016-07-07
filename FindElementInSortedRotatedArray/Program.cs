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
        static int BinarySearch(int[] arry, int left, int right, int target)
        {
            //SOLUTION
            int mid = (left + right)/2; 
            if(target == arry[mid]) return mid; 
            if(right < left) return -1; 
                       
            if(arry[left] < arry[mid])
            {
                if(target >= arry[left] && target < arry[mid]) 
                    return BinarySearch(arry, left, mid - 1, target);
                else
                    return BinarySearch(arry, mid + 1, right, target);
            }
            else if(arry[left] > arry[mid])
            {
                if(target > arry[mid] && target < arry[right])
                    return BinarySearch(arry, mid + 1, right, target);
                else
                    return BinarySearch(arry, left, mid - 1, target);
            }
            else if (arry[left] == arry[mid])
            {
                if(arry[mid] != arry[right])
                    return BinarySearch(arry, mid + 1, right, target);
                else
                {
                    int result = BinarySearch(arry, left, mid -1, target);
                    if(result == -1)
                        return BinarySearch(arry, mid + 1, right, target); 
                    else
                        return result;
                }
            }
            return -1;
        }
    }
}
