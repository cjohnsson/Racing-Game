using System;
using Microsoft.Xna.Framework;
using Moq;
using NUnit.Framework;
using RaceGame;

namespace RaceGame_Tests
{
    [TestFixture]
    public class Car_Test
    {
        private const float MAXSPEED = 1.5f;


        #region Acclerate_Method_Tests

        [Test]
        public void Accelerate_IncreaseSpeed_SpeedIncreases()
        {
            var mock = new Mock<ICar>();
            mock.Setup(x => x.Speed).Returns(0.0f);
            ICar car = mock.Object;

            Assert.That(car.Speed, Is.LessThanOrEqualTo(MAXSPEED));
        }

        [Test]
        public void Accelerate_SpeedAcceleration_AllowToAccelerate()
        {
            float carAccelerated = 0;
            var mock = new Mock<ICar>();
            mock.Setup(x => x.Speed).Returns(0.0f);
            ICar car = mock.Object;
            float carStartSpeed = car.Speed;

            mock.Setup(x => x.Speed).Returns(0.1f);
            car = mock.Object;

            carAccelerated = carStartSpeed;
            carAccelerated += car.Speed;

            Assert.That(carAccelerated, Is.InRange(carStartSpeed, MAXSPEED));
        }

        #endregion

        #region Break_Methods_Test

        [Test]
        public void Break_AllowBreak_BreakAllowed()
        {
            float startBreak = 0;

            var mock = new Mock<ICar>();
            mock.Setup(x => x.Speed).Returns(0.0f);
            ICar car = mock.Object;
            float carSpeedStart = car.Speed;

            mock.Setup(x => x.Speed).Returns(0.1f);
            car = mock.Object;
            startBreak = carSpeedStart;
            startBreak -= car.Speed;


            if (carSpeedStart == 0)
            {
                Assert.That(carSpeedStart, Is.LessThanOrEqualTo(carSpeedStart));
            }
            else
                Assert.That(startBreak, Is.LessThan(carSpeedStart));
        }

        [Test]
        public void Break_NotNegativValueAndStoped_CarStoped()
        {
            float breaks = 0;

            var mock = new Mock<ICar>();
            mock.Setup(x => x.Speed).Returns(0.2f);
            ICar car = mock.Object;
            float startBreaks = car.Speed;

            mock.Setup(x => x.Speed).Returns(0.1f);
            car = mock.Object;

            breaks = startBreaks;
            breaks -= car.Speed;

            Assert.That(breaks, Is.Not.Negative.Or.GreaterThan(0));
        }

        #endregion

        #region NullPointer_Tests_Car_Methods

        [Test]
        public void CheckCarSpeed_IsNotNull_CarSpeedHasValue()
        {
            var mock = new Mock<ICar>();
            mock.Setup(x => x.Speed).Returns(0.0f);
            ICar car = mock.Object;

            Assert.That(car.Speed, !Is.Null);
        }

        [Test]
        public void CheckRotation_IsNotNull_RotationHasValue()
        {
            var mock = new Mock<ICar>();
            mock.Setup(x => x.Rotation).Returns(0.0f);
            ICar car = mock.Object;

            Assert.That(car.Rotation, !Is.Null);
        }

        #endregion

        #region TurnLeft&Right_Methods_Test

        [Test]
        public void TurnLeft_RotationDeceses_CarTurnsLeft()
        {
            float newRotationPosition = 0;

            var mock = new Mock<ICar>();
            mock.Setup(x => x.Rotation).Returns(0.0f);
            ICar car = mock.Object;
            float currentRotationPosition = car.Rotation;

            mock.Setup(x => x.Rotation).Returns(0.1f);
            car = mock.Object;

            newRotationPosition = currentRotationPosition;
            newRotationPosition -= car.Rotation;

            Assert.That(newRotationPosition, Is.LessThan(currentRotationPosition));
        }

        [Test]
        public void TurnRight_RotationIncreases_CarTurnRight()
        {
            float newRotationPosition = 0;

            var mock = new Mock<ICar>();
            mock.Setup(x => x.Rotation).Returns(0.0f);
            ICar car = mock.Object;
            float currentRotationPosition = car.Rotation;

            mock.Setup(x => x.Rotation).Returns(0.1f);
            car = mock.Object;

            newRotationPosition = currentRotationPosition;
            newRotationPosition += car.Rotation;

            Assert.That(newRotationPosition, Is.GreaterThan(currentRotationPosition));
        }

        #endregion
    }
}
