using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ovelse1._4
{
    class Tråd
    {
        private char ch = '*';

        public void reader()
        {
            while (true)
            {
                string result = Console.ReadLine();
                if (result != "")
                {
                    this.ch = result[result.Length - 1];
                }
            }
        }

        public void printer()
        {
            while (true)
            {
                Thread.Sleep(50);
                Console.Write(ch);
            }
        }
    }
}
