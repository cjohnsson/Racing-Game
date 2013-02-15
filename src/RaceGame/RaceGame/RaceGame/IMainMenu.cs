using Microsoft.Xna.Framework.Graphics;

namespace RaceGame
{
    public interface IMainMenu
    {
        int Index { get; }
        int NrOfPlayers { get; }
        int NrOfBots { get; }
        int SelectedMap { get; }
        int NrOfLaps { get; }
        void ScrollUp();
        void ScrollDown();
        void Draw(SpriteBatch spriteBatch);
        void RaiseChosenValue();
        void LowerChosenValue();
    }
}