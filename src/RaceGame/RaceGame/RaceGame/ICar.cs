using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RaceGame
{
    public interface ICar
    {
        Rectangle Position { get; }
        bool HasFinishedLap { get; }
        float Speed { get; }
        float Rotation { get; set; }
        float X { get; set; }
        float Y { get; set; }
        void Accelerate();
        void Break();
        void TurnLeft();
        void TurnRight();
        void Update();
        TerrainTypes GetTerrain(Vector2 position);
        void Draw(SpriteBatch spriteBatch);
    }
}