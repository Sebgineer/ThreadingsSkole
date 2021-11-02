using System;
using System.Collections.Generic;
using System.Text;

namespace Flaskeautomaten
{
    class Buffer
    {
        //variables
        private int maxBuffer;
        private Bottle[] bottles;

        //Properties
        public int MaxBuffer { get { return this.maxBuffer; } } 
        public Bottle[] Bottles { get { return this.bottles; } }

        public Buffer(int Max)
        {
            this.maxBuffer = Max;
            this.bottles = new Bottle[Max];
        }

        public void GiveBottle(Bottle bottle)
        {

        }

        public Bottle TakeBottle()
        {
            Bottle returnBottle = this.bottles[0];

            for (int i = 1; i < this.bottles.Length; i++)
            {
                this.bottles[i - 1] = this.bottles[i];
            }

            this.bottles[this.bottles.Length] = null;

            return returnBottle;
        }
    }
}
