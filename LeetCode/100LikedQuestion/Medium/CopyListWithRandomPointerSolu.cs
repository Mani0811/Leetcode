using LeetCode.common;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._100LikedQuestion.Medium
{
    class CopyListWithRandomPointerSolu : BaseClass
    {
        public override void Run()
        {

            base.Run();
        }

        public Node CopyRandomList(Node head)
        {
            Node headref = head;
            Node headCopy = null;
            Node current = null;
            Dictionary<Node, Node> randomDic = new Dictionary<Node, Node>();
            if (head == null) return null;
            headCopy = new Node(head.val);
            randomDic.Add(head, headCopy);
            current = headCopy;
            head = head.next;
            while (head != null)
            {
                var node = new Node(head.val);
                randomDic.Add(head, node);
                current.next = node;
                current = current.next;
                head = head.next;
            }
            current = headCopy;
            head = headref;
            while (current!=null)
            {
                if(head.random==null)
                current.random = null;
                else
                    current.random = randomDic[head.random];
                current = current.next;
                head = head.next;
            }
            return headCopy;
        }
    }
}
