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
        private int _buttonTextureHeight;
        private int _buttonTextureWidth;
        public int Index { get; private set; }
        private Texture2D[] _buttonTextures;
        private Rectangle[] _buttonPositions;

        public Menu(Texture2D backgroundImage, Texture2D[] menuButtonImages)
        {
            Index = 0;
            _backgroundImage = backgroundImage;
            NUMBER_OF_BUTTONS = menuButtonImages.Length;
            _buttonTextureHeight = menuButtonImages[0].Bounds.Height;
            _buttonTextureWidth = menuButtonImages[0].Bounds.Width;
            _buttonPositions = new Rectangle[NUMBER_OF_BUTTONS];
            _buttonTextures = menuButtonImages;
            int _x = _backgroundImage.Bounds.Width / 2 - _buttonTextureWidth;
            int _y = _backgroundImage.Bounds.Height / 2 - _buttonTextureHeight * NUMBER_OF_BUTTONS;

            for (int i = 0; i < _buttonPositions.Length; i++)
            {
                _buttonPositions[i] = new Rectangle(_x, _y, _buttonTextureWidth, _buttonTextureHeight);
                _y += _buttonTextureHeight;
            }
        }

        public void ScrollUp()
        {
            if (Index > 0)
                Index--;
            else if (Index <= 0)
            {
                Index = NUMBER_OF_BUTTONS-1;
            }
        }

        public void ScrollDown()
        {
            if (Index < NUMBER_OF_BUTTONS-1)
                Index++;
            else if (Index >= NUMBER_OF_BUTTONS-1)
            {
                Index = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_backgroundImage, new Rectangle(0, 0, _backgroundImage.Bounds.Width, _backgroundImage.Bounds.Height), Color.White);

            for (int i = 0; i < NUMBER_OF_BUTTONS; i++)
            {
                if (i == Index)
                {
                    spriteBatch.Draw(_buttonTextures[i],
                                 _buttonPositions[i],
                                 Color.Green);
                }
                else
                {
                    spriteBatch.Draw(_buttonTextures[i],
                                 _buttonPositions[i],
                                 Color.White);
                }
            }
        }
    }
}
