using Microsoft.Xna.Framework.Graphics;

namespace RaceGame
{
    public interface IPlayer
    {
        Car Car { get; set; }
        int Lap { get; set; }
        Control Control { get; set; }
        void Draw(SpriteBatch spriteBatch);
        void Update();
    }
}