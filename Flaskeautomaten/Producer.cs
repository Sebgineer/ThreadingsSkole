using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Flaskeautomaten
{
    class Producer
    {
        //Variables
        private Buffer output;
        private Random rnd = new Random();

        //Constructor
        public Producer(Buffer Output)
        {
            this.output = Output;
        }

        //Method

        //Produce bottles to the buffer
        public void Produce()
        {
            while (true)
            {
                lock (this.output.Bottles)
                {
                    if (!this.output.isFull())
                    {
                        Bottle bottle = null;
                        switch (rnd.Next(0, 2))
                        {
                            case 0:
                                bottle = new BeerBottle();
                                break;
                            case 1:
                                bottle = new SodaBottle();
                                break;
                        }

                        this.output.GiveBottle(bottle);

                        Monitor.Pulse(this.output.Bottles);
                    }
                    else
                    {
                        Monitor.Wait(this.output.Bottles);
                    }
                }
                Thread.Sleep(rnd.Next(1000, 2500));
            }
        }
    }
}
