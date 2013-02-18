using System;
using System.Collections.Generic;
using System.Drawing;
using Microsoft.Xna.Framework.Graphics;

namespace RaceGame
{
    public class World : IWorld
    {
        public Map Map { get; set; }
        public List<Player> Players { get; set; }
        private static DateTime _startTime;
        public static TimeSpan ElapsedTime { get { return DateTime.Now.Subtract(_startTime); } }
        private Info _info;
        public static Bitmap CollisionImage { get; set; }
        public Player Winner { get; set; }
        public CountDown CountDown { get; set; }


        public World(Map map, List<Player> players, SpriteFont font, Texture2D hud, CountDown countDown)
        {
            CountDown = countDown;
            CountDown.Start();
            Players = players;
            Map = map;
            _startTime = DateTime.Now;
            _info = new Info(font, Map, Players, hud);
            CollisionImage = map.CollisionImage;
            Winner = null;
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


            if (!CountDown.Finished)
            {
                _info.Draw(spriteBatch);
            }
            else
                CountDown.Draw(spriteBatch);
        }

        public void Update()
        {
            if (!CountDown.Finished)
            {
                foreach (var player in Players)
                {
                    player.Update();
                    if (player.Lap == Map.Laps)
                    {
                        Winner = player;
                    }
                }                
            }
            Map.Update();          
        }
    }
}
