using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace RaceGame
{
    public static class PlayerFactory
    {
        public static List<Player> CreatePlayers(int numberOfPlayers, int numberOfBots, Map map)
        {
            List<Player> _players = new List<Player>();
            var player1 = CreatePlayer(new Control(Keys.Up, Keys.Down, Keys.Left, Keys.Right), ContentLoader.GetCar(0));
            var player2 = CreatePlayer(new Control(Keys.W, Keys.S, Keys.A, Keys.D), ContentLoader.GetCar(1));
            var player3 = CreatePlayer(new Control(Keys.None, Keys.None, Keys.None, Keys.None), ContentLoader.GetCar(2));
            player3.isHuman = false;
            var player4 = CreatePlayer(new Control(Keys.None, Keys.None, Keys.None, Keys.None), ContentLoader.GetCar(3));
            player4.isHuman = false;

            if (numberOfPlayers == 1)
                _players.Add(player1);
            else
            {
                _players.Add(player1);
                _players.Add(player2);
            }

            switch (numberOfBots)
            {
                case 1:
                    _players.Add(player3);
                    break;
                case 2:
                    _players.Add(player3);
                    _players.Add(player4);
                    break;
            }
        }

        private static Player CreatePlayer(Control control, Texture2D carTexture, Map map)
        {
            return new Player(control, carTexture, new Vector2(map.StartX, map.StartY), map.StartRotation);
        }

    }
}
