using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace LeetCode._100LikedQuestion.Medium
{
    public class LRUCache : BaseClass
    {
        public override void Run()
        {
            var cache = new LRUCache(3);
            cache.Put(1, 1);
            cache.Put(2, 2);
            cache.Put(3, 3);
            var value = cache.Get(3);
            value = cache.Get(2);
            cache.Put(4, 3);
            value = cache.Get(2);
            value = cache.Get(3);
            value = cache.Get(4);
            base.Run();
        }

        
       public class Node
        {
           public int key, value;
           public Node next, prev;

          public  Node(int key, int value)
            {
                this.key = key;
                this.value = value;
            }
        }
        Node head, tail;
        Dictionary<int, Node> map;
        int size;

        public LRUCache()
        {

        }

        public LRUCache(int capacity)
        {
            size = capacity;
            head = tail = null;
            map = new Dictionary<int, Node>();
        }

        public int Get(int key)
        {
            if (map.ContainsKey(key))
            {
                Node node = map[key];
                remove(node);
                setHead(node);
                return node.value;
            }
            return -1;
        }

        public void Put(int key, int value)
        {
            if (map.ContainsKey(key))
            {
                Node node = map[key];
                node.value = value;
                remove(node);
                setHead(node);
            }
            else
            {
                if (map.Count == size)
                {
                    map.Remove(tail.key);
                    remove(tail);
                }
                Node node = new Node(key, value);
                map.Add(key, node);
                setHead(node);
            }
        }

        void remove(Node node)
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
        void setHead(Node node)
        {
            node.next = head;
            node.prev = null;
            if (head != null)
            {
                head.prev = node;
            }
            head = node;
            if (tail == null)
            {
                tail = node;
            }
        }
    }
}
