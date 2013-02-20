using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RaceGame.Menu
{
    public abstract class Menu : IMenu
    {
        private Texture2D _backgroundImage;
        private Vector2[] _menuItemPositions;
        private SpriteFont _font;
        private const int MENU_ITEM_HEIGHT = 50;
        protected MenuItem[] MenuItems;
        protected RolloverUtility RolloverUtility;
        protected string Description = string.Empty;
        public MenuItem SelectedMenuItem { get { return MenuItems[RolloverUtility.Value]; } }
        public int NrOfPlayers { get { return MenuItems[0].GetValue(); } }
        public int NrOfBots { get { return MenuItems[1].GetValue(); } }
        public int SelectedMap { get { return MenuItems[2].GetValue(); } }
        public int NrOfLaps { get { return MenuItems[3].GetValue(); } }

        protected Menu()
        {
            Initilize();
        }

        protected Menu(Texture2D backgroundImage, SpriteFont font)
        {
            Initilize();
            _backgroundImage = backgroundImage;
            _font = font;

            _menuItemPositions = new Vector2[MenuItems.Length];
            int startXPosition = _backgroundImage.Bounds.Width / 2 - 75;
            int startYPosition = _backgroundImage.Bounds.Height / 2 - (MENU_ITEM_HEIGHT * MenuItems.Length) / 2;
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
            spriteBatch.DrawString(_font, Description, new Vector2(5, 5), Color.White);

            for (int i = 0; i < MenuItems.Length; i++)
            {
                Color color = Color.White;

                if (i == RolloverUtility.Value)
                    color = Color.Red;

                spriteBatch.DrawString(_font, MenuItems[i].ToString(), _menuItemPositions[i], color);
            }
        }
    }
}
