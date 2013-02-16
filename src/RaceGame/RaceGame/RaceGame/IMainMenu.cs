using Microsoft.Xna.Framework.Graphics;

namespace RaceGame
{
    public interface IMainMenu
    {
        int SelectedMenuItem { get; }
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