using System;
using System.Threading;

namespace ThreadingsOpgave1
{
    class Program
    {
        static void Main(string[] args)
        {
            Tråd tråd = new Tråd();
            Thread thread1 = new Thread(new ThreadStart(tråd.Process));
            Thread thread2 = new Thread(new ThreadStart(tråd.Process2));
            thread1.Start();
            thread2.Start();

            Console.ReadKey();
        }
    }
}
