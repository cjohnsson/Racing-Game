#region Using Statements
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
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
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private World world;
        private KeyboardState _oldState;
        private Color backColor;
        private Keys _menuKey = Keys.P;
        private Keys _exitKey = Keys.Escape;
        private Texture2D transparentBackgroundImage;

        //Screen State variables to indicate what is the current screen
        private bool _isGameMenuShowed;

        public RaceGame()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            //Initialize screen size to an ideal resolution for the projector
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
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
            
            backColor = Color.CornflowerBlue;
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

            transparentBackgroundImage = Content.Load<Texture2D>("transparentBackground");
            Texture2D car_emilImage = Content.Load<Texture2D>("car-emil");
            Texture2D mapCollision = Content.Load<Texture2D>("mapcollision");

            System.Drawing.Bitmap bitmap = null;
            Stream stream = new MemoryStream();
            
            mapCollision.SaveAsPng(stream, mapCollision.Bounds.Width, mapCollision.Bounds.Height);
            bitmap = new Bitmap(stream);
            
            List<Player> players = new List<Player>();
            players.Add(new Player(new Control(Keys.W, Keys.S, Keys.A, Keys.D), car_emilImage, new Vector2(50,50)));
            world = new World(new Map(Content.Load<Texture2D>("map"),Content.Load<Texture2D>("mapforeground"), bitmap), players );

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

            if(newState.IsKeyDown(_exitKey))
                this.Exit();

            if (newState.IsKeyDown(_menuKey))
            {
                if (_isGameMenuShowed && _oldState.IsKeyUp(_menuKey))
                {
                    _isGameMenuShowed = false;
                    
                }
                else if (_oldState.IsKeyUp(_menuKey))
                {
                    _isGameMenuShowed = true;
                    
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
            GraphicsDevice.Clear(backColor);

            spriteBatch.Begin();

            world.Draw(spriteBatch);

            if (_isGameMenuShowed)
            {
                spriteBatch.Draw(transparentBackgroundImage, Vector2.Zero, Color.White);
            }
            
            spriteBatch.End();
           
            base.Draw(gameTime);
        }
    }
}
