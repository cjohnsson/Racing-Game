using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RaceGame
{
    class MainMenu
    {
        private const int NR_OF_BUTTONS = 5;
        private Texture2D _backgroundImage;
        private Texture2D _buttonTexture;
        private Rectangle[] _buttonPositions;
        private SpriteFont _font;
        private int _buttonHeight;
        private int _buttonWidth;
        public int Index { get; private set; }
        public int NrOfPlayers { get; private set; }
        public int NrOfBots { get; private set; }
        public int SelectedMap { get; private set; }
        public int NrOfLaps { get; private set; }

        private void InitilizeDefaultValues()
        {
            Index = 0;
            NrOfPlayers = 1;
            NrOfBots = 2;
            SelectedMap = 0;
            NrOfLaps = 2;
        }

        public MainMenu(Texture2D backgroundImage, Texture2D buttonTexture, SpriteFont font)
        {
            InitilizeDefaultValues();
            _backgroundImage = backgroundImage;
            _buttonTexture = buttonTexture;
            _font = font;
            _buttonPositions = new Rectangle[NR_OF_BUTTONS];
            _buttonHeight = buttonTexture.Bounds.Height;
            _buttonWidth = buttonTexture.Bounds.Width;
            int xPosition = _backgroundImage.Bounds.Width / 2 - _buttonWidth / 2;
            int yPosition = _backgroundImage.Bounds.Height / 2 - (_buttonHeight * NR_OF_BUTTONS) / 2;

            for (int i = 0; i < _buttonPositions.Length; i++)
            {
                _buttonPositions[i] = new Rectangle(xPosition, yPosition, _buttonWidth, _buttonHeight);
                yPosition += _buttonHeight;
            }
        }

        public void ScrollUp()
        {
            if (Index > 0)
                Index--;
            else if (Index <= 0)
            {
                Index = NR_OF_BUTTONS - 1;
            }
        }

        public void ScrollDown()
        {
            if (Index < NR_OF_BUTTONS - 1)
                Index++;
            else if (Index >= NR_OF_BUTTONS - 1)
            {
                Index = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_backgroundImage, new Rectangle(0, 0, _backgroundImage.Bounds.Width, _backgroundImage.Bounds.Height), Color.White);

            Color color = Color.White;
            Vector2 position;
            for (int i = 0; i < NR_OF_BUTTONS; i++)
            {
                position = new Vector2(_buttonPositions[i].X, _buttonPositions[i].Y);

                if (i == Index)
                    color = Color.Red;
                else
                    color = Color.White;

                switch (i)
                {
                    case (int)MainMenuItems.Players:
                        spriteBatch.DrawString(_font, string.Format("Number of players: " + NrOfPlayers), position, color);
                        break;
                    case (int)MainMenuItems.Bots:
                        spriteBatch.DrawString(_font, string.Format("Number of bots: " + NrOfBots), position, color);
                        break;
                    case (int)MainMenuItems.Map:
                        spriteBatch.DrawString(_font, string.Format("Selected map: " + SelectedMap), position, color);
                        break;
                    case (int)MainMenuItems.Laps:
                        spriteBatch.DrawString(_font, string.Format("Number of laps: " + NrOfLaps), position, color);
                        break;
                    case (int)MainMenuItems.Start:
                        spriteBatch.DrawString(_font, string.Format("START THE GAME"), position, color);
                        break;
                }
            }
        }
    }
}
