using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace RaceGame
{
    public class ComputerPlayer
    {
        public List<Player> Players { get; set; }
        private const float FORESIGHT = 15.0f;
        private const float FORESIGHT_ANGLE = 0.5f;
        private DateTime lastMovement = DateTime.Now;
        private int lastX, lastY;
        private Random r = new Random();
        public ComputerPlayer()
        {
            Players = new List<Player>();
        }

        public  void Update()
        {
            foreach (var player in Players)
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
            if(lastX != player.Car.Position.X || lastY != player.Car.Position.Y)
            {
                lastMovement = DateTime.Now;
                lastX = player.Car.Position.X;
                lastY = player.Car.Position.Y;
            }
            else if(DateTime.Now.Subtract(lastMovement).TotalSeconds >= 1)
            {
                 player.Car.TurnLeft();
            }
        }

       private void TurnRandom(Player player)
       {
           int chance = r.Next(50);
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

