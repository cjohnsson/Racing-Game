using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.GamerServices;


namespace RaceGame
{
    //TODO: Eventuella tester ska göras
    public class Info : IInfo
    {
        private Map _map;
        private List<Player> _players;
        private SpriteFont _font;
        private Texture2D _hud;

        public Info(SpriteFont newFont, Map newMap, List<Player> newPlayers, Texture2D hud)
        {
            if (newFont == null) throw new ArgumentNullException("newFont");
            if (newMap == null) throw new ArgumentNullException("newMap");
            if (newPlayers == null) throw new ArgumentNullException("newPlayers");
            if (hud == null) throw new ArgumentNullException("hud");

            _font = newFont;
            _map = newMap;
            _players = newPlayers;
            _hud = hud;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_hud, new Vector2(0, 0), Color.White);
            spriteBatch.DrawString(_font, string.Format("Time: {0}:{1}:{2} ", World.ElapsedTime.Minutes, World.ElapsedTime.Seconds , World.ElapsedTime.Milliseconds), new Vector2(300, 10), Color.Black);

            spriteBatch.DrawString(_font, "P1 Lap : " + _players[0].Lap + "/" + _map.Laps, new Vector2(10, 10), Color.Black);
            if (_players[1].Control.Accelerate == Keys.W)
            {
                spriteBatch.DrawString(_font, "P2 Lap : " + _players[1].Lap + "/" + _map.Laps, new Vector2(650, 10), Color.Black);
            }
        }
    }
}
