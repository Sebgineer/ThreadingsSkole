using System;
using System.Threading;

namespace ThreadSyn1
{
    class Program
    {
        static void Main(string[] args)
        {
            Tråd tråd = new Tråd();
            Thread thread1 = new Thread(tråd.Process);
            Thread thread2 = new Thread(tråd.Process);

            thread1.Start(2);
            Thread.Sleep(500);
            thread2.Start(-1);
        }
    }
}
