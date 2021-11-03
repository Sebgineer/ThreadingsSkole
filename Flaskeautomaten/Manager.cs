using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Flaskeautomaten
{
    class Manager
    {
        private static Buffer InputBuffer = new Buffer(5);
        private static Buffer BeerBuffer = new Buffer(5);
        private static Buffer SodaBuffer = new Buffer(5);

        private Consumer BeerConsumer = new Consumer(BeerBuffer);
        private Consumer SodaConsumer = new Consumer(SodaBuffer);

        private Producer producer = new Producer(InputBuffer);

        private Splitter splitter = new Splitter(InputBuffer, SodaBuffer, BeerBuffer);

        public void Start()
        {
            //Consumer Threads
            Thread c1 = new Thread(BeerConsumer.Consume);
            Thread c2 = new Thread(SodaConsumer.Consume);
            //Producer Thread
            Thread p1 = new Thread(producer.Produce);
            //Splitter Thread
            Thread s1 = new Thread(splitter.Split);

            //Give Threads Names
            c1.Name = "Beer Consumer";
            c2.Name = "Soda Consumer";
            p1.Name = "Producer";
            s1.Name = "Splitter";

            //Starts Threads
            c1.Start();
            c2.Start();
            p1.Start();
            s1.Start();


            //Print Info Loop
            while (true)
            {
                Console.Clear();
                Console.Write("Queue = ");
                InputBuffer.Print();
                Console.Write("Beer List = ");
                BeerBuffer.Print();
                Console.Write("Soda List = ");
                SodaBuffer.Print();

                Console.WriteLine($"Beers = {BeerConsumer.Count}\nSodas = {SodaConsumer.Count}");

                Thread.Sleep(500);
            }
        }
    }
}
