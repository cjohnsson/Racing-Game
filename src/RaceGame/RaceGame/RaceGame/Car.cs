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
        private Texture2D _image;
        private bool _passedCheckPoint = false;
        private bool _passedFinishLine = false;
        private float _speed;
        private float _rotation;
        private float _x;
        private float _y;
        private int _height;
        private int _width;
        private const float ROTATION_SPEED = 0.1f;
        private const float MAXSPEED = 1.5f;
        private const float ACCELERATION = 0.1f;
        private const float DECELERATION = 0.01f;
        private const float BREAK_DECELERATION = 0.1f;
        private const float TERRAIN_SPEED = 0.01f;

        public Car(Texture2D newImage, Vector2 position)
        {
            _image = newImage;
            _width = newImage.Bounds.Width;
            _height = newImage.Bounds.Height;
            _x = position.X;
            _y = position.Y;
        }

        public Rectangle Position
        {
            get
            {
                return new Rectangle((int)_x, (int)_y, _width, _height);
            }
        }

        public bool HasFinishedLap
        {
            get
            {
                if (_passedCheckPoint && _passedFinishLine)
                {
                    _passedCheckPoint = false;
                    _passedFinishLine = false;
                    return true;
                }
                return false;
            }
        }

        public float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        public float Rotation
        {
            get { return _rotation; }
            set { _rotation = value; }
        }

        public float X
        {
            get { return _x; }
            set { _x = value; }
        }

        public float Y
        {
            get { return _y; }
            set { _y = value; }
        }

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
            float newX = _x + (float)Math.Cos((double)_rotation) * _speed;
            float newY = _y + (float)Math.Sin((double)_rotation) * _speed;

            TerrainTypes newTerrain = GetTerrain(new Vector2(newX, newY));
            switch (newTerrain)
            {
                case TerrainTypes.CheckPoint:
                    _x = newX;
                    _y = newY;
                    _passedCheckPoint = true;
                    break;
                case TerrainTypes.FinishLine:
                    _x = newX;
                    _y = newY;
                    if (_passedCheckPoint)
                    {
                        _passedFinishLine = true;
                    }
                    break;
                case TerrainTypes.Obstacle:
                    //krock
                    break;
                case TerrainTypes.Road:
                    _x = newX;
                    _y = newY;
                    break;
                case TerrainTypes.Terrain:
                    _x = newX;
                    _y = newY;
                    _speed = TERRAIN_SPEED;
                    break;
            }
            Decelerate();
        }

        public TerrainTypes GetTerrain(Vector2 position)
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
            spriteBatch.Draw(_image, Position, null, Color.White, _rotation, new Vector2(_width / 2, _height / 2), SpriteEffects.None, 0);
        }
    }
}