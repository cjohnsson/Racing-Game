using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using RaceGame;

namespace RaceGame_Tests
{
    [TestFixture]
    class Map_Test
    {
        private Map MakeMap()
        {
            return new Map(null, null,null, null,1,0,0,0f);
        }

        // StartX
        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void StartX_NegativeOutOfRange_ThrowsArgumentOutOfRangeException()
        {
            Map map = MakeMap();
            map.StartX = -100;
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void StartX_PossitiveOutOfRange_ThrowsArgumentOutOfRangeException()
        {
            Map map = MakeMap();
            map.StartX = 900;
        }

        [Test]
        public void StartX_InRangeCenter_Pass()
        {
            Map map = MakeMap();
            map.StartX = 500;
            Assert.AreEqual(500, map.StartX);
        }

        [Test]
        public void StartX_InRangeMin_Pass()
        {
            Map map = MakeMap();
            map.StartX = 0;
            Assert.AreEqual(0, map.StartX);
        }

        [Test]
        public void StartX_InRangeMax_Pass()
        {
            Map map = MakeMap();
            map.StartX = 800;
            Assert.AreEqual(800, map.StartX);
        }

        // StartY

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void StartY_NegativeOutOfRange_ThrowsArgumentOutOfRangeException()
        {
            Map map = MakeMap();
            map.StartY = -100;
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void StartY_PossitiveOutOfRange_ThrowsArgumentOutOfRangeException()
        {
            Map map = MakeMap();
            map.StartY = 900;
        }

        [Test]
        public void StartY_InRangeCenter_Pass()
        {
            Map map = MakeMap();
            map.StartY = 300;
            Assert.AreEqual(300, map.StartY);
        }

        [Test]
        public void StartY_InRangeMin_Pass()
        {
            Map map = MakeMap();
            map.StartY = 0;
            Assert.AreEqual(0, map.StartY);
        }

        [Test]
        public void StartY_InRangeMax_Pass()
        {
            Map map = MakeMap();
            map.StartY = 600;
            Assert.AreEqual(600, map.StartY);
        }

        // Laps

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Laps_NegativeOutOfRange_ThrowsArgumentOutOfRangeException()
        {
            Map map = MakeMap();
            map.Laps = 0;
        }

        [Test]
        public void Laps_InRange_Pass()
        {
            Map map = MakeMap();
            map.Laps = 1;
            Assert.AreEqual(1, map.Laps);
        }
    }
}
