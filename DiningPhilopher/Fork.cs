using System;
using System.Collections.Generic;
using System.Text;

namespace DiningPhilopher
{
    class Fork
    {
        //Varibles
        //private int id;
        private bool taken;

        //Properties
        //public int ID { get { return this.id; } }
        public bool Taken { get { return this.taken; } set { this.taken = value; } }

        public Fork()
        {
            this.taken = false;
        }
    }
}
