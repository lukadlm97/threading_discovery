using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace simple_threading_discovery
{
    class CounterNoLock : CounterBase
    {
        private int _count;
        public int Count { get; set; }
        public override void Decrement()
        {
            Interlocked.Decrement(ref _count);
        }

        public override void Increment()
        {
            Interlocked.Increment(ref _count);
        }
    }
}
