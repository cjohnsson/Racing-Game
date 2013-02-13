using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace RaceGame
{
    public interface ICar
    {
        void Accelerate();
        void Break();
        void Update();
        void Draw(SpriteBatch spriteBatch);
        void TurnLeft();
        void TurnRight();
    }
}
