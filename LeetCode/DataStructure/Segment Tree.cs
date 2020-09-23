//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace LeetCode
//{
//    /*
//     *  Write a program to support mininmum range query
//     * createSegmentTree(int arr[]) - create segment tree
//     * query(int segment[], int startRange, int endRange) - returns minimum between startRange and endRange
//     * update(int input[], int segment[], int indexToBeUpdated, int newVal) - updates input and segmentTree with newVal at index indexToBeUpdated;
//     * updateRange(int input[], int segment[], int lowRange, int highRange, int delta) - updates all the values in given range by
//     * adding delta to them
//     * queryLazy(int segment[], int startRange, int endRange) - query based off lazy propagation
//     */
//    class Segment_Tree : BaseClass
//    {
//        public override void Run()
//        {
//            int[] input = { 0, 3, 4, 2, 1, 6, -1 };
//            int[] segTree = createSegmentTree(input);
//            assert 0 == st.rangeMinimumQuery(segTree, 0, 3, input.length);
//        }
//        public int[] createSegmentTree(int input[])
//        {
//            NextPowerOf2 np2 = new NextPowerOf2();
//            int nextPowOfTwo = np2.nextPowerOf2(input.length);
//            int[] segmentTree = new int[nextPowOfTwo * 2 - 1];

//            for (int i = 0; i < segmentTree.Length; i++)
//            {
//                segmentTree[i] = Integer.MAX_VALUE;
//            }
//            constructMinSegmentTree(segmentTree, input, 0, input.length - 1, 0);
//            return segmentTree;
//        }
//        public void updateSegmentTree()
//        {
//        }
//        public void updateSegmentTreeRange(int input[], int segmentTree[], int startRange, int endRange, int delta)
//        {
//            for (int i = startRange; i <= endRange; i++)
//            {
//                input[i] += delta;
//            }
//            updateSegmentTreeRange(segmentTree, startRange, endRange, delta, 0, input.length - 1, 0);
//        }

//        public int rangeMinimumQuery(int[] segmentTree, int qlow, int qhigh, int len)
//        {
//        }
//}
