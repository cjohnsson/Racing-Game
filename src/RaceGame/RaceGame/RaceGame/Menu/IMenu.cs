using Microsoft.Xna.Framework.Graphics;
using RaceGame.Menu;

namespace RaceGame.Menu
{
    public interface IMenu
    {
        int NrOfPlayers { get; }
        int NrOfBots { get; }
        int SelectedMap { get; }
        int NrOfLaps { get; }
        MenuItem SelectedMenuItem { get; }
        void ScrollUp();
        void ScrollDown();
        void Draw(SpriteBatch spriteBatch);
    }
}