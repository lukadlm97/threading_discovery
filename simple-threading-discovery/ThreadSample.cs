using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace simple_threading_discovery
{
    class ThreadSample
    {
        private bool _isStopped = false;
        public void Stop()
        {
            _isStopped = true;
        }
        public void CountNumber()
        {
            long counter = 0;
            while (!_isStopped)
                counter++;

            Console.WriteLine("{0} with {1,11} priority "+" has a count={2,13}",
                Thread.CurrentThread.Name,
                Thread.CurrentThread.Priority,
                counter.ToString("NO"));
        }

    }
}
