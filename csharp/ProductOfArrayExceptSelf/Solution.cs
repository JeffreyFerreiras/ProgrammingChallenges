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

        public static int[] ProductExceptSelf_2025(int[] nums)
        {
            int[] result = new int[nums.Length];
            int zeros = 0;
            result[0] = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    zeros++;
                }

                if (zeros > 1)
                {
                    return new int[nums.Length];
                }

                result[i] = result[i - 1] * nums[i];
            }
            int prev = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0) // there will only be 1 0
                {
                    result[i] = i > 0 ? prev : 1;
                    int j = i + 1;
                    while (j < nums.Length)
                    {
                        result[i] *= nums[j++];
                    }

                    continue;
                }

                prev = result[i];
                result[i] = result[nums.Length - 1] / nums[i];
            }

            return result;
        }

        public static int[] ProductExceptSelf_2025_Clean(int[] nums)
        {
            int length = nums.Length;
            int[] result = new int[length];

            // Count zeros and calculate product of all non-zero elements
            int zeroCount = 0;
            int productNonZero = 1;

            foreach (int num in nums)
            {
                if (num == 0)
                    zeroCount++;
                else
                    productNonZero *= num;
            }

            // If more than one zero, all products will be zero
            if (zeroCount > 1)
                return new int[length]; // Returns array filled with zeros

            // If exactly one zero, only the element at the zero position will have a non-zero value
            if (zeroCount == 1)
            {
                for (int i = 0; i < length; i++)
                {
                    result[i] = nums[i] == 0 ? productNonZero : 0;
                }
                return result;
            }

            // No zeros - each result is product of all divided by current element
            for (int i = 0; i < length; i++)
            {
                result[i] = productNonZero / nums[i];
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
        /// JF 3/2025 - forgot about this! nice solution.
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

        /// <summary>
        /// Some people's first attempt - brute force O(n^2) solution. Not efficient but works and is easy to understand.
        /// In practice, this solution is very performant with the test cases provided, but it will struggle with larger inputs due to its O(n^2) time complexity. It's a good starting point for understanding the problem before optimizing.
        /// </summary>
        public static int[] ProductExceptSelf_2026(int [] nums)
        {
            int[] answer = new int[nums.Length];

            for (int i = 0; i < nums.Length; i++)
            {
                answer[i] = Mult(i);
            }
            
            return answer;

            int Mult(int skipIndex)
            {
                int product = 1;
                for (int j = 0; j < nums.Length; j++)
                {
                    if(j == skipIndex) continue;
                    product *= nums[j];
                }
                return product;
            }
        }

        /// <summary>
        /// What if we do one pass to multiply all the numbers together, and then a second pass to divide by each number? This is O(n) time but also O(1) space (ignoring the output array).
        /// This is a common solution to this problem, but it has a major flaw: it doesn't handle zeros correctly. If there's a zero in the input array, the product will be zero and all results will be zero, which is not correct.
        /// </summary>
        /// <remarks>
        /// The updated logic does the right thing:
        /// - If there are 2+ zeros: return all zeros.
        /// - If there is exactly 1 zero:
        ///  - the zero position gets the product of all non-zero values
        ///  - all other positions get zero.
        /// - If there are no zeros: return product divided by each element.
        /// </remarks>
        public static int[] ProductExceptSelf_2026_Divide(int[] nums)
        {
            int[] answer = new int[nums.Length];
            int product = 1;


            int zeroCount = nums.Count(n => n == 0);
            
            if (zeroCount > 1)
            {
                return answer; // all zeros
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0) continue; // skip the 1 zero
                product *= nums[i];
            }

            // if we get here, there are either 0 or 1 zeros in the input
            // get the index of the zero (if it exists) and set that position
            // to the product of all non-zero values, and all other positions to zero
            int zeroIndex = Array.IndexOf(nums, 0);

            if (zeroIndex != -1)
            {
                answer[zeroIndex] = product;
                return answer; // all other positions are already zero
            }

            for (int i = 0; i < nums.Length; i++)
            {
                answer[i] = product / nums[i];
            }

            return answer;
        }
    }
}
