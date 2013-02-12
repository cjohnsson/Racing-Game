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
    class Car
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

        const float MAXSPEED = 1.5f;
        const float ACCELERATION = 0.1f;
        const float DECELERATION = 0.1f;
        const float BREAK_DECELERATION = 0.1f;

        void Accelerate()
        {
            if (speed < MAXSPEED)
                speed += ACCELERATION;

            if (speed > MAXSPEED)
                speed = MAXSPEED;
 
        }

        void Break()
        {
            if (speed <= 0)
                speed = 0;
            else
                speed -= BREAK_DECELERATION;
        }

        void TurnLeft()
        {             

        }

        void TurnRight()
        {

        }

        void Update()
        {

        }

        TerrainTypes GetTerrain()
        {
            return null;
        }

        void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, position, Color.White);
        }

        Vector2 GetOrigin()
        {
            return new Vector2(1, 2);
        }
    }
}