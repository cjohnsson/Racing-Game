using Microsoft.Xna.Framework.Graphics;

namespace RaceGame
{
    public interface IPauseMenu
    {
        int Index { get; }
        void ScrollUp();
        void ScrollDown();
        void Draw(SpriteBatch spriteBatch);
    }
}