using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ovelse1._3
{
    class Tråd
    {
        public void Tempertur()
        {
            Random rnd = new Random();
            int warningsCount = 0;
            int Temp;

            while (warningsCount < 3)
            {
                Thread.Sleep(1000);
                Temp = rnd.Next(-20, 121);
                Console.WriteLine($"{Temp} °C");
                if (Temp < 0 || Temp > 100)
                {
                    Console.WriteLine("Waring!!!");
                    warningsCount++;
                }
            }

        }
    }
}
