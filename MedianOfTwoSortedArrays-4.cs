
namespace LeetCode;

public partial class Solution
{
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        double avg(int d1, int d2) => (d1 + d2) / 2d;

        double median(int[] arr)
        {
            var len = arr.Length;
            var isEven = len % 2 == 0;
            return isEven ? (arr[len / 2 - 1] + arr[len / 2]) / 2d : arr[len / 2];
        }

        double sortedArrays(int[] lower, int[] higher)
        {
            int len = lower.Length + higher.Length;
            var isEven = len % 2 == 0;
            var index = (len - 1) / 2;
            if (lower.Length <= index && isEven) return avg(higher[index - lower.Length], higher[index - lower.Length + 1]);
            if (lower.Length <= index && !isEven) return higher[index - lower.Length];

            if (lower.Length == index + 1 && isEven) return avg(lower[lower.Length - 1], higher[0]);

            if (lower.Length > index && !isEven) return lower[index];
            else return avg(lower[index], lower[index + 1]);
                //(lower.Length > index && isEven)
        }
   

        if (nums1.Length == 0 && nums2.Length == 0) return 0;
        if (nums1.Length == 0) return median(nums2);
        if (nums2.Length == 0) return median(nums1);
        if (nums1.Length == 1 && nums2.Length == 1) return avg(nums1[0], nums2[0]);

        if (nums1[0] > nums2[nums2.Length - 1]) return sortedArrays(nums2, nums1);
        if (nums2[0] > nums1[nums1.Length - 1]) return sortedArrays(nums1, nums2);

        if (nums1.Length < nums2.Length) (nums1, nums2) = (nums2, nums1);

        var arrays = new int[][] { nums1, nums2 };

        int i = nums1.Length / 2;
        byte srcArr = 0;
        byte searchArr = 1;
        int sumLength = nums1.Length + nums2.Length;
        (int toFind, bool isEven) = sumLength % 2 == 0 ? ((sumLength - 1) / 2, true) : ((sumLength - 1) / 2, false);

        while (true)
        {
            var ind = Array.BinarySearch(arrays[searchArr], arrays[srcArr][i]);
            if (ind < 0) ind = ~ind;
            int currentPos = i + ind;

            if (currentPos == toFind && !isEven)
            {
                return arrays[srcArr][i];
            }
            if (currentPos == toFind && isEven)
            {
                int next;
                if (i == arrays[srcArr].Length - 1)
                {
                    next = arrays[searchArr][ind];
                }
                else
                {
                    next = Math.Min(arrays[srcArr][i + 1], arrays[searchArr][ind]);
                }
                return avg(arrays[srcArr][i], next);
            }
            if (currentPos == toFind + 1 && isEven)
            {
                var next = Math.Max(arrays[srcArr][i - 1], arrays[searchArr][ind - 1]);
                return avg(arrays[srcArr][i], next);
            }
            if (currentPos < toFind)
            {
                i = (arrays[searchArr].Length - ind) / 2 + ind - 1;
            }
            if (currentPos > toFind)
            {
                i = ind / 2;
            }
            (srcArr, searchArr) = (searchArr, srcArr);
        }
    }
}
