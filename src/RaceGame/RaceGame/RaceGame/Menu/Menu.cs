using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RaceGame.Menu
{
    public abstract class Menu : IMenu
    {
        protected Texture2D _backgroundImage;
        protected Vector2[] _menuItemPositions;
        protected SpriteFont _font;
        protected const int MENU_ITEM_HEIGHT = 50;
        protected MenuItem[] _menuItems;
        public MenuItem SelectedMenuItem { get { return _menuItems[RolloverUtility.Value]; } }
        private RolloverUtility RolloverUtility { get; set; }
        public int NrOfPlayers { get { return _menuItems[0].GetValue(); } }
        public int NrOfBots { get { return _menuItems[1].GetValue(); } }
        public int SelectedMap { get { return _menuItems[2].GetValue(); } }
        public int NrOfLaps { get { return _menuItems[3].GetValue(); } }

        protected Menu()
        {
            Initilize();
            RolloverUtility = new RolloverUtility(0, 0, 3);
        }

        protected Menu(Texture2D backgroundImage, SpriteFont font)
        {
            Initilize();
            RolloverUtility = new RolloverUtility(0, 0, 3);
            _backgroundImage = backgroundImage;
            _font = font;
            _menuItemPositions = new Vector2[_menuItems.Length];

            int startXPosition = _backgroundImage.Bounds.Width / 2 - 75;
            int startYPosition = _backgroundImage.Bounds.Height / 2 - (MENU_ITEM_HEIGHT * _menuItems.Length) / 2;

            MakePositions(startXPosition, startYPosition);
        }

        protected abstract void Initilize();

        private void MakePositions(int xPosition, int yPosition)
        {
            for (int i = 0; i < _menuItemPositions.Length; i++)
            {
                _menuItemPositions[i] = new Vector2(xPosition, yPosition);
                yPosition += MENU_ITEM_HEIGHT;
            }
        }

        public void ScrollUp()
        {
            RolloverUtility.LowerValue();
        }

        public void ScrollDown()
        {
            RolloverUtility.RaiseValue();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_backgroundImage, new Rectangle(0, 0, _backgroundImage.Bounds.Width, _backgroundImage.Bounds.Height), Color.White);
            spriteBatch.DrawString(_font, "Controls: \nQuit game = Escape \nStart game = Enter \nSelect a value = Up & Down \nChange selected value = Left & Right \nToggle fullscreen = F", new Vector2(5, 5), Color.White);

            for (int i = 0; i < _menuItems.Length; i++)
            {
                Color color = Color.White;

                if (i == RolloverUtility.Value)
                    color = Color.Red;

                spriteBatch.DrawString(_font, _menuItems[i].ToString(), _menuItemPositions[i], color);
            }
        }
    }
}
