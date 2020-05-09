using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class BaseClass
    {
        public virtual void Run()
        {
            Console.WriteLine();
        }

        public void Dispalay(object obj)
        {
            Console.WriteLine(obj);
        }
    }
}
