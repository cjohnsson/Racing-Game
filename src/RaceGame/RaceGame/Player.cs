﻿using System;
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
    public class Player
    {
        public Car Car { get; set; }
        public int Lap { get; set; }
        public TimeSpan Time { get; set; }
        public Control Control { get; set; }
        private string _name;

        public Player(Control control)
        {
            Control = control;
        }

        public string Name {
            get {
                if (_name == "") {
                    _name = "Unknown Player";
                    return _name;
                }
                else { return _name; }
            }
            set {
                if (value == "") {
                    throw new ArgumentException("Please insert a valid name!");
                } else { _name = value; }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Car.Draw(spriteBatch);
        }

        public void Update()
        {

        }
    }
}
