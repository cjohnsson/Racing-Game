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
using Color = Microsoft.Xna.Framework.Color;

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
        private Keys _exitKey;
        private Menu _menu;

        private const int NR_OF_MAPS = 5;
        private const int NR_OF_CARS = 5;
        private Map[] _maps;
        private Texture2D[] _cars;

        //Screen State variables to indicate what is the current screen
        private bool _isGameMenuShowed;

        public RaceGame()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            _menuKey = Keys.P;
            _exitKey = Keys.Escape;
            
            //Initialize screen size to an ideal resolution for the projector
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;

            //graphics.IsFullScreen = true;
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

            _menu = new Menu(Content.Load<Texture2D>("transparentBackground"), Content.Load<Texture2D>("menu_start"), Content.Load<Texture2D>("menu_continue"), Content.Load<Texture2D>("menu_exit"));

            
            Texture2D[] mapCollisions = new Texture2D[NR_OF_MAPS];
            Texture2D[] mapBackgrounds = new Texture2D[NR_OF_MAPS];
            Texture2D[] mapForegrounds = new Texture2D[NR_OF_MAPS];
            Bitmap[] bitmaps = new Bitmap[NR_OF_MAPS];
            _maps = new Map[NR_OF_MAPS];
            _cars = new Texture2D[NR_OF_CARS];

            _cars[0] = Content.Load<Texture2D>("car1");
            _cars[1] = Content.Load<Texture2D>("car2");
            _cars[2] = Content.Load<Texture2D>("car3");
            _cars[3] = Content.Load<Texture2D>("car4");
            _cars[4] = Content.Load<Texture2D>("car6");

            mapCollisions[0] = Content.Load<Texture2D>("map1_collision");
            mapCollisions[1] = Content.Load<Texture2D>("map2_collision");
            mapCollisions[2] = Content.Load<Texture2D>("map3_collision");
            mapCollisions[3] = Content.Load<Texture2D>("map4_collision");
            mapCollisions[4] = Content.Load<Texture2D>("map6_collision");


            mapBackgrounds[0] = Content.Load<Texture2D>("map1_background");
            mapBackgrounds[1] = Content.Load<Texture2D>("map2_background");
            mapBackgrounds[2] = Content.Load<Texture2D>("map3_background");
            mapBackgrounds[3] = Content.Load<Texture2D>("map4_background");
            mapBackgrounds[4] = Content.Load<Texture2D>("map6_background");

            mapForegrounds[0] = Content.Load<Texture2D>("map1_foreground1");
            mapForegrounds[1] = Content.Load<Texture2D>("default_foreground");
            mapForegrounds[2] = Content.Load<Texture2D>("default_foreground");
            mapForegrounds[3] = Content.Load<Texture2D>("default_foreground");
            mapForegrounds[4] = Content.Load<Texture2D>("default_foreground");

            for (int i = 0; i < bitmaps.Length; i++)
            {
                MemoryStream stream = new MemoryStream();

                mapCollisions[i].SaveAsPng(stream, mapCollisions[i].Bounds.Width, mapCollisions[i].Bounds.Height);
                bitmaps[i] = new Bitmap(stream);
            }

            for (int i = 0; i < _maps.Length; i++)
            {
                _maps[i] = new Map(mapBackgrounds[i], mapForegrounds[i], bitmaps[i], Content.Load<Texture2D>("clouds"));
            }

            List<Player> players = new List<Player>();
            players.Add(new Player(new Control(Keys.W, Keys.S, Keys.A, Keys.D), _cars[0], new Vector2(80, 270)));
            players.Add(new Player(new Control(Keys.Up, Keys.Down, Keys.Left, Keys.Right), _cars[1], new Vector2(80, 270)));
            world = new World(_maps[0], players, Content.Load<SpriteFont>("spritefont1"));
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

            if (newState.IsKeyDown(_exitKey))
                this.Exit();

            if (newState.IsKeyDown(_menuKey))
            {
                if (_isGameMenuShowed && _oldState.IsKeyUp(_menuKey))
                {
                    _isGameMenuShowed = false;
                    IsMouseVisible = false;
                }
                else if (_oldState.IsKeyUp(_menuKey))
                {
                    _isGameMenuShowed = true;
                    IsMouseVisible = true;
                }
            }

            if (!_isGameMenuShowed)
            {
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
                    world.Update();
                }
            }
            else
            {
                if (newState.IsKeyDown(Keys.Up))
                {
                    
                }
                if (newState.IsKeyDown(Keys.Down))
                {
                    
                }
                if (newState.IsKeyDown(Keys.Enter))
                {
                    
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

            world.Draw(spriteBatch);

            if (_isGameMenuShowed)
            {
                _menu.Draw(spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
