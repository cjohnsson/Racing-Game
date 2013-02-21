using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using NUnit.Framework;
using RaceGame;


namespace RaceGame_Tests
{
    [TestFixture]
    class Player_Test
    {
        private Player MakePlayer()
        {
            return new Player(null,null,new Vector2(), 0);
        }

    }
}
