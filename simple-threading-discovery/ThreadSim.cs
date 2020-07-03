using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace simple_threading_discovery
{
    class ThreadSim
    {
        private readonly int _iteratons;

        public ThreadSim(int iterations)
        {
            _iteratons = iterations;
        }
        public void CountNumbers()
        {
            for(int i = 1; i < _iteratons; i++)
            {

                Thread.Sleep(TimeSpan.FromSeconds(0.5));
                Console.WriteLine("{0} prints {1}",
                    Thread.CurrentThread.Name,
                    i);
            }
        }

        public void PrintNum(int num)
        {
            Console.WriteLine(num);
        }
    }
}
