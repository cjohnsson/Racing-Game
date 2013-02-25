using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RaceGame
{
    public class CountDown
    {
        private const float COUNTDOWN_TIME = 3.0f;
        private SpriteFont _font;

        public CountDown(SpriteFont spriteFont)
        {
            _font = spriteFont;
        }

        #region Propertys

        public bool IsFinished
        {
            get { return DateTime.Now.Subtract(StartDate).TotalSeconds > COUNTDOWN_TIME; }
        }

        private string Text
        {
            get { return ((int)COUNTDOWN_TIME - DateTime.Now.Subtract(StartDate).Seconds).ToString(); }        
        }

        
        public DateTime StartDate { get; set; }

        #endregion
     

        public void Start()
        {
            StartDate = DateTime.Now;
        }

        public void Draw(SpriteBatch spriteBatch)
        {        
            spriteBatch.DrawString(_font, Text, new Vector2(400,150), Color.Red);
        }
    }
}
