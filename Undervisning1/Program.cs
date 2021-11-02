using System;
using System.Threading;

namespace Undervisning1
{
    class Program
    {
        static int sum = 0;
        static void Main(string[] args)
        {
            Thread[] threads = new Thread[1000];

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(addone);
                threads[i].Start();
            }

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i].Join();
            }

            Console.WriteLine(sum);
        }

        public static void addone()
        {
            Console.WriteLine($"[{Thread.CurrentThread.ManagedThreadId}] added one");
            Interlocked.Increment(ref sum);
        }
    }
}
