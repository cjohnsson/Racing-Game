using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace RaceGame
{
    public class Clouds
    {
        const float XSPEED = 0.1f;
        const float YSPEED = 0.075f;
        Texture2D image;
        int height, width;
        float[] x = new float[4];
        float[] y = new float[4];
        Random r = new Random();
        public Clouds(Texture2D image)
        {
            this.image = image;
            height = image.Bounds.Height;
            width = image.Bounds.Width;
            x[0] = 0;
            y[0] = 0;
            x[1] = width;
            y[1] = -height;
            x[2] = 0;
            y[2] = -height;
            x[3] = width;
            y[3] = 0;
        }

        public void Update()
        {

            if (x[0] + width < 0 && y[0] > 600)
            {
                x[0] = width;
                y[0] = -height;
            }

            if (x[1] + width < 0 && y[1] > 600)
            {
                x[1] = width;
                y[1] = -height;
            }

            if (x[2] + width < 0)
            {
                x[2] = 0;
                y[2] = -height;
            }

            if (y[3] > 600)
            {
                x[3] = width;
                y[3] = 0;
            }

            for (int i = 0; i < x.Length; i++)
            {
                x[i] -= XSPEED;
                y[i] += YSPEED;
            } 
        }




        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, new Rectangle((int)x[0], (int)y[0], width, height), Color.White);
            spriteBatch.Draw(image, new Rectangle((int)x[1], (int)y[1], width, height), Color.White);
            spriteBatch.Draw(image, new Rectangle((int)x[2], (int)y[2], width, height), Color.White);
            spriteBatch.Draw(image, new Rectangle((int)x[3], (int)y[3], width, height), Color.White);
        }

    }
}
