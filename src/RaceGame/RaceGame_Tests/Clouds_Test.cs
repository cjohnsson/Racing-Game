using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Microsoft.Xna.Framework.Graphics;
using RaceGame;
using Moq;

namespace RaceGame_Tests
{
    [TestFixture]
    class Clouds_Test
    {
        private Clouds CreateCloud()
        {
            Clouds cloud = new Clouds();
            cloud.X = new float[] {0, 800, 0, 800};
            cloud.Y = new float[] {0, -600, -600, 0};
            cloud.Width = 800;
            cloud.Height = 600;
            return cloud;
        }
        
        [Test]
        public void UpdateTest_PositionX_Pic1()
        {
            var cloud = CreateCloud();
            var x = cloud.X[0];
            cloud.Update();
            var newX = cloud.X[0];

            Assert.AreNotSame(x,newX);           
        }

        [Test]
        public void UpdateTesy_PositionY_Pic1()
        {
            var cloud = CreateCloud();
            var y = cloud.Y[0];
            cloud.Update();
            var newY = cloud.Y[0];
            
            Assert.AreNotSame(y, newY);
        }

        [Test]
        public void UpdateTest_PositionX_Pic2()
        {
            var cloud = CreateCloud();
            var x = cloud.X[1];
            cloud.Update();
            var newX = cloud.X[1];

            Assert.AreNotSame(x, newX);
        }

        [Test]
        public void UpdateTesy_PositionY_Pic2()
        {
            var cloud = CreateCloud();
            var y = cloud.Y[1];
            cloud.Update();
            var newY = cloud.Y[1];

            Assert.AreNotSame(y, newY);
        }

        [Test]
        public void UpdateTest_PositionX_Pic3()
        {
            var cloud = CreateCloud();
            var x = cloud.X[2];
            cloud.Update();
            var newX = cloud.X[2];

            Assert.AreNotSame(x, newX);
        }

        [Test]
        public void UpdateTesy_PositionY_Pic3()
        {
            var cloud = CreateCloud();
            var y = cloud.Y[2];
            cloud.Update();
            var newY = cloud.Y[2];

            Assert.AreNotSame(y, newY);
        }

        [Test]
        public void UpdateTest_PositionX_Pic4()
        {
            var cloud = CreateCloud();
            var x = cloud.X[3];
            cloud.Update();
            var newX = cloud.X[3];

            Assert.AreNotSame(x, newX);
        }

        [Test]
        public void UpdateTesy_PositionY_Pic4()
        {
            var cloud = CreateCloud();
            var y = cloud.Y[3];
            cloud.Update();
            var newY = cloud.Y[3];

            Assert.AreNotSame(y, newY);
        }
    }
}
