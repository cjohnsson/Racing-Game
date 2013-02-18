using Microsoft.Xna.Framework.Graphics;
using RaceGame.Menu.Main;

namespace RaceGame
{
    public interface IMainMenu
    {
        MenuItem SelectedMenuItem { get; }
        int NrOfPlayers { get; }
        int NrOfBots { get; }
        int SelectedMap { get; }
        int NrOfLaps { get; }
        void ScrollUp();
        void ScrollDown();
        void Draw(SpriteBatch spriteBatch);
        void RaiseSelectedValue();
        void LowerSelectedValue();
    }
}