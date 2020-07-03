using System;
using System.Collections.Generic;
using System.Text;

namespace simple_threading_discovery
{
    class Counter : CounterBase
    {
        public int Count { get; private set; }
        public override void Decrement()
        {
            Count--;
        }

        public override void Increment()
        {
            Count++;
        }
    }
}
