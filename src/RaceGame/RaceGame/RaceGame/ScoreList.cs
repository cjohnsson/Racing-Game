using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace RaceGame
{
    [Serializable]
    public class ScoreList
    {
        public Score[] scoreArray = new Score[5];
        private static int _index;
        private static TimeSpan _time;

        public ScoreList()
        {

        }

        public void SetScore(TimeSpan newTime)
        {

            throw new NotImplementedException();

            //_time = newTime;
            //if (CheckScore(_time)) {
            //    SaveScore();
            //}
        }

        public void SaveScore()
        {

            throw new NotImplementedException();

        //    int tempIndex = _index;
        //    string name = TextTyper.GetText();
        //    Score score = new Score(name, _time);

        //    for (int i = tempIndex; i < scoreArray.Length - 1; i++)
        //    {
        //        Score temp = scoreArray[tempIndex];
        //        if (tempIndex < scoreArray.Length-1)
        //        {
        //            scoreArray[tempIndex] = scoreArray[_index + 1];
        //        }
        //        scoreArray[tempIndex + 1] = temp;
        //    }
        //    scoreArray[_index] = score;
        }

        public void Ïnsert(Score score, int index)
        {
            Score tempScore = scoreArray[index];
            scoreArray[index] = score;
            for (int i = index + 1; i < scoreArray.Length - 1; i++)
            {
                scoreArray[i] = tempScore;
                if (i < scoreArray.Length - 1)
                {
                    tempScore = scoreArray[i + 1];
                }
            }
        }

        public int CheckScore(TimeSpan time)
        {
            for (int i = 0; i < scoreArray.Length - 1; i++) {
                if (scoreArray[i] == null || time <= scoreArray[i].Time) {
                        return i;
                }
            }
            return -1;
        }
    }
}
