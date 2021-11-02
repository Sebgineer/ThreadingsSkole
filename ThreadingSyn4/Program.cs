using System;
using System.Threading;

namespace ThreadingSyn4
{
    class Program
    {
        static void Main(string[] args)
        {
            Tråd tråd = new Tråd();

            Thread thread1 = new Thread(tråd.Producer);
            Thread thread2 = new Thread(tråd.Consumer);

            thread1.Start();
            thread2.Start();
        }
    }
}
