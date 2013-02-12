using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;

namespace RaceGame
{
    public class Car
    {
        Texture2D image;
        private Rectangle Position;
        

        public Rectangle position
        {
            get 
            { 
                return new Rectangle((int)x, (int)y, width, height); 
            }
        }

        bool checkPoint;
        float speed;
        float rotation;
        Vector2 origin;

        float x;
        float y;
        int height;
        int width;

        const float ROTATION_SPEED = 0.1f;
        const float MAXSPEED = 1.5f;
        const float ACCELERATION = 0.1f;
        const float DECELERATION = 0.1f;
        const float BREAK_DECELERATION = 0.1f;

        public void Accelerate()
        {
            if (speed < MAXSPEED)
                speed += ACCELERATION;

            if (speed > MAXSPEED)
                speed = MAXSPEED;
 
        }

        public void Break()
        {
            if (speed <= 0)
                speed = 0;
            else
                speed -= BREAK_DECELERATION;
        }

        public void TurnLeft()
        {
            rotation -= ROTATION_SPEED;
        }

        public void TurnRight()
        {
            rotation -= ROTATION_SPEED;
        }

        public void Update()
        {

        }

        public TerrainTypes GetTerrain()
        {
           System.Drawing.Bitmap bitMap = null;

           Vector2 position = GetOrigin();
           System.Drawing.Color color = bitMap.GetPixel((int)position.X,(int)position.Y);


        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, position, Color.White);
        }

        Vector2 GetOrigin()
        {
            return new Vector2((x + position.X/2),(y+position.Y/2));
        }
    }
}