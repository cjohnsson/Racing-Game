using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RaceGame
{
    public class Car
    {
        Texture2D _image;

        public Car(Texture2D newImage, Vector2 position)
        {
            _image = newImage;
            width = newImage.Bounds.Width;
            height = newImage.Bounds.Height;
            x = position.X;
            y = position.Y;
        }

        public Rectangle Position
        {
            get
            {
                return new Rectangle((int)x, (int)y, width, height);
            }
        }

        public bool passedCheckPoint = false;
        public bool passedFinishLine = false;
        public bool HasFinishedLap
        {
            get
            {
                if (passedCheckPoint && passedFinishLine)
                {
                    passedCheckPoint = false;
                    passedFinishLine = false;
                    return true;
                }
                return false;
            }
        }
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
        const float DECELERATION = 0.01f;
        const float BREAK_DECELERATION = 0.1f;
        const float TERRAIN_SPEED = 0.01f;
        
        public void Accelerate()
        {
            if (speed < MAXSPEED)
                speed += ACCELERATION;

            if (speed > MAXSPEED)
                speed = MAXSPEED;

        }

        private void Decelerate()
        {
            if (speed <= 0)
                speed = 0;
            else
                speed -= DECELERATION;
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
            rotation += ROTATION_SPEED;
        }

        public void Update()
        {
            //inte 100% här om detta är korrekt - Svar: Det är korrekt nu :)
            float newX = x += (float)Math.Cos((double)rotation) * speed;
            float newY = y += (float)Math.Sin((double)rotation) * speed;

            TerrainTypes newTerrain = GetTerrain(new Vector2(newX, newY));
            switch (newTerrain)
            {
                case TerrainTypes.CheckPoint:
                    x = newX;
                    y = newY;
                    passedCheckPoint = true;
                    break;
                case TerrainTypes.FinishLine:
                    x = newX;
                    y = newY;
                    passedFinishLine = true;
                    break;
                case TerrainTypes.Obstacle:
                    //krock
                    break;
                case TerrainTypes.Road:
                    x = newX;
                    y = newY;
                    break;
                case TerrainTypes.Terrain:
                    x = newX;
                    y = newY;
                    speed = TERRAIN_SPEED;
                    break;
                default:
                    break;
            }
            Decelerate();
        }

        public TerrainTypes GetTerrain()
        {
            return GetTerrain(GetOrigin());
        }

        public TerrainTypes GetTerrain(Vector2 position)
        {
            System.Drawing.Color color = Map.CollisionImage.GetPixel((int)position.X, (int)position.Y);

            //svart
            if (color.R < 10 && color.G < 10 && color.B < 10)
                return TerrainTypes.Road;
            //vit
            if (color.R > 245 && color.G > 245 && color.B > 245)
                return TerrainTypes.Terrain;
            //röd
            if (color.R > 245 && color.G < 10 && color.B < 10)
                return TerrainTypes.CheckPoint;
            //blå
            if (color.R < 10 && color.G < 10 && color.B > 245)
                return TerrainTypes.Obstacle;
            //grön
            if (color.R < 10 && color.G > 245 && color.B < 10)
                return TerrainTypes.FinishLine;
            //alla andra färger
            return TerrainTypes.Road;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_image, Position, null, Color.White, rotation, new Vector2(width/2,height/2), SpriteEffects.None, 0 );
        }

        Vector2 GetOrigin()
        {
            return new Vector2((x + Position.X / 2), (y + Position.Y / 2));
        }
    }
}