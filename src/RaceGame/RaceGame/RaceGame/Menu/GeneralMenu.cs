using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RaceGame.Menu
{
    public class GeneralMenu : IGeneralMenu
    {
        private Texture2D _backgroundImage;
        private Vector2[] _menuItemPositions;
        private SpriteFont _font;
        private const int MENU_ITEM_HEIGHT = 50;
        private MenuItem[] _menuItems;
        public MenuItem SelectedMenuItem { get; private set; }
        public int NrOfPlayers { get { return _menuItems[0].GetValue(); } }
        public int NrOfBots { get { return _menuItems[1].GetValue(); } }
        public int SelectedMap { get { return _menuItems[2].GetValue(); } }
        public int NrOfLaps { get { return _menuItems[3].GetValue(); } }

        public GeneralMenu(MenuItem[] menuItems)
        {
            _menuItems = menuItems;
        }

        public GeneralMenu(Texture2D backgroundImage, SpriteFont font, MenuItem[] menuItems)
        {
            SelectedMenuItem = new MenuItem(string.Empty, new RolloverUtility(0, 0, 3));
            _menuItems = menuItems;
            _backgroundImage = backgroundImage;
            _font = font;
            _menuItemPositions = new Vector2[_menuItems.Length];
            
            int startXPosition = _backgroundImage.Bounds.Width / 2 - 75;
            int startYPosition = _backgroundImage.Bounds.Height / 2 - (MENU_ITEM_HEIGHT * _menuItems.Length) / 2;

            MakePositions(startXPosition, startYPosition);
        }

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
            SelectedMenuItem.LowerValue();
        }

        public void ScrollDown()
        {
            SelectedMenuItem.RaiseValue();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_backgroundImage, new Rectangle(0, 0, _backgroundImage.Bounds.Width, _backgroundImage.Bounds.Height), Color.White);
            spriteBatch.DrawString(_font, "Controls: \nQuit game = Escape \nStart game = Enter \nSelect a value = Up & Down \nChange selected value = Left & Right \nToggle fullscreen = F", new Vector2(5, 5), Color.White);

            for (int i = 0; i < _menuItems.Length; i++)
            {
                Color color = Color.White;

                if (i == SelectedMenuItem.GetValue())
                    color = Color.Red;

                spriteBatch.DrawString(_font, _menuItems[i].ToString(), _menuItemPositions[i], color);
            }
        }

        public void RaiseSelectedValue()
        {
            _menuItems[SelectedMenuItem.GetValue()].RaiseValue();
        }

        public void LowerSelectedValue()
        {
            _menuItems[SelectedMenuItem.GetValue()].LowerValue();
        }
    }
}
