using System;
using System.Collections.Generic;
using System.Text;

namespace Flaskeautomaten
{
    class SodaBottle : Bottle
    {
        //Constructor
        public SodaBottle() 
        {
            //Making an random name, to keeping eye on the object
            this.name = $"Soda: {this.RandomNum()}";
        }
    }
}
