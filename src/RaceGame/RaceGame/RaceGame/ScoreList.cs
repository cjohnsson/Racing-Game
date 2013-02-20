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
            _time = newTime;
            if (CheckScore(_time)) {
                SaveScore();
            }
        }

        public void SaveScore()
        {
            int tempIndex = _index;
            TextTyper textTyper = new TextTyper();
            string name = textTyper.GetText();
            Score score = new Score(name, _time);

            for (int i = tempIndex; i < scoreArray.Length - 1; i++)
            {
                Score temp = scoreArray[tempIndex];
                if (tempIndex < scoreArray.Length-1)
                {
                    scoreArray[tempIndex] = scoreArray[_index + 1];
                }
                scoreArray[tempIndex + 1] = temp;
            }
            scoreArray[_index] = score;
        }

        public bool CheckScore(TimeSpan time)
        {
            for (int i = 0; i < scoreArray.Length-1; i++)
                {
                    if (time <= scoreArray[i].Time || scoreArray[i] == null)
                    {
                        _index = i;
                        return true;
                    }
                }
            return false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }
    }
}
