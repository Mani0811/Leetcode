using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LeetCode._100LikedQuestion.Medium
{
    class PhoneNumberSolu : BaseClass
    {
        public override void Run()
        {
         var result =   LetterCombinations("234");



        }
        Dictionary<string, string> phone = new Dictionary<string, string>
       {
           {"2","abc" },
           {"3","def"},
           {"4","ghi"},
           {"5","jkl" },
           {"6","mno"},
           {"7","pqrs"},
           {"8","tuv" },
           {"9","wxyz"},
       };
        List<string> output = new List<string>();
        public IList<string> LetterCombinations(string digits)
        {
            if (digits.Length != 0)
                BackTrack("", digits);
            return output;
        }

        public void BackTrack(string combination, string next_digits)
        {
            
            // if there is no more digits to check
            if (next_digits.Length == 0)
            {
                // the combination is done
                output.Add(combination);
            }
            // if there are still digits to check
            else
            {
                // iterate over all letters which map 
                // the next available digit
                String digit = next_digits.Substring(0, 1);
                String letters = phone[digit];
                for (int i = 0; i < letters.Length; i++)
                {
                    String letter = letters.Substring(i,1);
                    // append the current letter to the combination
                    // and proceed to the next digits
                    BackTrack(combination + letter, next_digits.Substring(1));
                }
            }

           

        }
    }
}
