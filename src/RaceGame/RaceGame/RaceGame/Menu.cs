using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RaceGame
{
    class Menu
    {
        private Texture2D _image;

        public Menu(Texture2D image)
        {
            _image = image;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_image, new Rectangle(0, 0, _image.Bounds.Width, _image.Bounds.Height), Color.White);
        }

        public void Update()
        {
            
        }
    }
}
