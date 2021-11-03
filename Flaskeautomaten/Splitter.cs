using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Flaskeautomaten
{
    class Splitter
    {
        private Bottle bottle;
        private Buffer Input;
        private Buffer OutputBeer;
        private Buffer OutputSoda;

        public Splitter(Buffer Input, Buffer OutputSoda, Buffer OutputBeer)
        {
            this.Input = Input;
            this.OutputBeer = OutputBeer;
            this.OutputSoda = OutputSoda;

        }

        public void Split()
        {
            while (true)
            {
                lock (this.Input.Bottles)
                {
                    if (!this.Input.isEmpty())
                    {
                        Console.WriteLine("test");
                        this.bottle = this.Input.TakeBottle();
                        this.SendBottle();

                        Monitor.Pulse(this.Input.Bottles);
                    }
                    else
                    {
                        Monitor.Wait(this.Input.Bottles);
                    }
                }
                Thread.Sleep(500);
            }
        }

        private void SendBottle()
        {
            if (this.bottle != null)
            {
                Type type = this.bottle.GetType();
                if (type == new SodaBottle().GetType())
                {
                    this.BufferSend(this.OutputSoda);
                }
                else if (type == new BeerBottle().GetType())
                {
                    this.BufferSend(this.OutputBeer);
                }
            }
        }

        public void BufferSend(Buffer Output)
        {
            while (this.bottle != null)
            {
                lock (Output.Bottles)
                {
                    if (!Output.isFull())
                    {
                        Output.GiveBottle(this.bottle);
                        ResetBottle();
                        Monitor.Pulse(Output.Bottles);
                    }
                    else
                    {
                        Monitor.Wait(Output.Bottles);
                    }
                }
            }
        }

        private void ResetBottle()
        {
            this.bottle = null;
        }
    }
}
