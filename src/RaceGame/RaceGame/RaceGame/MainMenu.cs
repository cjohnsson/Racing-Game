using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RaceGame
{
    public class MainMenu : IMainMenu
    {
        private const int NR_OF_BUTTONS = 5;
        private Texture2D _backgroundImage;
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

        public MainMenu()
        {
            Index = 0;
            NrOfPlayers = 1;
            NrOfBots = 2;
            SelectedMap = 0;
            NrOfLaps = 2;
        }

        public MainMenu(Texture2D backgroundImage, SpriteFont font)
        {
            InitilizeDefaultValues();
            _backgroundImage = backgroundImage;
            _font = font;
            _buttonPositions = new Rectangle[NR_OF_BUTTONS];
            _buttonHeight = 50;
            _buttonWidth = 150;
            int xPosition = _backgroundImage.Bounds.Width / 2 - _buttonWidth / 2;
            int yPosition = _backgroundImage.Bounds.Height / 2 - (_buttonHeight * NR_OF_BUTTONS) / 2;

            MakePositions(xPosition, yPosition);
        }

        private void MakePositions(int xPosition, int yPosition)
        {
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

            for (int i = 0; i < NR_OF_BUTTONS; i++)
            {
                Color color = Color.White;
                Vector2 position = new Vector2(_buttonPositions[i].X, _buttonPositions[i].Y);

                if (i == Index)
                    color = Color.Red;

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

        public void RaiseChosenValue()
        {
            switch (Index)
            {
                case (int)MainMenuItems.Players:
                    if (NrOfPlayers < 2)
                    {
                        NrOfPlayers++;
                    }
                    else if (NrOfPlayers >= 2)
                    {
                        NrOfPlayers = 1;
                    }
                    break;
                case (int)MainMenuItems.Bots:
                    if (NrOfBots < 2)
                    {
                        NrOfBots++;
                    }
                    else if (NrOfBots >= 2)
                    {
                        NrOfBots = 0;
                    }
                    break;
                case (int)MainMenuItems.Map:
                    if (SelectedMap < 3)
                    {
                        SelectedMap++;
                    }
                    else if (SelectedMap >= 3)
                    {
                        SelectedMap = 0;
                    }
                    break;
                case (int)MainMenuItems.Laps:
                    if (NrOfLaps < 99)
                    {
                        NrOfLaps++;
                    }
                    else if (NrOfLaps >= 99)
                    {
                        NrOfLaps = 1;
                    }
                    break;
            }
        }

        public void LowerChosenValue()
        {
            switch (Index)
            {
                case (int)MainMenuItems.Players:
                    if (NrOfPlayers == 2)
                    {
                        NrOfPlayers = 1;
                    }
                    else
                        NrOfPlayers = 2;
                    break;
                case (int)MainMenuItems.Bots:
                    if (NrOfBots >= 1)
                        NrOfBots--;
                    else
                        NrOfBots = 2;
                    break;

                case (int)MainMenuItems.Map:
                    if (SelectedMap >= 1)
                    {
                        SelectedMap--;
                    }
                    else
                    {
                        SelectedMap = 3;
                    }
                    break;
                case (int)MainMenuItems.Laps:
                    if (NrOfLaps > 1)
                    {
                        NrOfLaps--;
                    }
                    else
                    {
                        NrOfLaps = 99;
                    }
                    break;
            }
        }
    }
}
