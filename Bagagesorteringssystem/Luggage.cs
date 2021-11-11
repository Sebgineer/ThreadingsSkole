using System;
using System.Collections.Generic;
using System.Text;

namespace Bagagesorteringssystem
{
    class Luggage
    {
        #region Variables
        private Terminal terminal;

        #endregion

        #region Properties
        /// <summary>
        /// Returns The Luggages Terminal object
        /// </summary>
        public Terminal Terminal { get { return this.terminal; } }
        /// <summary>
        /// Returns the Luggages Plane object
        /// </summary>
        public Plane Plane { get { return this.terminal.Plane; } }
        

        #endregion

        #region Constructor

        /// <summary>
        /// 
        /// </summary>
        public Luggage()
        {
            this.RandomLuggage();
        }

        ///
        public Luggage(Terminal terminal)
        {
            this.terminal = terminal;
        }

        #endregion

        #region Method

        /// <summary>
        /// 
        /// </summary>
        public void RandomLuggage()
        {
            Terminal terminal = null;
            Random rnd = new Random();
            bool terminalfound = false;

            if (!Manager.TerminalEmpty)
            {
                while (!terminalfound)
                {
                    terminal = Manager.Terminals[rnd.Next(0, Manager.Terminals.Length)];
                    if (terminal != null)
                    {
                        terminalfound = true;
                    }
                }
            }

            this.terminal = terminal;
        }

        #endregion

    }
}
