using System;
using System.Collections.Generic;
using System.Text;

namespace Flaskeautomaten
{
    class Buffer
    {
        //Variables
        private int maxBuffer;
        private Bottle[] bottles;


        //Properties
        public int MaxBuffer { get { return this.maxBuffer; } } 
        public Bottle[] Bottles { get { return this.bottles; } }


        //Constructer
        public Buffer(int Max)
        {
            this.maxBuffer = Max;
            this.bottles = new Bottle[Max];
        }


        //Methods

        //This Method Put the giving bottle in its system
        public bool GiveBottle(Bottle bottle)
        {
            for (int i = 0; i < this.bottles.Length; i++)
            {
                //checks if the Array is full
                if (this.bottles[i] == null)
                {
                    this.bottles[i] = bottle;
                    return true;
                }
            }
            return false;
        }

        //Send the oldest bottle to the request and delete it in the array
        public Bottle TakeBottle()
        {
            Bottle returnBottle = this.bottles[0];

            //Moving the queue
            for (int i = 1; i < this.bottles.Length; i++)
            {
                this.bottles[i - 1] = this.bottles[i];
            }

            this.bottles[this.bottles.Length - 1] = null;

            return returnBottle;
        }

        //prints the Array to read
        public void Print()
        {
            for (int i = 0; i < this.bottles.Length; i++)
            {
                if (this.bottles[i] != null)
                {
                    Console.Write($"{this.bottles[i].Name} ");
                }
            }
            Console.WriteLine(".");
        }

        //checks if the array is empty
        public bool isEmpty()
        {
            for (int i = 0; i < this.bottles.Length; i++)
            {
                if (this.bottles[i] != null)
                {
                    return false;
                }
            }

            return true;
        }

        //checks if the array is full
        public bool isFull()
        {
            for (int i = 0; i < this.bottles.Length; i++)
            {
                if (this.bottles[i] == null)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
