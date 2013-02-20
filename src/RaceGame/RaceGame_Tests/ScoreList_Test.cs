using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using RaceGame;

namespace RaceGame_Tests
{
    [TestFixture]
    public class ScoreList_Test
    {
        ScoreList list;
        
       [SetUp]
       public void OurSetup()
       {
           //list = new ScoreList();
           Score tempScore = new Score("Kalle", new TimeSpan(0,0,45));
           list.scoreArray[0] = tempScore;
       }

       public void FillArray()
        {
            Score newScore2 = new Score("Stiffe", new TimeSpan(0, 7, 10));
            Score newScore3 = new Score("Stiffe", new TimeSpan(0, 4, 10));
            Score newScore4 = new Score("Stiffe", new TimeSpan(0, 5, 10));
            Score newScore5 = new Score("Stiffe", new TimeSpan(0, 2, 10));
            Score newScore6 = new Score("Stiffe", new TimeSpan(1, 5, 10));
            //list.SaveScore(newScore2);
            //list.SaveScore(newScore3);
            //list.SaveScore(newScore4);
            //list.SaveScore(newScore5);
            //list.SaveScore(newScore6);
        }


       //[Test]
       // [ExpectedException(typeof(Exception))]
       //public void CheckScore_CheckIfTimespanisNull_IsNull()
       //{
       //    TimeSpan nullTime = new TimeSpan(null,null);
           
       //    list.CheckScore(nullTime);
           
       //    Assert.That(list.scoreArray[0], Is.GreaterThanOrEqualTo(newTime));
       //}

        [Test]
       public void CheckScore_BetterThanExisting_IsTrue()
       {
           FillArray();
           TimeSpan newTime = new TimeSpan(0, 0, 02);
           Assert.That(list.CheckScore(newTime) , Is.True);
       }

       [Test]
       public void CheckScore_WorseThanExisting_IsFalse()
       {
           FillArray();
           TimeSpan newTime = new TimeSpan(17, 0, 02);
           
           Assert.That(list.CheckScore(newTime), Is.False);
       }

    
       #region SaveScore
       [Test]
       public void SaveScore_AddScore_ScoreIsAdded()
       {
           Score newScore = new Score("Nisse", new TimeSpan(0, 1, 10));
           //list.SaveScore(newScore);
           Assert.That(list.scoreArray, Has.Member(newScore));
       }

       [Test]
       public void SaveScore_AddFasterScore_FasterScoreIsAddedFirst()
       {
           Score newScore2 = new Score("Olle", new TimeSpan(0, 0, 10));
           //list.SaveScore(newScore2);
           Assert.That(list.scoreArray[0].Time,  Is.EqualTo(newScore2.Time));

       }

      
       #endregion
    }
}
