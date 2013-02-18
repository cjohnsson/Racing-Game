using System;
using System.Diagnostics;
using NUnit.Framework;
using RaceGame;
using System.Threading.Tasks;



namespace RaceGame_Tests
{
    [TestFixture]
    class RaceTimer_Test
    {
        public RaceTimer CreateRaceTimer()
        {
            return new RaceTimer();
        }

        public Stopwatch CreateStopwatch()
        {
            return new Stopwatch();
        }

        [Test]
        public void GetElapsedTime_DefaultTime_ReturnsTimeSpan()
        {
            //Arrange
            var raceTimer = CreateRaceTimer();
            var expected = CreateStopwatch();

            //Act

            //Assert
            var result = raceTimer.GetElapsedTime();
            Assert.AreEqual(expected.Elapsed, result);
        }

        [Test]
        public void GetElapsedTime_WhenStart_ReturnsHigherValue()
        {
            //Arrange
            var raceTimer = CreateRaceTimer();
            var startTime = CreateStopwatch();
            
            //Act
            raceTimer.Resume();
            System.Threading.Thread.Sleep(1000);
            raceTimer.Pause();

            //Assert
            var result = raceTimer.GetElapsedTime();
            
            Assert.Greater(result, startTime.Elapsed);
        }

        [Test]
        public void GetElapsedTime_WhenPause_ReturnsSameValue()
        {
            //Arrange
            var raceTimer = CreateRaceTimer();
            
            //Act
            raceTimer.Resume();
            raceTimer.Pause();
            var result1 = raceTimer.GetElapsedTime();
            System.Threading.Thread.Sleep(1000);
            var result2 = raceTimer.GetElapsedTime();

            //Assert
            Assert.AreEqual(result1, result2);
        }

        [Test]
        public void GetElapsedTime_WhenResumeAfterPause_ReturnsHigherValue()
        {
            //Arrange
            var raceTimer = CreateRaceTimer();

            //Act
            raceTimer.Resume();
            raceTimer.Pause();
            raceTimer.Resume();
            var expectLower = raceTimer.GetElapsedTime();
            System.Threading.Thread.Sleep(1000);
            var expectHigher = raceTimer.GetElapsedTime();

            //Assert
            Assert.Greater(expectHigher, expectLower);

        }

    }

}


