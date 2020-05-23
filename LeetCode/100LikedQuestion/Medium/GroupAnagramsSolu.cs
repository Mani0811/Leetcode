using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode._100LikedQuestion.Medium
{
    class GroupAnagramsSolu : BaseClass
    {
        public override void Run()
        {
            var result = GroupAnagrams(new string[] { "eat", "tea", "tan", "ate", "nat", "bat" });
            base.Run();
        }
       
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            Dictionary<string, IList<string>> map = new Dictionary<string, IList<string>>();
            foreach (string item in strs)
            {
                char[] characters = item.ToArray();
                Array.Sort(characters);
                var key = new string(characters);
                var valueItem = item;
                if (map.ContainsKey(key))
                {
                    map[key].Add(valueItem);
                }
                else
                    map.Add(key, new List<string>() { valueItem });
            }

            return map.Select(s => s.Value).ToList();
        }
    }
}

