using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace RaceGame {
    public class World
    {
        public Map Map { get; set; }
        // public Info Info { get; set; }
        public List<Player> Players { get; set; }
        private static DateTime _startTime;
        public static TimeSpan ElapsedTime { get { return DateTime.Now.Subtract(_startTime); } }

        public World(Map map, List<Player> players)
        {
            Players = players;
            Map = map; 
            _startTime = DateTime.Now;
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
        }

        public void Update() {
            foreach (var player in Players)
            {
                player.Update();
                if (player.Lap == Map.Laps)
                {
                    player.Time = GetWinnerTime();
                }
            }
        }
    }
}
