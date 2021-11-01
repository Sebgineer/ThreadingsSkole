using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ThreadingsOpgave1
{
    class Tråd
    {
        public void Process()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("C#-trådning er nemt!");
                Thread.Sleep(1000);
            }
        }

        public void Process2()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Også med flere tråde ...");
                Thread.Sleep(1000);
            }
        }
    }
}
