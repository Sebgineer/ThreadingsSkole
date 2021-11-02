using System;
using System.Threading;

namespace ThreadSyn2
{
    class Program
    {
        static void Main(string[] args)
        {
            Tråd tråd = new Tråd();

            Thread thread1 = new Thread(tråd.Process);
            Thread thread2 = new Thread(tråd.Process);
            Thread thread3 = new Thread(tråd.Process);
            thread1.Start('*');
            thread2.Start('#');
            thread3.Start('@');

        }
    }
}
