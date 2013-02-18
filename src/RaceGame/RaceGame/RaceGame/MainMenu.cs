using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RaceGame.Menu.Main;

namespace RaceGame
{
    public class MainMenu : IMainMenu
    {
        private Texture2D _backgroundImage;
        private Vector2[] _menuItemPositions;
        private SpriteFont _font;
        private int _menuItemHeight;
        private int _menuItemWidth;
        private MainMenuItem[] _mainMenuItems;
        public MainMenuItem SelectedMainMenuItem { get; private set; }
        public int NrOfPlayers { get { return _mainMenuItems[0].GetValue(); } }
        public int NrOfBots { get { return _mainMenuItems[1].GetValue(); } }
        public int SelectedMap { get { return _mainMenuItems[2].GetValue(); } }
        public int NrOfLaps { get { return _mainMenuItems[3].GetValue(); } }

        public MainMenu()
        {
            InitilizeMainMenuItems();
        }

        public MainMenu(Texture2D backgroundImage, SpriteFont font)
        {
            InitilizeMainMenuItems();

            _backgroundImage = backgroundImage;
            _font = font;
            _menuItemPositions = new Vector2[_mainMenuItems.Length];
            _menuItemHeight = 50;
            _menuItemWidth = 150;
            int xStartPosition = _backgroundImage.Bounds.Width / 2 - _menuItemWidth / 2;
            int yStartPosition = _backgroundImage.Bounds.Height / 2 - (_menuItemHeight * _mainMenuItems.Length) / 2;

            MakePositions(xStartPosition, yStartPosition);
        }

        private void InitilizeMainMenuItems()
        {
            _mainMenuItems = new MainMenuItem[5];
            _mainMenuItems[0] = new MainMenuItem("Number of players: {0}", new RolloverUtility(1, 1, 2));
            _mainMenuItems[1] = new MainMenuItem("Number of bots: {0}", new RolloverUtility(2, 0, 2));
            _mainMenuItems[2] = new MainMenuItem("Selected map: {0}", new RolloverUtility(0, 0, 3));
            _mainMenuItems[3] = new MainMenuItem("Number of laps: {0}", new RolloverUtility(1, 1, 9));
            _mainMenuItems[4] = new MainMenuItem("START THE GAME");
            SelectedMainMenuItem = new MainMenuItem(string.Empty, new RolloverUtility(0,0,4));
        }

        private void MakePositions(int xPosition, int yPosition)
        {
            for (int i = 0; i < _menuItemPositions.Length; i++)
            {
                _menuItemPositions[i] = new Vector2(xPosition, yPosition);
                yPosition += _menuItemHeight;
            }
        }

        public void ScrollUp()
        {
            SelectedMainMenuItem.LowerValue();
        }

        public void ScrollDown()
        {
            SelectedMainMenuItem.RaiseValue();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_backgroundImage, new Rectangle(0, 0, _backgroundImage.Bounds.Width, _backgroundImage.Bounds.Height), Color.White);

            for (int i = 0; i < _mainMenuItems.Length; i++)
            {
                Color color = Color.White;

                if (i == SelectedMainMenuItem.GetValue())
                    color = Color.Red;

                spriteBatch.DrawString(_font, _mainMenuItems[i].ToString(), _menuItemPositions[i], color);
            }
        }

        public void RaiseSelectedValue()
        {
            _mainMenuItems[SelectedMainMenuItem.GetValue()].RaiseValue();
        }

        public void LowerSelectedValue()
        {
            _mainMenuItems[SelectedMainMenuItem.GetValue()].LowerValue();
        }
    }
}
