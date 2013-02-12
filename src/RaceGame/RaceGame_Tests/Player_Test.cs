﻿using System;
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
            return new Player(null,null,new Vector2(),null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void SetName_InsertsAnEmptyString_ThrowsAnArgumentException()
        {
            Player player = MakePlayer();

            player.Name = "";
        }

        [Test]
        public void GetName_GetAValidName_ReturnsAValidName()
        {
            Player player = MakePlayer();

            player.Name = "Mattias";
            Assert.That("Mattias", Is.EqualTo(player.Name));
        }
    }
}
