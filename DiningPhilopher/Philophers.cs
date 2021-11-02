using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DiningPhilopher
{
    class Philophers
    {
        //variables
        private string name;
        private Fork forkLeft;
        private Fork forkRight;

        //properties
        public string Name { get { return this.name; } }
        public Fork ForkLeft { get { return this.forkLeft; } }
        public Fork ForkRight { get { return this.forkRight; } }

        //Constructor
        public Philophers(string name, Fork fork1, Fork fork2)
        {
            this.name = name;
            this.forkLeft = fork1;
            this.forkRight = fork2;
        }

        //Method
        public void StartPhilophers()
        {
            bool haveEat;
            while (true)
            {
                haveEat = false;
                lock (this.forkLeft)
                {
                    if (Monitor.TryEnter(this.forkRight))
                    {
                        Eat();
                        haveEat = true;

                        Monitor.Pulse(this.forkRight);
                        Monitor.Exit(this.forkRight);
                    }
                    Monitor.Pulse(this.forkLeft);
                }
                if (haveEat) Think();


            }
        }

        private void Eat()
        {
            Random rnd = new Random();
            Console.WriteLine($"[{this.name}] Spiser Maden");

            Thread.Sleep(rnd.Next(900, 2000));
        }

        private void Think()
        {
            Random rnd = new Random();
            //Console.WriteLine($"[{this.name}] Tænker");

            Thread.Sleep(rnd.Next(2000, 5000));
        }
    }
}
