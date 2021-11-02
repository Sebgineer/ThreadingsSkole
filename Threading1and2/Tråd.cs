using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Threading1and2
{
    class Tråd
    {
        public void Process(object text)
        {
            //kører en loop 5 gange
            for (int i = 0; i < 5; i++)
            {
                //Udskriver tekst
                Console.WriteLine(text);
                Thread.Sleep(1000);
            }
        }

    }
}
