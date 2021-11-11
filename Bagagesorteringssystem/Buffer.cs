using System;
using System.Collections.Generic;
using System.Text;

namespace Bagagesorteringssystem
{
    class Buffer
    {
        //Variables
        #region Variables
        private int maxBuffer;
        private Luggage[] luggages;

        #endregion
        //Properties
        #region Properties
        public int MaxBuffer { get { return this.maxBuffer; } }
        public Luggage[] Luggages { get { return this.luggages; } }

        #endregion
        //Constructor
        #region Constructor
        public Buffer(int Max)
        {
            this.maxBuffer = Max;
            this.luggages = new Luggage[Max];
        }

        #endregion
        //Methods
        #region Methods
        public bool GiveLuggage(Luggage luggage)
        {
            for (int i = 0; i < this.luggages.Length; i++)
            {
                //checks if the Array is full
                if (this.luggages[i] == null)
                {
                    this.luggages[i] = luggage;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Send the oldest bottle to the request and delete it in the array
        /// </summary>
        /// <returns>g</returns>
        public Luggage TakeLuggage()
        {
            Luggage returnLuggage = this.luggages[0];

            //Moving the queue
            for (int i = 1; i < this.luggages.Length; i++)
            {
                this.luggages[i - 1] = this.luggages[i];
            }

            this.luggages[this.luggages.Length - 1] = null;

            return returnLuggage;
        }

        /// <summary>
        /// prints the Array to read
        /// </summary>
        public void Print()
        {
            for (int i = 0; i < this.luggages.Length; i++)
            {
                if (this.luggages[i] != null)
                {
                    Console.Write($"{this.luggages[i].Terminal.TerminalID} ");
                }
            }
            Console.WriteLine(".");
        }

        /// <summary>
        /// checks if the array is empty
        /// </summary>
        /// <returns>Returns true if empty</returns>
        public bool isEmpty()
        {
            for (int i = 0; i < this.luggages.Length; i++)
            {
                if (this.luggages[i] != null)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// checks if the array is full
        /// </summary>
        /// <returns>Returns true if full</returns>
        public bool isFull()
        {
            for (int i = 0; i < this.luggages.Length; i++)
            {
                if (this.luggages[i] == null)
                {
                    return false;
                }
            }
            return true;
        }

        #endregion
    }
}
