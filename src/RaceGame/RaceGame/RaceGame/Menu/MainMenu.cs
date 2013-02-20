using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace RaceGame.Menu
{
    public class MainMenu: Menu
    {
        public MainMenu()
        {
            
        }

        public MainMenu(Texture2D backgroundImage, SpriteFont font) : base(backgroundImage, font)
        {
        }

        protected override void Initilize()
        {
            RolloverUtility = new RolloverUtility(0, 0, 3);
            MenuItems = new MenuItem[4];
            MenuItems[0] = new MenuItem("Number of players: {0}", new RolloverUtility(1, 1, 2));
            MenuItems[1] = new MenuItem("Number of bots: {0}", new RolloverUtility(2, 0, 2));
            MenuItems[2] = new MenuItem("Selected map: {0}", new RolloverUtility(0, 0, 4));
            MenuItems[3] = new MenuItem("Number of laps: {0}", new RolloverUtility(1, 1, 9));   
        }
    }
}
