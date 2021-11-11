using System;
using System.Collections.Generic;
using System.Text;

namespace Bagagesorteringssystem
{
    class Terminal
    {
        //Variables
        private string terminalID;
        private Plane plane;

        //Properties
        public string TerminalID { get { return this.terminalID; } }
        public Plane Plane { get { return this.plane; } }

        //Constructor
        public Terminal(string TerminalID, Plane plane)
        {
            this.terminalID = TerminalID;
            this.plane = plane;
        }

        //Method
        public void Start()
        {

        }

    }
}
