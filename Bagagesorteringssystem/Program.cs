using System;

namespace Bagagesorteringssystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager(10, 10);

            manager.Start();
        }
    }
}
