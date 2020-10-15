using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class TaskSchedulerSolu : BaseClass
    {
        public override void Run()
        {
            var resu = LeastInterval(new char[] { 'A', 'A', 'A', 'B', 'B', 'B', 'C', 'C', 'C', 'D', 'D', 'E' }, 2);
        }
        public int LeastInterval(char[] tasks, int n)
        {
            var hash = new int[26];
            foreach (char ch in  tasks)
            {
                hash[ch - 'A']++;
            }

            int max_freq = 0;
            for (int i = 0; i < 26; i++)
            {
                max_freq = Math.Max(max_freq, hash[i]);
            }

            int count_max = 0;
            for (int i = 0; i < 26; i++)
            {
                if (max_freq == hash[i])
                    count_max++;
            }

            return Math.Max(tasks.Length, (max_freq - 1) * (n + 1) + count_max);
        }
        //public int LeastInterval(char[] tasks, int n)
        //{
        //    var map = new Dictionary<char, int>();
        //    int result = 0;
        //    for (int i = 0; i < tasks.Length; i++)
        //    {
        //        if (!map.ContainsKey(tasks[i]))
        //            map.Add(tasks[i], 1);
        //        else
        //            map[tasks[i]] += 1;
        //    }
        //     map = map.OrderByDescending(i => i.Value).ToDictionary(v => v.Key, v => v.Value);
        //    while (map.Count > 0)
        //    {
        //        map = map.OrderByDescending(i => i.Value).ToDictionary(v => v.Key, v => v.Value);
        //        int localcount = 0;
        //        foreach (var item in map.ToArray())
        //        {
        //            var frq = item.Value;
        //            result++;
        //            localcount++;

        //            if (frq == 1)
        //            {
        //                map.Remove(item.Key);
        //            }
        //            else
        //            {

        //                map[item.Key] = item.Value - 1;
        //            }
        //            if (localcount == n+1) break;
        //        }
        //        if (map.Count > 0)
        //            result += (n - localcount + 1) >= 0 ? n - localcount + 1 : 0;
        //    }
        //    return result;
        //}
    }
}
