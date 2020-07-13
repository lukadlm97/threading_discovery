using System;
using System.Collections.Generic;
using System.Text;

namespace simple_threading_discovery
{
    public class SomeClass1
    {
       
        public static void PassStringByValue(string s)
        {
            s = "Changed in method";

        }
    }
    class OneMoreClass
    {
        const SomeClass1 someClass = null;
        readonly SomeClass1 someClass1;
    }
     interface SomeInterface
    {
        static int a = 3;

    }
}
