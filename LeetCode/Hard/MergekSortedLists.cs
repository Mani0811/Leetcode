using LeetCode.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace LeetCode
{
    class MergekSortedLists : BaseClass
    {
        public override void Run()
        {
            int[,] arr = {{2, 6, 12, 34},
                      {1, 9, 20, 1000},
                      {23, 34, 90, 2000}};

            MinHeap.MergeKSortedArrays(arr, arr.GetLength(0));
           // var output = MergeKLists(new List<int>[] { new List<int> { 1, 4, 5 }, new List<int> { 1, 3, 4 }, new List<int> { 2, 6 } });


        }


        public ListNode MergeKLists(ListNode[] lists)
        {
            if (lists == null || lists.Length == 0)
            {
                return null;
            }

            return MergeKLists_s(lists, 0, lists.Length - 1);
        }
        private ListNode MergeKLists_s(ListNode[] lists, int start, int end)
        {
            if (start == end)
            {
                return lists[start];
            }

            if (start >= end)
            {
                return lists[start];
            }

            int mid = (start + end) / 2;
            ListNode left = MergeKLists_s(lists, start, mid);
            ListNode right = MergeKLists_s(lists, mid + 1, end);

            return merge(left, right);
        }

        private ListNode merge(ListNode l1, ListNode l2)
        {
            if (l1 == null) return l2;
            if (l2 == null) return l1;
            if (l1.val < l2.val)
            {
                l1.next = merge(l1.next, l2);
                return l1;
            }
            l2.next = merge(l1, l2.next);
            return l2;
        }


        // using min heap 

        public class MinHeapNode
        {
            public int element; // The element to be stored 

            // index of the array from  
            // which the element is taken 
            public int i;

            // index of the next element  
            // to be picked from array 
            public int j;

            public MinHeapNode(int element, int i, int j)
            {
                this.element = element;
                this.i = i;
                this.j = j;
            }
        };

        public class MinHeap
        {
            MinHeapNode[] harr;
            int heap_size;
            public MinHeap(MinHeapNode[] a, int size)
            {
                heap_size = size;
                harr = a;
                int i = (heap_size - 1) / 2;
                while (i >= 0)
                {
                    MinHeapify(i);
                    i--;
                }
            }

            void MinHeapify(int i)
            {
                int l = left(i);
                int r = right(i);
                int smallest = i;
                if (l < heap_size &&
                    harr[l].element < harr[i].element)
                    smallest = l;
                if (r < heap_size &&
                    harr[r].element < harr[smallest].element)
                    smallest = r;
                if (smallest != i)
                {
                    swap(harr, i, smallest);
                    MinHeapify(smallest);
                }
            }
            int left(int i) { return (2 * i + 1); }
            int right(int i) { return (2 * i + 2); }

            public MinHeapNode getMin()
            {
                if (heap_size <= 0)
                {
                    Console.WriteLine("Heap underflow");
                    return null;
                }
                return harr[0];
            }
            public void replaceMin(MinHeapNode root)
            {
                harr[0] = root;
                MinHeapify(0);
            }

            void swap(MinHeapNode[] arr, int i, int j)
            {
                MinHeapNode temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }





           public static void MergeKSortedArrays(int[,] arr, int k)
            {
                MinHeapNode[] hArr = new MinHeapNode[k];
                int resultSize = 0;
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    MinHeapNode node = new MinHeapNode(arr[i, 0], i, 1);
                    hArr[i] = node;
                    resultSize += arr.GetLength(1);
                }

                // Create a min heap with k heap nodes.  
                // Every heap node has first element of an array 
                MinHeap mh = new MinHeap(hArr, k);

                int[] result = new int[resultSize];     // To store output array 

                // Now one by one get the minimum element  
                // from min heap and replace it with  
                // next element of its array 
                for (int i = 0; i < resultSize; i++)
                {

                    // Get the minimum element and 
                    // store it in result 
                    MinHeapNode root = mh.getMin();
                    result[i] = root.element;

                    // Find the next element that will  
                    // replace current root of heap.  
                    // The next element belongs to same 
                    // array as the current root. 
                    if (root.j < arr.GetLength(1))
                        root.element = arr[root.i, root.j++];

                    // If root was the last element of its array 
                    else
                        root.element = int.MaxValue;

                    // Replace root with next element of array  
                    mh.replaceMin(root);
                }


            }

        }

    }
}


