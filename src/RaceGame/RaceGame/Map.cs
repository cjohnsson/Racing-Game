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
        private int _startX;
        private int _startY;
        private int _laps;

        public int StartX 
        {
            get { return _startX; } 
            set 
            {
                if (value >= 0 && value <= 800)
                    _startX = value;
                else
                    throw new ArgumentOutOfRangeException("Negative coordinates!");
            } 
        }
        public int StartY 
        {
            get { return _startY; }
            set 
            {
                if (value >= 0 && value <= 600)
                    _startY = value;
                else
                    throw new ArgumentOutOfRangeException("Negative coordinates!");
            }
        }

        public int Laps 
        {
            get { return _laps; }
            set 
            {
                if (value >= 0)
                    _laps = value;
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