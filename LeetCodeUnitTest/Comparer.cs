using LeetCode.common;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace LeetCodeUnitTest
{

    public class LinkedListCompare : IEqualityComparer<ListNode>
    {
        public bool Equals([AllowNull] ListNode x, [AllowNull] ListNode y)
        {
            if (x == null && y == null)
                return true;
            else if (x == null || y == null)
                return false;
            else
                while (x != null && y != null)
                {
                    if (x?.val != y?.val) return false;
                    x = x.next;
                    y = y.next;
                }
            return true;

        }

        public int GetHashCode([DisallowNull] ListNode obj)
        {
            throw new NotImplementedException();
        }
    }
}

