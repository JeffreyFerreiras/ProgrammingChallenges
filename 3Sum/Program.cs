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