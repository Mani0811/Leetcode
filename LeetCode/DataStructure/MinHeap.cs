using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    class MinHeapSolu : BaseClass
    {
        public override void Run()
        {
            base.Run();
            MinHeap h = new MinHeap(11);
            h.insertKey(3);
            h.insertKey(2);
             h.deleteKey(1);
            h.insertKey(15);
            h.insertKey(5);
            h.insertKey(4);
            h.insertKey(45);

            var min = h.ExtractMin();
        }
    }

    class MinHeap
    {

        //k To store array of elements in heap
        public int[] heapArray { get; set; }

        // max size of the heap 
        public int capacity { get; set; }

        // Current number of elements in the heap 
        public int current_heap_size { get; set; }

        // Constructor  
        public MinHeap(int n)
        {
            capacity = n;
            heapArray = new int[capacity];
            current_heap_size = 0;
        }


        // Swapping using reference  
        public static void Swap<T>(ref T lhs,ref T rhs)
        {
            T temp = lhs;
            lhs = rhs;
            rhs = temp;
        }

        public int Parent(int key)
        {
            return (key - 1) / 2;
        }

        // Get the Left Child index for the given index 
        public int Left(int key)
        {
            return 2 * key + 1;
        }

        // Get the Right Child index for the given index 
        public int Right(int key)
        {
            return 2 * key + 2;
        }

        // Inserts a new key 
        public bool insertKey(int key)
        {
            if (current_heap_size == capacity)
            {

                // heap is full 
                return false;
            }

            // First insert the new key at the end  
            int i = current_heap_size;
            heapArray[i] = key;
            current_heap_size++;

            // Fix the min heap property if it is violated  
            while (i != 0 && heapArray[i] <
                             heapArray[Parent(i)])
            {
                Swap(ref heapArray[i],
                      ref heapArray[Parent(i)]);
                i = Parent(i);
            }
            return true;
        }

        // Returns the minimum key (key at 
        // root) from min heap  
        public int GetMin()
        {
            return heapArray[0];
        }

        // Method to remove minimum element  
        // (or root) from min heap  
        public int ExtractMin()
        {
            if (current_heap_size <= 0)
            {
                return int.MaxValue;
            }

            if (current_heap_size == 1)
            {
                current_heap_size--;
                return heapArray[0];
            }

            // Store the minimum value,  
            // and remove it from heap  
            int root = heapArray[0];

            heapArray[0] = heapArray[current_heap_size - 1];
            current_heap_size--;
            MinHeapify(0);

            return root;
        }

        // A recursive method to heapify a subtree  
        // with the root at given index  
        // This method assumes that the subtrees 
        // are already heapified 
        public void MinHeapify(int key)
        {
            int l = Left(key);
            int r = Right(key);

            int smallest = key;
            if (l < current_heap_size &&
                heapArray[l] < heapArray[smallest])
            {
                smallest = l;
            }
            if (r < current_heap_size &&
                heapArray[r] < heapArray[smallest])
            {
                smallest = r;
            }

            if (smallest != key)
            {
                Swap(ref heapArray[key],

                   ref heapArray[smallest]);
                MinHeapify(smallest);
            }
        }

        /// <summary>
        /// generally delete is performed on root.
        /// Replace the root or element to be deleted by the last element.
       /// Delete the last element from the Heap.
       /// Since, the last element is now placed at the position of the root node.So, it may not follow the heap property.
       ///Therefore, heapify the last node placed at the position of root.
        /// </summary>
        /// <param name="key"></param>
        public void deleteKey(int key)
        {
            decreaseKey(key, int.MinValue);
            extractMin();
        }

        public int extractMin()
        {
            if (current_heap_size <= 0)
            {
                return int.MaxValue;
            }

            if (current_heap_size == 1)
            {
                current_heap_size--;
                return heapArray[0];
            }

            // Store the minimum value,  
            // and remove it from heap  
            int root = heapArray[0];

            heapArray[0] = heapArray[current_heap_size - 1];
            current_heap_size--;
            MinHeapify(0);

            return root;
        }
       

        public void decreaseKey(int key, int new_val)
        {
            heapArray[key] = new_val;

            while (key != 0 && heapArray[key] <
                               heapArray[Parent(key)])
            {
                Swap(ref heapArray[key],
                     ref heapArray[Parent(key)]);
                key = Parent(key);
            }
        }
    }
}
