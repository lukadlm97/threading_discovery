using System;
using System.Diagnostics;
using System.Threading;

namespace simple_threading_discovery
{
    class Program
    {
        static void Main(string[] args)
        {
            //Thread thread = new Thread(PrintNumbersWithDelay);
            //thread.Start();
            //PrintNumbers();
            //Thread.Sleep(TimeSpan.FromSeconds(2));
            //thread.Abort();
            //Console.WriteLine("A Thread aborted!!!");
            //Thread t = new Thread(PrintNumbers);
            //t.Start();
            ////thread.Join();
            //Console.WriteLine("Program started");
            //Thread thread1 = new Thread(PrintNumbersWithDelay);
            //Thread thread2 = new Thread(DoNothing);
            //Console.WriteLine(thread1.ThreadState.ToString());
            //thread2.Start();
            //thread1.Start();
            //for(int i=1;i<30;i++)
            //    Console.WriteLine(thread1.ThreadState.ToString());
            //Thread.Sleep(TimeSpan.FromSeconds(2));
            //thread1.Abort();
            //Console.WriteLine("A thread has been aborted!");
            //Console.WriteLine(thread1.ThreadState.ToString());
            //Console.WriteLine(thread2.ThreadState.ToString());
            //Console.WriteLine("Current thread priority:{0}",
            //Thread.CurrentThread.Priority);
            //Console.WriteLine("Running on all cores available");
            //RunThreads();
            //Thread.Sleep(TimeSpan.FromSeconds(2));
            //Console.WriteLine("Running on a single core");
            //Process.GetCurrentProcess().ProcessorAffinity
            //= new IntPtr(1);
            //RunThreads();
            RunGrounds();

        }

        static void RunGrounds()
        {
            var simpleForeground = new ThreadSamp(20);
            var simpleBackground = new ThreadSamp(30);

            var threadOne = new Thread(simpleForeground.CountNumber);
            threadOne.Name = "ForegroudThread";
            var threadTwo = new Thread(simpleBackground.CountNumber);
            threadTwo.Name = "BackgroundThread";
            threadTwo.IsBackground = true;

            threadOne.Start();
            threadTwo.Start();
        }

        static void RunThreads()
        {
            var sample = new ThreadSample();
            var threadOne = new
            Thread(sample.CountNumber);
            threadOne.Name = "ThreadOne";
            var threadTwo = new
            Thread(sample.CountNumber);
            threadTwo.Name = "ThreadTwo";
            threadOne.Priority = ThreadPriority.Highest;
            threadTwo.Priority = ThreadPriority.Lowest;
            threadOne.Start();
            threadTwo.Start();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            sample.Stop();
        }

        static void PrintNumbers()
        {
            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }
        }

        static void PrintNumbersWithDelay()
        {
            Console.WriteLine("Starting...");
            Console.WriteLine(Thread.CurrentThread.Name);
            for(int i = 0; i < 10; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(2));
                Console.WriteLine("number with dealy:"+i);
            }
        }

        static void DoNothing()
        {
            Thread.Sleep(TimeSpan.FromSeconds(5));
        }

    }
}
