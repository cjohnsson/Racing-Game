#region Using Statements
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.GamerServices;
using RaceGame.Menu;
using Color = Microsoft.Xna.Framework.Color;
using Point = Microsoft.Xna.Framework.Point;
using RaceGame.Menu;
#endregion

namespace RaceGame
{

    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class RaceGame : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private World world;
        private KeyboardState _oldState;
        private Keys _menuKey;
        private Keys _fullScreenKey;
        private Menu.Menu _pauseMenu;
        private const int NR_OF_MAPS = 5;
        private const int NR_OF_CARS = 5;
        private Map[] _maps;
        private Texture2D[] _cars;
        private ComputerPlayer computerPlayer;
        //Screen State variables to indicate what is the current screen
        private bool _isPauseScreenShowed;
        private bool _isMainMenuScreenShowed;
        private Menu.Menu _mainMenu;
        private List<Player> _players;
        private CountDown _countDown;
        private Point[] _startPositions;
        private float[] _startRotations;

        public RaceGame()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            _menuKey = Keys.Escape;
            _fullScreenKey = Keys.F;
            _isMainMenuScreenShowed = true;

            //Initialize screen size to an ideal resolution for the projector
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;

            graphics.IsFullScreen = false;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            _oldState = Keyboard.GetState();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            computerPlayer = new ComputerPlayer();

            _pauseMenu = new PauseMenu(Content.Load<Texture2D>("transparentBackground"), Content.Load<SpriteFont>("SpriteFont1"));
            _mainMenu = new MainMenu(Content.Load<Texture2D>("transparentBackground"), Content.Load<SpriteFont>("SpriteFont1"));

            Texture2D[] mapCollisions = new Texture2D[NR_OF_MAPS];
            Texture2D[] mapBackgrounds = new Texture2D[NR_OF_MAPS];
            Texture2D[] mapForegrounds = new Texture2D[NR_OF_MAPS];
            Bitmap[] bitmaps = new Bitmap[NR_OF_MAPS];
            _maps = new Map[NR_OF_MAPS];
            _cars = new Texture2D[NR_OF_CARS];
            _countDown = new CountDown() { Font = Content.Load<SpriteFont>("CountDownFont") };
            _startPositions = new Point[NR_OF_MAPS];
            _startRotations = new float[NR_OF_MAPS];

            _cars[0] = Content.Load<Texture2D>("car1");
            _cars[1] = Content.Load<Texture2D>("car2");
            _cars[2] = Content.Load<Texture2D>("car3");
            _cars[3] = Content.Load<Texture2D>("car4");
            _cars[4] = Content.Load<Texture2D>("car6");

            mapCollisions[0] = Content.Load<Texture2D>("map1_collision");
            mapCollisions[1] = Content.Load<Texture2D>("map2_collision");
            mapCollisions[2] = Content.Load<Texture2D>("map4_collision");
            mapCollisions[3] = Content.Load<Texture2D>("map6_collision");
            mapCollisions[4] = Content.Load<Texture2D>("map7_collision");

            mapBackgrounds[0] = Content.Load<Texture2D>("map1_background");
            mapBackgrounds[1] = Content.Load<Texture2D>("map2_background");
            mapBackgrounds[2] = Content.Load<Texture2D>("map4_background");
            mapBackgrounds[3] = Content.Load<Texture2D>("map6_background");
            mapBackgrounds[4] = Content.Load<Texture2D>("map7_background");

            mapForegrounds[0] = Content.Load<Texture2D>("map1_foreground1");
            mapForegrounds[1] = Content.Load<Texture2D>("default_foreground");
            mapForegrounds[2] = Content.Load<Texture2D>("default_foreground");
            mapForegrounds[3] = Content.Load<Texture2D>("default_foreground");
            mapForegrounds[4] = Content.Load<Texture2D>("map7_foreground1");

            for (int i = 0; i < bitmaps.Length; i++)
            {
                MemoryStream stream = new MemoryStream();

                mapCollisions[i].SaveAsPng(stream, mapCollisions[i].Bounds.Width, mapCollisions[i].Bounds.Height);
                bitmaps[i] = new Bitmap(stream);
            }

            _startPositions[0] = new Point(80, 270);
            _startPositions[1] = new Point(732, 216);
            _startPositions[2] = new Point(384, 550);
            _startPositions[3] = new Point(435, 545);
            _startPositions[4] = new Point(80, 270);

            _startRotations[0] = 8.0f;
            _startRotations[1] = 8.0f;
            _startRotations[2] = 0.0f;
            _startRotations[3] = 3.2f;
            _startRotations[4] = 8.0f;

            for (int i = 0; i < _maps.Length; i++)
            {
                _maps[i] = new Map(mapBackgrounds[i], mapForegrounds[i], bitmaps[i], Content.Load<Texture2D>("clouds"), _startPositions[i].X, _startPositions[i].Y, _startRotations[i]);
            }
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
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            KeyboardState newState = Keyboard.GetState();

