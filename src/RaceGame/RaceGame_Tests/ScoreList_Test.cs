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
        Score tempScore = new Score("Kalle", new TimeSpan(0,0,45));


       [SetUp]
       public void OurSetup()
       {
           list.scoreArray[0] = tempScore;
       }


       [Test]
       public void SaveScore_AddScore_ScoreIsAdded()
       {
           Score newScore = new Score("Nisse", new TimeSpan(0, 1, 10));
           Assert.That(list.scoreArray[1], Is.TypeOf(typeof(Score)));
       }

       [Test]
       public void SaveScore_AddFasterScore_FasterScoreIsAddedFirst()
       {


       }

       [Test]
       public void SaveScore_TryToAddBadScore_ScoreIsNotAdded()
       {


       }
    }
}
