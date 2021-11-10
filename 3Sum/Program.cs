using System;
using System.Collections.Generic;
using System.Linq;

namespace _3Sum
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }


    public class Solution
    {
        //[-1, 0, 1, 2, -1, -4]
        public IList<IList<int>> ThreeSum1(int[] nums)
        {
            Array.Sort(nums);
            var resultSet = new List<IList<int>>();
            for (int start = 0; start < nums.Length - 2; start++)
            {
                if (start > 0 && nums[start] == nums[start - 1]) continue;

                int mid = start + 1, end = nums.Length - 1;

                while (mid < nums.Length - 1)
                {
                    if (nums[mid] + nums[end] > -nums[start])
                    {
                        end--;
                    }
                    else if (nums[mid] + nums[end] < -nums[start])
                    {
                        mid++;
                    }
                    else
                    {
                        var set = new List<int>
                    {
                       nums[start],
                       nums[mid],
                       nums[end]
                    };

                        resultSet.Add(set);
                    }
                    while (++mid < nums.Length && nums[mid] == nums[mid - 1]) ;
                    while (--end > start && nums[end] == nums[end + 1]) ;
                }
<<<<<<< HEAD
=======

                while (++mid < nums.Length && nums[mid] == nums[mid - 1]) ;
                while (--end > start && nums[end] == nums[end + 1]) ;
>>>>>>> b28b0ab3d6844b12f31943ebb5d0f2bf6e1aa747
            }

            return resultSet;
        }

        //my approach, doesn't pass the speed test but does have correct answer
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            var resultSet = new List<IList<int>>();
            var usedMap = new HashSet<string>();

            var nm = nums.ToList();
            nm.Sort();
            nums = nm.ToArray();

            int low = 0;
            while (low < nums.Length - 2 && nums[low] <= 0)
            {
                int high = nums.Length - 1;

                while (nums[high] >= 0 && high > 1)
                {
                    int mid = low + 1;

                    while (mid < high)
                    {
                        int sum = nums[low] + nums[mid] + nums[high];
                        if (sum == 0 && !usedMap.Contains($"{nums[low]}{nums[mid]}{nums[high]}"))
                        {
                            var set = new List<int>
                        {
                           nums[low],
                           nums[mid],
                           nums[high]
                        };

                            resultSet.Add(set);
                            usedMap.Add($"{nums[low]}{nums[mid]}{nums[high]}");
                        }

                        mid++;
                    }

                    high--;
                }

                low++;
            }
            return resultSet;
        }
    }
}
