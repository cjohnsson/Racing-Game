using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using NUnit.Framework;
using RaceGame;

namespace RaceGame_Tests
{
    public class Class1
    {
        [Test]
        public void Method_Scenario_Expected()
        {
            MockCar car = new MockCar();

            car.Accelerate();

            Assert.That(car.Speed,Is.GreaterThan(0));
        }
    }
}
