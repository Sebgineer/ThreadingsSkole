using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ovelse1and2
{
    class Tråd
    {
        public void Process(object text)
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(text);
                Thread.Sleep(1000);
            }
        }

    }
}
