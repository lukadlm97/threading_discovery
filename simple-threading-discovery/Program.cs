using System;
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
            //thread.Join();
            Console.WriteLine("Program started");
            Thread thread1 = new Thread(PrintNumbersWithDelay);
            Thread thread2 = new Thread(DoNothing);
            Console.WriteLine(thread1.ThreadState.ToString());
            thread2.Start();
            thread1.Start();
            for(int i=1;i<30;i++)
                Console.WriteLine(thread1.ThreadState.ToString());
            Thread.Sleep(TimeSpan.FromSeconds(2));
            thread1.Abort();
            Console.WriteLine("A thread has been aborted!");
            Console.WriteLine(thread1.ThreadState.ToString());
            Console.WriteLine(thread2.ThreadState.ToString());
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
