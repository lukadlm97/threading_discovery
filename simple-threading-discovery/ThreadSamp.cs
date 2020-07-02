using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace simple_threading_discovery
{
    class ThreadSamp
    {
        private readonly int _iterations;

        public ThreadSamp(int iterations)
        {
            _iterations = iterations;
        }

        public void CountNumber()
        {
            int a = 1;
            for (;a<_iterations;)
            {
                Thread.Sleep(TimeSpan.FromSeconds(0.5));
                Console.WriteLine("a: {0} thread name: {1}",a++,Thread.CurrentThread.Name);
            }
        }
    }
}
