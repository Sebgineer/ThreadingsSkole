using System;
using System.Collections.Generic;
using System.Text;

namespace Flaskeautomaten
{
    abstract class Bottle
    {
        //variables
        protected string name;

        //Properties
        public string Name { get { return this.name; } }

        //Method to make a Random Num to Name.
        protected int RandomNum()
        {
            Random rnd = new Random();
            return rnd.Next(1000, 90000);
        }
    }
}
