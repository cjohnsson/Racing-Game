using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace RaceGame
{
    public static class ContentLoader
    {
        public static int NR_OF_MAPS
        {
            get { return 5; }
        }
        public static int NR_OF_CARS
        {
            get { return 5; }
        }
        private static Texture2D[] _cars;
        private static Texture2D[] _mapBackgrounds;
        private static Texture2D[] _mapForegrounds;
        private static Bitmap[] _bitmaps;
        public static Texture2D TransparentBackground { get; set; }
        public static Texture2D CloudTexture { get; set; }
        public static SpriteFont MenuFont { get; set; }
        public static SpriteFont CountDownFont { get; set; }
        public static Texture2D Hud { get; set; }

        public static void Load(ContentManager manager)
        {
            _cars = new Texture2D[NR_OF_CARS];
            _mapBackgrounds = new Texture2D[NR_OF_MAPS];
            _mapForegrounds = new Texture2D[NR_OF_MAPS];
            _bitmaps = new Bitmap[NR_OF_MAPS];

            //Bilbilder
            for (int i = 0; i < NR_OF_CARS; i++)
            {
                _cars[i] = manager.Load<Texture2D>("car" + (i + 1));
            }

            //Kollisionsbilder
            for (int i = 0; i < NR_OF_MAPS; i++)
            {
                Texture2D texture = manager.Load<Texture2D>("map" + (i + 1) + "_collision");
                using (MemoryStream stream = new MemoryStream())
                {
                    texture.SaveAsPng(stream, texture.Bounds.Width, texture.Bounds.Height);
                    _bitmaps[i] = new Bitmap(stream);
                }
            }

            //Bakgrundsbilder
            for (int i = 0; i < NR_OF_MAPS; i++)
            {
                _mapBackgrounds[i] = manager.Load<Texture2D>("map" + (i + 1) + "_background");
            }

            //Förgrundsbilder
            for (int i = 0; i < NR_OF_MAPS; i++)
            {
                try
                {
                    _mapForegrounds[i] = manager.Load<Texture2D>("map" + (i + 1) + "_foreground");
                }
                catch
                {
                    _mapForegrounds[i] = manager.Load<Texture2D>("default_foreground");
                }

            }

            //Övrigt
            TransparentBackground = manager.Load<Texture2D>("transparentBackground");
            CloudTexture = manager.Load<Texture2D>("clouds");
            Hud = manager.Load<Texture2D>("HUD");

            //Fonts
            MenuFont = manager.Load<SpriteFont>("MenuFont");
            CountDownFont = manager.Load<SpriteFont>("CountDownFont");

        }

        public static Texture2D GetCarTexture(int index)
        {
            return _cars[index];
        }

        public static Texture2D GetMapForeground(int index)
        {
            return _mapForegrounds[index];
        }

        public static Texture2D GetMapBackground(int index)
        {
            return _mapBackgrounds[index];
        }

        public static Bitmap GetMapCollision(int index)
        {
            return _bitmaps[index];
        }
    }
}
