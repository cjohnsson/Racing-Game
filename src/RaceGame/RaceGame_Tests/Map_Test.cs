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
        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void StartX_NegativeOutOfRange_ThrowsException() 
        {

        }
    }
}
