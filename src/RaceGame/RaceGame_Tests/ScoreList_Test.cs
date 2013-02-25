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
        ScoreList list = new ScoreList();
        
       public void FillArray()
        {
            Score newScore2 = new Score("Stiffe", new TimeSpan(0, 0, 1, 10));
            Score newScore3 = new Score("Stiffe", new TimeSpan(0, 0, 2, 10));
            Score newScore4 = new Score("Stiffe", new TimeSpan(0, 0, 3, 10));
            Score newScore5 = new Score("Stiffe", new TimeSpan(0, 0, 5, 10));
            Score newScore6 = new Score("Stiffe", new TimeSpan(0, 0, 6, 10));
            list.scoreArray[0] = (newScore2);
            list.scoreArray[1] = (newScore3);
            list.scoreArray[2] = (newScore4);
            list.scoreArray[3] = (newScore5);
            list.scoreArray[4] = (newScore6);
        }


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

        [Test]
        public void CheckScore_CheckScoreInEmptyList_ReturnIndex0()
        {
            TimeSpan time = new TimeSpan(0,0,2,0);
            Assert.That(list.CheckScore(time), Is.EqualTo(0));
        }

        [Test]
        public void CheckScore_CheckScoreInFullList_ReturnIndexNegativeOne() {
            TimeSpan time = new TimeSpan(1, 4, 2, 0);
            FillArray();
            Assert.That(list.CheckScore(time), Is.EqualTo(-1));
        }

        [Test]
        public void CheckScore_CheckMiddleScoreInFullList_ReturnIndex3() {
            TimeSpan time = new TimeSpan(0, 0, 4, 0);
            FillArray();
            Assert.That(list.CheckScore(time), Is.EqualTo(3));
        }

        [Test]
        public void Insert_InsertToNewBestTime_MoveToFirstPlaceInArray() {
            FillArray();
            TimeSpan time = new TimeSpan(0, 0, 0, 1);
            Score score = new Score("Mattias", time);
            list.Ïnsert(score, 0);
            Assert.That(list.scoreArray[0].Name, Is.EqualTo(score.Name));
        }

        [Test]
        public void Insert_InsertToMiddleTime_MoveToMidPlaceInArray() {
            FillArray();
            TimeSpan time = new TimeSpan(0, 0, 4, 10);
            Score score = new Score("Magnus", time);
            list.Ïnsert(score, 3);
            Assert.That(list.scoreArray[3].Name, Is.EqualTo(score.Name));
        }

        [Test]
        public void Insert_InsertToLastTime_MoveToLastPlaceInArray() {
            FillArray();
            TimeSpan time = new TimeSpan(0, 0, 5, 50);
            Score score = new Score("Fidde", time);
            list.Ïnsert(score, 4);
            Assert.That(list.scoreArray[4].Name, Is.EqualTo(score.Name));
        }
    }
}
