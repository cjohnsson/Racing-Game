using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RaceGame
{
    public class CountDown
    {
        private bool  _finsished;

        private SpriteFont _font;
        private Vector2 _position;
        private float _deltaTime;
        const float _time = 5.0f;
        private DateTime _startDate;
        


        public CountDown()
        {
            _startDate = DateTime.Now;
            Finished = false;
        }

        #region Propertys


        public bool Finished
        {
            get { return DateTime.Now.Subtract(_startDate).Seconds < _time; }
            set { _finsished = value; }
        }

        public string Text
        {
            get { return ((int)_time - DateTime.Now.Subtract(_startDate).Seconds).ToString(); }
           
        }

        public SpriteFont Font
        {
            get { return _font; }
            set { _font = value; }
        }

        public Vector2 Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public float DeltaTime
        {
            get { return _deltaTime; }
            set { _deltaTime = value; }
        }

        #endregion
     

        public void Start()
        {
            _startDate = DateTime.Now;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
         
                spriteBatch.DrawString(Font, Text, new Vector2(400,150), Color.Red);
        }
    }
}
