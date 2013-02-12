using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Microsoft.Xna.Framework.Graphics;

namespace RaceGame
{
    class Map
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

        public float StartRotation 
        {
            get;
            set 
            {
                if (value >= 0.00F && value < 360.00F)
                    StartRotation = value;
                else
                    throw new ArgumentOutOfRangeException("Angle out of range!");
            } 
        }
        public static Bitmap CollisionImage { get; set; }
        public Texture2D BackgroundImage { get; set; }

        public void Draw(SpriteBatch spriteBatch) 
        {
            //spriteBatch.Draw();
        }
    }
}