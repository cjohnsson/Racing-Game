using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;

namespace RaceGame {
    public class World
    {
        public Map Map { get; set; }
        // public Info Info { get; set; }
        public List<Player> Players  { get; set; }
        private DateTime _startTime;
        private TimeSpan _winnerTime;

        private void StartCounter() {
            _startTime = DateTime.Now;
        }

        private void StopCounter() {
            _winnerTime =  _startTime.Subtract(DateTime.Now);
        }

        public void Draw(SpriteBatch spriteBatch) {
            //spriteBatch.Draw()
        }

        public void Update() {

        }
    }
}
