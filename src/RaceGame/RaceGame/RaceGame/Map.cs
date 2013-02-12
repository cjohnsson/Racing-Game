using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Microsoft.Xna.Framework.Graphics;
using Color = Microsoft.Xna.Framework.Color;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace RaceGame
{
    public class Map
    {
        private int _startX;
        private int _startY;
        private int _laps;

        public float StartRotation { get; set; }
        public Texture2D BackgroundImage { get; set; }
        public Texture2D ForegroundImage { get; set; }

        public Map(Texture2D backgroundImage, Texture2D foregroundImage)
        {
            BackgroundImage = backgroundImage;
            ForegroundImage = foregroundImage;
        }

        public int StartX
        {
            get { return _startX; }
            set
            {
                if (value >= 0 && value <= 800)
                    _startX = value;
                else
                    throw new ArgumentOutOfRangeException("Invalid coordinates!");
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
                    throw new ArgumentOutOfRangeException("Invalid coordinates!");
            }
        }

        public int Laps
        {
            get { return _laps; }
            set
            {
                if (value > 0)
                    _laps = value;
                else
                    throw new ArgumentOutOfRangeException("Invalid lap number!");
            }
        }

        public void DrawForeground(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(ForegroundImage, new Rectangle(0, 0, ForegroundImage.Bounds.Width, ForegroundImage.Bounds.Height), Color.White);
        }

        public void DrawBackground(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(BackgroundImage, new Rectangle(0, 0, BackgroundImage.Bounds.Width, BackgroundImage.Bounds.Height), Color.White);
        }
    }
}