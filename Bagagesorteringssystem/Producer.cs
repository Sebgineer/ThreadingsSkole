using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Bagagesorteringssystem
{
    /// <summary>
    /// 
    /// </summary>
    class Producer
    {
        //Variables

        //Properties


        //Constructor


        public Producer()
        {

        }

        //Method
        
        /// <summary>
        /// Starts the Producing
        /// </summary>
        public void Produce()
        {
            while (true)
            {
                Person person = CreatePerson();
                if (person.Luggage.Terminal != null)
                {
                    Console.WriteLine("Person Created");
                }
                else
                {
                    Console.WriteLine("Person Failed");
                }



                Manager.RandomSleep();
            }
        }

        /// <summary>
        /// Generate a Random Person
        /// </summary>
        /// <returns>Random New Person</returns>
        private Person CreatePerson()
        {   
            return new Person(new Luggage());
        }
    }
}
