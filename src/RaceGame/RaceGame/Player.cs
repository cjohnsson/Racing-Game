using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;

namespace RaceGame
{
    class Player
    {
        public Car Car { get; set; }
        public int Lap { get; set; }
        public TimeSpan Time { get; set; }
        //public Control Control { get; set; }
        private string _name;

        public Player()
        {

        }

        public string Name {
            get { return _name; }
            set { _name = value; }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw()
        }

        public void Update()
        {

        }
    }
}
