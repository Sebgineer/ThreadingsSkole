using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Bagagesorteringssystem
{
    class Manager
    {
        #region Variables

        /// <summary>
        /// Array of Counters
        /// </summary>
        public static Counter[] Counters;

        /// <summary>
        /// Array of Terminals
        /// </summary>
        public static Terminal[] Terminals;

        private Sorter sorter;
        #endregion

        #region Properties

        /// <summary>
        /// Returns true if Counter is empty
        /// </summary>
        public static bool CounterEmpty { get { return ArrayEmpty(Manager.Counters); } }

        /// <summary>
        /// Returns true if Terminal is empty
        /// </summary>
        public static bool TerminalEmpty { get { return ArrayEmpty(Manager.Terminals); } }

        /// <summary>
        /// Returns true if Counter is full
        /// </summary>
        public static bool CounterFull { get { return ArrayFull(Manager.Counters); } }

        /// <summary>
        /// Returns true if Terminal is full
        /// </summary>
        public static bool TerminalFull { get { return ArrayFull(Manager.Terminals); } }

        #endregion

        #region Constructor
        /// <summary>
        /// Manager
        /// </summary>
        /// <param name="MaxCounter">How many Counters there can be</param>
        /// <param name="MaxTerminal">How many Terminals there can be</param>
        public Manager(int MaxCounter, int MaxTerminal)
        {
            Counters = new Counter[MaxCounter];
            Terminals = new Terminal[MaxTerminal];
        }

        #endregion

        #region Method
        /// <summary>
        /// Starts the hole simulation
        /// </summary>
        public void Start()
        {
            Producer producer = new Producer();

            Thread p1 = new Thread(producer.Produce);
            p1.Start();

            while (true)
            {
                Terminal terminal = this.AddTerminal(new Plane());

                Console.WriteLine("Create Station");
                Manager.RandomSleep(5, 20);
            }
        }

        /// <summary>
        /// Adds Counter to System
        /// </summary>
        /// <returns>Returns true if it works</returns>
        private Counter AddCounter(Terminal terminal)
        {
            Counter counter = null;
            if (!Manager.CounterFull)
            {
                Monitor.Enter(Manager.Counters);
                try
                {
                    for (int i = 0; i < Manager.Counters.Length; i++)
                    {
                        if (Manager.Counters[i] == null)
                        {
                            counter = new Counter(null, terminal);
                            Manager.Counters[i] = counter;
                            Thread thread = new Thread(Manager.Counters[i].Start);
                            thread.Name = $"Counter{i}";
                            thread.Priority = ThreadPriority.Normal;
                            thread.Start();
                            Console.WriteLine("Created Counter");
                        }
                    }
                }
                finally
                {
                    Monitor.Pulse(Manager.Counters);
                    Monitor.Exit(Manager.Counters);
                }
            }
            else Console.WriteLine("Counter Failed");
            return counter;
        }

        /// <summary>
        /// Adds Terminal to System
        /// </summary>
        /// <returns>Returns terminal thats created</returns>
        private Terminal AddTerminal(Plane plane)
        {
            Terminal terminal = null;
            if (!Manager.TerminalFull)
            {
                Monitor.Enter(Manager.Terminals);
                try
                {
                    for (int i = 0; i < Manager.Terminals.Length; i++)
                    {
                        if (Manager.Terminals[i] == null)
                        {
                            terminal = new Terminal($"Terminal {i}", plane);
                            Manager.Terminals[i] = terminal;

                            Thread thread = new Thread(Manager.Terminals[i].Start);
                            thread.Name = $"Terminal {i}";
                            thread.Priority = ThreadPriority.Normal;
                            thread.Start();
                            Console.WriteLine("Created Terminal");
                        }
                    }
                }
                finally
                {
                    Monitor.Pulse(Manager.Terminals);
                    Monitor.Exit(Manager.Terminals);
                }
            }
            else Console.WriteLine("Terminal Failed");
            return terminal;
        }

        /// <summary>
        /// Checks if array is empty
        /// </summary>
        /// <param name="objects">An array</param>
        /// <returns>If empty returns true</returns>
        private static bool ArrayEmpty(object[] objects)
        {
            for (int i = 0; i < objects.Length; i++)
            {
                if (objects[i] != null)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Checks if array is full
        /// </summary>
        /// <param name="objects">An array</param>
        /// <returns>If full returns true</returns>
        private static bool ArrayFull(object[] objects)
        {
            for (int i = 0; i < objects.Length; i++)
            {
                if (objects[i] == null)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Random Thread Sleep Time 1 to 5 sec
        /// </summary>
        public static void RandomSleep()
        {
            Random rnd = new Random();
            Thread.Sleep(rnd.Next(1000, 5000));
        }

        /// <summary>
        /// Random Thread Sleep Time
        /// </summary>
        /// <param name="minSec">The minimum Second</param>
        /// <param name="maxSec">The Maximum Second</param>
        public static void RandomSleep(int minSec, int maxSec)
        {
            Random rnd = new Random();
            Thread.Sleep(rnd.Next(minSec * 1000, maxSec * 1000));
        }
        #endregion
    }
}
