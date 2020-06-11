using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace LeetCode._100LikedQuestion.Medium
{
    public class WordBreakSolu : BaseClass
    {
        public override void Run()
        {
            var s = "leetcode"; var wordDict = new List<string> { "leet", "code" };
            var resut = WordBreak1(s, wordDict);
            base.Run();
        }

        public bool WordBreak(string s, IList<string> wordDict)
        {
            int len = s.Length;
            int[,] T = new int[len, len];
            wordDict = wordDict.OrderBy(q => q).ToList();


            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    T[i,j] = -1; //-1 indicates string between i to j cannot be split
                }
            }
            //fill up the matrix in bottom up manner
            for (int l = 1; l <= len; l++)
            {
                for (int i = 0; i < len - l + 1; i++)
                {
                    int j =  l+i-1;
                    string sub = s.Substring(i, l);
                    //if string between i to j is in dictionary T[i][j] is true
                    if ((wordDict as List<string>).BinarySearch(sub) >= 0)
                    {
                        T[i, j] = i;
                    }
                    
                    //find a k between i+1 to j such that T[i][k-1] && T[k][j] are both true 
                    for (int k = i + 1; k <= j; k++)
                    {
                        if (T[i, k - 1] != -1 && T[k,j] != -1)
                        {
                            T[i, j] = k;
                            break;
                        }
                    }
                }
            }
            if (T[0, len - 1] == -1)
            {
                return false;
            }


            return true;
        }


        //public bool WordBreak(string s, IList<string> wordDict)
        //{
        //    wordDict = wordDict.OrderBy(q => q).ToList();
        //    int len = s.Length;
        //    var matrix = new bool[len, len];
        //    for (int i = 0; i < len; i++)
        //    {
        //        for (int l = 1; l <= len - i; l++)
        //        {
        //            var sub = s.Substring(i, l);
        //            if ((wordDict as List<string>).BinarySearch(sub) >= 0)
        //            {
        //                matrix[i, i + l - 1] = true;
        //            }
        //        }
        //    }
        //    return IsValid(len,matrix);
        //}

        private static bool IsValid(int len, bool[,] matrix)
        {

            if (len == 0) return true;
            for (int j = len - 1; j >= 0; j--)
            {
                if (matrix[j, len - 1])
                {
                    if (IsValid(j, matrix))
                        return true;
                }
            }
            return false;
        }

        public bool WordBreak1(string s, IList<string> wordDict)
        {
            wordDict = wordDict.OrderBy(q => q).ToList();

            if (WordBreakUtil(s, wordDict.ToList())) return true;
            return false;
        }

        public bool WordBreakUtil(string word, List<string> wordDict)

        {
            int size = word.Length;

            // base case 
            if (size == 0)
                return true;

            //else check for all words 
            for (int i = 1; i <= size; i++)
            {
                if ((wordDict.BinarySearch(word.Substring(0, i)) >= 0) &&
                    WordBreakUtil(word.Substring(i), wordDict))
                    return true;
            }

            // if all cases failed then return false 
            return false;

        }
    }
}
