using NUnit.Framework;
using RaceGame;
using RaceGame_Tests.Holders;
using Microsoft.Xna.Framework;

namespace RaceGame_Tests
{
    [TestFixture]
    public class Car_Test
    {
        private const float MAXSPEED = 1.5f;

        private Car CreateCar()
        {
            var text2D = new StubTexture2DHolder();
            return new Car(text2D, new Vector2(0, 0));
        }

        #region Acclerate_Method_Tests

        [Test]
        public void Accelerate_IncreaseSpeed_SpeedIncreases()
        {
            var car = CreateCar();
            Assert.That(car.Speed, Is.LessThanOrEqualTo(MAXSPEED));
        }

        [Test]
        public void Accelerate_SpeedAcceleration_AllowToAccelerate()
        {
            var car = CreateCar();
            var currentSpeed = car.Speed;
            car.Accelerate();
            var newSpeed = car.Speed;
            Assert.That(newSpeed, Is.InRange(currentSpeed, MAXSPEED));
        }

        #endregion

        #region Break_Methods_Test

        [Test]
        public void Break_AllowBreak_BreakAllowed()
        {
            var car = CreateCar();
            var currentBreakSpeed = car.Speed;
            car.Break();
            var speedAfterBreak = car.Speed;


            if (currentBreakSpeed == 0)
            {
                Assert.That(currentBreakSpeed, Is.LessThanOrEqualTo(currentBreakSpeed));
            }
            else
                Assert.That(speedAfterBreak, Is.LessThan(currentBreakSpeed));
        }

        [Test]
        public void Break_NotNegativValueAndStoped_CarStoped()
        {
            var car = CreateCar();
            var newSpeedAfterBreak = car.Speed;
            car.Break();

            Assert.That(newSpeedAfterBreak, Is.Not.Negative.Or.GreaterThan(0));
        }

        #endregion

        #region NullPointer_Tests_Car_Methods

        [Test]
        public void CheckCarSpeed_IsNotNull_CarSpeedHasValue()
        {
            var car = CreateCar();

            Assert.That(car.Speed, !Is.Null);
        }

        [Test]
        public void CheckRotation_IsNotNull_RotationHasValue()
        {
            var car = CreateCar();

            Assert.That(car.Rotation, !Is.Null);
        }

        #endregion

        #region TurnLeft&Right_Methods_Test

        [Test]
        public void TurnLeft_RotationDeceses_CarTurnsLeft()
        {

            var car = CreateCar();
            float currentPosition = car.Rotation;
            car.TurnLeft();
            float newPosition = car.Rotation;

            Assert.That(newPosition, Is.LessThan(currentPosition));
        }

        [Test]
        public void TurnRight_RotationIncreases_CarTurnRight()
        {
            var car = CreateCar();
            float currentPosition = car.Rotation;
            car.TurnRight();
            float newPosition = car.Rotation;

            Assert.That(newPosition, Is.GreaterThan(currentPosition));
        }

        #endregion
    }
}
