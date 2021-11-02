using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DiningPhilopher
{
    class Manager
    {
        public static List<Fork> forks = new List<Fork>() { new Fork(), new Fork(), new Fork(), new Fork(), new Fork() };
        public static List<Philophers> philophers = new List<Philophers>() { new Philophers("Hans", forks[0], forks[1]), new Philophers("Karsten", forks[1], forks[2]), new Philophers("Fette", forks[2], forks[3]), new Philophers("Jørgen", forks[3], forks[4]), new Philophers("Frank", forks[4], forks[0]) };
        public Thread[] threads = new Thread[5];

        public void Start()
        {
            for (int i = 0; i < 5; i++)
            {
                threads[i] = new Thread(philophers[i].StartPhilophers);
                threads[i].Start();
            }
        }
    }
}
