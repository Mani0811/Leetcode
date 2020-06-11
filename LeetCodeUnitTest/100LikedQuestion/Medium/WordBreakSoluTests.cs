using Xunit;
using LeetCode._100LikedQuestion.Medium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace LeetCode._100LikedQuestion.Medium.Tests
{
    public class WordBreakSoluTests
    {
        WordBreakSolu _wordBreakSolu;
        public WordBreakSoluTests()
        {
            _wordBreakSolu = new WordBreakSolu();
        }
       

        [Theory]
        [ClassData(typeof(CalculatorTestData))]
        public void RunTest(string s, List<string> wordDict, bool result)
        {
           var resu = _wordBreakSolu.WordBreak(s,wordDict);
            Assert.Equal(resu, result);
        }
    }

    public class CalculatorTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            
            yield return new object[] { "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaab", new List<string> { "a", "aa", "aaa", "aaaa", "aaaaa", "aaaaaa", "aaaaaaa", "aaaaaaaa", "aaaaaaaaa", "aaaaaaaaaa" }, false };
            yield return new object[] { "applepenapple", new List<string> { "apple", "pen" }, true };
            yield return new object[] { "aaaaaaa", new List<string> { "aaaa", "aaa" }, true };
            yield return new object[] { "leetcode", new List<string> { "leet", "code" }, true };
            yield return new object[] { "catsandog", new List<string> { "cats", "dog", "sand", "and", "cat" }, false };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }
}