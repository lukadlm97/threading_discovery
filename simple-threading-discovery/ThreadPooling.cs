using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace simple_threading_discovery
{
    class ThreadPooling
    {
        public delegate string RunOnThreadPool(out int threadId);

        public static void CallBack(IAsyncResult ar)
        {
            Console.WriteLine("Starting a callback...");
            Console.WriteLine("State passed to a callback: {0}",ar.AsyncState);
            Console.WriteLine("Is thread pool thread: {0}",Thread.CurrentThread.IsThreadPoolThread);
            Console.WriteLine("Thread pool worker thread id: {0}", Thread.CurrentThread.ManagedThreadId);

        }

        public  static string Test(out int threadId)
        {
            Console.WriteLine("Starting...");
            Console.WriteLine("Is thread pool thread: {0}",Thread.CurrentThread.IsThreadPoolThread);
            Thread.Sleep(TimeSpan.FromSeconds(2));
            threadId = Thread.CurrentThread.ManagedThreadId;
            return string.Format("Thread pool worker thread id was:{0}", threadId);
        }

    }
}
