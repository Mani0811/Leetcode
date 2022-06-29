using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    class DynamicPolymorphisam: BaseClass
    {
        public override void Run()
        {
            base.Run();

            Base b = new Derived();
            b.Show();

            Derived d = new Derived();
            d.Show();

        }

        public class Base
        {
            public void Show()
            {
                Console.WriteLine("Base Class");
            }
        }

        public class Derived : Base
        {
            public new void Show()
            {
                base.Show();
                Console.WriteLine("Derived Class");
            }
        }
    }
}
