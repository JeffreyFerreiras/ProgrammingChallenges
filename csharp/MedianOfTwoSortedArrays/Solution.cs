using System.Security.Principal;

namespace MedianOfTwoSortedArrays;

public class Solution
{
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        if (nums1.Length == 0 && nums2.Length == 0)
            return 0.0;
        int totalLength = nums1.Length + nums2.Length;
        int medianIndexMax = totalLength / 2;
        int left = 0,
            right = 0;
        int medianIndex = 0;
        int[] medians = [int.MinValue, int.MinValue];

        while (medianIndex <= medianIndexMax && (left < nums1.Length || right < nums2.Length))
        {
            if (left < nums1.Length && right < nums2.Length)
            {
                if (nums1[left] <= nums2[right])
                {
                    medians[medianIndex % 2] = nums1[left];
                    left++;
                }
                else
                {
                    medians[medianIndex % 2] = nums2[right];
                    right++;
                }
            }
            else if (left < nums1.Length)
            {
                medians[medianIndex % 2] = nums1[left];
                left++;
            }
            else if (right < nums2.Length)
            {
                medians[medianIndex % 2] = nums2[right];
                right++;
            }

            medianIndex++;
        }

        return totalLength % 2 == 0
            ? (medians[0] + medians[1]) / 2.0 
            : medians[medianIndexMax % 2];
    }
}
