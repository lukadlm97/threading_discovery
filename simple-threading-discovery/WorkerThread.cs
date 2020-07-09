using System;
using System.Collections.Generic;
using System.Text;

namespace simple_threading_discovery
{
    class WorkerThread
    {
        private volatile bool shouldStop;

        public void DoWork()
        {
            while (shouldStop)
            {
                Console.WriteLine("Worker thread: working...");
            }
            Console.WriteLine("Worker thread: terminationg gracefully.");
        }


        public void RequestStop()
        {
            shouldStop = true;
        }
    }
}
