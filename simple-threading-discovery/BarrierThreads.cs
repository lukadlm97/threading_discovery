using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace simple_threading_discovery
{
    class BarrierThreads
    {
        public static Barrier barrier = new Barrier(2, b => Console.WriteLine("End of phase {0}", b.CurrentPhaseNumber + 1));
        
        public static void PlayMusic(string name,string message,int secounds)
        {
            for(int i = 1; i < 3; i++)
            {
                Console.WriteLine("----------------------------------------");
                Thread.Sleep(TimeSpan.FromSeconds(secounds));
                Console.WriteLine("{0} starts to {1}",name,message);
                Thread.Sleep(TimeSpan.FromSeconds(secounds));
                Console.WriteLine("{0} finishes to {1}",name,message);
                barrier.SignalAndWait();
            }
        }
    }
}
