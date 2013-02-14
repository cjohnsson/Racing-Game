using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RaceGame
{
    public class Car : ICar
    {
        private Texture2D image;

        public Car()
        {

        }

        public Car(Texture2D newImage, Vector2 position)
        {
            image = newImage;
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

        private float _speed;
        private float _rotation;
        public float Speed { get { return _speed; } }
        public float Rotation { get { return _rotation; } }

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
            if (_speed < MAXSPEED)
                _speed += ACCELERATION;

            if (_speed > MAXSPEED)
                _speed = MAXSPEED;

        }

        private void Decelerate()
        {
            if (_speed <= 0)
                _speed = 0;
            else
                _speed -= DECELERATION;
        }

        public void Break()
        {
            if (_speed <= 0)
                _speed = 0;
            else
                _speed -= BREAK_DECELERATION;
        }

        public void TurnLeft()
        {
            _rotation -= ROTATION_SPEED;
        }

        public void TurnRight()
        {
            _rotation += ROTATION_SPEED;
        }

        public void Update()
        {
            //inte 100% här om detta är korrekt - Svar: Det är korrekt nu :) svar till stoffe: Nej det var inte korrekt, vi ändrade din ändring
            float newX = x + (float)Math.Cos((double)_rotation) * _speed;
            float newY = y + (float)Math.Sin((double)_rotation) * _speed;

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
                    if (passedCheckPoint)
                    {
                        passedFinishLine = true;
                    }
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
                    _speed = TERRAIN_SPEED;
                    break;
                default:
                    break;
            }
            Decelerate();
        }

        private TerrainTypes GetTerrain()
        {
            return GetTerrain(GetOrigin());
        }

        private TerrainTypes GetTerrain(Vector2 position)
        {
            //kollar så att inte bilens mitt inte är utanför vänster/höger/up/ner kanten
            if (position.X >= World.CollisionImage.Width || position.Y >= World.CollisionImage.Height || position.X <= 0 || position.Y <= 0)
               return TerrainTypes.Obstacle;

            System.Drawing.Color color = World.CollisionImage.GetPixel((int)position.X, (int)position.Y);

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
            spriteBatch.Draw(image, Position, null, Color.White, _rotation, new Vector2(width / 2, height / 2), SpriteEffects.None, 0);
        }

        private Vector2 GetOrigin()
        {
            return new Vector2((x + Position.X / 2), (y + Position.Y / 2));
        }
    }
}