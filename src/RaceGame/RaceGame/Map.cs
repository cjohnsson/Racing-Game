using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Microsoft.Xna.Framework.Graphics;

namespace RaceGame
{
    public class Map
    {
        public int StartX 
        {
            get; 
            set 
            {
                if (value >= 0)
                    StartX = value;
                else
                    throw new ArgumentOutOfRangeException("Negative coordinates!");
            } 
        }
        public int StartY 
        {
            get;
            set 
            {
                if (value >= 0)
                    StartY = value;
                else
                    throw new ArgumentOutOfRangeException("Negative coordinates!");
            }
        }

        public int Laps 
        {
            get;
            set 
            {
                if (value >= 0)
                    Laps = value;
                else
                    throw new ArgumentOutOfRangeException("Negative lap number!");
            }
        }

        public float StartRotation { get; set; }
        public static Bitmap CollisionImage { get; set; }
        public Texture2D BackgroundImage { get; set; }
        public Texture2D ForegroundImage { get; set; }

        public void Draw(SpriteBatch spriteBatch) 
        {
            //spriteBatch.Draw();
        }
    }
}