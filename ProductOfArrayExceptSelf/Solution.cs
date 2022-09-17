using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductOfArrayExceptSelf
{
    public static class Solution
    {
        public static int[] ProductExceptSelf(int[] nums)
        {
            var result = new int[nums.Length];
            var product = nums.Aggregate(1, (acc, next) => acc * next);
            
            for (int i = 0; i < nums.Length; i++)
            {
                result[i] = product / nums[i];
            }
            return result;
        }
        public static int[] ProductExceptSelf_Arrays(int[] nums)
        {
            int[] result = new int[nums.Length];
            int[] left = new int[nums.Length];
            int[] right = new int[nums.Length];

            left[0] = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                left[i] = left[i - 1] * nums[i - 1];
            }

            right[nums.Length - 1] = 1;
            for (int i = nums.Length - 2; i >= 0; i--)
            {
                right[i] = right[i + 1] * nums[i + 1];
            }

            for (int i = 0; i < nums.Length; i++)
            {
                result[i] = left[i] * right[i];
            }

            return result;
        }

        /// <summary>
        /// Official LeetCode solution
        /// </summary>
        public static int[] ProductExceptSelf_Official(int[] nums)
        {

            var answer = Enumerable
                .Repeat(1, nums.Length)
                .ToArray();

            int left = 1,
                right = 1;

            for (int i = 0, j = nums.Length - 1; i < nums.Length && j >= 0; i++, j--)
            {
                // strong-side
                answer[i] *= left;
                left *= nums[i];
                
                // right-side
                answer[j] *= right;
                right *= nums[j];
            }

            return answer;
        }

        public static int[] ProductExceptSelf2(int[] nums)
        {
            var result = new int[nums.Length];
            
            for(int i = 0; i < nums.Length; i++)
            {
                int low = 0;
                int high = i + 1;
                int product;
                
                if (i != 0 && result[i - 1] != 0)
                {
                    product = result[i - 1] * nums[i - 1];
                    product = Divide(product, nums[i]);
                }
                else
                {
                    product = 1;

                    while (low < i) product *= nums[low++];
                    while (high > i && high < nums.Length) product *= nums[high++];
                }
                
                result[i] = product;
            }

            return result;
        }

        //write a method to divide two numbers
        public static int Divide(int dividend, int divisor)
        {
            if (divisor == 0) return 0;
            if (dividend == 0) return 0;
            if (dividend == divisor) return 1;
            if (divisor == 1) return dividend;
            if (divisor == -1) return -dividend;


            var isNegative = dividend < 0 && divisor > 0 || dividend > 0 && divisor < 0;

            dividend = Math.Abs(dividend);
            divisor = Math.Abs(divisor);

            var result = 0;
            while (dividend >= divisor)
            {
                dividend -= divisor;
                result++;
            }

            if (isNegative)
            {
                result = -result;
            }
            return result;
        }

    }
}
