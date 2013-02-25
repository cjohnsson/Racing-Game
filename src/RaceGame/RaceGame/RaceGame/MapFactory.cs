using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using RaceGame.Holders;

namespace RaceGame
{
    public static class MapFactory
    {
        private static Point[] _startPositions;
        private static float[] _startRotations;

        public static void Initilize()
        {
            _startPositions = new Point[ContentLoader.NR_OF_MAPS];

            _startPositions[0] = new Point(80, 270);
            _startPositions[1] = new Point(732, 216);
            _startPositions[2] = new Point(384, 550);
            _startPositions[3] = new Point(435, 545);
            _startPositions[4] = new Point(80, 270);

            _startRotations = new float[ContentLoader.NR_OF_MAPS];
            _startRotations[0] = 8.0f;
            _startRotations[1] = 8.0f;
            _startRotations[2] = 0.0f;
            _startRotations[3] = 3.2f;
            _startRotations[4] = 8.0f;
        }

        public static Map Create(int index)
        {
            return new Map(ContentLoader.GetMapBackground(index), ContentLoader.GetMapForeground(index), ContentLoader.GetMapCollision(index), new Texture2DHolder(ContentLoader.CloudTexture), _startPositions[index].X, _startPositions[index].Y, _startRotations[index]);
        }
    }
}
