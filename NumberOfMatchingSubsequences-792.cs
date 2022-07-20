using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode;

public partial class Solution
{

    //  Runtime: 2930 ms, faster than 5.45% of C# online submissions for Number of Matching Subsequences.
    //  Memory Usage: 43.8 MB, less than 84.24% of C# online submissions for Number of Matching Subsequences.
    
    //public int NumMatchingSubseq(string s, string[] words)
    //{
    //    static bool IsSubsequence(string source, string search)
    //    {
    //        int j = 0;
    //        for (int i = 0; i < source.Length; i++)
    //        {
    //            if (source[i] == search[j])
    //            {
    //                if (++j >= search.Length)
    //                {
    //                    return true;
    //                }
    //            }
    //        }
    //        return false;
    //    }

    //    int res = 0;
    //    foreach (var word in words)
    //    {
    //        if (IsSubsequence(s, word)) res++;
    //    }
    //    return res;
    //}


    //  Runtime: 1206 ms, faster than 17.57% of C# online submissions for Number of Matching Subsequences.
    //  Memory Usage: 51.7 MB, less than 12.73% of C# online submissions for Number of Matching Subsequences.
    
    //public int NumMatchingSubseq(string s, string[] words)
    //{
    //    Dictionary<char, SortedSet<int>> letters = new();
    //    bool IsSubsequence(string search)
    //    {
    //        int prev = -1;

    //        for(int i = 0; i < search.Length; i++)
    //        {
    //            if (!letters.ContainsKey(search[i]) || prev + 1 > letters[search[i]].Max) return false;
    //            prev = letters[search[i]].GetViewBetween(prev + 1, letters[search[i]].Max).Min;
    //        }
    //        return true;
    //    }


    //    for (int i = 0; i < s.Length; i++)
    //    {
    //        if (!letters.ContainsKey(s[i]))
    //        {
    //            letters.Add(s[i], new SortedSet<int>());
    //        }
    //        letters[s[i]].Add(i);
    //    }

    //    int res = 0;
    //    foreach (var word in words)
    //    {
    //        if (IsSubsequence(word)) res++;
    //    }
    //    return res;
    //}

    //  Runtime: 273 ms, faster than 50.91% of C# online submissions for Number of Matching Subsequences.
    //  Memory Usage: 45.5 MB, less than 49.70% of C# online submissions for Number of Matching Subsequences.
    public int NumMatchingSubseq(string s, string[] words)
    {
        bool IsSubSequence(string big, string small)
        {
            int j = 0;
            for (int i = 0; i < big.Length; i++)
            {
                if (big[i] == small[j])
                {
                    if (++j >= small.Length)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        var wordsDedup = words.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());

        int res = 0;
        foreach (var word in wordsDedup.Keys)
        {
            if (IsSubSequence(s, word)) res += wordsDedup[word];
        }
        return res;
    }
}
