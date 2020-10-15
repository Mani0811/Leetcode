using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Easy
{
    class AlienDictionary : BaseClass
    {
        public override void Run()
        {
            var output = IsAlienSorted(new string[] { "fxasxpc", "dfbdrifhp"}, "zkgwaverfimqxbnctdplsjyohu");
        }


      
        public bool IsAlienSorted(string[] words, string order)
        {
            
            var map = new Dictionary<char, int>();
            for (int i = 0; i < order.Length; i++)
            {
                map.Add(order[i], i);
            }
            if (words.Length == 1) return true;
            for (int j = 0; j < words.Length - 1; j++)
            {
                var fw = words[j];
                var sw = words[j + 1];
                int k = 0;
                while (k < fw.Length && k < sw.Length)
                {
                    if (map[fw[k]] < map[sw[k]])
                    {
                        k++;
                        continue;
                    }
                    else if (map[fw[k]] == map[sw[k]])
                    {
                        k++;
                        continue;
                    }
                    else
                        return false;
                }
                if (sw.Length < fw.Length) return false;
            }
            return true;
        }
    }
}
