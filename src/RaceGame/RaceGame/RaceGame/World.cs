using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace RaceGame {
    public class World
    {
        public Map Map { get; set; }
        public List<Player> Players { get; set; }
        private static DateTime _startTime;
        public static TimeSpan ElapsedTime { get { return DateTime.Now.Subtract(_startTime); } }
        public SpriteFont font;
        private Info _info;
        public static Bitmap CollisionImage { get; set; }
        
        public World(Map map, List<Player> players, SpriteFont font)
        {
            Players = players;
            Map = map; 
            _startTime = DateTime.Now;
            this.font = font;
            _info = new Info(font, Map , Players);
            CollisionImage = map.CollisionImage;
        }

        //private TimeSpan GetWinnerTime() {
        //    return  _startTime.Subtract(DateTime.Now);
        //}

        public void Draw(SpriteBatch spriteBatch)
        {
            Map.DrawBackground(spriteBatch);
            foreach (var player in Players)
            {
                player.Draw(spriteBatch);
            }
            Map.DrawForeground(spriteBatch);
            _info.Draw(spriteBatch);
        }

        public void Update() {
            foreach (var player in Players)
            {
                player.Update();
                if (player.Lap == Map.Laps)
                {
                    //något ska hända när en spelare vunnit
                    //player.Time = GetWinnerTime();
                }
            }
            Map.Update();
        }
    }
}
