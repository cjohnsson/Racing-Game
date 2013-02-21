using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace RaceGame
{
    public class Clouds : IClouds
    {
        const float XSPEED = 0.1f;
        const float YSPEED = 0.075f;
        Texture2D image;
        private int height;
        private int width;
        private float[] x = new float[4];
        private float[] y = new float[4];

        public Clouds()
        {}

        public Clouds(Texture2D image)
        {
            this.image = image;
            Height = image.Bounds.Height;
            Width = image.Bounds.Width;
            X[0] = 0;
            Y[0] = 0;
            X[1] = Width;
            Y[1] = -Height;
            X[2] = 0;
            Y[2] = -Height;
            X[3] = Width;
            Y[3] = 0;
        }

        public float[] X
        {
            get { return x; }
            set { x = value; }
        }

        public float[] Y
        {
            get { return y; }
            set { y = value; }
        }

        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        public void Update()
        {

            UpdatePostitionFirstPicture();

            UpdatePositionSecondPicture();

            UpdatePositionThirdPicture();

            UpdatePositionFourthPicture();

            SetSpeed(); 
        }

        private void SetSpeed()
        {
            for (int i = 0; i < X.Length; i++)
            {
                X[i] -= XSPEED;
                Y[i] += YSPEED;
            }
        }

        private void UpdatePositionFourthPicture()
        {
            if (Y[3] > Height)
            {
                X[3] = Width;
                Y[3] = 0;
            }
        }

        private void UpdatePositionThirdPicture()
        {
            if (X[2] + Width < 0)
            {
                X[2] = 0;
                Y[2] = -Height;
            }
        }

        private void UpdatePositionSecondPicture()
        {
            if (X[1] + Width < 0 && Y[1] > Height)
            {
                X[1] = Width;
                Y[1] = -Height;
            }
        }

        private void UpdatePostitionFirstPicture()
        {
            if (X[0] + Width < 0 && Y[0] > Height)
            {                
                X[0] = Width;
                Y[0] = -Height;
            }
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, new Rectangle((int)X[0], (int)Y[0], Width, Height), Color.White);
            spriteBatch.Draw(image, new Rectangle((int)X[1], (int)Y[1], Width, Height), Color.White);
            spriteBatch.Draw(image, new Rectangle((int)X[2], (int)Y[2], Width, Height), Color.White);
            spriteBatch.Draw(image, new Rectangle((int)X[3], (int)Y[3], Width, Height), Color.White);
        }

    }
}
