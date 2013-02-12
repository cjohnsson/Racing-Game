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
            get { return Position; }
        }

        bool checkPoint;
        float speed;
        float rotation;
        Vector2 origin;

        float x;
        float y;
        int height;
        int width;

        const float ACCELERATION = 0.1f;
        const float DECELERATION = 0.1f;
        const float BREAK_DECELERATION = 0.1f;

        void Accelerate()
        {

        }

        void Break()
        {

        }

        void TurnLeft()
        {
            if(Keyboard.GetState().IsKeyDown(Keys.Left)
                

        }

        void TurnRight()
        {

        }

        void Update()
        {

        }

        //TerrainType GetTerrain()
        //{ 
        //    return null;
        //}

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