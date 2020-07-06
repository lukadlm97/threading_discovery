using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace simple_threading_discovery
{
    class SemaphoreSample
    {
        static SemaphoreSlim _semaphore = new SemaphoreSlim(4);

       public  static void AccessDatabase(string threadName,int secounds)
        {
            Console.WriteLine("{0} waits to access the database",threadName);
            _semaphore.Wait();

            Console.WriteLine("{0} was granted an access to a database",threadName);
            Thread.Sleep(TimeSpan.FromSeconds(secounds));

            Console.WriteLine("{0} is completed",threadName);

            _semaphore.Release();

        }
    }
}
