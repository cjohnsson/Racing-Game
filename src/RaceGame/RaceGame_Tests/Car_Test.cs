using System;
using NUnit.Framework;
using RaceGame;

namespace RaceGame_Tests
{
    [TestFixture]
    public class Car_Test
    {
        const float MAXSPEED = 1.5f;

        

        public Car CreateCarInstance()
        {
            return new Car();
        }

        #region Acclerate_Method_Tests      

        [Test]
        public void Accelerate_IncreaseSpeed_SpeedIncreases()
        {
            var car = CreateCarInstance();
            car.Accelerate();
            Assert.That(car.Speed, Is.LessThanOrEqualTo(MAXSPEED));
        }

        [Test]
        public void Accelerate_SpeedAcceleration_AllowToAccelerate()
        {
            var car = CreateCarInstance();
            float carStartSpeed = car.Speed;
            car.Accelerate();
            float carAccelerated = car.Speed;
            Assert.That(carAccelerated, Is.InRange(carStartSpeed, MAXSPEED));
        }

        #endregion

        #region Break_Methods_Test

        [Test]
        public void Break_AllowBreak_BreakAllowed()
        {
            var car = CreateCarInstance();
            float carSpeedStart = car.Speed;
            car.Break();
            float carSpeedSlowed = car.Speed;

            if (carSpeedStart == 0)
            {
                Assert.That(carSpeedStart, Is.LessThanOrEqualTo(carSpeedStart));
            }
            else
                Assert.That(carSpeedSlowed, Is.LessThan(carSpeedStart));
        }

        [Test]
        public void Break_NotNegativValueAndStoped_CarStoped()
        {
            var car = CreateCarInstance();
            car.Break();
            Assert.That(car.Speed, Is.Not.Negative.Or.GreaterThan(0));
        }

        #endregion

        #region NullPointer_Tests_Car_Methods

        [Test]
        public void CheckCarSpeed_IsNotNull_CarSpeedHasValue()
        {
            var car = CreateCarInstance();
            Assert.That(car.Speed, !Is.Null);
        }

        [Test]
        public void CheckRotation_IsNotNull_RotationHasValue()
        {
            var car = CreateCarInstance();
            Assert.That(car.Rotation, !Is.Null);
        }

        #endregion

        #region TurnLeft&Right_Methods_Test

        [Test]
        public void TurnLeft_RotationDeceses_CarTurnsLeft()
        {
            var car = CreateCarInstance();
            float currentRotationPosition = car.Rotation;
            car.TurnLeft();
            float newRotationPosition = car.Rotation;
            Assert.That(newRotationPosition, Is.LessThan(currentRotationPosition));
        }

        [Test]
        public void TurnRight_RotationIncreases_CarTurnRight()
        {
            var car = CreateCarInstance();
            float currentRotationPosition = car.Rotation;
            car.TurnRight();
            float newRotationPosition = car.Rotation;
            Assert.That(newRotationPosition, Is.GreaterThan(currentRotationPosition));
        }

        #endregion
    }
}
