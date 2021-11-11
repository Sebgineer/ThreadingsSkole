using System;
using System.Collections.Generic;
using System.Text;

namespace Bagagesorteringssystem
{
    class Plane
    {
        //Variables
        private string destination;
        private int id;

        //Properties
        public string Destination { get { return this.destination; } }
        public int ID { get { return this.id; } }

        //Constructor
        public Plane()
        {
            Random rnd = new Random();
            this.destination = this.RandomDestination();
            this.id = rnd.Next(10000, 900000);
        }

        public Plane(string destination)
        {
            Random rnd = new Random();
            this.destination = destination;
            this.id = rnd.Next(10000, 900000);

        }

        //Method
        private string RandomDestination()
        {
            string[] des = { "London", "Copenhagen", "Bangkok", "Stockholm", "Oslo", "New York", "Kageland", "New Mexico", "Berlin", "Nukk", "Paris", "Odessa", "Kiev", "Bejing", "Amstardam", "Rønne", "Helsinki", "Rejkevik" };
            Random rnd = new Random();
            return des[rnd.Next(0, des.Length)];
        }

    }
}
