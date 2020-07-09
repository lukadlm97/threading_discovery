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
            // RunGrounds();

            //ThreadWithoutLocks();
            ///  RunMutex();

            // AutoResetSimulation();
            //   ManualSimulation();
            //CountdownSimulation();
            // BarrierSimulation(); 
            /*   int a = 5;
               object b = a;
               a++;
               int c = (int)b;
               c++;
               Console.WriteLine("{0} {1} {2}",a,b,c);

               M1 delegatM = new M1(metoda);
               delegatM = metoda;
               delegatM += metoda1;
               delegatM(5);

               SomeClass some = new SomeClass(4, "prvi");
               SomeClass some1 = new SomeClass(2, "drugi");

               Console.WriteLine("prvi : {0} {1} {2}",some,some.a,some.b);
               Console.WriteLine("drugi : {0} {1} {2}", some1, some1.a, some1.b);

               Swap<SomeClass>(ref some, ref some1);

               Console.WriteLine("prvi : {0} {1} {2}", some, some.a, some.b);
               Console.WriteLine("drugi : {0} {1} {2}", some1, some1.a, some1.b);

               int prvi = 1;
               int drugi = 2;

               Console.WriteLine("{0} {1}",prvi,drugi);
               Swap<int>(ref prvi,ref drugi);
               Console.WriteLine("{0} {1}", prvi, drugi);

               int treci = 1;
               int cetvrti = 2;

               Console.WriteLine("{0} {1}", treci, cetvrti);
               Swap(treci,cetvrti);
               Console.WriteLine("{0} {1}", treci, cetvrti);*/


            // VolatileThread();

          /*  A a = new B();
            E e = (E)a;
            F f = (F)e;
            E r = new F();
            B b = (B)a;*/
        }

        public static void VolatileThread()
        {
            WorkerThread workerObject = new WorkerThread();
            Thread thread = new Thread(workerObject.DoWork);

            thread.Start();

            Console.WriteLine("Main thread:starting worker thread...");

            while (!thread.IsAlive) ;
            Thread.Sleep(1);

            workerObject.RequestStop();
            thread.Join();
            Console.WriteLine("Main thread: worker thread has terminated.");
            Console.ReadKey();
        }

        public static void Swap(dynamic a,dynamic b)
        {
            dynamic x = a;
            a = b;
            b = x;
        }

        public static void Swap<T>(ref T firstValue,ref T secoundValue)
        {
            T tempValue = firstValue;
            firstValue = secoundValue;
            secoundValue = tempValue;
        }

        class SomeClass
        {
            public int a = 0;
            public string b = null;

            public SomeClass(int b,string s)
            {
                a = b;
                this.b = s;
            }
        }

        public static void metoda(int b)
        {
            Console.WriteLine(b);
        }
        public static void metoda1(int c)
        {
            Console.WriteLine(c);
        }
        public delegate void M1(int a);

        static void ThreadPoolingSimulation()
        {
            int threadId = 0;

            ThreadPooling.RunOnThreadPool poolDelegate = ThreadPooling.Test;

            var t = new Thread(() => ThreadPooling.Test(out threadId));
            t.Start();
            t.Join();

            Console.WriteLine("Thread id:{0}",threadId);

            IAsyncResult r = poolDelegate.BeginInvoke(out threadId, ThreadPooling.CallBack, "a delegate asynchronous call");
            r.AsyncWaitHandle.WaitOne();

            string result = poolDelegate.EndInvoke(out threadId, r);

            Console.WriteLine("Thread pool worker thread id: {0}",threadId);
            Console.WriteLine(result);

            Thread.Sleep(TimeSpan.FromSeconds(2));
        }

        static void BarrierSimulation()
        {
            var t1 = new Thread(() =>
            BarrierThreads.PlayMusic("the guitarist", "play an amazing solo", 5));
            var t2 = new Thread(() =>
               BarrierThreads.PlayMusic("the singer", "sing his song", 3));

            t1.Start();
            t2.Start();
        }

        static void CountdownSimulation()
        {
            Console.WriteLine("Starting two operations.");
            var t1 = new Thread(() =>
            CountDownOperations.PerformOperation("Operation 1 iscompleted", 4));
            var t2 = new Thread(() =>
            CountDownOperations.PerformOperation("Operation 2 iscompleted", 8));
            t1.Start();
            t2.Start();
            CountDownOperations._countdown.Wait();
            Console.WriteLine("Both operations have been complted.");
            CountDownOperations._countdown.Dispose();
        }

        static void ManualSimulation()
        {
            var t1 = new Thread(() =>
            GatesSimulation.TravelThroughGates("Thread 1", 5));
            var t2 = new Thread(() =>
            GatesSimulation.TravelThroughGates("Thread 2", 6));
            var t3 = new Thread(() =>
            GatesSimulation.TravelThroughGates("Thread 3", 12));

            t1.Start();
            t2.Start();
            t3.Start();

            Thread.Sleep(TimeSpan.FromSeconds(6));
            Console.WriteLine("The gates are now open!");
            GatesSimulation._mainEvent.Set();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            GatesSimulation._mainEvent.Reset();
            Console.WriteLine("The gates have been closed!");
            Thread.Sleep(TimeSpan.FromSeconds(10));
            Console.WriteLine("The gates are now open for the secound time!");
            GatesSimulation._mainEvent.Set();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            Console.WriteLine("The gates have been closed!");
            GatesSimulation._mainEvent.Reset();
        }

        static void AutoResetSimulation()
        {
            var t = new Thread(() => AutoResetEventSync.Process(10));
            t.Start();

            Console.WriteLine("Waitning for another thread to complete work");
            AutoResetEventSync._workerEvent.WaitOne();
            Console.WriteLine("First operations has completed!");
            Console.WriteLine("Performing an operation on a mainthread!");
            Thread.Sleep(TimeSpan.FromSeconds(5));
            AutoResetEventSync._mainEvent.Set();
            Console.WriteLine("Now running the secound operation on a secound thread");
            AutoResetEventSync._workerEvent.WaitOne();
            Console.WriteLine("Secound operation completed!");
            
        }

        static void SempahoreSimulation()
        {
            for (int i = 0; i <= 6; i++)
            {
                string threadName = "Thread" + i;
                int secoundToWait = 2 + 2 * i;
                var t = new Thread(() =>
                SemaphoreSample.AccessDatabase(threadName, secoundToWait));
                t.Start();
            }
        }

        static void RunMutex()
        {
            const string MutexName = "SomeNamedMutex";

            using(var m = new Mutex(false, MutexName))
            {
                if (!m.WaitOne(TimeSpan.FromSeconds(15)))
                {
                    Console.WriteLine("The secound instance running!!!");
                }
                else
                {
                    Console.WriteLine("Running!!!");
                    Console.ReadLine();
                    m.ReleaseMutex();
                }
            }

        }

        private static void ThreadWithoutLocks()
        {
            Console.WriteLine("Incorrect counter");

            var c = new Counter();

            var t1 = new Thread(() => TestCounter(c));
            var t2 = new Thread(() => TestCounter(c));
            var t3 = new Thread(() => TestCounter(c));

            t1.Start();
            t2.Start();
            t3.Start();
            t1.Join();
            t2.Join();
            t3.Join();

            Console.WriteLine("Total count: {0}", c.Count);
            Console.WriteLine("-------------------------------");

            Console.WriteLine("Incorrect counter");

            var c1 = new CounterNoLock();

            t1 = new Thread(() => TestCounter(c1));
            t2 = new Thread(() => TestCounter(c1));
            t3 = new Thread(() => TestCounter(c1));

            t1.Start();
            t2.Start();
            t3.Start();
            t1.Join();
            t2.Join();
            t3.Join();

            Console.WriteLine("Total count: {0}", c1.Count);
            Console.WriteLine("-------------------------------");

        }

        private static void ThreadWithLocks()
        {
            Console.WriteLine("Incorrect counter");

            var c = new Counter();

            var t1 = new Thread(() => TestCounter(c));
            var t2 = new Thread(() => TestCounter(c));
            var t3 = new Thread(() => TestCounter(c));

            t1.Start();
            t2.Start();
            t3.Start();
            t1.Join();
            t2.Join();
            t3.Join();

            Console.WriteLine("Total count: {0}",c.Count);
            Console.WriteLine("-------------------------------");

            Console.WriteLine("Incorrect counter");

            var c1 = new CounterWithLock();

            t1 = new Thread(() => TestCounter(c1));
            t2 = new Thread(() => TestCounter(c1));
            t3 = new Thread(() => TestCounter(c1));

            t1.Start();
            t2.Start();
            t3.Start();
            t1.Join();
            t2.Join();
            t3.Join();

            Console.WriteLine("Total count: {0}", c1.Count);
            Console.WriteLine("-------------------------------");
        }

        static void TestCounter(CounterBase c)
        {
            for (int i = 0; i < 100000; i++)
            {
                c.Increment();
                c.Decrement();
            }
        }

        static void ThreadSimultany()
        {
            var sample = new ThreadSim(10);

            var threadOne = new Thread(sample.CountNumbers);
            threadOne.Name = "threadOne";
            threadOne.Start();
            threadOne.Join();
            Console.WriteLine("---------------------------------------");

            var threadTwo = new Thread(Count);
            threadTwo.Name = "threadTwo";
            threadTwo.Start(8);
            threadTwo.Join();
            Console.WriteLine("---------------------------------------");

            var threadThree = new Thread(() => CountNumbers(12));
            threadThree.Name = "ThreadThree";
            threadThree.Start();
            threadThree.Join();
            Console.WriteLine("---------------------------------------");

            int i = 10;
            var threadFour = new Thread(() =>
            sample.PrintNum(i));
            i = 20;
            var threadFive = new Thread(() =>
             sample.PrintNum(i));

            threadFour.Start();
            threadFive.Start();
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

        static void Count(object iterations)
        {
            CountNumbers((int)iterations);
        }

        private static void CountNumbers(int iterations)
        {
            int i = 0;
            for (; i < iterations;)
            {
                Thread.Sleep(TimeSpan.FromSeconds(0.5));
                Console.WriteLine("{0} prints {1}",Thread.CurrentThread.Name,i++);
            }
        }
    }
}
