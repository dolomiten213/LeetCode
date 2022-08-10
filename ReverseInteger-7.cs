
namespace LeetCode;

public partial class Solution
{
    public int Reverse(int x)
    {

        //====================================================//
        //try
        //{
        //    if (x > -10 && x < 10) return x;
        //    bool isNegative = x < 0;
        //    x = Math.Abs(x);
        //    Stack<int> stack = new();

        //    while (x > 0)
        //    {
        //        stack.Push(x % 10);
        //        x /= 10;
        //    }

        //    int mp = 1;
        //    int res = 0;

        //    while (stack.TryPop(out var y))
        //    {
        //        if (y == 0 && res == 0) continue;
        //        res = checked(res + mp * y);
        //        mp *= 10;
        //    }

        //    return isNegative ? -res : res;
        //}
        //catch
        //{
        //    return 0;
        //}
        //====================================================//

        int res = 0;
        while (x != 0)
        {
            int mod = x % 10;
            x /= 10;

            if (mod >= 0 && res > (int.MaxValue - mod) / 10) return 0;
            if (mod <= 0 && res < (int.MinValue - mod) / 10) return 0;

            res = res * 10 + mod;
        }
        return res;
    }
}
