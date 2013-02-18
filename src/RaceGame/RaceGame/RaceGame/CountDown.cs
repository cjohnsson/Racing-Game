using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RaceGame
{
    public class CountDown
    {
     
        private const float TIME = 5.0f;

        #region Propertys


        public bool IsFinished
        {
            get { return DateTime.Now.Subtract(StartDate).TotalSeconds > TIME; }
        }

        public string Text
        {
            get { return ((int)TIME - DateTime.Now.Subtract(StartDate).Seconds).ToString(); }        
        }

        public SpriteFont Font { get; set; }

        public Vector2 Position { get; set; }

        public DateTime StartDate { get; set; }

        #endregion
     

        public void Start()
        {
            StartDate = DateTime.Now;
        }

        public void Draw(SpriteBatch spriteBatch)
        {        
            spriteBatch.DrawString(Font, Text, new Vector2(400,150), Color.Red);
        }
    }
}
