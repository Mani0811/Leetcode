using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.DataStructure
{
    class DoubleLinkist : BaseClass
    {
        public override void Run()
        {
            AddNodeInFront(1);
            AddNodeInFront(2);
            AddNodeInFront(3);

        }
        DoubleLinkistNode head, tail;

        /// <summary>
        /// Adding a node at the front of the list 
        /// h==null;
        /// h=node;
        /// node-><-node1
        /// </summary>
        /// <param name="data"></param>
        public void AddNodeInFront(int data)
        {
            var node = new DoubleLinkistNode(data);
            node.next = head;
            node.prev = null;
            if (head != null)
                head.prev = node;
            head = node;
            if (tail == null)
            {
                tail = node;
            }

        }


        public void AddNodeInLast(int data)
        {
            var node = new DoubleLinkistNode(data);
            node.next = null;
            node.prev = tail;
            if (tail != null)
                tail.next = node;
            tail = node;
            if (head == null)
            {
                head = node;
            }

        }

        public void RemoveNode(DoubleLinkistNode node)
        {
            if (node.prev != null)
            {
                node.prev.next = node.next;
            }
            else
            {
                head = node.next;
            }
            if (node.next != null)
            {
                node.next.prev = node.prev;
            }
            else
            {
                tail = node.prev;
            }
        }


        public class DoubleLinkistNode
        {
            int data;
           public DoubleLinkistNode prev;
            public DoubleLinkistNode next;

            // Constructor to create a new node 
            // next and prev is by default initialized as null 
            public DoubleLinkistNode(int d)
            { data = d; }

            // Adding a node at the front of the list 
            
        }
    }
}
