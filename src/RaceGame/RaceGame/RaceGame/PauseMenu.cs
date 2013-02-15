using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RaceGame
{
    public class PauseMenu : IMenu
    {
        private readonly Texture2D _backgroundImage;
        public int Index { get; private set; }
        private readonly Texture2D[] _buttonTextures;
        private readonly Rectangle[] _buttonPositions;

        public PauseMenu(Texture2D backgroundImage, Texture2D[] menuButtonImages)
        {
            Index = 0;
            _backgroundImage = backgroundImage;
            _buttonPositions = new Rectangle[menuButtonImages.Length];
            _buttonTextures = menuButtonImages;
            int buttonHeight = menuButtonImages[0].Bounds.Height;
            int buttonWidth = menuButtonImages[0].Bounds.Width;
            int xPosition = _backgroundImage.Bounds.Width / 2 - buttonWidth / 2;
            int yPosition = _backgroundImage.Bounds.Height / 2 - (buttonHeight * menuButtonImages.Length) / 2;

            for (int i = 0; i < _buttonPositions.Length; i++)
            {
                _buttonPositions[i] = new Rectangle(xPosition, yPosition, buttonWidth, buttonHeight);
                yPosition += buttonHeight;
            }
        }

        public void ScrollUp()
        {
            if (Index > 0)
                Index--;
            else if (Index <= 0)
            {
                Index = _buttonTextures.Length - 1;
            }
        }

        public void ScrollDown()
        {
            if (Index < _buttonTextures.Length - 1)
                Index++;
            else if (Index >= _buttonTextures.Length - 1)
            {
                Index = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_backgroundImage, new Rectangle(0, 0, _backgroundImage.Bounds.Width, _backgroundImage.Bounds.Height), Color.White);

            for (int i = 0; i < _buttonTextures.Length; i++)
            {
                if (i == Index)
                {
                    spriteBatch.Draw(_buttonTextures[i],
                                 _buttonPositions[i],
                                 Color.LightGreen);
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
