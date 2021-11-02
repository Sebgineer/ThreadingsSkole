using System;
using System.Threading;

namespace Threading4
{
    class Program
    {
        static void Main(string[] args)
        {
            Tråd tråd = new Tråd();
            Thread thread1 = new Thread(tråd.printer);
            Thread thread2 = new Thread(tråd.reader);
            thread1.Start();
            thread2.Start();
        }
    }
}
