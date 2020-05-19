using LeetCode.common;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._100LikedQuestion.Medium
{
    class RemoveNthNodeFromEndofListSolu : BaseClass
    {
        public override void Run()
        {

            var l1 = new ListNode(1);
            var result = RemoveNthFromEnd(l1, 1);
            base.Run();
        }

        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            ListNode dummy = new ListNode(0);
            dummy.next = head;
            ListNode curr = dummy; ListNode next = dummy;
            if (curr == null) return null;
            for (int i = 1; i <= n+1; i++)
            {
                if (next != null)
                {
                    next = next.next;
                }
            }
            while (next != null)
            {
                curr = curr.next;
                next = next.next;
            }
            curr.next = curr.next.next;
            return dummy.next;
        }
    }
}
