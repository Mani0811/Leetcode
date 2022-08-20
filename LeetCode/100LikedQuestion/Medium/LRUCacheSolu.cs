using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace LeetCode._100LikedQuestion.Medium
{
    public class LRUCache : BaseClass
    {
        /// <summary>
        /// double linked list is that the node can remove itself without other reference. 
        /// it takes constant time to add and remove nodes from the head or tail.
        /// </summary>

        static Object LOCK;
        public override void Run()
        {
            LOCK = new object();
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

        
       public class DoubleLinkList
        {
           public int key, value;
           public DoubleLinkList next, prev;
            public DoubleLinkList()
            {
                
            }
            public  DoubleLinkList(int key, int value)
            {
                this.key = key;
                this.value = value;
            }
        }
        DoubleLinkList head, tail;
        ConcurrentDictionary<int, DoubleLinkList> map;
        int size;

        public LRUCache()
        {

        }

        public LRUCache(int capacity)
        {
            size = capacity;
            head = tail = new DoubleLinkList();
            map = new ConcurrentDictionary<int, DoubleLinkList>();
        }

        public int Get(int key)
        {
                if (map.ContainsKey(key))
                {
                    DoubleLinkList node = map[key];
                    removeNode(node);
                    AddNodeInFront(node);
                    return node.value;
                }
            return -1;
        }

        public void Put(int key, int value)
        {
                if (map.ContainsKey(key))
                {
                    DoubleLinkList node = map[key];
                    node.value = value;
                    removeNode(node);
                    AddNodeInFront(node);
                }
                else
                {
                    if (map.Count == size)
                    {
                        //map.Remove(tail.key);
                        removeNode(tail);
                    }
                    DoubleLinkList node = new DoubleLinkList(key, value);
                    //map.AddOrUpdate(key, node);
                    AddNodeInFront(node);
                }
        }

        void removeNode(DoubleLinkList node)
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
        void AddNodeInFront(DoubleLinkList node)
        {
            lock (node)
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
}
