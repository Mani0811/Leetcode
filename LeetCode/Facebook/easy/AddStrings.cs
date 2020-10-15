using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace LeetCode
{
    class AddStringsSolu : BaseClass
    {
        public override void Run()
        {
             var output = AddStrings("6", "501");
            var output1 = AddBinary("11", "1");
            
           
        }

        
      
        public string AddBinary(string a, string b)
        {
            var n1 = a.Length;
            var n2 = b.Length;
            var diff = Math.Abs(n1 - n2);
            var builder = new StringBuilder();
            for (int i = 0; i < diff; i++)
            {
                builder.Append('0');
            }
            var prefix = builder.ToString();
            if (n1 > n2)
                b =  prefix+b;
            else
                a = prefix + a;
            int reminder = 0;
            var output = string.Empty;
            for (int i = a.Length - 1; i >= 0; i--)
            {
                var d1 = (int)char.GetNumericValue(a[i]);
                var d2 = (int)char.GetNumericValue(b[i]);
                var sum = d1 + d2+reminder;
                reminder = sum / 2;
                var digit = sum % 2;
                output = digit + output;
            }
            if (reminder != 0)
                output = reminder + output;
            return output;
        }


        public string AddStrings(string num1, string num2)
        {
            string leading = string.Empty;
            int n1 = num1.Length;
            int n2 = num2.Length;
            int count = n1 <= n2 ? n1 : n2;
            int i = count;
            int reminder = 0;

            while (i > 0)
            {
                int d1 = (int)char.GetNumericValue(num1[n1 - 1]);
                int d2 = (int)char.GetNumericValue(num2[n2 - 1]);
                var sum = d1 + d2 + reminder;
                reminder = sum / 10;
                int digit = sum % 10;
                leading = digit + leading;
                n2--;
                n1--;
                i--;
            }

            var n3 = n2 == 0 ? n1 : n2;
            if (n2 == 0)
            {
                for (int j = n3 - 1; j >= 0; j--)
                {
                    int d1 = (int)char.GetNumericValue(num1[j]);
                    var sum = d1 + reminder;
                    reminder = sum / 10;
                    int digit = sum % 10;
                    leading = digit + leading;
                }
            }
            else
            {
                for (int j = n3 - 1; j >= 0; j--)
                {
                    int d1 = (int)char.GetNumericValue(num2[j]);
                    var sum = d1 + reminder;
                    reminder = sum / 10;
                    int digit = sum % 10;
                    leading = digit + leading;
                }
            }
            if(reminder!=0)
            return reminder+ leading;
            return leading;
        }
    }
}
