using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RaceGame
{
    public class CountDown
    {
        private bool  _finsished;
        private const float _time = 5.0f;


        public CountDown()
        {
            StartDate = DateTime.Now;
            Finished = false;
        }

        #region Propertys


        public bool Finished
        {
            get { return DateTime.Now.Subtract(StartDate).Seconds < _time; }
            set { _finsished = value; }
        }

        public string Text
        {
            get { return ((int)_time - DateTime.Now.Subtract(StartDate).Seconds).ToString(); }
           
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
