using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace RaceGame
{
    public interface IWorld
    {
        Map Map { get; set; }
        List<Player> Players { get; set; }
        Player Winner { get; set; }
        void Draw(SpriteBatch spriteBatch);
        void Update();
    }
}