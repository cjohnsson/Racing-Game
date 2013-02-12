using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using RaceGame;

namespace RaceGame_Tests {

    [TestFixture]
    class Player_Test {

        [Test]
        public void SetName_InsertName_CheckIfStringIsEmpty()
        {
            Control control = new Control();
            Player player = new Player(control);

            player.Name = "";
            Assert.That(player.Name, Is.StringContaining(""),"Please type a valid name!");
        }
    }
}
