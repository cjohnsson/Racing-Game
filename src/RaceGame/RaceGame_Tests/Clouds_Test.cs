using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Microsoft.Xna.Framework.Graphics;
using RaceGame;

namespace RaceGame_Tests
{
    [TestFixture]
    class Clouds_Test
    {
        private Texture2D t2d;
        [Test]
        public void Update_TestPosition_Picture1()
        {
            var cloud = new Clouds(t2d);
            var x = cloud.X;
            var y = cloud.Y;
            cloud.Update();
            var newX = cloud.X;
            var newY = cloud.Y;

            Assert.AreNotSame(x,newX);
        }
    }
}
