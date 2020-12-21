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
            var m = new int[][]
                {
new int[]{1,3},
new int[]{2,3},
                };
            bm.Intialize(m);
            var output = LeftMostColumnWithOne(bm);

        }



        BinaryMatrix bm;

        public int LeftMostColumnWithOne(BinaryMatrix binaryMatrix)
        {
       
            var dia = binaryMatrix.Dimensions();
            int r = dia[0] - 1;
            int c = dia[1] - 1;
            int lastClouindx = c;
            for (int i = 0; i < r; i++)
            {
                for (int j = lastClouindx; j > 0; j--)
                {
                    if (binaryMatrix.Get(i, j) == 1)
                    {
                        lastClouindx = j;
                    }
                    else
                        break;
                }
            }
            return lastClouindx==c?-1: lastClouindx+1;
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

            if (bm.Get(mid, c) == 1)
                return Helpercell(c, s, mid - 1);
            return Helpercell(c, mid + 1, e);

        }

        public class BinaryMatrix
        {
            int[][] bm;
            int col;
            public BinaryMatrix(int m, int n)
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
