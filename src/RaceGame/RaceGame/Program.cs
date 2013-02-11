#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
#endregion

namespace RaceGame
{
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        private static RaceGame game;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            game = new RaceGame();
            game.Run();
        }
    }
}
