using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Flaskeautomaten
{
    class Consumer
    {
        //Variables
        private int count;
        private Buffer input;

        //Properties
        public int Count { get { return this.count; } }
        
        //Constructor
        public Consumer(Buffer Input)
        {
            this.count = 0;
            this.input = Input;
        }

        //Method

        //The Consume the input buffer of bottles
        public void Consume()
        {
            while (true)
            {
                lock (this.input.Bottles)
                {
                    if (!this.input.isEmpty())
                    {
                        Bottle bottle = this.input.TakeBottle();

                        if (bottle != null)
                        {
                            this.count++;
                        }
                        Monitor.Pulse(this.input.Bottles);

                    }
                    else
                    {
                        Monitor.Wait(this.input.Bottles);
                    }
                    
                }
                //to slow it down ;P
                Random rnd = new Random();
                Thread.Sleep(rnd.Next(1000, 5000));
            }
        }
    }
}
