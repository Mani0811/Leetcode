using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Facebook
{
    class LeftmostColumnwithatLeastaOne : BaseClass
    {
        public override void Run()
        {

           
            var bm = new BinaryMatrix(2, 2);
            var m =new int[][]
                {
new int[]{1,3},
new int[]{2,3},
                };
            bm.Intialize(m);
           var output = LeftMostColumnWithOne(bm);
            var output1 = FindJudge(3, m);
        }

        public int FindJudge(int N, int[][] trust)
        {


            Dictionary<int, HashSet<int>> map = new Dictionary<int, HashSet<int>>();
            HashSet<int> pset = new HashSet<int>();
            for (int i = 1; i <= N; i++)
            {
                map.Add(i, new HashSet<int>());
            }

            foreach (var item in trust)
            {
                pset.Add(item[0]);
                map[item[1]].Add(item[0]);
            }
            
            foreach( var item in map)
            {
                if (item.Value.Count == N - 1)
                {
                    if (!pset.Contains(item.Key))
                        return item.Key;
                }
            }
            return -1;
        }

        BinaryMatrix bm;
        int r;
        int c;
        int curr;
        int pre=-1;
        public int LeftMostColumnWithOne(BinaryMatrix binaryMatrix)
        {
            bm = binaryMatrix;
            var dia = binaryMatrix.Dimensions();
            r = dia[0]-1;
            c = dia[1]-1;
            pre = -1;
            return Helperc(0, c);
        }

        int Helperc(int s, int e)
        {

            if (s <= e)
            {
                if (pre >= 0)
                    return pre;
                var mid = s + (e - s) / 2;
                curr = Helpercell(mid, 0, c);
                if (curr >= 0)
                {
                    pre = mid;
                    return Helperc(s, mid - 1);
                }
                return Helperc(mid + 1, e);
            }
            return -1;
        }

        int Helpercell(int c, int s, int e)
        {
            if (s >= e)
            {
                if (bm.Get(s, c) == 1)
                    return s;
                else
                    return -1;
            }

            var mid = s + (e - s) / 2;

            if (bm.Get(mid,c) == 1)
                return Helpercell(c, s, mid - 1);
            return Helpercell(c, mid + 1, e);

        }

        public class BinaryMatrix
        {
            int[][] bm;
            int col;
            public BinaryMatrix(int m,int n)
            {
                bm = new int[m][];
                col = n;
                for (int i = 0; i < n; i++)
                {
                    bm[0] = new int[n];
                }
            }
            public void Intialize(int[][] m)
            {
                bm = m;
            }

            public int Get(int i, int j)
            {
                return bm[i][j];
            }
            public IList<int> Dimensions()
            {
                return new List<int>() { bm.Length, col };
            }

        }
    }
}
