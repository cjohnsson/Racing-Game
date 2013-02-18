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
        public static RaceTimer RaceTimer { get; private set; }
        public static TimeSpan ElapsedTime
        {
            get { return RaceTimer.GetElapsedTime(); }
        }
        private Info _info;
        public static Bitmap CollisionImage { get; set; }
        public Player Winner { get; set; }
        private CountDown CountDown { get; set; }

        public World(Map map, List<Player> players, SpriteFont font, Texture2D hud, CountDown countDown)
        {
            RaceTimer = new RaceTimer();
            
            CountDown = countDown;
            CountDown.Start();
            Players = players;
            Map = map;
            _info = new Info(font, Map, Players, hud);
            CollisionImage = map.CollisionImage;
            Winner = null;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Map.DrawBackground(spriteBatch);
            foreach (var player in Players)
            {
                player.Draw(spriteBatch);
            }

            Map.DrawForeground(spriteBatch);

            if (CountDown.IsFinished)
            {
                _info.Draw(spriteBatch);
            }
            else
                CountDown.Draw(spriteBatch);
        }

        public void Update()
        {
            if (CountDown.IsFinished)
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
