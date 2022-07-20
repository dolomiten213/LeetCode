using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public partial class Solution
    {
        public IList<IList<int>> Generate(int numRows)
        {
            IList<int> MakeRow(IList<int> prevRow)
            {
                IList<int> res = new List<int>(prevRow.Count + 1) { 1 };
                for(int i = 0; i < prevRow.Count - 1; i++)
                {
                    res.Add(prevRow[i] + prevRow[i+1]);
                }
                res.Add(1);
                return res;
            }

            if (numRows == 1) return new List<IList<int>> { new List<int> { 1 } };
            //if (numRows == 2) return new List<List<int>> { new List<int> { 1 }, new List<int> { 1, 1 } };
            //if (numRows == 3) return new List<List<int>> { new List<int> { 1 }, new List<int> { 1, 1 }, new List<int> { 1, 2, 1 } };
            var res = Generate(numRows - 1);
            res.Add(MakeRow(res.Last()));
            return (IList<IList<int>>)res;
        }
    }
}
