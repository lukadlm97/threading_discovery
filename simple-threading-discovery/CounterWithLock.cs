using System;
using System.Collections.Generic;
using System.Text;

namespace simple_threading_discovery
{
    class CounterWithLock : CounterBase
    {
        public int Count { get; private set; }
        private readonly object lock_object = new Object();
        public override void Decrement()
        {
            lock (lock_object)
            {
                Count--;
            }
        }

        public override void Increment()
        {
            lock (lock_object)
            {
                Count++;
            }
        }
    }
}
