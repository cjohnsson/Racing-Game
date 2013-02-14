using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RaceGame
{
    public class Menu
    {
        private Texture2D _backgroundImage;
        private const int NUMBER_OF_BUTTONS = 3;
        private int BUTTON_HEIGHT;
        private int BUTTON_WIDTH;
        private Rectangle[] button_rectangles = new Rectangle[NUMBER_OF_BUTTONS];
        private Texture2D[] button_textures = new Texture2D[NUMBER_OF_BUTTONS];

        public Menu(Texture2D backgroundImage, Texture2D startButtonImage, Texture2D continueButtonImage, Texture2D exitButtonImage)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_backgroundImage, new Rectangle(0, 0, _backgroundImage.Bounds.Width, _backgroundImage.Bounds.Height), Color.White);

            
        }
    }
}
