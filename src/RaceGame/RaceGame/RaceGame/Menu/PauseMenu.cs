using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace RaceGame.Menu
{
    class PauseMenu : Menu
    {
        public PauseMenu()
        {

        }

        public PauseMenu(Texture2D backgroundImage, SpriteFont font)
            : base(backgroundImage, font)
        {
        }

        protected override void Initilize()
        {
            _menuItems = new MenuItem[2];
            _menuItems[0] = new MenuItem("Continue", null);
            _menuItems[1] = new MenuItem("Main Menu", null);
        }
    }
}
