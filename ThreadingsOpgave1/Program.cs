﻿using System;
using System.Threading;

namespace ovelse1and2
{
    class Program
    {
        static void Main(string[] args)
        {
            Tråd tråd = new Tråd();
            Thread thread1 = new Thread(tråd.Process);
            Thread thread2 = new Thread(tråd.Process);
            thread1.Start("C#-trådning er nemt!");
            thread2.Start("Også med flere tråde ...");

            Console.ReadKey();
        }
    }
}
