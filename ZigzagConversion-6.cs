
using System.Text;

namespace LeetCode;

public partial class Solution
{
    public string Convert(string s, int numRows)
    {
        if (numRows == 1) return s;
        StringBuilder res = new(s.Length);
        res.Length = s.Length;
        int[] startPointers = new int[numRows];
        startPointers[0] = 0;
        (int div, int mod) = (s.Length / (2 * numRows - 2), s.Length % (2 * numRows - 2));
        startPointers[1] = div + (mod > 0 ? 1 : 0);
        for (int i = 1; i < numRows - 1; i++)
        {   
            int count;
            (int div1, int mod1) = (mod / numRows, mod % numRows);
            count = 2 * div;
            if (div1 == 1)
            {
                count++;
                if (i >= numRows - mod1 - 1) count++;
            }
            else
            {
                if (i <= mod1 - 1) count++;
            }
            startPointers[i + 1] = startPointers[i] + count;
        }


        for (int i = 0; i < s.Length; i++)
        {
            (div, mod) = (i / (numRows - 1), i % (numRows - 1));
            if (div % 2 == 0)
            {
                res[startPointers[mod]++] = s[i];
            }
            else
            {
                res[startPointers[numRows - 1 - mod]++] = s[i];
            }
        }
        return res.ToString();
    }
}
