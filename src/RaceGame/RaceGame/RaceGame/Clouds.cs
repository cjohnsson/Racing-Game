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
        int height, width;
        private float[] x = new float[4];
        private float[] y = new float[4];

        public Clouds(Texture2D image)
        {
            this.image = image;
            height = image.Bounds.Height;
            width = image.Bounds.Width;
            X[0] = 0;
            Y[0] = 0;
            X[1] = width;
            Y[1] = -height;
            X[2] = 0;
            Y[2] = -height;
            X[3] = width;
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

        public void Update()
        {

            UpdatePostitionFirstPicture();

            if (X[1] + width < 0 && Y[1] > height)
            {
                X[1] = width;
                Y[1] = -height;
            }

            if (X[2] + width < 0)
            {
                X[2] = 0;
                Y[2] = -height;
            }

            if (Y[3] > height)
            {
                X[3] = width;
                Y[3] = 0;
            }

            for (int i = 0; i < X.Length; i++)
            {
                X[i] -= XSPEED;
                Y[i] += YSPEED;
            } 
        }

        private void UpdatePostitionFirstPicture()
        {
            if (X[0] + width < 0 && Y[0] > height)
            {
                X[0] = width;
                Y[0] = -height;
            }
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, new Rectangle((int)X[0], (int)Y[0], width, height), Color.White);
            spriteBatch.Draw(image, new Rectangle((int)X[1], (int)Y[1], width, height), Color.White);
            spriteBatch.Draw(image, new Rectangle((int)X[2], (int)Y[2], width, height), Color.White);
            spriteBatch.Draw(image, new Rectangle((int)X[3], (int)Y[3], width, height), Color.White);
        }

    }
}
