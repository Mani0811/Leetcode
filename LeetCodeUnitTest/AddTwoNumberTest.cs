using FluentAssertions;
using FluentAssertions.Common;
using LeetCode._100LikedQuestion.Medium;
using LeetCode.common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Xunit;

namespace LeetCodeUnitTest
{
    public class AddTwoNumberTest
    {
        private readonly AddTwoNumber _addTwoNumber;
        public ListNode l1, l2, expectedResult;

        public AddTwoNumberTest()
        {
            _addTwoNumber = new AddTwoNumber();
            PrepareData();

        }

        private void PrepareData()
        {
            l1 = new ListNode(2);
            ListNode.InsertEnd(l1, 4);
            ListNode.InsertEnd(l1, 3);

            l2 = new ListNode(8);
            ListNode.InsertEnd(l2, 6);
            ListNode.InsertEnd(l2, 8);

            expectedResult = new ListNode(1);
            ListNode.InsertEnd(expectedResult, 1);
            ListNode.InsertEnd(expectedResult, 1);
            ListNode.InsertEnd(expectedResult, 1);
        }

        [Fact]
        public void MyFact()
        {
            var result = _addTwoNumber.AddTwoNumbers(l1, l2);
            Assert.NotNull(result);
            Assert.Equal(expectedResult, result, new LinkedListCompare());
        }


    }
}
