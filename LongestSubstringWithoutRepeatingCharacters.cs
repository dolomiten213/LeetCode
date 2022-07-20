
namespace LeetCode;

public partial class Solution
{
    //Runtime: 167 ms, faster than 25.49% of C# online submissions for Longest Substring Without Repeating Characters.
    //Memory Usage: 36.3 MB, less than 99.74% of C# online submissions for Longest Substring Without Repeating Characters.
    public int LengthOfLongestSubstring(string s)
    {
        if (string.IsNullOrEmpty(s)) return 0;
        if (s.Length == 1) return 1;

        Dictionary<char, int> letters = new();
        int i = 0;
        int res = 0;
        while (i < s.Length)
        {
            if (!letters.ContainsKey(s[i]))
            {
                letters[s[i]] = i++;
            }
            else
            {
                if (res == 0) res = i;
                if (letters.Count > res) res = letters.Count;
                i = letters[s[i]] + 1;
                letters.Clear();
            }
        }
        return Math.Max(res, letters.Count);
    }
}
