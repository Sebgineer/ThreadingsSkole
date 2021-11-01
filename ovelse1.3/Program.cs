using System;
using System.Threading;

namespace ovelse1._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Tråd tråd = new Tråd();
            Thread thread = new Thread(tråd.Tempertur);
            thread.Name = "TempThread";
            thread.Priority = ThreadPriority.AboveNormal;
            thread.Start();

            while (thread.IsAlive)
            {
                Thread.Sleep(5000);
            }
            Console.WriteLine($"[{thread.Name}] Alarm-tråd termineret!");
        }
    }
}
