using LeetCode.common;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._100LikedQuestion.Medium
{
    class AddTwoNumbersStoredInReverseOrder: BaseClass
    {
        public override void Run()
        {
            var l1 = new ListNode(1);
            ListNode.InsertEnd(l1, 8);

            var l2 = new ListNode(0);


            var res = AddTwoNumbers(l1, l2);
        }
        private int reminder = 0; ListNode result = null; ListNode curr = null;
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {

            var len1 = GetSize(l1);
            var len2 = GetSize(l2);
            var curl1 = l1;
            var curl2 = l2;
            var diff = len1 - len2;
            if (diff != 0)
            {
                if (diff < 0)
                    AddZeroNode(l1, Math.Abs(diff));
                else
                    AddZeroNode(l2, Math.Abs(diff));
            }
            AddTwoNumbersUtil(curl1, curl2);
            AddREminderNode();
            return result;
        }
        private void AddZeroNode(ListNode l1, int length)
        {
            var curr = l1;
            while (curr.next != null)
            {
                curr = curr.next;
            }
            for (int i = 0; i < length; i++)
            {
                curr.next = new ListNode(0);
                curr = curr.next;
            }
        }

        private void AddREminderNode()
        {
            if (reminder != 0)
            {
                var node = new ListNode(reminder);
                curr.next = node;
                curr = curr.next;
            }
        }

        int GetSize(ListNode head)
        {
            int len = 0;
            while (head != null)
            {
                len++;
                head = head.next;
            }
            return len;
        }

        void AddTwoNumbersUtil(ListNode l1, ListNode l2)
        {
            while (l1 != null)
            {
                var addtionResult = l1.val + l2.val + reminder;
                var value = addtionResult % 10;
                reminder = addtionResult / 10;
                var node = new ListNode(value);

                if (result == null)
                {
                    result = node;
                    curr = node;
                }
                else
                {
                    curr.next = node;
                    curr = curr.next;
                }
                l1 = l1.next;
                l2 = l2.next;
            }
        }
    }
}
