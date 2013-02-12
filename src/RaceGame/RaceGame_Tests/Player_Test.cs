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
        [ExpectedException(typeof(ArgumentException))]
        public void SetName_InsertsAnEmptyString_ThrowsAnArgumentException()
        {
            Control control = new Control();
            Player player = new Player(control);

            player.Name = "";
        }

        [Test]
        public void GetName_GetAValidName_ReturnsAValidName()
        {
            Control control = new Control();
            Player player = new Player(control);

            player.Name = "Mattias";
            Assert.That("Mattias", Is.EqualTo(player.Name));
        }
    }
}
