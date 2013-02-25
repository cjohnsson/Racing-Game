using System;
using System.Diagnostics;
using NUnit.Framework;
using RaceGame;
using System.Threading;



namespace RaceGame_Tests
{
    [TestFixture]
    class RaceTimer_Test
    {
        public RaceTimer CreateRaceTimer()
        {
            return new RaceTimer();
        }


        [Test]
        public void GetElapsedTime_DefaultTime_ReturnsTimeSpan()
        {
            //Arrange
            var raceTimer = CreateRaceTimer();

            //Act

            //Assert
            var result = raceTimer.GetElapsedTime();
            Assert.AreEqual(TimeSpan.FromSeconds(-3), result);
        }

        [Test]
        public void GetElapsedTime_WhenStart_ReturnsHigherValue()
        {
            //Arrange
            var raceTimer = CreateRaceTimer();
            
            //Act
            raceTimer.Resume();
            Thread.Sleep(1000);
            raceTimer.Pause();

            //Assert
            var result = raceTimer.GetElapsedTime();
            Assert.Greater(result.Seconds, TimeSpan.FromSeconds(-2).Seconds );
        }

        [Test]
        public void GetElapsedTime_WhenPause_ReturnsSameValue()
        {
            //Arrange
            var raceTimer = CreateRaceTimer();
            
            //Act
            raceTimer.Resume();
            raceTimer.Pause();
            var resumeBeforePause = raceTimer.GetElapsedTime();
            Thread.Sleep(500);
            var resultAfterResume = raceTimer.GetElapsedTime();

            //Assert
            Assert.AreEqual(resumeBeforePause, resultAfterResume);
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
            Thread.Sleep(500);
            var expectHigher = raceTimer.GetElapsedTime();

            //Assert
            Assert.Greater(expectHigher, expectLower);
        }

    }

}


