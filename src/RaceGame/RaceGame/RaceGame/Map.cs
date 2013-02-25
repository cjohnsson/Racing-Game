using System;
using RaceGame.Holders;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Microsoft.Xna.Framework.Graphics;
using Color = Microsoft.Xna.Framework.Color;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace RaceGame
{
    //TODO: Tester ska göras
    public class Map : IMap
    {
        private int _startX;
        private int _startY;
        private int _laps;
        private Clouds clouds;
        public float StartRotation { get; set; }
        public Texture2D BackgroundImage { get; set; }
        public Texture2D ForegroundImage { get; set; }
        public Bitmap CollisionImage { get; set; }

        public Map(Texture2D backgroundImage, Texture2D foregroundImage, Bitmap collisionImage, ITexture2DHolder cloudImage, int startX, int startY, float startRotation)
        {
            BackgroundImage = backgroundImage;
            ForegroundImage = foregroundImage;
            CollisionImage = collisionImage;
            clouds = new Clouds(cloudImage.GetTexture2D());
            StartX = startX;
            StartY = startY;
            StartRotation = startRotation;
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

        public void Update()
        {
            clouds.Update();
        }

        public void DrawForeground(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(ForegroundImage, new Rectangle(0, 0, ForegroundImage.Bounds.Width, ForegroundImage.Bounds.Height), Color.White);
            clouds.Draw(spriteBatch);
        }

        public void DrawBackground(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(BackgroundImage, new Rectangle(0, 0, BackgroundImage.Bounds.Width, BackgroundImage.Bounds.Height), Color.White);
        }
    }
}