using System;
using System.Collections.Generic;
using System.Text;

namespace simple_threading_discovery
{
    public class B:A
    {
        static B()
        {
            Console.WriteLine("Static constructor B!!!");
        }

        public B(int a):base(a)
        {
            
        }

        public void M()
        {

        }
    }
}
