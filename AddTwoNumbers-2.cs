using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public partial class Solution
    {
         public class ListNode {
             public int val;
             public ListNode next;
             public ListNode(int val=0, ListNode next=null) {
                 this.val = val;
                 this.next = next;
    }
}

        //public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        //{
        //    ListNode Sum(ListNode? l1, ListNode? l2, bool plusOne)
        //    {
        //        var newValue = l1?.val ?? 0 + l2?.val ?? 0;
        //        var addOne = false;
        //        if (plusOne) newValue++;
        //        if (newValue > 9)
        //        {
        //            newValue %= 10;
        //            addOne = true;
        //        }
        //        if (l1?.next is null && l2?.next is null)
        //        {
        //            if (addOne)
        //            {
        //                var final = new ListNode(1, null);
        //                return new ListNode(newValue, final);
        //            }
        //            else
        //            {
        //                return new ListNode(newValue, null);
        //            }
        //        }
        //        return new ListNode(newValue, Sum(l1?.next, l2?.next, addOne));
        //    }

        //    return Sum(l1, l2, false);
        //}

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            long ParseToInt(ListNode node)
            {
                long mp = 1;
                long res = 0;
                while (true)
                {
                    res += node.val * mp;
                    mp *= 10;
                    if (node.next == null) return res;
                    node = node.next;
                }
            }
            ListNode IntToNode(long num)
            {
                if (num < 10) return new ListNode((int)num, null);
                return new ListNode(((int)num) % 10, IntToNode(num / 10));
            }

            return IntToNode(ParseToInt(l1) + ParseToInt(l2));
        }
    }
}
