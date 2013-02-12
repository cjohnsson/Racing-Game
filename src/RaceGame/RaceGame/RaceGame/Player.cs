using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RaceGame
{
    public class Player
    {
        public Car Car { get; set; }
        public int Lap { get; set; }
        public TimeSpan Time { get; set; }
        public Control Control { get; set; }
        private string _name;

        public Player(Control control, Texture2D carImage, Vector2 position,System.Drawing.Bitmap bitmap)
        {
            Control = control;
            Car = new Car(carImage, position,bitmap);
        }

        public string Name
        {
            get
            {
                if (_name == "")
                {
                    _name = "Unknown Player";
                    return _name;
                }
                return _name;
            }
            set
            {
                if (value == "")
                {
                    throw new ArgumentException("Please insert a valid name!");
                }
                _name = value;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Car.Draw(spriteBatch);
        }

        public void Update()
        {
            Car.Update();
            while (Car.HasFinishedLap)
            {
                Lap++;
            }
        }
    }
}
