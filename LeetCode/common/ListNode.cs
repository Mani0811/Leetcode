using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.common
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x)
        {
            val = x;
            next = null;
        }

        public static ListNode InsertEnd(ListNode head, int data)
        {
            // If linked list is empty, create a  
            // new node (Assuming newNode() allocates  
            // a new node with given data)  
            if (head == null)
                return new ListNode(data);  

            // If we have not reached end, keep traversing  
            // recursively.  
            else
                head.next = InsertEnd(head.next, data);
            return head;
        }   
    }
}
