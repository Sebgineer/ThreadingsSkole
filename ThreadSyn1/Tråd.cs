using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ThreadSyn1
{
    class Tråd
    {
        private int count = 0;
        private object _Lock = new object();

        public void Process(object value)
        {
            while (true)
            {
                Monitor.Enter(_Lock);
                this.count += (int)value;
                Console.WriteLine($"Count: {this.count}");
                Monitor.Exit(_Lock);
                Thread.Sleep(1000);
            }
        }
    }
}
