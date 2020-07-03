using System;
using System.Collections.Generic;
using System.Text;

namespace simple_threading_discovery
{
    abstract class CounterBase
    {
        public abstract void Increment();
        public abstract void Decrement();
    }
}
