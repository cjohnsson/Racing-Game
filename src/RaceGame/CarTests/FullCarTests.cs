using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using RaceGame;


namespace CarTests
{
    // ReSharper disable InconsistentNaming

    [TestFixture]
    public class FullCarTests
    {
        private Car MakeCar1()
        {
            return new Car();
        }

        [Test]
        public void Accelerate_ForwardKeyIsPressedDown_CarMovesForward()
        {
            Car car = MakeCar1();

            float oldSpeed = car.Speed;

            car.Accelerate();

            float result = car.Speed;

            Assert.Greater(result,oldSpeed);
        }

        [Test]
        public 
    }

    // ReSharper restore InconsistentNaming
}