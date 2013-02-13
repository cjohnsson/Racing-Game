using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
//using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;

namespace RaceGame
{
    public class Info
    {
        Map map;
        List<Player> players;
        SpriteFont font;

        
        public Info(SpriteFont newFont, Map newMap, List<Player> newPlayers)
        {
            this.font = newFont;
            this.map = newMap;
            this.players = newPlayers;
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.DrawString(font, "P1 Lap : " + players[0].Lap + "/" + map.Laps, new Vector2(10, 5), Color.Black);
            spriteBatch.DrawString(font, "P2 Lap : " + players[1].Lap + "/" + map.Laps, new Vector2(150, 5), Color.Black);
            
            spriteBatch.DrawString(font, "Lap : " + World.ElapsedTime, new Vector2(300, 5), Color.Black);

        }

        

        public void LoadSpriteFont()
        {


        }
    }
}
