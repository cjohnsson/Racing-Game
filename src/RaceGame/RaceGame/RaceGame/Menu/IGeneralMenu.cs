using Microsoft.Xna.Framework.Graphics;
using RaceGame.Menu;

namespace RaceGame.Menu
{
    public interface IGeneralMenu
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