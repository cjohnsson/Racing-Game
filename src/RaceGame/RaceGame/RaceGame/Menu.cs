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
        private int NUMBER_OF_BUTTONS;
        public int Index { get; private set; }

        public Menu(Texture2D backgroundImage, Texture2D[] menuButtonImages)
        {
            NUMBER_OF_BUTTONS = menuButtonImages.Length;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_backgroundImage, new Rectangle(0, 0, _backgroundImage.Bounds.Width, _backgroundImage.Bounds.Height), Color.White);
        }

        public void ScrollUp()
        {
         
        }

        public void ScrollDown()
        {
            throw new NotImplementedException();
        }
    }
}
