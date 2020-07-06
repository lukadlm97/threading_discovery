using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace simple_threading_discovery
{
    class GatesSimulation
    {
       public static ManualResetEventSlim _mainEvent = new ManualResetEventSlim(false);
    
        public static void TravelThroughGates(string threadName,int secounds)
        {
            Console.WriteLine("{0} falls to sleep",threadName);
            Thread.Sleep(TimeSpan.FromSeconds(secounds));
            Console.WriteLine("{0} waits for the gates to open!",threadName);
            _mainEvent.Wait();
            Console.WriteLine("{0} enters the gates!",threadName);

        }
    }
}
