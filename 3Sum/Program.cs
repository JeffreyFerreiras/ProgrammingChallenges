using System;
using System.Collections.Generic;
using System.Linq;

namespace _3Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}


public class Solution
{
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        var resultSet = new List<IList<int>>();
        var n = nums.Length;
        var usedMap = new HashSet<string>();

        var nm = nums.ToList();
        nm.Sort();
        nums = nm.ToArray();

        int highStart = nums.Length - 1;
        int lowStart = 0;

        int low = lowStart;
        int mid = low + 1;
        int high = highStart;
        int sum = 0;

        bool isLowsMove = true;

        while (low < nums.Length - 2 && nums[low] <= 0)
        {
            high = nums.Length - 1;

            while (nums[high] >= 0 && high > 1)
            {
                mid = low + 1;

                while (mid < high)
                {
                    sum = nums[low] + nums[mid] + nums[high];

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