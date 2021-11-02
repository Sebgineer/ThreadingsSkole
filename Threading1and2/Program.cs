using System;
using System.Threading;

namespace Threading1and2
{
    class Program
    {
        static void Main(string[] args)
        {
            //laver min klasse tråd.
            Tråd tråd = new Tråd();

            //Laver 2 Tråde
            Thread thread1 = new Thread(tråd.Process);
            Thread thread2 = new Thread(tråd.Process);

            //her starter vi trådene med en parameter.
            thread1.Start("C#-trådning er nemt!");
            thread2.Start("Også med flere tråde ...");

            //slut
            Console.ReadKey();
        }
    }
}
