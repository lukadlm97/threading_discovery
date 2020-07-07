using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace simple_threading_discovery
{
    class CountDownOperations
    {

       public static CountdownEvent _countdown = new CountdownEvent(2);

        public static void PerformOperation(string message,int secound)
        {
            Thread.Sleep(TimeSpan.FromSeconds(secound));
            Console.WriteLine(message);
            _countdown.Signal();
        }
    }
}
