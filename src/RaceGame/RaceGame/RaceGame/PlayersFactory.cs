using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using RaceGame.Holders;

namespace RaceGame
{
    public static class PlayersFactory
    {
        public static List<Player> CreatePlayers(int numberOfPlayers, int numberOfBots, Map map)
        {
            List<Player> players = new List<Player>();
            var player1 = CreatePlayer(new Control(Keys.Up, Keys.Down, Keys.Left, Keys.Right), ContentLoader.GetCarTexture(0), map);
            var player2 = CreatePlayer(new Control(Keys.W, Keys.S, Keys.A, Keys.D), ContentLoader.GetCarTexture(1), map);
            var player3 = CreatePlayer(new Control(Keys.None, Keys.None, Keys.None, Keys.None), ContentLoader.GetCarTexture(2), map);
            player3.IsHuman = false;
            var player4 = CreatePlayer(new Control(Keys.None, Keys.None, Keys.None, Keys.None), ContentLoader.GetCarTexture(3), map);
            player4.IsHuman = false;

            if (numberOfPlayers == 1)
                players.Add(player1);
            else
            {
                players.Add(player1);
                players.Add(player2);
            }

            switch (numberOfBots)
            {
                case 1:
                    players.Add(player3);
                    break;
                case 2:
                    players.Add(player3);
                    players.Add(player4);
                    break;
            }
            return players;
        }

        private static Player CreatePlayer(Control control, Texture2D carTexture, Map map)
        {
            return new Player(control, new Texture2DHolder(carTexture), new Vector2(map.StartX, map.StartY), map.StartRotation);
        }
    }
}
