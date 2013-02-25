using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace RaceGame
{
    public class ComputerPlayersAi : IComputerPlayersAI
    {
        public List<Player> ComputerPlayers { get; set; }
        private const float FORESIGHT = 20.0f;
        private const float FORESIGHT_ANGLE = 0.7f;
        private DateTime _lastMovement = DateTime.Now;
        private int _lastX, _lastY;
        private Random _random = new Random();

        public ComputerPlayersAi()
        {
            ComputerPlayers = new List<Player>();
        }

        public  void Update()
        {
            foreach (var player in ComputerPlayers)
            {
                float newX = player.Car.X + (float)Math.Cos((double)player.Car.Rotation) * FORESIGHT;
                float newY = player.Car.Y + (float)Math.Sin((double)player.Car.Rotation) * FORESIGHT;

                TerrainTypes type = player.Car.GetTerrain(new Vector2(newX, newY));

                if(type == TerrainTypes.Obstacle || type == TerrainTypes.Terrain)
                {
                    float newX_Right = player.Car.X + (float)Math.Cos((double)player.Car.Rotation + FORESIGHT_ANGLE) * FORESIGHT;
                    float newY_Right = player.Car.Y + (float)Math.Sin((double)player.Car.Rotation + FORESIGHT_ANGLE) * FORESIGHT;
                    TerrainTypes typeRight = player.Car.GetTerrain(new Vector2(newX_Right, newY_Right));
                    if(typeRight == TerrainTypes.Terrain ||typeRight == TerrainTypes.Obstacle)
                    {
                        player.Car.TurnLeft();
                    }
                    else
                    {
                        player.Car.TurnRight();
                    }
                }
                        player.Car.Accelerate();
                TurnRandom(player);
                CheckIfStuck(player);
            }
        }

        private void CheckIfStuck(Player player)
        {
            if(_lastX != player.Car.Position.X || _lastY != player.Car.Position.Y)
            {
                _lastMovement = DateTime.Now;
                _lastX = player.Car.Position.X;
                _lastY = player.Car.Position.Y;
            }
            else if(DateTime.Now.Subtract(_lastMovement).TotalSeconds >= 1)
            {
                 player.Car.TurnLeft();
            }
        }

       private void TurnRandom(Player player)
       {
           int chance = _random.Next(50);
           if (chance <= 5)
           {
               player.Car.TurnLeft();
           }
           else if (chance >= 45)
           {
               player.Car.TurnRight();
           }
           else if(chance == 30)
           {
               player.Car.Break();
           }
       }
    }
}

