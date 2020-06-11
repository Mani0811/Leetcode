using Xunit;
using LeetCode._100LikedQuestion.Medium;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.Design.Serialization;

namespace LeetCode._100LikedQuestion.Medium.Tests
{
    public class ValidateBinarySearchTreeSoluTests
    {
        private ValidateBinarySearchTreeSolu validateBinarySearchTreeSolu;
        private TreeNode root;
        public ValidateBinarySearchTreeSoluTests()
        {
            validateBinarySearchTreeSolu = new ValidateBinarySearchTreeSolu();
            PrepareData();
         }

        private void PrepareData()
        {
            root = new TreeNode(-2147483648);
            root.left = new TreeNode(-2147483648);
        }
        [Fact()]
        public void RunTest()
        {
            var result = validateBinarySearchTreeSolu.IsValidBST(root);
            Assert.True(result);
        }
    }
}