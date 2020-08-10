using LeetCode.common;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._100LikedQuestion.Medium
{
    class SortListSolu : BaseClass
    {
        public override void Run()
        {
            base.Run();
        }

        public ListNode SortList(ListNode head)
        {
            var loop = head;
            while (loop != null)
            {
                var node = loop;
                var next = node.next;
                while (next != null)
                {
                    if (node.val > next.val)
                        Swap(node, next);
                    next = next.next;
                }
                loop = loop.next;
            }
            return head;
        }

        private void Swap(ListNode node, ListNode next)
        {
            var temp = node.val;
            node.val = next.val;
            next.val = temp;

        }
    }
}
