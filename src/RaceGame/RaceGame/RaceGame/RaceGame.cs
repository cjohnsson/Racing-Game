#region Using Statements
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RaceGame.Menu;
using Color = Microsoft.Xna.Framework.Color;
using Point = Microsoft.Xna.Framework.Point;

#endregion

namespace RaceGame
{

    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class RaceGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private World _world;
        private KeyboardState _oldKeyboardState;
        private KeyboardState _newKeyboardState;
        private Keys _menuKey;
        private Keys _fullScreenKey;
        private Menu.Menu _pauseMenu;
        private ComputerPlayersAi _computerPlayersComputerPlayersAi;
        private bool _isPauseScreenShowed;
        private bool _isMainMenuScreenShowed;
        private Menu.Menu _mainMenu;
        private CountDown _countDown;

        public RaceGame()
            : base()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            //Initialize screen size to an ideal resolution for the projector
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 600;
            _graphics.IsFullScreen = false;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            MapFactory.Initilize();
            ContentLoader.Load(Content);

            _menuKey = Keys.Escape;
            _fullScreenKey = Keys.F;
            _isMainMenuScreenShowed = true;
            _oldKeyboardState = Keyboard.GetState();
            _countDown = new CountDown(ContentLoader.CountDownFont);
            _computerPlayersComputerPlayersAi = new ComputerPlayersAi();
            _pauseMenu = new PauseMenu(ContentLoader.TransparentBackground, ContentLoader.MenuFont);
            _mainMenu = new MainMenu(ContentLoader.TransparentBackground, ContentLoader.MenuFont);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the _world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            _newKeyboardState = Keyboard.GetState();

            if (_isMainMenuScreenShowed)
            {
                MainMenuActions();
            }
            else if (!_isPauseScreenShowed)
            {
                GameActions();
            }
            else
            {
                PauseMenuActions();
            }

            _oldKeyboardState = _newKeyboardState;
            base.Update(gameTime);
        }

        private void PauseMenuActions()
        {
            if (IsPressed(_menuKey))
            {
                if (_isPauseScreenShowed)
                {
                    _isPauseScreenShowed = false;
                    World.RaceTimer.Resume();
                }
                else
                {
                    _isPauseScreenShowed = true;
                    World.RaceTimer.Pause();
                }
            }

            if (IsPressed(Keys.Up))
            {
                _pauseMenu.ScrollUp();
            }

            if (IsPressed(Keys.Down))
            {
                _pauseMenu.ScrollDown();
            }

            if (IsPressed(Keys.Enter))
            {
                switch (_pauseMenu.SelectedMenuItem.GetValue())
                {
                    case 0:
                        _isPauseScreenShowed = false;
                        break;
                    case 1:
                        _isMainMenuScreenShowed = true;
                        _isPauseScreenShowed = false;
                        break;
                }
            }
        }

        private void GameActions()
        {
            if (_countDown.IsFinished)
            {
                if (IsPressed(_menuKey))
                {
                    if (_isPauseScreenShowed)
                    {
                        _isPauseScreenShowed = false;
                        World.RaceTimer.Resume();
                    }
                    else
                    {
                        _isPauseScreenShowed = true;
                        World.RaceTimer.Pause();
                    }
                }

                foreach (Player player in _world.Players)
                {
                    if (_newKeyboardState.IsKeyDown(player.Control.Accelerate))
                    {
                        player.Car.Accelerate();
                    }

                    if (_newKeyboardState.IsKeyDown(player.Control.Decelearte))
                    {
                        player.Car.Break();
                    }

                    if (_newKeyboardState.IsKeyDown(player.Control.Left))
                    {
                        player.Car.TurnLeft();
                    }

                    if (_newKeyboardState.IsKeyDown(player.Control.Right))
                    {
                        player.Car.TurnRight();
                    }
                }
                _computerPlayersComputerPlayersAi.Update();
                _world.Update();

                if (_world.Winner != null)
                {
                    _isMainMenuScreenShowed = true;
                }
            }
        }

        private void MainMenuActions()
        {
            if (IsPressed(Keys.Up))
            {
                _mainMenu.ScrollUp();
            }

            if (IsPressed(Keys.Down))
            {
                _mainMenu.ScrollDown();
            }

            if (IsPressed(Keys.Left))
            {
                _mainMenu.SelectedMenuItem.LowerValue();
            }

            if (IsPressed(Keys.Right))
            {
                _mainMenu.SelectedMenuItem.RaiseValue();
            }

            if (IsPressed(Keys.Escape))
            {
                Exit();
            }

            if (IsPressed(_fullScreenKey))
            {
                _graphics.ToggleFullScreen();
            }

            if (IsPressed(Keys.Enter))
            {
                _isMainMenuScreenShowed = false;


                CreateGameWorld();
            }
        }

        private bool IsPressed(Keys key)
        {
            return _newKeyboardState.IsKeyDown(key) && _oldKeyboardState.IsKeyUp(key);
        }

        private void CreateGameWorld()
        {
            Map map = MapFactory.Create(_mainMenu.SelectedMap);

            List<Player> players = PlayersFactory.CreatePlayers(_mainMenu.NrOfPlayers, _mainMenu.NrOfBots, map);

            foreach (var player in players )
            {
                if (!player.IsHuman)
                    _computerPlayersComputerPlayersAi.ComputerPlayers.Add(player);
            }

            _world = new World(map, players,
                               ContentLoader.MenuFont, ContentLoader.Hud, _countDown);
            _world.Map.Laps = _mainMenu.NrOfLaps;
            World.RaceTimer.Reset();
            World.RaceTimer.Resume();
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            if (_isMainMenuScreenShowed)
            {
                _mainMenu.Draw(_spriteBatch);
            }
            else
            {
                _world.Draw(_spriteBatch);

                if (_isPauseScreenShowed)
                {
                    _pauseMenu.Draw(_spriteBatch);
                }
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
