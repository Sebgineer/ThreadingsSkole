using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ThreadingSyn4
{
    class Tråd
    {
        public static Queue<object> queue = new Queue<object>();

        public void Producer() 
        {
            while (true)
            {
                lock (queue)
                {
                    if (queue.Count < 3)
                    {
                        Thread.Sleep(50);
                        queue.Enqueue(new object());
                        Console.WriteLine($"P: {queue.Count}");
                        Monitor.Pulse(queue);

                    }
                    else
                    {
                        Monitor.Wait(queue);
                    }
                }
            }
        }

        public void Consumer()
        {
            while (true)
            {
                lock (queue)
                {
                    if (queue.Count > 0)
                    {
                        Thread.Sleep(100);
                        queue.Dequeue();
                        Console.WriteLine($"C: {queue.Count}");
                        Monitor.Pulse(queue);
                    }
                    else
                    {
                        Monitor.Wait(queue);
                    }
                }
            }
        }
    }
}