            if (_isMainMenuScreenShowed)
            {
                if (newState.IsKeyDown(Keys.Up))
                {
                    if (_oldState.IsKeyUp(Keys.Up))
                    {
                        _mainMenu.ScrollUp();
                    }
                }
                if (newState.IsKeyDown(Keys.Down))
                {
                    if (_oldState.IsKeyUp(Keys.Down))
                    {
                        _mainMenu.ScrollDown();
                    }
                }

                if (newState.IsKeyDown(Keys.Left))
                {
                    if (_oldState.IsKeyUp(Keys.Left))
                    {
                        _mainMenu.SelectedMenuItem.LowerValue();
                    }
                }

                if (newState.IsKeyDown(Keys.Right))
                {
                    if (_oldState.IsKeyUp(Keys.Right))
                    {
                        _mainMenu.SelectedMenuItem.RaiseValue();
                    }
                }

                if (newState.IsKeyDown(_menuKey))
                {
                    if (_oldState.IsKeyUp(_menuKey))
                    {
                        this.Exit();
                    }
                }

                if (newState.IsKeyDown(_fullScreenKey))
                {
                    if (_oldState.IsKeyUp(_fullScreenKey))
                    {
                        graphics.ToggleFullScreen();
                    }
                }


                if (newState.IsKeyDown(Keys.Enter))
                {
                    if (_oldState.IsKeyUp(Keys.Enter))
                    {
                        _isMainMenuScreenShowed = false;

                        Player player1 = new Player(new Control(Keys.Up, Keys.Down, Keys.Left, Keys.Right), _cars[0],
                                                    new Vector2(_maps[_mainMenu.SelectedMap].StartX,
                                                                _maps[_mainMenu.SelectedMap].StartY),
                                                    _maps[_mainMenu.SelectedMap].StartRotation);
                        Player player2 = new Player(new Control(Keys.W, Keys.S, Keys.A, Keys.D), _cars[1],
                                                    new Vector2(_maps[_mainMenu.SelectedMap].StartX,
                                                                _maps[_mainMenu.SelectedMap].StartY),
                                                    _maps[_mainMenu.SelectedMap].StartRotation);
                        Player player3 =
                            new Player(new Control(Keys.PageDown, Keys.PageDown, Keys.PageDown, Keys.PageDown), _cars[3],
                                       new Vector2(_maps[_mainMenu.SelectedMap].StartX,
                                                   _maps[_mainMenu.SelectedMap].StartY),
                                       _maps[_mainMenu.SelectedMap].StartRotation);
                        Player player4 =
                            new Player(new Control(Keys.PageDown, Keys.PageDown, Keys.PageDown, Keys.PageDown), _cars[4],
                                       new Vector2(_maps[_mainMenu.SelectedMap].StartX,
                                                   _maps[_mainMenu.SelectedMap].StartY),
                                       _maps[_mainMenu.SelectedMap].StartRotation);

                        _players = new List<Player>();

                        if (_mainMenu.NrOfPlayers == 1)
                            _players.Add(player1);
                        else
                        {
                            _players.Add(player1);
                            _players.Add(player2);
                        }

                        switch (_mainMenu.NrOfBots)
                        {
                            case 1:
                                _players.Add(player3);
                                computerPlayer.Players.Add(player3);
                                break;
                            case 2:
                                _players.Add(player3);
                                computerPlayer.Players.Add(player3);
                                _players.Add(player4);
                                computerPlayer.Players.Add(player4);
                                break;
                        }

                        world = new World(_maps[_mainMenu.SelectedMap], _players,
                                          Content.Load<SpriteFont>("spritefont1"), Content.Load<Texture2D>("HUD"), _countDown);
                        world.Map.Laps = _mainMenu.NrOfLaps;
                        World.RaceTimer.Reset();
                        World.RaceTimer.Resume();
                    }
                }
            }
            else if (!_isPauseScreenShowed)
            {
                if (newState.IsKeyDown(_menuKey))
                {
                    if (_isPauseScreenShowed && _oldState.IsKeyUp(_menuKey))
                    {
                        _isPauseScreenShowed = false;
                        World.RaceTimer.Resume();
                    }
                    else if (_oldState.IsKeyUp(_menuKey))
                    {
                        _isPauseScreenShowed = true;
                        World.RaceTimer.Pause();
                    }
                }

                foreach (Player player in world.Players)
                {
                    if (newState.IsKeyDown(player.Control.Accelerate))
                    {
                        player.Car.Accelerate();
                    }
                    if (newState.IsKeyDown(player.Control.Decelearte))
                    {
                        player.Car.Break();
                    }
                    if (newState.IsKeyDown(player.Control.Left))
                    {
                        player.Car.TurnLeft();
                    }
                    if (newState.IsKeyDown(player.Control.Right))
                    {
                        player.Car.TurnRight();
                    }
                }
                computerPlayer.Update();
                world.Update();

                if (world.Winner != null)
                {
                    _isMainMenuScreenShowed = true;
                    //Spelet är över... spara tiden till highscoren och celebrate
                }
            }
            else
            {
                if (newState.IsKeyDown(_menuKey))
                {
                    if (_isPauseScreenShowed && _oldState.IsKeyUp(_menuKey))
                    {
                        _isPauseScreenShowed = false;
                        World.RaceTimer.Resume();
                    }
                    else if (_oldState.IsKeyUp(_menuKey))
                    {
                        _isPauseScreenShowed = true;
                        World.RaceTimer.Pause();
                    }
                }
                if (newState.IsKeyDown(Keys.Up))
                {
                    if (_oldState.IsKeyUp(Keys.Up))
                    {
                        _pauseMenu.ScrollUp();
                    }
                }
                if (newState.IsKeyDown(Keys.Down))
                {
                    if (_oldState.IsKeyUp(Keys.Down))
                    {
                        _pauseMenu.ScrollDown();
                    }
                }
                if (newState.IsKeyDown(Keys.Enter))
                {
                    if (_oldState.IsKeyUp(Keys.Enter))
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
            }

            _oldState = newState;
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            if (_isMainMenuScreenShowed)
            {
                _mainMenu.Draw(spriteBatch);
            }
            else
            {
                world.Draw(spriteBatch);

                if (_isPauseScreenShowed)
                {
                    _pauseMenu.Draw(spriteBatch);
                }
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
