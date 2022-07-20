using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public partial class Solution
    {
        public int[] TwoSum(int[] nums, int target)
        {
            var dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (dict.ContainsKey(nums[i])) return new int[2] { i, dict[nums[i]] };
                if (!dict.ContainsKey(target - nums[i])) dict.Add(target - nums[i], i);
            }
            return null;
        }
    }
}
