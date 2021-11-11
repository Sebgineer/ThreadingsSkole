using System;
using System.Collections.Generic;
using System.Text;

namespace Bagagesorteringssystem
{
    class Person
    {
        //Variables
        private Luggage luggage;

        //Properties
        public Luggage Luggage { get { return this.luggage; } }

        //Constructor
        public Person(Luggage luggage)
        {
            this.luggage = luggage;
        }

        //Method
        public Luggage TakeLuggage()
        {
            Luggage result = this.luggage;
            this.luggage = null;

            return result;
        }
    }
}
