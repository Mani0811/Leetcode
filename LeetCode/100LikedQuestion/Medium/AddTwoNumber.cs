using LeetCode.common;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._100LikedQuestion.Medium
{
    public class AddTwoNumber : BaseClass
    {
        public override void Run()
        {
            var l1 = new ListNode(2);
            ListNode.InsertEnd(l1, 4);
            ListNode.InsertEnd(l1, 3);

            var l2 = new ListNode(8);
            ListNode.InsertEnd(l2, 6);
            ListNode.InsertEnd(l2, 8);

            var res = AddTwoNumbers(l1, l2);
            this.Dispalay(res);
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
                    for (int i = 0; i < Math.Abs(diff); i++)
                    {
                        curl1 = curl1.next;
                    }
                else
                    for (int i = 0; i < Math.Abs(diff); i++)
                    {
                        curl2 = curl2.next;
                    }
            }
            AddTwoNumbersUtil(curl1, curl2);



            if (diff != 0)
            {
                if (diff < 0)
                    AddExtraNode(l1, curl1);
                else
                    AddExtraNode(l2, curl2);

            }
            AddREminderNode();
            return result;
        }
        private void AddExtraNode(ListNode l1, ListNode curr)
        {
            if (l1 == curr) return;
            var addtionResult = l1.val + reminder;
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
            if (l1 == null && l2 == null) return;
            AddTwoNumbersUtil(l1.next, l2.next);
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
        }
    }
}


