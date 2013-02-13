using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using RaceGame;

namespace RaceGame_Tests
{
    class MockCar : ICar
    {
        public void Accelerate()
        {
            Speed += 0.1f;
        }

        public void Break()
        {

        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }

        public void TurnLeft()
        {

        }

        public void TurnRight()
        {

        }

        public float Speed
        {
            get;
            private set;
        }
    }
}
