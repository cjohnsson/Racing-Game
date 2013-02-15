using System.Drawing;
using Microsoft.Xna.Framework.Graphics;

namespace RaceGame
{
    public interface IMap
    {
        float StartRotation { get; set; }
        Texture2D BackgroundImage { get; set; }
        Texture2D ForegroundImage { get; set; }
        Bitmap CollisionImage { get; set; }
        int StartX { get; set; }
        int StartY { get; set; }
        int Laps { get; set; }
        void Update();
        void DrawForeground(SpriteBatch spriteBatch);
        void DrawBackground(SpriteBatch spriteBatch);
    }
}