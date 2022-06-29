using LeetCode._100LikedQuestion;
using LeetCode._100LikedQuestion.Medium;
using LeetCode.Assesment;
using LeetCode.common;
using LeetCode.DataStructure;
using LeetCode.DesignConcept;
using LeetCode.DsQuestion;
using LeetCode.Easy;
using LeetCode.Facebook;
using LeetCode.Google;
using LeetCode.Hard;
using LeetCode.Interview;
using LeetCode.Interview.NationalInstrument;
using LeetCode.interviewbit;
using LeetCode.Medium;
using LeetCode.VMware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class TestStatic
    {
        public static int TestValue;

        public TestStatic()
        {
            if (TestValue == 0)
            {
                TestValue = 5;
            }
        }
        static TestStatic()
        {
            if (TestValue == 0)
            {
                TestValue = 10;
            }

        }

        public void Print()
        {
            if (TestValue == 5)
            {
                TestValue = 6;
            }
            Console.WriteLine("TestValue : " + TestValue);

        }
    }
    
    class Program
    {
       

        //private static string result;
        public static void Main()
         {
            var addTn = new LongestIncreasingSubsequence();
                       addTn.Run();
            TestStatic t = new TestStatic();
            t.Print();
            EasyQuestionDriver();
        }
        //static async Task<string> SaySomething()
        //{
        //    await Task.Delay(5);
        //    result = "Hello world!";
        //    return "Something";
        //}
        static void EasyQuestionDriver()
        {
            var solu = new Solution();
            var headP = new ListNode(1);
            headP.next = new ListNode(2);
            //headP.next.next = new ListNode(2);
            //headP.next.next.next = new ListNode(1);
            var revnum = solu.Reverse(-2147483648);
            var revnum1 = solu.Reverse(-5);

            var head = new ListNode(1)
            {
                next = new ListNode(2)
                {
                    next = new ListNode(3)
                }
            };
            solu.ReverseList(head);
            solu.MajorityElement(new int[] { 5, 6, 6 });

            var headA = new ListNode(4);
            headA.next = new ListNode(1);
            var node8 = new ListNode(8);
            headA.next.next = node8;

            var headB = new ListNode(5);
            headB.next = new ListNode(0);
            headB.next.next = new ListNode(1);
            headB.next.next.next = node8;
            var solul = new Solution();
            var result = solul.GetIntersectionNode(headA, headB);
            var minStack = new MinStack();
            minStack.Push(-2);
            minStack.Push(0);
            minStack.Push(-3);
            minStack.GetMin(); // return -3
            minStack.Pop();
            minStack.Top();    // return 0
            minStack.GetMin(); // return -2

            var root = solu.CreateTreeInput();
            var profit = solu.MaxProfit(new int[] { 2, 4, 1 });
            var depth = solu.MaxDepth(root);
            var isSymmetric = solu.IsSymmetric(root);
        }
    }
    public class MinStack
    {

        Stack<int> stack;
        Stack<int> minStack;
        /** initialize your data structure here. */
        public MinStack()
        {
            stack = new Stack<int>();
            minStack = new Stack<int>();
        }

        public void Push(int x)
        {
            stack.Push(x);
            ModifyMinStack(x);
        }

        public void Pop()
        {
            var actual = stack.Pop();
            var topMin = minStack.Peek();
            if (actual < topMin)
                minStack.Pop();
        }

        public int Top()
        {
            return stack.Peek();
        }

        public int GetMin()
        {
            return minStack.Peek();
        }

        private void ModifyMinStack(int x)
        {
            if (minStack.Count == 0)
            {
                minStack.Push(x);
                return;
            }
            var top = minStack.Peek();
            if (x < top)
            {
                minStack.Push(x);
            }

        }
    }
    public class Solution
    {

        public int Reverse(int x)
        {
            int num = x;
            bool negativeFlag = false;
            if (num < 0)
            {
                negativeFlag = true;
                num = -num;
            }

            int prev_rev_num = 0, rev_num = 0;
            while (num != 0)
            {
                int curr_digit = num % 10;

                rev_num = (rev_num * 10) +
                           curr_digit;

                // checking if the reverse overflowed  
                // or not. The values of (rev_num -  
                // curr_digit)/10 and prev_rev_num must  
                // be same if there was no problem.  
                if ((rev_num - curr_digit) / 10 != prev_rev_num)
                {
                    Console.WriteLine("WARNING OVERFLOWED!!!");
                    return 0;
                }

                prev_rev_num = rev_num;
                num = num / 10;
            }

            var z = (negativeFlag == true) ?
                                 -rev_num : rev_num;
            return z;
        }
        public void MoveZeroes(int[] nums)
        {
            int pos = -1;
            for (int i = 0; i < nums.Length; i++)
            {
                if (pos == -1 && nums[i] != 0) continue;
                if (nums[i] == 0 && pos == -1)
                {
                    pos = i;
                    continue;
                }
                else if (nums[i] != 0)
                {
                    nums[pos] = nums[i];
                    nums[i] = 0;
                    pos = pos + 1;
                }
            }

        }
        public bool IsPalindrome(ListNode head)
        {
            var curr = head;
            if (head == null) return true;
            var fast = head.next;
            if (head.next == null) return true;
            Stack<ListNode> stck = new Stack<ListNode>();

            while (fast != null && fast.next != null)
            {
                curr = curr.next;
                fast = fast.next.next;
            }
            var mid = curr;
            fast = curr.next;
            curr = head;
            while (fast != null)
            {
                stck.Push(fast);
                fast = fast.next;
            }

            while (stck.Count != 0)
            {
                var node = stck.Pop();
                if (curr.val != node.val) return false;
                curr = curr.next;
            }
            return true;
        }
        // Tod: Correct the method
        // public bool IsPalindrome(ListNode head)
        //{
        //    var curr = head;
        //    if (head == null) return true;
        //    var fast = head.next;
        //    if (head.next == null) return true;
        //    Stack<ListNode> stck = new Stack<ListNode>();
        //    IsPalindrome(curr, fast);


        //    var mid = curr;
        //    fast = curr.next;
        //    curr = head;
        //    while (fast != null)
        //    {
        //        stck.Push(fast);
        //        fast = fast.next;
        //    }

        //    while (stck.Count != 0)
        //    {
        //        var node = stck.Pop();
        //        if (curr.val != node.val) return false;
        //        curr = curr.next;
        //    }
        //    return true;
        //}
        public void IsPalindrome(ListNode curr, ListNode fast)
        {
            if (fast == null || fast.next == null) return;
            IsPalindrome(curr.next, curr.next.next);

        }
        public ListNode ReverseList(ListNode head)
        {
            ListNode p = null, n = null;
            ListNode c = head;
            while (c != null)
            {
                n = c.next;
                c.next = p;
                p = c;
                c = n;
            }
            return c;
        }
        public int MajorityElement(int[] nums)
        {
            var len = nums.Length;
            var group = nums.GroupBy(a => a);
            foreach (var item in group)
            {
                if (item.Count() >= Math.Ceiling((decimal)len / 2))
                    return item.Key;
            }
            return 0;

        }

        public ListNode GetIntersectionNode1(ListNode headA, ListNode headB)
        {
            ListNode pa = headA, pb = headB;
            while (pa != pb)
            {
                pa = (pa != null) ? pa.next : headB;
                pb = (pb != null) ? pb.next : headA;
            }
            return pa;
        }

        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {

            HashSet<ListNode> map = new HashSet<ListNode>();
            while (headA != null && headB != null)
            {
                map.Add(headA);
                headA = headA.next;
                if (map.Contains(headB)) return headB;
                map.Add(headB);
                headB = headB.next;
            }
            return null;
        }
        public bool HasCycle(ListNode head)
        {
            ListNode slow = head;
            ListNode fast = head;
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if (slow == fast)
                {
                    return true;
                }
            }
            return false;
        }
        public int MaxProfit(int[] prices)
        {
            int count = prices.Length;
            if (count < 2) return 0;
            int bP = prices[0];
            int sP = prices[1];
            int maxProfit = 0;
            int profit = 0;
            for (int i = 1; i < count; i++)
            {
                var curr = prices[i];
                if (bP > curr)
                {
                    bP = curr;
                    sP = curr;
                }
                else
                {
                    if (curr > sP)
                        sP = curr;
                }
                profit = sP - bP;
                maxProfit = Math.Max(profit, maxProfit);
            }
            return maxProfit;
        }

        public int MaxDepth(TreeNode root)
        {

            if (root == null)
                return 0;
            else
            {
                /* compute the depth of each subtree */
                int lDepth = MaxDepth(root.left);
                int rDepth = MaxDepth(root.right);

                return Math.Max(lDepth, rDepth) + 1;
            }

        }
        public int MaxDepth(TreeNode root, int depth)
        {
            if (root == null) return depth;
            return Math.Max(MaxDepth(root.left, depth + 1), MaxDepth(root.right, depth + 1));

        }

        //public int MaxDepth(TreeNode root)
        //{
        //    int depth = 0;
        //    if (root == null) return depth;
        //    var queue = new Queue<TreeNode>();
        //    var dummy = new TreeNode(int.MinValue);
        //    queue.Enqueue(root);
        //    queue.Enqueue(dummy);
        //    while (queue.Count >= 1)
        //    {
        //        var temp = queue.Dequeue();
        //        if (temp == dummy)
        //        {
        //            if (queue.Count>0 && queue.Peek()!=dummy)
        //                queue.Enqueue(dummy);
        //            depth += 1;
        //            continue;
        //        }

        //        if (temp.left != null)
        //            queue.Enqueue(temp.left);
        //        if (temp.right != null)
        //            queue.Enqueue(temp.right);
        //    }
        //    return depth;
        //}


        //public bool IsSymmetric(TreeNode root)
        //{
        //    if (root == null) return true;
        //    var queue = new Queue<TreeNode>();
        //    queue.Enqueue(root.left);
        //    queue.Enqueue(root.right);
        //    while (queue.Count > 0)
        //    {
        //        var tempLeft = queue.Dequeue();
        //        var tempRight = queue.Dequeue();

        //        if (tempLeft == null && tempRight == null)
        //            continue;

        //        /* if only one is null---inequality, retun false */
        //        if ((tempLeft == null && tempRight != null) ||
        //            (tempLeft != null && tempRight == null))
        //            return false;

        //        /* if both left and right nodes exist, but 
        //        have different values-- inequality, 
        //        return false*/
        //        if (tempLeft.val != tempRight.val)
        //            return false;


        //        if (tempLeft?.val != tempRight?.val) return false;
        //        queue.Enqueue(tempLeft.left);
        //        queue.Enqueue(tempRight.right);
        //        queue.Enqueue(tempLeft.right);
        //        queue.Enqueue(tempRight.left);
        //    }
        //    return true;
        //}


        public bool IsSymmetric(TreeNode root)
        {
            if (root == null) return true;
            return isMirror(root.left, root.right);


        }
        public bool isMirror(TreeNode left, TreeNode right)
        {
            if (right == null && left == null) return true;
            if (right != null && left != null && left.val == right.val)
                return (isMirror(left.left, right.right) && isMirror(left.right, right.left));
            return false;
        }

        public TreeNode CreateTreeInput()
        {
            var root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.left.left = new TreeNode(3);
            root.left.right = new TreeNode(4);
            root.right = new TreeNode(2);
            root.right.left = new TreeNode(4);
            root.right.right = new TreeNode(3);
            return root;
        }
    }

    // Definition for a binary tree node.
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

}


