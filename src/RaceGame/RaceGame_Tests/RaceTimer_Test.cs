using System;
using System.Diagnostics;
using NUnit.Framework;
using RaceGame;



namespace RaceGame_Tests
{
    [TestFixture]
    class RaceTimer_Test
    {

        [Test]
        public void GetElapsedTime_DefaultTime_ReturnsTimeSpan()
        {
            //Arrange
            RaceTimer raceTimer = new RaceTimer();
            Stopwatch stopWatch = new Stopwatch();

            //Act


            //Assert
            var result = raceTimer.GetElapsedTime();
            Assert.AreEqual(stopWatch.Elapsed, result);

        }

    }

}


