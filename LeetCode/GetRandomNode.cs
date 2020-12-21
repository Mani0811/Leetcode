using LeetCode.common;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    class GetRandomNode :BaseClass
    {
        List<int> list;
        public override void Run()
        {
            base.Run();
            var head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(2);
            Solution(head);

        }

        int n;
        ListNode Head;
        Random r = new Random();
        
        public void Solution(ListNode head)
        {
            Head = head;
            while (head.next != null)
            {
                list.Add(head.val);
            }
        }


        /** Returns a random node's value. */
        public int GetRandom()
        {
           
            var next = r.Next(1,n);
            var curr = 0;
            var node = Head;
            while (node.next != null || curr != next)
            {
                curr++;
                node = node.next;
            }
            return node.val;

        }
    }
}
