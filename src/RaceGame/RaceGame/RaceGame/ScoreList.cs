using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace RaceGame
{
    public class ScoreList
    {
       public Score[] scoreArray = new Score[5];


        public void SaveScore(Score newScore)
        { 
            throw new NotImplementedException();
        }

        public bool CheckScore(TimeSpan newTime)
        {
            for (int i = 0; i < scoreArray.Length-1; i++)
                {
                    if (newTime <= scoreArray[i].Time)
                    {
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
