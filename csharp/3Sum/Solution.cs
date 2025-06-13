using System;
using System.Collections.Generic;
using System.Linq;

namespace _3Sum
{
    public class Solution
    {
        // correct 3Sum solution
        // n ^ 2 solution
        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            IList<IList<int>> output = [];
            if (nums.Length < 3)
            {
                return output;
            }

            Array.Sort(nums);
            var seen = new HashSet<string>();

            for (int i = 0; i < nums.Count() - 2; i++)
            {
                for (int j = i + 1; j < nums.Count() - 1; j++)
                {
                    int difference = (nums[i] + nums[j]) * -1;
                    int diffIndex = Array.BinarySearch(nums, j + 1, nums.Count() - j - 1, difference);
                    if (diffIndex >= 2 && diffIndex != i && diffIndex != j)
                    {
                        var answer = new List<int> { nums[i], nums[j], difference };
                        answer.Sort();
                        var ansKey = string.Join(',', answer);
                        if (seen.Contains(ansKey))
                        {
                            continue;
                        }

                        output.Add(answer);
                        seen.Add(ansKey);
                    }
                }
            }

            return output;
        }

        // n ^ 2 solution
        public static IList<IList<int>> ThreeSumX(int[] nums)
        {
            var result = new List<IList<int>>();
            var lookUp = new Dictionary<int, List<int>>();
            var usedIndex = new HashSet<string>();
            
            for (int i = 0; i < nums.Length; i++)
            {
                if (!lookUp.TryGetValue(nums[i], out List<int> value))
                {
                    lookUp.Add(nums[i], [i]);
                }
                else
                {
                    value.Add(i);
                }
            }

            for (int i = 0; i < nums.Length - 2; i++)
            {
                for (int j = i + 1; j < nums.Length - 1; j++)
                {
                    var missing = (nums[i] + nums[j]) * -1;
                    if (lookUp.TryGetValue(missing, out List<int> missingIndex))
                    {
                        foreach (var index in missingIndex)
                        {
                            if (index > j)
                            {
                                var answer = new List<int> { nums[i], nums[j], missing };
                                answer.Sort();
                                var ansKey = string.Join(',', answer);
                                if (usedIndex.Contains(ansKey))
                                {
                                    continue;
                                }

                                result.Add(answer);
                                usedIndex.Add(ansKey);
                            }
                        }
                    }
                }
            }

            return result;
        }
        
        // n ^ 3 solution
        public static IList<IList<int>> ThreeSumBrute(int[] nums)
        {
            IList<IList<int>> output = [];
            if (nums.Length < 3)
            {
                return output;
            }

            // brute force solution
            for (int i = 0; i < nums.Count() - 2; i++)
            {
                for (int j = i + 1; j < nums.Count() - 1; j++)
                {
                    for (int k = j + 1; k < nums.Count(); k++)
                    {
                        if (nums[i] + nums[j] + nums[k] == 0)
                        {
                            var ans = new List<int> { nums[i], nums[j], nums[k] };

                            output.Add(ans);
                        }
                    }
                }
            }
            return output;
        }
    }
    
}
