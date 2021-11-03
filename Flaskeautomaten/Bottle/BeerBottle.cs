using System;
using System.Collections.Generic;
using System.Text;

namespace Flaskeautomaten
{
    class BeerBottle : Bottle
    {
        //Constuctor
        public BeerBottle()
        {
            //Making an random name, to keeping eye on the object
            this.name = $"Beer: {this.RandomNum()}";
        }
    }
}
