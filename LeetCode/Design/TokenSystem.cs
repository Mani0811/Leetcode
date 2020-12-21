using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace LeetCode.Design
{
    class TokenSystem : BaseClass
    {
        Dictionary<string, Token> tokenList;
        int sc = 0;
        int mc = 0;
        int lc = 0;
        int total;

        public override void Run()
        {
            Intaialize(5, 5, 5);
        }

        private void Intaialize(int s, int m, int l)
        {
            sc = s;
            mc = m;
            lc = l;
            total = sc + mc + lc;
            tokenList = new Dictionary<string, Token>();
        }
        public string GetToken(Bag bag)
        {
            Token t = null;
            bool flag = false;
            Tokenfactory(bag, ref t, ref flag);
            if (t != null)
            {
                tokenList.Add(t.TokenString, t);
                return t.TokenString;
            }
            else
            {
                return "Locker is Full";
            }
        }

        private void Tokenfactory(Bag bag, ref Token t, ref bool flag)
        {
            if (!flag && bag.Size == "S" && sc > 0)
            {
                var l = new SLocker() { Id = total };
                l.Status = true;
                t = new Token() { Locker = l, Bag = bag };
                sc--;
                total--;
                flag = true;
            }
            if (!flag && bag.Size == "M" || bag.Size == "S" && mc > 0)
            {
                var ml = new MLocker() { Id = total };
                ml.Status = true;
                t = new Token() { Locker = ml, Bag = bag };
                mc--;
                total--;
                flag = true;
            }
            if (!flag && bag.Size == "L" || bag.Size == "M" || bag.Size == "S" && mc > 0)
            {
                var ll = new LLocker() { Id = total };
                ll.Status = true;
                t = new Token() { Locker = ll, Bag = bag };
                lc--;
                total--;
                flag = true;
            }
        }

        public Bag GetBag(string token)
        {
            Bag bag = null;
            tokenList.TryGetValue(token, out Token t);
            if (t != null)
            {
                t.Locker.Status = false;
                bag = t.Bag;
                if (t.Locker.Size == "S")
                    sc++;
                else if (t.Locker.Size == "M")
                    mc++;
                else if (t.Locker.Size == "L")
                    lc++;
                total++;
                t.Bag = null;
                OptimizeLocker();
                return t.Bag;
            }
            else
                return bag;
        }

        private void OptimizeLocker()
        {
        }
        public class Locker
        {
            public int Id { get; set; }
            public bool Status { get; set; }

            public string Size { get; set; }

        }
        public class SLocker : Locker
        {
            public SLocker()
            {
                Size = "S";
            }
        }
        public class MLocker : Locker
        {
            public MLocker()
            {
                Size = "M";
            }
        }
        public class LLocker : Locker
        {
            public LLocker()
            {
                Size = "L";
            }
        }
        class Token
        {
            public Locker Locker { get; set; }
            public string TokenString { get; set; }


            public Bag Bag { get; set; }
            public override string ToString()
            {
                TokenString = Locker.Size + ":" + Locker.Id;
                return TokenString;
            }

        }

        public class Bag
        {
            public string Size { get; set; }

        }


    }
}
