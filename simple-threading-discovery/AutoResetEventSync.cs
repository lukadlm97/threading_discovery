using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace simple_threading_discovery
{
    class AutoResetEventSync
    {
        public static AutoResetEvent _workerEvent = 
            new AutoResetEvent(false);
        public static AutoResetEvent _mainEvent =
            new AutoResetEvent(false);

        public static void Process(int secound)
        {
            Console.WriteLine("Starting a long running work ...");
            Thread.Sleep(TimeSpan.FromSeconds(secound));
            Console.WriteLine("Work is done!!!");
            _workerEvent.Set();
            Console.WriteLine("Waiting for a main thread to complete its work");
            _mainEvent.WaitOne();
            Console.WriteLine("Starting secound operation ...");
            Thread.Sleep(TimeSpan.FromSeconds(secound));
            Console.WriteLine("Work is done!!!");
            _workerEvent.Set();
        }

    }
}
