using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ThreadSyn2
{
    class Tråd
    {
        private object _Lock = new object();
        private static Queue<object> _queue = new Queue<object>();
        private int row = 1;
        private int charinrow = 80;

        public void Process(object charator)
        {
            char ch = (char)charator;
            
            while (true)
            {
                lock (_Lock)
                {
                    for (int i = 0; i < charinrow; i++)
                    {
                        Console.Write(ch);
                    }

                    Console.WriteLine($" {row * charinrow}");

                    row++;
                    Monitor.PulseAll(_Lock);
                    Thread.Sleep(100);
                }
            }
        }
    }
}
